Public MustInherit Class ContextHandlerBase
   Public Const ERR_CONTEXT As Int16 = 1
   Public Const ERR_IO As Int16 = 2
   Public Const ERR_ARGUMENTS As Int16 = 3

   Protected m_Context As ContextFactory.Contexts
   Protected m_State As Dictionary(Of String, Object)
   Protected m_smallIntValues As Dictionary(Of String, Nullable(Of Short))
   Protected m_TextValues As Dictionary(Of String, String)
   Protected m_intValues As Dictionary(Of String, Nullable(Of Integer))
   Protected m_decimalValues As Dictionary(Of String, Nullable(Of Decimal))
   Protected m_booleanValues As Dictionary(Of String, Nullable(Of Boolean))
   Protected m_ExtendedValues As Dictionary(Of String, Object)

   Public Sub New(ByVal context As ContextFactory.Contexts, ByRef state As Dictionary(Of String, Object) _
                        , ByRef smallIntValues As Dictionary(Of String, Nullable(Of Short)) _
                        , ByRef textValues As Dictionary(Of String, String) _
                        , ByRef intValues As Dictionary(Of String, Nullable(Of Integer)) _
                        , ByRef decimalValues As Dictionary(Of String, Nullable(Of Decimal)) _
                        , ByRef booleanValues As Dictionary(Of String, Nullable(Of Boolean)) _
                        , ByRef extendedValues As Dictionary(Of String, Object))


      m_Context = context
      m_State = state
      m_smallIntValues = smallIntValues
      m_TextValues = textValues
      m_intValues = intValues
      m_decimalValues = decimalValues
      m_booleanValues = booleanValues
      m_ExtendedValues = extendedValues
   End Sub

   Public MustOverride Function Execute() As Boolean
End Class
