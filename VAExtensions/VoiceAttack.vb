Imports System.Linq
Imports System.XML.Linq

Public Class VoiceAttack
   Public Shared Function VA_Id() As Guid
      Return New Guid("{9571B674-0CE8-4A04-90D3-83519CB66968}")
   End Function

   Public Shared Function VA_DisplayName() As String
        Return "VA Extensions 2.0"
    End Function

   Public Shared Function VA_DisplayInfo() As String
        Return "A general purpose plugin to extend the base functionalities of VoiceAttack"
    End Function

    Public Shared Sub VA_Init1(vaProxy As Object)

        Dim v As System.Version = vaProxy.VAVersion()
        If v.Major < 2 AndAlso v.Minor < 5 Then
            vaProxy.WriteToLog(String.Format("{0} require VA 1.6 or above (detected {1})", VA_DisplayName, v.ToString), "red")
        Else
            App.InitValues()
            App.Settings = Settings.Deserialize()
        End If

    End Sub

    Public Shared Sub VA_Exit1(vaProxy As Object)
        App.ClearCachedFiles()
        Settings.Serialize(App.Settings)
    End Sub

    Public Shared Sub VA_StopCommand()

    End Sub

    Public Shared Sub VA_Invoke1(vaProxy As Object)

#If SHOW_DEBUG_UI Then
        DebugForm.ShowDebugInfo(context, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
#End If

        Dim contextHandler As ContextHandlerBase = ContextFactory.Create(vaProxy)

        vaProxy.SetSmallInt(App.KEY_ERROR, Nothing)
        vaProxy.SetText(App.KEY_RESULT, Nothing)

        If contextHandler Is Nothing Then
            vaProxy.SetSmallInt(App.KEY_ERROR, ContextHandlerBase.ERR_CONTEXT)
            vaProxy.SetText(App.KEY_RESULT, String.Format("Unsupported or empty context: '{0}'.", vaProxy.Context))
            Exit Sub
        Else
            contextHandler.Execute()
        End If

        If vaProxy.GetText(App.KEY_RESULT) Is Nothing Then
            vaProxy.SetText(App.KEY_RESULT, String.Empty) 'Nothing
        End If
        If vaProxy.GetSmallInt(App.KEY_ERROR) Is Nothing Then
            vaProxy.SetSmallInt(App.KEY_ERROR, 0)
        End If
    End Sub

End Class
