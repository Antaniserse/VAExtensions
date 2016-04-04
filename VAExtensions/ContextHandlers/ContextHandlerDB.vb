Public Class ContextHandlerDB
    Inherits ContextHandlerBase

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

        If Not m_TextValues.ContainsKey(App.KEY_FILE) Then
            m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
            m_TextValues(App.KEY_RESULT) = String.Format("Unknown database name. Text variable '{0}' not set.", App.KEY_FILE)
            Return False
        End If

        Dim dbFile As String = m_TextValues(App.KEY_FILE)

        If Not IO.Path.IsPathRooted(dbFile) Then
            dbFile = IO.Path.Combine(App.LibraryFolder, dbFile)
        End If

        If Not IO.File.Exists(dbFile) Then
            m_smallIntValues(App.KEY_ERROR) = ERR_IO
            m_TextValues(App.KEY_RESULT) = String.Format("Database '{0}' not found.", dbFile)
            Return False
        End If
        Dim db As New SQLiteHelper(dbFile)
        Dim table, columns, where As String


        Select Case m_Context
            Case ContextFactory.Contexts.ReadDB
                If Not m_TextValues.ContainsKey(App.KEY_DB_TABLE) OrElse Not m_TextValues.ContainsKey(App.KEY_DB_COLUMNS) OrElse Not m_TextValues.ContainsKey(App.KEY_DB_WHERE) Then
                    m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                    m_TextValues(App.KEY_RESULT) = "'Table', 'Columns' and 'Where' arguments are required."
                    Return False
                Else
                    table = m_TextValues(App.KEY_DB_TABLE)
                    If m_TextValues.ContainsKey(App.KEY_DB_COLUMNS) Then
                        columns = m_TextValues(App.KEY_DB_COLUMNS)
                    Else
                        columns = "*"
                    End If
                    If m_TextValues.ContainsKey(App.KEY_DB_WHERE) Then
                        where = " WHERE " & m_TextValues(App.KEY_DB_WHERE)
                    Else
                        where = String.Empty
                    End If
                End If

                Dim result As Data.DataTable = db.GetDataTable("SELECT {0} FROM {1}{2}", columns, table, where)
                If result Is Nothing Then
                    m_smallIntValues(App.KEY_ERROR) = ERR_IO
                    m_TextValues(App.KEY_RESULT) = String.Format("Database error: '{0}'.", db.LastMessage)
                    Return False
                Else
                    m_TextValues(App.KEY_RESULT) = result.Rows(0).Item(0).ToString
                    Return True
                End If
            Case ContextFactory.Contexts.InsertDB
                If Not m_TextValues.ContainsKey(App.KEY_DB_TABLE) OrElse Not m_TextValues.ContainsKey(App.KEY_DB_COLUMNS) OrElse Not m_TextValues.ContainsKey(App.KEY_ARGUMENTS) Then
                    m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                    m_TextValues(App.KEY_RESULT) = "'Table', 'Columns' and 'Args' arguments are required."
                    Return False
                End If
                Dim values As New Dictionary(Of String, String)
                Dim tempCol(), tempVal() As String
                tempCol = Split(m_TextValues(App.KEY_DB_COLUMNS), ",")
                tempVal = Split(m_TextValues(App.KEY_ARGUMENTS), ",")
                If tempCol.GetLength(0) <> tempVal.GetLength(0) Then
                    m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                    m_TextValues(App.KEY_RESULT) = "'Columns' and 'Args' must have teh same number of values."
                    Return False
                End If

                For i As Integer = 0 To tempCol.GetUpperBound(0)
                    values.Add(tempCol(i), tempVal(i))
                Next
                If Not db.Insert(m_TextValues(App.KEY_DB_TABLE), values) Then
                    m_smallIntValues(App.KEY_ERROR) = ERR_IO
                    m_TextValues(App.KEY_RESULT) = String.Format("Database error: '{0}'.", db.LastMessage)
                    Return False
                Else
                    'Primary key/Auto increment column?
                    Dim rowID As Integer
                    If Integer.TryParse(db.ExecuteScalar(String.Format("SELECT last_insert_rowid() AS rowid FROM {0} LIMIT 1", m_TextValues(App.KEY_DB_TABLE))), rowID) Then
                        m_intValues(App.KEY_INDEX) = rowID
                    End If

                    Return True
                End If
            Case ContextFactory.Contexts.UpdateDB
        'Dim db As New SQLiteHelper("test.s3db")
        'Dim values As New Dictionary(Of String, String)

        'values.Add("Breed", "Something")
        'values.Add("Name", "Jimbo")
        'values.Add("Percentage", "2.7")
        'Try
        '   db.Update("Cats", values, "Cats.id=" & DataGrid1.SelectedRows(0).Cells(0).Value.ToString)
        'Catch ex As Exception
        '   MessageBox.Show(ex.Message)
        'End Try
            Case ContextFactory.Contexts.DeleteDB
                'Dim db As New SQLiteHelper("test.s3db")
                'Dim values As New Dictionary(Of String, String)

                'values.Add("Breed", "Something")
                'values.Add("Name", "Jimbo")
                'values.Add("Percentage", "2.7")
                'Try
                '   db.Update("Cats", values, "Cats.id=" & DataGrid1.SelectedRows(0).Cells(0).Value.ToString)
                'Catch ex As Exception
                '   MessageBox.Show(ex.Message)
                'End Try
        End Select

    End Function
End Class
