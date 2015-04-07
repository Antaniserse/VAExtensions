
<SerializableAttribute> Public Class Settings
	private m_CacheTimeout As Int32	
   Private m_ResponseLimit As Int32
   Private m_RSSCustomDateTimeFormat As String = String.Empty 'so that the entry is always serialized in the file, for user reference, even when empty
	private m_DownloadedFiles As New List(Of DownloadedFile)
		
	Public Property CacheTimeout() As Int32
		Get
			Return m_CacheTimeout
		End Get
		Set
			m_CacheTimeout = value
		End Set
	End Property
		
	Public Property ResponseLimit() As Int32
		Get
			Return m_ResponseLimit
		End Get
		Set
			m_ResponseLimit = value
		End Set
	End Property

   Public Property RSSCustomDateTimeFormat() As String
      Get
         Return m_RSSCustomDateTimeFormat
      End Get
      Set(value As String)
         m_RSSCustomDateTimeFormat = value
      End Set
   End Property

	Public Property DownloadedFiles() As List(Of DownloadedFile)
		Get
			Return m_DownloadedFiles
		End Get
		Set
			m_DownloadedFiles = value
		End Set
	End Property
	
	Public Shared Function Deserialize() As Settings
		Dim obj As Settings 
		Dim serializer As Xml.Serialization.XmlSerializer
		Dim fs As IO.FileStream=Nothing 
		Try
			fs = New IO.FileStream(App.SettingsFile, IO.FileMode.Open, IO.FileAccess.Read)
			serializer= New Xml.Serialization.XmlSerializer(GetType(Settings))
			obj = CType(serializer.Deserialize(fs), Settings)
		Catch ex As Exception
'			If ex.InnerException IsNot Nothing Then
'				lastError = ex.InnerException.Message
'			Else
'				lastError = ex.Message
'			End If
			obj=New Settings 
		Finally
			If fs IsNot Nothing Then 
				fs.Close 
				fs.Dispose
			End If
		End Try

		Return obj
	End Function
	
	Public Shared Function Serialize(ByVal objectToSerialize As Settings) As Boolean
		If objectToSerialize IsNot Nothing Then
			Dim fs As IO.FileStream=Nothing 
			Dim fi As New IO.FileInfo(App.SettingsFile)
			Dim serializer As System.Xml.Serialization.XmlSerializer
			
			If fi.Exists AndAlso fi.IsReadOnly Then
				Return True 'If the user has marked the as 'ReadOnly' we return success
			Else
				Try
					fs = New IO.FileStream(App.SettingsFile, IO.FileMode.Create)
				 	serializer  = New Xml.Serialization.XmlSerializer(objectToSerialize.GetType())
					serializer.Serialize(fs, objectToSerialize)
					Serialize = True
			    Catch ex As Exception
			       Serialize = False
			    Finally
			       If fs IsNot Nothing Then 
						fs.Close 
						fs.Dispose
					End If
			    End Try
			End If
		Else
			Return False 
		End If
	End Function
	
	Public Sub AddDownloadedFile(item As DownloadedFile)
		For i As Integer = me.DownloadedFiles.Count -1 To 0 Step -1
			If String.Compare(me.DownloadedFiles(i).SourcePath,item.SourcePath,True)=0 Then
            If Me.DownloadedFiles(i).IsExpired Then
               Try
                  IO.File.Delete(Me.DownloadedFiles(i).LocalPath)
               Catch
               End Try
            End If
            Me.DownloadedFiles.RemoveAt(i)
			End If
		Next
		Me.DownloadedFiles.Add(item)
		Settings.Serialize(me)
	End Sub
End Class
