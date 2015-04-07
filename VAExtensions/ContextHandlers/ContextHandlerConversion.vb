Public Class ContextHandlerConversion
   Inherits ContextHandlerBase

   Public Sub New(ByVal context As ContextFactory.Contexts, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      MyBase.New(context, state, conditions, textValues, extendedValues)
   End Sub

   Public Overrides Function Execute() As Boolean
      If m_Context = ContextFactory.Contexts.TextToNum Then
         If m_TextValues.Count = 0 Then
            m_Conditions(App.KEY_ERROR) = ERR_ARGUMENTS
            m_TextValues(App.KEY_RESULT) = "At least one text value is needed."
            Return False
         End If

         Dim val As Short
         For Each k As String In m_TextValues.Keys
            If Short.TryParse(m_TextValues(k), val) Then
               m_Conditions(k) = val
            Else
               m_Conditions(k) = 0
            End If
         Next
      Else
         If m_Conditions.Count = 0 Then
            m_Conditions(App.KEY_ERROR) = ERR_ARGUMENTS
            m_TextValues(App.KEY_RESULT) = "At least one condition is needed."
            Return False
         End If

         For Each k As String In m_Conditions.Keys
            If m_Conditions(k).HasValue Then
               m_TextValues(k) = Convert.ToString(m_Conditions(k).Value)
            End If
         Next
      End If

      Return True
   End Function
End Class
