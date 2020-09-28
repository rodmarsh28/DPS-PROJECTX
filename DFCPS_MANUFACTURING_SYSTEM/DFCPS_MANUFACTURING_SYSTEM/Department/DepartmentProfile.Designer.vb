<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DepartmentProfile
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
        Me.chkboxInactiveDept = New System.Windows.Forms.CheckBox()
        Me.txtDeptNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDept = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblAccTax = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.txtAccTax = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblExpBenifits = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtExpBenifits = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLaborCostAcc = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtLaborCostAcc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAccPH = New System.Windows.Forms.TextBox()
        Me.lblAccHDMF = New System.Windows.Forms.TextBox()
        Me.lblAccSSS = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtAccPH = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtAccHDMF = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtAccSSS = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkboxInactiveDept)
        Me.GroupBox1.Controls.Add(Me.txtDeptNo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtDept)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 91)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information"
        '
        'chkboxInactiveDept
        '
        Me.chkboxInactiveDept.AutoSize = True
        Me.chkboxInactiveDept.Location = New System.Drawing.Point(239, 26)
        Me.chkboxInactiveDept.Name = "chkboxInactiveDept"
        Me.chkboxInactiveDept.Size = New System.Drawing.Size(122, 17)
        Me.chkboxInactiveDept.TabIndex = 22
        Me.chkboxInactiveDept.Text = "Inactive Department"
        Me.chkboxInactiveDept.UseVisualStyleBackColor = True
        '
        'txtDeptNo
        '
        Me.txtDeptNo.Enabled = False
        Me.txtDeptNo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDeptNo.Location = New System.Drawing.Point(114, 24)
        Me.txtDeptNo.Name = "txtDeptNo"
        Me.txtDeptNo.Size = New System.Drawing.Size(115, 20)
        Me.txtDeptNo.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Department No"
        '
        'txtDept
        '
        Me.txtDept.Location = New System.Drawing.Point(114, 49)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(239, 20)
        Me.txtDept.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Department"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblAccTax)
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.txtAccTax)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblExpBenifits)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.txtExpBenifits)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblLaborCostAcc)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.txtLaborCostAcc)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblAccPH)
        Me.GroupBox2.Controls.Add(Me.lblAccHDMF)
        Me.GroupBox2.Controls.Add(Me.lblAccSSS)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.txtAccPH)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.txtAccHDMF)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.txtAccSSS)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 361)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Account Information"
        '
        'lblAccTax
        '
        Me.lblAccTax.Enabled = False
        Me.lblAccTax.Location = New System.Drawing.Point(114, 191)
        Me.lblAccTax.Name = "lblAccTax"
        Me.lblAccTax.Size = New System.Drawing.Size(208, 20)
        Me.lblAccTax.TabIndex = 43
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.Location = New System.Drawing.Point(328, 169)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(46, 42)
        Me.Button6.TabIndex = 42
        Me.Button6.Text = ">>"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'txtAccTax
        '
        Me.txtAccTax.Enabled = False
        Me.txtAccTax.Location = New System.Drawing.Point(114, 171)
        Me.txtAccTax.Name = "txtAccTax"
        Me.txtAccTax.Size = New System.Drawing.Size(208, 20)
        Me.txtAccTax.TabIndex = 41
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 26)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Withholding" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Tax Account"
        '
        'lblExpBenifits
        '
        Me.lblExpBenifits.Enabled = False
        Me.lblExpBenifits.Location = New System.Drawing.Point(114, 238)
        Me.lblExpBenifits.Name = "lblExpBenifits"
        Me.lblExpBenifits.Size = New System.Drawing.Size(208, 20)
        Me.lblExpBenifits.TabIndex = 39
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Location = New System.Drawing.Point(328, 216)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(46, 42)
        Me.Button5.TabIndex = 38
        Me.Button5.Text = ">>"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtExpBenifits
        '
        Me.txtExpBenifits.Enabled = False
        Me.txtExpBenifits.Location = New System.Drawing.Point(114, 218)
        Me.txtExpBenifits.Name = "txtExpBenifits"
        Me.txtExpBenifits.Size = New System.Drawing.Size(208, 20)
        Me.txtExpBenifits.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 26)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Indirect Labor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Cost Account"
        '
        'lblLaborCostAcc
        '
        Me.lblLaborCostAcc.Enabled = False
        Me.lblLaborCostAcc.Location = New System.Drawing.Point(114, 287)
        Me.lblLaborCostAcc.Name = "lblLaborCostAcc"
        Me.lblLaborCostAcc.Size = New System.Drawing.Size(208, 20)
        Me.lblLaborCostAcc.TabIndex = 35
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Location = New System.Drawing.Point(328, 265)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(46, 42)
        Me.Button4.TabIndex = 34
        Me.Button4.Text = ">>"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtLaborCostAcc
        '
        Me.txtLaborCostAcc.Enabled = False
        Me.txtLaborCostAcc.Location = New System.Drawing.Point(114, 267)
        Me.txtLaborCostAcc.Name = "txtLaborCostAcc"
        Me.txtLaborCostAcc.Size = New System.Drawing.Size(208, 20)
        Me.txtLaborCostAcc.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 271)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 26)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Direct Labor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Cost Account"
        '
        'lblAccPH
        '
        Me.lblAccPH.Enabled = False
        Me.lblAccPH.Location = New System.Drawing.Point(114, 146)
        Me.lblAccPH.Name = "lblAccPH"
        Me.lblAccPH.Size = New System.Drawing.Size(208, 20)
        Me.lblAccPH.TabIndex = 31
        '
        'lblAccHDMF
        '
        Me.lblAccHDMF.Enabled = False
        Me.lblAccHDMF.Location = New System.Drawing.Point(114, 100)
        Me.lblAccHDMF.Name = "lblAccHDMF"
        Me.lblAccHDMF.Size = New System.Drawing.Size(208, 20)
        Me.lblAccHDMF.TabIndex = 30
        '
        'lblAccSSS
        '
        Me.lblAccSSS.Enabled = False
        Me.lblAccSSS.Location = New System.Drawing.Point(114, 55)
        Me.lblAccSSS.Name = "lblAccSSS"
        Me.lblAccSSS.Size = New System.Drawing.Size(208, 20)
        Me.lblAccSSS.TabIndex = 29
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Location = New System.Drawing.Point(328, 124)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(46, 42)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = ">>"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtAccPH
        '
        Me.txtAccPH.Enabled = False
        Me.txtAccPH.Location = New System.Drawing.Point(114, 126)
        Me.txtAccPH.Name = "txtAccPH"
        Me.txtAccPH.Size = New System.Drawing.Size(208, 20)
        Me.txtAccPH.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 26)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Philhealth Payable" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Account"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(328, 80)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(46, 40)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = ">>"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtAccHDMF
        '
        Me.txtAccHDMF.Enabled = False
        Me.txtAccHDMF.Location = New System.Drawing.Point(114, 81)
        Me.txtAccHDMF.Name = "txtAccHDMF"
        Me.txtAccHDMF.Size = New System.Drawing.Size(208, 20)
        Me.txtAccHDMF.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 26)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "HDMF Payable" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Account"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(328, 35)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 39)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtAccSSS
        '
        Me.txtAccSSS.Enabled = False
        Me.txtAccSSS.Location = New System.Drawing.Point(114, 36)
        Me.txtAccSSS.Name = "txtAccSSS"
        Me.txtAccSSS.Size = New System.Drawing.Size(208, 20)
        Me.txtAccSSS.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 26)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "SSS Payable " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Account"
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(216, 494)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(93, 41)
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(115, 494)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(93, 41)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "Add"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'DepartmentProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(429, 556)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DepartmentProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Department Profile"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtDeptNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkboxInactiveDept As System.Windows.Forms.CheckBox
    Friend WithEvents lblLaborCostAcc As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtLaborCostAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAccPH As System.Windows.Forms.TextBox
    Friend WithEvents lblAccHDMF As System.Windows.Forms.TextBox
    Friend WithEvents lblAccSSS As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtAccPH As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtAccHDMF As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtAccSSS As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblExpBenifits As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txtExpBenifits As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAccTax As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txtAccTax As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
