Imports System.Windows.Forms

Partial Public Class InfoForm
   Public Sub New()
      ' The Me.InitializeComponent call is required for Windows Forms designer support.
      Me.InitializeComponent()

      '
      ' TODO : Add constructor code after InitializeComponents
      '
   End Sub

   Sub Form1Load(sender As Object, e As EventArgs) Handles MyBase.Load

      If IO.File.Exists(App.HelpFile) Then
         rtfHelp.LoadFile(App.HelpFile)
      Else
         rtfHelp.AppendText(String.Format("* Can't find file ""{0}"" *", App.HelpFile))
      End If
      If App.Settings.CacheTimeout > 0 Then
         chkCache.Checked = True
         udDays.Value = App.Settings.CacheTimeout \ 1440
         udHours.Value = (App.Settings.CacheTimeout - Convert.ToInt32(udDays.Value * 1440)) \ 60
         udMinutes.Value = App.Settings.CacheTimeout - Convert.ToInt32(udDays.Value * 1440) - (udHours.Value * 60)
      End If
      If App.Settings.ResponseLimit > 0 Then
         chkResponseLimit.Checked = True
         udResponseLimit.Value = App.Settings.ResponseLimit
      End If
   End Sub

   Sub InfoFormFormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
      App.Settings.CacheTimeout = Convert.ToInt32(udMinutes.Value + (udHours.Value * 60) + (udDays.Value * 1440))
      App.Settings.ResponseLimit = Convert.ToInt32(udResponseLimit.Value)
      Settings.Serialize(App.Settings)
   End Sub

   Private Sub chkCache_CheckedChanged(sender As Object, e As EventArgs) Handles chkCache.CheckedChanged
      udDays.Enabled = chkCache.Checked
      udHours.Enabled = chkCache.Checked
      udMinutes.Enabled = chkCache.Checked

      If Not chkCache.Checked Then
         udDays.Value = 0
         udHours.Value = 0
         udMinutes.Value = 0
      End If
   End Sub

   Private Sub rtfHelp_SizeChanged(sender As Object, e As EventArgs) Handles rtfHelp.SizeChanged
      rtfHelp.RightMargin = rtfHelp.Size.Width - 40
   End Sub

   Private Sub chkResponseLimit_CheckedChanged(sender As Object, e As EventArgs) Handles chkResponseLimit.CheckedChanged
      udResponseLimit.Enabled = chkResponseLimit.Checked
      If Not chkResponseLimit.Checked Then
         udResponseLimit.Value = 0
      End If
   End Sub
End Class
