Public Class ContextHandlerCountdown
    Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean

        Dim countDownList As New Dictionary(Of String, Int32)
        Dim key As String
        Dim i As Integer

        'Since the new VAProxy interface expose every possible INT value in the profile, we don't know how many 'VxCountdown' token are present,
        'and how many were intended for this specific call; for now, we allow a fixed number of 10
        For i = 0 To 9
            key = String.Format("{0}{1}", App.KEY_TIMER, i)
            If VAProxy.GetInt(key) IsNot Nothing Then
                countDownList.Add(key, VAProxy.GetInt(key))
            End If
        Next

        If countDownList.Count = 0 Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
            VAProxy.SetText(App.KEY_RESULT, String.Format("At least a numeric condition '{0}<index>' is needed to manage the timer.", App.KEY_TIMER))
            Return False
        Else
            Dim lastRun, thisRun As DateTime, diff As TimeSpan
            Dim result As Integer
            Dim timerValue As Integer
            Dim timerName As String

            thisRun = Now
            For Each kvp As KeyValuePair(Of String, Int32) In countDownList
                timerName = kvp.Key
                timerValue = kvp.Value

                If Context = ContextFactory.Contexts.TimerStart Then
                    VAProxy.SessionState(timerName) = thisRun
                Else
                    If VAProxy.SessionState.ContainsKey(timerName) Then
                        lastRun = CType(VAProxy.SessionState(timerName), DateTime)
                        diff = thisRun - lastRun
                        If diff.TotalSeconds < timerValue Then
                            result = CInt(timerValue - diff.TotalSeconds)
                        Else
                            VAProxy.SessionState(timerName) = Nothing 'timer expired
                            result = 0
                        End If
                        VAProxy.SetSmallInt(App.KEY_ERROR, 0)
                        VAProxy.SetInt(timerName.Replace(App.KEY_TIMER, App.KEY_TIMER_RESULT), result)
                    Else
                        VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                        VAProxy.SetText(App.KEY_RESULT, String.Format("Timer '{0}' is not running.", timerName))
                        Return False
                    End If
                End If
            Next
        End If

        Return True
    End Function
End Class
