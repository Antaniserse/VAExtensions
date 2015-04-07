Imports System.Windows.Forms

Partial Public Class TextForm
   Private currentFile As DownloadedFile
   Private currentTextVar As String

   Private originalEncoding As Text.Encoding

   Public Sub New()
      ' The Me.InitializeComponent call is required for Windows Forms designer support.
      Me.InitializeComponent()

      '
      ' TODO : Add constructor code after InitializeComponents
      '
   End Sub

   Public Sub New(ByVal file As DownloadedFile, textVar As String)
      Me.New()
      currentFile = file
      currentTextVar = textVar
   End Sub

   Sub TextFormLoad(sender As Object, e As EventArgs)
      Cursor = Cursors.WaitCursor
      Me.Visible = True

      If currentFile IsNot Nothing Then
         'A file was passed
         Using reader = New IO.StreamReader(currentFile.LocalPath)
            txtMain.Text = Convert.ToString(reader.ReadToEnd())
            originalEncoding = reader.CurrentEncoding
         End Using
      Else
         'A simple text variable from VA was passed
         txtMain.Text = currentTextVar
      End If
      Cursor = Cursors.Default

      'To ensure the CheckedChanged events are fired during Load
      chkWrap.CheckState = CheckState.Indeterminate
      chkWrap.CheckState = CheckState.Checked

      chkEditing.CheckState = CheckState.Indeterminate
      chkEditing.CheckState = CheckState.Unchecked
      If currentFile IsNot Nothing Then
         chkEditing.Enabled = Not currentFile.IsTemporary
      ElseIf currentTextVar IsNot Nothing Then
         chkEditing.Enabled = True
      End If
      chkWrap.Focus()
   End Sub

   Sub chkEditingCheckedChanged(sender As Object, e As EventArgs)
      cmdSave.Visible = chkEditing.Checked
      txtMain.ReadOnly = Not chkEditing.Checked
   End Sub

   Sub chkWrapCheckedChanged(sender As Object, e As EventArgs)
      If chkWrap.Checked Then
         txtMain.ScrollBars = ScrollBars.Vertical
         txtMain.WordWrap = True
      Else
         txtMain.ScrollBars = ScrollBars.Both
         txtMain.WordWrap = False
      End If
   End Sub

   Sub CmdCloseClick(sender As Object, e As EventArgs)
      Me.Close()
   End Sub

   Sub CmdSaveClick(sender As Object, e As EventArgs)
      Cursor = Cursors.WaitCursor
      If currentFile IsNot Nothing Then
         Try
            IO.File.WriteAllText(currentFile.LocalPath, txtMain.Text, originalEncoding)
         Catch ex As Exception
            MessageBox.Show(String.Format("Error while saving file: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      Else

      End If
      Cursor = Cursors.Default
      Me.Close()
   End Sub
End Class
