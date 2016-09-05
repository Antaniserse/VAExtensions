Public Class ContextHandlerShowFile
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
        Dim newFile As DownloadedFile = Nothing
        Dim textVar As String = Nothing

        If m_Context = ContextFactory.Contexts.ShowFile Then
            If Not m_TextValues.ContainsKey(App.KEY_FILE) Then
                m_smallIntValues(App.KEY_ERROR) = ERR_CONTEXT
                m_TextValues(App.KEY_RESULT) = String.Format("Unknown file name. Text variable '{0}' not set.", App.KEY_FILE)
                Return False
            End If

            Try
                newFile = App.DownloadFile(m_TextValues(App.KEY_FILE))
                If newFile.LocalPath.Length = 0 Then
                    m_smallIntValues(App.KEY_ERROR) = ERR_IO
                    m_TextValues(App.KEY_RESULT) = String.Format("Error retrieving File '{0}'.", m_TextValues(App.KEY_FILE))
                    Return False
                End If
            Catch ex As Exception
                m_smallIntValues(App.KEY_ERROR) = ERR_IO
                m_TextValues(App.KEY_RESULT) = String.Format("Error loading file content '{0}'.", m_TextValues(App.KEY_FILE))
                Return False
            End Try
        ElseIf m_Context = ContextFactory.Contexts.ShowText Then
            If m_TextValues.Count = 0 Then
                m_smallIntValues(App.KEY_ERROR) = ERR_ARGUMENTS
                m_TextValues(App.KEY_RESULT) = "At least one text value is needed."
                Return False
            Else
                textVar = m_TextValues(m_TextValues.Keys(0))
            End If
        End If

        Dim viewer As New TextForm(newFile, textVar)
        viewer.ShowDialog()
        viewer.Dispose()
        If newFile IsNot Nothing AndAlso newFile.IsTemporary Then App.Settings.AddDownloadedFile(newFile)

        Return True
    End Function
End Class
