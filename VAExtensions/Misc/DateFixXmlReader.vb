Imports System.Xml

Class DateFixXmlReader
   Inherits XmlTextReader

   Public Shared CustomUtcDateTimeFormat As String = "ddd, dd MMM yyyy HH:mm:ss Z"
   Private readingDate As Boolean = False

   Public Sub New(s As IO.Stream)
      MyBase.New(s)
   End Sub

   Public Sub New(inputUri As String)
      MyBase.New(inputUri)
   End Sub

   Public Overrides Sub ReadStartElement()
      If String.Equals(MyBase.NamespaceURI, String.Empty, StringComparison.InvariantCultureIgnoreCase) _
         AndAlso (String.Equals(MyBase.LocalName, "lastBuildDate", StringComparison.InvariantCultureIgnoreCase) _
         OrElse String.Equals(MyBase.LocalName, "pubDate", StringComparison.InvariantCultureIgnoreCase)) Then

         readingDate = True
      End If
      MyBase.ReadStartElement()
   End Sub

   Public Overrides Sub ReadEndElement()
      If readingDate Then
         readingDate = False
      End If
      MyBase.ReadEndElement()
   End Sub

   Public Overrides Function ReadString() As String
      If readingDate Then
         Dim dateString As String = MyBase.ReadString()
         Dim dt As DateTime
         If Not DateTime.TryParse(dateString, dt) Then
            dt = DateTime.ParseExact(dateString, CustomUtcDateTimeFormat, Globalization.CultureInfo.InvariantCulture)
         End If
         Return dt.ToUniversalTime().ToString("R", Globalization.CultureInfo.InvariantCulture)
      Else
         Return MyBase.ReadString()
      End If
   End Function
End Class