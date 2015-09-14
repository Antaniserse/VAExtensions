Public Class ContextHandlerCountdown
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

      If m_smallIntValues.Count = 0 Then
         m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
         m_TextValues(App.KEY_RESULT) = "At least a numeric condition is needed to manage the countdown."
         Return False
      Else
         Dim lastRun, thisRun As DateTime, diff As TimeSpan
         Dim result As Integer
         Dim countDown As Short
         Dim countdownName As String

         thisRun = Now
         countdownName = "count_" & m_smallIntValues.Keys(0)
         countDown = m_smallIntValues(m_smallIntValues.Keys(0)).Value

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
         m_smallIntValues(App.KEY_RESULT) = Convert.ToInt16(result)
      End If

      Return True
   End Function
End Class
