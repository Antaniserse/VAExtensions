Public Class ContextHandlerSpellText
   Inherits ContextHandlerBase

   Public Sub New(ByVal context As ContextFactory.Contexts, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      MyBase.New(context, state, conditions, textValues, extendedValues)
   End Sub

   Public Overrides Function Execute() As Boolean

      If Not m_TextValues.ContainsKey(App.KEY_SPELL) Then
         m_Conditions(App.KEY_ERROR) = ERR_ARGUMENTS
         m_TextValues(App.KEY_RESULT) = String.Format("Text value '{0}' not set", App.KEY_SPELL)
         Return False
      Else
         If String.IsNullOrEmpty(m_TextValues(App.KEY_SPELL)) Then
            m_TextValues(App.KEY_RESULT) = String.Empty
            m_Conditions(App.KEY_SPELLASCII) = 0
         Else
            m_TextValues(App.KEY_RESULT) = m_TextValues(App.KEY_SPELL).Substring(0, 1)
            m_TextValues(App.KEY_SPELL) = m_TextValues(App.KEY_SPELL).Substring(1, m_TextValues(App.KEY_SPELL).Length - 1)
            m_Conditions(App.KEY_SPELLASCII) = Text.Encoding.ASCII.GetBytes(m_TextValues(App.KEY_RESULT))(0)
         End If
      End If

      Return True
   End Function
End Class
