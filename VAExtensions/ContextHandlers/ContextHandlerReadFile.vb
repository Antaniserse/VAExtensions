Public Class ContextHandlerReadFile
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

      If Not m_TextValues.ContainsKey(App.KEY_FILE) Then
         m_smallIntValues(App.KEY_ERROR) = ERR_CONTEXT
         m_TextValues(App.KEY_RESULT) = String.Format("Unknown file name. Text variable ""{0}"" not set.", App.KEY_FILE)
         Return False
      End If

      If m_TextValues.ContainsKey(App.KEY_REGEX) Then
         regexPattern = m_TextValues(App.KEY_REGEX)
      Else
         regexPattern = String.Empty
      End If
      Try
         newFile = App.DownloadTextFile(m_TextValues(App.KEY_FILE))
         If newFile.LocalPath.Length = 0 Then
            m_smallIntValues(App.KEY_ERROR) = ERR_IO
            m_TextValues(App.KEY_RESULT) = String.Format("Error retrieving file ""{0}"".", m_TextValues(App.KEY_FILE))
            Return False
         End If

         Dim newFileContent As String = IO.File.ReadAllText(newFile.LocalPath)
         m_TextValues(App.KEY_RESULT) = App.LimitResponse(newFileContent, regexPattern)

      Catch ex As Exception
         m_smallIntValues(App.KEY_ERROR) = ERR_IO
         m_TextValues(App.KEY_RESULT) = String.Format("Error loading file content ""{0}"" ({1}).", m_TextValues(App.KEY_FILE), ex.Message)
      End Try
      If newFile.IsTemporary Then App.Settings.AddDownloadedFile(newFile)

      Return True
   End Function

End Class
