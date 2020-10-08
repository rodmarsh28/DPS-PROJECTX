Public Class frmPurchaseMain

    Private Sub AddEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEmployeesToolStripMenuItem.Click
        frmItemRequisition.Show()
    End Sub

    Private Sub WidthrawItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WidthrawItemsToolStripMenuItem.Click
        Dim frm As New frmPurchases
        frm.lblFormMode.Text = "PURCHASE ORDER"
        frm.MdiParent = Me
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.dgv.SelectionMode = DataGridViewSelectionMode.CellSelect
        frm.dgv.AllowUserToAddRows = True
        frm.dgv.AllowUserToDeleteRows = True
        frm.dgv.ReadOnly = False

        frm.btnSearch.Enabled = False
        frm.Show()
    End Sub

    Private Sub PreparePurchaseInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreparePurchaseInvoiceToolStripMenuItem.Click
        Dim frm As New frmPurchases
        frm.lblFormMode.Text = "PURCHASE INVOICE"
        frm.MdiParent = Me
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        frm.dgv.AllowUserToAddRows = False
        frm.dgv.AllowUserToDeleteRows = False
        frm.dgv.ReadOnly = True
        frm.btnSearch.Enabled = True
        frm.Show()
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