Imports System.Data.SqlClient

Public Class HRIS_class
    Public sssPayAcc As String
    Public piPayAcc As String
    Public phPayAcc As String
    Public taxAcc As String
    Public indirectAcc As String
    Public directAcc As String

    Public Function get_labor_cost(ByVal empid, ByVal rHours, ByVal latemin, ByVal otHours, ByVal rdrHours, ByVal rhHours, ByVal nwhHours) As Tuple(Of Decimal, Decimal)
        Dim direct As Decimal = 0
        Dim indirect As Decimal = 0
        Try
            Dim dt As New DataTable
            Dim rate As Decimal
            Dim salaryType As String
            Dim dayFactor As Integer
            checkConn()
            Dim cmd As New SqlCommand("select rate,payMethod,grade from tblEmployeesInfo where empID = '" & empid & "'", conn)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            rate = dt.Rows(0).Item(0)
            salaryType = dt.Rows(0).Item(1)
            salaryType = dt.Rows(0).Item(2)
            If salaryType = "Daily" Then
                direct += (rate / 8) * rhHours
                direct += ((rate / 8) * otHours) * 1 'overhead accnt .25'
                indirect += ((rate / 8) * otHours) * 0.25
                direct += ((rate / 8) * rdrHours) * 1
                indirect += ((rate / 8) * rdrHours) * 0.3
                direct += ((rate / 8) * rhHours) + rate
                direct += ((rate / 8) * nwhHours) * 1
                indirect += ((rate / 8) * nwhHours) * 0.3
                direct -= ((rate / 8 / 60) * latemin)
            ElseIf salaryType = "Monthly" Then
                direct += (rate / dayFactor / 8) * rhHours
                direct += ((rate / dayFactor / 8) * otHours) * 1
                indirect += ((rate / dayFactor / 8) * otHours) * 0.25
                direct += ((rate / dayFactor / 8) * rdrHours) * 1
                indirect += ((rate / dayFactor / 8) * rdrHours) * 0.3
                direct += ((rate / dayFactor / 8) * rhHours) + (rate / dayFactor)
                direct += ((rate / dayFactor / 8) * nwhHours) * 1
                indirect += ((rate / dayFactor / 8) * nwhHours) * 0.3
                direct -= ((rate / dayFactor / 8 / 60) * latemin)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tuple.Create(indirect, direct)
    End Function
    Function get_dept_acc(ByVal deptID As String) As HRIS_class
        Dim dt As New DataTable
        Dim dptacc = New HRIS_class()
        checkConn()
        Dim cmd As New SqlCommand("select * from tblDepartmentProfile where departmentNo = '" & deptID & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        dptacc.sssPayAcc = dt.Rows(0).Item("sssAccount")
        dptacc.sssPayAcc = dt.Rows(0).Item("hdmfAccount")
        dptacc.sssPayAcc = dt.Rows(0).Item("phAccount")
        dptacc.sssPayAcc = dt.Rows(0).Item("taxAccount")
        dptacc.sssPayAcc = dt.Rows(0).Item("costBenefitsAccount")
        dptacc.sssPayAcc = dt.Rows(0).Item("costAccount")
        Return dptacc
    End Function
End Class
