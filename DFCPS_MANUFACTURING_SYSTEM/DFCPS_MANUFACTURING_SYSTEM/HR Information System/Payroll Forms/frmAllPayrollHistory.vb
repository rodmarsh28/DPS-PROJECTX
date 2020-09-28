Public Class frmAllPayrollHistory
    Dim payrollMaxID As String
    Dim payrollRemarks As String
   
    Dim dateTo As String
    Sub deletePayroll()
        If MsgBox("Delete Payroll?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Try
                If conn.State = ConnectionState.Open Then
                    OleDBC.Dispose()
                    conn.Close()
                End If
                If conn.State <> ConnectionState.Open Then
                    ConnectDatabase()
                End If
                Dim c As Integer
                c = 0
                With OleDBC
                    .Connection = conn
                    .CommandText = "delete tblPayroll where payrollID ='" & dgw.CurrentRow.Cells(0).Value & "' " & _
                                    "delete tblBenefitsPaymentSum where payrollID ='" & dgw.CurrentRow.Cells(0).Value & "' " & _
                                    "delete tblPayrollofEmployees where payrollID ='" & dgw.CurrentRow.Cells(0).Value & "' "
                    .ExecuteNonQuery()
                End With
                MsgBox("Delete Success", MsgBoxStyle.Information, "Success")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub ShowAllPayrollHistory()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "select * from tblPayroll order by dateTo desc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = Format(OleDBDR.Item(2), "MM/dd/yyyy") & " - " & Format(OleDBDR.Item(3), "MM/dd/yyyy")
                    dgw.Item(2, c).Value = Format(OleDBDR.Item(6), "N")
                    dgw.Item(3, c).Value = Format(OleDBDR.Item(7), "N")
                    dgw.Item(4, c).Value = Format(OleDBDR.Item(8), "N")
                    dgw.Item(5, c).Value = OleDBDR.Item(9)
                    dgw.Item(6, c).Value = Format(OleDBDR.Item(2), "MMMM") & " " & Format(OleDBDR.Item(2), "dd") & " - " + Format(OleDBDR.Item(3), "dd") & " " & Format(OleDBDR.Item(3), "yyyy")
                    If CInt(Format(OleDBDR.Item(2), "dd")) >= 16 Then
                        dgw.Item(7, c).Value = "YES"
                    Else
                        dgw.Item(7, c).Value = "NO"
                    End If
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub findPayroll()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "select * from tblPayroll where dateFrom >= '" & dtpFrom.Value.ToString("MM/dd/yyyy") & "' and dateTo <= '" & _
                                dtpTo.Value.ToString("MM/dd/yyyy") & "' order by dateTo desc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = Format(OleDBDR.Item(2), "MM/dd/yyyy") & " - " & Format(OleDBDR.Item(3), "MM/dd/yyyy")
                    dgw.Item(2, c).Value = Format(OleDBDR.Item(6), "N")
                    dgw.Item(3, c).Value = Format(OleDBDR.Item(7), "N")
                    dgw.Item(4, c).Value = Format(OleDBDR.Item(8), "N")
                    dgw.Item(5, c).Value = OleDBDR.Item(9)
                    dgw.Item(6, c).Value = Format(OleDBDR.Item(2), "MMMM") & " " & Format(OleDBDR.Item(2), "dd") & " - " + Format(OleDBDR.Item(3), "dd") & " " & Format(OleDBDR.Item(3), "yyyy")
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub printPayroll()
        frmLoading.Show()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT payrollID,tblEmployeesInfo.employeeID,department,lastname,firstname,middlename,rate,payMethod,position,workingStatus,totalWorkedDays,absent,rhd,nwhd,regHolidays,NonWorkHolidays,leavePay,overtimeHRS," & _
                    "restdayReportHRS,lateUTMins,basicPay,regHolidayPay,nonWorkHolidayPay,leavePayCash,overtimePay,restdayReportAmount,lateUndertimeDed," & _
                    "cashAdvance,wHoldingTax,sssPrems,piPrems,phPrems,sssLoans,piLoans,ledgerBalance,Deduction,grossPay,Netpay FROM tblPayrollofEmployees " & _
                    "INNER JOIN tblEmployeesInfo ON tblPayrollofEmployees.employeeID = tblEmployeesInfo.employeeID" & _
                                " where payrollID = '" & dgw.CurrentRow.Cells(0).Value & "' order by lastname asc"
            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("datarange")
                .Columns.Add("date")
                .Columns.Add("payrollID")
                .Columns.Add("empID")
                .Columns.Add("department")
                .Columns.Add("name")
                .Columns.Add("rate")
                .Columns.Add("paymethod")
                .Columns.Add("position")
                .Columns.Add("status")
                .Columns.Add("twd")
                .Columns.Add("absent")
                .Columns.Add("rhd")
                .Columns.Add("nwhd")
                .Columns.Add("rh")
                .Columns.Add("nwh")
                .Columns.Add("lp")
                .Columns.Add("ot")
                .Columns.Add("rdr")
                .Columns.Add("late")
                .Columns.Add("bp")
                .Columns.Add("rhp")
                .Columns.Add("nwhp")
                .Columns.Add("lpc")
                .Columns.Add("otp")
                .Columns.Add("rdrp")
                .Columns.Add("latep")
                .Columns.Add("ca")
                .Columns.Add("tax")
                .Columns.Add("sss")
                .Columns.Add("pi")
                .Columns.Add("ph")
                .Columns.Add("sssl")
                .Columns.Add("pil")
                .Columns.Add("lb")
                .Columns.Add("ded")
                .Columns.Add("gp")
                .Columns.Add("netpay")
                .Columns.Add("preparedby")
                
                

            End With

            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dt.Rows.Add(UCase(dgw.CurrentRow.Cells(6).Value),
                                Format(Now, "MM/dd/yyyy"),
                                OleDBDR.Item(0),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2),
                                OleDBDR.Item(3) & ", " & OleDBDR.Item(4) & " " & OleDBDR.Item(5),
                                Format(OleDBDR.Item(6), "N"),
                                OleDBDR.Item(7),
                                OleDBDR.Item(8),
                                OleDBDR.Item(9),
                                Format(OleDBDR.Item(10), "N"),
                                Format(OleDBDR.Item(11), "N"),
                                Format(OleDBDR.Item(12), "N"),
                                Format(OleDBDR.Item(13), "N"),
                                Format(OleDBDR.Item(14), "N"),
                                Format(OleDBDR.Item(15), "N"),
                                Format(OleDBDR.Item(16), "N"),
                                Format(OleDBDR.Item(17), "N"),
                                Format(OleDBDR.Item(18), "N"),
                                Format(OleDBDR.Item(19), "N"),
                                Format(OleDBDR.Item(20), "N"),
                                Format(OleDBDR.Item(21), "N"),
                                Format(OleDBDR.Item(22), "N"),
                                Format(OleDBDR.Item(23), "N"),
                                Format(OleDBDR.Item(24), "N"),
                                Format(OleDBDR.Item(25), "N"),
                                Format(OleDBDR.Item(26), "N"),
                                Format(OleDBDR.Item(27), "N"),
                                Format(OleDBDR.Item(28), "N"),
                                Format(OleDBDR.Item(29), "N"),
                                Format(OleDBDR.Item(30), "N"),
                                Format(OleDBDR.Item(31), "N"),
                                Format(OleDBDR.Item(32), "N"),
                                Format(OleDBDR.Item(33), "N"),
                                Format(OleDBDR.Item(34), "N"),
                                Format(OleDBDR.Item(35), "N"),
                                Format(OleDBDR.Item(36), "N"),
                                Format(OleDBDR.Item(37), "N"),
                                HRISMain.lblUsername.Text)

                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New PayrollReport
            rptDoc.SetDataSource(dt)
            HRISReportViewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
            HRISReportViewer.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub printPayslip()
        frmLoading.Show()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer

            With OleDBC
                .Connection = conn
                .CommandText = "SELECT payrollID,tblEmployeesInfo.employeeID,lastname,firstname,middlename,position,rate,payMethod,dateHired,totalWorkedDays,absent,rhd,nwhd,regHolidays,NonWorkHolidays,leavePay,overtimeHRS," & _
                    "restdayReportHRS,lateUTMins,basicPay,regHolidayPay,nonWorkHolidayPay,leavePayCash,overtimePay,restdayReportAmount,lateUndertimeDed," & _
                    "cashAdvance,wHoldingTax,sssPrems,piPrems,phPrems,sssLoans,piLoans,ledgerBalance,Deduction,grossPay,Netpay FROM tblPayrollofEmployees " & _
                    "INNER JOIN tblEmployeesInfo ON tblPayrollofEmployees.employeeID = tblEmployeesInfo.employeeID" & _
                                " where payrollID = '" & dgw.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("datarange")
                .Columns.Add("date")
                .Columns.Add("payrollID")
                .Columns.Add("empID")
                .Columns.Add("name")
                .Columns.Add("pos")
                .Columns.Add("rate")
                .Columns.Add("paymethod")
                .Columns.Add("dateHired")
                .Columns.Add("twd")
                .Columns.Add("absent")
                .Columns.Add("rhd")
                .Columns.Add("nwhd")
                .Columns.Add("rh")
                .Columns.Add("nwh")
                .Columns.Add("lp")
                .Columns.Add("ot")
                .Columns.Add("rdr")
                .Columns.Add("late")
                .Columns.Add("bp")
                .Columns.Add("rhp")
                .Columns.Add("nwhp")
                .Columns.Add("lpc")
                .Columns.Add("otp")
                .Columns.Add("rdrp")
                .Columns.Add("latep")
                .Columns.Add("ca")
                .Columns.Add("tax")
                .Columns.Add("sss")
                .Columns.Add("pi")
                .Columns.Add("ph")
                .Columns.Add("sssl")
                .Columns.Add("pil")
                .Columns.Add("lb")
                .Columns.Add("ded")
                .Columns.Add("gp")
                .Columns.Add("netpay")
                .Columns.Add("preparedby")



            End With

            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    c = 0
                    While c < 2
                        dt.Rows.Add(UCase(dgw.CurrentRow.Cells(6).Value),
                            Format(Now, "MM/dd/yyyy"),
                                OleDBDR.Item(0),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2) & ", " & OleDBDR.Item(3) & " " & OleDBDR.Item(4),
                                OleDBDR.Item(5),
                                Format(OleDBDR.Item(6), "N"),
                                OleDBDR.Item(7),
                                Format(OleDBDR.Item(8), "MM/dd/yyyy"),
                                Format(OleDBDR.Item(9), "N"),
                                Format(OleDBDR.Item(10), "N"),
                                Format(OleDBDR.Item(11), "N"),
                                Format(OleDBDR.Item(12), "N"),
                                Format(OleDBDR.Item(13), "N"),
                                Format(OleDBDR.Item(14), "N"),
                                Format(OleDBDR.Item(15), "N"),
                                Format(OleDBDR.Item(16), "N"),
                                Format(OleDBDR.Item(17), "N"),
                                Format(OleDBDR.Item(18), "N"),
                                Format(OleDBDR.Item(19), "N"),
                                Format(OleDBDR.Item(20), "N"),
                                Format(OleDBDR.Item(21), "N"),
                                Format(OleDBDR.Item(22), "N"),
                                Format(OleDBDR.Item(23), "N"),
                                Format(OleDBDR.Item(24), "N"),
                                Format(OleDBDR.Item(25), "N"),
                                Format(OleDBDR.Item(26), "N"),
                                Format(OleDBDR.Item(27), "N"),
                                Format(OleDBDR.Item(28), "N"),
                                Format(OleDBDR.Item(29), "N"),
                                Format(OleDBDR.Item(30), "N"),
                                Format(OleDBDR.Item(31), "N"),
                                Format(OleDBDR.Item(32), "N"),
                                Format(OleDBDR.Item(33), "N"),
                                Format(OleDBDR.Item(34), "N"),
                                Format(OleDBDR.Item(35), "N"),
                                Format(OleDBDR.Item(36), "N"),
                                HRISMain.lblUsername.Text)
                        c = c + 1
                    End While
                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New Payslip
            rptDoc.SetDataSource(dt)
            HRISReportViewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
            HRISReportViewer.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub updatePayroll()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblPayrollofEmployees.payrollID,dbo.tblPayroll.dateFrom,dbo.tblPayroll.dateTo,dbo.tblPayroll.totalEmployees," & _
                    "dbo.tblPayroll.totalOvertime,dbo.tblPayroll.totalGrossPay,dbo.tblPayroll.totalDeduction,dbo.tblPayroll.totalNetpay," & _
                    "dbo.tblPayrollofEmployees.employeeID,dbo.tblEmployeesInfo.lastname,dbo.tblEmployeesInfo.firstname,dbo.tblEmployeesInfo.middlename," & _
                    "dbo.tblPayrollofEmployees.totalWorkedDays,dbo.tblPayrollofEmployees.absent,dbo.tblPayrollofEmployees.rhd,dbo.tblPayrollofEmployees.nwhd," & _
                    "dbo.tblPayrollofEmployees.regHolidays, " & _
                    "dbo.tblPayrollofEmployees.NonWorkHolidays,dbo.tblPayrollofEmployees.leavePay,dbo.tblPayrollofEmployees.overtimeHRS," & _
                    "dbo.tblPayrollofEmployees.restdayReportHRS,dbo.tblPayrollofEmployees.lateUTMins,dbo.tblPayrollofEmployees.basicPay," & _
                    "dbo.tblPayrollofEmployees.regHolidayPay,dbo.tblPayrollofEmployees.nonWorkHolidayPay,dbo.tblPayrollofEmployees.leavePayCash," & _
                    "dbo.tblPayrollofEmployees.overtimePay,dbo.tblPayrollofEmployees.restdayReportAmount,dbo.tblPayrollofEmployees.lateUndertimeDed," & _
                    "dbo.tblPayrollofEmployees.cashAdvance,dbo.tblPayrollofEmployees.wHoldingTax,dbo.tblPayrollofEmployees.sssPrems,dbo.tblPayrollofEmployees.piPrems," & _
                    "dbo.tblPayrollofEmployees.phPrems,dbo.tblPayrollofEmployees.sssLoans,dbo.tblPayrollofEmployees.piLoans,dbo.tblPayrollofEmployees.ledgerBalance," & _
                    "dbo.tblPayrollofEmployees.grossPay,dbo.tblPayrollofEmployees.Deduction,dbo.tblPayrollofEmployees.Netpay, tblBenefitsPaymentSum.erSSS, " & _
                    "tblBenefitsPaymentSum.erPI,tblBenefitsPaymentSum.erPH FROM dbo.tblPayrollofEmployees " & _
                    "INNER JOIN dbo.tblPayroll ON dbo.tblPayrollofEmployees.payrollID = dbo.tblPayroll.payrollID " & _
                    "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblPayrollofEmployees.employeeID = dbo.tblEmployeesInfo.employeeID " & _
                    "INNER JOIN dbo.tblBenefitsPaymentSum ON dbo.tblPayrollofEmployees.empPayrollTransNo = dbo.tblBenefitsPaymentSum.empPayrollTransNo " & _
                    "where dbo.tblPayrollofEmployees.payrollID = '" & dgw.CurrentRow.Cells(0).Value & "'"


            End With
            OleDBDR = OleDBC.ExecuteReader
            frmPayroll.dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    frmPayroll.lblPRID.Text = OleDBDR.Item(0)
                    frmPayroll.dtrFrom.Value = OleDBDR.Item(1)
                    frmPayroll.dtrTo.Value = OleDBDR.Item(2)
                    frmPayroll.lblTotEmp.Text = OleDBDR.Item(3)

                    frmPayroll.totalOT = Format(OleDBDR.Item(4), "N")
                    frmPayroll.totalGrossPay = Format(OleDBDR.Item(5), "N")
                    frmPayroll.totalDeductions = Format(OleDBDR.Item(6), "N")
                    frmPayroll.totalNetpay = Format(OleDBDR.Item(7), "N")

                    frmPayroll.lblTotOT.Text = frmPayroll.totalOT
                    frmPayroll.lblTotGP.Text = frmPayroll.totalGrossPay
                    frmPayroll.lblTotDed.Text = frmPayroll.totalDeductions
                    frmPayroll.lblTotNet.Text = frmPayroll.totalNetpay
                    
                    frmPayroll.dgw.Rows.Add()
                    frmPayroll.dgw.Item(0, c).Value = OleDBDR.Item(8)
                    frmPayroll.dgw.Item(1, c).Value = OleDBDR.Item(9) & ", " & OleDBDR.Item(10) & " " & OleDBDR.Item(11) & "."
                    frmPayroll.dgw.Item(2, c).Value = Format(OleDBDR.Item(12), "0.0")
                    frmPayroll.dgw.Item(3, c).Value = Format(OleDBDR.Item(13), "0.0")
                    frmPayroll.dgw.Item(4, c).Value = Format(OleDBDR.Item(14), "0.0")
                    frmPayroll.dgw.Item(5, c).Value = Format(OleDBDR.Item(15), "0.0")
                    frmPayroll.dgw.Item(6, c).Value = Format(OleDBDR.Item(16), "0.0")
                    frmPayroll.dgw.Item(7, c).Value = Format(OleDBDR.Item(17), "0.0")
                    frmPayroll.dgw.Item(8, c).Value = Format(OleDBDR.Item(18), "0.0")
                    frmPayroll.dgw.Item(9, c).Value = Format(OleDBDR.Item(19), "0.0")
                    frmPayroll.dgw.Item(10, c).Value = Format(OleDBDR.Item(20), "0.0")
                    frmPayroll.dgw.Item(11, c).Value = Format(OleDBDR.Item(21), "0.0")
                    frmPayroll.dgw.Item(12, c).Value = Format(OleDBDR.Item(22), "N")
                    frmPayroll.dgw.Item(13, c).Value = Format(OleDBDR.Item(23), "N")
                    frmPayroll.dgw.Item(14, c).Value = Format(OleDBDR.Item(24), "N")
                    frmPayroll.dgw.Item(15, c).Value = Format(OleDBDR.Item(25), "N")
                    frmPayroll.dgw.Item(16, c).Value = Format(OleDBDR.Item(26), "N")
                    frmPayroll.dgw.Item(17, c).Value = Format(OleDBDR.Item(27), "N")
                    frmPayroll.dgw.Item(18, c).Value = Format(OleDBDR.Item(28), "N")
                    frmPayroll.dgw.Item(19, c).Value = Format(OleDBDR.Item(29), "N")
                    frmPayroll.dgw.Item(20, c).Value = Format(OleDBDR.Item(30), "N")
                    frmPayroll.dgw.Item(21, c).Value = Format(OleDBDR.Item(31), "N")
                    frmPayroll.dgw.Item(22, c).Value = Format(OleDBDR.Item(32), "N")
                    frmPayroll.dgw.Item(23, c).Value = Format(OleDBDR.Item(33), "N")
                    frmPayroll.dgw.Item(24, c).Value = Format(OleDBDR.Item(34), "N")
                    frmPayroll.dgw.Item(25, c).Value = Format(OleDBDR.Item(35), "N")
                    frmPayroll.dgw.Item(26, c).Value = Format(OleDBDR.Item(36), "N")
                    frmPayroll.dgw.Item(27, c).Value = Format(OleDBDR.Item(37), "N")
                    frmPayroll.dgw.Item(28, c).Value = Format(OleDBDR.Item(38), "N")
                    frmPayroll.dgw.Item(29, c).Value = Format(OleDBDR.Item(39), "N")
                    frmPayroll.dgw.Item(30, c).Value = Format(OleDBDR.Item(40), "N")
                    frmPayroll.dgw.Item(31, c).Value = Format(OleDBDR.Item(41), "N")
                    frmPayroll.dgw.Item(32, c).Value = Format(OleDBDR.Item(42), "N")
                    c = c + 1
                End While
                frmPayroll.dgw.ClearSelection()
                frmEmployeeName.searchExisting()
                frmEmployeeName.showEmployee()
                frmPayroll.countsunday()
                frmPayroll.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub frmAllPayrollHistory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            dgw.ClearSelection()
        End If
    End Sub
    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgw.ContextMenuStrip = ContextMenuStrip2
    End Sub
    Private Sub PrintPayrollToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPayrollToolStripMenuItem.Click
        printPayroll()
    End Sub

    Private Sub PrintPayslipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPayslipToolStripMenuItem.Click
        printPayslip()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        findPayroll()
    End Sub
    Private Sub CancelPayrollToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelPayrollToolStripMenuItem.Click
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "select max(payrollID) from tblPayroll"

            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                If OleDBDR.Read Then
                    payrollMaxID = OleDBDR.Item(0)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If payrollMaxID = dgw.CurrentRow.Cells(0).Value Then
            deletePayroll()
            ShowAllPayrollHistory()
        Else
            MsgBox("you cannot delete this payroll", MsgBoxStyle.Critical, "error")
        End If
    End Sub
    Private Sub frmAllPayrollHistory_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowAllPayrollHistory()
    End Sub
    Sub selectIfWeekly()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "select remarks from tblPayroll where payrollID = '" & dgw.CurrentRow.Cells(0).Value & "'"

            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                If OleDBDR.Read Then
                    payrollRemarks = OleDBDR.Item(0)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub dgw_CellMouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgw.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgw.CurrentCell = dgw(e.ColumnIndex, e.RowIndex)
                dgw.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub

    Private Sub UpdatePayrollToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdatePayrollToolStripMenuItem.Click
        'Dim str As String = dgw.CurrentRow.Cells(0).Value
        'dateTo = str.Substring(str.Length - 7)
        'If dateTo = "30" Or dateTo = "31" Or dateTo = "29" Or dateTo = "28" Or dateTo = "27" Then
        If dgw.CurrentRow.Cells(7).Value = "YES" Then
            frmDateGenerator.isLastDay = True
        Else
            frmDateGenerator.isLastDay = False
        End If
        selectIfWeekly()
        'If payrollRemarks = "Labor" Then

        payrollMode = "Update"

        updatePayroll()
        'Else
        'MsgBox("You cant Update this payroll", MsgBoxStyle.Critical, "Error")
        'End If

    End Sub
End Class