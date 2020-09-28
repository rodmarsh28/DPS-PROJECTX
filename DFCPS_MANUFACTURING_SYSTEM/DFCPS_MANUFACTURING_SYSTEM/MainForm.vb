Public Class MainForm
    Dim companyName As String
    Dim companyAddress As String
    Public logo() As Byte
    Public header() As Byte
    Private Sub ABOUTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ABOUTToolStripMenuItem.Click

    End Sub
    Sub load_company()
        Dim sc As New setup_class
        sc.get_company()
        companyName = sc.companyName
        companyAddress = sc.companyAddress
        logo = sc.companyLogo
        header = sc.companyHeader
    End Sub

    Private Sub REGISTERACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTERACCOUNTToolStripMenuItem.Click
        If LBLPOS.Text = "Admin" Then
            frmRegForm.ShowDialog()
        Else
            MsgBox("This account is not allowed to access this module", MsgBoxStyle.Critical, "System Reminder")
        End If

    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        frmLogin.ShowDialog()
    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HRISMain.ShowDialog()
    End Sub

    Private Sub ACCOUNTLISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmUserList.ShowDialog()
    End Sub

    Private Sub MANAGEACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MANAGEACCOUNTToolStripMenuItem.Click
        If LBLPOS.Text = "Admin" Then
            frmUserList.ShowDialog()
        Else
            MsgBox("This account is not allowed to access this module", MsgBoxStyle.Critical, "System Reminder")
        End If

    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmAccountingSystem.ShowDialog()
    End Sub

    Private Sub MANAGECHARTOFACCOUNTSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MANAGECHARTOFACCOUNTSToolStripMenuItem.Click
        frmManageAccounts.ShowDialog()
    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ProductionMain.ShowDialog()
    End Sub

   
    Private Sub MetroButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        MsgBox("This Module is not available right now", MsgBoxStyle.Information, "System information")
        'frmInventorySystemMain.ShowDialog()
    End Sub

    Private Sub MetroButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton6.Click
        'frmPurchaseMain.ShowDialog()
        MsgBox("This Module is not available right now", MsgBoxStyle.Information, "System information")
    End Sub

    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        frmSalesMain.ShowDialog()
        'MsgBox("This Module is not available right now", MsgBoxStyle.Information, "System information")
    End Sub

    Private Sub MetroButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        'frmProductionMain.ShowDialog()
        MsgBox("This Module is not available right now", MsgBoxStyle.Information, "System information")
    End Sub

    Private Sub MetroButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        'HRISMain.ShowDialog()
        MsgBox("This Module is not available right now", MsgBoxStyle.Information, "System information")
    End Sub

    Private Sub MetroButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        frmAccountingMain.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "Question") = MsgBoxResult.Yes Then
            Me.Hide()
            frmLogin.txtPassword.Text = ""
            frmLogin.ShowDialog()
        End If
    End Sub

    Private Sub SYSTEMSETTINGSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SYSTEMSETTINGSToolStripMenuItem.Click
        frmSystemSettings.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim ss As New systemSettings_class
        ss.isDataupdated()
    End Sub
End Class