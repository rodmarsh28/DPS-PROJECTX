Public Class frmSalesMain

    Private Sub AddEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEmployeesToolStripMenuItem.Click
        Dim frm As New frmSalesInvoice
        frm.lblFormMode.Text = "QUOTATION"
        frm.Show()
        frm.load_commands()
    End Sub

    Private Sub WidthrawItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WidthrawItemsToolStripMenuItem.Click
        Dim frm As New frmSalesInvoice
        frm.lblFormMode.Text = "SALES ORDER"
        frm.Show()
        frm.load_commands()
    End Sub

    Private Sub PreparePurchaseInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreparePurchaseInvoiceToolStripMenuItem.Click
        Dim frm As New frmSalesInvoice
        frm.lblFormMode.Text = "SALES CASH INVOICE"
        frm.Show()
        frm.load_commands()
    End Sub

    Private Sub PrepareSalesDeliveryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareSalesDeliveryToolStripMenuItem.Click
        Dim frm As New frmSalesInvoice
        frm.lblFormMode.Text = "SALES DELIVER"
        frm.Show()
        frm.load_commands()
    End Sub

    Private Sub PrepareSalesChargeInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareSalesChargeInvoiceToolStripMenuItem.Click
        Dim frm As New frmSalesInvoice
        frm.lblFormMode.Text = "SALES CHARGE INVOICE"
        frm.Show()
        frm.load_commands()
    End Sub

    Private Sub PurchaseOrderHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderHistoryToolStripMenuItem.Click
        Dim frm As New SalesTransactionViewer
        frm.MODE = "SALES ORDER"
        frm.MdiParent = Me
        frm.Show()
        frm.GET_SALE_LIST()
    End Sub

    Private Sub PurchaseRequisitionHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRequisitionHistoryToolStripMenuItem.Click
        Dim frm As New SalesTransactionViewer
        frm.MODE = "QUOTATION"
        frm.MdiParent = Me
        frm.Show()
        frm.GET_SALE_LIST()
    End Sub

    Private Sub PurchaseInvoiceHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceHistoryToolStripMenuItem.Click
        Dim frm As New SalesTransactionViewer
        frm.MODE = "SALES CASH INVOICE"
        frm.MdiParent = Me
        frm.Show()
        frm.GET_SALE_LIST()
    End Sub

    Private Sub SalesChargeInvoiceHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesChargeInvoiceHistoryToolStripMenuItem.Click
        Dim frm As New SalesTransactionViewer
        frm.MODE = "SALES CHARGE INVOICE"
        frm.MdiParent = Me
        frm.Show()
        frm.GET_SALE_LIST()
    End Sub

    Private Sub SalesDeliverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesDeliverToolStripMenuItem.Click
        Dim frm As New SalesTransactionViewer
        frm.MODE = "SALES DELIVER"
        frm.MdiParent = Me
        frm.Show()
        frm.GET_SALE_LIST()
    End Sub

    Private Sub ReceivePaymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivePaymentsToolStripMenuItem.Click
        Dim frm As New frmReceivePayments
        frm.MODE = "RECEIVE PAYMENT"
        frm.Show()
        frm.load_command()
    End Sub

    Private Sub JobOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobOrderToolStripMenuItem.Click
        Dim frm As New SalesTransactionViewer
        frm.MODE = "JOB ORDER"
        frm.MdiParent = Me
        frm.Show()
        frm.GET_SALE_LIST()
    End Sub

    Private Sub PrepareJobOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareJobOrderToolStripMenuItem.Click
        Dim frm As New prepare_job
        frm.MdiParent = Me
        frm.StartPosition = FormStartPosition.CenterParent
        frm.generateNo()
        frm.Show()
    End Sub
End Class