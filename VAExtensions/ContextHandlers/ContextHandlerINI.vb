Public Class ContextHandlerReadINI
   Inherits ContextHandlerBase

   Private Declare Auto Function GetPrivateProfileString Lib "kernel32.dll" (ByVal lpAppName As String, _
        ByVal lpKeyName As String, _
        ByVal lpDefault As String, _
        ByVal lpReturnedString As System.Text.StringBuilder, _
        ByVal nSize As Integer, _
        ByVal lpFileName As String) As Integer


    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean

        If VAProxy.GetText(App.KEY_FILE) Is Nothing Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Unknown file name. Text variable '{0}' not set.", App.KEY_FILE))
            Return False
        End If

        If VAProxy.GetText(App.KEY_INI_SECTION) Is Nothing OrElse VAProxy.GetText(App.KEY_INI_KEY) Is Nothing Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Both '{0}' and '{1}' arguments are required.", App.KEY_INI_SECTION, App.KEY_INI_KEY))
            Return False
        End If

        Dim iniFile As String = VAProxy.GetText(App.KEY_FILE)

        If Not IO.Path.IsPathRooted(iniFile) Then
            iniFile = IO.Path.Combine(App.LibraryFolder, iniFile)
        End If

        If Not IO.File.Exists(iniFile) Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
            VAProxy.SetText(App.KEY_RESULT, String.Format("File '{0}' not found.", iniFile))
            Return False
        End If

        Dim resultSB As New Text.StringBuilder(512)
        Dim result As Integer = GetPrivateProfileString(VAProxy.GetText(App.KEY_INI_SECTION), VAProxy.GetText(App.KEY_INI_KEY), String.Empty, resultSB, resultSB.Capacity, iniFile)

        If result = 0 Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Key '{0}' not found in section '{1}'.", VAProxy.GetText(App.KEY_INI_KEY), VAProxy.GetText(App.KEY_INI_SECTION)))
            Return False
        Else
            VAProxy.SetText(App.KEY_RESULT, resultSB.ToString)
            Return True
      End If
   End Function
End Class

Public Class ContextHandlerWriteINI
    Inherits ContextHandlerBase

    Private Declare Auto Function WritePrivateProfileString Lib "kernel32.dll" (ByVal lpAppName As String _
         , ByVal lpKeyName As String _
         , ByVal lpString As String _
         , ByVal lpFileName As String) As Integer

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean

        If VAProxy.GetText(App.KEY_FILE) Is Nothing Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Unknown file name. Text variable '{0}' not set.", App.KEY_FILE))
            Return False
        End If

        If VAProxy.GetText(App.KEY_INI_SECTION) Is Nothing OrElse VAProxy.GetText(App.KEY_INI_KEY) Is Nothing OrElse VAProxy.GetText(App.KEY_ARGUMENTS) Is Nothing Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
            VAProxy.SetText(App.KEY_RESULT, String.Format("A '{0}', '{1}' and '{2}' arguments are required.", App.KEY_INI_SECTION, App.KEY_INI_KEY, App.KEY_ARGUMENTS))
            Return False
        End If

        Dim iniFile As String = VAProxy.GetText(App.KEY_FILE)

        If Not IO.Path.IsPathRooted(iniFile) Then
            iniFile = IO.Path.Combine(App.LibraryFolder, iniFile)
        End If

        Dim result As Integer
        result = WritePrivateProfileString(VAProxy.GetText(App.KEY_INI_SECTION), VAProxy.GetText(App.KEY_INI_KEY), VAProxy.GetText(App.KEY_ARGUMENTS), iniFile)
        If result = 0 Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
            VAProxy.SetText(App.KEY_RESULT, "Error writing INI value.")
            Return False
        Else
            Return True
        End If

    End Function
End Class