<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountingMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUsername = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddEmployeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WidthrawItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreparePurchaseInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrepareVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrepareCheckvoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrepareCashCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecordGeneralJournalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseRequisitionHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseOrderHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseInvoiceHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesOrderHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesInvoiceHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashvoucherHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashRequisitionHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CardVoucherPayablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckbookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PayrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneralLedgerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.lblDate, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6, Me.lblTime, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel7, Me.lblUsername})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 728)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1173, 22)
        Me.StatusStrip.TabIndex = 14
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(34, 17)
        Me.ToolStripStatusLabel3.Text = "Date:"
        '
        'lblDate
        '
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(65, 17)
        Me.lblDate.Text = "00/00/0000"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(37, 17)
        Me.ToolStripStatusLabel6.Text = "Time:"
        '
        'lblTime
        '
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(34, 17)
        Me.lblTime.Text = "00:00"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(40, 17)
        Me.ToolStripStatusLabel1.Text = "           "
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(33, 17)
        Me.ToolStripStatusLabel7.Text = "User:"
        '
        'lblUsername
        '
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(58, 17)
        Me.lblUsername.Text = "Unknown"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TransactionToolStripMenuItem, Me.ManageToolStripMenuItem, Me.PayrollToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1173, 24)
        Me.MenuStrip1.TabIndex = 15
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEmployeesToolStripMenuItem, Me.WidthrawItemsToolStripMenuItem, Me.PreparePurchaseInvoiceToolStripMenuItem, Me.PrepareVoucherToolStripMenuItem, Me.PrepareCheckvoucherToolStripMenuItem, Me.PrepareCashCheckToolStripMenuItem, Me.RecordGeneralJournalToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AddEmployeesToolStripMenuItem
        '
        Me.AddEmployeesToolStripMenuItem.Name = "AddEmployeesToolStripMenuItem"
        Me.AddEmployeesToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.AddEmployeesToolStripMenuItem.Text = "Prepare Purchase Requisition"
        '
        'WidthrawItemsToolStripMenuItem
        '
        Me.WidthrawItemsToolStripMenuItem.Name = "WidthrawItemsToolStripMenuItem"
        Me.WidthrawItemsToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.WidthrawItemsToolStripMenuItem.Text = "Prepare Purchase Order"
        '
        'PreparePurchaseInvoiceToolStripMenuItem
        '
        Me.PreparePurchaseInvoiceToolStripMenuItem.Name = "PreparePurchaseInvoiceToolStripMenuItem"
        Me.PreparePurchaseInvoiceToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.PreparePurchaseInvoiceToolStripMenuItem.Text = "Prepare Purchase Receiving / Bills"
        '
        'PrepareVoucherToolStripMenuItem
        '
        Me.PrepareVoucherToolStripMenuItem.Name = "PrepareVoucherToolStripMenuItem"
        Me.PrepareVoucherToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.PrepareVoucherToolStripMenuItem.Text = "Prepare Voucher"
        '
        'PrepareCheckvoucherToolStripMenuItem
        '
        Me.PrepareCheckvoucherToolStripMenuItem.Name = "PrepareCheckvoucherToolStripMenuItem"
        Me.PrepareCheckvoucherToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.PrepareCheckvoucherToolStripMenuItem.Text = "Prepare Checkvoucher"
        '
        'PrepareCashCheckToolStripMenuItem
        '
        Me.PrepareCashCheckToolStripMenuItem.Name = "PrepareCashCheckToolStripMenuItem"
        Me.PrepareCashCheckToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.PrepareCashCheckToolStripMenuItem.Text = "Prepare Cash/Check Requisition"
        '
        'RecordGeneralJournalToolStripMenuItem
        '
        Me.RecordGeneralJournalToolStripMenuItem.Name = "RecordGeneralJournalToolStripMenuItem"
        Me.RecordGeneralJournalToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.RecordGeneralJournalToolStripMenuItem.Text = "Record General Journal"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseRequisitionHistoryToolStripMenuItem, Me.PurchaseOrderHistoryToolStripMenuItem, Me.PurchaseInvoiceHistoryToolStripMenuItem, Me.SalesOrderHistoryToolStripMenuItem, Me.SalesInvoiceHistoryToolStripMenuItem, Me.CashvoucherHistoryToolStripMenuItem, Me.CashRequisitionHistoryToolStripMenuItem, Me.CardVoucherPayablesToolStripMenuItem, Me.CheckTransactionToolStripMenuItem})
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.TransactionToolStripMenuItem.Text = "View"
        '
        'PurchaseRequisitionHistoryToolStripMenuItem
        '
        Me.PurchaseRequisitionHistoryToolStripMenuItem.Name = "PurchaseRequisitionHistoryToolStripMenuItem"
        Me.PurchaseRequisitionHistoryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.PurchaseRequisitionHistoryToolStripMenuItem.Text = "Purchase Requisition History"
        '
        'PurchaseOrderHistoryToolStripMenuItem
        '
        Me.PurchaseOrderHistoryToolStripMenuItem.Name = "PurchaseOrderHistoryToolStripMenuItem"
        Me.PurchaseOrderHistoryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.PurchaseOrderHistoryToolStripMenuItem.Text = "Purchase Order History"
        '
        'PurchaseInvoiceHistoryToolStripMenuItem
        '
        Me.PurchaseInvoiceHistoryToolStripMenuItem.Name = "PurchaseInvoiceHistoryToolStripMenuItem"
        Me.PurchaseInvoiceHistoryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.PurchaseInvoiceHistoryToolStripMenuItem.Text = "Purchase Receiving History"
        '
        'SalesOrderHistoryToolStripMenuItem
        '
        Me.SalesOrderHistoryToolStripMenuItem.Name = "SalesOrderHistoryToolStripMenuItem"
        Me.SalesOrderHistoryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SalesOrderHistoryToolStripMenuItem.Text = "Sales Order History"
        '
        'SalesInvoiceHistoryToolStripMenuItem
        '
        Me.SalesInvoiceHistoryToolStripMenuItem.Name = "SalesInvoiceHistoryToolStripMenuItem"
        Me.SalesInvoiceHistoryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SalesInvoiceHistoryToolStripMenuItem.Text = "Sales Invoice History"
        '
        'CashvoucherHistoryToolStripMenuItem
        '
        Me.CashvoucherHistoryToolStripMenuItem.Name = "CashvoucherHistoryToolStripMenuItem"
        Me.CashvoucherHistoryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.CashvoucherHistoryToolStripMenuItem.Text = "Checkvoucher"
        '
        'CashRequisitionHistoryToolStripMenuItem
        '
        Me.CashRequisitionHistoryToolStripMenuItem.Name = "CashRequisitionHistoryToolStripMenuItem"
        Me.CashRequisitionHistoryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.CashRequisitionHistoryToolStripMenuItem.Text = "Cash Requisition"
        '
        'CardVoucherPayablesToolStripMenuItem
        '
        Me.CardVoucherPayablesToolStripMenuItem.Name = "CardVoucherPayablesToolStripMenuItem"
        Me.CardVoucherPayablesToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.CardVoucherPayablesToolStripMenuItem.Text = "Card Voucher Payables"
        '
        'CheckTransactionToolStripMenuItem
        '
        Me.CheckTransactionToolStripMenuItem.Name = "CheckTransactionToolStripMenuItem"
        Me.CheckTransactionToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.CheckTransactionToolStripMenuItem.Text = "Check Transaction list"
        '
        'ManageToolStripMenuItem
        '
        Me.ManageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CardToolStripMenuItem, Me.BankToolStripMenuItem, Me.CheckbookToolStripMenuItem})
        Me.ManageToolStripMenuItem.Name = "ManageToolStripMenuItem"
        Me.ManageToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ManageToolStripMenuItem.Text = "Manage"
        '
        'CardToolStripMenuItem
        '
        Me.CardToolStripMenuItem.Name = "CardToolStripMenuItem"
        Me.CardToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CardToolStripMenuItem.Text = "Card"
        '
        'BankToolStripMenuItem
        '
        Me.BankToolStripMenuItem.Name = "BankToolStripMenuItem"
        Me.BankToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BankToolStripMenuItem.Text = "Bank"
        '
        'CheckbookToolStripMenuItem
        '
        Me.CheckbookToolStripMenuItem.Name = "CheckbookToolStripMenuItem"
        Me.CheckbookToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CheckbookToolStripMenuItem.Text = "Checkbook"
        '
        'PayrollToolStripMenuItem
        '
        Me.PayrollToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneralLedgerToolStripMenuItem})
        Me.PayrollToolStripMenuItem.Name = "PayrollToolStripMenuItem"
        Me.PayrollToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.PayrollToolStripMenuItem.Text = "Report"
        '
        'GeneralLedgerToolStripMenuItem
        '
        Me.GeneralLedgerToolStripMenuItem.Name = "GeneralLedgerToolStripMenuItem"
        Me.GeneralLedgerToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.GeneralLedgerToolStripMenuItem.Text = "General Ledger"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'frmAccountingMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 750)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "frmAccountingMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Accounting "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUsername As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddEmployeesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WidthrawItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreparePurchaseInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseRequisitionHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseOrderHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseInvoiceHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PayrollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesInvoiceHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrepareCheckvoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CashvoucherHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CashRequisitionHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesOrderHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BankToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckbookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrepareVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CardVoucherPayablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeneralLedgerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrepareCashCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckTransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecordGeneralJournalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
