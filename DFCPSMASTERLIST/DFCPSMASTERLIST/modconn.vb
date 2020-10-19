Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Module modconn
    Public strSQL As String
    Public OleDBC As New SqlCommand
    Public OleDBDR As SqlDataReader
    Public da As New SqlDataAdapter
    Public ds As DataSet
    Public conn As New SqlConnection
    Public strConnString As String
    Public payrollType As String
    Public payrollMode As String
    Public Sub ConnectDatabase()
        'strConnString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=dfcpsMasterlistDB;server=localhost"
        'strConnString = "Data Source=DFARM3;" & _
        '                "Initial Catalog=dfcpsMasterlistDB;" & _
        '                "User ID=dfcps;" & _
        '                "Password=passwork"
        strConnString = "Data Source=" & My.Settings.mServer & ";" & _
                       "Initial Catalog=" & My.Settings.mDBname & ";" & _
                       "User ID=" & My.Settings.mUserDB & ";" & _
                       "Password=" & My.Settings.mPassDB
        conn.ConnectionString = strConnString
        conn.Open()
    End Sub
    Sub checkConn()
        If conn.State = ConnectionState.Open Then
            OleDBC.Dispose()
            conn.Close()
        End If
        If conn.State <> ConnectionState.Open Then
            ConnectDatabase()
        End If
    End Sub
    Function ConvertNumberToENG(ByVal amount As String) As String

        Dim dollars, cents, temp
        Dim decimalPlace, count
        Dim place(9) As String
        place(2) = " Thousand "
        place(3) = " Million "
        place(4) = " Billion "
        place(5) = " Trillion "

        ' String representation of amount.
        amount = amount.Trim()
        amount = amount.Replace(",", "")
        ' Position of decimal place 0 if none.
        decimalPlace = amount.IndexOf(".")
        ' Convert cents and set string amount to dollar amount.
        If decimalPlace > 0 Then
            cents = GetTens(amount.Substring(decimalPlace + 1).PadRight(2, "0").Substring(0, 2))
            amount = amount.Substring(0, decimalPlace).Trim()
        End If

        count = 1
        Do While amount <> ""
            temp = GetHundreds(amount.Substring(Math.Max(amount.Length, 3) - 3))
            If temp <> "" Then dollars = temp & place(count) & dollars
            If amount.Length > 3 Then
                amount = amount.Substring(0, amount.Length - 3)
            Else
                amount = ""
            End If
            count = count + 1
        Loop

        Select Case dollars
            Case ""
                dollars = ""
            Case "One"
                dollars = "One Peso"
            Case Else
                dollars = dollars & " Pesos"
        End Select

        Select Case cents
            Case ""
                cents = ""
            Case "One"
                cents = " and One Cent"
            Case Else
                cents = " and " & cents & " Cents"
        End Select

        ConvertNumberToENG = dollars & cents
    End Function

    ' Converts a number from 100-999 into text
    Function GetHundreds(ByVal amount As String) As String
        Dim Result As String
        If Not Integer.Parse(amount) = 0 Then
            amount = amount.PadLeft(3, "0")
            ' Convert the hundreds place.
            If amount.Substring(0, 1) <> "0" Then
                Result = GetDigit(amount.Substring(0, 1)) & " Hundred "
            End If
            ' Convert the tens and ones place.
            If amount.Substring(1, 1) <> "0" Then
                Result = Result & GetTens(amount.Substring(1))
            Else
                Result = Result & GetDigit(amount.Substring(2))
            End If
            GetHundreds = Result
        End If
    End Function

    ' Converts a number from 10 to 99 into text.
    Private Function GetTens(ByRef TensText As String) As String
        Dim Result As String
        Result = ""           ' Null out the temporary function value.
        If TensText.StartsWith("1") Then   ' If value between 10-19...
            Select Case Integer.Parse(TensText)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        Else                                 ' If value between 20-99...
            Select Case Integer.Parse(TensText.Substring(0, 1))
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Forty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select
            Result = Result & GetDigit(TensText.Substring(1, 1))  ' Retrieve ones place.
        End If
        GetTens = Result
    End Function

    ' Converts a number from 1 to 9 into text.
    Private Function GetDigit(ByRef Digit As String) As String
        Select Case Integer.Parse(Digit)
            Case 1 : GetDigit = "One"
            Case 2 : GetDigit = "Two"
            Case 3 : GetDigit = "Three"
            Case 4 : GetDigit = "Four"
            Case 5 : GetDigit = "Five"
            Case 6 : GetDigit = "Six"
            Case 7 : GetDigit = "Seven"
            Case 8 : GetDigit = "Eight"
            Case 9 : GetDigit = "Nine"
            Case Else : GetDigit = ""
        End Select
    End Function
End Module
