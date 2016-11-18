Public Class ContextHandlerReadRSS
    Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean
        Dim newFile As DownloadedFile = Nothing
        Dim regexPattern As String
        Dim i As Integer, elementCount As Short
        Dim reader As Xml.XmlReader
        Dim feed As System.ServiceModel.Syndication.SyndicationFeed

        If VAProxy.GetText(App.KEY_FILE) Is Nothing Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Unknown file name. Text variable '{0}' not set.", App.KEY_FILE))
            Return False
        End If
        If VAProxy.GetSmallInt(App.KEY_INDEX) Is Nothing OrElse VAProxy.GetSmallInt(App.KEY_INDEX).Value < 1 Then
            elementCount = 1
        Else
            elementCount = VAProxy.GetSmallInt(App.KEY_INDEX).Value
        End If
        If VAProxy.GetText(App.KEY_REGEX) IsNot Nothing Then
            regexPattern = VAProxy.GetText(App.KEY_REGEX)
        Else
            regexPattern = String.Empty
        End If

        Try
            newFile = App.DownloadFile(VAProxy.GetText(App.KEY_FILE))
            If newFile.LocalPath.Length = 0 Then
                VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
                VAProxy.SetText(App.KEY_RESULT, String.Format("Error retrieving File '{0}'.", VAProxy.GetText(App.KEY_FILE)))
                Return False
            End If

            If Not String.IsNullOrEmpty(VAProxy.GetText(App.KEY_RSSFORMAT)) Then
                DateFixXmlReader.CustomUtcDateTimeFormat = VAProxy.GetText(App.KEY_RSSFORMAT)
            End If
            reader = New DateFixXmlReader(newFile.LocalPath)
            feed = System.ServiceModel.Syndication.SyndicationFeed.Load(reader)
            reader.Close()

            If feed IsNot Nothing AndAlso feed.Items IsNot Nothing Then
                Dim sortedList As IEnumerable(Of System.ServiceModel.Syndication.SyndicationItem) = feed.Items.OrderByDescending(Function(itm) itm.PublishDate)
                Dim itemSummary As System.ServiceModel.Syndication.TextSyndicationContent
                Dim result As String = String.Empty

                i = 1
                For Each item As System.ServiceModel.Syndication.SyndicationItem In sortedList
                    If item.Summary IsNot Nothing Then
                        itemSummary = item.Summary
                    ElseIf item.Content IsNot Nothing AndAlso TypeOf item.Content Is System.ServiceModel.Syndication.TextSyndicationContent Then
                        itemSummary = DirectCast(item.Content, System.ServiceModel.Syndication.TextSyndicationContent)
                    Else
                        itemSummary = New System.ServiceModel.Syndication.TextSyndicationContent("No summary found")
                    End If

                    If String.IsNullOrEmpty(VAProxy.GetText(App.KEY_ARGUMENTS)) Then
                        result = item.Title.Text
                    ElseIf VAProxy.GetText(App.KEY_ARGUMENTS).ToLower = "title" Then
                        result = item.Title.Text
                    ElseIf VAProxy.GetText(App.KEY_ARGUMENTS).ToLower = "summary" Then
                        result = itemSummary.Text
                    ElseIf VAProxy.GetText(App.KEY_ARGUMENTS).ToLower = "title&summary" Then
                        result = String.Format("{0}. {1}", item.Title.Text, itemSummary.Text)
                    End If
                    i += 1
                    If i > elementCount Then Exit For
                Next
                VAProxy.SetText(App.KEY_RESULT, App.LimitResponse(result, regexPattern))
                VAProxy.SetSmallInt(App.KEY_INDEX) = elementCount + 1S
            Else
                VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                VAProxy.SetText(App.KEY_RESULT, String.Format("Element not found: '{0}'", VAProxy.GetText(App.KEY_ARGUMENTS)))
            End If

        Catch ex As Exception
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Error reading XML: {0}", ex.Message))
            Return False
        End Try
        If newFile.IsTemporary Then App.Settings.AddDownloadedFile(newFile)

        Return True
    End Function
End Class
