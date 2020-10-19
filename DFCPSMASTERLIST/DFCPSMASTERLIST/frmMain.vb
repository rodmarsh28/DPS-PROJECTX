Imports System.Windows.Forms

Public Class frmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub



    

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer
    'Sub checkDB()
    '    Try
    '        If conn.State = ConnectionState.Open Then
    '            OleDBC.Dispose()
    '            conn.Close()
    '        End If
    '        lblDate.Text = Now.ToString("MM/dd/yyyy")
    '        If conn.State <> ConnectionState.Open Then
    '            strConnString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=dfcpsMasterlistDB;server=localhost"
    '            'strConnString = "Data Source=" & My.Settings.mServer & ";" & _
    '            '          "Initial Catalog=" & My.Settings.mDBname & ";" & _
    '            '          "User ID=" & My.Settings.mUserDB & ";" & _
    '            '          "Password=" & My.Settings.mPassDB
    '            conn.ConnectionString = strConnString
    '            conn.Open()
    '            lblDBstatus.Text = "Connected"
    '        End If
    '    Catch ex As Exception
    '        lblDBstatus.Text = "Not Connected"
    '    End Try
    'End Sub

    Private Sub AddEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEmployeesToolStripMenuItem.Click
        frmAddEmployees.cmbAdd.Text = "Add"
        frmAddEmployees.ShowDialog()
    End Sub

    Private Sub DatabaseConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        databaseConnection.ShowDialog()
    End Sub

    Private Sub VIEWMASTERLISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEWMASTERLISTToolStripMenuItem.Click
        frmMasterList.ShowDialog()
    End Sub

    Private Sub ViewOngoingDesciplinaryActionPunishedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewOngoingDesciplinaryActionPunishedToolStripMenuItem.Click
        frmOngoingDesciplinaryActionViewer.ShowDialog()
    End Sub

    Private Sub ViewOngoingLeavEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewOngoingLeavEmployeesToolStripMenuItem.Click
        frmOngoingLeaveEmployees.ShowDialog()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDate.Text = Format(Now, "MM/dd/yyyy")
        lblUsername.Text = "Rizalito Alitre"
        'checkDB()
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    lblTime.Text = Format(Now, "hh:mm:ss tt")
    'End Sub

    Private Sub ConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurationToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub AddPayrollToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPayrollToolStripMenuItem.Click
        frmDateGenerator.mode = "AddPayroll"
        frmDateGenerator.ShowDialog()
    End Sub

    Private Sub ViewAllPayrollToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllPayrollToolStripMenuItem.Click
        frmAllPayrollHistory.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub BackupDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupDatabaseToolStripMenuItem.Click
        frmBackupDatabase.ShowDialog()
    End Sub

    Private Sub PremiumsManualCalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PremiumsManualCalculatorToolStripMenuItem.Click
        manualPremsCalculator.ShowDialog()
    End Sub

    Private Sub DatabaseSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatabaseSettingsToolStripMenuItem.Click
        frmDatabaseSettings.ShowDialog()
    End Sub

    Private Sub PrintPremiumsSummaryToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PrintPremiumsSummaryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPremiumsSummaryToolStripMenuItem1.Click
        frmPrintPremsPaymentSum.MODE = "PREMIUMS"
        frmPrintPremsPaymentSum.lblTittle.Text = "Premiums Payment Summary"
        frmPrintPremsPaymentSum.ShowDialog()
    End Sub

    Private Sub WithholdingTaxSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WithholdingTaxSummaryToolStripMenuItem.Click
        frmPrintPremsPaymentSum.MODE = "WITHHOLDING"
        frmPrintPremsPaymentSum.lblTittle.Text = "Withholding Tax Summary"
        frmPrintPremsPaymentSum.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        frmPrintPremsPaymentSum.MODE = "SSS LOANS"
        frmPrintPremsPaymentSum.lblTittle.Text = "SSS Loans Summary"
        frmPrintPremsPaymentSum.ShowDialog()
    End Sub

    Private Sub PrintSSSLoansSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSSSLoansSummaryToolStripMenuItem.Click
        frmPrintPremsPaymentSum.MODE = "PI LOANS"
        frmPrintPremsPaymentSum.lblTittle.Text = "Pagibig Loans Summary"
        frmPrintPremsPaymentSum.ShowDialog()
    End Sub
End Class
