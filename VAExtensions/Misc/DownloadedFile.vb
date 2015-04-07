<SerializableAttribute> Public Class DownloadedFile
	private m_SourcePath As String 
	private m_LocalPath As String
	private m_IsTemporary As Boolean
	private m_TimeStamp As DateTime
	
	Public Property SourcePath() As String
		Get
			Return m_SourcePath
		End Get
		Set
			m_SourcePath = value
		End Set
	End Property
		
	Public Property LocalPath() As String
		Get
			Return m_LocalPath
		End Get
		Set
			m_LocalPath = value
		End Set
	End Property

	Public Property IsTemporary() As Boolean
		Get
			Return m_IsTemporary
		End Get
		Set
			m_IsTemporary = value
		End Set
	End Property
	
	Public Property TimeStamp() As DateTime
		Get
			Return m_TimeStamp
		End Get
		Set
			m_TimeStamp = value
		End Set
	End Property
	
	Public ReadOnly Property IsExpired() As Boolean
		Get
			If Not IsTemporary Then Return False
			
			If App.Settings.CacheTimeout=0 Then return true
			
			Return DateTime.Now.Subtract(me.TimeStamp).TotalMinutes>App.Settings.CacheTimeout
		End Get
	End Property
End Class