<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDailyTimeRecording
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRecordNo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.RichTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblcount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cempid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.crh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cah = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.crhc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cnwh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.crhr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cnwhr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cotNonh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.crdr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clatem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cdeptid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.csss = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cpi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cph = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ctax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cindiracc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cdiracc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cindircost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cdirectcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cempid, Me.cname, Me.crh, Me.cah, Me.crhc, Me.cnwh, Me.crhr, Me.cnwhr, Me.coth, Me.cotNonh, Me.crdr, Me.clatem, Me.cdeptid, Me.csss, Me.cpi, Me.cph, Me.ctax, Me.cindiracc, Me.cdiracc, Me.cindircost, Me.cdirectcost})
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(3, 16)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(1186, 361)
        Me.dgv.TabIndex = 79
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(616, 482)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(103, 43)
        Me.btnClose.TabIndex = 81
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.Location = New System.Drawing.Point(497, 482)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(103, 43)
        Me.btnAdd.TabIndex = 80
        Me.btnAdd.Text = "&Save"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(33, 49)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(38, 13)
        Me.Label24.TabIndex = 82
        Me.Label24.Text = "Date:"
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(77, 44)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpDate.TabIndex = 83
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Record No,"
        '
        'lblRecordNo
        '
        Me.lblRecordNo.AutoSize = True
        Me.lblRecordNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordNo.Location = New System.Drawing.Point(110, 21)
        Me.lblRecordNo.Name = "lblRecordNo"
        Me.lblRecordNo.Size = New System.Drawing.Size(14, 13)
        Me.lblRecordNo.TabIndex = 85
        Me.lblRecordNo.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(642, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(704, 11)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(493, 59)
        Me.txtRemarks.TabIndex = 87
        Me.txtRemarks.Text = ""
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1168, 83)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 23)
        Me.Button2.TabIndex = 89
        Me.Button2.Text = "-"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1142, 83)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(27, 23)
        Me.Button4.TabIndex = 88
        Me.Button4.Text = "+"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1192, 380)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Attendance"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblcount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 549)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1216, 22)
        Me.StatusStrip1.TabIndex = 92
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(112, 17)
        Me.ToolStripStatusLabel1.Text = "Employee's Count : "
        '
        'lblcount
        '
        Me.lblcount.BackColor = System.Drawing.Color.White
        Me.lblcount.Name = "lblcount"
        Me.lblcount.Size = New System.Drawing.Size(13, 17)
        Me.lblcount.Text = "0"
        '
        'cempid
        '
        Me.cempid.Frozen = True
        Me.cempid.HeaderText = "Employee ID"
        Me.cempid.Name = "cempid"
        Me.cempid.ReadOnly = True
        '
        'cname
        '
        Me.cname.Frozen = True
        Me.cname.HeaderText = "Name"
        Me.cname.Name = "cname"
        Me.cname.ReadOnly = True
        Me.cname.Width = 260
        '
        'crh
        '
        Me.crh.HeaderText = "Regular Worked Hours"
        Me.crh.Name = "crh"
        Me.crh.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.crh.Width = 80
        '
        'cah
        '
        Me.cah.HeaderText = "Absent Hours"
        Me.cah.Name = "cah"
        Me.cah.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cah.Width = 70
        '
        'crhc
        '
        Me.crhc.HeaderText = "RH Counted"
        Me.crhc.Name = "crhc"
        Me.crhc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.crhc.Width = 80
        '
        'cnwh
        '
        Me.cnwh.HeaderText = "NWH Counted"
        Me.cnwh.Name = "cnwh"
        Me.cnwh.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cnwh.Width = 80
        '
        'crhr
        '
        Me.crhr.HeaderText = "RH Report (HRS)"
        Me.crhr.Name = "crhr"
        Me.crhr.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.crhr.Width = 80
        '
        'cnwhr
        '
        Me.cnwhr.HeaderText = "NWH Report (HRS)"
        Me.cnwhr.Name = "cnwhr"
        Me.cnwhr.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cnwhr.Width = 80
        '
        'coth
        '
        Me.coth.HeaderText = "OT (HRS)"
        Me.coth.Name = "coth"
        Me.coth.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.coth.Width = 70
        '
        'cotNonh
        '
        Me.cotNonh.HeaderText = "OT Non-Routine (HRS)"
        Me.cotNonh.Name = "cotNonh"
        '
        'crdr
        '
        Me.crdr.HeaderText = "Restday Report(HRS)"
        Me.crdr.Name = "crdr"
        Me.crdr.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.crdr.Width = 80
        '
        'clatem
        '
        Me.clatem.HeaderText = "Late/UT (Mins)"
        Me.clatem.Name = "clatem"
        Me.clatem.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clatem.Width = 80
        '
        'cdeptid
        '
        Me.cdeptid.HeaderText = "cdeptid"
        Me.cdeptid.Name = "cdeptid"
        Me.cdeptid.Visible = False
        '
        'csss
        '
        Me.csss.HeaderText = "sss"
        Me.csss.Name = "csss"
        Me.csss.Visible = False
        '
        'cpi
        '
        Me.cpi.HeaderText = "pi"
        Me.cpi.Name = "cpi"
        Me.cpi.Visible = False
        '
        'cph
        '
        Me.cph.HeaderText = "ph"
        Me.cph.Name = "cph"
        Me.cph.Visible = False
        '
        'ctax
        '
        Me.ctax.HeaderText = "tax"
        Me.ctax.Name = "ctax"
        Me.ctax.Visible = False
        '
        'cindiracc
        '
        Me.cindiracc.HeaderText = "indiracc"
        Me.cindiracc.Name = "cindiracc"
        Me.cindiracc.Visible = False
        '
        'cdiracc
        '
        Me.cdiracc.HeaderText = "diracc"
        Me.cdiracc.Name = "cdiracc"
        Me.cdiracc.Visible = False
        '
        'cindircost
        '
        Me.cindircost.HeaderText = "IndirectCost"
        Me.cindircost.Name = "cindircost"
        '
        'cdirectcost
        '
        Me.cdirectcost.HeaderText = "directCost"
        Me.cdirectcost.Name = "cdirectcost"
        '
        'frmDailyTimeRecording
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1216, 571)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRecordNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmDailyTimeRecording"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Time Recording"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRecordNo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.RichTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblcount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cempid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents crh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cah As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents crhc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnwh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents crhr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnwhr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cotNonh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents crdr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clatem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cdeptid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents csss As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cpi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cph As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cindiracc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cdiracc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cindircost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cdirectcost As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
