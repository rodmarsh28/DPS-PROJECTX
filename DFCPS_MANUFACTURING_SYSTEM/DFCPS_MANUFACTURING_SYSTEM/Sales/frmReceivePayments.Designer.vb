<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceivePayments
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblOutBalance = New System.Windows.Forms.Label()
        Me.lblTotalAmountReceived = New System.Windows.Forms.Label()
        Me.lblTotalAmountApplied = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPaymentNo = New System.Windows.Forms.TextBox()
        Me.groupCheck = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpcheckDate = New System.Windows.Forms.DateTimePicker()
        Me.txtChequeNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCheckAmount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.groupCash = New System.Windows.Forms.GroupBox()
        Me.txtCashAmount = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtAccountDesc = New System.Windows.Forms.TextBox()
        Me.txtDepositAcc = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.chkCheck = New System.Windows.Forms.CheckBox()
        Me.chkCash = New System.Windows.Forms.CheckBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtMemo = New System.Windows.Forms.RichTextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.lblDiscountAcc = New System.Windows.Forms.TextBox()
        Me.txtDiscountAcc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.txtCollection = New System.Windows.Forms.TextBox()
        Me.lblTotDiscount = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkCollection = New System.Windows.Forms.CheckBox()
        Me.groupCheck.SuspendLayout()
        Me.groupCash.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Enabled = False
        Me.txtCustomerName.Location = New System.Drawing.Point(111, 43)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(636, 20)
        Me.txtCustomerName.TabIndex = 65
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Costumer"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(749, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 21)
        Me.Button1.TabIndex = 66
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblOutBalance
        '
        Me.lblOutBalance.AutoSize = True
        Me.lblOutBalance.Location = New System.Drawing.Point(130, 500)
        Me.lblOutBalance.Name = "lblOutBalance"
        Me.lblOutBalance.Size = New System.Drawing.Size(28, 13)
        Me.lblOutBalance.TabIndex = 81
        Me.lblOutBalance.Text = "0.00"
        '
        'lblTotalAmountReceived
        '
        Me.lblTotalAmountReceived.AutoSize = True
        Me.lblTotalAmountReceived.Location = New System.Drawing.Point(130, 484)
        Me.lblTotalAmountReceived.Name = "lblTotalAmountReceived"
        Me.lblTotalAmountReceived.Size = New System.Drawing.Size(28, 13)
        Me.lblTotalAmountReceived.TabIndex = 80
        Me.lblTotalAmountReceived.Text = "0.00"
        '
        'lblTotalAmountApplied
        '
        Me.lblTotalAmountApplied.AutoSize = True
        Me.lblTotalAmountApplied.Location = New System.Drawing.Point(130, 451)
        Me.lblTotalAmountApplied.Name = "lblTotalAmountApplied"
        Me.lblTotalAmountApplied.Size = New System.Drawing.Size(28, 13)
        Me.lblTotalAmountApplied.TabIndex = 79
        Me.lblTotalAmountApplied.Text = "0.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 500)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Out Balance"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 484)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "Total Received"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 451)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 13)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "Total Amount Applied"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(691, 449)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(107, 48)
        Me.Button3.TabIndex = 83
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(575, 449)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 48)
        Me.Button2.TabIndex = 82
        Me.Button2.Text = "Record"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "NO."
        '
        'txtPaymentNo
        '
        Me.txtPaymentNo.Enabled = False
        Me.txtPaymentNo.ForeColor = System.Drawing.Color.Maroon
        Me.txtPaymentNo.Location = New System.Drawing.Point(112, 17)
        Me.txtPaymentNo.Name = "txtPaymentNo"
        Me.txtPaymentNo.Size = New System.Drawing.Size(122, 20)
        Me.txtPaymentNo.TabIndex = 88
        '
        'groupCheck
        '
        Me.groupCheck.Controls.Add(Me.Label8)
        Me.groupCheck.Controls.Add(Me.dtpcheckDate)
        Me.groupCheck.Controls.Add(Me.txtChequeNo)
        Me.groupCheck.Controls.Add(Me.Label7)
        Me.groupCheck.Controls.Add(Me.txtCheckAmount)
        Me.groupCheck.Controls.Add(Me.Label4)
        Me.groupCheck.Enabled = False
        Me.groupCheck.Location = New System.Drawing.Point(19, 169)
        Me.groupCheck.Name = "groupCheck"
        Me.groupCheck.Size = New System.Drawing.Size(425, 99)
        Me.groupCheck.TabIndex = 95
        Me.groupCheck.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Check Date"
        '
        'dtpcheckDate
        '
        Me.dtpcheckDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpcheckDate.Location = New System.Drawing.Point(104, 43)
        Me.dtpcheckDate.Name = "dtpcheckDate"
        Me.dtpcheckDate.Size = New System.Drawing.Size(275, 20)
        Me.dtpcheckDate.TabIndex = 99
        '
        'txtChequeNo
        '
        Me.txtChequeNo.Location = New System.Drawing.Point(104, 21)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(276, 20)
        Me.txtChequeNo.TabIndex = 97
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "Cheque No."
        '
        'txtCheckAmount
        '
        Me.txtCheckAmount.Location = New System.Drawing.Point(104, 65)
        Me.txtCheckAmount.Name = "txtCheckAmount"
        Me.txtCheckAmount.Size = New System.Drawing.Size(275, 20)
        Me.txtCheckAmount.TabIndex = 95
        Me.txtCheckAmount.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Check Amount"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Memo"
        '
        'groupCash
        '
        Me.groupCash.Controls.Add(Me.txtCashAmount)
        Me.groupCash.Controls.Add(Me.Label14)
        Me.groupCash.Enabled = False
        Me.groupCash.Location = New System.Drawing.Point(450, 170)
        Me.groupCash.Name = "groupCash"
        Me.groupCash.Size = New System.Drawing.Size(351, 98)
        Me.groupCash.TabIndex = 101
        Me.groupCash.TabStop = False
        '
        'txtCashAmount
        '
        Me.txtCashAmount.Location = New System.Drawing.Point(80, 21)
        Me.txtCashAmount.Name = "txtCashAmount"
        Me.txtCashAmount.Size = New System.Drawing.Size(241, 20)
        Me.txtCashAmount.TabIndex = 95
        Me.txtCashAmount.Text = "0.00"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Cash Amount"
        '
        'txtAccountDesc
        '
        Me.txtAccountDesc.Enabled = False
        Me.txtAccountDesc.Location = New System.Drawing.Point(575, 91)
        Me.txtAccountDesc.Name = "txtAccountDesc"
        Me.txtAccountDesc.Size = New System.Drawing.Size(172, 20)
        Me.txtAccountDesc.TabIndex = 100
        '
        'txtDepositAcc
        '
        Me.txtDepositAcc.Enabled = False
        Me.txtDepositAcc.Location = New System.Drawing.Point(575, 70)
        Me.txtDepositAcc.Name = "txtDepositAcc"
        Me.txtDepositAcc.Size = New System.Drawing.Size(172, 20)
        Me.txtDepositAcc.TabIndex = 97
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(520, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 26)
        Me.Label11.TabIndex = 99
        Me.Label11.Text = "Deposit to " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Account"
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Location = New System.Drawing.Point(749, 69)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(49, 41)
        Me.Button4.TabIndex = 98
        Me.Button4.Text = ">>"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'chkCheck
        '
        Me.chkCheck.AutoSize = True
        Me.chkCheck.Location = New System.Drawing.Point(19, 155)
        Me.chkCheck.Name = "chkCheck"
        Me.chkCheck.Size = New System.Drawing.Size(57, 17)
        Me.chkCheck.TabIndex = 102
        Me.chkCheck.Text = "Check"
        Me.chkCheck.UseVisualStyleBackColor = True
        '
        'chkCash
        '
        Me.chkCash.AutoSize = True
        Me.chkCash.Location = New System.Drawing.Point(450, 155)
        Me.chkCash.Name = "chkCash"
        Me.chkCash.Size = New System.Drawing.Size(50, 17)
        Me.chkCash.TabIndex = 103
        Me.chkCash.Text = "Cash"
        Me.chkCash.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column6, Me.Column7, Me.Column5, Me.Column8})
        Me.dgv.Location = New System.Drawing.Point(19, 304)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(782, 141)
        Me.dgv.TabIndex = 104
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "Invoice #"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "Status"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.Frozen = True
        Me.Column3.HeaderText = "Date"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 110
        '
        'Column4
        '
        Me.Column4.Frozen = True
        Me.Column4.HeaderText = "Amount"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.Frozen = True
        Me.Column6.HeaderText = "Discount"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Total Amount"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Amount Applied"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 110
        '
        'Column8
        '
        Me.Column8.HeaderText = "ReceivableAccount"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'txtMemo
        '
        Me.txtMemo.Location = New System.Drawing.Point(111, 67)
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(377, 85)
        Me.txtMemo.TabIndex = 105
        Me.txtMemo.Text = ""
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(772, 279)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(29, 19)
        Me.Button5.TabIndex = 106
        Me.Button5.Text = "-"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'lblDiscountAcc
        '
        Me.lblDiscountAcc.Enabled = False
        Me.lblDiscountAcc.Location = New System.Drawing.Point(575, 135)
        Me.lblDiscountAcc.Name = "lblDiscountAcc"
        Me.lblDiscountAcc.Size = New System.Drawing.Size(172, 20)
        Me.lblDiscountAcc.TabIndex = 110
        '
        'txtDiscountAcc
        '
        Me.txtDiscountAcc.Enabled = False
        Me.txtDiscountAcc.Location = New System.Drawing.Point(575, 114)
        Me.txtDiscountAcc.Name = "txtDiscountAcc"
        Me.txtDiscountAcc.Size = New System.Drawing.Size(172, 20)
        Me.txtDiscountAcc.TabIndex = 107
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(520, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 26)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "Discount" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Account"
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.Location = New System.Drawing.Point(749, 113)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(49, 41)
        Me.Button6.TabIndex = 108
        Me.Button6.Text = ">>"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'txtCollection
        '
        Me.txtCollection.ForeColor = System.Drawing.Color.Maroon
        Me.txtCollection.Location = New System.Drawing.Point(655, 17)
        Me.txtCollection.Name = "txtCollection"
        Me.txtCollection.Size = New System.Drawing.Size(143, 20)
        Me.txtCollection.TabIndex = 112
        Me.txtCollection.Visible = False
        '
        'lblTotDiscount
        '
        Me.lblTotDiscount.AutoSize = True
        Me.lblTotDiscount.Location = New System.Drawing.Point(130, 467)
        Me.lblTotDiscount.Name = "lblTotDiscount"
        Me.lblTotDiscount.Size = New System.Drawing.Size(28, 13)
        Me.lblTotDiscount.TabIndex = 114
        Me.lblTotDiscount.Text = "0.00"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 467)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 113
        Me.Label15.Text = "Total Discount"
        '
        'chkCollection
        '
        Me.chkCollection.AutoSize = True
        Me.chkCollection.Location = New System.Drawing.Point(557, 19)
        Me.chkCollection.Name = "chkCollection"
        Me.chkCollection.Size = New System.Drawing.Size(92, 17)
        Me.chkCollection.TabIndex = 115
        Me.chkCollection.Text = "Collection No."
        Me.chkCollection.UseVisualStyleBackColor = True
        '
        'frmReceivePayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(811, 526)
        Me.Controls.Add(Me.chkCollection)
        Me.Controls.Add(Me.lblTotDiscount)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtCollection)
        Me.Controls.Add(Me.lblDiscountAcc)
        Me.Controls.Add(Me.txtDiscountAcc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.txtAccountDesc)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.txtDepositAcc)
        Me.Controls.Add(Me.chkCash)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.chkCheck)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.groupCash)
        Me.Controls.Add(Me.groupCheck)
        Me.Controls.Add(Me.txtPaymentNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblOutBalance)
        Me.Controls.Add(Me.lblTotalAmountReceived)
        Me.Controls.Add(Me.lblTotalAmountApplied)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmReceivePayments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "   Receive Payments"
        Me.groupCheck.ResumeLayout(False)
        Me.groupCheck.PerformLayout()
        Me.groupCash.ResumeLayout(False)
        Me.groupCash.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblOutBalance As System.Windows.Forms.Label
    Friend WithEvents lblTotalAmountReceived As System.Windows.Forms.Label
    Friend WithEvents lblTotalAmountApplied As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentNo As System.Windows.Forms.TextBox
    Friend WithEvents groupCheck As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpcheckDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCheckAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents groupCash As System.Windows.Forms.GroupBox
    Friend WithEvents txtAccountDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtDepositAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtCashAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkCheck As System.Windows.Forms.CheckBox
    Friend WithEvents chkCash As System.Windows.Forms.CheckBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents txtMemo As System.Windows.Forms.RichTextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents lblDiscountAcc As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txtCollection As System.Windows.Forms.TextBox
    Friend WithEvents lblTotDiscount As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkCollection As System.Windows.Forms.CheckBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
