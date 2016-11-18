Public Class ContextHandlerSpellText
   Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean

        If VAProxy.GetText(App.KEY_SPELL) Is Nothing Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Text value '{0}' not set", App.KEY_SPELL))
            Return False
        Else
            Dim currentText As String = VAProxy.GetText(App.KEY_SPELL)
            Dim nextText As String

            If currentText.Length = 0 Then
                VAProxy.SetText(App.KEY_RESULT, String.Empty)
                VAProxy.SetSmallInt(App.KEY_SPELLASCII, 0)
            Else
                nextText = currentText.Substring(0, 1)
                VAProxy.SetText(App.KEY_RESULT, nextText)
                VAProxy.SetText(App.KEY_SPELL, currentText.Substring(1, currentText.Length - 1))
                VAProxy.SetSmallInt(App.KEY_SPELLASCII, Text.Encoding.ASCII.GetBytes(nextText)(0))
            End If
      End If

      Return True
   End Function
End Class
