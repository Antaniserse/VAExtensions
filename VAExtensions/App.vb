Public Class App

    Public Const KEY_RESULT As String = "VxResult" '"VAReaderResult"
    Public Const KEY_FILE As String = "VxFile" '"VAReaderFile"
    Public Const KEY_ARGUMENTS As String = "VxArgs" '"VAReaderArgs"
    Public Const KEY_REGEX As String = "VxRegEx" '"VAReaderRegEx"
    Public Const KEY_INDEX As String = "VxIndex" '"VAReaderXMLCount"
    Public Const KEY_RSSFORMAT As String = "VxRSSDateFormat" '"VAReaderRSSDateFormat"
    Public Const KEY_SPELL As String = "VxSpell" '"VAReaderSpell"
    Public Const KEY_SPELLASCII As String = "VxSpellASCII" '"VAReaderSpellASCII"

    Public Const KEY_INI_SECTION As String = "VxINISection"
    Public Const KEY_INI_KEY As String = "VxINIKey"

    Public Const KEY_ROW As String = "VxRow"
    Public Const KEY_ROWSCOUNT As String = "VxRowsCount"
    Public Const KEY_COL As String = "VxColumn"
    Public Const KEY_COLSCOUNT As String = "VxColumnsCount"
    Public Const KEY_DELIMITER As String = "VxDelimiter"

    Public Const KEY_DB_TABLE As String = "VxDBTable"
    Public Const KEY_DB_COLUMNS As String = "VxDBColumns"
    Public Const KEY_DB_WHERE As String = "VxDBWhere"


    Public Const KEY_RANGEMIN As String = "VxRangeMin" '"VAMathRangeMin"
    Public Const KEY_RANGEMAX As String = "VxRangeMax" '"VAMathRangeMax"
    Public Const KEY_RANDOMLIST As String = "VxRandomList" '"VAMathCurrentRndList"
    Public Const KEY_CURRENTIDX As String = "VxCurrentIndex" '"VAMathCurrentIndex"

    Public Const KEY_ERROR As String = "VxError" '"VAReaderError"

    Private Shared m_LibraryFolder As String
    Private Shared m_HelpFile As String
    Private Shared m_SettingsFile As String
    Private Shared m_Settings As New Settings

    Shared Sub InitValues()
        m_LibraryFolder = System.IO.Path.GetDirectoryName(GetType(VAExtensions.App).Assembly.Location)
        m_HelpFile = System.IO.Path.Combine(m_LibraryFolder, "VA Extensions Help.rtf")
        m_SettingsFile = System.IO.Path.Combine(m_LibraryFolder, "Settings.xml")
    End Sub

    Public Shared ReadOnly Property LibraryFolder() As String
        Get
            Return m_LibraryFolder
        End Get
    End Property

    Public Shared ReadOnly Property HelpFile() As String
        Get
            Return m_HelpFile
        End Get
    End Property

    Public Shared ReadOnly Property SettingsFile() As String
        Get
            Return m_SettingsFile
        End Get
    End Property

    Public Shared Property Settings() As Settings
        Get
            Return m_Settings
        End Get
        Set(value As Settings)
            m_Settings = value
        End Set

    End Property

    Public Shared Function LimitResponse(ByVal value As String) As String
        Return LimitResponse(value, Nothing)
    End Function

    Public Shared Function LimitResponse(ByVal value As String, ByVal regExPattern As String) As String
        If Not String.IsNullOrEmpty(regExPattern) Then
            Dim r As New Text.RegularExpressions.Regex(regExPattern)
            Dim m As Text.RegularExpressions.Match

            m = r.Match(value)
            If m.Success Then
                If m.Groups.Count > 1 Then
                    value = m.Groups(1).Value
                Else
                    value = m.Value
                End If
            End If
        End If

        If Settings.ResponseLimit = 0 OrElse value Is Nothing OrElse value.Length <= Settings.ResponseLimit Then
            Return value
        Else
            Return value.Substring(0, Settings.ResponseLimit)
        End If
    End Function

    Public Shared Function DownloadFile(ByVal url As String) As DownloadedFile
        Dim result As New DownloadedFile

        If Not url.ToLower.StartsWith("http") Then
            If Not IO.Path.IsPathRooted(url) Then
                url = IO.Path.Combine(LibraryFolder, url)
            End If
        End If
        result.SourcePath = url
        result.TimeStamp = DateTime.Now

        Dim uri As New Uri(result.SourcePath)
        result.LocalPath = String.Empty
        If uri.IsFile Then
            If IO.File.Exists(url) Then
                result.LocalPath = url
                result.IsTemporary = False
            End If
        Else
            If Not IsCachedFile(result) Then
                Dim wc As New Net.WebClient

                result.LocalPath = IO.Path.GetTempFileName
                Try
                    wc.DownloadFile(url, result.LocalPath)
                    result.IsTemporary = True
                    Settings.AddDownloadedFile(result)
                Catch ex As Exception
                    result.LocalPath = String.Empty
                Finally
                    wc.Dispose()
                End Try

            End If
        End If
        Return result
    End Function

    Public Shared Function ReadTextFile(ByVal filename As String) As String
        Dim content As String = Nothing

        Using fileStream = New IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
            Using textReader = New IO.StreamReader(fileStream)
                content = textReader.ReadToEnd()
            End Using
        End Using

        Return content
    End Function

    Public Shared Sub ClearCachedFiles()
        Dim f As DownloadedFile

        For i As Integer = Settings.DownloadedFiles.Count - 1 To 0 Step -1
            f = Settings.DownloadedFiles(i)
            If f.IsExpired Then
                Try
                    IO.File.Delete(f.LocalPath)
                    Settings.DownloadedFiles.RemoveAt(i)
                Catch
                End Try
            End If
        Next
    End Sub

    Public Shared Function IsCachedFile(ByRef file As DownloadedFile) As Boolean
        If Settings.CacheTimeout = 0 Then Return False

        For Each storedFile As DownloadedFile In Settings.DownloadedFiles
            If String.Compare(storedFile.SourcePath, file.SourcePath, True) = 0 Then
                If Not storedFile.IsExpired Then
                    file.LocalPath = storedFile.LocalPath
                    file.TimeStamp = storedFile.TimeStamp
                    file.IsTemporary = storedFile.IsTemporary
                    Return True
                End If
            End If
        Next
        Return False
    End Function

End Class
