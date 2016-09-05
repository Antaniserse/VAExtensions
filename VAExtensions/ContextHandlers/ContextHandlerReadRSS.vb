﻿Public Class ContextHandlerReadRSS
   Inherits ContextHandlerBase

   Public Sub New(ByVal context As ContextFactory.Contexts _
                        , ByRef state As Dictionary(Of String, Object) _
                        , ByRef smallIntValues As Dictionary(Of String, Nullable(Of Short)) _
                        , ByRef textValues As Dictionary(Of String, String) _
                        , ByRef intValues As Dictionary(Of String, Nullable(Of Integer)) _
                        , ByRef decimalValues As Dictionary(Of String, Nullable(Of Decimal)) _
                        , ByRef booleanValues As Dictionary(Of String, Nullable(Of Boolean)) _
                        , ByRef extendedValues As Dictionary(Of String, Object))

      MyBase.New(context, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
   End Sub


   Public Overrides Function Execute() As Boolean
      Dim newFile As DownloadedFile = Nothing
      Dim regexPattern As String
      Dim i As Integer, elementCount As Short
      Dim reader As Xml.XmlReader
      Dim feed As System.ServiceModel.Syndication.SyndicationFeed

      If Not m_TextValues.ContainsKey(App.KEY_FILE) Then
         m_smallIntValues(App.KEY_ERROR) = ERR_CONTEXT
         m_TextValues(App.KEY_RESULT) = String.Format("Unknown file name. Text variable '{0}' not set.", App.KEY_FILE)
         Return False
      End If
      If Not m_smallIntValues.ContainsKey(App.KEY_INDEX) OrElse Not m_smallIntValues(App.KEY_INDEX).HasValue OrElse m_smallIntValues(App.KEY_INDEX).Value < 1 Then
         elementCount = 1
      Else
         elementCount = m_smallIntValues(App.KEY_INDEX).Value
      End If
      If m_TextValues.ContainsKey(App.KEY_REGEX) Then
         regexPattern = m_TextValues(App.KEY_REGEX)
      Else
         regexPattern = String.Empty
      End If

      Try
         newFile = App.DownloadFile(m_TextValues(App.KEY_FILE))
         If newFile.LocalPath.Length = 0 Then
            m_smallIntValues(App.KEY_ERROR) = ERR_IO
            m_TextValues(App.KEY_RESULT) = String.Format("Error retrieving File '{0}'.", m_TextValues(App.KEY_FILE))
            Return False
         End If

         If m_TextValues.ContainsKey(App.KEY_RSSFORMAT) AndAlso Not String.IsNullOrEmpty(m_TextValues(App.KEY_RSSFORMAT)) Then
            DateFixXmlReader.CustomUtcDateTimeFormat = m_TextValues(App.KEY_RSSFORMAT)
         End If
         reader = New DateFixXmlReader(newFile.LocalPath)
         feed = System.ServiceModel.Syndication.SyndicationFeed.Load(reader)
         reader.Close()

         If feed IsNot Nothing AndAlso feed.Items IsNot Nothing Then
            Dim sortedList As IEnumerable(Of System.ServiceModel.Syndication.SyndicationItem) = feed.Items.OrderByDescending(Function(itm) itm.PublishDate)
            Dim itemSummary As System.ServiceModel.Syndication.TextSyndicationContent

            i = 1
            For Each item As System.ServiceModel.Syndication.SyndicationItem In sortedList
               If item.Summary IsNot Nothing Then
                  itemSummary = item.Summary
               ElseIf item.Content IsNot Nothing AndAlso TypeOf item.Content Is System.ServiceModel.Syndication.TextSyndicationContent Then
                  itemSummary = DirectCast(item.Content, System.ServiceModel.Syndication.TextSyndicationContent)
               Else
                  itemSummary = New System.ServiceModel.Syndication.TextSyndicationContent("No summary found")
               End If

               If String.IsNullOrEmpty(m_TextValues(App.KEY_ARGUMENTS)) Then
                  m_TextValues(App.KEY_RESULT) = item.Title.Text
               ElseIf m_TextValues(App.KEY_ARGUMENTS).ToLower = "title" Then
                  m_TextValues(App.KEY_RESULT) = item.Title.Text
               ElseIf m_TextValues(App.KEY_ARGUMENTS).ToLower = "summary" Then
                  m_TextValues(App.KEY_RESULT) = itemSummary.Text
               ElseIf m_TextValues(App.KEY_ARGUMENTS).ToLower = "title&summary" Then
                  m_TextValues(App.KEY_RESULT) = String.Format("{0}. {1}", item.Title.Text, itemSummary.Text)
               End If
               i += 1
               If i > elementCount Then Exit For
            Next
            m_TextValues(App.KEY_RESULT) = App.LimitResponse(m_TextValues(App.KEY_RESULT), regexPattern)
            m_smallIntValues(App.KEY_INDEX) = elementCount + 1S
         Else
            m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
            m_TextValues(App.KEY_RESULT) = String.Format("Element not found: '{0}'", m_TextValues(App.KEY_ARGUMENTS))
         End If

      Catch ex As Exception
         m_smallIntValues(App.KEY_ERROR) = ERR_IO
         m_TextValues(App.KEY_RESULT) = String.Format("Error reading XML: {0}", ex.Message)
         Return False
      End Try
      If newFile.IsTemporary Then App.Settings.AddDownloadedFile(newFile)

      Return True
   End Function
End Class
