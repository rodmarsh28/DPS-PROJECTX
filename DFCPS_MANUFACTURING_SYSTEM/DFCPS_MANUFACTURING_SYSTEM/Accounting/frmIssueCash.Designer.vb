<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIssueCash
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
        Me.lblAccAsset = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtAccAsset = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.REFNO = New System.Windows.Forms.Label()
        Me.txtRefNo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblAccAsset
        '
        Me.lblAccAsset.Enabled = False
        Me.lblAccAsset.Location = New System.Drawing.Point(12, 102)
        Me.lblAccAsset.Name = "lblAccAsset"
        Me.lblAccAsset.Size = New System.Drawing.Size(159, 20)
        Me.lblAccAsset.TabIndex = 37
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Location = New System.Drawing.Point(174, 83)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(46, 39)
        Me.Button3.TabIndex = 36
        Me.Button3.Text = ">>"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtAccAsset
        '
        Me.txtAccAsset.Enabled = False
        Me.txtAccAsset.Location = New System.Drawing.Point(12, 83)
        Me.txtAccAsset.Name = "txtAccAsset"
        Me.txtAccAsset.Size = New System.Drawing.Size(159, 20)
        Me.txtAccAsset.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Asset Account Link"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Amount"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(12, 188)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(208, 20)
        Me.txtAmount.TabIndex = 39
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(68, 221)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 33)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "Issue"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'REFNO
        '
        Me.REFNO.AutoSize = True
        Me.REFNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.REFNO.Location = New System.Drawing.Point(12, 19)
        Me.REFNO.Name = "REFNO"
        Me.REFNO.Size = New System.Drawing.Size(120, 16)
        Me.REFNO.TabIndex = 41
        Me.REFNO.Text = "Reference No. : "
        '
        'txtRefNo
        '
        Me.txtRefNo.AutoSize = True
        Me.txtRefNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRefNo.Location = New System.Drawing.Point(125, 20)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(73, 16)
        Me.txtRefNo.TabIndex = 42
        Me.txtRefNo.Text = "CV-00000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Memo"
        '
        'txtMemo
        '
        Me.txtMemo.Location = New System.Drawing.Point(11, 148)
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(209, 20)
        Me.txtMemo.TabIndex = 44
        '
        'frmIssueCash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(237, 275)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.REFNO)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblAccAsset)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txtAccAsset)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIssueCash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Issuance"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAccAsset As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtAccAsset As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents REFNO As System.Windows.Forms.Label
    Friend WithEvents txtRefNo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
End Class
