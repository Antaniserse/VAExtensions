'
' Created by SharpDevelop.
' User: sigla
' Date: 26/08/2014
' Time: 08.46
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class InfoForm
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
      Me.rtfHelp = New System.Windows.Forms.RichTextBox()
      Me.tabControl1 = New System.Windows.Forms.TabControl()
      Me.tabPage1 = New System.Windows.Forms.TabPage()
      Me.tabPage2 = New System.Windows.Forms.TabPage()
      Me.udResponseLimit = New System.Windows.Forms.NumericUpDown()
      Me.lblResponseLimit = New System.Windows.Forms.Label()
      Me.chkResponseLimit = New System.Windows.Forms.CheckBox()
      Me.udMinutes = New System.Windows.Forms.NumericUpDown()
      Me.udHours = New System.Windows.Forms.NumericUpDown()
      Me.udDays = New System.Windows.Forms.NumericUpDown()
      Me.label2 = New System.Windows.Forms.Label()
      Me.lblHours = New System.Windows.Forms.Label()
      Me.lblDays = New System.Windows.Forms.Label()
      Me.chkCache = New System.Windows.Forms.CheckBox()
      Me.tabControl1.SuspendLayout()
      Me.tabPage1.SuspendLayout()
      Me.tabPage2.SuspendLayout()
      CType(Me.udResponseLimit, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.udMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.udHours, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.udDays, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'rtfHelp
      '
      Me.rtfHelp.Dock = System.Windows.Forms.DockStyle.Fill
      Me.rtfHelp.Location = New System.Drawing.Point(3, 3)
      Me.rtfHelp.Name = "rtfHelp"
      Me.rtfHelp.ReadOnly = True
      Me.rtfHelp.Size = New System.Drawing.Size(570, 244)
      Me.rtfHelp.TabIndex = 0
      Me.rtfHelp.Text = ""
      '
      'tabControl1
      '
      Me.tabControl1.Controls.Add(Me.tabPage1)
      Me.tabControl1.Controls.Add(Me.tabPage2)
      Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tabControl1.Location = New System.Drawing.Point(0, 0)
      Me.tabControl1.Name = "tabControl1"
      Me.tabControl1.SelectedIndex = 0
      Me.tabControl1.Size = New System.Drawing.Size(584, 276)
      Me.tabControl1.TabIndex = 1
      '
      'tabPage1
      '
      Me.tabPage1.Controls.Add(Me.rtfHelp)
      Me.tabPage1.Location = New System.Drawing.Point(4, 22)
      Me.tabPage1.Name = "tabPage1"
      Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
      Me.tabPage1.Size = New System.Drawing.Size(576, 250)
      Me.tabPage1.TabIndex = 0
      Me.tabPage1.Text = "Documentation"
      Me.tabPage1.UseVisualStyleBackColor = True
      '
      'tabPage2
      '
      Me.tabPage2.Controls.Add(Me.udResponseLimit)
      Me.tabPage2.Controls.Add(Me.lblResponseLimit)
      Me.tabPage2.Controls.Add(Me.chkResponseLimit)
      Me.tabPage2.Controls.Add(Me.udMinutes)
      Me.tabPage2.Controls.Add(Me.udHours)
      Me.tabPage2.Controls.Add(Me.udDays)
      Me.tabPage2.Controls.Add(Me.label2)
      Me.tabPage2.Controls.Add(Me.lblHours)
      Me.tabPage2.Controls.Add(Me.lblDays)
      Me.tabPage2.Controls.Add(Me.chkCache)
      Me.tabPage2.Location = New System.Drawing.Point(4, 22)
      Me.tabPage2.Name = "tabPage2"
      Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
      Me.tabPage2.Size = New System.Drawing.Size(576, 250)
      Me.tabPage2.TabIndex = 1
      Me.tabPage2.Text = "Settings"
      Me.tabPage2.UseVisualStyleBackColor = True
      '
      'udResponseLimit
      '
      Me.udResponseLimit.Enabled = False
      Me.udResponseLimit.Location = New System.Drawing.Point(25, 91)
      Me.udResponseLimit.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
      Me.udResponseLimit.Name = "udResponseLimit"
      Me.udResponseLimit.Size = New System.Drawing.Size(71, 20)
      Me.udResponseLimit.TabIndex = 13
      '
      'lblResponseLimit
      '
      Me.lblResponseLimit.Location = New System.Drawing.Point(102, 91)
      Me.lblResponseLimit.Name = "lblResponseLimit"
      Me.lblResponseLimit.Size = New System.Drawing.Size(71, 20)
      Me.lblResponseLimit.TabIndex = 12
      Me.lblResponseLimit.Text = "characters"
      '
      'chkResponseLimit
      '
      Me.chkResponseLimit.AutoSize = True
      Me.chkResponseLimit.Location = New System.Drawing.Point(8, 68)
      Me.chkResponseLimit.Name = "chkResponseLimit"
      Me.chkResponseLimit.Size = New System.Drawing.Size(105, 17)
      Me.chkResponseLimit.TabIndex = 11
      Me.chkResponseLimit.Text = "Limit response to"
      Me.chkResponseLimit.UseVisualStyleBackColor = True
      '
      'udMinutes
      '
      Me.udMinutes.Enabled = False
      Me.udMinutes.Location = New System.Drawing.Point(179, 29)
      Me.udMinutes.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
      Me.udMinutes.Name = "udMinutes"
      Me.udMinutes.Size = New System.Drawing.Size(35, 20)
      Me.udMinutes.TabIndex = 10
      '
      'udHours
      '
      Me.udHours.Enabled = False
      Me.udHours.Location = New System.Drawing.Point(102, 29)
      Me.udHours.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
      Me.udHours.Name = "udHours"
      Me.udHours.Size = New System.Drawing.Size(35, 20)
      Me.udHours.TabIndex = 9
      '
      'udDays
      '
      Me.udDays.Enabled = False
      Me.udDays.Location = New System.Drawing.Point(25, 29)
      Me.udDays.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
      Me.udDays.Name = "udDays"
      Me.udDays.Size = New System.Drawing.Size(35, 20)
      Me.udDays.TabIndex = 8
      '
      'label2
      '
      Me.label2.Location = New System.Drawing.Point(220, 29)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(46, 20)
      Me.label2.TabIndex = 7
      Me.label2.Text = "minutes"
      '
      'lblHours
      '
      Me.lblHours.Location = New System.Drawing.Point(143, 29)
      Me.lblHours.Name = "lblHours"
      Me.lblHours.Size = New System.Drawing.Size(30, 20)
      Me.lblHours.TabIndex = 6
      Me.lblHours.Text = "hours"
      '
      'lblDays
      '
      Me.lblDays.Location = New System.Drawing.Point(66, 29)
      Me.lblDays.Name = "lblDays"
      Me.lblDays.Size = New System.Drawing.Size(30, 20)
      Me.lblDays.TabIndex = 5
      Me.lblDays.Text = "days"
      '
      'chkCache
      '
      Me.chkCache.AutoSize = True
      Me.chkCache.Location = New System.Drawing.Point(6, 6)
      Me.chkCache.Name = "chkCache"
      Me.chkCache.Size = New System.Drawing.Size(154, 17)
      Me.chkCache.TabIndex = 1
      Me.chkCache.Text = "Cache downloaded files for"
      Me.chkCache.UseVisualStyleBackColor = True
      '
      'InfoForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(584, 276)
      Me.Controls.Add(Me.tabControl1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
      Me.MinimumSize = New System.Drawing.Size(280, 180)
      Me.Name = "InfoForm"
      Me.Text = "VA Extensions"
      Me.TopMost = True
      Me.tabControl1.ResumeLayout(False)
      Me.tabPage1.ResumeLayout(False)
      Me.tabPage2.ResumeLayout(False)
      Me.tabPage2.PerformLayout()
      CType(Me.udResponseLimit, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.udMinutes, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.udHours, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.udDays, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents chkResponseLimit As System.Windows.Forms.CheckBox
   Friend WithEvents lblResponseLimit As System.Windows.Forms.Label
   Friend WithEvents udResponseLimit As System.Windows.Forms.NumericUpDown
   Friend WithEvents udHours As System.Windows.Forms.NumericUpDown
   Friend WithEvents udMinutes As System.Windows.Forms.NumericUpDown
   Friend WithEvents lblDays As System.Windows.Forms.Label
   Friend WithEvents lblHours As System.Windows.Forms.Label
   Friend WithEvents label2 As System.Windows.Forms.Label
   Friend WithEvents chkCache As System.Windows.Forms.CheckBox
   Friend WithEvents udDays As System.Windows.Forms.NumericUpDown
   Friend WithEvents tabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents tabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents tabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents rtfHelp As System.Windows.Forms.RichTextBox
End Class
