<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQA
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMesh = New System.Windows.Forms.ComboBox()
        Me.dtpDto = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVisor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCos = New System.Windows.Forms.TextBox()
        Me.txtQA = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQAno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RPM1 = New System.Windows.Forms.TextBox()
        Me.AT1 = New System.Windows.Forms.TextBox()
        Me.AD1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RPM2 = New System.Windows.Forms.TextBox()
        Me.AT2 = New System.Windows.Forms.TextBox()
        Me.AD2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.RPM3 = New System.Windows.Forms.TextBox()
        Me.AT3 = New System.Windows.Forms.TextBox()
        Me.AD3 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(605, 308)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 44)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(499, 308)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 44)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMesh)
        Me.GroupBox1.Controls.Add(Me.dtpDto)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtVisor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCustomer)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCos)
        Me.GroupBox1.Controls.Add(Me.txtQA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpDFrom)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtQAno)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 246)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'txtMesh
        '
        Me.txtMesh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtMesh.FormattingEnabled = True
        Me.txtMesh.Items.AddRange(New Object() {"10x10", "12x12"})
        Me.txtMesh.Location = New System.Drawing.Point(112, 156)
        Me.txtMesh.Name = "txtMesh"
        Me.txtMesh.Size = New System.Drawing.Size(102, 21)
        Me.txtMesh.TabIndex = 38
        '
        'dtpDto
        '
        Me.dtpDto.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.dtpDto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDto.Location = New System.Drawing.Point(112, 100)
        Me.dtpDto.Name = "dtpDto"
        Me.dtpDto.Size = New System.Drawing.Size(148, 20)
        Me.dtpDto.TabIndex = 19
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(77, 103)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(20, 13)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "From"
        '
        'txtVisor
        '
        Me.txtVisor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVisor.Location = New System.Drawing.Point(112, 210)
        Me.txtVisor.Name = "txtVisor"
        Me.txtVisor.Size = New System.Drawing.Size(298, 20)
        Me.txtVisor.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "SUPERVISOR"
        '
        'txtCustomer
        '
        Me.txtCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomer.Location = New System.Drawing.Point(112, 184)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(298, 20)
        Me.txtCustomer.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "CUSTOMER"
        '
        'txtCos
        '
        Me.txtCos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCos.Location = New System.Drawing.Point(112, 131)
        Me.txtCos.Name = "txtCos"
        Me.txtCos.Size = New System.Drawing.Size(298, 20)
        Me.txtCos.TabIndex = 11
        '
        'txtQA
        '
        Me.txtQA.AutoSize = True
        Me.txtQA.Location = New System.Drawing.Point(13, 129)
        Me.txtQA.Name = "txtQA"
        Me.txtQA.Size = New System.Drawing.Size(28, 13)
        Me.txtQA.TabIndex = 10
        Me.txtQA.Text = "Q.A."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Date Shift"
        '
        'dtpDFrom
        '
        Me.dtpDFrom.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.dtpDFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDFrom.Location = New System.Drawing.Point(112, 75)
        Me.dtpDFrom.Name = "dtpDFrom"
        Me.dtpDFrom.Size = New System.Drawing.Size(148, 20)
        Me.dtpDFrom.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 162)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "MESH"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "QA No."
        '
        'txtQAno
        '
        Me.txtQAno.Enabled = False
        Me.txtQAno.Location = New System.Drawing.Point(112, 33)
        Me.txtQAno.Name = "txtQAno"
        Me.txtQAno.Size = New System.Drawing.Size(117, 20)
        Me.txtQAno.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.792453!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "AVG. DENIER"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(819, 199)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "REMARKS"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(504, 220)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(658, 44)
        Me.txtRemarks.TabIndex = 34
        Me.txtRemarks.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.RPM1)
        Me.GroupBox2.Controls.Add(Me.AT1)
        Me.GroupBox2.Controls.Add(Me.AD1)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(504, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 149)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "1ST"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.792453!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "RPM"
        '
        'RPM1
        '
        Me.RPM1.Location = New System.Drawing.Point(17, 103)
        Me.RPM1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RPM1.Name = "RPM1"
        Me.RPM1.Size = New System.Drawing.Size(163, 20)
        Me.RPM1.TabIndex = 26
        '
        'AT1
        '
        Me.AT1.Location = New System.Drawing.Point(104, 61)
        Me.AT1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AT1.Name = "AT1"
        Me.AT1.Size = New System.Drawing.Size(76, 20)
        Me.AT1.TabIndex = 25
        '
        'AD1
        '
        Me.AD1.Location = New System.Drawing.Point(17, 61)
        Me.AD1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AD1.Name = "AD1"
        Me.AD1.Size = New System.Drawing.Size(76, 20)
        Me.AD1.TabIndex = 24
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.792453!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(105, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "AVG. TENSILE"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.RPM2)
        Me.GroupBox3.Controls.Add(Me.AT2)
        Me.GroupBox3.Controls.Add(Me.AD2)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(736, 40)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 149)
        Me.GroupBox3.TabIndex = 43
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "2ND"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.792453!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(83, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "RPM"
        '
        'RPM2
        '
        Me.RPM2.Location = New System.Drawing.Point(17, 103)
        Me.RPM2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RPM2.Name = "RPM2"
        Me.RPM2.Size = New System.Drawing.Size(163, 20)
        Me.RPM2.TabIndex = 26
        '
        'AT2
        '
        Me.AT2.Location = New System.Drawing.Point(104, 61)
        Me.AT2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AT2.Name = "AT2"
        Me.AT2.Size = New System.Drawing.Size(76, 20)
        Me.AT2.TabIndex = 25
        '
        'AD2
        '
        Me.AD2.Location = New System.Drawing.Point(17, 61)
        Me.AD2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AD2.Name = "AD2"
        Me.AD2.Size = New System.Drawing.Size(76, 20)
        Me.AD2.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.792453!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(105, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "AVG. TENSILE"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.792453!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(21, 39)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "AVG. DENIER"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.RPM3)
        Me.GroupBox4.Controls.Add(Me.AT3)
        Me.GroupBox4.Controls.Add(Me.AD3)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Location = New System.Drawing.Point(960, 40)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 149)
        Me.GroupBox4.TabIndex = 44
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "3RD"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.792453!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(83, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "RPM"
        '
        'RPM3
        '
        Me.RPM3.Location = New System.Drawing.Point(17, 103)
        Me.RPM3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RPM3.Name = "RPM3"
        Me.RPM3.Size = New System.Drawing.Size(163, 20)
        Me.RPM3.TabIndex = 26
        '
        'AT3
        '
        Me.AT3.Location = New System.Drawing.Point(104, 61)
        Me.AT3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AT3.Name = "AT3"
        Me.AT3.Size = New System.Drawing.Size(76, 20)
        Me.AT3.TabIndex = 25
        '
        'AD3
        '
        Me.AD3.Location = New System.Drawing.Point(17, 61)
        Me.AD3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AD3.Name = "AD3"
        Me.AD3.Size = New System.Drawing.Size(76, 20)
        Me.AD3.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.792453!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(105, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "AVG. TENSILE"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.792453!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(21, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "AVG. DENIER"
        '
        'frmQA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1194, 391)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Q.A. FORM"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVisor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCos As System.Windows.Forms.TextBox
    Friend WithEvents txtQA As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQAno As System.Windows.Forms.TextBox
    Friend WithEvents txtMesh As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RPM1 As System.Windows.Forms.TextBox
    Friend WithEvents AT1 As System.Windows.Forms.TextBox
    Friend WithEvents AD1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RPM2 As System.Windows.Forms.TextBox
    Friend WithEvents AT2 As System.Windows.Forms.TextBox
    Friend WithEvents AD2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents RPM3 As System.Windows.Forms.TextBox
    Friend WithEvents AT3 As System.Windows.Forms.TextBox
    Friend WithEvents AD3 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
