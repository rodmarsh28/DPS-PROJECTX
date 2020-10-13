<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TViewer
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
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.cmsPA = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApproveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrepareCheckPrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintCheckVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPA.SuspendLayout()
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
        'cmsPA
        '
        Me.cmsPA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem9, Me.ApproveToolStripMenuItem1, Me.PrepareCheckPrintToolStripMenuItem, Me.PrintCheckVoucherToolStripMenuItem})
        Me.cmsPA.Name = "cmsCV"
        Me.cmsPA.Size = New System.Drawing.Size(258, 92)
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(257, 22)
        Me.ToolStripMenuItem9.Text = "View Transaction"
        '
        'ApproveToolStripMenuItem1
        '
        Me.ApproveToolStripMenuItem1.Name = "ApproveToolStripMenuItem1"
        Me.ApproveToolStripMenuItem1.Size = New System.Drawing.Size(257, 22)
        Me.ApproveToolStripMenuItem1.Text = "Approve"
        '
        'PrepareCheckPrintToolStripMenuItem
        '
        Me.PrepareCheckPrintToolStripMenuItem.Name = "PrepareCheckPrintToolStripMenuItem"
        Me.PrepareCheckPrintToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.PrepareCheckPrintToolStripMenuItem.Text = "Request for information correction"
        '
        'PrintCheckVoucherToolStripMenuItem
        '
        Me.PrintCheckVoucherToolStripMenuItem.Name = "PrintCheckVoucherToolStripMenuItem"
        Me.PrintCheckVoucherToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.PrintCheckVoucherToolStripMenuItem.Text = "Disapproved"
        '
        'TViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 405)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.txtSearch)
        Me.Name = "TViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TRANSACTION LIST'S"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPA.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents cmsPA As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApproveToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrepareCheckPrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintCheckVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
