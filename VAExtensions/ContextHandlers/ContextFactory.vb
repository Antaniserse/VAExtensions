Public Class ContextFactory
   Public Shared SupportedContexts As List(Of ContextFactory.Contexts)

   Public Enum Contexts
      <EnumInfo("Show configuration dialog", "config")> _
      Config

      <EnumInfo("Read a text file", "read_file")> _
      ReadFile
      <EnumInfo("Read an XML File", "read_xml")> _
      ReadXml
      <EnumInfo("Read a RSS feed", "read_rss")> _
      ReadRSS
      <EnumInfo("Show content of a text file", "show_file")> _
      ShowFile
      <EnumInfo("Show content of a text variable", "show_text")> _
      ShowText
      <EnumInfo("Convert text variable into list of ASCII character codes", "spell_text")> _
      SpellText
      <EnumInfo("Execute a console application and read the output", "read_stdout")> _
      ReadStdOut

      <EnumInfo("Read value from the specified key of an INI file", "read_ini")> _
      ReadINI
      <EnumInfo("Write value to the specified key of an INI file", "write_ini")> _
      WriteINI

      <EnumInfo("Read record from a SQLite database", "read_db")> _
      ReadDB
      <EnumInfo("Insert a new record into a SQLite database", "insert_db")> _
      InsertDB
      <EnumInfo("Update a record into a SQLite database", "update_db")> _
      UpdateDB
      <EnumInfo("Delete a record into a SQLite database", "delete_db")> _
      DeleteDB


      <EnumInfo("Perform an addition of all the given values", "math_add")> _
      MathAdd
      <EnumInfo("Perform an subtraction of all the given values", "math_subtract")> _
      MathSubtract
      <EnumInfo("Perform a multiplication of all the given values", "math_multiply")> _
      MathMultiply
      <EnumInfo("Perform a division of all the given values", "math_divide")> _
      MathDivide
      <EnumInfo("Perform a modulo operation (remainder of division) all the given values", "math_mod")> _
      MathMod
      <EnumInfo("Return the higher in a list of values", "math_max")> _
      MathMax
      <EnumInfo("Return the lower in a list of values", "math_min")> _
      MathMin

      <EnumInfo("Perform a bitwise AND operation between two supplied values", "bit_and")> _
      BitAnd
      <EnumInfo("Perform a bitwise OR operation between two supplied values", "bit_or")> _
      BitOr
      <EnumInfo("Perform a bitwise XOR operation between two supplied values", "bit_xor")> _
      BitXOr

      <EnumInfo("Start a timer of X seconds and manage the countdown to zero", "countdown")> _
      Countdown

      <EnumInfo("Create a random list of non-repeating numbers", "rnd_init")> _
      RandomInit
      <EnumInfo("Get the next number from a previously created random list", "rnd_next")> _
      RandomNext
   End Enum

   Shared Sub New()
      SupportedContexts = New List(Of ContextFactory.Contexts)
      SupportedContexts.AddRange(EnumInfoAttribute.ToSimpleList(Of Contexts))
   End Sub

   Public Shared Function Create(ByVal contextName As String, ByRef state As Dictionary(Of String, Object) _
                              , ByRef smallIntValues As Dictionary(Of String, Nullable(Of Short)) _
                              , ByRef textValues As Dictionary(Of String, String) _
                              , ByRef intValues As Dictionary(Of String, Nullable(Of Integer)) _
                              , ByRef decimalValues As Dictionary(Of String, Nullable(Of Decimal)) _
                              , ByRef booleanValues As Dictionary(Of String, Nullable(Of Boolean)) _
                              , ByRef extendedValues As Dictionary(Of String, Object)) As ContextHandlerBase

      Dim result As ContextHandlerBase = Nothing

      For Each c As Contexts In SupportedContexts
         If String.Compare(EnumInfoAttribute.GetTag(c), contextName, True) = 0 Then
            Select Case c
               Case Contexts.Config
                  result = New ContextHandlerInfoDialog(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)

               Case Contexts.ReadFile
                  result = New ContextHandlerReadFile(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)

               Case Contexts.ReadXml
                  result = New ContextHandlerReadXML(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)

               Case Contexts.ReadRSS
                  result = New ContextHandlerReadRSS(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)

               Case Contexts.ShowFile, Contexts.ShowText
                  result = New ContextHandlerShowFile(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)

               Case Contexts.SpellText
                  result = New ContextHandlerSpellText(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)

               Case Contexts.ReadStdOut
                  result = New ContextHandlerReadStdOut(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)

               Case Contexts.ReadINI
                  result = New ContextHandlerReadINI(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
               Case Contexts.WriteINI
                  result = New ContextHandlerWriteINI(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)

               Case Contexts.MathAdd, Contexts.MathSubtract, Contexts.MathMultiply, Contexts.MathDivide _
                  , Contexts.MathMod, Contexts.MathMin, Contexts.MathMax, Contexts.BitAnd, Contexts.BitOr, Contexts.BitXOr
                  result = New ContextHandlerMath(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)

               Case Contexts.RandomInit, Contexts.RandomNext
                  result = New ContextHandlerRandom(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)
               Case Contexts.Countdown
                  result = New ContextHandlerCountdown(c, state, smallIntValues, textValues, intValues, decimalValues, booleanValues, extendedValues)

            End Select
            Exit For
         End If
      Next

      Return result
   End Function
End Class
