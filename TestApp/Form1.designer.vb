
Partial Class Form1
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
      Me.components = New System.ComponentModel.Container()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.btnLaunchVA = New System.Windows.Forms.Button()
      Me.btnShowInfo = New System.Windows.Forms.Button()
      Me.BindingSourceMathCond = New System.Windows.Forms.BindingSource(Me.components)
      Me.pageCountDown = New System.Windows.Forms.TabPage()
      Me.lblCountdownOUT = New System.Windows.Forms.Label()
      Me.txtCountdownOUT = New System.Windows.Forms.TextBox()
      Me.txtCountdownName = New System.Windows.Forms.TextBox()
      Me.lblCountdownSec = New System.Windows.Forms.Label()
      Me.lblCountdownName = New System.Windows.Forms.Label()
      Me.udCountdown = New System.Windows.Forms.NumericUpDown()
      Me.btnCountdownNext = New System.Windows.Forms.Button()
      Me.btnCountdownInit = New System.Windows.Forms.Button()
      Me.pageRandom = New System.Windows.Forms.TabPage()
      Me.lblRandomMax = New System.Windows.Forms.Label()
      Me.udRandomMax = New System.Windows.Forms.NumericUpDown()
      Me.lblRandomMin = New System.Windows.Forms.Label()
      Me.udRandomMin = New System.Windows.Forms.NumericUpDown()
      Me.btnRandomNext = New System.Windows.Forms.Button()
      Me.lblRandomOUT = New System.Windows.Forms.Label()
      Me.txtRandomOUT = New System.Windows.Forms.TextBox()
      Me.btnRandomInit = New System.Windows.Forms.Button()
      Me.pageMath = New System.Windows.Forms.TabPage()
      Me.btnMathXor = New System.Windows.Forms.Button()
      Me.dgvMath = New System.Windows.Forms.DataGridView()
      Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.btnMathOr = New System.Windows.Forms.Button()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.btnMathAnd = New System.Windows.Forms.Button()
      Me.btnMathAdd = New System.Windows.Forms.Button()
      Me.btnMathMax = New System.Windows.Forms.Button()
      Me.btnMathSub = New System.Windows.Forms.Button()
      Me.btnMathMin = New System.Windows.Forms.Button()
      Me.btnMathMult = New System.Windows.Forms.Button()
      Me.btnMathMod = New System.Windows.Forms.Button()
      Me.btnMathDiv = New System.Windows.Forms.Button()
      Me.pageReadStdOut = New System.Windows.Forms.TabPage()
      Me.lblReadStdOutResult = New System.Windows.Forms.Label()
      Me.txtReadStdOutResult = New System.Windows.Forms.TextBox()
      Me.txtReadStdOutArgs = New System.Windows.Forms.TextBox()
      Me.txtReadStdOutName = New System.Windows.Forms.TextBox()
      Me.lblReadStdOutName = New System.Windows.Forms.Label()
      Me.btnReadStdOutExecute = New System.Windows.Forms.Button()
      Me.lblReadStdOutArgs = New System.Windows.Forms.Label()
      Me.pageSpellText = New System.Windows.Forms.TabPage()
      Me.lblSpellTextOUT = New System.Windows.Forms.Label()
      Me.lblSpellTextIN = New System.Windows.Forms.Label()
      Me.txtSpellTextOUT = New System.Windows.Forms.TextBox()
      Me.txtSpellTextIN = New System.Windows.Forms.TextBox()
      Me.btnSpellTextExecute = New System.Windows.Forms.Button()
      Me.pageShowText = New System.Windows.Forms.TabPage()
      Me.lblShowFileOR = New System.Windows.Forms.Label()
      Me.txtShowFileTextVar = New System.Windows.Forms.TextBox()
      Me.lblShowFileName = New System.Windows.Forms.Label()
      Me.lblShowFileTextVar = New System.Windows.Forms.Label()
      Me.cboShowFileName = New System.Windows.Forms.ComboBox()
      Me.btnShowFileName = New System.Windows.Forms.Button()
      Me.pageCompareText = New System.Windows.Forms.TabPage()
      Me.txtCompareText2 = New System.Windows.Forms.TextBox()
      Me.txtCompareText1 = New System.Windows.Forms.TextBox()
      Me.lblCompareText1 = New System.Windows.Forms.Label()
      Me.lblCompareText2 = New System.Windows.Forms.Label()
      Me.btnCompareText = New System.Windows.Forms.Button()
      Me.pageReadRSS = New System.Windows.Forms.TabPage()
      Me.txtReadRSSRegEx = New System.Windows.Forms.TextBox()
      Me.lblReadRSSRegEx = New System.Windows.Forms.Label()
      Me.cboReadRSSName = New System.Windows.Forms.ComboBox()
      Me.cboReadRSSDateMask = New System.Windows.Forms.ComboBox()
      Me.lblReadRSSIndex = New System.Windows.Forms.Label()
      Me.cboReadRSSArgs = New System.Windows.Forms.ComboBox()
      Me.udReadRSSIndex = New System.Windows.Forms.NumericUpDown()
      Me.lblReadRSSArgs = New System.Windows.Forms.Label()
      Me.lblReadRSSDateMask = New System.Windows.Forms.Label()
      Me.lblReadRSSName = New System.Windows.Forms.Label()
      Me.btnReadRSSExecute = New System.Windows.Forms.Button()
      Me.pageReadXML = New System.Windows.Forms.TabPage()
      Me.txtReadXMLItemPath = New System.Windows.Forms.TextBox()
      Me.txtReadXMLRegEx = New System.Windows.Forms.TextBox()
      Me.cboReadXMLName = New System.Windows.Forms.ComboBox()
      Me.lblReadXMLItemPath = New System.Windows.Forms.Label()
      Me.lblReadXMLIndex = New System.Windows.Forms.Label()
      Me.lblReadXMLName = New System.Windows.Forms.Label()
      Me.udReadXMLIndex = New System.Windows.Forms.NumericUpDown()
      Me.lblReadXMLRegEx = New System.Windows.Forms.Label()
      Me.btnReadXMLExecute = New System.Windows.Forms.Button()
      Me.pageReadFile = New System.Windows.Forms.TabPage()
      Me.lblReadFileName = New System.Windows.Forms.Label()
      Me.txtReadFileRegEx = New System.Windows.Forms.TextBox()
      Me.cboReadFileName = New System.Windows.Forms.ComboBox()
      Me.lblReadFileRegEx = New System.Windows.Forms.Label()
      Me.btnReadFileExecute = New System.Windows.Forms.Button()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      CType(Me.BindingSourceMathCond, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pageCountDown.SuspendLayout()
      CType(Me.udCountdown, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pageRandom.SuspendLayout()
      CType(Me.udRandomMax, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.udRandomMin, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pageMath.SuspendLayout()
      CType(Me.dgvMath, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pageReadStdOut.SuspendLayout()
      Me.pageSpellText.SuspendLayout()
      Me.pageShowText.SuspendLayout()
      Me.pageCompareText.SuspendLayout()
      Me.pageReadRSS.SuspendLayout()
      CType(Me.udReadRSSIndex, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pageReadXML.SuspendLayout()
      CType(Me.udReadXMLIndex, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pageReadFile.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnLaunchVA
      '
      Me.btnLaunchVA.Location = New System.Drawing.Point(168, 12)
      Me.btnLaunchVA.Name = "btnLaunchVA"
      Me.btnLaunchVA.Size = New System.Drawing.Size(147, 23)
      Me.btnLaunchVA.TabIndex = 0
      Me.btnLaunchVA.Text = "Launch VoiceAttack"
      Me.btnLaunchVA.UseVisualStyleBackColor = True
      '
      'btnShowInfo
      '
      Me.btnShowInfo.Location = New System.Drawing.Point(12, 12)
      Me.btnShowInfo.Name = "btnShowInfo"
      Me.btnShowInfo.Size = New System.Drawing.Size(147, 23)
      Me.btnShowInfo.TabIndex = 4
      Me.btnShowInfo.Text = "Show Plugin Info"
      Me.btnShowInfo.UseVisualStyleBackColor = True
      '
      'pageCountDown
      '
      Me.pageCountDown.Controls.Add(Me.lblCountdownOUT)
      Me.pageCountDown.Controls.Add(Me.txtCountdownOUT)
      Me.pageCountDown.Controls.Add(Me.txtCountdownName)
      Me.pageCountDown.Controls.Add(Me.lblCountdownSec)
      Me.pageCountDown.Controls.Add(Me.lblCountdownName)
      Me.pageCountDown.Controls.Add(Me.udCountdown)
      Me.pageCountDown.Controls.Add(Me.btnCountdownNext)
      Me.pageCountDown.Controls.Add(Me.btnCountdownInit)
      Me.pageCountDown.Location = New System.Drawing.Point(4, 40)
      Me.pageCountDown.Name = "pageCountDown"
      Me.pageCountDown.Padding = New System.Windows.Forms.Padding(3)
      Me.pageCountDown.Size = New System.Drawing.Size(773, 342)
      Me.pageCountDown.TabIndex = 11
      Me.pageCountDown.Text = "CountDown"
      Me.pageCountDown.UseVisualStyleBackColor = True
      '
      'lblCountdownOUT
      '
      Me.lblCountdownOUT.AutoSize = True
      Me.lblCountdownOUT.Location = New System.Drawing.Point(6, 37)
      Me.lblCountdownOUT.Name = "lblCountdownOUT"
      Me.lblCountdownOUT.Size = New System.Drawing.Size(39, 13)
      Me.lblCountdownOUT.TabIndex = 37
      Me.lblCountdownOUT.Text = "Output"
      '
      'txtCountdownOUT
      '
      Me.txtCountdownOUT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCountdownOUT.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCountdownOUT.Location = New System.Drawing.Point(66, 37)
      Me.txtCountdownOUT.Multiline = True
      Me.txtCountdownOUT.Name = "txtCountdownOUT"
      Me.txtCountdownOUT.ReadOnly = True
      Me.txtCountdownOUT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtCountdownOUT.Size = New System.Drawing.Size(206, 296)
      Me.txtCountdownOUT.TabIndex = 36
      '
      'txtCountdownName
      '
      Me.txtCountdownName.Location = New System.Drawing.Point(66, 6)
      Me.txtCountdownName.Name = "txtCountdownName"
      Me.txtCountdownName.Size = New System.Drawing.Size(91, 20)
      Me.txtCountdownName.TabIndex = 35
      Me.txtCountdownName.Text = "Timer1"
      '
      'lblCountdownSec
      '
      Me.lblCountdownSec.Location = New System.Drawing.Point(233, 8)
      Me.lblCountdownSec.Name = "lblCountdownSec"
      Me.lblCountdownSec.Size = New System.Drawing.Size(52, 18)
      Me.lblCountdownSec.TabIndex = 34
      Me.lblCountdownSec.Text = "seconds"
      '
      'lblCountdownName
      '
      Me.lblCountdownName.Location = New System.Drawing.Point(6, 8)
      Me.lblCountdownName.Name = "lblCountdownName"
      Me.lblCountdownName.Size = New System.Drawing.Size(67, 18)
      Me.lblCountdownName.TabIndex = 32
      Me.lblCountdownName.Text = "Name"
      '
      'udCountdown
      '
      Me.udCountdown.Location = New System.Drawing.Point(163, 6)
      Me.udCountdown.Maximum = New Decimal(New Integer() {32000, 0, 0, 0})
      Me.udCountdown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.udCountdown.Name = "udCountdown"
      Me.udCountdown.Size = New System.Drawing.Size(66, 20)
      Me.udCountdown.TabIndex = 33
      Me.udCountdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.udCountdown.Value = New Decimal(New Integer() {60, 0, 0, 0})
      '
      'btnCountdownNext
      '
      Me.btnCountdownNext.Location = New System.Drawing.Point(291, 35)
      Me.btnCountdownNext.Name = "btnCountdownNext"
      Me.btnCountdownNext.Size = New System.Drawing.Size(125, 23)
      Me.btnCountdownNext.TabIndex = 31
      Me.btnCountdownNext.Text = "Get Next Number"
      Me.btnCountdownNext.UseVisualStyleBackColor = True
      '
      'btnCountdownInit
      '
      Me.btnCountdownInit.Location = New System.Drawing.Point(291, 6)
      Me.btnCountdownInit.Name = "btnCountdownInit"
      Me.btnCountdownInit.Size = New System.Drawing.Size(125, 23)
      Me.btnCountdownInit.TabIndex = 30
      Me.btnCountdownInit.Text = "Initialize"
      Me.btnCountdownInit.UseVisualStyleBackColor = True
      '
      'pageRandom
      '
      Me.pageRandom.Controls.Add(Me.lblRandomMax)
      Me.pageRandom.Controls.Add(Me.udRandomMax)
      Me.pageRandom.Controls.Add(Me.lblRandomMin)
      Me.pageRandom.Controls.Add(Me.udRandomMin)
      Me.pageRandom.Controls.Add(Me.btnRandomNext)
      Me.pageRandom.Controls.Add(Me.lblRandomOUT)
      Me.pageRandom.Controls.Add(Me.txtRandomOUT)
      Me.pageRandom.Controls.Add(Me.btnRandomInit)
      Me.pageRandom.Location = New System.Drawing.Point(4, 40)
      Me.pageRandom.Name = "pageRandom"
      Me.pageRandom.Padding = New System.Windows.Forms.Padding(3)
      Me.pageRandom.Size = New System.Drawing.Size(773, 342)
      Me.pageRandom.TabIndex = 10
      Me.pageRandom.Text = "Random list"
      Me.pageRandom.UseVisualStyleBackColor = True
      '
      'lblRandomMax
      '
      Me.lblRandomMax.Location = New System.Drawing.Point(149, 12)
      Me.lblRandomMax.Name = "lblRandomMax"
      Me.lblRandomMax.Size = New System.Drawing.Size(29, 18)
      Me.lblRandomMax.TabIndex = 29
      Me.lblRandomMax.Text = "Max"
      '
      'udRandomMax
      '
      Me.udRandomMax.Location = New System.Drawing.Point(184, 10)
      Me.udRandomMax.Maximum = New Decimal(New Integer() {32000, 0, 0, 0})
      Me.udRandomMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.udRandomMax.Name = "udRandomMax"
      Me.udRandomMax.Size = New System.Drawing.Size(66, 20)
      Me.udRandomMax.TabIndex = 28
      Me.udRandomMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.udRandomMax.Value = New Decimal(New Integer() {20, 0, 0, 0})
      '
      'lblRandomMin
      '
      Me.lblRandomMin.Location = New System.Drawing.Point(5, 10)
      Me.lblRandomMin.Name = "lblRandomMin"
      Me.lblRandomMin.Size = New System.Drawing.Size(74, 18)
      Me.lblRandomMin.TabIndex = 26
      Me.lblRandomMin.Text = "Min"
      '
      'udRandomMin
      '
      Me.udRandomMin.Location = New System.Drawing.Point(79, 10)
      Me.udRandomMin.Maximum = New Decimal(New Integer() {32000, 0, 0, 0})
      Me.udRandomMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.udRandomMin.Name = "udRandomMin"
      Me.udRandomMin.Size = New System.Drawing.Size(66, 20)
      Me.udRandomMin.TabIndex = 27
      Me.udRandomMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.udRandomMin.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'btnRandomNext
      '
      Me.btnRandomNext.Location = New System.Drawing.Point(291, 39)
      Me.btnRandomNext.Name = "btnRandomNext"
      Me.btnRandomNext.Size = New System.Drawing.Size(125, 23)
      Me.btnRandomNext.TabIndex = 25
      Me.btnRandomNext.Text = "Get Next Number"
      Me.btnRandomNext.UseVisualStyleBackColor = True
      '
      'lblRandomOUT
      '
      Me.lblRandomOUT.AutoSize = True
      Me.lblRandomOUT.Location = New System.Drawing.Point(6, 39)
      Me.lblRandomOUT.Name = "lblRandomOUT"
      Me.lblRandomOUT.Size = New System.Drawing.Size(39, 13)
      Me.lblRandomOUT.TabIndex = 24
      Me.lblRandomOUT.Text = "Output"
      '
      'txtRandomOUT
      '
      Me.txtRandomOUT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtRandomOUT.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRandomOUT.Location = New System.Drawing.Point(79, 39)
      Me.txtRandomOUT.Multiline = True
      Me.txtRandomOUT.Name = "txtRandomOUT"
      Me.txtRandomOUT.ReadOnly = True
      Me.txtRandomOUT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtRandomOUT.Size = New System.Drawing.Size(206, 314)
      Me.txtRandomOUT.TabIndex = 21
      '
      'btnRandomInit
      '
      Me.btnRandomInit.Location = New System.Drawing.Point(291, 10)
      Me.btnRandomInit.Name = "btnRandomInit"
      Me.btnRandomInit.Size = New System.Drawing.Size(125, 23)
      Me.btnRandomInit.TabIndex = 20
      Me.btnRandomInit.Text = "Initialize"
      Me.btnRandomInit.UseVisualStyleBackColor = True
      '
      'pageMath
      '
      Me.pageMath.Controls.Add(Me.btnMathXor)
      Me.pageMath.Controls.Add(Me.dgvMath)
      Me.pageMath.Controls.Add(Me.btnMathOr)
      Me.pageMath.Controls.Add(Me.Label2)
      Me.pageMath.Controls.Add(Me.btnMathAnd)
      Me.pageMath.Controls.Add(Me.btnMathAdd)
      Me.pageMath.Controls.Add(Me.btnMathMax)
      Me.pageMath.Controls.Add(Me.btnMathSub)
      Me.pageMath.Controls.Add(Me.btnMathMin)
      Me.pageMath.Controls.Add(Me.btnMathMult)
      Me.pageMath.Controls.Add(Me.btnMathMod)
      Me.pageMath.Controls.Add(Me.btnMathDiv)
      Me.pageMath.Location = New System.Drawing.Point(4, 22)
      Me.pageMath.Name = "pageMath"
      Me.pageMath.Size = New System.Drawing.Size(773, 360)
      Me.pageMath.TabIndex = 7
      Me.pageMath.Text = "Math functions"
      Me.pageMath.UseVisualStyleBackColor = True
      '
      'btnMathXor
      '
      Me.btnMathXor.Location = New System.Drawing.Point(398, 82)
      Me.btnMathXor.Name = "btnMathXor"
      Me.btnMathXor.Size = New System.Drawing.Size(39, 23)
      Me.btnMathXor.TabIndex = 43
      Me.btnMathXor.Text = "Xor"
      Me.btnMathXor.UseVisualStyleBackColor = True
      '
      'dgvMath
      '
      Me.dgvMath.AllowUserToResizeRows = False
      Me.dgvMath.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvMath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvMath.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
      Me.dgvMath.Location = New System.Drawing.Point(3, 24)
      Me.dgvMath.Name = "dgvMath"
      Me.dgvMath.RowHeadersWidth = 20
      Me.dgvMath.Size = New System.Drawing.Size(303, 226)
      Me.dgvMath.TabIndex = 30
      '
      'DataGridViewTextBoxColumn3
      '
      Me.DataGridViewTextBoxColumn3.HeaderText = "Key"
      Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
      Me.DataGridViewTextBoxColumn3.Width = 80
      '
      'DataGridViewTextBoxColumn4
      '
      DataGridViewCellStyle3.Format = "0"
      DataGridViewCellStyle3.NullValue = Nothing
      Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
      Me.DataGridViewTextBoxColumn4.HeaderText = "Value"
      Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
      '
      'btnMathOr
      '
      Me.btnMathOr.Location = New System.Drawing.Point(355, 82)
      Me.btnMathOr.Name = "btnMathOr"
      Me.btnMathOr.Size = New System.Drawing.Size(39, 23)
      Me.btnMathOr.TabIndex = 42
      Me.btnMathOr.Text = "Or"
      Me.btnMathOr.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(6, 8)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(158, 13)
      Me.Label2.TabIndex = 29
      Me.Label2.Text = "Numeric conditions (int16 value)"
      '
      'btnMathAnd
      '
      Me.btnMathAnd.Location = New System.Drawing.Point(312, 82)
      Me.btnMathAnd.Name = "btnMathAnd"
      Me.btnMathAnd.Size = New System.Drawing.Size(39, 23)
      Me.btnMathAnd.TabIndex = 41
      Me.btnMathAnd.Text = "And"
      Me.btnMathAnd.UseVisualStyleBackColor = True
      '
      'btnMathAdd
      '
      Me.btnMathAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnMathAdd.Location = New System.Drawing.Point(312, 24)
      Me.btnMathAdd.Name = "btnMathAdd"
      Me.btnMathAdd.Size = New System.Drawing.Size(25, 23)
      Me.btnMathAdd.TabIndex = 31
      Me.btnMathAdd.Text = "+"
      Me.btnMathAdd.UseVisualStyleBackColor = True
      '
      'btnMathMax
      '
      Me.btnMathMax.Location = New System.Drawing.Point(398, 53)
      Me.btnMathMax.Name = "btnMathMax"
      Me.btnMathMax.Size = New System.Drawing.Size(39, 23)
      Me.btnMathMax.TabIndex = 40
      Me.btnMathMax.Text = "Max"
      Me.btnMathMax.UseVisualStyleBackColor = True
      '
      'btnMathSub
      '
      Me.btnMathSub.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnMathSub.Location = New System.Drawing.Point(343, 24)
      Me.btnMathSub.Name = "btnMathSub"
      Me.btnMathSub.Size = New System.Drawing.Size(25, 23)
      Me.btnMathSub.TabIndex = 32
      Me.btnMathSub.Text = "-"
      Me.btnMathSub.UseVisualStyleBackColor = True
      '
      'btnMathMin
      '
      Me.btnMathMin.Location = New System.Drawing.Point(355, 53)
      Me.btnMathMin.Name = "btnMathMin"
      Me.btnMathMin.Size = New System.Drawing.Size(39, 23)
      Me.btnMathMin.TabIndex = 39
      Me.btnMathMin.Text = "Min"
      Me.btnMathMin.UseVisualStyleBackColor = True
      '
      'btnMathMult
      '
      Me.btnMathMult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnMathMult.Location = New System.Drawing.Point(381, 24)
      Me.btnMathMult.Name = "btnMathMult"
      Me.btnMathMult.Size = New System.Drawing.Size(25, 23)
      Me.btnMathMult.TabIndex = 33
      Me.btnMathMult.Text = "*"
      Me.btnMathMult.UseVisualStyleBackColor = True
      '
      'btnMathMod
      '
      Me.btnMathMod.Location = New System.Drawing.Point(312, 53)
      Me.btnMathMod.Name = "btnMathMod"
      Me.btnMathMod.Size = New System.Drawing.Size(39, 23)
      Me.btnMathMod.TabIndex = 38
      Me.btnMathMod.Text = "Mod"
      Me.btnMathMod.UseVisualStyleBackColor = True
      '
      'btnMathDiv
      '
      Me.btnMathDiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnMathDiv.Location = New System.Drawing.Point(412, 24)
      Me.btnMathDiv.Name = "btnMathDiv"
      Me.btnMathDiv.Size = New System.Drawing.Size(25, 23)
      Me.btnMathDiv.TabIndex = 34
      Me.btnMathDiv.Text = "/"
      Me.btnMathDiv.UseVisualStyleBackColor = True
      '
      'pageReadStdOut
      '
      Me.pageReadStdOut.Controls.Add(Me.lblReadStdOutResult)
      Me.pageReadStdOut.Controls.Add(Me.txtReadStdOutResult)
      Me.pageReadStdOut.Controls.Add(Me.txtReadStdOutArgs)
      Me.pageReadStdOut.Controls.Add(Me.txtReadStdOutName)
      Me.pageReadStdOut.Controls.Add(Me.lblReadStdOutName)
      Me.pageReadStdOut.Controls.Add(Me.btnReadStdOutExecute)
      Me.pageReadStdOut.Controls.Add(Me.lblReadStdOutArgs)
      Me.pageReadStdOut.Location = New System.Drawing.Point(4, 40)
      Me.pageReadStdOut.Name = "pageReadStdOut"
      Me.pageReadStdOut.Size = New System.Drawing.Size(773, 342)
      Me.pageReadStdOut.TabIndex = 6
      Me.pageReadStdOut.Text = "Read standard output"
      Me.pageReadStdOut.UseVisualStyleBackColor = True
      '
      'lblReadStdOutResult
      '
      Me.lblReadStdOutResult.AutoSize = True
      Me.lblReadStdOutResult.Location = New System.Drawing.Point(10, 64)
      Me.lblReadStdOutResult.Name = "lblReadStdOutResult"
      Me.lblReadStdOutResult.Size = New System.Drawing.Size(39, 13)
      Me.lblReadStdOutResult.TabIndex = 16
      Me.lblReadStdOutResult.Text = "Output"
      '
      'txtReadStdOutResult
      '
      Me.txtReadStdOutResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtReadStdOutResult.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtReadStdOutResult.Location = New System.Drawing.Point(105, 68)
      Me.txtReadStdOutResult.Multiline = True
      Me.txtReadStdOutResult.Name = "txtReadStdOutResult"
      Me.txtReadStdOutResult.ReadOnly = True
      Me.txtReadStdOutResult.Size = New System.Drawing.Size(206, 285)
      Me.txtReadStdOutResult.TabIndex = 12
      '
      'txtReadStdOutArgs
      '
      Me.txtReadStdOutArgs.Location = New System.Drawing.Point(105, 34)
      Me.txtReadStdOutArgs.Name = "txtReadStdOutArgs"
      Me.txtReadStdOutArgs.Size = New System.Drawing.Size(206, 20)
      Me.txtReadStdOutArgs.TabIndex = 15
      '
      'txtReadStdOutName
      '
      Me.txtReadStdOutName.Location = New System.Drawing.Point(105, 7)
      Me.txtReadStdOutName.Name = "txtReadStdOutName"
      Me.txtReadStdOutName.Size = New System.Drawing.Size(206, 20)
      Me.txtReadStdOutName.TabIndex = 14
      Me.txtReadStdOutName.Text = "TestData\TestConsole.exe"
      '
      'lblReadStdOutName
      '
      Me.lblReadStdOutName.AutoSize = True
      Me.lblReadStdOutName.Location = New System.Drawing.Point(8, 10)
      Me.lblReadStdOutName.Name = "lblReadStdOutName"
      Me.lblReadStdOutName.Size = New System.Drawing.Size(80, 13)
      Me.lblReadStdOutName.TabIndex = 11
      Me.lblReadStdOutName.Text = "Process to start"
      '
      'btnReadStdOutExecute
      '
      Me.btnReadStdOutExecute.Location = New System.Drawing.Point(317, 32)
      Me.btnReadStdOutExecute.Name = "btnReadStdOutExecute"
      Me.btnReadStdOutExecute.Size = New System.Drawing.Size(125, 23)
      Me.btnReadStdOutExecute.TabIndex = 1
      Me.btnReadStdOutExecute.Text = "Execute"
      Me.btnReadStdOutExecute.UseVisualStyleBackColor = True
      '
      'lblReadStdOutArgs
      '
      Me.lblReadStdOutArgs.AutoSize = True
      Me.lblReadStdOutArgs.Location = New System.Drawing.Point(8, 34)
      Me.lblReadStdOutArgs.Name = "lblReadStdOutArgs"
      Me.lblReadStdOutArgs.Size = New System.Drawing.Size(57, 13)
      Me.lblReadStdOutArgs.TabIndex = 9
      Me.lblReadStdOutArgs.Text = "Arguments"
      '
      'pageSpellText
      '
      Me.pageSpellText.Controls.Add(Me.lblSpellTextOUT)
      Me.pageSpellText.Controls.Add(Me.lblSpellTextIN)
      Me.pageSpellText.Controls.Add(Me.txtSpellTextOUT)
      Me.pageSpellText.Controls.Add(Me.txtSpellTextIN)
      Me.pageSpellText.Controls.Add(Me.btnSpellTextExecute)
      Me.pageSpellText.Location = New System.Drawing.Point(4, 40)
      Me.pageSpellText.Name = "pageSpellText"
      Me.pageSpellText.Size = New System.Drawing.Size(773, 342)
      Me.pageSpellText.TabIndex = 4
      Me.pageSpellText.Text = "Spell Text"
      Me.pageSpellText.UseVisualStyleBackColor = True
      '
      'lblSpellTextOUT
      '
      Me.lblSpellTextOUT.AutoSize = True
      Me.lblSpellTextOUT.Location = New System.Drawing.Point(3, 36)
      Me.lblSpellTextOUT.Name = "lblSpellTextOUT"
      Me.lblSpellTextOUT.Size = New System.Drawing.Size(39, 13)
      Me.lblSpellTextOUT.TabIndex = 19
      Me.lblSpellTextOUT.Text = "Output"
      '
      'lblSpellTextIN
      '
      Me.lblSpellTextIN.AutoSize = True
      Me.lblSpellTextIN.Location = New System.Drawing.Point(3, 13)
      Me.lblSpellTextIN.Name = "lblSpellTextIN"
      Me.lblSpellTextIN.Size = New System.Drawing.Size(64, 13)
      Me.lblSpellTextIN.TabIndex = 18
      Me.lblSpellTextIN.Text = "Text to spell"
      '
      'txtSpellTextOUT
      '
      Me.txtSpellTextOUT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSpellTextOUT.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSpellTextOUT.Location = New System.Drawing.Point(77, 36)
      Me.txtSpellTextOUT.Multiline = True
      Me.txtSpellTextOUT.Name = "txtSpellTextOUT"
      Me.txtSpellTextOUT.ReadOnly = True
      Me.txtSpellTextOUT.Size = New System.Drawing.Size(206, 317)
      Me.txtSpellTextOUT.TabIndex = 16
      '
      'txtSpellTextIN
      '
      Me.txtSpellTextIN.Location = New System.Drawing.Point(77, 10)
      Me.txtSpellTextIN.Name = "txtSpellTextIN"
      Me.txtSpellTextIN.Size = New System.Drawing.Size(206, 20)
      Me.txtSpellTextIN.TabIndex = 17
      Me.txtSpellTextIN.Text = "The cat is on the table, 1 ball is under."
      '
      'btnSpellTextExecute
      '
      Me.btnSpellTextExecute.Location = New System.Drawing.Point(289, 10)
      Me.btnSpellTextExecute.Name = "btnSpellTextExecute"
      Me.btnSpellTextExecute.Size = New System.Drawing.Size(125, 23)
      Me.btnSpellTextExecute.TabIndex = 15
      Me.btnSpellTextExecute.Text = "Execute"
      Me.btnSpellTextExecute.UseVisualStyleBackColor = True
      '
      'pageShowText
      '
      Me.pageShowText.Controls.Add(Me.lblShowFileOR)
      Me.pageShowText.Controls.Add(Me.txtShowFileTextVar)
      Me.pageShowText.Controls.Add(Me.lblShowFileName)
      Me.pageShowText.Controls.Add(Me.lblShowFileTextVar)
      Me.pageShowText.Controls.Add(Me.cboShowFileName)
      Me.pageShowText.Controls.Add(Me.btnShowFileName)
      Me.pageShowText.Location = New System.Drawing.Point(4, 40)
      Me.pageShowText.Name = "pageShowText"
      Me.pageShowText.Size = New System.Drawing.Size(773, 342)
      Me.pageShowText.TabIndex = 5
      Me.pageShowText.Text = "Show file/text"
      Me.pageShowText.UseVisualStyleBackColor = True
      '
      'lblShowFileOR
      '
      Me.lblShowFileOR.AutoSize = True
      Me.lblShowFileOR.Location = New System.Drawing.Point(29, 30)
      Me.lblShowFileOR.Name = "lblShowFileOR"
      Me.lblShowFileOR.Size = New System.Drawing.Size(16, 13)
      Me.lblShowFileOR.TabIndex = 12
      Me.lblShowFileOR.Text = "or"
      '
      'txtShowFileTextVar
      '
      Me.txtShowFileTextVar.Location = New System.Drawing.Point(106, 51)
      Me.txtShowFileTextVar.Multiline = True
      Me.txtShowFileTextVar.Name = "txtShowFileTextVar"
      Me.txtShowFileTextVar.Size = New System.Drawing.Size(331, 66)
      Me.txtShowFileTextVar.TabIndex = 8
      Me.txtShowFileTextVar.Text = "This is a simple text variable to show in a window"
      '
      'lblShowFileName
      '
      Me.lblShowFileName.AutoSize = True
      Me.lblShowFileName.Location = New System.Drawing.Point(9, 10)
      Me.lblShowFileName.Name = "lblShowFileName"
      Me.lblShowFileName.Size = New System.Drawing.Size(74, 13)
      Me.lblShowFileName.TabIndex = 11
      Me.lblShowFileName.Text = "File path/URL"
      '
      'lblShowFileTextVar
      '
      Me.lblShowFileTextVar.AutoSize = True
      Me.lblShowFileTextVar.Location = New System.Drawing.Point(9, 51)
      Me.lblShowFileTextVar.Name = "lblShowFileTextVar"
      Me.lblShowFileTextVar.Size = New System.Drawing.Size(68, 13)
      Me.lblShowFileTextVar.TabIndex = 9
      Me.lblShowFileTextVar.Text = "Text variable"
      '
      'cboShowFileName
      '
      Me.cboShowFileName.FormattingEnabled = True
      Me.cboShowFileName.Items.AddRange(New Object() {"https://docs.google.com/uc?export=download&id=0B1i7jJTId0GVVzRyZ0N5OEQ5eGM", "TestData\Test.txt"})
      Me.cboShowFileName.Location = New System.Drawing.Point(106, 7)
      Me.cboShowFileName.Name = "cboShowFileName"
      Me.cboShowFileName.Size = New System.Drawing.Size(331, 21)
      Me.cboShowFileName.TabIndex = 10
      '
      'btnShowFileName
      '
      Me.btnShowFileName.Location = New System.Drawing.Point(312, 123)
      Me.btnShowFileName.Name = "btnShowFileName"
      Me.btnShowFileName.Size = New System.Drawing.Size(125, 23)
      Me.btnShowFileName.TabIndex = 1
      Me.btnShowFileName.Text = "Execute"
      Me.btnShowFileName.UseVisualStyleBackColor = True
      '
      'pageCompareText
      '
      Me.pageCompareText.Controls.Add(Me.txtCompareText2)
      Me.pageCompareText.Controls.Add(Me.txtCompareText1)
      Me.pageCompareText.Controls.Add(Me.lblCompareText1)
      Me.pageCompareText.Controls.Add(Me.lblCompareText2)
      Me.pageCompareText.Controls.Add(Me.btnCompareText)
      Me.pageCompareText.Location = New System.Drawing.Point(4, 40)
      Me.pageCompareText.Name = "pageCompareText"
      Me.pageCompareText.Size = New System.Drawing.Size(773, 342)
      Me.pageCompareText.TabIndex = 3
      Me.pageCompareText.Text = "Compare Text"
      Me.pageCompareText.UseVisualStyleBackColor = True
      '
      'txtCompareText2
      '
      Me.txtCompareText2.Location = New System.Drawing.Point(110, 38)
      Me.txtCompareText2.Name = "txtCompareText2"
      Me.txtCompareText2.Size = New System.Drawing.Size(177, 20)
      Me.txtCompareText2.TabIndex = 12
      '
      'txtCompareText1
      '
      Me.txtCompareText1.Location = New System.Drawing.Point(110, 14)
      Me.txtCompareText1.Name = "txtCompareText1"
      Me.txtCompareText1.Size = New System.Drawing.Size(177, 20)
      Me.txtCompareText1.TabIndex = 8
      '
      'lblCompareText1
      '
      Me.lblCompareText1.AutoSize = True
      Me.lblCompareText1.Location = New System.Drawing.Point(13, 17)
      Me.lblCompareText1.Name = "lblCompareText1"
      Me.lblCompareText1.Size = New System.Drawing.Size(55, 13)
      Me.lblCompareText1.TabIndex = 11
      Me.lblCompareText1.Text = "First value"
      '
      'lblCompareText2
      '
      Me.lblCompareText2.AutoSize = True
      Me.lblCompareText2.Location = New System.Drawing.Point(13, 41)
      Me.lblCompareText2.Name = "lblCompareText2"
      Me.lblCompareText2.Size = New System.Drawing.Size(73, 13)
      Me.lblCompareText2.TabIndex = 9
      Me.lblCompareText2.Text = "Second value"
      '
      'btnCompareText
      '
      Me.btnCompareText.Location = New System.Drawing.Point(316, 35)
      Me.btnCompareText.Name = "btnCompareText"
      Me.btnCompareText.Size = New System.Drawing.Size(125, 23)
      Me.btnCompareText.TabIndex = 1
      Me.btnCompareText.Text = "Execute"
      Me.btnCompareText.UseVisualStyleBackColor = True
      '
      'pageReadRSS
      '
      Me.pageReadRSS.Controls.Add(Me.txtReadRSSRegEx)
      Me.pageReadRSS.Controls.Add(Me.lblReadRSSRegEx)
      Me.pageReadRSS.Controls.Add(Me.cboReadRSSName)
      Me.pageReadRSS.Controls.Add(Me.cboReadRSSDateMask)
      Me.pageReadRSS.Controls.Add(Me.lblReadRSSIndex)
      Me.pageReadRSS.Controls.Add(Me.cboReadRSSArgs)
      Me.pageReadRSS.Controls.Add(Me.udReadRSSIndex)
      Me.pageReadRSS.Controls.Add(Me.lblReadRSSArgs)
      Me.pageReadRSS.Controls.Add(Me.lblReadRSSDateMask)
      Me.pageReadRSS.Controls.Add(Me.lblReadRSSName)
      Me.pageReadRSS.Controls.Add(Me.btnReadRSSExecute)
      Me.pageReadRSS.Location = New System.Drawing.Point(4, 40)
      Me.pageReadRSS.Name = "pageReadRSS"
      Me.pageReadRSS.Size = New System.Drawing.Size(773, 342)
      Me.pageReadRSS.TabIndex = 2
      Me.pageReadRSS.Text = "Read RSS"
      Me.pageReadRSS.UseVisualStyleBackColor = True
      '
      'txtReadRSSRegEx
      '
      Me.txtReadRSSRegEx.Location = New System.Drawing.Point(103, 116)
      Me.txtReadRSSRegEx.Name = "txtReadRSSRegEx"
      Me.txtReadRSSRegEx.Size = New System.Drawing.Size(177, 20)
      Me.txtReadRSSRegEx.TabIndex = 16
      '
      'lblReadRSSRegEx
      '
      Me.lblReadRSSRegEx.AutoSize = True
      Me.lblReadRSSRegEx.Location = New System.Drawing.Point(7, 119)
      Me.lblReadRSSRegEx.Name = "lblReadRSSRegEx"
      Me.lblReadRSSRegEx.Size = New System.Drawing.Size(61, 13)
      Me.lblReadRSSRegEx.TabIndex = 17
      Me.lblReadRSSRegEx.Text = "Use RegEx"
      '
      'cboReadRSSName
      '
      Me.cboReadRSSName.FormattingEnabled = True
      Me.cboReadRSSName.Items.AddRange(New Object() {"http://feeds.bbci.co.uk/news/rss.xml", "http://rss.nytimes.com/services/xml/rss/nyt/HomePage.xml", "http://www.elitedangerous.com/news/galnet/rss"})
      Me.cboReadRSSName.Location = New System.Drawing.Point(103, 13)
      Me.cboReadRSSName.Name = "cboReadRSSName"
      Me.cboReadRSSName.Size = New System.Drawing.Size(331, 21)
      Me.cboReadRSSName.TabIndex = 10
      '
      'cboReadRSSDateMask
      '
      Me.cboReadRSSDateMask.FormattingEnabled = True
      Me.cboReadRSSDateMask.Items.AddRange(New Object() {"<default>", "ddd, dd MMM yyyy HH:mm:ss UTC"})
      Me.cboReadRSSDateMask.Location = New System.Drawing.Point(103, 89)
      Me.cboReadRSSDateMask.Name = "cboReadRSSDateMask"
      Me.cboReadRSSDateMask.Size = New System.Drawing.Size(177, 21)
      Me.cboReadRSSDateMask.TabIndex = 15
      '
      'lblReadRSSIndex
      '
      Me.lblReadRSSIndex.Location = New System.Drawing.Point(7, 66)
      Me.lblReadRSSIndex.Name = "lblReadRSSIndex"
      Me.lblReadRSSIndex.Size = New System.Drawing.Size(74, 18)
      Me.lblReadRSSIndex.TabIndex = 6
      Me.lblReadRSSIndex.Text = "Item index"
      '
      'cboReadRSSArgs
      '
      Me.cboReadRSSArgs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboReadRSSArgs.FormattingEnabled = True
      Me.cboReadRSSArgs.Items.AddRange(New Object() {"title", "summary", "title&summary"})
      Me.cboReadRSSArgs.Location = New System.Drawing.Point(103, 40)
      Me.cboReadRSSArgs.Name = "cboReadRSSArgs"
      Me.cboReadRSSArgs.Size = New System.Drawing.Size(177, 21)
      Me.cboReadRSSArgs.TabIndex = 14
      '
      'udReadRSSIndex
      '
      Me.udReadRSSIndex.Location = New System.Drawing.Point(103, 66)
      Me.udReadRSSIndex.Name = "udReadRSSIndex"
      Me.udReadRSSIndex.Size = New System.Drawing.Size(66, 20)
      Me.udReadRSSIndex.TabIndex = 7
      Me.udReadRSSIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblReadRSSArgs
      '
      Me.lblReadRSSArgs.AutoSize = True
      Me.lblReadRSSArgs.Location = New System.Drawing.Point(7, 40)
      Me.lblReadRSSArgs.Name = "lblReadRSSArgs"
      Me.lblReadRSSArgs.Size = New System.Drawing.Size(61, 13)
      Me.lblReadRSSArgs.TabIndex = 13
      Me.lblReadRSSArgs.Text = "Info to read"
      '
      'lblReadRSSDateMask
      '
      Me.lblReadRSSDateMask.AutoSize = True
      Me.lblReadRSSDateMask.Location = New System.Drawing.Point(7, 92)
      Me.lblReadRSSDateMask.Name = "lblReadRSSDateMask"
      Me.lblReadRSSDateMask.Size = New System.Drawing.Size(88, 13)
      Me.lblReadRSSDateMask.TabIndex = 9
      Me.lblReadRSSDateMask.Text = "DateTime Format"
      '
      'lblReadRSSName
      '
      Me.lblReadRSSName.AutoSize = True
      Me.lblReadRSSName.Location = New System.Drawing.Point(7, 16)
      Me.lblReadRSSName.Name = "lblReadRSSName"
      Me.lblReadRSSName.Size = New System.Drawing.Size(54, 13)
      Me.lblReadRSSName.TabIndex = 11
      Me.lblReadRSSName.Text = "RSS URL"
      '
      'btnReadRSSExecute
      '
      Me.btnReadRSSExecute.Location = New System.Drawing.Point(309, 113)
      Me.btnReadRSSExecute.Name = "btnReadRSSExecute"
      Me.btnReadRSSExecute.Size = New System.Drawing.Size(125, 23)
      Me.btnReadRSSExecute.TabIndex = 1
      Me.btnReadRSSExecute.Text = "Execute"
      Me.btnReadRSSExecute.UseVisualStyleBackColor = True
      '
      'pageReadXML
      '
      Me.pageReadXML.Controls.Add(Me.txtReadXMLItemPath)
      Me.pageReadXML.Controls.Add(Me.txtReadXMLRegEx)
      Me.pageReadXML.Controls.Add(Me.cboReadXMLName)
      Me.pageReadXML.Controls.Add(Me.lblReadXMLItemPath)
      Me.pageReadXML.Controls.Add(Me.lblReadXMLIndex)
      Me.pageReadXML.Controls.Add(Me.lblReadXMLName)
      Me.pageReadXML.Controls.Add(Me.udReadXMLIndex)
      Me.pageReadXML.Controls.Add(Me.lblReadXMLRegEx)
      Me.pageReadXML.Controls.Add(Me.btnReadXMLExecute)
      Me.pageReadXML.Location = New System.Drawing.Point(4, 40)
      Me.pageReadXML.Name = "pageReadXML"
      Me.pageReadXML.Padding = New System.Windows.Forms.Padding(3)
      Me.pageReadXML.Size = New System.Drawing.Size(773, 342)
      Me.pageReadXML.TabIndex = 1
      Me.pageReadXML.Text = "Read XML"
      Me.pageReadXML.UseVisualStyleBackColor = True
      '
      'txtReadXMLItemPath
      '
      Me.txtReadXMLItemPath.Location = New System.Drawing.Point(96, 33)
      Me.txtReadXMLItemPath.Name = "txtReadXMLItemPath"
      Me.txtReadXMLItemPath.Size = New System.Drawing.Size(177, 20)
      Me.txtReadXMLItemPath.TabIndex = 12
      Me.txtReadXMLItemPath.Text = "breakfast_menu\food\description"
      '
      'txtReadXMLRegEx
      '
      Me.txtReadXMLRegEx.Location = New System.Drawing.Point(96, 82)
      Me.txtReadXMLRegEx.Name = "txtReadXMLRegEx"
      Me.txtReadXMLRegEx.Size = New System.Drawing.Size(177, 20)
      Me.txtReadXMLRegEx.TabIndex = 8
      '
      'cboReadXMLName
      '
      Me.cboReadXMLName.FormattingEnabled = True
      Me.cboReadXMLName.Items.AddRange(New Object() {"TestData\TestXML.xml"})
      Me.cboReadXMLName.Location = New System.Drawing.Point(96, 6)
      Me.cboReadXMLName.Name = "cboReadXMLName"
      Me.cboReadXMLName.Size = New System.Drawing.Size(331, 21)
      Me.cboReadXMLName.TabIndex = 10
      '
      'lblReadXMLItemPath
      '
      Me.lblReadXMLItemPath.AutoSize = True
      Me.lblReadXMLItemPath.Location = New System.Drawing.Point(0, 33)
      Me.lblReadXMLItemPath.Name = "lblReadXMLItemPath"
      Me.lblReadXMLItemPath.Size = New System.Drawing.Size(57, 13)
      Me.lblReadXMLItemPath.TabIndex = 13
      Me.lblReadXMLItemPath.Text = "Node path"
      '
      'lblReadXMLIndex
      '
      Me.lblReadXMLIndex.Location = New System.Drawing.Point(0, 59)
      Me.lblReadXMLIndex.Name = "lblReadXMLIndex"
      Me.lblReadXMLIndex.Size = New System.Drawing.Size(74, 18)
      Me.lblReadXMLIndex.TabIndex = 6
      Me.lblReadXMLIndex.Text = "Item index"
      '
      'lblReadXMLName
      '
      Me.lblReadXMLName.AutoSize = True
      Me.lblReadXMLName.Location = New System.Drawing.Point(0, 9)
      Me.lblReadXMLName.Name = "lblReadXMLName"
      Me.lblReadXMLName.Size = New System.Drawing.Size(74, 13)
      Me.lblReadXMLName.TabIndex = 11
      Me.lblReadXMLName.Text = "File path/URL"
      '
      'udReadXMLIndex
      '
      Me.udReadXMLIndex.Location = New System.Drawing.Point(96, 59)
      Me.udReadXMLIndex.Name = "udReadXMLIndex"
      Me.udReadXMLIndex.Size = New System.Drawing.Size(66, 20)
      Me.udReadXMLIndex.TabIndex = 7
      Me.udReadXMLIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblReadXMLRegEx
      '
      Me.lblReadXMLRegEx.AutoSize = True
      Me.lblReadXMLRegEx.Location = New System.Drawing.Point(0, 85)
      Me.lblReadXMLRegEx.Name = "lblReadXMLRegEx"
      Me.lblReadXMLRegEx.Size = New System.Drawing.Size(61, 13)
      Me.lblReadXMLRegEx.TabIndex = 9
      Me.lblReadXMLRegEx.Text = "Use RegEx"
      '
      'btnReadXMLExecute
      '
      Me.btnReadXMLExecute.Location = New System.Drawing.Point(302, 79)
      Me.btnReadXMLExecute.Name = "btnReadXMLExecute"
      Me.btnReadXMLExecute.Size = New System.Drawing.Size(125, 23)
      Me.btnReadXMLExecute.TabIndex = 1
      Me.btnReadXMLExecute.Text = "Execute"
      Me.btnReadXMLExecute.UseVisualStyleBackColor = True
      '
      'pageReadFile
      '
      Me.pageReadFile.Controls.Add(Me.lblReadFileName)
      Me.pageReadFile.Controls.Add(Me.txtReadFileRegEx)
      Me.pageReadFile.Controls.Add(Me.cboReadFileName)
      Me.pageReadFile.Controls.Add(Me.lblReadFileRegEx)
      Me.pageReadFile.Controls.Add(Me.btnReadFileExecute)
      Me.pageReadFile.Location = New System.Drawing.Point(4, 22)
      Me.pageReadFile.Name = "pageReadFile"
      Me.pageReadFile.Padding = New System.Windows.Forms.Padding(3)
      Me.pageReadFile.Size = New System.Drawing.Size(773, 360)
      Me.pageReadFile.TabIndex = 0
      Me.pageReadFile.Text = "Read file"
      Me.pageReadFile.UseVisualStyleBackColor = True
      '
      'lblReadFileName
      '
      Me.lblReadFileName.AutoSize = True
      Me.lblReadFileName.Location = New System.Drawing.Point(-1, 9)
      Me.lblReadFileName.Name = "lblReadFileName"
      Me.lblReadFileName.Size = New System.Drawing.Size(74, 13)
      Me.lblReadFileName.TabIndex = 11
      Me.lblReadFileName.Text = "File path/URL"
      '
      'txtReadFileRegEx
      '
      Me.txtReadFileRegEx.Location = New System.Drawing.Point(96, 33)
      Me.txtReadFileRegEx.Name = "txtReadFileRegEx"
      Me.txtReadFileRegEx.Size = New System.Drawing.Size(177, 20)
      Me.txtReadFileRegEx.TabIndex = 8
      '
      'cboReadFileName
      '
      Me.cboReadFileName.FormattingEnabled = True
      Me.cboReadFileName.Items.AddRange(New Object() {"https://docs.google.com/uc?export=download&id=0B1i7jJTId0GVVzRyZ0N5OEQ5eGM", "TestData\Test.txt"})
      Me.cboReadFileName.Location = New System.Drawing.Point(96, 6)
      Me.cboReadFileName.Name = "cboReadFileName"
      Me.cboReadFileName.Size = New System.Drawing.Size(331, 21)
      Me.cboReadFileName.TabIndex = 10
      '
      'lblReadFileRegEx
      '
      Me.lblReadFileRegEx.AutoSize = True
      Me.lblReadFileRegEx.Location = New System.Drawing.Point(-1, 33)
      Me.lblReadFileRegEx.Name = "lblReadFileRegEx"
      Me.lblReadFileRegEx.Size = New System.Drawing.Size(61, 13)
      Me.lblReadFileRegEx.TabIndex = 9
      Me.lblReadFileRegEx.Text = "Use RegEx"
      '
      'btnReadFileExecute
      '
      Me.btnReadFileExecute.Location = New System.Drawing.Point(302, 30)
      Me.btnReadFileExecute.Name = "btnReadFileExecute"
      Me.btnReadFileExecute.Size = New System.Drawing.Size(125, 23)
      Me.btnReadFileExecute.TabIndex = 1
      Me.btnReadFileExecute.Text = "Execute"
      Me.btnReadFileExecute.UseVisualStyleBackColor = True
      '
      'TabControl1
      '
      Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TabControl1.Controls.Add(Me.pageReadFile)
      Me.TabControl1.Controls.Add(Me.pageReadXML)
      Me.TabControl1.Controls.Add(Me.pageReadRSS)
      Me.TabControl1.Controls.Add(Me.pageCompareText)
      Me.TabControl1.Controls.Add(Me.pageShowText)
      Me.TabControl1.Controls.Add(Me.pageSpellText)
      Me.TabControl1.Controls.Add(Me.pageReadStdOut)
      Me.TabControl1.Controls.Add(Me.pageMath)
      Me.TabControl1.Controls.Add(Me.pageRandom)
      Me.TabControl1.Controls.Add(Me.pageCountDown)
      Me.TabControl1.Location = New System.Drawing.Point(12, 41)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(781, 386)
      Me.TabControl1.TabIndex = 37
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(792, 428)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.btnShowInfo)
      Me.Controls.Add(Me.btnLaunchVA)
      Me.MinimumSize = New System.Drawing.Size(450, 400)
      Me.Name = "Form1"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Form1"
      CType(Me.BindingSourceMathCond, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pageCountDown.ResumeLayout(False)
      Me.pageCountDown.PerformLayout()
      CType(Me.udCountdown, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pageRandom.ResumeLayout(False)
      Me.pageRandom.PerformLayout()
      CType(Me.udRandomMax, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.udRandomMin, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pageMath.ResumeLayout(False)
      Me.pageMath.PerformLayout()
      CType(Me.dgvMath, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pageReadStdOut.ResumeLayout(False)
      Me.pageReadStdOut.PerformLayout()
      Me.pageSpellText.ResumeLayout(False)
      Me.pageSpellText.PerformLayout()
      Me.pageShowText.ResumeLayout(False)
      Me.pageShowText.PerformLayout()
      Me.pageCompareText.ResumeLayout(False)
      Me.pageCompareText.PerformLayout()
      Me.pageReadRSS.ResumeLayout(False)
      Me.pageReadRSS.PerformLayout()
      CType(Me.udReadRSSIndex, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pageReadXML.ResumeLayout(False)
      Me.pageReadXML.PerformLayout()
      CType(Me.udReadXMLIndex, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pageReadFile.ResumeLayout(False)
      Me.pageReadFile.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents btnShowInfo As System.Windows.Forms.Button
   Friend WithEvents btnLaunchVA As System.Windows.Forms.Button
   Friend WithEvents BindingSourceMathCond As System.Windows.Forms.BindingSource
   Friend WithEvents pageCountDown As System.Windows.Forms.TabPage
   Friend WithEvents lblCountdownOUT As System.Windows.Forms.Label
   Friend WithEvents txtCountdownOUT As System.Windows.Forms.TextBox
   Friend WithEvents txtCountdownName As System.Windows.Forms.TextBox
   Friend WithEvents lblCountdownSec As System.Windows.Forms.Label
   Friend WithEvents lblCountdownName As System.Windows.Forms.Label
   Friend WithEvents udCountdown As System.Windows.Forms.NumericUpDown
   Friend WithEvents btnCountdownNext As System.Windows.Forms.Button
   Friend WithEvents btnCountdownInit As System.Windows.Forms.Button
   Friend WithEvents pageRandom As System.Windows.Forms.TabPage
   Friend WithEvents lblRandomMax As System.Windows.Forms.Label
   Friend WithEvents udRandomMax As System.Windows.Forms.NumericUpDown
   Friend WithEvents lblRandomMin As System.Windows.Forms.Label
   Friend WithEvents udRandomMin As System.Windows.Forms.NumericUpDown
   Friend WithEvents btnRandomNext As System.Windows.Forms.Button
   Friend WithEvents lblRandomOUT As System.Windows.Forms.Label
   Friend WithEvents txtRandomOUT As System.Windows.Forms.TextBox
   Friend WithEvents btnRandomInit As System.Windows.Forms.Button
   Friend WithEvents pageMath As System.Windows.Forms.TabPage
   Friend WithEvents btnMathXor As System.Windows.Forms.Button
   Friend WithEvents dgvMath As System.Windows.Forms.DataGridView
   Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents btnMathOr As System.Windows.Forms.Button
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents btnMathAnd As System.Windows.Forms.Button
   Friend WithEvents btnMathAdd As System.Windows.Forms.Button
   Friend WithEvents btnMathMax As System.Windows.Forms.Button
   Friend WithEvents btnMathSub As System.Windows.Forms.Button
   Friend WithEvents btnMathMin As System.Windows.Forms.Button
   Friend WithEvents btnMathMult As System.Windows.Forms.Button
   Friend WithEvents btnMathMod As System.Windows.Forms.Button
   Friend WithEvents btnMathDiv As System.Windows.Forms.Button
   Friend WithEvents pageReadStdOut As System.Windows.Forms.TabPage
   Friend WithEvents lblReadStdOutResult As System.Windows.Forms.Label
   Friend WithEvents txtReadStdOutResult As System.Windows.Forms.TextBox
   Friend WithEvents txtReadStdOutArgs As System.Windows.Forms.TextBox
   Friend WithEvents txtReadStdOutName As System.Windows.Forms.TextBox
   Friend WithEvents lblReadStdOutName As System.Windows.Forms.Label
   Friend WithEvents btnReadStdOutExecute As System.Windows.Forms.Button
   Friend WithEvents lblReadStdOutArgs As System.Windows.Forms.Label
   Friend WithEvents pageSpellText As System.Windows.Forms.TabPage
   Friend WithEvents lblSpellTextOUT As System.Windows.Forms.Label
   Friend WithEvents lblSpellTextIN As System.Windows.Forms.Label
   Friend WithEvents txtSpellTextOUT As System.Windows.Forms.TextBox
   Friend WithEvents txtSpellTextIN As System.Windows.Forms.TextBox
   Friend WithEvents btnSpellTextExecute As System.Windows.Forms.Button
   Friend WithEvents pageShowText As System.Windows.Forms.TabPage
   Friend WithEvents lblShowFileOR As System.Windows.Forms.Label
   Friend WithEvents txtShowFileTextVar As System.Windows.Forms.TextBox
   Friend WithEvents lblShowFileName As System.Windows.Forms.Label
   Friend WithEvents lblShowFileTextVar As System.Windows.Forms.Label
   Friend WithEvents cboShowFileName As System.Windows.Forms.ComboBox
   Friend WithEvents btnShowFileName As System.Windows.Forms.Button
   Friend WithEvents pageCompareText As System.Windows.Forms.TabPage
   Friend WithEvents txtCompareText2 As System.Windows.Forms.TextBox
   Friend WithEvents txtCompareText1 As System.Windows.Forms.TextBox
   Friend WithEvents lblCompareText1 As System.Windows.Forms.Label
   Friend WithEvents lblCompareText2 As System.Windows.Forms.Label
   Friend WithEvents btnCompareText As System.Windows.Forms.Button
   Friend WithEvents pageReadRSS As System.Windows.Forms.TabPage
   Friend WithEvents txtReadRSSRegEx As System.Windows.Forms.TextBox
   Friend WithEvents lblReadRSSRegEx As System.Windows.Forms.Label
   Friend WithEvents cboReadRSSName As System.Windows.Forms.ComboBox
   Friend WithEvents cboReadRSSDateMask As System.Windows.Forms.ComboBox
   Friend WithEvents lblReadRSSIndex As System.Windows.Forms.Label
   Friend WithEvents cboReadRSSArgs As System.Windows.Forms.ComboBox
   Friend WithEvents udReadRSSIndex As System.Windows.Forms.NumericUpDown
   Friend WithEvents lblReadRSSArgs As System.Windows.Forms.Label
   Friend WithEvents lblReadRSSDateMask As System.Windows.Forms.Label
   Friend WithEvents lblReadRSSName As System.Windows.Forms.Label
   Friend WithEvents btnReadRSSExecute As System.Windows.Forms.Button
   Friend WithEvents pageReadXML As System.Windows.Forms.TabPage
   Friend WithEvents txtReadXMLItemPath As System.Windows.Forms.TextBox
   Friend WithEvents txtReadXMLRegEx As System.Windows.Forms.TextBox
   Friend WithEvents cboReadXMLName As System.Windows.Forms.ComboBox
   Friend WithEvents lblReadXMLItemPath As System.Windows.Forms.Label
   Friend WithEvents lblReadXMLIndex As System.Windows.Forms.Label
   Friend WithEvents lblReadXMLName As System.Windows.Forms.Label
   Friend WithEvents udReadXMLIndex As System.Windows.Forms.NumericUpDown
   Friend WithEvents lblReadXMLRegEx As System.Windows.Forms.Label
   Friend WithEvents btnReadXMLExecute As System.Windows.Forms.Button
   Friend WithEvents pageReadFile As System.Windows.Forms.TabPage
   Friend WithEvents lblReadFileName As System.Windows.Forms.Label
   Friend WithEvents txtReadFileRegEx As System.Windows.Forms.TextBox
   Friend WithEvents cboReadFileName As System.Windows.Forms.ComboBox
   Friend WithEvents lblReadFileRegEx As System.Windows.Forms.Label
   Friend WithEvents btnReadFileExecute As System.Windows.Forms.Button
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
End Class
