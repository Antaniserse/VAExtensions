Public Class ContextHandlerRandom
    Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean
        Dim numbers() As Int32
        Select Case Context
            Case ContextFactory.Contexts.RandomInit
                If VAProxy.GetInt(App.KEY_RANGEMIN) Is Nothing OrElse VAProxy.GetInt(App.KEY_RANGEMAX) Is Nothing Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("Both min and max range values are needed (set {0} and {1} conditions).", App.KEY_RANGEMIN, App.KEY_RANGEMAX))
                    Return False
                Else
                    Dim numberList As New List(Of Int32)
                    For n As Int16 = VAProxy.GetInt(App.KEY_RANGEMIN) To VAProxy.GetInt(App.KEY_RANGEMAX)
                        numberList.Add(n)
                    Next
                    numbers = numberList.OrderBy(Function(s) Guid.NewGuid()).ToArray
                    VAProxy.SessionState.Remove(App.KEY_RANDOMLIST)
                    VAProxy.SessionState.Remove(App.KEY_CURRENTIDX)
                    VAProxy.SessionState.Add(App.KEY_RANDOMLIST, numbers)
                End If
            Case ContextFactory.Contexts.RandomShuffle
                If Not VAProxy.SessionState.ContainsKey(App.KEY_RANDOMLIST) Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("Random list not initialized (call {0} first).", EnumInfoAttribute.GetTag(ContextFactory.Contexts.RandomInit)))
                    Return False
                Else
                    numbers = CType(VAProxy.SessionState(App.KEY_RANDOMLIST), Integer())

                    numbers.OrderBy(Function(s) Guid.NewGuid())
                    VAProxy.SessionState.Remove(App.KEY_RANDOMLIST)
                    VAProxy.SessionState.Remove(App.KEY_CURRENTIDX)
                    VAProxy.SessionState.Add(App.KEY_RANDOMLIST, numbers)
                End If
            Case ContextFactory.Contexts.RandomNext
                If Not VAProxy.SessionState.ContainsKey(App.KEY_RANDOMLIST) Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("Random list not initialized (call {0} first).", EnumInfoAttribute.GetTag(ContextFactory.Contexts.RandomInit)))
                    Return False
                Else
                    numbers = CType(VAProxy.SessionState(App.KEY_RANDOMLIST), Integer())
                    Dim currentIndex As Int16

                    If VAProxy.SessionState.ContainsKey(App.KEY_CURRENTIDX) Then
                        currentIndex = Convert.ToInt16(VAProxy.SessionState(App.KEY_CURRENTIDX))
                        If currentIndex > numbers.GetUpperBound(0) Then currentIndex = 0
                    Else
                        currentIndex = 0
                    End If
                    VAProxy.SetInt(App.KEY_RESULT) = numbers(currentIndex)
                    currentIndex += 1S
                    VAProxy.SessionState(App.KEY_CURRENTIDX) = currentIndex
                End If
        End Select

        Return True
    End Function
End Class
