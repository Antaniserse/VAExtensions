Public Class VAProxyReplica
    Public Context As String

    Public SessionState As New Dictionary(Of String, Object)

    Private smallIntValues As Dictionary(Of String, Nullable(Of Int16)) = New Dictionary(Of String, Nullable(Of Int16))
    Private textValues As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Private intValues As Dictionary(Of String, Nullable(Of Integer)) = New Dictionary(Of String, Nullable(Of Integer))
    Private decimalValues As Dictionary(Of String, Nullable(Of Decimal)) = New Dictionary(Of String, Nullable(Of Decimal))
    Private booleanValues As Dictionary(Of String, Nullable(Of Boolean)) = New Dictionary(Of String, Nullable(Of Boolean))
    Private dateTimeValues As Dictionary(Of String, Nullable(Of DateTime)) = New Dictionary(Of String, Nullable(Of DateTime))
    Private extendedValues As Dictionary(Of String, Object) = New Dictionary(Of String, Object)

#Region "Values Get/set"

    Public Function GetText(ByVal variableName As String) As String
        If textValues.ContainsKey(variableName) Then
            Return textValues(variableName)
        Else
            Return Nothing
        End If
    End Function

    Public Sub SetText(ByVal variableName As String, ByVal value As String)
        If textValues.ContainsKey(variableName) Then textValues.Remove(variableName)
        If value IsNot Nothing Then textValues.Add(variableName, value)
    End Sub

    Public Function GetSmallInt(ByVal variableName As String) As Nullable(Of Int16)
        If smallIntValues.ContainsKey(variableName) Then
            Return smallIntValues(variableName)
        Else
            Return Nothing
        End If
    End Function

    Public Sub SetSmallInt(ByVal variableName As String, ByVal value As Nullable(Of Int16))
        If smallIntValues.ContainsKey(variableName) Then smallIntValues.Remove(variableName)
        If value.HasValue Then smallIntValues.Add(variableName, value)
    End Sub

    Public Function GetInt(ByVal variableName As String) As Nullable(Of Int32)
        If intValues.ContainsKey(variableName) Then
            Return intValues(variableName)
        Else
            Return Nothing
        End If
    End Function

    Public Sub SetInt(ByVal variableName As String, ByVal value As Nullable(Of Int32))
        If intValues.ContainsKey(variableName) Then intValues.Remove(variableName)
        If value.HasValue Then intValues.Add(variableName, value)
    End Sub

    Public Function GetDecimal(ByVal variableName As String) As Nullable(Of Decimal)
        If decimalValues.ContainsKey(variableName) Then
            Return decimalValues(variableName)
        Else
            Return Nothing
        End If
    End Function

    Public Sub SetDecimal(ByVal variableName As String, ByVal value As Nullable(Of Decimal))
        If decimalValues.ContainsKey(variableName) Then decimalValues.Remove(variableName)
        If value.HasValue Then decimalValues.Add(variableName, value)
    End Sub

    Public Function GetBoolean(ByVal variableName As String) As Nullable(Of Boolean)
        If booleanValues.ContainsKey(variableName) Then
            Return booleanValues(variableName)
        Else
            Return Nothing
        End If
    End Function

    Public Sub SetBoolean(ByVal variableName As String, ByVal value As Nullable(Of Boolean))
        If booleanValues.ContainsKey(variableName) Then booleanValues.Remove(variableName)
        If value.HasValue Then booleanValues.Add(variableName, value)
    End Sub

    Public Function GetDateTime(ByVal variableName As String) As Nullable(Of DateTime)
        If dateTimeValues.ContainsKey(variableName) Then
            Return dateTimeValues(variableName)
        Else
            Return Nothing
        End If
    End Function

    Public Sub SetDateTime(ByVal variableName As String, ByVal value As Nullable(Of DateTime))
        If dateTimeValues.ContainsKey(variableName) Then dateTimeValues.Remove(variableName)
        dateTimeValues.Add(variableName, value)
    End Sub
#End Region

#Region "Misc"
    Public Function ProxyVersion() As System.Version
        Return New System.Version(4, 0, 0, 0)
    End Function

    Public Function VAVersion() As System.Version
        Return New System.Version(1, 5, 7, 3)
    End Function

    Public Function GetProfileName() As String
        Return "TestApp profile"
    End Function

    Public Function CommandExists(ByVal name As String) As Boolean
        Return True
    End Function

    Public Sub ExecuteCommand(ByVal name As String)
        Return
    End Sub

    Public Sub WriteToLog(ByVal value As String, color As String)
        Debug.WriteLine(String.Format("[VA LOG {0}({1})]", value, color))
    End Sub

    Public Function ParseTokens(ByVal name As String) As String
        Return String.Empty
    End Function
#End Region

#Region "** Not included in VA interface"
    Public Sub ClearAllInput()
        'SessionState is left untouched
        smallIntValues.Clear()
        textValues.Clear()
        intValues.Clear()
        decimalValues.Clear()
        booleanValues.Clear()
        dateTimeValues.Clear()
        extendedValues.Clear()
    End Sub
#End Region

End Class
