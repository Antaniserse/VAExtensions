Public Class ContextHandlerMath
   Inherits ContextHandlerBase

   Public Sub New(ByVal context As ContextFactory.Contexts, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      MyBase.New(context, state, conditions, textValues, extendedValues)
   End Sub

   Public Overrides Function Execute() As Boolean
      Dim factors As New List(Of Integer)
      Dim i, mathResult As Integer

      For Each k As String In m_Conditions.Keys
         If k <> App.KEY_ERROR AndAlso k <> App.KEY_RESULT AndAlso m_Conditions(k).HasValue Then
            factors.Add(m_Conditions(k).Value)
         End If
      Next
      If factors.Count < 2 Then
         m_Conditions(App.KEY_ERROR) = ERR_ARGUMENTS
         m_TextValues(App.KEY_RESULT) = String.Format("Not enough values in the m_Conditions list: count={0}.", factors.Count)
         Return False
      End If

      Select Case m_Context
         Case ContextFactory.Contexts.MathAdd
            mathResult = factors(0)
            For i = 1 To factors.Count - 1
               mathResult += factors(i)
            Next
            m_Conditions(App.KEY_RESULT) = Convert.ToInt16(mathResult)

         Case ContextFactory.Contexts.MathSubtract
            mathResult = factors(0)
            For i = 1 To factors.Count - 1
               mathResult -= factors(i)
            Next
            m_Conditions(App.KEY_RESULT) = Convert.ToInt16(mathResult)

         Case ContextFactory.Contexts.MathMultiply
            mathResult = factors(0)
            For i = 1 To factors.Count - 1
               mathResult *= factors(i)
            Next
            m_Conditions(App.KEY_RESULT) = Convert.ToInt16(mathResult)

         Case ContextFactory.Contexts.MathDivide
            '(Integer division)
            mathResult = factors(0)
            For i = 1 To factors.Count - 1
               If factors(i) <> 0 Then mathResult \= factors(i)
            Next
            m_Conditions(App.KEY_RESULT) = Convert.ToInt16(mathResult)

         Case ContextFactory.Contexts.MathMod
            mathResult = factors(0)
            For i = 1 To factors.Count - 1
               mathResult = mathResult Mod factors(i)
            Next
            m_Conditions(App.KEY_RESULT) = Convert.ToInt16(mathResult)

         Case ContextFactory.Contexts.MathMin
            mathResult = factors(0)
            For i = 1 To factors.Count - 1
               If factors(i) < mathResult Then mathResult = factors(i)
            Next
            m_Conditions(App.KEY_RESULT) = Convert.ToInt16(mathResult)

         Case ContextFactory.Contexts.MathMax
            mathResult = factors(0)
            For i = 1 To factors.Count - 1
               If factors(i) > mathResult Then mathResult = factors(i)
            Next
            m_Conditions(App.KEY_RESULT) = Convert.ToInt16(mathResult)

         Case ContextFactory.Contexts.BitAnd
            mathResult = factors(0) And factors(1)
            m_Conditions(App.KEY_RESULT) = Convert.ToInt16(mathResult)

         Case ContextFactory.Contexts.BitOr
            mathResult = factors(0) Or factors(1)
            m_Conditions(App.KEY_RESULT) = Convert.ToInt16(mathResult)

         Case ContextFactory.Contexts.BitXOr
            mathResult = factors(0) Xor factors(1)
            m_Conditions(App.KEY_RESULT) = Convert.ToInt16(mathResult)

      End Select

      Return True
   End Function
End Class
