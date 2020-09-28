<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventorySystemMain
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
        Me.AdjustInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithrawRawMaterialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RawMaterialsStockInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PendingRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PayrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoldReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemsLevelReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchasesReceivingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.lblDate, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6, Me.lblTime, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel7, Me.lblUsername})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 756)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1173, 22)
        Me.StatusStrip.TabIndex = 10
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TransactionToolStripMenuItem, Me.PayrollToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1173, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEmployeesToolStripMenuItem, Me.AdjustInventoryToolStripMenuItem, Me.WithrawRawMaterialToolStripMenuItem, Me.RawMaterialsStockInToolStripMenuItem, Me.PurchasesReceivingToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AddEmployeesToolStripMenuItem
        '
        Me.AddEmployeesToolStripMenuItem.Name = "AddEmployeesToolStripMenuItem"
        Me.AddEmployeesToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.AddEmployeesToolStripMenuItem.Text = "Add Items"
        '
        'AdjustInventoryToolStripMenuItem
        '
        Me.AdjustInventoryToolStripMenuItem.Name = "AdjustInventoryToolStripMenuItem"
        Me.AdjustInventoryToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.AdjustInventoryToolStripMenuItem.Text = "Adjust Inventory"
        '
        'WithrawRawMaterialToolStripMenuItem
        '
        Me.WithrawRawMaterialToolStripMenuItem.Name = "WithrawRawMaterialToolStripMenuItem"
        Me.WithrawRawMaterialToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.WithrawRawMaterialToolStripMenuItem.Text = "Withraw Raw Materials"
        '
        'RawMaterialsStockInToolStripMenuItem
        '
        Me.RawMaterialsStockInToolStripMenuItem.Name = "RawMaterialsStockInToolStripMenuItem"
        Me.RawMaterialsStockInToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.RawMaterialsStockInToolStripMenuItem.Text = "Raw Materials Stock in"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventoryToolStripMenuItem, Me.PendingRequisitionToolStripMenuItem})
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.TransactionToolStripMenuItem.Text = "View"
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.InventoryToolStripMenuItem.Text = "Inventory"
        '
        'PendingRequisitionToolStripMenuItem
        '
        Me.PendingRequisitionToolStripMenuItem.Name = "PendingRequisitionToolStripMenuItem"
        Me.PendingRequisitionToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PendingRequisitionToolStripMenuItem.Text = "Pending Requisition"
        '
        'PayrollToolStripMenuItem
        '
        Me.PayrollToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemsReportToolStripMenuItem, Me.SoldReportToolStripMenuItem, Me.PurchaseReportToolStripMenuItem, Me.ItemsLevelReportToolStripMenuItem})
        Me.PayrollToolStripMenuItem.Name = "PayrollToolStripMenuItem"
        Me.PayrollToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.PayrollToolStripMenuItem.Text = "Report"
        '
        'ItemsReportToolStripMenuItem
        '
        Me.ItemsReportToolStripMenuItem.Name = "ItemsReportToolStripMenuItem"
        Me.ItemsReportToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ItemsReportToolStripMenuItem.Text = "Items Report"
        '
        'SoldReportToolStripMenuItem
        '
        Me.SoldReportToolStripMenuItem.Name = "SoldReportToolStripMenuItem"
        Me.SoldReportToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SoldReportToolStripMenuItem.Text = "Sold Report"
        '
        'PurchaseReportToolStripMenuItem
        '
        Me.PurchaseReportToolStripMenuItem.Name = "PurchaseReportToolStripMenuItem"
        Me.PurchaseReportToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PurchaseReportToolStripMenuItem.Text = "Purchase Report"
        '
        'ItemsLevelReportToolStripMenuItem
        '
        Me.ItemsLevelReportToolStripMenuItem.Name = "ItemsLevelReportToolStripMenuItem"
        Me.ItemsLevelReportToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ItemsLevelReportToolStripMenuItem.Text = "Items Level Report"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'PurchasesReceivingToolStripMenuItem
        '
        Me.PurchasesReceivingToolStripMenuItem.Name = "PurchasesReceivingToolStripMenuItem"
        Me.PurchasesReceivingToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.PurchasesReceivingToolStripMenuItem.Text = "Purchases Receiving"
        '
        'frmInventorySystemMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1173, 778)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "frmInventorySystemMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory System"
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
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PayrollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemsReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SoldReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemsLevelReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdjustInventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PendingRequisitionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WithrawRawMaterialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RawMaterialsStockInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchasesReceivingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
