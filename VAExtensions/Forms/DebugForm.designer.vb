
Partial Class DebugForm
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
      Me.txtMain = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      '
      'txtMain
      '
      Me.txtMain.AcceptsReturn = True
      Me.txtMain.AcceptsTab = True
      Me.txtMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtMain.Location = New System.Drawing.Point(0, 0)
      Me.txtMain.Multiline = True
      Me.txtMain.Name = "txtMain"
      Me.txtMain.ReadOnly = True
      Me.txtMain.Size = New System.Drawing.Size(405, 362)
      Me.txtMain.TabIndex = 1
      '
      'DebugForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(404, 361)
      Me.Controls.Add(Me.txtMain)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
      Me.MinimumSize = New System.Drawing.Size(330, 120)
      Me.Name = "DebugForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Debug"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents txtMain As System.Windows.Forms.TextBox
End Class
