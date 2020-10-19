<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUsername = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddEmployeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VIEWMASTERLISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewOngoingDesciplinaryActionPunishedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewOngoingLeavEmployeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PayrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddPayrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAllPayrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPremiumsSummaryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithholdingTaxSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PremiumsManualCalculatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PrintSSSLoansSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.lblDate, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6, Me.lblTime, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel7, Me.lblUsername})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 406)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1055, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(34, 17)
        Me.ToolStripStatusLabel3.Text = "Date:"
        '
        'lblDate
        '
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(65, 17)
        Me.lblDate.Text = "00/00/0000"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(37, 17)
        Me.ToolStripStatusLabel6.Text = "Time:"
        '
        'lblTime
        '
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(34, 17)
        Me.lblTime.Text = "00:00"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(40, 17)
        Me.ToolStripStatusLabel1.Text = "           "
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(33, 17)
        Me.ToolStripStatusLabel7.Text = "User:"
        '
        'lblUsername
        '
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(58, 17)
        Me.lblUsername.Text = "Unknown"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TransactionToolStripMenuItem, Me.PayrollToolStripMenuItem, Me.ReportToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.ConfigurationToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1055, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEmployeesToolStripMenuItem, Me.BackupDatabaseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AddEmployeesToolStripMenuItem
        '
        Me.AddEmployeesToolStripMenuItem.Name = "AddEmployeesToolStripMenuItem"
        Me.AddEmployeesToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.AddEmployeesToolStripMenuItem.Text = "Add Employees"
        '
        'BackupDatabaseToolStripMenuItem
        '
        Me.BackupDatabaseToolStripMenuItem.Name = "BackupDatabaseToolStripMenuItem"
        Me.BackupDatabaseToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.BackupDatabaseToolStripMenuItem.Text = "Backup Database"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VIEWMASTERLISTToolStripMenuItem, Me.ViewOngoingDesciplinaryActionPunishedToolStripMenuItem, Me.ViewOngoingLeavEmployeesToolStripMenuItem})
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.TransactionToolStripMenuItem.Text = "View"
        '
        'VIEWMASTERLISTToolStripMenuItem
        '
        Me.VIEWMASTERLISTToolStripMenuItem.Name = "VIEWMASTERLISTToolStripMenuItem"
        Me.VIEWMASTERLISTToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.VIEWMASTERLISTToolStripMenuItem.Text = "Masterlist"
        '
        'ViewOngoingDesciplinaryActionPunishedToolStripMenuItem
        '
        Me.ViewOngoingDesciplinaryActionPunishedToolStripMenuItem.Name = "ViewOngoingDesciplinaryActionPunishedToolStripMenuItem"
        Me.ViewOngoingDesciplinaryActionPunishedToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.ViewOngoingDesciplinaryActionPunishedToolStripMenuItem.Text = "Ongoing Desciplinary Action"
        '
        'ViewOngoingLeavEmployeesToolStripMenuItem
        '
        Me.ViewOngoingLeavEmployeesToolStripMenuItem.Name = "ViewOngoingLeavEmployeesToolStripMenuItem"
        Me.ViewOngoingLeavEmployeesToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.ViewOngoingLeavEmployeesToolStripMenuItem.Text = "Ongoing Leave Employees"
        '
        'PayrollToolStripMenuItem
        '
        Me.PayrollToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddPayrollToolStripMenuItem, Me.ViewAllPayrollToolStripMenuItem})
        Me.PayrollToolStripMenuItem.Name = "PayrollToolStripMenuItem"
        Me.PayrollToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.PayrollToolStripMenuItem.Text = "Payroll"
        '
        'AddPayrollToolStripMenuItem
        '
        Me.AddPayrollToolStripMenuItem.Name = "AddPayrollToolStripMenuItem"
        Me.AddPayrollToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AddPayrollToolStripMenuItem.Text = "Add Payroll"
        '
        'ViewAllPayrollToolStripMenuItem
        '
        Me.ViewAllPayrollToolStripMenuItem.Name = "ViewAllPayrollToolStripMenuItem"
        Me.ViewAllPayrollToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ViewAllPayrollToolStripMenuItem.Text = "All Payroll History"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintPremiumsSummaryToolStripMenuItem1, Me.WithholdingTaxSummaryToolStripMenuItem, Me.ToolStripMenuItem1, Me.PrintSSSLoansSummaryToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'PrintPremiumsSummaryToolStripMenuItem1
        '
        Me.PrintPremiumsSummaryToolStripMenuItem1.Name = "PrintPremiumsSummaryToolStripMenuItem1"
        Me.PrintPremiumsSummaryToolStripMenuItem1.Size = New System.Drawing.Size(214, 22)
        Me.PrintPremiumsSummaryToolStripMenuItem1.Text = "Print Premiums Summary"
        '
        'WithholdingTaxSummaryToolStripMenuItem
        '
        Me.WithholdingTaxSummaryToolStripMenuItem.Name = "WithholdingTaxSummaryToolStripMenuItem"
        Me.WithholdingTaxSummaryToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.WithholdingTaxSummaryToolStripMenuItem.Text = "Withholding Tax Summary"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PremiumsManualCalculatorToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'PremiumsManualCalculatorToolStripMenuItem
        '
        Me.PremiumsManualCalculatorToolStripMenuItem.Name = "PremiumsManualCalculatorToolStripMenuItem"
        Me.PremiumsManualCalculatorToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.PremiumsManualCalculatorToolStripMenuItem.Text = "Premiums Manual Calculator"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatabaseSettingsToolStripMenuItem})
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.ConfigurationToolStripMenuItem.Text = "Configuration"
        '
        'DatabaseSettingsToolStripMenuItem
        '
        Me.DatabaseSettingsToolStripMenuItem.Name = "DatabaseSettingsToolStripMenuItem"
        Me.DatabaseSettingsToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DatabaseSettingsToolStripMenuItem.Text = "Database Settings"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'PrintSSSLoansSummaryToolStripMenuItem
        '
        Me.PrintSSSLoansSummaryToolStripMenuItem.Name = "PrintSSSLoansSummaryToolStripMenuItem"
        Me.PrintSSSLoansSummaryToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.PrintSSSLoansSummaryToolStripMenuItem.Text = "Print Pagibig Loans Summary"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(214, 22)
        Me.ToolStripMenuItem1.Text = "Print SSS Loans Summary"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 428)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DFC PACKING SOLUTIONS EMPLOYEES MASTER LIST"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddEmployeesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VIEWMASTERLISTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewOngoingDesciplinaryActionPunishedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewOngoingLeavEmployeesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PayrollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddPayrollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewAllPayrollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUsername As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BackupDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PremiumsManualCalculatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatabaseSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPremiumsSummaryToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WithholdingTaxSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSSSLoansSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
