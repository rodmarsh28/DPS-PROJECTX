<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HRISMain
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
        Me.RecordDTRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeesLeaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisciplinaryActionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageOffensesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageInfractionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageLeaveTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VIEWMASTERLISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DTRRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PayrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddPayrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAllPayrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPremiumsSummaryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithholdingTaxSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintSSSLoansSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DTRRecordReportSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailySummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeaveSummaryReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintMasterlistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InactiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PremiumsManualCalculatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SSSContributionTablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TransactionToolStripMenuItem, Me.PayrollToolStripMenuItem, Me.ReportToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.SetupToolStripMenuItem, Me.ConfigurationToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1055, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEmployeesToolStripMenuItem, Me.RecordDTRToolStripMenuItem, Me.EmployeesLeaveToolStripMenuItem, Me.DisciplinaryActionToolStripMenuItem1, Me.ManageOffensesToolStripMenuItem, Me.ManageInfractionsToolStripMenuItem, Me.ManageLeaveTypeToolStripMenuItem, Me.BackupDatabaseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AddEmployeesToolStripMenuItem
        '
        Me.AddEmployeesToolStripMenuItem.Name = "AddEmployeesToolStripMenuItem"
        Me.AddEmployeesToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.AddEmployeesToolStripMenuItem.Text = "Add Employees"
        '
        'RecordDTRToolStripMenuItem
        '
        Me.RecordDTRToolStripMenuItem.Name = "RecordDTRToolStripMenuItem"
        Me.RecordDTRToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.RecordDTRToolStripMenuItem.Text = "Record DTR "
        '
        'EmployeesLeaveToolStripMenuItem
        '
        Me.EmployeesLeaveToolStripMenuItem.Name = "EmployeesLeaveToolStripMenuItem"
        Me.EmployeesLeaveToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.EmployeesLeaveToolStripMenuItem.Text = "Employees Leave"
        '
        'DisciplinaryActionToolStripMenuItem1
        '
        Me.DisciplinaryActionToolStripMenuItem1.Name = "DisciplinaryActionToolStripMenuItem1"
        Me.DisciplinaryActionToolStripMenuItem1.Size = New System.Drawing.Size(178, 22)
        Me.DisciplinaryActionToolStripMenuItem1.Text = "Disciplinary Action"
        '
        'ManageOffensesToolStripMenuItem
        '
        Me.ManageOffensesToolStripMenuItem.Name = "ManageOffensesToolStripMenuItem"
        Me.ManageOffensesToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ManageOffensesToolStripMenuItem.Text = "Manage Offenses"
        '
        'ManageInfractionsToolStripMenuItem
        '
        Me.ManageInfractionsToolStripMenuItem.Name = "ManageInfractionsToolStripMenuItem"
        Me.ManageInfractionsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ManageInfractionsToolStripMenuItem.Text = "Manage Infractions"
        '
        'ManageLeaveTypeToolStripMenuItem
        '
        Me.ManageLeaveTypeToolStripMenuItem.Name = "ManageLeaveTypeToolStripMenuItem"
        Me.ManageLeaveTypeToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ManageLeaveTypeToolStripMenuItem.Text = "Manage Leave Type"
        '
        'BackupDatabaseToolStripMenuItem
        '
        Me.BackupDatabaseToolStripMenuItem.Name = "BackupDatabaseToolStripMenuItem"
        Me.BackupDatabaseToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.BackupDatabaseToolStripMenuItem.Text = "Backup Database"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VIEWMASTERLISTToolStripMenuItem, Me.DTRRecordToolStripMenuItem})
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.TransactionToolStripMenuItem.Text = "View"
        '
        'VIEWMASTERLISTToolStripMenuItem
        '
        Me.VIEWMASTERLISTToolStripMenuItem.Name = "VIEWMASTERLISTToolStripMenuItem"
        Me.VIEWMASTERLISTToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.VIEWMASTERLISTToolStripMenuItem.Text = "Masterlist"
        '
        'DTRRecordToolStripMenuItem
        '
        Me.DTRRecordToolStripMenuItem.Name = "DTRRecordToolStripMenuItem"
        Me.DTRRecordToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DTRRecordToolStripMenuItem.Text = "DTR Record"
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
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintPremiumsSummaryToolStripMenuItem1, Me.WithholdingTaxSummaryToolStripMenuItem, Me.ToolStripMenuItem4, Me.PrintSSSLoansSummaryToolStripMenuItem, Me.DTRRecordReportSummaryToolStripMenuItem, Me.LeaveSummaryReportToolStripMenuItem, Me.PrintMasterlistToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'PrintPremiumsSummaryToolStripMenuItem1
        '
        Me.PrintPremiumsSummaryToolStripMenuItem1.Name = "PrintPremiumsSummaryToolStripMenuItem1"
        Me.PrintPremiumsSummaryToolStripMenuItem1.Size = New System.Drawing.Size(230, 22)
        Me.PrintPremiumsSummaryToolStripMenuItem1.Text = "Print Premiums Summary"
        '
        'WithholdingTaxSummaryToolStripMenuItem
        '
        Me.WithholdingTaxSummaryToolStripMenuItem.Name = "WithholdingTaxSummaryToolStripMenuItem"
        Me.WithholdingTaxSummaryToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.WithholdingTaxSummaryToolStripMenuItem.Text = "Withholding Tax Summary"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(230, 22)
        Me.ToolStripMenuItem4.Text = "Print SSS Loans Summary"
        '
        'PrintSSSLoansSummaryToolStripMenuItem
        '
        Me.PrintSSSLoansSummaryToolStripMenuItem.Name = "PrintSSSLoansSummaryToolStripMenuItem"
        Me.PrintSSSLoansSummaryToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.PrintSSSLoansSummaryToolStripMenuItem.Text = "Print Pagibig Loans Summary"
        '
        'DTRRecordReportSummaryToolStripMenuItem
        '
        Me.DTRRecordReportSummaryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailySummaryToolStripMenuItem, Me.TotalSummaryToolStripMenuItem})
        Me.DTRRecordReportSummaryToolStripMenuItem.Name = "DTRRecordReportSummaryToolStripMenuItem"
        Me.DTRRecordReportSummaryToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.DTRRecordReportSummaryToolStripMenuItem.Text = "DTR Record Report"
        '
        'DailySummaryToolStripMenuItem
        '
        Me.DailySummaryToolStripMenuItem.Name = "DailySummaryToolStripMenuItem"
        Me.DailySummaryToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.DailySummaryToolStripMenuItem.Text = "Daily Summary"
        '
        'TotalSummaryToolStripMenuItem
        '
        Me.TotalSummaryToolStripMenuItem.Name = "TotalSummaryToolStripMenuItem"
        Me.TotalSummaryToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.TotalSummaryToolStripMenuItem.Text = "Total Summary"
        '
        'LeaveSummaryReportToolStripMenuItem
        '
        Me.LeaveSummaryReportToolStripMenuItem.Name = "LeaveSummaryReportToolStripMenuItem"
        Me.LeaveSummaryReportToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.LeaveSummaryReportToolStripMenuItem.Text = "Leave Summary Report"
        '
        'PrintMasterlistToolStripMenuItem
        '
        Me.PrintMasterlistToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllToolStripMenuItem, Me.ActiveToolStripMenuItem, Me.InactiveToolStripMenuItem})
        Me.PrintMasterlistToolStripMenuItem.Name = "PrintMasterlistToolStripMenuItem"
        Me.PrintMasterlistToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.PrintMasterlistToolStripMenuItem.Text = "Print Masterlist"
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AllToolStripMenuItem.Text = "All"
        '
        'ActiveToolStripMenuItem
        '
        Me.ActiveToolStripMenuItem.Name = "ActiveToolStripMenuItem"
        Me.ActiveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ActiveToolStripMenuItem.Text = "Active"
        '
        'InactiveToolStripMenuItem
        '
        Me.InactiveToolStripMenuItem.Name = "InactiveToolStripMenuItem"
        Me.InactiveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InactiveToolStripMenuItem.Text = "Inactive"
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
        'SetupToolStripMenuItem
        '
        Me.SetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SSSContributionTablesToolStripMenuItem})
        Me.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        Me.SetupToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.SetupToolStripMenuItem.Text = "Setup"
        '
        'SSSContributionTablesToolStripMenuItem
        '
        Me.SSSContributionTablesToolStripMenuItem.Name = "SSSContributionTablesToolStripMenuItem"
        Me.SSSContributionTablesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.SSSContributionTablesToolStripMenuItem.Text = "SSS Contribution Tables"
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
        'HRISMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 428)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "HRISMain"
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
    Friend WithEvents SetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SSSContributionTablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSSSLoansSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeesLeaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisciplinaryActionToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageOffensesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageInfractionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecordDTRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageLeaveTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DTRRecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DTRRecordReportSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailySummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TotalSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LeaveSummaryReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintMasterlistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InactiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
