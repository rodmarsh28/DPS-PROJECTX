Imports System.Data.SqlClient

Public Class frmSalesHistoryViewer
    Dim checkNo As String
    Dim amountPaid As String
    Public lblmode As String
    Dim PAYNO As String
    Dim postChequeDate As DateTime
    Private Sub frmSalesHistoryViewer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmSalesHistoryViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSalesHistory()
    End Sub
    Sub generatePAYNo()
        Dim StrID As String
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT * from tblPaid where PAYNO like '" & Format(Now, "yyyy") & "%' order by PAYNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 6, Len(OleDBDR(0)))
                PAYNO = Format(Now, "yyyy") & "-" & Format(Val(StrID) + 1, "00000")

            Else
                PAYNO = Format(Now, "yyyy") & "-" & "00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    
    Sub loadSalesHistory()
        Dim c As Integer = 0
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblSales.SALESDATE, " & _
                "dbo.tblSales.SALESNO AS SLSNO, " & _
                "dbo.tblSales.CUSTOMERNAME, " & _
                "dbo.tblSales.TOTALAMOUNT, " & _
                "CASE " & _
                "WHEN PAYSTATUS = 'CANCELLED' THEN " & _
                "'CANCELLED' " & _
                "WHEN PAYTYPE = 'CHEQUE (POSTDATE)' AND PAYSTATUS = 'NOT PAID' THEN " & _
                "'NOT PAID' " & _
                 "ELSE ( CASE WHEN TOTALAMOUNT <= SUM ( dbo.tblPaid.AMOUNTPAID ) THEN 'PAID' ELSE 'NOT PAID' END ) " & _
                 "END AS STATUS , " & _
                   "ISNULL(dbo.tblPaid.PAYTYPE,'NO PAYMENT'), " & _
                 "ISNULL(dbo.tblPaid.POSTCHEQUEDATE,'0001-01-01 12:00:00.0000000') " & _
                "FROM " & _
                "dbo.tblSales " & _
                "FULL OUTER JOIN dbo.tblPaid ON dbo.tblSales.SALESNO = dbo.tblPaid.SALESNO " & _
                "GROUP by  " & _
               "dbo.tblSales.SALESDATE, " & _
                "dbo.tblSales.SALESNO, " & _
                "dbo.tblSales.TOTALAMOUNT, " & _
                "dbo.tblSales.CUSTOMERNAME, " & _
                "dbo.tblSales.PAYSTATUS, " & _
                "dbo.tblPaid.PAYTYPE, " & _
                "dbo.tblPaid.POSTCHEQUEDATE " & _
                "order by salesdate desc"
            End With
            OleDBDR = OleDBC.ExecuteReader
            dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = Format(OleDBDR.Item(0), "MM/dd/yy hh:mm tt")
                    dgv.Item(1, c).Value = OleDBDR.Item(1)
                    dgv.Item(2, c).Value = OleDBDR.Item(2)
                    dgv.Item(3, c).Value = CDec(OleDBDR.Item(3)).ToString("N")
                    dgv.Item(4, c).Value = OleDBDR.Item(4)
                    dgv.Item(5, c).Value = Format(OleDBDR.Item(5), "dd/MM/yyyy")
                    c = c + 1
                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub loadPaymentHistory()
        Dim c As Integer = 0
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblPaid.PAYNO, " & _
                "dbo.tblPaid.PAYDATE, " & _
                "dbo.tblPaid.AMOUNTPAID " & _
                "FROM dbo.tblPaid " & _
                " where SALESNO = '" & dgv.CurrentRow.Cells(1).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            frmPaymentList.dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    frmPaymentList.dgv.Rows.Add()
                    frmPaymentList.dgv.Item(0, c).Value = OleDBDR.Item(0)
                    frmPaymentList.dgv.Item(1, c).Value = Format(OleDBDR.Item(1), "MM/dd/yy hh:mm tt")
                    frmPaymentList.dgv.Item(2, c).Value = OleDBDR.Item(2)
                    c = c + 1
                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub printAcknowledgementReceipt()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblSales.SALESNO, " & _
                "dbo.tblPaid.PAYDATE, " & _
                "dbo.tblSales.CUSTOMERNAME, " & _
                "dbo.tblSales.TOTALAMOUNT, " & _
                "dbo.tblSales.RECEIVEDBY, " & _
                "dbo.tblSalesTR.WIDTH, " & _
                "dbo.tblSalesTR.LENGTH, " & _
                "dbo.tblSalesTR.COLOR, " & _
                "dbo.tblSalesTR.SEWNTYPE, " & _
                "dbo.tblSalesTR.PRINTED, " & _
                "dbo.tblSalesTR.QTY, " & _
                "dbo.tblSalesTR.UPRICE, " & _
                "dbo.tblSalesTR.AMOUNT, " & _
                 "dbo.tblPaid.PAYNO, " & _
                "dbo.tblPaid.PAYTYPE, " & _
                "dbo.tblPaid.CHEQUENO, " & _
                "dbo.tblPaid.AMOUNTPAID " & _
                "FROM dbo.tblSales " & _
                "INNER JOIN dbo.tblSalesTR ON dbo.tblSales.SALESNO = dbo.tblSalesTR.SALESNO " & _
                "INNER JOIN dbo.tblPaid ON dbo.tblSales.SALESNO = dbo.tblPaid.SALESNO " & _
                "WHERE tblPaid.payno = '" & PAYNO & "'"

            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("SALESNO")
                .Columns.Add("PAYNO")
                .Columns.Add("DATE")
                .Columns.Add("CUSTOMER")
                .Columns.Add("AMOUNTINWORDS")
                .Columns.Add("TOTAMOUNT")
                .Columns.Add("PAYTYPE")
                .Columns.Add("RECEIVEDBY")
                .Columns.Add("DESCRIPTION")
                .Columns.Add("UNIT")
                .Columns.Add("QTY")
                .Columns.Add("UNITPRICE")
                .Columns.Add("AMOUNT")
            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    Dim PAYTYPE As String
                    If OleDBDR.Item(14) = "CASH (PARTIAL)" Or OleDBDR.Item(14) = "CHEQUE (PARTIAL)" Then
                        PAYTYPE = "partial "
                    Else
                        PAYTYPE = ""
                    End If
                    dt.Rows.Add(OleDBDR.Item(0),
                    OleDBDR.Item(13),
                     Format(OleDBDR.Item(1), "MMM dd, yyyy"),
                     OleDBDR.Item(2),
                     UCase(ConvertNumberToENG(Val(OleDBDR.Item(16)))),
                     Format(OleDBDR.Item(16), "N"),
                    PAYTYPE,
                     OleDBDR.Item(4),
                    OleDBDR.Item(5) & "x" & Format(OleDBDR.Item(6), "N0") & " - " & OleDBDR.Item(7) & " (" & OleDBDR.Item(8) & " " & OleDBDR.Item(9) & ")",
                      "PCS",
                     Format(OleDBDR.Item(10), "N"),
                     Format(OleDBDR.Item(11), "N"),
                     Format(OleDBDR.Item(12), "N"))
                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New ACKprint
            rptDoc.SetDataSource(dt)
            frmReportViewerNoDateRange.CrystalReportViewer1.ReportSource = rptDoc
            frmReportViewerNoDateRange.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PrintViewAcknowledgementReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintViewAcknowledgementReceiptToolStripMenuItem.Click
        If dgv.CurrentRow.Cells(4).Value = "CANCELLED" Then
            MsgBox("Sorry this transaction is cancelled, You cant print Acknowledgement Receipt", MsgBoxStyle.Critical, "Sorry")
            Exit Sub
        End If
        frmPaymentList.dgv.Rows.Clear()
        loadPaymentHistory()
        frmPaymentList.ShowDialog()
    End Sub
    Private Sub dgv_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgv.CurrentCell = dgv(e.ColumnIndex, e.RowIndex)
                dgv.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub CancellTransaction()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "update tblSales set PAYSTATUS = 'CANCELLED' " & _
                                " WHERE SALESNO = '" & dgv.CurrentRow.Cells(1).Value & "'"
                .ExecuteNonQuery()
            End With
            MsgBox("Transaction Cancelled !", MsgBoxStyle.Information, "Success")
            loadSalesHistory()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgv.ContextMenuStrip = ContextMenuStrip2
    End Sub
    Sub savePaid()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "INSERT INTO tblPaid VALUES('" & PAYNO & _
                     "','" & Now.ToString("MM/dd/yyyy hh:mm tt") & _
                    "','" & dgv.CurrentRow.Cells(1).Value & _
                    "','" & lblmode & _
                     "','" & checkNo & _
                     "','" & amountPaid & _
                       "','','" & Format(postChequeDate, "MM/dd/yyyy hh:mm") & "'); " & _
                    "WITH STATS AS (SELECT " & _
                    "CASE WHEN TOTALAMOUNT <= SUM(dbo.tblPaid.AMOUNTPAID) THEN " & _
                    "'PAID' " & _
                    "ELSE " & _
                    "'NOT PAID' " & _
                    "END as STATUS " & _
                    "FROM " & _
                    "dbo.tblSales " & _
                    "INNER JOIN dbo.tblPaid ON dbo.tblSales.SALESNO = dbo.tblPaid.SALESNO " & _
                    "WHERE " & _
                    "tblsales.SALESNO = '" & dgv.CurrentRow.Cells(1).Value & "' " & _
                    "GROUP BY  " & _
                    "dbo.tblSales.TOTALAMOUNT) " & _
                    "UPDATE tblsales set PAYSTATUS = STATUS " & _
                    "FROM STATS  " & _
                    "WHERE  " & _
                    "tblsales.SALESNO = '" & dgv.CurrentRow.Cells(1).Value & "' "
                .ExecuteNonQuery()
            End With
            If MsgBox("You want to print this acknowledgement receipt", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                printAcknowledgementReceipt()
            End If
            MsgBox("Sales Paid !", MsgBoxStyle.Information, "Success")
            loadSalesHistory()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CancelSalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelSalesToolStripMenuItem.Click
        If MsgBox("Are you sure you want to cancel this transaction ?", MsgBoxStyle.YesNo, "Are you sure ?") = MsgBoxResult.Yes Then
            CancellTransaction()
        End If
    End Sub

    Private Sub PaySalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaySalesToolStripMenuItem.Click
        If dgv.CurrentRow.Cells(4).Value = "PAID" Then
            MsgBox("Sorry this transaction is already paid, You can't pay it again", MsgBoxStyle.Critical, "Sorry")
            Exit Sub
        End If
        If dgv.CurrentRow.Cells(4).Value = "CANCELLED" Then
            MsgBox("Sorry this transaction is cancelled, You can't pay it", MsgBoxStyle.Critical, "Sorry")
            Exit Sub
        End If
        frmPaymethod.mode = "Pay"
        frmPaymethod.ShowDialog()
        If frmPaymethod.ComboBox1.Text = "" Then
            Exit Sub
        End If
        amountPaid = InputBox("Input Paid Amount", "Entry")
        If IsNumeric(amountPaid) = False Then
            MsgBox("Please input valid Amount", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If lblmode = "CHEQUE" Or lblmode = "CHEQUE (POSTDATE)" Or lblmode = "CHEQUE (PARTIAL)" Then
            checkNo = InputBox("Please Type Check No.", "Entry")
        Else
            checkNo = ""
        End If
        generatePAYNo()
        savePaid()
    End Sub

    Private Sub PaidPostdatedChequeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaidPostdatedChequeToolStripMenuItem.Click
        Dim postchequedate As DateTime = dgv.CurrentRow.Cells(5).Value
        If dgv.CurrentRow.Cells(4).Value = "CHEQUE (POSTDATE)" And postchequedate <= Format(Now, "dd/MM/yyyy") Then

            If MsgBox("Are you sure you want to paid this transaction ?", MsgBoxStyle.YesNo, "Are you sure ?") = MsgBoxResult.Yes Then
                Try
                    If conn.State = ConnectionState.Open Then
                        OleDBC.Dispose()
                        conn.Close()
                    End If
                    If conn.State <> ConnectionState.Open Then
                        ConnectDatabase()
                    End If
                    With OleDBC
                        .Connection = conn
                        .CommandText = "UPDATE tblsales set PAYSTATUS = 'PAID' " & _
                            "WHERE tblsales.SALESNO = '" & dgv.CurrentRow.Cells(1).Value & "' "
                        .ExecuteNonQuery()
                    End With
                    MsgBox("Sales Paid !", MsgBoxStyle.Information, "Success")
                    loadSalesHistory()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Else
            MsgBox("You Can't Paid this sales right now!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
    End Sub
End Class