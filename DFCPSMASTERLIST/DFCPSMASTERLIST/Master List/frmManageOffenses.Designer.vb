<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageOffenses
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtTypeOff = New System.Windows.Forms.TextBox()
        Me.dgvOcc = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvOff = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtOccTimes = New System.Windows.Forms.TextBox()
        Me.txtCorrectiveActions = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgvOcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(516, 29)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "-"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(489, 29)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(27, 23)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "+"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(156, 29)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(27, 23)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "-"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(130, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtTypeOff
        '
        Me.txtTypeOff.Location = New System.Drawing.Point(8, 31)
        Me.txtTypeOff.Name = "txtTypeOff"
        Me.txtTypeOff.Size = New System.Drawing.Size(121, 20)
        Me.txtTypeOff.TabIndex = 11
        '
        'dgvOcc
        '
        Me.dgvOcc.AllowUserToAddRows = False
        Me.dgvOcc.AllowUserToDeleteRows = False
        Me.dgvOcc.AllowUserToResizeRows = False
        Me.dgvOcc.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvOcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOcc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4})
        Me.dgvOcc.Location = New System.Drawing.Point(188, 54)
        Me.dgvOcc.MultiSelect = False
        Me.dgvOcc.Name = "dgvOcc"
        Me.dgvOcc.ReadOnly = True
        Me.dgvOcc.RowHeadersVisible = False
        Me.dgvOcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOcc.Size = New System.Drawing.Size(353, 330)
        Me.dgvOcc.TabIndex = 10
        '
        'Column3
        '
        Me.Column3.HeaderText = "Occurrence"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column4.HeaderText = "Corrective Actions"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 230
        '
        'dgvOff
        '
        Me.dgvOff.AllowUserToAddRows = False
        Me.dgvOff.AllowUserToDeleteRows = False
        Me.dgvOff.AllowUserToResizeRows = False
        Me.dgvOff.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvOff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOff.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dgvOff.Location = New System.Drawing.Point(8, 54)
        Me.dgvOff.MultiSelect = False
        Me.dgvOff.Name = "dgvOff"
        Me.dgvOff.ReadOnly = True
        Me.dgvOff.RowHeadersVisible = False
        Me.dgvOff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOff.Size = New System.Drawing.Size(174, 330)
        Me.dgvOff.TabIndex = 9
        '
        'Column1
        '
        Me.Column1.HeaderText = "offenseID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Types of Offenses"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 160
        '
        'txtOccTimes
        '
        Me.txtOccTimes.Enabled = False
        Me.txtOccTimes.Location = New System.Drawing.Point(199, 31)
        Me.txtOccTimes.Name = "txtOccTimes"
        Me.txtOccTimes.Size = New System.Drawing.Size(78, 20)
        Me.txtOccTimes.TabIndex = 16
        '
        'txtCorrectiveActions
        '
        Me.txtCorrectiveActions.Location = New System.Drawing.Point(283, 31)
        Me.txtCorrectiveActions.Name = "txtCorrectiveActions"
        Me.txtCorrectiveActions.Size = New System.Drawing.Size(200, 20)
        Me.txtCorrectiveActions.TabIndex = 17
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
        'frmManageOffenses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(553, 406)
        Me.Controls.Add(Me.txtCorrectiveActions)
        Me.Controls.Add(Me.txtOccTimes)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtTypeOff)
        Me.Controls.Add(Me.dgvOcc)
        Me.Controls.Add(Me.dgvOff)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmManageOffenses"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Offenses"
        CType(Me.dgvOcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtTypeOff As System.Windows.Forms.TextBox
    Friend WithEvents dgvOcc As System.Windows.Forms.DataGridView
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvOff As System.Windows.Forms.DataGridView
    Friend WithEvents txtOccTimes As System.Windows.Forms.TextBox
    Friend WithEvents txtCorrectiveActions As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
