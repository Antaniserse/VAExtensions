Public Class ContextHandlerCompareText
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

      If m_TextValues.Count < 2 Then
         m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
         m_TextValues(App.KEY_RESULT) = "Two text variable are needed for comparison."
         Return False
      Else
         Dim i As Integer
         i = String.Compare(m_TextValues(m_TextValues.Keys(0)), m_TextValues(m_TextValues.Keys(1)), StringComparison.OrdinalIgnoreCase)
         If i > 0 Then
            m_smallIntValues(App.KEY_COMPARISON) = 1
         ElseIf i < 0 Then
            m_smallIntValues(App.KEY_COMPARISON) = -1
         Else
            m_smallIntValues(App.KEY_COMPARISON) = 0
         End If
         m_TextValues(App.KEY_RESULT) = m_smallIntValues(App.KEY_COMPARISON).ToString
      End If

      Return True
   End Function
End Class
