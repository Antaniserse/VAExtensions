Public Class ContextHandlerReadFile
    Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean
        Dim newFile As DownloadedFile = Nothing
        Dim regexPattern As String

        If VAProxy.GetText(App.KEY_FILE) Is Nothing Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Unknown file name. Text variable '{0}' not set.", App.KEY_FILE))
            Return False
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

            'Dim newFileContent As String = IO.File.ReadAllText(newFile.LocalPath)
            Dim newFileContent As String = App.ReadTextFile(newFile.LocalPath)
            VAProxy.SetText(App.KEY_RESULT, App.LimitResponse(newFileContent, regexPattern))

        Catch ex As Exception
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Error loading file content '{0}' ({1}).", VAProxy.GetText(App.KEY_FILE), ex.Message))
        End Try
        If newFile.IsTemporary Then App.Settings.AddDownloadedFile(newFile)

        Return True
    End Function

End Class
