Imports System.Data

Public Class ContextHandlerReadCSV
    Inherits ContextHandlerBase

    Private Shared CSVStorage As New Dictionary(Of String, DataTable)

    Public Sub New(ByVal context As ContextFactory.Contexts _
                        , ByRef state As Dictionary(Of String, Object) _
                        , ByRef smallIntValues As Dictionary(Of String, Nullable(Of Short)) _
                        , ByRef textValues As Dictionary(Of String, String) _
                        , ByRef intValues As Dictionary(Of String, Nullable(Of Integer)) _
                        , ByRef decimalValues As Dictionary(Of String, Nullable(Of Decimal)) _
                        , ByRef booleanValues As Dictionary(Of String, Nullable(Of Boolean)) _
                        , ByRef extendedValues As Dictionary(Of String, Object))

        MyBase.New(context, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
    End Sub

    Public Overrides Function Execute() As Boolean
        Dim newFile As DownloadedFile = Nothing

        If Not m_TextValues.ContainsKey(App.KEY_FILE) Then
            m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
            m_TextValues(App.KEY_RESULT) = String.Format("Unknown file name. Text variable '{0}' not set.", App.KEY_FILE)
            Return False
        End If

        Select Case m_Context
            Case ContextFactory.Contexts.LoadCSV
                Try
                    newFile = App.DownloadTextFile(m_TextValues(App.KEY_FILE))
                    If newFile.LocalPath.Length = 0 Then
                        m_smallIntValues(App.KEY_ERROR) = ERR_IO
                        m_TextValues(App.KEY_RESULT) = String.Format("Error retrieving File '{0}'.", m_TextValues(App.KEY_FILE))
                        Return False
                    End If
                    Dim delimiter As String
                    If m_TextValues.ContainsKey(App.KEY_DELIMITER) Then
                        delimiter = m_TextValues(App.KEY_DELIMITER)
                    Else
                        delimiter = String.Empty
                    End If

                    If CSVStorage.ContainsKey(m_TextValues(App.KEY_FILE)) Then CSVStorage.Remove(m_TextValues(App.KEY_FILE))

                    Dim newTable As DataTable = getDataTableFromCSVFile(newFile.LocalPath, delimiter)
                    If newTable IsNot Nothing Then
                        CSVStorage.Add(m_TextValues(App.KEY_FILE), newTable)

                        m_intValues(App.KEY_ROWSCOUNT) = newTable.Rows.Count
                        m_intValues(App.KEY_COLSCOUNT) = newTable.Columns.Count
                    End If
                Catch ex As Exception
                    m_smallIntValues(App.KEY_ERROR) = ERR_IO
                    m_TextValues(App.KEY_RESULT) = String.Format("Error loading file content '{0}' ({1}).", m_TextValues(App.KEY_FILE), ex.Message)
                    Return False
                End Try
                If newFile.IsTemporary Then App.Settings.AddDownloadedFile(newFile)

            Case ContextFactory.Contexts.ReadCSV, ContextFactory.Contexts.SearchCSV
                Dim table As DataTable
                Dim row As Integer
                Dim dataRow As DataRow
                Dim dataCol As DataColumn

                If Not CSVStorage.ContainsKey(m_TextValues(App.KEY_FILE)) Then
                    m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                    m_TextValues(App.KEY_RESULT) = String.Format("CSV file not loaded. Use '{0}' function first.", EnumInfoAttribute.GetTag(ContextFactory.Contexts.LoadCSV))
                    Return False
                Else
                    table = CSVStorage.Item(m_TextValues(App.KEY_FILE))
                End If

                dataCol = Nothing
                If Not m_intValues.ContainsKey(App.KEY_COL) Then
                    If Not m_TextValues.ContainsKey(App.KEY_COL) Then
                        m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                        m_TextValues(App.KEY_RESULT) = String.Format("No column specified. variable '{0}' not set.", App.KEY_COL)
                        Return False
                    End If

                    For i As Integer = 0 To table.Columns.Count - 1
                        If String.Compare(table.Columns(i).ColumnName, m_TextValues(App.KEY_COL), True) = 0 Then
                            dataCol = table.Columns(i)
                            Exit For
                        End If
                    Next
                Else
                    If m_intValues(App.KEY_COL).Value <= 0 OrElse m_intValues(App.KEY_COL).Value > table.Columns.Count Then
                        m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                        m_TextValues(App.KEY_RESULT) = String.Format("Invalid column name/index. The loaded CSV contains '{0}' columns.", table.Columns.Count)
                        Return False
                    End If
                    dataCol = table.Columns(m_intValues(App.KEY_COL).Value - 1)
                End If

                If dataCol Is Nothing Then
                    m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                    m_TextValues(App.KEY_RESULT) = String.Format("Invalid column name/index. The loaded CSV contains '{0}' columns.", table.Columns.Count)
                    Return False
                End If

                If m_Context = ContextFactory.Contexts.ReadCSV Then
                    If Not m_intValues.ContainsKey(App.KEY_ROW) Then
                        m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                        m_TextValues(App.KEY_RESULT) = String.Format("No row specified. variable '{0}' not set.", App.KEY_ROW)
                        Return False
                    End If
                    row = m_intValues(App.KEY_ROW).Value - 1

                    If table.Rows.Count <= row Then
                        m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                        m_TextValues(App.KEY_RESULT) = String.Format("Invalid row. The loaded CSV contains '{0}' elements.", table.Rows.Count)
                        Return False
                    End If
                    dataRow = table.Rows.Item(row)
                    m_TextValues(App.KEY_RESULT) = App.LimitResponse(Convert.ToString(dataRow.Item(dataCol.Ordinal)))

                Else
                    If Not m_TextValues.ContainsKey(App.KEY_ARGUMENTS) Then
                        m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                        m_TextValues(App.KEY_RESULT) = String.Format("No search value specified. variable '{0}' not set.", App.KEY_ARGUMENTS)
                        Return False
                    End If

                    'We need the index here, so we can't use .Select() but we iterate instead
                    Dim foundIndex As Integer = -1
                    For i As Integer = 0 To table.Rows.Count - 1
                        If String.Compare(Convert.ToString(table.Rows(i).Item(dataCol.Ordinal)), m_TextValues(App.KEY_ARGUMENTS), True) = 0 Then
                            foundIndex = i
                            Exit For
                        End If
                    Next

                    If foundIndex >= 0 Then
                        m_intValues(App.KEY_ROW) = foundIndex + 1
                        m_TextValues(App.KEY_RESULT) = m_intValues(App.KEY_ROW).ToString
                    Else
                        m_intValues(App.KEY_ROW) = 0
                        m_TextValues(App.KEY_RESULT) = "Value not found at specified column"
                    End If
                End If
        End Select

        Return True
    End Function

    Private Function getDataTableFromCSVFile(ByVal csvFile As String, ByVal delimiter As String) As DataTable
        Dim csvData As New DataTable()

        Try
            If String.IsNullOrEmpty(delimiter) Then delimiter = ","

            Using csvReader As New FileIO.TextFieldParser(csvFile)
                csvReader.SetDelimiters(New String() {delimiter})
                csvReader.HasFieldsEnclosedInQuotes = False
                Dim colFields As String() = csvReader.ReadFields()

                For Each column As String In colFields
                    Dim datecolumn As New DataColumn(column)
                    datecolumn.AllowDBNull = True
                    csvData.Columns.Add(datecolumn)
                Next

                While Not csvReader.EndOfData
                    Dim fieldData As String() = csvReader.ReadFields()
                    'Making empty value as null
                    For i As Integer = 0 To fieldData.Length - 1
                        If fieldData(i) = "" Then
                            fieldData(i) = Nothing
                        End If
                    Next

                    csvData.Rows.Add(fieldData)
                End While
            End Using

            Return csvData
        Catch ex As Exception
            m_smallIntValues(App.KEY_ERROR) = ERR_IO
            m_TextValues(App.KEY_RESULT) = String.Format("Error parsing csv file content '{0}' ({1}).", m_TextValues(App.KEY_FILE), ex.Message)
            Return Nothing
        End Try
    End Function

End Class
