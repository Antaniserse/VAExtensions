Public Class ContextHandlerCompareText
   Inherits ContextHandlerBase

   Public Sub New(ByVal context As ContextFactory.Contexts, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      MyBase.New(context, state, conditions, textValues, extendedValues)
   End Sub

   Public Overrides Function Execute() As Boolean

      If m_TextValues.Count < 2 Then
         m_Conditions(App.KEY_ERROR) = ERR_ARGUMENTS
         m_TextValues(App.KEY_RESULT) = "Two text variable are needed for comparison."
         Return False
      Else
         Dim i As Integer
         i = String.Compare(m_TextValues(m_TextValues.Keys(0)), m_TextValues(m_TextValues.Keys(1)), StringComparison.OrdinalIgnoreCase)
         If i > 0 Then
            m_Conditions(App.KEY_COMPARISON) = 1
         ElseIf i < 0 Then
            m_Conditions(App.KEY_COMPARISON) = -1
         Else
            m_Conditions(App.KEY_COMPARISON) = 0
         End If
         m_TextValues(App.KEY_RESULT) = m_Conditions(App.KEY_COMPARISON).ToString
      End If

      Return True
   End Function
End Class
