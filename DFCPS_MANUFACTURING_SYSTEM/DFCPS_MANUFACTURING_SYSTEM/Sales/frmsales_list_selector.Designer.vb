<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsales_list_selector
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmsales_list_selector))
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblItemCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.cmsSalesOrder = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintJobOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrepareSalesCashInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrepareSalesChargeInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelSalesOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsSalesQuotation = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsSalesOrder.SuspendLayout()
        Me.cmsSalesQuotation.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(12, 5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(561, 20)
        Me.txtSearch.TabIndex = 14
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblItemCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 249)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(589, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(102, 17)
        Me.ToolStripStatusLabel1.Text = "Total Item Count :"
        '
        'lblItemCount
        '
        Me.lblItemCount.Name = "lblItemCount"
        Me.lblItemCount.Size = New System.Drawing.Size(13, 17)
        Me.lblItemCount.Text = "0"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AllowUserToResizeColumns = False
        Me.DGV.BackgroundColor = System.Drawing.Color.White
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 29)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV.Size = New System.Drawing.Size(561, 210)
        Me.DGV.TabIndex = 17
        '
        'cmsSalesOrder
        '
        Me.cmsSalesOrder.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem, Me.PrintJobOrderToolStripMenuItem, Me.PrepareSalesCashInvoiceToolStripMenuItem, Me.PrepareSalesChargeInvoiceToolStripMenuItem, Me.CancelSalesOrderToolStripMenuItem})
        Me.cmsSalesOrder.Name = "cmsSalesOrder"
        Me.cmsSalesOrder.Size = New System.Drawing.Size(226, 114)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'PrintJobOrderToolStripMenuItem
        '
        Me.PrintJobOrderToolStripMenuItem.Name = "PrintJobOrderToolStripMenuItem"
        Me.PrintJobOrderToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.PrintJobOrderToolStripMenuItem.Text = "Print Job Order"
        '
        'PrepareSalesCashInvoiceToolStripMenuItem
        '
        Me.PrepareSalesCashInvoiceToolStripMenuItem.Name = "PrepareSalesCashInvoiceToolStripMenuItem"
        Me.PrepareSalesCashInvoiceToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.PrepareSalesCashInvoiceToolStripMenuItem.Text = "Prepare Sales Cash Invoice"
        '
        'PrepareSalesChargeInvoiceToolStripMenuItem
        '
        Me.PrepareSalesChargeInvoiceToolStripMenuItem.Name = "PrepareSalesChargeInvoiceToolStripMenuItem"
        Me.PrepareSalesChargeInvoiceToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.PrepareSalesChargeInvoiceToolStripMenuItem.Text = "Prepare Sales Charge Invoice"
        '
        'CancelSalesOrderToolStripMenuItem
        '
        Me.CancelSalesOrderToolStripMenuItem.Enabled = False
        Me.CancelSalesOrderToolStripMenuItem.Name = "CancelSalesOrderToolStripMenuItem"
        Me.CancelSalesOrderToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.CancelSalesOrderToolStripMenuItem.Text = "Cancel Sales Order"
        '
        'cmsSalesQuotation
        '
        Me.cmsSalesQuotation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.cmsSalesQuotation.Name = "cmsSalesOrder"
        Me.cmsSalesQuotation.Size = New System.Drawing.Size(100, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripMenuItem1.Text = "Print"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem4, Me.ToolStripMenuItem6})
        Me.ContextMenuStrip1.Name = "cmsSalesOrder"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(189, 70)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(188, 22)
        Me.ToolStripMenuItem2.Text = "Print"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(188, 22)
        Me.ToolStripMenuItem4.Text = "Prepare Sales Delivery"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Enabled = False
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(188, 22)
        Me.ToolStripMenuItem6.Text = "Cancel Sales Order"
        '
        'PrintDocument1
        '
        '
        'frmsales_list_selector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 271)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtSearch)
        Me.Name = "frmsales_list_selector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales List"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsSalesOrder.ResumeLayout(False)
        Me.cmsSalesQuotation.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblItemCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents cmsSalesOrder As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintJobOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrepareSalesCashInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrepareSalesChargeInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelSalesOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsSalesQuotation As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
