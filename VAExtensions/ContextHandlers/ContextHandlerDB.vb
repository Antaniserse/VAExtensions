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
        Dim table, columns, where As String


        Select Case Context
            Case ContextFactory.Contexts.ReadDB
                If VAProxy.GetText(App.KEY_DB_TABLE) Is Nothing Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("The '{0}', variable is required.", App.KEY_DB_TABLE))
                    Return False
                Else
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
                End If

                    Dim result As Data.DataTable = db.GetDataTable("SELECT {0} FROM {1}{2}", columns, table, where)
                If result Is Nothing Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_IO)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("Database error: '{0}'.", db.LastMessage))
                    Return False
                Else
                    VAProxy.SetText(App.KEY_RESULT, result.Rows(0).Item(0).ToString)
                    Return True
                End If
            Case ContextFactory.Contexts.InsertDB
                If VAProxy.GetText(App.KEY_DB_TABLE) Is Nothing OrElse VAProxy.GetText(App.KEY_DB_COLUMNS) Is Nothing OrElse VAProxy.GetText(App.KEY_ARGUMENTS) Is Nothing Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("The '{0}', '{1}' and '{2}' arguments are required.", App.KEY_DB_TABLE, App.KEY_DB_COLUMNS, App.KEY_ARGUMENTS))
                    Return False
                End If
                Dim values As New Dictionary(Of String, String)
                Dim tempCol(), tempVal() As String
                tempCol = Split(VAProxy.GetText(App.KEY_DB_COLUMNS), ",")
                tempVal = Split(VAProxy.GetText(App.KEY_ARGUMENTS), ",")
                If tempCol.GetLength(0) <> tempVal.GetLength(0) Then
                    VAProxy.SetSmallInt(App.KEY_ERROR, ERR_ARGUMENTS)
                    VAProxy.SetText(App.KEY_RESULT, String.Format("'{0}' and '{2}' must have the same number of values.", App.KEY_DB_COLUMNS, App.KEY_ARGUMENTS))
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
                    'Primary key/Auto increment column?
                    Dim rowID As Integer
                    If Integer.TryParse(db.ExecuteScalar(String.Format("SELECT last_insert_rowid() AS rowid FROM {0} LIMIT 1", VAProxy.GetText(App.KEY_DB_TABLE))), rowID) Then
                        VAProxy.SetInt(App.KEY_INDEX, rowID)
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
