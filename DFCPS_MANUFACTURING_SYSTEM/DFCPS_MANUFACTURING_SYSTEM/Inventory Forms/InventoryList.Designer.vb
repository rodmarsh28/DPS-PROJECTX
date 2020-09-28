<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryList
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnNewItem = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblItemsCount = New System.Windows.Forms.Label()
        Me.Item_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sell_Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Onhand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IncomeAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssetAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item_No, Me.Description, Me.Unit, Me.Sell_Price, Me.Onhand, Me.CostAccount, Me.IncomeAccount, Me.AssetAccount, Me.Column1})
        Me.dgv.Location = New System.Drawing.Point(12, 36)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(863, 259)
        Me.dgv.TabIndex = 6
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(13, 10)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(862, 20)
        Me.txtSearch.TabIndex = 7
        '
        'btnNewItem
        '
        Me.btnNewItem.Location = New System.Drawing.Point(13, 301)
        Me.btnNewItem.Name = "btnNewItem"
        Me.btnNewItem.Size = New System.Drawing.Size(83, 30)
        Me.btnNewItem.TabIndex = 8
        Me.btnNewItem.Text = "New Item"
        Me.btnNewItem.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(749, 307)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Item's Count:"
        '
        'lblItemsCount
        '
        Me.lblItemsCount.AutoSize = True
        Me.lblItemsCount.Location = New System.Drawing.Point(823, 307)
        Me.lblItemsCount.Name = "lblItemsCount"
        Me.lblItemsCount.Size = New System.Drawing.Size(13, 13)
        Me.lblItemsCount.TabIndex = 10
        Me.lblItemsCount.Text = "0"
        '
        'Item_No
        '
        Me.Item_No.HeaderText = "Item No."
        Me.Item_No.Name = "Item_No"
        Me.Item_No.ReadOnly = True
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 350
        '
        'Unit
        '
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        '
        'Sell_Price
        '
        Me.Sell_Price.HeaderText = "Sell Price"
        Me.Sell_Price.Name = "Sell_Price"
        Me.Sell_Price.ReadOnly = True
        Me.Sell_Price.Width = 120
        '
        'Onhand
        '
        Me.Onhand.HeaderText = "Onhand"
        Me.Onhand.Name = "Onhand"
        Me.Onhand.ReadOnly = True
        '
        'CostAccount
        '
        Me.CostAccount.HeaderText = "CostAccount"
        Me.CostAccount.Name = "CostAccount"
        Me.CostAccount.ReadOnly = True
        Me.CostAccount.Visible = False
        '
        'IncomeAccount
        '
        Me.IncomeAccount.HeaderText = "IncomeAccount"
        Me.IncomeAccount.Name = "IncomeAccount"
        Me.IncomeAccount.ReadOnly = True
        Me.IncomeAccount.Visible = False
        '
        'AssetAccount
        '
        Me.AssetAccount.HeaderText = "AssetAccount"
        Me.AssetAccount.Name = "AssetAccount"
        Me.AssetAccount.ReadOnly = True
        Me.AssetAccount.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cost"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'InventoryList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 343)
        Me.Controls.Add(Me.lblItemsCount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnNewItem)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.dgv)
        Me.Name = "InventoryList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InventoryList"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnNewItem As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblItemsCount As System.Windows.Forms.Label
    Friend WithEvents Item_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sell_Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Onhand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostAccount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IncomeAccount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssetAccount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
