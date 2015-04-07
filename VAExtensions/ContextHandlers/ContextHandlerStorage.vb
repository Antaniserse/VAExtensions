Public Class ContextHandlerStorage
   Inherits ContextHandlerBase

   Public Sub New(ByVal context As ContextFactory.Contexts, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      MyBase.New(context, state, conditions, textValues, extendedValues)
   End Sub

   Public Overrides Function Execute() As Boolean
      Dim result As Boolean

      Select Case m_Context
         Case ContextFactory.Contexts.LoadStorage
            result = Storage.Load(m_Conditions, m_TextValues)
            If Not result Then
               m_Conditions(App.KEY_ERROR) = ERR_IO
               m_TextValues(App.KEY_RESULT) = "An error occured while loading the storage file."
               Return False
            End If
         Case ContextFactory.Contexts.SaveStorage
            If m_TextValues.Count = 0 AndAlso m_Conditions.Count = 0 Then
               m_Conditions(App.KEY_ERROR) = ERR_ARGUMENTS
               m_TextValues(App.KEY_RESULT) = "At least one text value or condition is needed."
               Return False
            Else
               result = Storage.Save(m_Conditions, m_TextValues)
               If Not result Then
                  m_Conditions(App.KEY_ERROR) = ERR_IO
                  m_TextValues(App.KEY_RESULT) = "An error occured while saving the storage file."
                  Return False
               End If
            End If
         Case ContextFactory.Contexts.ClearStorage
            result = Storage.Clear()
            If Not result Then
               m_Conditions(App.KEY_ERROR) = ERR_IO
               m_TextValues(App.KEY_RESULT) = "An error occured while clearing the storage file."
               Return False
            End If
      End Select

      Return result
   End Function
End Class
