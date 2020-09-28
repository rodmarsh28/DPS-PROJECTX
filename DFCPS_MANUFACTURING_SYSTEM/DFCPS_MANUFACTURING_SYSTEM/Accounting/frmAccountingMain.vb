Public Class frmAccountingMain

    Private Sub PrepareCheckvoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareCheckvoucherToolStripMenuItem.Click
        frmCheckVoucher.ShowDialog()
    End Sub

    Private Sub PrepareCashRequisistionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmRequestForCash.ShowDialog()
    End Sub

    Private Sub PreparePaymentRequisistionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmRequestForPayment.ShowDialog()
    End Sub

    Private Sub PrepareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPettyCashVoucher.ShowDialog()
    End Sub

    Private Sub PurchaseOrderHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderHistoryToolStripMenuItem.Click
        TransactionViewer.MODE = "GET_PURCHASEORDER"
        TransactionViewer.ShowDialog()
    End Sub

    Private Sub PurchaseRequisitionHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRequisitionHistoryToolStripMenuItem.Click
        TransactionViewer.MODE = "GET_REQUISITION"
        TransactionViewer.ShowDialog()
    End Sub

    Private Sub CashRequisitionHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashRequisitionHistoryToolStripMenuItem.Click
        TransactionViewer.MODE = "GET_CASH_REQUISITION"
        TransactionViewer.ShowDialog()
    End Sub

    Private Sub PayablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAR_AP.Text = "Accounts Payable List"
        frmAR_AP.MODE = "Payables"
        frmAR_AP.GET_PAYABLES()
        frmAR_AP.ShowDialog()
    End Sub

    Private Sub ReceivablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAR_AP.Text = "Accounts Receivable List"
        frmAR_AP.MODE = "Receivable"
        frmAR_AP.GET_RECEIVABLES()
        frmAR_AP.ShowDialog()
    End Sub

    Private Sub BankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankToolStripMenuItem.Click
        frmManageBank.ShowDialog()
    End Sub

    Private Sub CheckbookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckbookToolStripMenuItem.Click
        frmManageCheckbook.ShowDialog()
    End Sub

    Private Sub CardVoucherPayablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardVoucherPayablesToolStripMenuItem.Click
        frmVoucher_Payable_List.ShowDialog()
    End Sub

    Private Sub CashvoucherHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashvoucherHistoryToolStripMenuItem.Click
        TransactionViewer.MODE = "GET_CV"
        TransactionViewer.ShowDialog()
    End Sub

    Private Sub GeneralLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralLedgerToolStripMenuItem.Click
        frmGLreportViewer.ShowDialog()
    End Sub

    Private Sub PrepareCashCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareCashCheckToolStripMenuItem.Click
        frmCashRequisition.ShowDialog()
    End Sub

    Private Sub PrepareVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareVoucherToolStripMenuItem.Click
        frmVoucher.ShowDialog()
    End Sub

    Private Sub CardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardToolStripMenuItem.Click
        CardList.ShowDialog()
    End Sub

    Private Sub CheckTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTransactionToolStripMenuItem.Click
        frmCheckTransList.ShowDialog()
    End Sub

    Private Sub RecordGeneralJournalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecordGeneralJournalToolStripMenuItem.Click
        frmJournalEntry.ShowDialog()
    End Sub
End Class