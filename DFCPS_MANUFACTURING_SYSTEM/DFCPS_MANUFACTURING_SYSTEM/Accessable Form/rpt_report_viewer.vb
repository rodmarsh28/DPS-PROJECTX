Public Class rpt_report_viewer
    Public cardid As String
    Public Sub print_report(ByVal command As String, ByVal type As String, ByVal id As String, ByVal dfrom As DateTime, ByVal dto As DateTime)
        Try
            If command = "PAYMENT RECEIVABLE" Then
                Dim ds As New sales_dsTableAdapters.get_payment_statementTableAdapter
                ds.Connection.ConnectionString = My.Settings.connStringValue
                Dim dt As New sales_ds
                ds.Fill(dt.Tables("get_payment_statement"), command, type, id, dfrom, dto)
                Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
                rptDoc = New rpt_receivableReport
                rptDoc.SetDataSource(dt.Tables("get_payment_statement"))
                CrystalReportViewer1.ReportSource = rptDoc
            Else
                Dim ds As New sales_dsTableAdapters.get_sales_reportTableAdapter
                ds.Connection.ConnectionString = My.Settings.connStringValue
                Dim dt As New sales_ds
                ds.Fill(dt.Tables("get_sales_report"), command, type, id, dfrom, dto)
                Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
                rptDoc = New rpt_salesReport
                rptDoc.SetDataSource(dt.Tables("get_sales_report"))
                rptDoc.SetParameterValue("title", command)
                CrystalReportViewer1.ReportSource = rptDoc
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        print_report(LBLMODE.Text, cmbType.Text, cardid, dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        frmCardListForSelection.formMode = "Sales Invoice"
        frmCardListForSelection.itemClick = False
        frmCardListForSelection.filterType()
        frmCardListForSelection.ShowDialog()
        If frmCardListForSelection.itemClick = True Then
            cardid = frmCardListForSelection.LV.SelectedItems(0).SubItems(0).Text
            txtName.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(1).Text
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        txtName.Text = ""
        cardid = ""
    End Sub
End Class