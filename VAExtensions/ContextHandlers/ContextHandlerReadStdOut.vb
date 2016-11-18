Public Class ContextHandlerReadStdOut
    Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean
        Dim newFile As DownloadedFile = Nothing

        If VAProxy.GetText(App.KEY_FILE) Is Nothing Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Unknown file name. Text variable '{0}' not set.", App.KEY_FILE))
            Return False
        End If

        Try
            Dim pName As String = VAProxy.GetText(App.KEY_FILE)
            Dim pInfo As ProcessStartInfo
            Dim pOutput As String
            Dim p As Process

            If Not IO.Path.IsPathRooted(pName) Then
                pName = IO.Path.Combine(IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.Location), pName)
            End If
            pInfo = New ProcessStartInfo(pName) With {.UseShellExecute = False, .CreateNoWindow = True, .RedirectStandardOutput = True}
            If Not String.IsNullOrEmpty(VAProxy.GetText(App.KEY_ARGUMENTS)) Then
                pInfo.Arguments = VAProxy.GetText(App.KEY_ARGUMENTS)
            End If

            p = Process.Start(pInfo)
            pOutput = p.StandardOutput.ReadToEnd
            p.WaitForExit()

            VAProxy.SetText(App.KEY_RESULT, App.LimitResponse(pOutput))
        Catch ex As Exception
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Error running process '{0}' - {1}.", VAProxy.GetText(App.KEY_FILE), ex.Message))
            Return False
        End Try

        Return True
    End Function
End Class
