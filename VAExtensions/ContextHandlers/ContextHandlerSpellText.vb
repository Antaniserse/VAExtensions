Public Class ContextHandlerSpellText
   Inherits ContextHandlerBase

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

      If Not m_TextValues.ContainsKey(App.KEY_SPELL) Then
         m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
         m_TextValues(App.KEY_RESULT) = String.Format("Text value '{0}' not set", App.KEY_SPELL)
         Return False
      Else
         If String.IsNullOrEmpty(m_TextValues(App.KEY_SPELL)) Then
            m_TextValues(App.KEY_RESULT) = String.Empty
            m_smallIntValues(App.KEY_SPELLASCII) = 0
         Else
            m_TextValues(App.KEY_RESULT) = m_TextValues(App.KEY_SPELL).Substring(0, 1)
            m_TextValues(App.KEY_SPELL) = m_TextValues(App.KEY_SPELL).Substring(1, m_TextValues(App.KEY_SPELL).Length - 1)
            m_smallIntValues(App.KEY_SPELLASCII) = Text.Encoding.ASCII.GetBytes(m_TextValues(App.KEY_RESULT))(0)
         End If
      End If

      Return True
   End Function
End Class
