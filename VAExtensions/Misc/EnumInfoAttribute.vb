
<AttributeUsage(AttributeTargets.Field, AllowMultiple:=False)> _
Public Class EnumInfoAttribute
   Inherits Attribute

   Private m_Description As String
   Private m_Tag As String

   Public Sub New(ByVal description As String)
      Me.New(description, String.Empty)
   End Sub

   Public Sub New(ByVal description As String, ByVal tag As String)
      MyBase.New()
      m_Description = description
      m_Tag = tag
   End Sub

   Public ReadOnly Property Description() As String
      Get
         Return m_Description
      End Get
   End Property

   Public ReadOnly Property Tag() As String
      Get
         Return m_Tag
      End Get
   End Property

   Private Shared Function GetInfoAttribute(ByVal value As System.Enum) As EnumInfoAttribute
      If value Is Nothing Then
         Throw New ArgumentNullException("value")
      Else
         Dim fieldInfo As Reflection.FieldInfo = value.GetType.GetField(value.ToString)
         Dim attributes() As EnumInfoAttribute = DirectCast(fieldInfo.GetCustomAttributes(GetType(EnumInfoAttribute), False), EnumInfoAttribute())

         If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
            Return attributes(0)
         Else
            Return Nothing
         End If
      End If
   End Function

   Public Shared Function GetDescription(ByVal value As System.Enum) As String
      Dim attr As EnumInfoAttribute = GetInfoAttribute(value)

      If attr IsNot Nothing Then
         Return attr.Description
      Else
         Return String.Empty
      End If
   End Function

   Public Shared Function GetTag(ByVal value As System.Enum) As String
      Dim attr As EnumInfoAttribute = GetInfoAttribute(value)

      If attr IsNot Nothing Then
         Return attr.Tag
      Else
         Return String.Empty
      End If
   End Function

   Public Shared Function FindTag(ByVal enumType As System.Type, ByVal tag As String) As System.Enum

      Dim enumValues As Array = System.Enum.GetValues(enumType)
      Dim attr As EnumInfoAttribute

      For Each value As System.Enum In enumValues
         attr = GetInfoAttribute(value)
         If String.Compare(attr.Tag, tag, StringComparison.InvariantCultureIgnoreCase) = 0 Then
            Return (value)
         End If
      Next
      Return Nothing

   End Function

   Public Shared Function FindDescription(ByVal enumType As System.Type, ByVal description As String) As System.Enum

      Dim enumValues As Array = System.Enum.GetValues(enumType)
      Dim attr As EnumInfoAttribute

      For Each value As System.Enum In enumValues
         attr = GetInfoAttribute(value)
         If String.Compare(attr.Description, description, StringComparison.InvariantCultureIgnoreCase) = 0 Then
            Return (value)
         End If
      Next
      Return Nothing

   End Function

   Public Shared Function ToSimpleList(Of T)() As IEnumerable(Of T)
      Dim enumType As Type = GetType(T)

      ' Can't use generic type constraints on value types,
      ' so have to do check like this
      If enumType.BaseType IsNot GetType([Enum]) Then
         Throw New ArgumentException("T must be of type System.Enum")
      Else
         Dim enumValArray As Array = [Enum].GetValues(enumType)
         Dim enumValList As New List(Of T)

         For Each val As Integer In enumValArray
            enumValList.Add(DirectCast([Enum].Parse(enumType, val.ToString()), T))
         Next

         Return enumValList
      End If
   End Function

   Public Shared Function ToBindableList(Of T)() As IList
      Dim enumType As Type = GetType(T)

      ' Can't use generic type constraints on value types,
      ' so have to do check like this
      If enumType.BaseType IsNot GetType([Enum]) Then
         Throw New ArgumentException("T must be of type System.Enum")
      Else
         Dim list As New List(Of KeyValuePair(Of System.Enum, String))
         Dim enumValues As Array = System.Enum.GetValues(enumType)

         For Each value As System.Enum In enumValues
            list.Add(New System.Collections.Generic.KeyValuePair(Of System.Enum, String)(value, GetDescription(value)))
         Next
         Return list
      End If
   End Function
End Class
