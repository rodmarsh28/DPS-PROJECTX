Imports System.Data.SqlClient

Public Class payroll_class
    Public basicpay As Double
    Public ssser As Double
    Public sssee As Double
    Public sssec As Double
    Public empid As String
    Public dtable As New DataTable
    Sub get_sss_cont()
        Try
            Dim cmd = New SqlCommand("select ER,EE,EC from tblSSS_cont_table where " & basicpay & " between salaryF and salaryT", conn)
            Dim dr As SqlDataReader
            checkConn()
            dr = cmd.ExecuteReader
                If dr.Read Then
                ssser = dr.Item(0) + dr.Item(2)
                sssee = dr.Item(1)
                End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub get_employees_info()
        checkConn()
        Dim cmd = New SqlCommand("select employeeID,lastname+', '+firstname+' '+middlename as Name,department,position,division,dateHired from tblEmployeesInfo where employeeID = '" & empid & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
End Class
