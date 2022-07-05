<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WatchForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.txtVarName = New System.Windows.Forms.TextBox()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cboVarType = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PropertyGrid1.HelpVisible = False
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 63)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(492, 432)
        Me.PropertyGrid1.TabIndex = 0
        Me.PropertyGrid1.ToolbarVisible = False
        '
        'txtVarName
        '
        Me.txtVarName.Location = New System.Drawing.Point(12, 15)
        Me.txtVarName.Name = "txtVarName"
        Me.txtVarName.Size = New System.Drawing.Size(100, 20)
        Me.txtVarName.TabIndex = 1
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(405, 15)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 2
        Me.cmdAdd.Text = "Button1"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cboVarType
        '
        Me.cboVarType.FormattingEnabled = True
        Me.cboVarType.Location = New System.Drawing.Point(138, 17)
        Me.cboVarType.Name = "cboVarType"
        Me.cboVarType.Size = New System.Drawing.Size(261, 21)
        Me.cboVarType.TabIndex = 3
        '
        'WatchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 495)
        Me.Controls.Add(Me.cboVarType)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txtVarName)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "WatchForm"
        Me.Text = "Variable Watch"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PropertyGrid1 As Windows.Forms.PropertyGrid
    Friend WithEvents txtVarName As Windows.Forms.TextBox
    Friend WithEvents cmdAdd As Windows.Forms.Button
    Friend WithEvents cboVarType As Windows.Forms.ComboBox
End Class
