<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesTransactionViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesTransactionViewer))
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblItemCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.cmsCashInvoice = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.tmsPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmsUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmsJobFinished = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmsCancelJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsJobOrder = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsDeliver = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsChargeInvoice = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDeliveryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsSalesOrder.SuspendLayout()
        Me.cmsSalesQuotation.SuspendLayout()
        Me.cmsCashInvoice.SuspendLayout()
        Me.cmsJobOrder.SuspendLayout()
        Me.cmsDeliver.SuspendLayout()
        Me.cmsChargeInvoice.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(12, 5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(712, 20)
        Me.txtSearch.TabIndex = 14
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblItemCount, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 383)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(740, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(101, 17)
        Me.ToolStripStatusLabel1.Text = "Total Item Count :"
        '
        'lblItemCount
        '
        Me.lblItemCount.Name = "lblItemCount"
        Me.lblItemCount.Size = New System.Drawing.Size(13, 17)
        Me.lblItemCount.Text = "0"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripStatusLabel2.Image = CType(resources.GetObject("ToolStripStatusLabel2.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(16, 17)
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
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV.BackgroundColor = System.Drawing.Color.White
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 29)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV.Size = New System.Drawing.Size(712, 351)
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
        Me.PrintJobOrderToolStripMenuItem.Text = "Prepare Job Order"
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
        Me.CancelSalesOrderToolStripMenuItem.Name = "CancelSalesOrderToolStripMenuItem"
        Me.CancelSalesOrderToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.CancelSalesOrderToolStripMenuItem.Text = "Cancel Sales Order"
        '
        'cmsSalesQuotation
        '
        Me.cmsSalesQuotation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.UpdateToolStripMenuItem, Me.CancelToolStripMenuItem})
        Me.cmsSalesQuotation.Name = "cmsSalesOrder"
        Me.cmsSalesQuotation.Size = New System.Drawing.Size(168, 70)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.ToolStripMenuItem1.Text = "Print"
        '
        'cmsCashInvoice
        '
        Me.cmsCashInvoice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem4, Me.CancelInvoiceToolStripMenuItem})
        Me.cmsCashInvoice.Name = "cmsSalesOrder"
        Me.cmsCashInvoice.Size = New System.Drawing.Size(189, 70)
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
        'CancelInvoiceToolStripMenuItem
        '
        Me.CancelInvoiceToolStripMenuItem.Name = "CancelInvoiceToolStripMenuItem"
        Me.CancelInvoiceToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.CancelInvoiceToolStripMenuItem.Text = "Cancel Invoice"
        '
        'PrintDocument1
        '
        '
        'tmsPrint
        '
        Me.tmsPrint.Name = "tmsPrint"
        Me.tmsPrint.Size = New System.Drawing.Size(152, 22)
        Me.tmsPrint.Text = "Print"
        '
        'tmsUpdate
        '
        Me.tmsUpdate.Name = "tmsUpdate"
        Me.tmsUpdate.Size = New System.Drawing.Size(152, 22)
        Me.tmsUpdate.Text = "Update"
        '
        'tmsJobFinished
        '
        Me.tmsJobFinished.Name = "tmsJobFinished"
        Me.tmsJobFinished.Size = New System.Drawing.Size(152, 22)
        Me.tmsJobFinished.Text = "Job Finished"
        '
        'tmsCancelJob
        '
        Me.tmsCancelJob.Name = "tmsCancelJob"
        Me.tmsCancelJob.Size = New System.Drawing.Size(152, 22)
        Me.tmsCancelJob.Text = "Cancel Job"
        '
        'cmsJobOrder
        '
        Me.cmsJobOrder.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmsPrint, Me.tmsUpdate, Me.tmsJobFinished, Me.tmsCancelJob})
        Me.cmsJobOrder.Name = "cmsSalesOrder"
        Me.cmsJobOrder.Size = New System.Drawing.Size(140, 92)
        '
        'cmsDeliver
        '
        Me.cmsDeliver.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintDeliveryToolStripMenuItem, Me.ToolStripMenuItem3, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7})
        Me.cmsDeliver.Name = "cmsSalesOrder"
        Me.cmsDeliver.Size = New System.Drawing.Size(191, 136)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(190, 22)
        Me.ToolStripMenuItem3.Text = "Print DR and Gatepass"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(190, 22)
        Me.ToolStripMenuItem5.Text = "Update"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(190, 22)
        Me.ToolStripMenuItem6.Text = "Cancel Delivery"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Enabled = False
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(190, 22)
        Me.ToolStripMenuItem7.Text = "Cancel Invoice"
        '
        'cmsChargeInvoice
        '
        Me.cmsChargeInvoice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem8, Me.ToolStripMenuItem10, Me.ToolStripMenuItem11})
        Me.cmsChargeInvoice.Name = "cmsSalesOrder"
        Me.cmsChargeInvoice.Size = New System.Drawing.Size(189, 70)
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(188, 22)
        Me.ToolStripMenuItem8.Text = "Print"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(188, 22)
        Me.ToolStripMenuItem10.Text = "Prepare Sales Delivery"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(188, 22)
        Me.ToolStripMenuItem11.Text = "Cancel Invoice"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.CancelToolStripMenuItem.Text = "Cancel Quotation"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'PrintDeliveryToolStripMenuItem
        '
        Me.PrintDeliveryToolStripMenuItem.Name = "PrintDeliveryToolStripMenuItem"
        Me.PrintDeliveryToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.PrintDeliveryToolStripMenuItem.Text = "Print Delivery"
        '
        'SalesTransactionViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 405)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtSearch)
        Me.Name = "SalesTransactionViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales Transaction Viewer"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsSalesOrder.ResumeLayout(False)
        Me.cmsSalesQuotation.ResumeLayout(False)
        Me.cmsCashInvoice.ResumeLayout(False)
        Me.cmsJobOrder.ResumeLayout(False)
        Me.cmsDeliver.ResumeLayout(False)
        Me.cmsChargeInvoice.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblItemCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
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
    Friend WithEvents cmsCashInvoice As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents CancelInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmsPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmsUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmsJobFinished As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmsCancelJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsJobOrder As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsDeliver As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsChargeInvoice As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDeliveryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
