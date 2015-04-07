Imports System.Windows.Forms

Partial Public Class DebugForm
 
   Public Sub New()
      ' The Me.InitializeComponent call is required for Windows Forms designer support.
      Me.InitializeComponent()

      '
      ' TODO : Add constructor code after InitializeComponents
      '
   End Sub

   Public Shared Sub ShowDebugInfo(context As String, ByRef state As Dictionary(Of String, Object), ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String), ByRef extendedValues As Dictionary(Of String, Object))
      Dim f As New DebugForm
      Dim strB As New Text.StringBuilder

      strB.AppendFormat("context: {0}", context)
      strB.AppendLine()
      strB.AppendLine()
      strB.Append("state: ")
      strB.AppendLine()
      For Each kvp As KeyValuePair(Of String, Object) In state
         strB.AppendFormat("key: {0}, value: {1}", kvp.Key, kvp.Value.ToString)
         strB.AppendLine()
      Next
      strB.AppendLine()
      strB.Append("conditions: ")
      strB.AppendLine()
      For Each kvp As KeyValuePair(Of String, Nullable(Of Int16)) In conditions
         strB.AppendFormat("key: {0}, value: {1}", kvp.Key, kvp.Value)
         strB.AppendLine()
      Next
      strB.AppendLine()
      strB.Append("Text Values: ")
      strB.AppendLine()
      For Each kvp As KeyValuePair(Of String, String) In textValues
         strB.AppendFormat("key: {0}, value: {1}", kvp.Key, kvp.Value)
         strB.AppendLine()
      Next
      strB.Append("extendedValues: ")
      strB.AppendLine()
      For Each kvp As KeyValuePair(Of String, Object) In extendedValues
         strB.AppendFormat("key: {0}, value: {1}", kvp.Key, kvp.Value.ToString)
         strB.AppendLine()
      Next
      strB.AppendLine()
      f.txtMain.Text = strB.ToString
      f.ShowDialog()
   End Sub
End Class
