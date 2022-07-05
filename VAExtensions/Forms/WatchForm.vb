Imports Flobbster.Windows.Forms

Public Class WatchForm
    Public vaProxy As Object
    Private WithEvents watchBag As New Flobbster.Windows.Forms.PropertyBag

    Private Sub WatchForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboVarType.Items.Add(GetType(Int16).ToString)
        cboVarType.Items.Add(GetType(Int32).ToString)
        cboVarType.Items.Add(GetType(String).ToString)
        cboVarType.Items.Add(GetType(Boolean).ToString)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        watchBag.Properties.Add(New PropertySpec(txtVarName.Text, cboVarType.Text, "Watched variables", Nothing, Nothing))
        PropertyGrid1.SelectedObject = watchBag
    End Sub

    Private Sub watchBag_GetValue(sender As Object, e As PropertySpecEventArgs) Handles watchBag.GetValue
        Select Case e.Property.TypeName
            Case GetType(Int16).ToString
                e.Value = vaProxy.GetSmallInt(e.Property.Name)
            Case GetType(Int32).ToString
                e.Value = vaProxy.GetInt(e.Property.Name)
            Case GetType(String).ToString
                e.Value = vaProxy.GetText(e.Property.Name)
            Case GetType(Boolean).ToString
                e.Value = vaProxy.GetBoolean(e.Property.Name)
        End Select
    End Sub

    Private Sub watchBag_SetValue(sender As Object, e As PropertySpecEventArgs) Handles watchBag.SetValue
        Select Case e.Property.TypeName
            Case GetType(Int16).ToString

            Case GetType(Int32).ToString

            Case GetType(String).ToString

            Case GetType(Boolean).ToString

        End Select

    End Sub
End Class