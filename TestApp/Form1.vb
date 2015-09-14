﻿Partial Public Class Form1

   Dim contextName As String
   Dim state As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
   Dim smallIntValues As Dictionary(Of String, Nullable(Of Int16)) = New Dictionary(Of String, Nullable(Of Int16))
   Dim textValues As Dictionary(Of String, String) = New Dictionary(Of String, String)
   Dim intValues As Dictionary(Of String, Nullable(Of Integer)) = New Dictionary(Of String, Nullable(Of Integer))
   Dim decimalValues As Dictionary(Of String, Nullable(Of Decimal)) = New Dictionary(Of String, Nullable(Of Decimal))
   Dim booleanValues As Dictionary(Of String, Nullable(Of Boolean)) = New Dictionary(Of String, Nullable(Of Boolean))
   Dim extendedValues As Dictionary(Of String, Object) = New Dictionary(Of String, Object)

   Dim storageTextVar As New List(Of EditableKVP(Of String))
   Dim storageCond As New List(Of EditableKVP(Of Nullable(Of Int16)))

   Dim convertTextVar As New List(Of EditableKVP(Of String))
   Dim convertCond As New List(Of EditableKVP(Of Nullable(Of Int16)))

   Dim mathCond As New List(Of EditableKVP(Of Nullable(Of Int16)))

   Class EditableKVP(Of T) 'standard KeyValuePair is not editable when used in data binding
      Property Key As String
      Property Value As T
   End Class

   Public Sub New()
      ' The Me.InitializeComponent call is required for Windows Forms designer support.
      Me.InitializeComponent()

      '
      ' TODO : Add constructor code after InitializeComponents
      '
   End Sub

   Private Sub clearAllInput()
      smallIntValues.Clear()
      textValues.Clear()
      extendedValues.Clear()
   End Sub

   Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      VAExtensions.VoiceAttack.VA_Init1(state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      Me.Text = String.Format("Test application: {0} ({1})", VAExtensions.VoiceAttack.VA_DisplayName, VAExtensions.VoiceAttack.VA_Id)

      BindingSourceMathCond.DataSource = mathCond
      rebindMathGrid()
   End Sub

   Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
      VAExtensions.VoiceAttack.VA_Exit1(state)
   End Sub

   Private Sub rebindMathGrid()
      BindingSourceMathCond.ResetBindings(False)
      dgvMath.AutoGenerateColumns = False
      dgvMath.Columns(0).DataPropertyName = "Key"
      dgvMath.Columns(1).DataPropertyName = "Value"
      dgvMath.DataSource = BindingSourceMathCond
   End Sub

   Private Sub dgvStorageCond_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs)
      If e.ColumnIndex = 1 Then
         Dim i As Int16
         Dim v As String = Convert.ToString(e.FormattedValue)
         If v.Length > 0 AndAlso Not Int16.TryParse(v, i) Then
            e.Cancel = True
         End If
      End If
   End Sub

   Private Sub NumericGrid_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) _
         Handles dgvMath.EditingControlShowing

      RemoveHandler e.Control.KeyPress, AddressOf NumericGridColumn_KeyPress
      If DirectCast(sender, DataGridView).CurrentCell.ColumnIndex = 1 Then
         Dim tb As TextBox = TryCast(e.Control, TextBox)
         If tb IsNot Nothing Then
            AddHandler tb.KeyPress, AddressOf NumericGridColumn_KeyPress
         End If
      End If
   End Sub

   Private Sub NumericGridColumn_KeyPress(sender As Object, e As KeyPressEventArgs)
      If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
         e.Handled = True
      End If
   End Sub

   Private Sub btnShowInfo_Click(sender As Object, e As EventArgs) Handles btnShowInfo.Click
      VAExtensions.VoiceAttack.VA_DisplayInfo()

      clearAllInput()
      contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.Config)

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub btnLaunchVA_Click(sender As Object, e As EventArgs) Handles btnLaunchVA.Click
      Process.Start("C:\Program Files (x86)\VoiceAttack\VoiceAttack.exe", "-listeningoff")
   End Sub

   Private Sub btnReadFileExecute_Click(sender As Object, e As EventArgs) Handles btnReadFileExecute.Click
      clearAllInput()
      contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadFile)
      textValues(VAExtensions.App.KEY_FILE) = cboReadFileName.Text
      If txtReadFileRegEx.TextLength > 0 Then textValues(VAExtensions.App.KEY_REGEX) = txtReadFileRegEx.Text

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

   End Sub

   Private Sub btnReadXMLExecute_Click(sender As Object, e As EventArgs) Handles btnReadXMLExecute.Click
      clearAllInput()
      contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadXml)
      textValues(VAExtensions.App.KEY_FILE) = cboReadXMLName.Text
      If txtReadXMLRegEx.TextLength > 0 Then textValues(VAExtensions.App.KEY_REGEX) = txtReadXMLRegEx.Text
      If txtReadXMLItemPath.TextLength > 0 Then textValues(VAExtensions.App.KEY_ARGUMENTS) = txtReadXMLItemPath.Text
      If udReadXMLIndex.Value > 0 Then smallIntValues(VAExtensions.App.KEY_XMLCOUNT) = Convert.ToInt16(udReadXMLIndex.Value)

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub btnShowFileName_Click(sender As Object, e As EventArgs) Handles btnShowFileName.Click
      clearAllInput()
      If cboShowFileName.Text.Length > 0 Then
         contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ShowFile)
         textValues(VAExtensions.App.KEY_FILE) = cboShowFileName.Text
      ElseIf txtShowFileTextVar.TextLength > 0 Then
         contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ShowText)
         textValues("CustomName1") = txtShowFileTextVar.Text
      End If

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
   End Sub

   Private Sub btnReadRSSExecute_Click(sender As Object, e As EventArgs) Handles btnReadRSSExecute.Click
      clearAllInput()
      contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadRSS)
      textValues(VAExtensions.App.KEY_FILE) = cboReadRSSName.Text
      textValues(VAExtensions.App.KEY_ARGUMENTS) = cboReadRSSArgs.Text
      If txtReadXMLRegEx.TextLength > 0 Then textValues(VAExtensions.App.KEY_REGEX) = txtReadXMLRegEx.Text
      If cboReadRSSDateMask.Text.Length > 0 AndAlso cboReadRSSDateMask.Text <> "<default>" Then textValues(VAExtensions.App.KEY_RSSFORMAT) = cboReadRSSDateMask.Text
      If udReadRSSIndex.Value > 0 Then smallIntValues(VAExtensions.App.KEY_XMLCOUNT) = Convert.ToInt16(udReadRSSIndex.Value)

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub btnReadStdOutExecute_Click(sender As Object, e As EventArgs) Handles btnReadStdOutExecute.Click
      clearAllInput()
      contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadStdOut)
      textValues(VAExtensions.App.KEY_FILE) = txtReadStdOutName.Text
      textValues(VAExtensions.App.KEY_ARGUMENTS) = txtReadStdOutArgs.Text

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         txtReadStdOutResult.Text = String.Format("Success:{0}{0}{1}", Environment.NewLine, textValues(VAExtensions.App.KEY_RESULT))
      End If

   End Sub

   Private Sub btnSpellTextExecute_Click(sender As Object, e As EventArgs) Handles btnSpellTextExecute.Click
      clearAllInput()
      txtSpellTextOUT.Clear()
      contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.SpellText)
      textValues(VAExtensions.App.KEY_SPELL) = txtSpellTextIN.Text

      Dim result As String
      Do
         VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
         If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Do
         Else
            result = textValues(VAExtensions.App.KEY_RESULT)
            txtSpellTextOUT.AppendText(String.Format("{1} ({2}){0}", Environment.NewLine, result, smallIntValues(VAExtensions.App.KEY_SPELLASCII)))
         End If

      Loop Until String.IsNullOrEmpty(result)
   End Sub

   Private Sub btnMath_Click(sender As Object, e As EventArgs) _
      Handles btnMathAdd.Click, btnMathSub.Click, btnMathMult.Click, btnMathDiv.Click _
      , btnMathMod.Click, btnMathMin.Click, btnMathMax.Click, btnMathAnd.Click, btnMathOr.Click, btnMathXor.Click

      clearAllInput()

      Dim mathContext As VAExtensions.ContextFactory.Contexts
      If sender Is btnMathAdd Then
         mathContext = VAExtensions.ContextFactory.Contexts.MathAdd
      ElseIf sender Is btnMathSub Then
         mathContext = VAExtensions.ContextFactory.Contexts.MathSubtract
      ElseIf sender Is btnMathMult Then
         mathContext = VAExtensions.ContextFactory.Contexts.MathMultiply
      ElseIf sender Is btnMathDiv Then
         mathContext = VAExtensions.ContextFactory.Contexts.MathDivide
      ElseIf sender Is btnMathMod Then
         mathContext = VAExtensions.ContextFactory.Contexts.MathMod
      ElseIf sender Is btnMathMin Then
         mathContext = VAExtensions.ContextFactory.Contexts.MathMin
      ElseIf sender Is btnMathMax Then
         mathContext = VAExtensions.ContextFactory.Contexts.MathMax
      ElseIf sender Is btnMathAnd Then
         mathContext = VAExtensions.ContextFactory.Contexts.BitAnd
      ElseIf sender Is btnMathOr Then
         mathContext = VAExtensions.ContextFactory.Contexts.BitOr
      ElseIf sender Is btnMathXor Then
         mathContext = VAExtensions.ContextFactory.Contexts.BitXOr
      End If

      contextName = VAExtensions.EnumInfoAttribute.GetTag(mathContext)
      For Each kvp As EditableKVP(Of Nullable(Of Int16)) In mathCond
         If Not String.IsNullOrEmpty(kvp.Key) AndAlso kvp.Value.HasValue Then smallIntValues.Add(kvp.Key, kvp.Value)
      Next

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         MessageBox.Show(smallIntValues(VAExtensions.App.KEY_RESULT).Value.ToString, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub btnRandomInit_Click(sender As Object, e As EventArgs) Handles btnRandomInit.Click
      clearAllInput()
      txtRandomOUT.Clear()
      contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.RandomInit)
      smallIntValues(VAExtensions.App.KEY_RANGEMIN) = CType(udRandomMin.Value, Short?)
      smallIntValues(VAExtensions.App.KEY_RANGEMAX) = CType(udRandomMax.Value, Short?)

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

   End Sub

   Private Sub btnRandomNext_Click(sender As Object, e As EventArgs) Handles btnRandomNext.Click
      clearAllInput()
      contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.RandomNext)

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         txtRandomOUT.AppendText(String.Format("{1}{0}", Environment.NewLine, smallIntValues(VAExtensions.App.KEY_RESULT)))
      End If
   End Sub

   Private Sub btnCountdownInit_Click(sender As Object, e As EventArgs) Handles btnCountdownInit.Click
      clearAllInput()
      txtCountdownOUT.clear()
      contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.Countdown)
      smallIntValues(txtCountdownName.Text) = CType(udCountdown.Value, Short?)

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

   End Sub

   Private Sub btnCountdownNext_Click(sender As Object, e As EventArgs) Handles btnCountdownNext.Click

      clearAllInput()
      contextName = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.Countdown)
      smallIntValues(txtCountdownName.Text) = CType(udCountdown.Value, Short?)

      VAExtensions.VoiceAttack.VA_Invoke1(contextName, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
      If smallIntValues(VAExtensions.App.KEY_ERROR).Value <> 0 Then
         MessageBox.Show(textValues(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         If smallIntValues(VAExtensions.App.KEY_RESULT).Value > 0 Then
            txtCountdownOUT.AppendText(String.Format("Still running: {1} seconds{0}", Environment.NewLine, smallIntValues(VAExtensions.App.KEY_RESULT)))
         Else
            txtCountdownOUT.AppendText(String.Format("Countdown complete{0}", Environment.NewLine, smallIntValues(VAExtensions.App.KEY_RESULT)))
         End If
      End If
   End Sub
End Class
