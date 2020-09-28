Public Class frmPrintPremsPaymentSum
    Public MODE As String
    Sub printPremsSum()
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
                .CommandText = "SELECT dbo.tblPayrollofEmployees.employeeID,department,dbo.tblEmployeesInfo.lastname,dbo.tblEmployeesInfo.firstname," & _
                    "dbo.tblEmployeesInfo.middlename,dbo.tblEmployeesInfo.sssNo,dbo.tblEmployeesInfo.piNo,dbo.tblEmployeesInfo.phNo," & _
                    "sum(dbo.tblPayrollofEmployees.sssPrems),sum(dbo.tblBenefitsPaymentSum.erSSS),sum(dbo.tblPayrollofEmployees.piPrems)," & _
                    "sum(dbo.tblBenefitsPaymentSum.erPI),sum(dbo.tblPayrollofEmployees.phPrems),sum(dbo.tblBenefitsPaymentSum.erPH)," & _
                    "SUM(dbo.tblPayrollofEmployees.basicPay) " & _
                    "FROM dbo.tblPayrollofEmployees INNER JOIN dbo.tblEmployeesInfo ON dbo.tblPayrollofEmployees.employeeID = dbo.tblEmployeesInfo.employeeID " & _
                    "INNER JOIN dbo.tblBenefitsPaymentSum ON dbo.tblPayrollofEmployees.empPayrollTransNo = dbo.tblBenefitsPaymentSum.empPayrollTransNo " & _
                    "INNER JOIN dbo.tblPayroll ON dbo.tblPayroll.payrollID = dbo.tblPayrollofEmployees.payrollID " & _
                    "WHERE cast(datename(MM,dbo.tblPayroll.dateFrom) as varchar)+' ' + cast(datepart(YY,dbo.tblPayroll.dateFrom) as varchar)  = '" & dgw.CurrentRow.Cells(1).Value & "' " & _
                    "GROUP BY dbo.tblPayrollofEmployees.employeeID,department,dbo.tblEmployeesInfo.lastname,dbo.tblEmployeesInfo.firstname,dbo.tblEmployeesInfo.middlename," & _
                    "dbo.tblEmployeesInfo.sssNo,dbo.tblEmployeesInfo.piNo,dbo.tblEmployeesInfo.phNo " & _
                    "ORDER BY dbo.tblEmployeesInfo.lastname ASC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("dateofprems")
                .Columns.Add("employeeID")
                .Columns.Add("department")
                .Columns.Add("name")
                .Columns.Add("sssNo")
                .Columns.Add("piNo")
                .Columns.Add("phNo")
                .Columns.Add("sssee")
                .Columns.Add("ssser")
                .Columns.Add("totalsss")
                .Columns.Add("piee")
                .Columns.Add("pier")
                .Columns.Add("totalpi")
                .Columns.Add("phee")
                .Columns.Add("pher")
                .Columns.Add("totalph")
                .Columns.Add("preparedby")
                .Columns.Add("grosspay")

            End With

            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dt.Rows.Add(UCase(dgw.CurrentRow.Cells(1).Value),
                                OleDBDR.Item(0),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2) & ", " & OleDBDR.Item(3) & " " & OleDBDR.Item(4),
                                OleDBDR.Item(5),
                                OleDBDR.Item(6),
                                OleDBDR.Item(7),
                                Format(OleDBDR.Item(8), "N"),
                                Format(OleDBDR.Item(9), "N"),
                                Format(OleDBDR.Item(8) + OleDBDR.Item(9), "N"),
                                Format(OleDBDR.Item(10), "N"),
                                Format(OleDBDR.Item(11), "N"),
                                Format(OleDBDR.Item(10) + OleDBDR.Item(11), "N"),
                                Format(OleDBDR.Item(12), "N"),
                                Format(OleDBDR.Item(13), "N"),
                                Format(OleDBDR.Item(12) + OleDBDR.Item(13), "N"),
                                HRISMain.lblUsername.Text,
                                Format(OleDBDR.Item(14), "N"))
                End While
                'dt.Rows.Add(UCase(dgw.CurrentRow.Cells(1).Value),
                '                "",
                '                "CACHUELA, NEIL P",
                '                "0915195822",
                '                "102001715646",
                '                "160500417312",
                '                Format(581.3, "N"),
                '                Format(1208.7, "N"),
                '                Format(581.3 + 1208.7, "N"),
                '                Format(100, "N"),
                '                Format(100, "N"),
                '                Format(100 + 100, "N"),
                '                Format(550, "N"),
                '                Format(550, "N"),
                '                Format(1100, "N"),
                '                frmMain.lblUsername.Text,
                '                Format(60000, "N"))
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New premsSummary
            rptDoc.SetDataSource(dt)
            HRISReportViewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
            HRISReportViewer.ShowDialog()
            'rptDoc.PrintToPrinter(1, False, 0, 0)
            'rptDoc.PrintOptions.PrinterName = My.Settings.printerName
            printPremsSums()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MsgBox("Report Successfully Printed !", MsgBoxStyle.Information)
        End Try
    End Sub
    Sub printPremsSums()
        'frmLoading.Show()
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
                .CommandText = "SELECT dbo.tblPayrollofEmployees.employeeID,department,dbo.tblEmployeesInfo.lastname,dbo.tblEmployeesInfo.firstname,dbo.tblEmployeesInfo.middlename,dbo.tblEmployeesInfo.rate,dbo.tblEmployeesInfo.payMethod,dbo.tblEmployeesInfo.sssNo,dbo.tblEmployeesInfo.piNo,dbo.tblEmployeesInfo.phNo,sum(dbo.tblPayrollofEmployees.sssPrems),sum(dbo.tblBenefitsPaymentSum.erSSS),sum(dbo.tblPayrollofEmployees.piPrems),sum(dbo.tblBenefitsPaymentSum.erPI),sum(dbo.tblPayrollofEmployees.phPrems),sum(dbo.tblBenefitsPaymentSum.erPH),sum(dbo.tblPayrollofEmployees.basicpay) FROM dbo.tblPayrollofEmployees INNER JOIN dbo.tblEmployeesInfo ON dbo.tblPayrollofEmployees.employeeID = " & _
                    "dbo.tblEmployeesInfo.employeeID INNER JOIN dbo.tblBenefitsPaymentSum ON dbo.tblPayrollofEmployees.empPayrollTransNo = " & _
                    "dbo.tblBenefitsPaymentSum.empPayrollTransNo INNER JOIN dbo.tblPayroll ON dbo.tblPayroll.payrollID = dbo.tblPayrollofEmployees.payrollID " & _
                    "WHERE cast(datename(MM,dbo.tblPayroll.dateFrom) as varchar)+' ' + cast(datepart(YY,dbo.tblPayroll.dateFrom) as varchar)  = '" & dgw.CurrentRow.Cells(1).Value & "' " & _
                    "group by dbo.tblPayrollofEmployees.employeeID,department,dbo.tblEmployeesInfo.lastname,dbo.tblEmployeesInfo.firstname,dbo.tblEmployeesInfo.middlename," & _
                    "dbo.tblEmployeesInfo.rate,dbo.tblEmployeesInfo.payMethod,dbo.tblEmployeesInfo.sssNo,dbo.tblEmployeesInfo.piNo,dbo.tblEmployeesInfo.phNo,month(dbo.tblPayroll.dateTo) " & _
                    "ORDER BY tblEmployeesInfo.lastname"

            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("dateofprems")
                .Columns.Add("employeeID")
                .Columns.Add("department")
                .Columns.Add("name")
                .Columns.Add("rate")
                .Columns.Add("sssNo")
                .Columns.Add("piNo")
                .Columns.Add("phNo")
                .Columns.Add("sssee")
                .Columns.Add("ssser")
                .Columns.Add("totalssswoec")
                .Columns.Add("ec")
                .Columns.Add("totalsss")
                .Columns.Add("piee")
                .Columns.Add("pier")
                .Columns.Add("totalpi")
                .Columns.Add("phee")
                .Columns.Add("pher")
                .Columns.Add("totalph")
                .Columns.Add("preparedby")
                .Columns.Add("grosspay")

            End With

            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    Dim rate As Double
                    Dim ec As Double
                    If OleDBDR.Item(6) = "Daily" Then
                        rate = OleDBDR.Item(16)
                    Else
                        rate = OleDBDR.Item(16)
                    End If
                    If rate <= 14750 Then
                        ec = 10.0
                    ElseIf rate > 14750 Then
                        ec = 30.0
                    End If
                    dt.Rows.Add(dgw.CurrentRow.Cells(1).Value,
                                OleDBDR.Item(0),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2) & ", " & OleDBDR.Item(3) & " " & OleDBDR.Item(4),
                                Format(rate, "N"),
                                OleDBDR.Item(7),
                                OleDBDR.Item(8),
                                OleDBDR.Item(9),
                                Format(OleDBDR.Item(10), "N"),
                                Format(OleDBDR.Item(11) - ec, "N"),
                                Format(OleDBDR.Item(10) + OleDBDR.Item(11) - ec, "N"),
                                Format(ec, "N"),
                                Format(OleDBDR.Item(10) + OleDBDR.Item(11), "N"),
                                Format(OleDBDR.Item(12), "N"),
                                Format(OleDBDR.Item(13), "N"),
                                Format(OleDBDR.Item(12) + OleDBDR.Item(13), "N"),
                                Format(OleDBDR.Item(14), "N"),
                                Format(OleDBDR.Item(15), "N"),
                                Format(OleDBDR.Item(14) + OleDBDR.Item(15), "N"),
                                HRISMain.lblUsername.Text,
                                Format(OleDBDR.Item(16), "N"))
                End While
                'dt.Rows.Add(dgw.CurrentRow.Cells(1).Value,
                '              "",
                '              "CACHUELA, NEIL P. ",
                '              Format(60000, "N"),
                '              "0915195822",
                '              "102001715646",
                '              "160500417312",
                '              Format(581.3, "N"),
                '              Format(1208.7 - 30, "N"),
                '              Format(581.3 + 1208.7 - 30, "N"),
                '              Format(30, "N"),
                '              Format(581.3 + 1208.7, "N"),
                '              Format(100, "N"),
                '              Format(100, "N"),
                '              Format(100 + 100, "N"),
                '              Format(550, "N"),
                '              Format(550, "N"),
                '              Format(1100, "N"),
                '              frmMain.lblUsername.Text,
                '              Format(60000, "N"))
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New premsReport
            rptDoc.SetDataSource(dt)
            HRISReportViewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
            HRISReportViewer.ShowDialog()
            'rptDoc.PrintToPrinter(1, False, 0, 0)
            'rptDoc.PrintOptions.PrinterName = My.Settings.printerName
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub getsssMonthLoans()
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
                .CommandText = "select DISTINCT '',DATENAME(month, dateto) AS MONTHS, YEAR(dateTo) AS YEARS,month(dateto) AS MONTHNUMERIC " & _
                                "from tblPayroll " & _
                                "inner join tblpayrollofemployees on tblpayrollofemployees.payrollid = tblpayroll.payrollid " & _
                                "where  sssLoans <> 0 " & _
                                "ORDER BY YEARS,MONTHNUMERIC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1) & "  " & OleDBDR.Item(2)
                    dgw.Item(2, c).Value = OleDBDR.Item(3)
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub getpiMonthLoans()
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
                .CommandText = "select DISTINCT '',DATENAME(month, dateto) AS MONTHS, YEAR(dateTo) AS YEARS,month(dateto) AS MONTHNUMERIC " & _
                                "from tblPayroll " & _
                                "inner join tblpayrollofemployees on tblpayrollofemployees.payrollid = tblpayroll.payrollid " & _
                                "where piLoans <> 0 " & _
                                "ORDER BY YEARS,MONTHNUMERIC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1) & "  " & OleDBDR.Item(2)
                    dgw.Item(2, c).Value = OleDBDR.Item(3)
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub getMonthPrems()
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
                .CommandText = "select DISTINCT '',DATENAME(month, dateto) AS MONTHS, YEAR(dateTo) AS YEARS,month(dateto) AS MONTHNUMERIC " & _
                                "from tblPayroll " & _
                                "where datefrom like '%16%'   " & _
                                "ORDER BY YEARS,MONTHNUMERIC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1) & " " & OleDBDR.Item(2)
                    dgw.Item(2, c).Value = OleDBDR.Item(3)
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub getMonthWH()
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
                .CommandText = "SELECT DISTINCT cast(datename(MM,dbo.tblPayroll.dateFrom) as varchar)+' ' + cast(datepart(YY,dbo.tblPayroll.dateFrom) as varchar) AS MONTHS " & _
                            "FROM dbo.tblPayroll " & _
                            "INNER JOIN dbo.tblPayrollofEmployees ON dbo.tblPayroll.payrollID = dbo.tblPayrollofEmployees.payrollID " & _
                            "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.employeeID = dbo.tblPayrollofEmployees.employeeID " & _
                            "WHERE tblPayrollofEmployees.wHoldingTax <> '' "

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(1, c).Value = OleDBDR.Item(0)
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmPrintPremsPaymentSum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If MODE = "PREMIUMS" Then
            getMonthPrems()
        ElseIf MODE = "WITHHOLDING" Then
            getMonthWH()
        ElseIf MODE = "PI LOANS" Then
            getpiMonthLoans()
        ElseIf MODE = "SSS LOANS" Then
            getsssMonthLoans()
        End If
    End Sub

    Sub printWHTax()
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
                .CommandText = "SELECT cast(datename(MM,dbo.tblPayroll.dateFrom) as varchar)+' ' + cast(datepart(YY,dbo.tblPayroll.dateFrom) as varchar) AS MONTHS, " & _
                        "dbo.tblEmployeesInfo.employeeID as ID, " & _
                        "dbo.tblEmployeesInfo.lastname + ', ' + dbo.tblEmployeesInfo.firstname + dbo.tblEmployeesInfo.middlename AS NAME, " & _
                        "SUM(dbo.tblPayrollofEmployees.grossPay) - (SUM(dbo.tblPayrollofEmployees.sssPrems)+SUM(dbo.tblPayrollofEmployees.piPrems)+SUM(dbo.tblPayrollofEmployees.phPrems)) AS BP, " & _
                        "SUM(dbo.tblPayrollofEmployees.wHoldingTax) AS WH, " & _
                        "SUM(dbo.tblPayrollofEmployees.grossPay) - (SUM(dbo.tblPayrollofEmployees.sssPrems)+SUM(dbo.tblPayrollofEmployees.piPrems)+SUM(dbo.tblPayrollofEmployees.phPrems))  -  " & _
                        "SUM(dbo.tblPayrollofEmployees.wHoldingTax) as total " & _
                         "FROM dbo.tblPayroll " & _
                        "INNER JOIN dbo.tblPayrollofEmployees ON dbo.tblPayroll.payrollID = dbo.tblPayrollofEmployees.payrollID " & _
                        "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.employeeID = dbo.tblPayrollofEmployees.employeeID " & _
                        " WHERE cast(datename(MM,dbo.tblPayroll.dateFrom) as varchar)+' ' + cast(datepart(YY,dbo.tblPayroll.dateFrom) as varchar)  = '" & dgw.CurrentRow.Cells(1).Value & "' " & _
                        " and dbo.tblPayrollofEmployees.wHoldingTax <> 0 " & _
                        "GROUP BY dbo.tblEmployeesInfo.employeeID, " & _
                        "cast(datename(MM,dbo.tblPayroll.dateFrom) as varchar)+' ' + cast(datepart(YY,dbo.tblPayroll.dateFrom) as varchar),dbo.tblEmployeesInfo.lastname " & _
                        "+ ', ' + dbo.tblEmployeesInfo.firstname + dbo.tblEmployeesInfo.middlename "

            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("dateofprems")
                .Columns.Add("employeeID")
                .Columns.Add("name")
                .Columns.Add("BP")
                .Columns.Add("WH")
                .Columns.Add("NET")
            End With

            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dt.Rows.Add(UCase(dgw.CurrentRow.Cells(1).Value),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2),
                                Format(OleDBDR.Item(3), "N"),
                                Format(OleDBDR.Item(4), "N"),
                                Format(OleDBDR.Item(5), "N"))
                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New WitholdingTaxSummaryReport
            rptDoc.SetDataSource(dt)
            HRISReportViewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
            HRISReportViewer.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub dgw_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgw.CellMouseDoubleClick
        If MODE = "PREMIUMS" Then
            printPremsSum()
        ElseIf MODE = "WITHHOLDING" Then
            printWHTax()
        ElseIf MODE = "PI LOANS" Then
            frmLoading.Show()
            Dim DC As New deduction_class
            DC.monthNo = dgw.CurrentRow.Cells(2).Value
            DC.monthName = dgw.CurrentRow.Cells(1).Value
            DC.print_piLoan_summary()
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New piLoansPayment
            rptDoc.SetDataSource(DC.dts)
            HRISReportViewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
            HRISReportViewer.ShowDialog()
        ElseIf MODE = "SSS LOANS" Then
            frmLoading.Show()
            Dim DC As New deduction_class
            DC.monthNo = dgw.CurrentRow.Cells(2).Value
            DC.monthName = dgw.CurrentRow.Cells(1).Value
            DC.print_sssLoan_summary()
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New sssLoansPayment
            rptDoc.SetDataSource(DC.dts)
            HRISReportViewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
            HRISReportViewer.ShowDialog()
        End If
    End Sub

    Private Sub dgw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub
End Class