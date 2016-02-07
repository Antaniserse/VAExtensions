
Partial Class TextForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
        Me.chkEditing = New System.Windows.Forms.CheckBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.chkWrap = New System.Windows.Forms.CheckBox()
        Me.rtfMain = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'chkEditing
        '
        Me.chkEditing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkEditing.Location = New System.Drawing.Point(89, 334)
        Me.chkEditing.Name = "chkEditing"
        Me.chkEditing.Size = New System.Drawing.Size(76, 20)
        Me.chkEditing.TabIndex = 3
        Me.chkEditing.Text = "Edit mode"
        Me.chkEditing.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(240, 332)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Location = New System.Drawing.Point(321, 332)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'chkWrap
        '
        Me.chkWrap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkWrap.Location = New System.Drawing.Point(7, 334)
        Me.chkWrap.Name = "chkWrap"
        Me.chkWrap.Size = New System.Drawing.Size(76, 20)
        Me.chkWrap.TabIndex = 2
        Me.chkWrap.Text = "Wrap text"
        Me.chkWrap.UseVisualStyleBackColor = True
        '
        'rtfMain
        '
        Me.rtfMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtfMain.Location = New System.Drawing.Point(7, 3)
        Me.rtfMain.Name = "rtfMain"
        Me.rtfMain.ReadOnly = True
        Me.rtfMain.Size = New System.Drawing.Size(389, 325)
        Me.rtfMain.TabIndex = 5
        Me.rtfMain.Text = ""
        '
        'TextForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 361)
        Me.Controls.Add(Me.rtfMain)
        Me.Controls.Add(Me.chkWrap)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.chkEditing)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(330, 135)
        Me.Name = "TextForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text Viewer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkWrap As System.Windows.Forms.CheckBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents chkEditing As System.Windows.Forms.CheckBox
    Friend WithEvents rtfMain As Windows.Forms.RichTextBox
End Class
