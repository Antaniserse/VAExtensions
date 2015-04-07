Public MustInherit Class ContextHandlerBase
   Public Const ERR_CONTEXT As Int16 = 1
   Public Const ERR_IO As Int16 = 2
   Public Const ERR_ARGUMENTS As Int16 = 3

   Protected m_Context As ContextFactory.Contexts
   Protected m_State As Dictionary(Of String, Object)
   Protected m_Conditions As Dictionary(Of String, Nullable(Of Int16))
   Protected m_TextValues As Dictionary(Of String, String)
   Protected m_ExtendedValues As Dictionary(Of String, Object)

   Public Sub New(ByVal context As ContextFactory.Contexts, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      m_Context = context
      m_State = state
      m_Conditions = conditions
      m_TextValues = textValues
      m_ExtendedValues = extendedValues
   End Sub

   Public MustOverride Function Execute() As Boolean
End Class
