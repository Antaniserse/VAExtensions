Imports System.Data
Imports System.Data.SQLite

Class SQLiteHelper
   Private dbFileName As String
   Private dbConnection As String
   Private dbLastMessage As String

   ''' <summary>
   '''     Default Constructor for SQLiteDatabase Class.
   ''' </summary>
   Public Sub New()

   End Sub

   ''' <summary>
   '''     Single Param Constructor for specifying the DB file.
   ''' </summary>
   ''' <param name="inputFile">The File containing the DB</param>
   Public Sub New(ByVal inputFile As String)
      dbFileName = inputFile
      dbConnection = String.Format("Data Source={0}", dbFileName)
   End Sub

   ''' <summary>
   '''     Single Param Constructor for specifying advanced connection options.
   ''' </summary>
   ''' <param name="connectionOpts">A dictionary containing all desired options and their values</param>
   Public Sub New(ByVal connectionOpts As Dictionary(Of String, String))
      Dim str As String = String.Empty
      For Each row As KeyValuePair(Of String, String) In connectionOpts
         str += String.Format("{0}={1}; ", row.Key, row.Value)
         If String.Compare(row.Key.Trim, "data source", True) = 0 Then
            dbFileName = row.Value.Trim
         End If
      Next
      str = str.Trim().Substring(0, str.Length - 1)
      dbConnection = str
   End Sub

   Public ReadOnly Property FileName() As String
      Get
         Return dbFileName
      End Get
   End Property

   Public ReadOnly Property ConnectionString() As String
      Get
         Return dbConnection
      End Get
   End Property

   Public ReadOnly Property LastMessage() As String
      Get
         Return dbLastMessage
      End Get
   End Property

   Public Function GetDataTable(ByVal format As String, ByVal ParamArray args() As Object) As DataTable
      Return GetDataTable(String.Format(format, args))
   End Function

   ''' <summary>
   '''     Allows the programmer to run a query against the Database.
   ''' </summary>
   ''' <param name="sql">The SQL to run</param>
   ''' <returns>A DataTable containing the result set.</returns>
   Public Function GetDataTable(ByVal sql As String) As DataTable
      dbLastMessage = String.Empty

      Dim dt As New DataTable()
      Try
         Dim cnn As New SQLiteConnection(dbConnection)
         cnn.Open()
         Dim mycommand As New SQLiteCommand(cnn)
         mycommand.CommandText = sql
         Dim reader As SQLiteDataReader = mycommand.ExecuteReader()
         dt.Load(reader)
         reader.Close()
         cnn.Close()
      Catch ex As Exception
         dbLastMessage = ex.Message
      End Try
      Return dt
   End Function

   ''' <summary>
   '''     Allows the programmer to interact with the database for purposes other than a query.
   ''' </summary>
   ''' <param name="sql">The SQL to be run.</param>
   ''' <returns>An Integer containing the number of rows updated.</returns>
   Public Function ExecuteNonQuery(ByVal sql As String) As Integer
      dbLastMessage = String.Empty

      Dim rowsUpdated As Integer
      Try
         Dim cnn As New SQLiteConnection(dbConnection)
         cnn.Open()
         Dim mycommand As New SQLiteCommand(cnn)
         mycommand.CommandText = sql
         rowsUpdated = mycommand.ExecuteNonQuery()
         cnn.Close()
      Catch ex As Exception
         dbLastMessage = ex.Message
      End Try

      Return rowsUpdated
   End Function

   ''' <summary>
   '''     Allows the programmer to retrieve single items from the DB.
   ''' </summary>
   ''' <param name="sql">The query to run.</param>
   ''' <returns>A string.</returns>
   Public Function ExecuteScalar(ByVal sql As String) As String
      dbLastMessage = String.Empty

      Try
         Dim cnn As New SQLiteConnection(dbConnection)
         cnn.Open()
         Dim mycommand As New SQLiteCommand(cnn)
         mycommand.CommandText = sql
         Dim value As Object = mycommand.ExecuteScalar()
         cnn.Close()
         If value IsNot Nothing Then
            Return value.ToString()
         End If
      Catch ex As Exception
         dbLastMessage = ex.Message
      End Try

      Return String.Empty
   End Function

   ''' <summary>
   '''     Allows the programmer to easily update rows in the DB.
   ''' </summary>
   ''' <param name="tableName">The table to update.</param>
   ''' <param name="data">A dictionary containing Column names and their new values.</param>
   ''' <param name="where">The where clause for the update statement.</param>
   ''' <returns>A boolean true or false to signify success or failure.</returns>
   Public Function Update(ByVal tableName As String, ByVal data As Dictionary(Of String, String), ByVal where As String) As Boolean
      dbLastMessage = String.Empty

      Dim vals As String = String.Empty

      If data.Count >= 1 Then
         For Each val As KeyValuePair(Of String, String) In data
            vals += String.Format(" {0} = '{1}',", val.Key, fixText(val.Value))
         Next
         vals = vals.Substring(0, vals.Length - 1)
      End If
      Try
         Me.ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, where))
         Return True
      Catch ex As Exception
         dbLastMessage = ex.Message
         Return False
      End Try

   End Function

   ''' <summary>
   '''     Allows the programmer to easily delete rows from the DB.
   ''' </summary>
   ''' <param name="tableName">The table from which to delete.</param>
   ''' <param name="where">The where clause for the delete.</param>
   ''' <returns>A boolean true or false to signify success or failure.</returns>
   Public Function Delete(ByVal tableName As String, ByVal where As String) As Boolean
      dbLastMessage = String.Empty

      Dim returnCode As Boolean
      Try
         Me.ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where))
         returnCode = True
      Catch ex As Exception
         dbLastMessage = ex.Message
         returnCode = False
      End Try
      Return returnCode
   End Function

   ''' <summary>
   '''     Allows the programmer to easily insert into the DB
   ''' </summary>
   ''' <param name="tableName">The table into which we insert the data.</param>
   ''' <param name="data">A dictionary containing the column names and data for the insert.</param>
   ''' <returns>A boolean true or false to signify success or failure.</returns>
   Public Function Insert(ByVal tableName As String, ByVal data As Dictionary(Of String, String)) As Boolean
      dbLastMessage = String.Empty

      Dim columns As String = String.Empty
      Dim values As String = String.Empty

      For Each val As KeyValuePair(Of String, String) In data
         columns += String.Format(" {0},", val.Key.ToString())
         values += String.Format(" '{0}',", fixText(val.Value))
      Next
      columns = columns.Substring(0, columns.Length - 1)
      values = values.Substring(0, values.Length - 1)
      Try
         Me.ExecuteNonQuery(String.Format("insert into {0}({1}) values({2});", tableName, columns, values))
         Return True
      Catch ex As Exception
         dbLastMessage = ex.Message
         Return False
      End Try
   End Function

   ''' <summary>
   '''     Allows the programmer to easily delete all data from the DB.
   ''' </summary>
   ''' <returns>A boolean true or false to signify success or failure.</returns>
   Public Function ClearDB() As Boolean
      dbLastMessage = String.Empty

      Dim tables As DataTable
      Try
         tables = Me.GetDataTable("select NAME from SQLITE_MASTER where type='table' order by NAME;")
         For Each table As DataRow In tables.Rows
            Me.ClearTable(table("NAME").ToString())
         Next
         Return True
      Catch ex As Exception
         dbLastMessage = ex.Message
         Return False
      End Try
   End Function

   ''' <summary>
   '''     Allows the user to easily clear all data from a specific table.
   ''' </summary>
   ''' <param name="table">The name of the table to clear.</param>
   ''' <returns>A boolean true or false to signify success or failure.</returns>
   Public Function ClearTable(ByVal table As String) As Boolean
      dbLastMessage = String.Empty

      Try
         Me.ExecuteNonQuery(String.Format("delete from {0};", table))
         Return True
      Catch ex As Exception
         dbLastMessage = ex.Message
         Return False
      End Try
   End Function

   Private Function fixText(ByVal textIN As String) As String
      Return textIN.Replace("'", "''")
   End Function
End Class