Public MustInherit Class ContextHandlerBase
    Public Const ERR_CONTEXT As Int16 = 1
    Public Const ERR_IO As Int16 = 2
    Public Const ERR_ARGUMENTS As Int16 = 3

    Protected Context As ContextFactory.Contexts
    Protected VAProxy As Object

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        Me.Context = context
        Me.VAProxy = vaProxy
    End Sub

    Public MustOverride Function Execute() As Boolean
End Class
