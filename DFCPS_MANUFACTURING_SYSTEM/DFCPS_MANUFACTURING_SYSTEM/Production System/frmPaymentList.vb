Public Class frmPaymentList
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
                "WHERE tblPaid.payno = '" & dgv.CurrentRow.Cells(0).Value & "'"

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

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        printAcknowledgementReceipt()
    End Sub
End Class