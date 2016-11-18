Partial Public Class Form1

    Dim proxyReplica As New VAProxyReplica

    Dim iniCond As New List(Of EditableKVP(Of String))

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
        'proxyReplica.ClearAllInput
    End Sub

    Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VAExtensions.VoiceAttack.VA_Init1(proxyReplica)
        Me.Text = String.Format("Test application: {0} ({1})", VAExtensions.VoiceAttack.VA_DisplayName, VAExtensions.VoiceAttack.VA_Id)

        BindingSourceINI.DataSource = iniCond
        rebindINIGrid()
    End Sub

    Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        VAExtensions.VoiceAttack.VA_Exit1(proxyReplica)
    End Sub

    Private Sub rebindINIGrid()
        BindingSourceINI.ResetBindings(False)
        dgvINI.AutoGenerateColumns = False
        dgvINI.Columns(0).DataPropertyName = "Key"
        dgvINI.Columns(1).DataPropertyName = "Value"
        dgvINI.DataSource = BindingSourceINI
    End Sub

    Private Sub NumericGrid_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)

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
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.Config)

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnLaunchVA_Click(sender As Object, e As EventArgs) Handles btnLaunchVA.Click
        Process.Start("C:\Program Files (x86)\VoiceAttack\VoiceAttack.exe", "-listeningoff")
    End Sub

    Private Sub btnReadFileExecute_Click(sender As Object, e As EventArgs) Handles btnReadFileExecute.Click
        clearAllInput()
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadFile)
        proxyReplica.SetText(VAExtensions.App.KEY_FILE, cboReadFileName.Text)
        If txtReadFileRegEx.TextLength > 0 Then proxyReplica.SetText(VAExtensions.App.KEY_REGEX, txtReadFileRegEx.Text)

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnReadXMLExecute_Click(sender As Object, e As EventArgs) Handles btnReadXMLExecute.Click
        clearAllInput()
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadXml)
        proxyReplica.SetText(VAExtensions.App.KEY_FILE, cboReadXMLName.Text)
        If txtReadXMLRegEx.TextLength > 0 Then proxyReplica.SetText(VAExtensions.App.KEY_REGEX, txtReadXMLRegEx.Text)
        If txtReadXMLItemPath.TextLength > 0 Then proxyReplica.SetText(VAExtensions.App.KEY_ARGUMENTS, txtReadXMLItemPath.Text)
        If udReadXMLIndex.Value > 0 Then proxyReplica.SetSmallInt(VAExtensions.App.KEY_INDEX, Convert.ToInt16(udReadXMLIndex.Value))

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnReadJSONExecute_Click(sender As Object, e As EventArgs) Handles btnReadJSONExecute.Click
        clearAllInput()
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadJSON)
        proxyReplica.SetText(VAExtensions.App.KEY_FILE, cboReadJSONName.Text)
        If txtReadJSONRegEx.TextLength > 0 Then proxyReplica.SetText(VAExtensions.App.KEY_REGEX, txtReadJSONRegEx.Text)
        If txtReadJSONItemPath.TextLength > 0 Then proxyReplica.SetText(VAExtensions.App.KEY_ARGUMENTS, txtReadJSONItemPath.Text)

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnShowFileName_Click(sender As Object, e As EventArgs) Handles btnShowFileName.Click
        clearAllInput()
        If cboShowFileName.Text.Length > 0 Then
            proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ShowFile)
            proxyReplica.SetText(VAExtensions.App.KEY_FILE, cboShowFileName.Text)
        ElseIf txtShowFileTextVar.TextLength > 0 Then
            proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ShowText)
            proxyReplica.SetText(VAExtensions.App.KEY_ARGUMENTS, txtShowFileTextVar.Text)
        End If

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnReadRSSExecute_Click(sender As Object, e As EventArgs) Handles btnReadRSSExecute.Click
        clearAllInput()
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadRSS)
        proxyReplica.SetText(VAExtensions.App.KEY_FILE, cboReadRSSName.Text)
        proxyReplica.SetText(VAExtensions.App.KEY_ARGUMENTS, cboReadRSSArgs.Text)
        If txtReadXMLRegEx.TextLength > 0 Then proxyReplica.SetText(VAExtensions.App.KEY_REGEX, txtReadXMLRegEx.Text)
        If cboReadRSSDateMask.Text.Length > 0 AndAlso cboReadRSSDateMask.Text <> "<default>" Then proxyReplica.SetText(VAExtensions.App.KEY_RSSFORMAT, cboReadRSSDateMask.Text)
        If udReadRSSIndex.Value > 0 Then proxyReplica.SetSmallInt(VAExtensions.App.KEY_INDEX, Convert.ToInt16(udReadRSSIndex.Value))

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnReadStdOutExecute_Click(sender As Object, e As EventArgs) Handles btnReadStdOutExecute.Click
        clearAllInput()
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadStdOut)
        proxyReplica.SetText(VAExtensions.App.KEY_FILE, txtReadStdOutName.Text)
        proxyReplica.SetText(VAExtensions.App.KEY_ARGUMENTS, txtReadStdOutArgs.Text)

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            txtReadStdOutResult.Text = String.Format("Success:{0}{0}{1}", Environment.NewLine, proxyReplica.GetText(VAExtensions.App.KEY_RESULT))
        End If

    End Sub

    Private Sub btnSpellTextExecute_Click(sender As Object, e As EventArgs) Handles btnSpellTextExecute.Click
        clearAllInput()
        txtSpellTextOUT.Clear()
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.SpellText)
        proxyReplica.SetText(VAExtensions.App.KEY_SPELL, txtSpellTextIN.Text)

        Dim result As String
        Do
            VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
            If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
                MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Do
            Else
                result = proxyReplica.GetText(VAExtensions.App.KEY_RESULT)
                txtSpellTextOUT.AppendText(String.Format("{1} ({2}){0}", Environment.NewLine, result, proxyReplica.GetSmallInt(VAExtensions.App.KEY_SPELLASCII)))
            End If

        Loop Until String.IsNullOrEmpty(result)
    End Sub

    Private Sub btnRandomInit_Click(sender As Object, e As EventArgs) Handles btnRandomInit.Click
        clearAllInput()
        txtRandomOUT.Clear()
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.RandomInit)
        proxyReplica.SetSmallInt(VAExtensions.App.KEY_RANGEMIN, CType(udRandomMin.Value, Short?))
        proxyReplica.SetSmallInt(VAExtensions.App.KEY_RANGEMAX, CType(udRandomMax.Value, Short?))

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnRandomNext_Click(sender As Object, e As EventArgs) Handles btnRandomNext.Click
        clearAllInput()
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.RandomNext)

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            txtRandomOUT.AppendText(String.Format("{1}{0}", Environment.NewLine, proxyReplica.GetSmallInt(VAExtensions.App.KEY_RESULT)))
        End If
    End Sub

    Private Sub btnCountdownInit_Click(sender As Object, e As EventArgs) Handles btnCountdownInit.Click
        clearAllInput()
        txtCountdownOUT.Clear()
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.TimerStart)
        proxyReplica.SetInt(cboCountdownName.Text, CType(udCountdown.Value, Integer?))

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnCountdownNext_Click(sender As Object, e As EventArgs) Handles btnCountdownNext.Click

        clearAllInput()
        Dim resultKey As String = cboCountdownName.Text.replace(VAExtensions.App.KEY_TIMER, VAExtensions.App.KEY_TIMER_RESULT)
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.TimerCheck)
        proxyReplica.SetInt(cboCountdownName.Text, CType(udCountdown.Value, Integer?))

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If proxyReplica.GetInt(resultKey).HasValue AndAlso proxyReplica.GetInt(resultKey).Value > 0 Then
                txtCountdownOUT.AppendText(String.Format("Still running: {1} seconds{0}", Environment.NewLine, proxyReplica.GetInt(resultKey)))
            Else
                txtCountdownOUT.AppendText(String.Format("Countdown complete{0}", Environment.NewLine))
            End If
        End If
    End Sub

    Private Sub btnINIReadWrite_Click(sender As Object, e As EventArgs) _
       Handles btnINIRead.Click, btnINIWrite.Click

        If sender Is btnINIRead Then
            proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadINI)
        Else
            proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.WriteINI)
        End If
        proxyReplica.SetText(VAExtensions.App.KEY_FILE, cboINIFile.Text)
        proxyReplica.SetText(VAExtensions.App.KEY_INI_SECTION, txtINISection.Text)
        For Each kvp As EditableKVP(Of String) In iniCond
            If Not String.IsNullOrEmpty(kvp.Key) Then
                proxyReplica.SetText(VAExtensions.App.KEY_INI_KEY, kvp.Key)
                If sender Is btnINIWrite Then
                    proxyReplica.SetText(VAExtensions.App.KEY_ARGUMENTS, kvp.Value)
                End If
                VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
                If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
                    MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    kvp.Value = proxyReplica.GetText(VAExtensions.App.KEY_RESULT)
                End If
            End If
        Next
        rebindINIGrid()
    End Sub

    Private Sub btnLoadCSVExecute_Click(sender As Object, e As EventArgs) Handles btnLoadCSVExecute.Click
        clearAllInput()
        proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.LoadCSV)
        proxyReplica.SetText(VAExtensions.App.KEY_FILE, cboReadCSVName.Text)

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show(String.Format("{0} rows and {1} columns", proxyReplica.GetInt(VAExtensions.App.KEY_ROWSCOUNT), proxyReplica.GetInt(VAExtensions.App.KEY_COLSCOUNT)), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnReadCSVExecute_Click(sender As Object, e As EventArgs) Handles btnReadCSVExecute.Click
        clearAllInput()
        proxyReplica.SetText(VAExtensions.App.KEY_FILE, cboReadCSVName.Text)
        Dim colIndex As Integer
        If Int32.TryParse(txtReadCSVCol.Text, colIndex) Then
            proxyReplica.SetInt(VAExtensions.App.KEY_COL, colIndex)
        Else
            proxyReplica.SetText(VAExtensions.App.KEY_COL, txtReadCSVCol.Text)
        End If

        If optReadCSVByIndex.Checked Then
            proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.ReadCSV)
            If udReadCSVRow.Value >= 0 Then proxyReplica.SetInt(VAExtensions.App.KEY_ROW, Convert.ToInt32(udReadCSVRow.Value))
        Else
            proxyReplica.Context = VAExtensions.EnumInfoAttribute.GetTag(VAExtensions.ContextFactory.Contexts.SearchCSV)
            proxyReplica.SetText(VAExtensions.App.KEY_ARGUMENTS, txtReadCSVSearch.Text)
        End If

        VAExtensions.VoiceAttack.VA_Invoke1(proxyReplica)
        If proxyReplica.GetSmallInt(VAExtensions.App.KEY_ERROR).Value <> 0 Then
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show(proxyReplica.GetText(VAExtensions.App.KEY_RESULT), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub optReadCSV_CheckedChanged(sender As Object, e As EventArgs) _
        Handles optReadCSVByIndex.CheckedChanged, optReadCSVByValue.CheckedChanged

        udReadCSVRow.Enabled = optReadCSVByIndex.Checked
        txtReadCSVSearch.Enabled = optReadCSVByValue.Checked
    End Sub

End Class
