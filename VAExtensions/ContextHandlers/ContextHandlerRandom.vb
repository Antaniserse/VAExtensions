Public Class ContextHandlerRandom
   Inherits ContextHandlerBase

   Public Sub New(ByVal context As ContextFactory.Contexts, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      MyBase.New(context, state, conditions, textValues, extendedValues)
   End Sub

   Public Overrides Function Execute() As Boolean
      Select Case m_Context
         Case ContextFactory.Contexts.RandomInit
            If Not m_Conditions.ContainsKey(App.KEY_RANGEMIN) OrElse Not m_Conditions.ContainsKey(App.KEY_RANGEMAX) Then
               m_Conditions(App.KEY_ERROR) = ERR_ARGUMENTS
               m_TextValues(App.KEY_RESULT) = String.Format("Both min and max range values are needed (set {0} and {1} conditions).", App.KEY_RANGEMIN, App.KEY_RANGEMAX)
               Return False
            Else
               Dim numbers() As Int16, numberList As New List(Of Int16)
               For n As Int16 = m_Conditions(App.KEY_RANGEMIN).Value To m_Conditions(App.KEY_RANGEMAX).Value
                  numberList.Add(n)
               Next
               numbers = numberList.OrderBy(Function(s) Guid.NewGuid()).ToArray
               m_State.Remove(App.KEY_RANDOMLIST)
               m_State.Remove(App.KEY_CURRENTIDX)
               m_State.Add(App.KEY_RANDOMLIST, numbers)
            End If
         Case ContextFactory.Contexts.RandomNext
            If Not m_State.ContainsKey(App.KEY_RANDOMLIST) Then
               m_Conditions(App.KEY_ERROR) = ERR_ARGUMENTS
               m_TextValues(App.KEY_RESULT) = String.Format("Random list not initialized (call {0} first).", EnumInfoAttribute.GetTag(ContextFactory.Contexts.RandomInit))
               Return False
            Else
               Dim numbers() As Int16 = CType(m_State(App.KEY_RANDOMLIST), Short())
               Dim currentIndex As Int16

               If m_State.ContainsKey(App.KEY_CURRENTIDX) Then
                  currentIndex = Convert.ToInt16(m_State(App.KEY_CURRENTIDX))
                  If currentIndex > numbers.GetUpperBound(0) Then currentIndex = 0
               Else
                  currentIndex = 0
               End If
               m_Conditions(App.KEY_RESULT) = numbers(currentIndex)
               currentIndex += 1S
               m_State(App.KEY_CURRENTIDX) = currentIndex
            End If
      End Select

      Return True
   End Function
End Class
