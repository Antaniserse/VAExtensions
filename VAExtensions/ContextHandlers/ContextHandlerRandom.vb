Public Class ContextHandlerRandom
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
      Select Case m_Context
         Case ContextFactory.Contexts.RandomInit
            If Not m_smallIntValues.ContainsKey(App.KEY_RANGEMIN) OrElse Not m_smallIntValues.ContainsKey(App.KEY_RANGEMAX) Then
               m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
               m_TextValues(App.KEY_RESULT) = String.Format("Both min and max range values are needed (set {0} and {1} conditions).", App.KEY_RANGEMIN, App.KEY_RANGEMAX)
               Return False
            Else
               Dim numbers() As Int16, numberList As New List(Of Int16)
               For n As Int16 = m_smallIntValues(App.KEY_RANGEMIN).Value To m_smallIntValues(App.KEY_RANGEMAX).Value
                  numberList.Add(n)
               Next
               numbers = numberList.OrderBy(Function(s) Guid.NewGuid()).ToArray
               m_State.Remove(App.KEY_RANDOMLIST)
               m_State.Remove(App.KEY_CURRENTIDX)
               m_State.Add(App.KEY_RANDOMLIST, numbers)
            End If
         Case ContextFactory.Contexts.RandomNext
            If Not m_State.ContainsKey(App.KEY_RANDOMLIST) Then
               m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
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
               m_smallIntValues(App.KEY_RESULT) = numbers(currentIndex)
               currentIndex += 1S
               m_State(App.KEY_CURRENTIDX) = currentIndex
            End If
      End Select

      Return True
   End Function
End Class
