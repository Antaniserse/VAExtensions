Public Class ContextHandlerInfoDialog
   Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean
   
      Dim f As New InfoForm
      f.ShowDialog()
      f.Dispose()

      Return True
   End Function
End Class
