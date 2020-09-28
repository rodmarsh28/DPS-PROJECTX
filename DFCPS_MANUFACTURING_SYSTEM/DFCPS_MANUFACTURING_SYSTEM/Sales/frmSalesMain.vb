Public Class frmSalesMain

    Private Sub AddEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEmployeesToolStripMenuItem.Click
        frmSalesInvoice.lblFormMode.Text = "QUOTATION"
        frmSalesInvoice.Show()
    End Sub

    Private Sub WidthrawItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WidthrawItemsToolStripMenuItem.Click
        frmSalesInvoice.lblFormMode.Text = "SALES ORDER"
        frmSalesInvoice.Show()
    End Sub

    Private Sub PreparePurchaseInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreparePurchaseInvoiceToolStripMenuItem.Click
        frmSalesInvoice.lblFormMode.Text = "SALES CASH INVOICE"
        frmSalesInvoice.Show()
    End Sub

    Private Sub PrepareSalesDeliveryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareSalesDeliveryToolStripMenuItem.Click
        frmSalesInvoice.lblFormMode.Text = "SALES DELIVER"
        frmSalesInvoice.Show()
    End Sub

    Private Sub PrepareSalesChargeInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareSalesChargeInvoiceToolStripMenuItem.Click
        frmSalesInvoice.lblFormMode.Text = "SALES CHARGE INVOICE"
        frmSalesInvoice.Show()
    End Sub

    Private Sub PurchaseOrderHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderHistoryToolStripMenuItem.Click
        SalesTransactionViewer.MODE = "SALES ORDER"
        SalesTransactionViewer.Show() 'show the child form
    End Sub

    Private Sub PurchaseRequisitionHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRequisitionHistoryToolStripMenuItem.Click
        SalesTransactionViewer.MODE = "QUOTATION"
        SalesTransactionViewer.Show()
    End Sub

    Private Sub PurchaseInvoiceHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceHistoryToolStripMenuItem.Click
        SalesTransactionViewer.MODE = "SALES CASH INVOICE"
        SalesTransactionViewer.Show()
    End Sub

    Private Sub SalesChargeInvoiceHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesChargeInvoiceHistoryToolStripMenuItem.Click
        SalesTransactionViewer.MODE = "SALES CHARGE INVOICE"
        SalesTransactionViewer.Show()
    End Sub

    Private Sub SalesDeliverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesDeliverToolStripMenuItem.Click
        SalesTransactionViewer.MODE = "SALES DELIVER"
        SalesTransactionViewer.Show()
    End Sub

    Private Sub ReceivePaymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivePaymentsToolStripMenuItem.Click
        'prepare_job.Show()
    End Sub

    Private Sub JobOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobOrderToolStripMenuItem.Click
        SalesTransactionViewer.MODE = "JOB ORDER"
        SalesTransactionViewer.Show()
    End Sub
End Class