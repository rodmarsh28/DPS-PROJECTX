<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransactionViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransactionViewer))
        Me.LV = New System.Windows.Forms.ListView()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblItemCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmsRequisition = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpdateRequisitionSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IssueRequisitionSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreparePurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintRequisitionSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.disable_context = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsPurchaseOrder = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsRFP = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsCV = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApproveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrepareCheckPrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintCheckVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsCashRequisition = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApproveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrepareCheckVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintCashCheckRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.StatusStrip1.SuspendLayout()
        Me.cmsRequisition.SuspendLayout()
        Me.cmsPurchaseOrder.SuspendLayout()
        Me.cmsRFP.SuspendLayout()
        Me.cmsCV.SuspendLayout()
        Me.cmsCashRequisition.SuspendLayout()
        Me.SuspendLayout()
        '
        'LV
        '
        Me.LV.AllowColumnReorder = True
        Me.LV.FullRowSelect = True
        Me.LV.GridLines = True
        Me.LV.Location = New System.Drawing.Point(12, 38)
        Me.LV.MultiSelect = False
        Me.LV.Name = "LV"
        Me.LV.Size = New System.Drawing.Size(712, 329)
        Me.LV.TabIndex = 15
        Me.LV.UseCompatibleStateImageBehavior = False
        Me.LV.View = System.Windows.Forms.View.Details
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(12, 12)
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
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(102, 17)
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
        'cmsRequisition
        '
        Me.cmsRequisition.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateRequisitionSlipToolStripMenuItem, Me.IssueRequisitionSlipToolStripMenuItem, Me.PreparePurchaseOrderToolStripMenuItem, Me.CancelToolStripMenuItem, Me.PrintRequisitionSlipToolStripMenuItem})
        Me.cmsRequisition.Name = "cmsRequisition"
        Me.cmsRequisition.Size = New System.Drawing.Size(199, 114)
        '
        'UpdateRequisitionSlipToolStripMenuItem
        '
        Me.UpdateRequisitionSlipToolStripMenuItem.Name = "UpdateRequisitionSlipToolStripMenuItem"
        Me.UpdateRequisitionSlipToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.UpdateRequisitionSlipToolStripMenuItem.Text = "Update Requisition"
        '
        'IssueRequisitionSlipToolStripMenuItem
        '
        Me.IssueRequisitionSlipToolStripMenuItem.Name = "IssueRequisitionSlipToolStripMenuItem"
        Me.IssueRequisitionSlipToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.IssueRequisitionSlipToolStripMenuItem.Text = "Prepare Issuance"
        '
        'PreparePurchaseOrderToolStripMenuItem
        '
        Me.PreparePurchaseOrderToolStripMenuItem.Name = "PreparePurchaseOrderToolStripMenuItem"
        Me.PreparePurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.PreparePurchaseOrderToolStripMenuItem.Text = "Prepare Purchase Order"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.CancelToolStripMenuItem.Text = "Cancel Requisition"
        '
        'PrintRequisitionSlipToolStripMenuItem
        '
        Me.PrintRequisitionSlipToolStripMenuItem.Name = "PrintRequisitionSlipToolStripMenuItem"
        Me.PrintRequisitionSlipToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.PrintRequisitionSlipToolStripMenuItem.Text = "Print Requisition Slip"
        '
        'disable_context
        '
        Me.disable_context.Name = "disable_context"
        Me.disable_context.Size = New System.Drawing.Size(61, 4)
        '
        'cmsPurchaseOrder
        '
        Me.cmsPurchaseOrder.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem4, Me.PrintSlipToolStripMenuItem})
        Me.cmsPurchaseOrder.Name = "cmsRequisition"
        Me.cmsPurchaseOrder.Size = New System.Drawing.Size(219, 92)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(218, 22)
        Me.ToolStripMenuItem1.Text = "Update Purchase Order Slip"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(218, 22)
        Me.ToolStripMenuItem2.Text = "Received Purchased Items"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(218, 22)
        Me.ToolStripMenuItem4.Text = "Cancel Purchase Order"
        '
        'PrintSlipToolStripMenuItem
        '
        Me.PrintSlipToolStripMenuItem.Name = "PrintSlipToolStripMenuItem"
        Me.PrintSlipToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.PrintSlipToolStripMenuItem.Text = "Print Purchase Order Slip"
        '
        'cmsRFP
        '
        Me.cmsRFP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.PrintRequisitionToolStripMenuItem})
        Me.cmsRFP.Name = "cmsRequisition"
        Me.cmsRFP.Size = New System.Drawing.Size(234, 48)
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(233, 22)
        Me.ToolStripMenuItem5.Text = "Prepare Check / Cash Voucher"
        '
        'PrintRequisitionToolStripMenuItem
        '
        Me.PrintRequisitionToolStripMenuItem.Name = "PrintRequisitionToolStripMenuItem"
        Me.PrintRequisitionToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.PrintRequisitionToolStripMenuItem.Text = "Print Cash Requisition"
        '
        'cmsCV
        '
        Me.cmsCV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateToolStripMenuItem, Me.ApproveToolStripMenuItem1, Me.PrepareCheckPrintToolStripMenuItem, Me.PrintCheckVoucherToolStripMenuItem})
        Me.cmsCV.Name = "cmsCV"
        Me.cmsCV.Size = New System.Drawing.Size(182, 92)
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'ApproveToolStripMenuItem1
        '
        Me.ApproveToolStripMenuItem1.Name = "ApproveToolStripMenuItem1"
        Me.ApproveToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ApproveToolStripMenuItem1.Text = "Approve"
        '
        'PrepareCheckPrintToolStripMenuItem
        '
        Me.PrepareCheckPrintToolStripMenuItem.Name = "PrepareCheckPrintToolStripMenuItem"
        Me.PrepareCheckPrintToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.PrepareCheckPrintToolStripMenuItem.Text = "Issue Cash /  Check "
        '
        'PrintCheckVoucherToolStripMenuItem
        '
        Me.PrintCheckVoucherToolStripMenuItem.Name = "PrintCheckVoucherToolStripMenuItem"
        Me.PrintCheckVoucherToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.PrintCheckVoucherToolStripMenuItem.Text = "Print Check Voucher"
        '
        'cmsCashRequisition
        '
        Me.cmsCashRequisition.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ApproveToolStripMenuItem, Me.PrepareCheckVoucherToolStripMenuItem, Me.PrintCashCheckRequisitionToolStripMenuItem})
        Me.cmsCashRequisition.Name = "cmsCV"
        Me.cmsCashRequisition.Size = New System.Drawing.Size(235, 92)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(234, 22)
        Me.ToolStripMenuItem3.Text = "Update"
        '
        'ApproveToolStripMenuItem
        '
        Me.ApproveToolStripMenuItem.Name = "ApproveToolStripMenuItem"
        Me.ApproveToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.ApproveToolStripMenuItem.Text = "Approve"
        '
        'PrepareCheckVoucherToolStripMenuItem
        '
        Me.PrepareCheckVoucherToolStripMenuItem.Name = "PrepareCheckVoucherToolStripMenuItem"
        Me.PrepareCheckVoucherToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.PrepareCheckVoucherToolStripMenuItem.Text = "Prepare Check Voucher"
        '
        'PrintCashCheckRequisitionToolStripMenuItem
        '
        Me.PrintCashCheckRequisitionToolStripMenuItem.Name = "PrintCashCheckRequisitionToolStripMenuItem"
        Me.PrintCashCheckRequisitionToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.PrintCashCheckRequisitionToolStripMenuItem.Text = "Print Cash / Check Requisition"
        '
        'Timer1
        '
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
        'TransactionViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 405)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.LV)
        Me.Controls.Add(Me.txtSearch)
        Me.Name = "TransactionViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TransactionViewer"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.cmsRequisition.ResumeLayout(False)
        Me.cmsPurchaseOrder.ResumeLayout(False)
        Me.cmsRFP.ResumeLayout(False)
        Me.cmsCV.ResumeLayout(False)
        Me.cmsCashRequisition.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LV As System.Windows.Forms.ListView
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblItemCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmsRequisition As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UpdateRequisitionSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IssueRequisitionSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreparePurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents disable_context As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintRequisitionSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPurchaseOrder As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmsRFP As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintRequisitionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsCV As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrepareCheckPrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsCashRequisition As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApproveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PrintCheckVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintCashCheckRequisitionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApproveToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrepareCheckVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
End Class
