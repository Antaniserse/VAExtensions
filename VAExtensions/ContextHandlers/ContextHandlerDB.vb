Public Class ContextHandlerDB
    Inherits ContextHandlerBase

    Public Sub New(ByVal context As ContextFactory.Contexts, vaProxy As Object)
        MyBase.New(context, vaProxy)
    End Sub

    Public Overrides Function Execute() As Boolean

        If VAProxy.GetText(App.KEY_FILE) Is Nothing Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Unknown database name. Text variable '{0}' not set.", App.KEY_FILE))
            Return False
        End If

        Dim dbFile As String = VAProxy.GetText(App.KEY_FILE)

        If Not IO.Path.IsPathRooted(dbFile) Then
            dbFile = IO.Path.Combine(App.LibraryFolder, dbFile)
        End If

        If Not IO.File.Exists(dbFile) Then
            VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
            VAProxy.SetText(App.KEY_RESULT, String.Format("Database '{0}' not found.", dbFile))
            Return False
        End If
        Dim db As New SQLiteHelper(dbFile)
        Dim sqlStmt, table, columns, where As String

        Select Case Context
            Case ContextFactory.Contexts.ReadDB
                If VAProxy.GetText(App.KEY_DB_TABLE) Is Nothing AndAlso VAProxy.GetText(App.KEY_DB_FULLSTMT) Is Nothing Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("Either '{0}' or {1} variables are required.", App.KEY_DB_FULLSTMT, App.KEY_DB_TABLE))
                    Return False
                Else
                    sqlStmt = VAProxy.GetText(App.KEY_DB_FULLSTMT)
                    If String.IsNullOrEmpty(sqlStmt) Then
                        table = VAProxy.GetText(App.KEY_DB_TABLE)
                        If VAProxy.GetText(App.KEY_DB_COLUMNS) IsNot Nothing Then
                            columns = VAProxy.GetText(App.KEY_DB_COLUMNS)
                        Else
                            columns = "*"
                        End If
                        If VAProxy.GetText(App.KEY_DB_WHERE) IsNot Nothing Then
                            where = " WHERE " & VAProxy.GetText(App.KEY_DB_WHERE)
                        Else
                            where = String.Empty
                        End If
                        sqlStmt = String.Format("SELECT {0} FROM {1}{2}", columns, table, where)
                    End If
                End If

                Dim result As Data.DataTable = db.GetDataTable(sqlStmt)
                If result Is Nothing Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("Database error: '{0}'.", db.LastMessage))
                    Return False
                Else
                    VAProxy.SetText(App.KEY_RESULT, result.Rows(0).Item(0).ToString)
                    Return True
                End If

            Case ContextFactory.Contexts.InsertDB
                If VAProxy.GetText(App.KEY_DB_FULLSTMT) Is Nothing AndAlso (VAProxy.GetText(App.KEY_DB_TABLE) Is Nothing OrElse VAProxy.GetText(App.KEY_DB_COLUMNS) Is Nothing OrElse VAProxy.GetText(App.KEY_DB_VALUES) Is Nothing) Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("Either '{0}' or '{1}', '{2}' and '{3}' variables are required.", App.KEY_DB_FULLSTMT, App.KEY_DB_TABLE, App.KEY_DB_COLUMNS, App.KEY_DB_VALUES))
                    Return False
                End If
                sqlStmt = VAProxy.GetText(App.KEY_DB_FULLSTMT)
                If String.IsNullOrEmpty(sqlStmt) Then
                    Dim values As New Dictionary(Of String, String)
                    Dim tempCol(), tempVal() As String
                    tempCol = Split(VAProxy.GetText(App.KEY_DB_COLUMNS), "|")
                    tempVal = Split(VAProxy.GetText(App.KEY_DB_VALUES), "|")
                    If tempCol.GetLength(0) <> tempVal.GetLength(0) Then
                        VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                        VAProxy.SetText(App.KEY_RESULT, String.Format("'{0}' and '{1}' must have the same number of values.", App.KEY_DB_COLUMNS, App.KEY_ARGUMENTS))
                        Return False
                    End If

                    For i As Integer = 0 To tempCol.GetUpperBound(0)
                        values.Add(tempCol(i), tempVal(i))
                    Next
                    If Not db.Insert(VAProxy.GetText(App.KEY_DB_TABLE), values) Then
                        VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
                        VAProxy.SetText(App.KEY_RESULT, String.Format("Database error: '{0}'.", db.LastMessage))
                        Return False
                    Else
                        Return True
                    End If
                Else
                    If Not db.ExecuteNonQuery(sqlStmt) Then
                        VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
                        VAProxy.SetText(App.KEY_RESULT, String.Format("Database error: '{0}'.", db.LastMessage))
                        Return False
                    Else
                        Return True
                    End If
                End If

                'Primary key/Auto increment column?
                'Dim rowID As Integer
                'If Integer.TryParse(db.ExecuteScalar(String.Format("SELECT last_insert_rowid() AS rowid FROM {0} LIMIT 1", VAProxy.GetText(App.KEY_DB_TABLE))), rowID) Then
                '    VAProxy.SetInt(App.KEY_INDEX, rowID)
                'End If

                'Return True

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
