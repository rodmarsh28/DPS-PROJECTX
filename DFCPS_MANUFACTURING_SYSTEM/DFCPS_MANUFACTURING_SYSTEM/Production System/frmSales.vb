Public Class frmSales
    Public totAmount As Double
    Public JONO As String
    Public remarks As String = ""
    Dim checkNo As String
    Dim amountPaid As String
    Dim PAYNO As String
    Public postChequeDate As DateTime
    Sub generateSALESNo()
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
                .CommandText = "SELECT * from tblSales order by SALESNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                txtSalesNo.Text = "SLS-" & Format(Val(StrID) + 1, "00000")

            Else
                txtSalesNo.Text = "SLS-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub generateJONo()
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
                .CommandText = "SELECT * from tblJobOrder order by JONO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                JONO = "JO-" & Format(Val(StrID) + 1, "00000")
            Else
                JONO = "JO-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
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
                StrID = Mid(OleDBDR(0), 8, Len(OleDBDR(0)))
                PAYNO = Format(Now, "yyyy") & "-" & Format(Val(StrID) + 1, "00000")

            Else
                PAYNO = Format(Now, "yyyy") & "-" & "00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    'Sub clear()
    '    txtColor.Text = ""
    '    txtUnitPrice.Text = ""
    '    txtQty.Text = ""
    'End Sub
    Sub disposeform()
        txtSalesNo.Text = ""
        txtName.Text = ""
        txtAddress.Text = ""
        totAmount = 0
        lblTotal.Text = "Php " & Format(totAmount, "N")
        dgv.Rows.Clear()
    End Sub
    Sub autoOperator()
        Try
            Dim col As New AutoCompleteStringCollection

            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT Distinct CUSTOMERNAME from tblSales "
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    col.Add(OleDBDR.Item(0))
                End While
                txtName.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtName.AutoCompleteCustomSource = col
                txtName.AutoCompleteMode = AutoCompleteMode.Suggest
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    If txtUnitPrice.Text = "" Then
        '        txtUnitPrice.Text = "0.00"
        '    End If
        '    If txtQty.Text = "" Then
        '        txtQty.Text = "0.00"
        '    End If
        '    If txtWidth.Text = "" Or txtColor.Text = "" Or cmbSewnType.Text = "" Then
        '        Exit Sub
        '    End If
        '    Dim Amount As Double
        '    Amount = txtUnitPrice.Text * txtQty.Text
        '    Dim R As Integer = dgv.Rows.Count
        '    dgv.Rows.Add()
        '    dgv.Item(0, R).Value = txtWidth.Text
        '    dgv.Item(1, R).Value = txtHeight.Text
        '    dgv.Item(2, R).Value = txtColor.Text
        '    dgv.Item(3, R).Value = cmbSewnType.Text
        '    dgv.Item(4, R).Value = txtQty.Text
        '    dgv.Item(5, R).Value = txtUnitPrice.Text
        '    dgv.Item(6, R).Value = Amount
        '    totAmount = totAmount + Amount
        '    lblTotAmount.Text = totAmount
        '    clear()
    End Sub
    Sub SAVE()
        Dim payStatus As String
        If lblMode.Text = "CREDIT" Then
            payStatus = "NOT PAID"
        ElseIf lblMode.Text = "CASH" Then
            payStatus = "PAID"
        ElseIf lblMode.Text = "CHEQUE (ONDATE)" Then
            payStatus = "PAID"
        ElseIf lblMode.Text = "CHEQUE (POSTDATE)" Then
            payStatus = "NOT PAID"
        End If
        If dgv.Rows.Count = "0" Then
            MsgBox("No Data can be Save", MsgBoxStyle.Critical, "Sorry")
            Exit Sub
        End If
        If MsgBox("ARE YOU SURE THIS TRANSACTION ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            remarks = "SALES DATE " & Format(Now, "MM/dd/yyyy")
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
                    .CommandText = "INSERT INTO tblSales VALUES('" & txtSalesNo.Text & _
                        "','" & Now.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & txtName.Text & _
                        "','" & txtAddress.Text & _
                        "','" & CStr(totAmount) & _
                        "','" & lblMode.Text & _
                        "','" & payStatus & _
                        "','" & remarks & _
                        "','DEVINE JENELIE BIÑAN')"

                    .ExecuteNonQuery()
                End With
                saveItem()
                SAVEJO()
                saveJOItem()
                If lblMode.Text <> "CREDIT" Then
                    generatePAYNo()
                    savePaid()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Sales Saved !", MsgBoxStyle.Information, "Success")
                disposeform()
                generateSALESNo()
                generateJONo()
                autoOperator()
            End Try
        End If
    End Sub
    Sub SAVEJO()
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
                .CommandText = "INSERT INTO tblJobOrder VALUES('" & JONO & _
                    "','" & Now.ToString("MM/dd/yyyy hh:mm tt") & _
                    "','" & txtSalesNo.Text & _
                    "','" & txtName.Text & _
                    "','')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub saveItem()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgv.RowCount
        While col < row1
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "INSERT INTO tblSalesTR VALUES('" & txtSalesNo.Text & _
                        "','" & dgv.Item(1, col).Value & _
                        "','" & dgv.Item(2, col).Value & _
                        "','" & dgv.Item(3, col).Value & _
                        "','" & dgv.Item(4, col).Value & _
                        "','" & dgv.Item(5, col).Value & _
                        "','" & CDbl(dgv.Item(6, col).Value) & _
                        "','" & CDbl(dgv.Item(7, col).Value) & _
                        "','" & CDbl(dgv.Item(8, col).Value) & _
                        "','" & dgv.Item(9, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub
    Sub saveJOItem()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgv.RowCount
        While col < row1
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "INSERT INTO tblJobOrderTR VALUES('" & JONO & _
                        "','" & dgv.Item(0, col).Value & _
                        "','" & dgv.Item(1, col).Value & _
                        "','" & dgv.Item(2, col).Value & _
                        "','" & dgv.Item(3, col).Value & _
                        "','" & dgv.Item(4, col).Value & _
                        "','" & dgv.Item(5, col).Value & _
                        "','" & CDbl(dgv.Item(6, col).Value) & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
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
                    "','" & txtSalesNo.Text & _
                    "','" & lblMode.Text & _
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
                    "tblsales.SALESNO = '" & txtSalesNo.Text & "' " & _
                    "GROUP BY  " & _
                    "dbo.tblSales.TOTALAMOUNT) " & _
                    "UPDATE tblsales set PAYSTATUS = STATUS " & _
                    "FROM STATS  " & _
                    "WHERE  " & _
                    "tblsales.SALESNO = '" & txtSalesNo.Text & "' "
                .ExecuteNonQuery()
            End With
            printAcknowledgementReceipt()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub printAcknowledgementReceipt()
        If MsgBox("You Want to Print Acknowledgement Receipt ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
        End If
    End Sub
    Sub JobOrderSlip()
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
                .CommandText = "SELECT dbo.tblJobOrderTR.JONO, " & _
                "dbo.tblJobOrder.[DATE], " & _
                "dbo.tblJobOrder.REF, " & _
                "dbo.tblJobOrder.CUSTOMER, " & _
                "dbo.tblJobOrderTR.DESCRIPTION, " & _
                "dbo.tblJobOrderTR.QTY " & _
                "FROM dbo.tblJobOrder " & _
                "INNER JOIN dbo.tblJobOrderTR ON dbo.tblJobOrder.JONO = dbo.tblJobOrderTR.JONO " & _
                "WHERE tblJobOrderTR.JONO = '" & dgv.CurrentRow.Cells(1).Value & "'"

            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("SALESNO")
                .Columns.Add("DATE")
                .Columns.Add("CUSTOMER")
                .Columns.Add("AMOUNTINWORDS")
                .Columns.Add("AMOUNT")
                .Columns.Add("RECEIVEDBY")
                .Columns.Add("DESCRIPTION")
                .Columns.Add("UNIT")
                .Columns.Add("QTY")
            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dt.Rows.Add(OleDBDR.Item(0),
                     Format(OleDBDR.Item(1), "MMM dd, yyyy"),
                     OleDBDR.Item(2),
                     UCase(ConvertNumberToENG(Val(OleDBDR.Item(3)))),
                     Format(OleDBDR.Item(3), "N"),
                     OleDBDR.Item(4),
                   OleDBDR.Item(5) & "x" & OleDBDR.Item(6) & " - " & OleDBDR.Item(7) & " (" & OleDBDR.Item(8) & " " & OleDBDR.Item(9) & ")",
                      "PCS",
                     Format(OleDBDR.Item(10), "N0"))
                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New AcknowledgementReceipt
            rptDoc.SetDataSource(dt)
            frmReportViewerNoDateRange.CrystalReportViewer1.ReportSource = rptDoc
            frmReportViewerNoDateRange.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lblMode.Text <> "CREDIT" Then
            amountPaid = InputBox("Input Paid Amount", "Entry")
            If IsNumeric(amountPaid) = False Then
                MsgBox("Please input valid Amount", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
        End If
        If lblMode.Text = "CHEQUE" Or lblMode.Text = "CHEQUE (POSTDATE)" Or lblMode.Text = "CHEQUE (PARTIAL)" Then
            checkNo = InputBox("Please Type Check No.", "Entry")
        Else
            checkNo = ""
        End If
        SAVE()
    End Sub

    Private Sub frmSales_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        disposeform()
    End Sub

    Private Sub frmSales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSearch.Focus()
        ElseIf e.KeyCode = Keys.F1 Then
            Dim Customer As String = InputBox("Please Enter Customer Name", "Customer")
            Dim Address As String = InputBox("Please Enter Customer Address", "Address")
            txtName.Text = Customer
            txtAddress.Text = Address
        ElseIf e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control Then
            If MsgBox("ARE YOU SURE TO DELETE THIS ITEM?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
                For Each row As DataGridViewRow In dgv.SelectedRows
                    totAmount = totAmount - dgv.CurrentRow.Cells(8).Value
                    dgv.Rows.Remove(row)
                Next
                lblTotal.Text = "Php " & Format(totAmount, "N")
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            frmPaymethod.mode = "Sales"
            frmPaymethod.ShowDialog()
        End If
    End Sub

    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateSALESNo()
        autoOperator()
        generateJONo()
        totAmount = 0
        lblTotal.Text = "Php " & Format(totAmount, "N")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then
            txtSearch.Text = "1"
        End If
        'frmProductStockList.MODE = "SALES"
        'frmProductStockList.ShowDialog()
        lblTotal.Text = "Php " & Format(totAmount, "N")
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmPaymethod.mode = "Sales"
        frmPaymethod.ShowDialog()
    End Sub



    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmSalesHistoryViewer.ShowDialog()
    End Sub


    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        savePaid()
    End Sub
End Class