Public Class ContextHandlerCountdown
   Inherits ContextHandlerBase

   Public Sub New(ByVal context As ContextFactory.Contexts, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      MyBase.New(context, state, conditions, textValues, extendedValues)
   End Sub

   Public Overrides Function Execute() As Boolean

      If m_Conditions.Count = 0 Then
         m_Conditions(App.KEY_ERROR) = ERR_ARGUMENTS
         m_TextValues(App.KEY_RESULT) = "At least a numeric condition is needed to manage the countdown."
         Return False
      Else
         Dim lastRun, thisRun As DateTime, diff As TimeSpan
         Dim result As Integer
         Dim countDown As Short
         Dim countdownName As String

         thisRun = Now
         countdownName = "count_" & m_Conditions.Keys(0)
         countDown = m_Conditions(m_Conditions.Keys(0)).Value

         If m_State.ContainsKey(countdownName) Then
            lastRun = CType(m_State(countdownName), DateTime)
            diff = thisRun - lastRun
            If diff.TotalSeconds < countDown Then
               result = CInt(countDown - diff.TotalSeconds)
            Else
               m_State(countdownName) = thisRun
               result = 0
            End If
         Else
            m_State(countdownName) = thisRun
            result = 0
         End If
         m_Conditions(App.KEY_RESULT) = Convert.ToInt16(result)
      End If

      Return True
   End Function
End Class
