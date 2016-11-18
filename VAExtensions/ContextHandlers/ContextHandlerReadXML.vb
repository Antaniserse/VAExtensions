Public Class ContextHandlerReadXML
    Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean
        Dim newFile As DownloadedFile = Nothing
        Dim regexPattern As String
        Dim elementPath As String()
        Dim i As Integer, elementCount As Short

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
        If VAProxy.GetText(App.KEY_ARGUMENTS) IsNot Nothing AndAlso VAProxy.GetText(App.KEY_ARGUMENTS).Length > 0 Then
            elementPath = VAProxy.GetText(App.KEY_ARGUMENTS).Split("\"c)
        Else
            elementPath = {}
        End If
        If VAProxy.GetSmallInt(App.KEY_INDEX) Is Nothing OrElse VAProxy.GetSmallInt(App.KEY_INDEX) < 1 Then
            elementCount = 1
        Else
            elementCount = VAProxy.GetSmallInt(App.KEY_INDEX)
        End If

        Try
            newFile = App.DownloadFile(VAProxy.GetText(App.KEY_FILE))
            If newFile.LocalPath.Length = 0 Then
                VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
                VAProxy.SetText(App.KEY_RESULT, String.Format("Error retrieving File '{0}'.", VAProxy.GetText(App.KEY_FILE)))
                Return False
            End If

            Dim xDoc As Xml.Linq.XDocument = Xml.Linq.XDocument.Load(newFile.LocalPath)
            Dim xElement1 As IEnumerable(Of Xml.Linq.XElement) = xDoc.Elements(elementPath(0))

            For i = 1 To elementPath.Length - 1
                xElement1 = From el In xElement1.Elements(elementPath(i)) Select el
            Next

            If xElement1 IsNot Nothing AndAlso xElement1.Value IsNot Nothing Then
                i = 1
                For Each el As Xml.Linq.XElement In xElement1
                    VAProxy.SetText(App.KEY_RESULT, el.Value)
                    i += 1
                    If i > elementCount Then Exit For
                Next
                VAProxy.SetSmallInt(App.KEY_INDEX, elementCount + 1S)
                VAProxy.SetText(App.KEY_RESULT, App.LimitResponse(VAProxy.GetText(App.KEY_RESULT), regexPattern))
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
