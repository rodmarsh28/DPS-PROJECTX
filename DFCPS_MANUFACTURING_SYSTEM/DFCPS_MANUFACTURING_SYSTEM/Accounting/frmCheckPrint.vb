Public Class frmCheckPrint
    Public bankAccno As String
    Public cardID As String
    Public rpttemp As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        formBankSelection.get_CheckbookList()
        formBankSelection.mode = "checkbookList"
        formBankSelection.ShowDialog()
        If formBankSelection.itemClicked = True Then
            txtCheckbookID.Text = formBankSelection.dgv.CurrentRow.Cells(0).Value
            txtBankName.Text = formBankSelection.dgv.CurrentRow.Cells(2).Value
            txtCheckno.Text = Format(Val(formBankSelection.dgv.CurrentRow.Cells(5).Value) + 1, "0000000000")
            BANKACCNO = formBankSelection.dgv.CurrentRow.Cells(8).Value
            formBankSelection.itemClicked = False
        End If
    End Sub
    Sub update_CheckVoucher_status()
        Dim ac As New Accounting_class
        ac.transNo = txtRefNo.Text
        ac.status = "Check No. " & txtCheckno.Text & " Issued Date of " & Now.ToString("yyyy/MM/dd")
        ac.update_checkvoucher_status()
    End Sub
    Sub save()
        accEntry()
        print_check_preview()
    End Sub
    Sub print_check_preview()
        Dim ac As New Accounting_class
        rpttemp = New check_print_preview
        ac.command = 0
        ac.transNo = txtRefNo.Text
        ac.PRINT_CHECK()
        frmCheck_print_preview.CrystalReportViewer1.ReportSource = ac.rptDoc
        frmCheck_print_preview.ShowDialog()
        Me.Close()
    End Sub
    Sub accEntry()
        Dim ac As New Accounting_class
        Dim ae As New accEntry_class
        ac.command = 0
        ac.refNo = txtRefNo.Text

        ac.transNo = txtRefNo.Text
        ac.src = frmCheckVoucher.Text
        ac.payee = txtPayee.Text
        ac.checkbookid = txtCheckbookID.Text
        ac.checkNo = txtCheckno.Text
        ac.cardID = cardID
        ac.amount = txtTotAmount.Text
        ac.CHECKDATE = dtpCheckDate.Value.ToString("yyyy/MM/dd")
        ac.status = "Outstanding Check"
        ac.get_temp_accEntry()
        ac.insert_CheckTransaction()
        ae.refno = txtRefNo.Text
        ae.account = bankAccno
        ae.SRC = frmCheckVoucher.Text
        ae.memo = txtRemarks.Text
        ae.debit = 0
        ae.credit = CDbl(txtTotAmount.Text)
        ae.cardID = cardID
        ae.insert_Acc_entry_class()
        update_CheckVoucher_status()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
            Try
                save()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub frmCheckPrint_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmCheckPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class