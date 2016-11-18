Imports Newtonsoft

Public Class ContextHandlerReadJSON
    Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean
        Dim newFile As DownloadedFile = Nothing
        Dim regexPattern As String
        Dim elementPath As String
        Dim elementCount As Short

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
        If Not String.IsNullOrEmpty(VAProxy.GetText(App.KEY_ARGUMENTS)) Then
            elementPath = VAProxy.GetText(App.KEY_ARGUMENTS)
        Else
            elementPath = String.Empty
        End If

        Try
            newFile = App.DownloadFile(VAProxy.GetText(App.KEY_FILE))
            If newFile.LocalPath.Length = 0 Then
                VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
                VAProxy.SetText(App.KEY_RESULT, String.Format("Error retrieving File '{0}'.", VAProxy.GetText(App.KEY_FILE)))
                Return False
            End If

            Dim jobj As Json.Linq.JObject = Json.Linq.JObject.Parse(App.ReadTextFile(newFile.LocalPath))

            Dim token As Json.Linq.JToken = jobj.SelectToken(elementPath)
            If token IsNot Nothing Then
                VAProxy.SetText(App.KEY_RESULT, App.LimitResponse(token.ToString, regexPattern))
                VAProxy.SetSmallInt(App.KEY_INDEX, elementCount + 1S)
            Else
                VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                VAProxy.SetText(App.KEY_RESULT, String.Format("Element not found: '{0}'", elementPath))
            End If

        Catch ex As Exception
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Error reading JSON: {0}", ex.Message))
            Return False
        End Try
        If newFile.IsTemporary Then App.Settings.AddDownloadedFile(newFile)

        Return True
    End Function
End Class
