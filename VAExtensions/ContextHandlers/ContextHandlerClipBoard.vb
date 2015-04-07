Public Class ContextHandlerClipBoard
   Inherits ContextHandlerBase

   Public Sub New(ByVal context As ContextFactory.Contexts, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      MyBase.New(context, state, conditions, textValues, extendedValues)
   End Sub

   Public Overrides Function Execute() As Boolean

      Select Case m_Context
         Case ContextFactory.Contexts.ClipboardSet
            If m_TextValues.Count = 0 Then
               m_Conditions(App.KEY_ERROR) = ERR_ARGUMENTS
               m_TextValues(App.KEY_RESULT) = "At least one text value is needed."
               Return False
            Else
               m_TextValues(App.KEY_RESULT) = m_TextValues(m_TextValues.Keys(0))
               clipboard_access(AddressOf clipboardWorkerSET)
            End If
         Case ContextFactory.Contexts.ClipboardGet
            If System.Windows.Forms.Clipboard.ContainsText Then
               clipboard_access(AddressOf clipboardWorkerGET)
            Else
               m_Conditions(App.KEY_ERROR) = ERR_IO
               m_TextValues(App.KEY_RESULT) = "Clipboard contains unsupported (non-text) data format."
            End If
         Case Else
            m_Conditions(App.KEY_ERROR) = ERR_CONTEXT
            m_TextValues(App.KEY_RESULT) = String.Format("Unexpected context in clipboard operation ""{0}"".", EnumInfoAttribute.GetTag(m_Context))
            Return False
      End Select

      Return True
   End Function

#Region " Thread helper for clipboard access"
   Private Sub clipboard_access(ts As Threading.ThreadStart)
      Dim clipboardThread As New Threading.Thread(ts)
      clipboardThread.SetApartmentState(Threading.ApartmentState.STA) 'needed; the reason we are doing this in a separate thread
      clipboardThread.IsBackground = False
      clipboardThread.Start()
   End Sub

   Private Sub clipboardWorkerGET()
      m_TextValues(App.KEY_RESULT) = System.Windows.Forms.Clipboard.GetText
   End Sub
   Private Sub clipboardWorkerSET()
      System.Windows.Forms.Clipboard.SetText(m_TextValues(App.KEY_RESULT))
   End Sub
#End Region
End Class
