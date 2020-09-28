<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardProfile
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkboxInactiveCard = New System.Windows.Forms.CheckBox()
        Me.txtCardNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCardCN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCardAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCardName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbDesignation = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCardType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCardCreditLimit = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkAllowCredit = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkboxInactiveCard)
        Me.GroupBox1.Controls.Add(Me.txtCardNo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCardCN)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCardAddress)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCardName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbDesignation)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCardType)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 201)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information"
        '
        'chkboxInactiveCard
        '
        Me.chkboxInactiveCard.AutoSize = True
        Me.chkboxInactiveCard.Location = New System.Drawing.Point(274, 25)
        Me.chkboxInactiveCard.Name = "chkboxInactiveCard"
        Me.chkboxInactiveCard.Size = New System.Drawing.Size(89, 17)
        Me.chkboxInactiveCard.TabIndex = 22
        Me.chkboxInactiveCard.Text = "Inactive Card"
        Me.chkboxInactiveCard.UseVisualStyleBackColor = True
        '
        'txtCardNo
        '
        Me.txtCardNo.Location = New System.Drawing.Point(109, 79)
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.Size = New System.Drawing.Size(255, 20)
        Me.txtCardNo.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(40, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Card #"
        '
        'txtCardCN
        '
        Me.txtCardCN.Location = New System.Drawing.Point(109, 156)
        Me.txtCardCN.Name = "txtCardCN"
        Me.txtCardCN.Size = New System.Drawing.Size(255, 20)
        Me.txtCardCN.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Contact #"
        '
        'txtCardAddress
        '
        Me.txtCardAddress.Location = New System.Drawing.Point(109, 130)
        Me.txtCardAddress.Name = "txtCardAddress"
        Me.txtCardAddress.Size = New System.Drawing.Size(255, 20)
        Me.txtCardAddress.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Address"
        '
        'txtCardName
        '
        Me.txtCardName.Location = New System.Drawing.Point(109, 104)
        Me.txtCardName.Name = "txtCardName"
        Me.txtCardName.Size = New System.Drawing.Size(255, 20)
        Me.txtCardName.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Name"
        '
        'cmbDesignation
        '
        Me.cmbDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDesignation.FormattingEnabled = True
        Me.cmbDesignation.Items.AddRange(New Object() {"Company", "Individual"})
        Me.cmbDesignation.Location = New System.Drawing.Point(109, 52)
        Me.cmbDesignation.Name = "cmbDesignation"
        Me.cmbDesignation.Size = New System.Drawing.Size(139, 21)
        Me.cmbDesignation.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Designation"
        '
        'cmbCardType
        '
        Me.cmbCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCardType.FormattingEnabled = True
        Me.cmbCardType.Items.AddRange(New Object() {"Customer", "Supplier", "Employee"})
        Me.cmbCardType.Location = New System.Drawing.Point(109, 25)
        Me.cmbCardType.Name = "cmbCardType"
        Me.cmbCardType.Size = New System.Drawing.Size(139, 21)
        Me.cmbCardType.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Card Type"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCardCreditLimit)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.chkAllowCredit)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 219)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 70)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Credit Information"
        '
        'txtCardCreditLimit
        '
        Me.txtCardCreditLimit.Location = New System.Drawing.Point(183, 27)
        Me.txtCardCreditLimit.Name = "txtCardCreditLimit"
        Me.txtCardCreditLimit.Size = New System.Drawing.Size(181, 20)
        Me.txtCardCreditLimit.TabIndex = 21
        Me.txtCardCreditLimit.Text = "0.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(121, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Credit Limit"
        '
        'chkAllowCredit
        '
        Me.chkAllowCredit.AutoSize = True
        Me.chkAllowCredit.Location = New System.Drawing.Point(25, 29)
        Me.chkAllowCredit.Name = "chkAllowCredit"
        Me.chkAllowCredit.Size = New System.Drawing.Size(90, 17)
        Me.chkAllowCredit.TabIndex = 12
        Me.chkAllowCredit.Text = "Allow Credit ?"
        Me.chkAllowCredit.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(218, 307)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(93, 41)
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(117, 307)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(93, 41)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'CardProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(429, 365)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "CardProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Card Profile"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCardCN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCardName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDesignation As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCardType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCardCreditLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkAllowCredit As System.Windows.Forms.CheckBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkboxInactiveCard As System.Windows.Forms.CheckBox
    Friend WithEvents txtCardAddress As System.Windows.Forms.TextBox
End Class
