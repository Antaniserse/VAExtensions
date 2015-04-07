Imports System.Collections.Generic
Imports System.Text
Imports System.Xml.Serialization

<Serializable> Public Class Storage
   Private Shared m_Storage As Storage
   Private Shared storageFile As String = IO.Path.Combine(System.IO.Path.GetDirectoryName(GetType(Storage).Assembly.Location), "Storage.xml")

   Public Conditions As New SerializableDictionary(Of String, Nullable(Of Int16))
   Public TextValues As New SerializableDictionary(Of String, String)

   Private Sub New()
      'singleton
   End Sub

   Public Shared Function Load(ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String)) As Boolean
      Dim result As Boolean = loadStorageFile()

      If result Then
         'If the dictionaries contains specific keys, we only return those ones;
         'otherwise we return the full list of values stored
         Dim loadAllCond As Boolean = conditions.Count = 0
         Dim loadAllTextVar As Boolean = textValues.Count = 0

         For Each c As KeyValuePair(Of String, Nullable(Of Int16)) In m_Storage.Conditions
            If loadAllCond OrElse conditions.ContainsKey(c.Key) Then
               conditions(c.Key) = m_Storage.Conditions(c.Key)
            End If
         Next
         For Each c As KeyValuePair(Of String, String) In m_Storage.TextValues
            If loadAllTextVar OrElse textValues.ContainsKey(c.Key) Then
               textValues(c.Key) = m_Storage.TextValues(c.Key)
            End If
         Next
      End If
      Return result
   End Function

   Public Shared Function Save(ByRef conditions As Dictionary(Of String, Nullable(Of Int16)), ByRef textValues As Dictionary(Of String, String)) As Boolean
      Dim result As Boolean

      If m_Storage Is Nothing Then
         loadStorageFile()  'do a full load if not initialized, so that we don't lose values stored in a previous session
      End If
      For Each c As KeyValuePair(Of String, Nullable(Of Int16)) In conditions
         m_Storage.Conditions(c.Key) = c.Value
      Next
      For Each t As KeyValuePair(Of String, String) In textValues
         m_Storage.TextValues(t.Key) = t.Value
      Next

      Dim fs As IO.FileStream = Nothing
      Dim serializer As System.Xml.Serialization.XmlSerializer
      Try
         fs = New IO.FileStream(storageFile, IO.FileMode.Create, IO.FileAccess.Write)
         serializer = New Xml.Serialization.XmlSerializer(m_Storage.GetType())
         serializer.Serialize(fs, m_Storage)

         result = True
      Catch ex As Exception
         result = False
      Finally
         If fs IsNot Nothing Then
            fs.Close()
            fs.Dispose()
         End If
      End Try

      Return result
   End Function

   Public Shared Function Clear() As Boolean
      If m_Storage Is Nothing Then
         m_Storage = New Storage
      End If
      m_Storage.Conditions.Clear()
      m_Storage.TextValues.Clear()
      Return Save(New Dictionary(Of String, Nullable(Of Int16)), New Dictionary(Of String, String))
   End Function

   Private Shared Function loadStorageFile() As Boolean
      Return loadStorageFile(False)
   End Function

   Private Shared Function loadStorageFile(ByVal forceReload As Boolean) As Boolean
      Dim result As Boolean

      If m_Storage IsNot Nothing AndAlso Not forceReload Then
         'already loaded
         result = True
      ElseIf Not IO.File.Exists(storageFile) Then
         'no existing file, start an empty storage
         m_Storage = New Storage
         result = True
      Else
         'load the storage file
         Dim serializer As Xml.Serialization.XmlSerializer
         Dim fs As IO.FileStream = Nothing
         Try
            fs = New IO.FileStream(storageFile, IO.FileMode.Open, IO.FileAccess.Read)
            serializer = New Xml.Serialization.XmlSerializer(GetType(Storage))
            m_Storage = CType(serializer.Deserialize(fs), Storage)

            result = True
         Catch ex As Exception
            'If ex.InnerException IsNot Nothing Then
            '   lastError = ex.InnerException.Message
            'Else
            '   lastError = ex.Message
            'End If
            result = False
         Finally
            If fs IsNot Nothing Then
               fs.Close()
               fs.Dispose()
            End If
         End Try
      End If

      Return result
   End Function
End Class