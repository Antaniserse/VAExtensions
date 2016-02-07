Public Class ContextHandlerReadINI
   Inherits ContextHandlerBase

   Private Declare Auto Function GetPrivateProfileString Lib "kernel32.dll" (ByVal lpAppName As String, _
        ByVal lpKeyName As String, _
        ByVal lpDefault As String, _
        ByVal lpReturnedString As System.Text.StringBuilder, _
        ByVal nSize As Integer, _
        ByVal lpFileName As String) As Integer


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

      If Not m_TextValues.ContainsKey(App.KEY_FILE) Then
         m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
         m_TextValues(App.KEY_RESULT) = String.Format("Unknown file name. Text variable '{0}' not set.", App.KEY_FILE)
         Return False
      End If

      If Not m_TextValues.ContainsKey(App.KEY_INI_SECTION) OrElse Not m_TextValues.ContainsKey(App.KEY_INI_KEY) Then
         m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
         m_TextValues(App.KEY_RESULT) = "Both a 'Section' and a 'Key' arguments are required."
         Return False
      End If

      Dim iniFile As String = m_TextValues(App.KEY_FILE)

      If Not IO.Path.IsPathRooted(iniFile) Then
         iniFile = IO.Path.Combine(App.LibraryFolder, iniFile)
      End If

      If Not IO.File.Exists(iniFile) Then
         m_smallIntValues(App.KEY_ERROR) = ERR_IO
         m_TextValues(App.KEY_RESULT) = String.Format("File '{0}' not found.", iniFile)
         Return False
      End If

      Dim resultSB As New Text.StringBuilder(512)
      Dim result As Integer = GetPrivateProfileString(m_TextValues(App.KEY_INI_SECTION), m_TextValues(App.KEY_INI_KEY), String.Empty, resultSB, resultSB.Capacity, iniFile)

      If result = 0 Then
         m_smallIntValues(App.KEY_ERROR) = ERR_IO
         m_TextValues(App.KEY_RESULT) = String.Format("Key '{0}' not found in section '{1}'.", m_TextValues(App.KEY_INI_KEY), m_TextValues(App.KEY_INI_SECTION))
         Return False
      Else
         m_TextValues(App.KEY_RESULT) = resultSB.ToString
         Return True
      End If
   End Function
End Class
