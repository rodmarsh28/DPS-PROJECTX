Public Class frmPurchaseMain

    Private Sub AddEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEmployeesToolStripMenuItem.Click
        frmItemRequisition.Show()
    End Sub

    Private Sub WidthrawItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WidthrawItemsToolStripMenuItem.Click
        frmPurchases.lblFormMode.Text = "PURCHASE ORDER"
        frmPurchases.Show()
    End Sub

    Private Sub PreparePurchaseInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreparePurchaseInvoiceToolStripMenuItem.Click
        frmPurchases.lblFormMode.Text = "PURCHASE INVOICE"
        frmPurchases.Show()
    End Sub

    Private Sub PurchaseOrderHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderHistoryToolStripMenuItem.Click
        TransactionViewer.MODE = "GET_PURCHASEORDER"
        TransactionViewer.ShowDialog()
    End Sub

    Private Sub PurchaseRequisitionHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRequisitionHistoryToolStripMenuItem.Click

    End Sub

    Private Sub PurchaseInvoiceHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceHistoryToolStripMenuItem.Click

    End Sub
End Class