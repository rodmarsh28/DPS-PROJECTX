<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddItemsInventory
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItemno = New System.Windows.Forms.TextBox()
        Me.txtItemdesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkBuy = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblAccAsset = New System.Windows.Forms.TextBox()
        Me.lblAccIncome = New System.Windows.Forms.TextBox()
        Me.lblAccCost = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtAccAsset = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtAccIncome = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtAccCost = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkboxInactive = New System.Windows.Forms.CheckBox()
        Me.chkInv = New System.Windows.Forms.CheckBox()
        Me.chkSell = New System.Windows.Forms.CheckBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbItemType = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMinQTY = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBalQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPC = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtUnitCost = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item No."
        '
        'txtItemno
        '
        Me.txtItemno.Location = New System.Drawing.Point(73, 52)
        Me.txtItemno.Name = "txtItemno"
        Me.txtItemno.Size = New System.Drawing.Size(94, 20)
        Me.txtItemno.TabIndex = 1
        '
        'txtItemdesc
        '
        Me.txtItemdesc.Location = New System.Drawing.Point(73, 78)
        Me.txtItemdesc.Name = "txtItemdesc"
        Me.txtItemdesc.Size = New System.Drawing.Size(222, 20)
        Me.txtItemdesc.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Item Desc."
        '
        'chkBuy
        '
        Me.chkBuy.AutoSize = True
        Me.chkBuy.Location = New System.Drawing.Point(12, 227)
        Me.chkBuy.Name = "chkBuy"
        Me.chkBuy.Size = New System.Drawing.Size(90, 17)
        Me.chkBuy.TabIndex = 6
        Me.chkBuy.Text = "I buy this item"
        Me.chkBuy.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAccAsset)
        Me.GroupBox1.Controls.Add(Me.lblAccIncome)
        Me.GroupBox1.Controls.Add(Me.lblAccCost)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txtAccAsset)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.txtAccIncome)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtAccCost)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chkboxInactive)
        Me.GroupBox1.Controls.Add(Me.chkInv)
        Me.GroupBox1.Controls.Add(Me.chkSell)
        Me.GroupBox1.Controls.Add(Me.chkBuy)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(339, 272)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item Profile"
        '
        'lblAccAsset
        '
        Me.lblAccAsset.Enabled = False
        Me.lblAccAsset.Location = New System.Drawing.Point(79, 201)
        Me.lblAccAsset.Name = "lblAccAsset"
        Me.lblAccAsset.Size = New System.Drawing.Size(161, 20)
        Me.lblAccAsset.TabIndex = 19
        '
        'lblAccIncome
        '
        Me.lblAccIncome.Enabled = False
        Me.lblAccIncome.Location = New System.Drawing.Point(79, 155)
        Me.lblAccIncome.Name = "lblAccIncome"
        Me.lblAccIncome.Size = New System.Drawing.Size(161, 20)
        Me.lblAccIncome.TabIndex = 18
        '
        'lblAccCost
        '
        Me.lblAccCost.Enabled = False
        Me.lblAccCost.Location = New System.Drawing.Point(79, 110)
        Me.lblAccCost.Name = "lblAccCost"
        Me.lblAccCost.Size = New System.Drawing.Size(161, 20)
        Me.lblAccCost.TabIndex = 17
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Location = New System.Drawing.Point(241, 179)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(46, 42)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = ">>"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtAccAsset
        '
        Me.txtAccAsset.Enabled = False
        Me.txtAccAsset.Location = New System.Drawing.Point(79, 181)
        Me.txtAccAsset.Name = "txtAccAsset"
        Me.txtAccAsset.Size = New System.Drawing.Size(161, 20)
        Me.txtAccAsset.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 26)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Asset" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Account"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(241, 135)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(46, 40)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = ">>"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtAccIncome
        '
        Me.txtAccIncome.Enabled = False
        Me.txtAccIncome.Location = New System.Drawing.Point(79, 136)
        Me.txtAccIncome.Name = "txtAccIncome"
        Me.txtAccIncome.Size = New System.Drawing.Size(161, 20)
        Me.txtAccIncome.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 26)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Income" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Account"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(241, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 39)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtAccCost
        '
        Me.txtAccCost.Enabled = False
        Me.txtAccCost.Location = New System.Drawing.Point(79, 91)
        Me.txtAccCost.Name = "txtAccCost"
        Me.txtAccCost.Size = New System.Drawing.Size(161, 20)
        Me.txtAccCost.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 26)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Cost of Sales " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Account"
        '
        'chkboxInactive
        '
        Me.chkboxInactive.AutoSize = True
        Me.chkboxInactive.Location = New System.Drawing.Point(244, 17)
        Me.chkboxInactive.Name = "chkboxInactive"
        Me.chkboxInactive.Size = New System.Drawing.Size(86, 17)
        Me.chkboxInactive.TabIndex = 9
        Me.chkboxInactive.Text = "Inactive item"
        Me.chkboxInactive.UseVisualStyleBackColor = True
        '
        'chkInv
        '
        Me.chkInv.AutoSize = True
        Me.chkInv.Location = New System.Drawing.Point(204, 227)
        Me.chkInv.Name = "chkInv"
        Me.chkInv.Size = New System.Drawing.Size(117, 17)
        Me.chkInv.TabIndex = 8
        Me.chkInv.Text = "I Inventory this item"
        Me.chkInv.UseVisualStyleBackColor = True
        '
        'chkSell
        '
        Me.chkSell.AutoSize = True
        Me.chkSell.Location = New System.Drawing.Point(108, 227)
        Me.chkSell.Name = "chkSell"
        Me.chkSell.Size = New System.Drawing.Size(90, 17)
        Me.chkSell.TabIndex = 7
        Me.chkSell.Text = "I Sell this item"
        Me.chkSell.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Location = New System.Drawing.Point(84, 186)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(133, 61)
        Me.btnAdd.TabIndex = 17
        Me.btnAdd.Text = "ADD ITEM"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Location = New System.Drawing.Point(223, 186)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(133, 61)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Item Type"
        '
        'cmbItemType
        '
        Me.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItemType.FormattingEnabled = True
        Me.cmbItemType.Items.AddRange(New Object() {"Raw Materials", "Finish Product", "Item, Materials & Supplies"})
        Me.cmbItemType.Location = New System.Drawing.Point(72, 10)
        Me.cmbItemType.Name = "cmbItemType"
        Me.cmbItemType.Size = New System.Drawing.Size(167, 21)
        Me.cmbItemType.TabIndex = 26
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtMinQTY)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.btnClose)
        Me.GroupBox2.Controls.Add(Me.txtBalQty)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtPC)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtUnit)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtUnitPrice)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtUnitCost)
        Me.GroupBox2.Location = New System.Drawing.Point(348, 37)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 272)
        Me.GroupBox2.TabIndex = 117
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Unit of Measurement"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(200, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 131
        Me.Label11.Text = "Balance QTY"
        '
        'txtMinQTY
        '
        Me.txtMinQTY.Location = New System.Drawing.Point(282, 75)
        Me.txtMinQTY.Name = "txtMinQTY"
        Me.txtMinQTY.Size = New System.Drawing.Size(87, 20)
        Me.txtMinQTY.TabIndex = 130
        Me.txtMinQTY.Text = "0.00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(199, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 26)
        Me.Label12.TabIndex = 129
        Me.Label12.Text = "Minimum " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Stock Qty "
        '
        'txtBalQty
        '
        Me.txtBalQty.Location = New System.Drawing.Point(282, 42)
        Me.txtBalQty.Name = "txtBalQty"
        Me.txtBalQty.Size = New System.Drawing.Size(87, 20)
        Me.txtBalQty.TabIndex = 128
        Me.txtBalQty.Text = "0.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "UOM"
        '
        'txtPC
        '
        Me.txtPC.Location = New System.Drawing.Point(97, 75)
        Me.txtPC.Name = "txtPC"
        Me.txtPC.Size = New System.Drawing.Size(87, 20)
        Me.txtPC.TabIndex = 126
        Me.txtPC.Text = "0.00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 26)
        Me.Label8.TabIndex = 125
        Me.Label8.Text = "PC QTY " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Optional)"
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(97, 42)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(87, 20)
        Me.txtUnit.TabIndex = 124
        Me.txtUnit.Text = "0.00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 121
        Me.Label9.Text = "Unit Cost"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Location = New System.Drawing.Point(282, 111)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(87, 20)
        Me.txtUnitPrice.TabIndex = 120
        Me.txtUnitPrice.Text = "0.00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(201, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 119
        Me.Label10.Text = "Unit Price"
        '
        'txtUnitCost
        '
        Me.txtUnitCost.Location = New System.Drawing.Point(97, 111)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(87, 20)
        Me.txtUnitCost.TabIndex = 118
        Me.txtUnitCost.Text = "0.00"
        '
        'frmAddItemsInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(783, 328)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmbItemType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtItemdesc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtItemno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmAddItemsInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Inventory Items"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItemno As System.Windows.Forms.TextBox
    Friend WithEvents txtItemdesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkBuy As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtAccAsset As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtAccIncome As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtAccCost As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkboxInactive As System.Windows.Forms.CheckBox
    Friend WithEvents chkInv As System.Windows.Forms.CheckBox
    Friend WithEvents chkSell As System.Windows.Forms.CheckBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbItemType As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccAsset As System.Windows.Forms.TextBox
    Friend WithEvents lblAccIncome As System.Windows.Forms.TextBox
    Friend WithEvents lblAccCost As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMinQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBalQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtPC As System.Windows.Forms.TextBox
End Class
