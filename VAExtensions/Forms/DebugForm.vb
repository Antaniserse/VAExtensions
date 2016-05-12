Imports System.Windows.Forms

Partial Public Class DebugForm
 
   Public Sub New()
      ' The Me.InitializeComponent call is required for Windows Forms designer support.
      Me.InitializeComponent()

      '
      ' TODO : Add constructor code after InitializeComponents
      '
   End Sub

    Public Shared Sub ShowDebugInfo(context As String, ByRef state As Dictionary(Of String, Object) _
                                , ByRef smallIntValues As Dictionary(Of String, Nullable(Of Short)) _
                                , ByRef textValues As Dictionary(Of String, String) _
                                , ByRef intValues As Dictionary(Of String, Nullable(Of Integer)) _
                                , ByRef decimalValues As Dictionary(Of String, Nullable(Of Decimal)) _
                                , ByRef booleanValues As Dictionary(Of String, Nullable(Of Boolean)) _
                                , ByRef extendedValues As Dictionary(Of String, Object))

        Dim f As New DebugForm
        Dim strB As New Text.StringBuilder

        strB.AppendFormat("context: {0}", context)
        strB.AppendLine()
        strB.AppendLine()
        strB.AppendFormat("state ({0}): ", state.Count)
        strB.AppendLine()
        For Each kvp As KeyValuePair(Of String, Object) In state
            strB.AppendFormat("key: {0}, value: {1}", kvp.Key, kvp.Value.ToString)
            strB.AppendLine()
        Next
        strB.AppendLine()
        strB.AppendFormat("Small Int Values ({0}): ", smallIntValues.Count)
        strB.AppendLine()
        For Each kvp As KeyValuePair(Of String, Nullable(Of Int16)) In smallIntValues
            strB.AppendFormat("key: {0}, value: {1}", kvp.Key, kvp.Value)
            strB.AppendLine()
        Next
        strB.AppendLine()
        strB.AppendFormat("Text Values ({0}): ", textValues.Count)
        strB.AppendLine()
        For Each kvp As KeyValuePair(Of String, String) In textValues
            strB.AppendFormat("key: {0}, value: {1}", kvp.Key, kvp.Value)
            strB.AppendLine()
        Next
        strB.AppendLine()
        strB.AppendFormat("Int Values ({0}): ", intValues.Count)
        strB.AppendLine()
        For Each kvp As KeyValuePair(Of String, Nullable(Of Integer)) In intValues
            strB.AppendFormat("key: {0}, value: {1}", kvp.Key, kvp.Value)
            strB.AppendLine()
        Next
        strB.AppendLine()
        strB.AppendFormat("Decimal Values ({0}): ", decimalValues.Count)
        strB.AppendLine()
        For Each kvp As KeyValuePair(Of String, Nullable(Of Decimal)) In decimalValues
            strB.AppendFormat("key: {0}, value: {1}", kvp.Key, kvp.Value)
            strB.AppendLine()
        Next
        strB.AppendLine()
        strB.AppendFormat("Boolean Values ({0}): ", booleanValues.Count)
        strB.AppendLine()
        For Each kvp As KeyValuePair(Of String, Nullable(Of Boolean)) In booleanValues
            strB.AppendFormat("key: {0}, value: {1}", kvp.Key, kvp.Value)
            strB.AppendLine()
        Next
        strB.AppendLine()
        strB.AppendFormat("Extended Values ({0}): ", extendedValues.Count)
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
