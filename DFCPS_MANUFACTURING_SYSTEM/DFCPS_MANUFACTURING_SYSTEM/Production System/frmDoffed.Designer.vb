<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDoffed
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
        Me.txtRollNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDoffDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLength = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDoffer = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtLoomNo = New System.Windows.Forms.ComboBox()
        Me.txtMesh = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "ROLL NO."
        '
        'txtRollNo
        '
        Me.txtRollNo.Enabled = False
        Me.txtRollNo.Location = New System.Drawing.Point(83, 32)
        Me.txtRollNo.Name = "txtRollNo"
        Me.txtRollNo.Size = New System.Drawing.Size(169, 20)
        Me.txtRollNo.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 15)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "DATE"
        '
        'dtpDoffDate
        '
        Me.dtpDoffDate.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.dtpDoffDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDoffDate.Location = New System.Drawing.Point(83, 73)
        Me.dtpDoffDate.Name = "dtpDoffDate"
        Me.dtpDoffDate.Size = New System.Drawing.Size(169, 20)
        Me.dtpDoffDate.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "MESH"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "WIDTH"
        '
        'txtWidth
        '
        Me.txtWidth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWidth.Location = New System.Drawing.Point(83, 158)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(119, 20)
        Me.txtWidth.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "LOOM NO."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "LENGTH"
        '
        'txtLength
        '
        Me.txtLength.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLength.Location = New System.Drawing.Point(83, 183)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(119, 20)
        Me.txtLength.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 15)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "WEIGHT"
        '
        'txtWeight
        '
        Me.txtWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWeight.Location = New System.Drawing.Point(83, 209)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(119, 20)
        Me.txtWeight.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 238)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 15)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "DOFFER"
        '
        'txtDoffer
        '
        Me.txtDoffer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDoffer.Location = New System.Drawing.Point(83, 235)
        Me.txtDoffer.Name = "txtDoffer"
        Me.txtDoffer.Size = New System.Drawing.Size(169, 20)
        Me.txtDoffer.TabIndex = 30
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(152, 274)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 44)
        Me.Button2.TabIndex = 33
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(46, 274)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 44)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtLoomNo
        '
        Me.txtLoomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtLoomNo.FormattingEnabled = True
        Me.txtLoomNo.Location = New System.Drawing.Point(83, 100)
        Me.txtLoomNo.Name = "txtLoomNo"
        Me.txtLoomNo.Size = New System.Drawing.Size(119, 21)
        Me.txtLoomNo.Sorted = True
        Me.txtLoomNo.TabIndex = 34
        '
        'txtMesh
        '
        Me.txtMesh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtMesh.FormattingEnabled = True
        Me.txtMesh.Items.AddRange(New Object() {"10x10", "12x12"})
        Me.txtMesh.Location = New System.Drawing.Point(83, 133)
        Me.txtMesh.Name = "txtMesh"
        Me.txtMesh.Size = New System.Drawing.Size(119, 21)
        Me.txtMesh.TabIndex = 39
        '
        'frmDoffed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(299, 328)
        Me.Controls.Add(Me.txtMesh)
        Me.Controls.Add(Me.txtLoomNo)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDoffer)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtWeight)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtLength)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpDoffDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRollNo)
        Me.Name = "frmDoffed"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add / Edit Doffed"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRollNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDoffDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLength As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDoffer As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtLoomNo As System.Windows.Forms.ComboBox
    Friend WithEvents txtMesh As System.Windows.Forms.ComboBox
End Class
