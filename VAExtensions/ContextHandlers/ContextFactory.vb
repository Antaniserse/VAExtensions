Public Class ContextFactory
    Public Shared SupportedContexts As List(Of ContextFactory.Contexts)

    Public Enum Contexts
        <EnumInfo("Show configuration dialog", "config")>
        Config

        <EnumInfo("Read a text file", "read_file")>
        ReadFile
        <EnumInfo("Read an XML File", "read_xml")>
        ReadXml
        <EnumInfo("Read a RSS feed", "read_rss")>
        ReadRSS
        <EnumInfo("Read a JSON feed", "read_json")>
        ReadJSON
        <EnumInfo("Loads a CSV file in memory", "load_csv")>
        LoadCSV
        <EnumInfo("Read a value from a previously loaded CSV file", "read_csv")>
        ReadCSV
        <EnumInfo("Search a specific text in a specific column of a previously loaded CSV file", "search_csv")>
        SearchCSV
        <EnumInfo("Show content of a text file", "show_file")>
        ShowFile
        <EnumInfo("Show content of a text variable", "show_text")>
        ShowText
        <EnumInfo("Convert text variable into list of ASCII character codes", "spell_text")>
        SpellText
        <EnumInfo("Execute a console application and read the output", "read_stdout")>
        ReadStdOut

        <EnumInfo("Read value from the specified key of an INI file", "read_ini")>
        ReadINI
        <EnumInfo("Write value to the specified key of an INI file", "write_ini")>
        WriteINI

        <EnumInfo("Read record from a SQLite database", "read_db")>
        ReadDB
        <EnumInfo("Insert a new record into a SQLite database", "insert_db")>
        InsertDB
        <EnumInfo("Update a record into a SQLite database", "update_db")>
        UpdateDB
        <EnumInfo("Delete a record into a SQLite database", "delete_db")>
        DeleteDB

        <EnumInfo("Perform a bitwise AND operation between two supplied values", "bit_and")>
        BitAnd
        <EnumInfo("Perform a bitwise OR operation between two supplied values", "bit_or")>
        BitOr
        <EnumInfo("Perform a bitwise XOR operation between two supplied values", "bit_xor")>
        BitXOr

        <EnumInfo("Start a timer of X seconds", "timer_start")>
        TimerStart
        <EnumInfo("Check timer running time", "timer_check")>
        TimerCheck

        <EnumInfo("Create a random list of non-repeating numbers", "rnd_init")>
        RandomInit
        <EnumInfo("Get the next number from a previously created random list", "rnd_next")>
        RandomNext
        <EnumInfo("Re-shuffle the values in a previously created random list", "rnd_shuffle")>
        RandomShuffle
    End Enum

    Shared Sub New()
        SupportedContexts = New List(Of ContextFactory.Contexts)
        SupportedContexts.AddRange(EnumInfoAttribute.ToSimpleList(Of Contexts))
    End Sub

    Public Shared Function Create(vaProxy As Object) As ContextHandlerBase

        Dim result As ContextHandlerBase = Nothing

        For Each c As Contexts In SupportedContexts
            If String.Compare(EnumInfoAttribute.GetTag(c), vaProxy.Context, True) = 0 Then
                Select Case c
                    Case Contexts.Config
                        result = New ContextHandlerInfoDialog(c, vaProxy)

                    Case Contexts.ReadFile
                        result = New ContextHandlerReadFile(c, vaProxy)

                    Case Contexts.ReadXml
                        result = New ContextHandlerReadXML(c, vaProxy)

                    Case Contexts.ReadJSON
                        result = New ContextHandlerReadJSON(c, vaProxy)

                    Case Contexts.ReadRSS
                        result = New ContextHandlerReadRSS(c, vaProxy)

                    Case Contexts.LoadCSV, Contexts.ReadCSV, Contexts.SearchCSV
                        result = New ContextHandlerReadCSV(c, vaProxy)

                    Case Contexts.ShowFile, Contexts.ShowText
                        result = New ContextHandlerShowFile(c, vaProxy)

                    Case Contexts.SpellText
                        result = New ContextHandlerSpellText(c, vaProxy)

                    Case Contexts.ReadStdOut
                        result = New ContextHandlerReadStdOut(c, vaProxy)

                    Case Contexts.ReadINI
                        result = New ContextHandlerReadINI(c, vaProxy)
                    Case Contexts.WriteINI
                        result = New ContextHandlerWriteINI(c, vaProxy)

                    Case Contexts.RandomInit, Contexts.RandomNext
                        result = New ContextHandlerRandom(c, vaProxy)
                    Case Contexts.TimerStart, Contexts.TimerCheck
                        result = New ContextHandlerCountdown(c, vaProxy)

                End Select
                Exit For
            End If
        Next

        Return result
    End Function
End Class
