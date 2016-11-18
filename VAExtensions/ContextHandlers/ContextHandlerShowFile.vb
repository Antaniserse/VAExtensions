Public Class ContextHandlerShowFile
    Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean
        Dim newFile As DownloadedFile = Nothing
        Dim textVar As String = Nothing

        If Context = ContextFactory.Contexts.ShowFile Then
            If VAProxy.GetText(App.KEY_FILE) Is Nothing Then
                VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                VAProxy.SetText(App.KEY_RESULT, String.Format("Unknown file name. Text variable '{0}' not set.", App.KEY_FILE))
                Return False
            End If

            Try
                newFile = App.DownloadFile(VAProxy.GetText(App.KEY_FILE))
                If newFile.LocalPath.Length = 0 Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("Error retrieving File '{0}'.", VAProxy.GetText(App.KEY_FILE)))
                    Return False
                End If
            Catch ex As Exception
                VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
                VAProxy.SetText(App.KEY_RESULT, String.Format("Error loading file content '{0}'.", VAProxy.GetText(App.KEY_FILE)))
                Return False
            End Try
        ElseIf Context = ContextFactory.Contexts.ShowText Then
            If VAProxy.GetText(App.KEY_ARGUMENTS) Is Nothing Then
                VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                VAProxy.SetText(App.KEY_RESULT, String.Format("Text variable '{0}' not set.", App.KEY_ARGUMENTS))
                Return False
            Else
                textVar = VAProxy.GetText(App.KEY_ARGUMENTS)
            End If
        End If

        Dim viewer As New TextForm(newFile, textVar)
        viewer.ShowDialog()
        viewer.Dispose()
        If newFile IsNot Nothing AndAlso newFile.IsTemporary Then App.Settings.AddDownloadedFile(newFile)

        Return True
    End Function
End Class
