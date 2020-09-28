Public Class frmVoucher
    Dim cardBalance As Decimal
    Dim command As Integer

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmAccountList.mode = "Checkvoucher"
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            Dim r As Integer = dgv.Rows.Count
            dgv.Rows.Add()
            dgv.Item(0, r).Value = frmAccountList.dgv.CurrentRow.Cells(0).Value
            dgv.Item(2, r).Value = "0.00"
            dgv.Item(3, r).Value = "0.00"
            frmAccountList.successClick = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each row As DataGridViewRow In dgv.SelectedRows
            lblTotCredit.Text = CDbl(CDbl(lblTotCredit.Text) - CDbl(dgv.CurrentRow.Cells(2).Value)).ToString("#,##0.00")
            dgv.Rows.Remove(row)
        Next
    End Sub



    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If
    End Sub


    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        Try
            lblTotAmount.Text = Format(CDbl(txtAmount.Text), "N")
        Catch ex As Exception
            lblTotAmount.Text = "0.00"
        End Try
    End Sub

    Sub generateNo()
        Try
            Dim SC As New systemSettings_class
            Dim NO As String
            Dim StrID As String
            SC.tableName = "tblVoucher"
            SC.columnName = "voucherNo"
            SC.series = "VN-"
            SC.generateNo()
            StrID = Mid(SC.result, Len(SC.series) + 1, Len(SC.result))
            NO = SC.series & Format(Val(StrID) + 1, "00000")
            txtNo.Text = NO
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub PRINT_VOUCHER_SLIP()
        Dim AC As New Accounting_class
        AC.transNo = txtNo.Text
        AC.PRINT_VOUCHER_SLIP()

    End Sub
    Sub save()
        If MsgBox("ARE YOU SURE YOU WANT TO CREATE AND SAVE  VOUCHER ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            If btnSave.Text = "POST" Then
                command = 0
            ElseIf btnSave.Text = "UPDATE" Then
                command = 1
            End If
            Dim AC As New Accounting_class
            AC.command = command
            AC.transNo = txtNo.Text
            AC.refNo = ""
            AC.cardID = txtCardID.Text
            AC.amount = CDec(txtAmount.Text)
            AC.remarks = txtMEmo.Text
            AC.insert_update_voucher()
            saveAccEntry()
        End If
    End Sub
    Sub saveAccEntry()
        Dim ac As New accEntry_class
        ac.refno = txtNo.Text
        ac.SRC = Me.Text
        ac.account = txtAccVPayable.Text
        ac.memo = txtMEmo.Text
        ac.debit = 0
        ac.credit = CDec(lblTotDebit.Text) - CDec(lblTotCredit.Text)
        ac.cardID = txtCardID.Text
        ac.insert_Acc_entry_class()
        For Each row As DataGridViewRow In dgv.Rows
            ac.refno = txtNo.Text
            ac.account = row.Cells(0).Value
            ac.memo = txtMEmo.Text
            ac.debit = row.Cells(2).Value
            ac.credit = row.Cells(3).Value
            ac.cardID = txtCardID.Text
            ac.insert_Acc_entry_class()
        Next
    End Sub

    Sub getAccName()
        Dim ac As New Account_Class
        For Each row As DataGridViewRow In dgv.Rows
            ac.searchValue = row.Cells(0).Value
            ac.getaccountName()
            row.Cells(1).Value = ac.AccName
        Next
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Try
            If dgv.CurrentCell.ColumnIndex = 2 Then
                Dim dbt As Decimal = InputBox("Debit Value")
                dgv.CurrentRow.Cells(2).Value = Format(dbt, "N")
            ElseIf dgv.CurrentCell.ColumnIndex = 3 Then
                Dim cdt As Decimal = InputBox("Credit Value")
                dgv.CurrentRow.Cells(3).Value = Format(cdt, "N")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        getAccName()
        Dim cdt As Decimal = 0
        Dim dbt As Decimal = 0
        For Each row As DataGridViewRow In dgv.Rows
            dbt += row.Cells(2).Value
            cdt += row.Cells(3).Value
        Next
        lblTotDebit.Text = Format(dbt, "N")
        lblTotCredit.Text = Format(cdt, "N")

    End Sub

    Private Sub frmVoucher_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateNo()
        Dim ss As New systemSettings_class
        ss.settingsName = Me.Text & "_VouchersPayableACC"
        ss.settingsValue = txtAccVPayable.Text
        ss.get_settingsValue()
        txtAccVPayable.Text = ss.return_settingsValue
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            frmCardListForSelection.formMode = "Voucher"
            frmCardListForSelection.ShowDialog()
            If frmCardListForSelection.itemClick = True Then
                txtCardID.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(0).Text
                lblName.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(1).Text
                cardBalance = frmCardListForSelection.LV.SelectedItems(0).SubItems(4).Text
                frmCardListForSelection.itemClick = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'If CDbl(lblTotAmount.Text) <> CDbl(lblTotDebit.Text) Then
        '    MsgBox("Value you inputed is not match", MsgBoxStyle.Critical, "Invalid")
        '    Exit Sub
        'End If
        Try
            save()
            MsgBox("Transaction Successfully Saved", MsgBoxStyle.Information, "Success")
            If MsgBox("DO YOU WANT TO PRINT VOUCHER PAYABLE SLIP ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "VOUCHER PAYABLE SLIP") = MsgBoxResult.Yes Then
                PRINT_VOUCHER_SLIP()
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ss As New systemSettings_class
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtAccVPayable.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
            ss.settingsName = Me.Text & "_VouchersPayableACC"
            ss.settingsValue = txtAccVPayable.Text
            ss.insert_update_settingsVariable()
        End If
    End Sub
    Private Sub txtAccVPayable_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccVPayable.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccVPayable.Text
        AC.get_accountInfo()
        lblAccVPayable.Text = AC.accDesc
    End Sub

    Private Sub txtCardID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCardID.TextChanged

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
    End Sub

    Private Sub lblAccVPayable_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAccVPayable.TextChanged

    End Sub
End Class