<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckPrint
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
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.txtTotAmount = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCheckbookID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCheckno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtpCheckDate = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtPayee = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "REFERENCE NO."
        '
        'txtRefNo
        '
        Me.txtRefNo.Enabled = False
        Me.txtRefNo.Location = New System.Drawing.Point(123, 26)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(198, 20)
        Me.txtRefNo.TabIndex = 1
        '
        'txtTotAmount
        '
        Me.txtTotAmount.Enabled = False
        Me.txtTotAmount.Location = New System.Drawing.Point(123, 82)
        Me.txtTotAmount.Name = "txtTotAmount"
        Me.txtTotAmount.Size = New System.Drawing.Size(198, 20)
        Me.txtTotAmount.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "TOTAL AMOUNT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "DATE OF CHECK"
        '
        'txtBankName
        '
        Me.txtBankName.Enabled = False
        Me.txtBankName.Location = New System.Drawing.Point(123, 108)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(198, 20)
        Me.txtBankName.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "BANK NAME"
        '
        'txtCheckbookID
        '
        Me.txtCheckbookID.Enabled = False
        Me.txtCheckbookID.Location = New System.Drawing.Point(123, 134)
        Me.txtCheckbookID.Name = "txtCheckbookID"
        Me.txtCheckbookID.Size = New System.Drawing.Size(164, 20)
        Me.txtCheckbookID.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "CHECKBOOK ID"
        '
        'txtCheckno
        '
        Me.txtCheckno.Location = New System.Drawing.Point(123, 160)
        Me.txtCheckno.Name = "txtCheckno"
        Me.txtCheckno.Size = New System.Drawing.Size(198, 20)
        Me.txtCheckno.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "CHECK NO."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(290, 132)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCheckDate.Location = New System.Drawing.Point(123, 248)
        Me.dtpCheckDate.Name = "dtpCheckDate"
        Me.dtpCheckDate.Size = New System.Drawing.Size(113, 20)
        Me.dtpCheckDate.TabIndex = 13
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(135, 287)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 36)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Print"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtPayee
        '
        Me.txtPayee.Enabled = False
        Me.txtPayee.Location = New System.Drawing.Point(123, 56)
        Me.txtPayee.Name = "txtPayee"
        Me.txtPayee.Size = New System.Drawing.Size(198, 20)
        Me.txtPayee.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "PAYEE"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "REMARKS"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(123, 188)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(198, 54)
        Me.txtRemarks.TabIndex = 18
        Me.txtRemarks.Text = ""
        '
        'frmCheckPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(351, 339)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPayee)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dtpCheckDate)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtCheckno)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCheckbookID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBankName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTotAmount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheckPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Check Print"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCheckbookID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCheckno As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dtpCheckDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtPayee As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.RichTextBox
End Class
