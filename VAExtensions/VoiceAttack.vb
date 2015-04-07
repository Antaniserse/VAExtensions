Imports System.Linq
Imports System.XML.Linq

Public Class VoiceAttack
   Public Shared Function VA_Id() As Guid
      Return New Guid("{9571B674-0CE8-4A04-90D3-83519CB66968}")
   End Function

   Public Shared Function VA_DisplayName() As String
      Return "VA Extensions 1.0"
   End Function

   Public Shared Function VA_DisplayInfo() As String
      Return String.Empty
   End Function

   Public Shared Sub VA_Init1(ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      App.InitValues()
      App.Settings = Settings.Deserialize()
   End Sub

   Public Shared Sub VA_Exit1(ByRef state As Dictionary(Of String, Object))
      App.ClearCachedFiles()
      Settings.Serialize(App.Settings)
   End Sub

   Public Shared Sub VA_Invoke1(context As String, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
#If SHOW_DEBUG_UI Then
      DebugForm.ShowDebugInfo(context, state, conditions, textValues, extendedValues)
#End If

      Dim contextHandler As ContextHandlerBase = ContextFactory.Create(context, state, conditions, textValues, extendedValues)

      If contextHandler Is Nothing Then
         conditions(App.KEY_ERROR) = ContextHandlerBase.ERR_CONTEXT
         textValues(App.KEY_RESULT) = String.Format("Unsupported or empty context: ""{0}"".", context)
         Exit Sub
      Else
         contextHandler.Execute()
      End If

      If Not textValues.ContainsKey(App.KEY_RESULT) Then
         textValues(App.KEY_RESULT) = Nothing
      End If
      If Not conditions.ContainsKey(App.KEY_ERROR) Then
         conditions(App.KEY_ERROR) = 0
      End If

   End Sub

End Class
