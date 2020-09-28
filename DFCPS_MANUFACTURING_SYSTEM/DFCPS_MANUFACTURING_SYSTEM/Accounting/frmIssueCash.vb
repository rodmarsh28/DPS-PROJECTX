Public Class frmIssueCash
    Public cardID As String
    Private Sub txtAccAsset_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccAsset.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccAsset.Text
        AC.get_accountInfo()
        lblAccAsset.Text = AC.accDesc
    End Sub
    Sub saveAccountSettings()
        Dim sysSettings As New systemSettings_class
        sysSettings.settingsName = Me.Text & "_AssetAcc"
        sysSettings.settingsValue = txtAccAsset.Text
        sysSettings.insert_update_settingsVariable()
    End Sub
    Sub getAccountSettings()
        Dim sysSettings As New systemSettings_class
        sysSettings.settingsName = Me.Text & "_AssetAcc"
        sysSettings.settingsValue = txtAccAsset.Text
        sysSettings.get_settingsValue()
        txtAccAsset.Text = sysSettings.return_settingsValue
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtAccAsset.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
            saveAccountSettings()
        End If
    End Sub

    Private Sub frmIssueCash_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmIssueCash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccountSettings()
    End Sub
    Sub accEntry()
        Dim ac As New Accounting_class
        Dim ae As New accEntry_class
        ac.command = 0
        ac.refNo = txtRefNo.Text

        ac.transNo = txtRefNo.Text
        ac.src = frmCheckVoucher.Text
        ac.get_temp_accEntry()
        ae.refno = txtRefNo.Text
        ae.account = txtAccAsset.Text
        ae.SRC = frmCheckVoucher.Text
        ae.memo = txtMemo.Text
        ae.debit = 0
        ae.credit = CDbl(txtAmount.Text)
        ae.cardID = cardID
        ae.insert_Acc_entry_class()
        update_CheckVoucher_status()
    End Sub
    Sub update_CheckVoucher_status()
        Dim ac As New Accounting_class
        ac.transNo = txtRefNo.Text
        ac.status = "Cash Issued Date of " & Now.ToString("yyyy/MM/dd")
        ac.update_checkvoucher_status()
    End Sub

    Private Sub txtRefNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REFNO.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            accEntry()
            MsgBox("Cash Succesfully issued", MsgBoxStyle.Information, "System Information")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class