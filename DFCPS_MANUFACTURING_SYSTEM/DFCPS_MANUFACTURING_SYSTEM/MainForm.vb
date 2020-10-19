Imports MadMilkman.Ini
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
    Sub restrictForm(ByVal POSITION As String)

        If POSITION = "ADMIN" Then
            btnAccounting.Enabled = True
            btnInventory.Enabled = True
            btnHR.Enabled = True
            btnProd.Enabled = True
            btnSales.Enabled = True
            btnPurchasing.Enabled = True
        ElseIf POSITION = "SALES IN-CHARGE" Then
            btnAccounting.Enabled = False
            btnInventory.Enabled = False
            btnHR.Enabled = False
            btnProd.Enabled = False
            btnSales.Enabled = True
            btnPurchasing.Enabled = False
        ElseIf POSITION = "ACCOUNTING" Then
            btnAccounting.Enabled = True
            btnInventory.Enabled = False
            btnHR.Enabled = False
            btnProd.Enabled = False
            btnSales.Enabled = False
            btnPurchasing.Enabled = False
        ElseIf POSITION = "HR" Then
            btnAccounting.Enabled = False
            btnInventory.Enabled = False
            btnHR.Enabled = True
            btnProd.Enabled = False
            btnSales.Enabled = False
            btnPurchasing.Enabled = False
        ElseIf POSITION = "PURCHASER" Then
            btnAccounting.Enabled = False
            btnInventory.Enabled = False
            btnHR.Enabled = False
            btnProd.Enabled = False
            btnSales.Enabled = False
            btnPurchasing.Enabled = True
        ElseIf POSITION = "INVENTORY IN-CHARGE" Then
            btnAccounting.Enabled = False
            btnInventory.Enabled = True
            btnHR.Enabled = False
            btnProd.Enabled = False
            btnSales.Enabled = False
            btnPurchasing.Enabled = False
        ElseIf POSITION = "PRODUCTION ENCODER" Then
            btnAccounting.Enabled = False
            btnInventory.Enabled = False
            btnHR.Enabled = False
            btnProd.Enabled = True
            btnSales.Enabled = False
            btnPurchasing.Enabled = False
        End If
    End Sub

    Private Sub REGISTERACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTERACCOUNTToolStripMenuItem.Click
        If LBLPOS.Text = "ADMIN" Then
            Dim frm As New frmRegForm
            frm.btnReg.Text = "REGISTER"
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.ShowDialog()
        Else
            MsgBox("This account is not allowed to access this module", MsgBoxStyle.Critical, "System Reminder")
        End If

    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        frmLogin.ShowDialog()
    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'HRISMain.ShowDialog()
    End Sub

    Private Sub ACCOUNTLISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmUserList.ShowDialog()
    End Sub

    Private Sub MANAGEACCOUNTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MANAGEACCOUNTToolStripMenuItem.Click
        If LBLPOS.Text = "ADMIN" Then
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

    Private Sub MANAGECHARTOFACCOUNTSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ProductionMain.ShowDialog()
    End Sub


    Private Sub MetroButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventory.Click
        'MsgBox("This Module is not available right now", MsgBoxStyle.Information, "System information")
        frmInventorySystemMain.ShowDialog()
    End Sub

    Private Sub MetroButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPurchasing.Click
        frmPurchaseMain.ShowDialog()
        'MsgBox("This Module is not available right now", MsgBoxStyle.Information, "System information")
    End Sub

    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSales.Click
        frmSalesMain.ShowDialog()
        'MsgBox("This Module is not available right now", MsgBoxStyle.Information, "System information")
    End Sub

    Private Sub MetroButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProd.Click
        'frmProductionMain.ShowDialog()
        MsgBox("This Module is not available right now", MsgBoxStyle.Information, "System information")
    End Sub

    Private Sub MetroButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHR.Click
        'HRISMain.ShowDialog()
        MsgBox("This Module is not available right now", MsgBoxStyle.Information, "System information")
    End Sub

    Private Sub MetroButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccounting.Click
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

    Private Sub CheckForUpdatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        frmUpdate.ShowDialog()
    End Sub

    Private Sub OptionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim acc_ds As New account_dsTableAdapters.tblUsersTableAdapter
            Dim dt = New account_ds.tblUsersDataTable
            acc_ds.Fill(dt, LBLID.Text)
            For Each r As DataRow In dt.Rows
                frmRegForm.txtUserID.Text = r.Item(0).ToString
                frmRegForm.txtUsername.Text = r.Item(1).ToString
                frmRegForm.txtFn.Text = r.Item(3).ToString
                frmRegForm.cmbAccRole.Text = r.Item(4).ToString
                frmRegForm.txtPass.Text = r.Item(2).ToString
                frmRegForm.txtRepass.Text = r.Item(2).ToString
            Next
            frmRegForm.btnReg.Text = "UPDATE"
            frmRegForm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




    Private Sub TRANSACTIONToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRANSACTIONToolStripMenuItem.Click
        TViewer.MODE = "Pending"
        TViewer.StartPosition = FormStartPosition.CenterScreen
        TViewer.Show()
    End Sub
End Class