Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strLastNames()
        Dim strFemaleNames()
        Dim strMaleNames()
        Dim strNames As String
        Dim strLastname As String = ""
        Dim strFirstname As String = ""
        Dim MaleOrFemale As Short
        Dim Count1 As Int32
        Dim Count2 As Int32

        Randomize()

        strNames = File.ReadAllText("D:\Data\Surnames.txt")
        strLastnames = Split(strNames, vbCrLf)

        strNames = File.ReadAllText("D:\Data\Female.txt")
        strFemaleNames = Split(strNames, vbCrLf)

        strNames = File.ReadAllText("D:\Data\Male.txt")
        strMaleNames = Split(strNames, vbCrLf)

        For i As Integer = 1 To 10000
            Count1 = Random(strLastNames.Length) - 1
            strLastname = Trim(strLastNames(Count1))

            MaleOrFemale = Random(2)
            Select Case MaleOrFemale
                Case 1 ' Male
                    Count2 = Random(strMaleNames.Length) - 1
                    strFirstname = SentenceCase(Trim(strMaleNames(Count2).ToString))
                    Console.WriteLine("(M) " & strFirstname & " " & strLastname)
                Case 2 ' Female
                    Count2 = Random(strFemaleNames.Length) - 1
                    strFirstname = SentenceCase(Trim(strFemaleNames(Count2).ToString))
                    Console.WriteLine("(F) " & strFirstname & " " & strLastname)
            End Select


        Next
    End Sub

    Private Function Random(ByVal UpperBound As Integer) As Integer
        Dim RandomValue As Integer

        RandomValue = CInt(Int((UpperBound - 1 + 1) * Rnd() + 1))

        Return RandomValue
    End Function

    Private Function SentenceCase(ByVal strInput As String) As String
        Dim strOutput As String = ""

        strOutput = strInput.Substring(0, 1).ToUpper & strInput.Substring(1).ToLower

        Return strOutput
    End Function

End Class
