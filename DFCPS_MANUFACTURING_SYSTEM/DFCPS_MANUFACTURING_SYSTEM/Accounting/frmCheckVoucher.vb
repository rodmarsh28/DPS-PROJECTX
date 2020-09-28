Public Class frmCheckVoucher
    Dim nl As Integer = 0
    Dim checkbookID As String
    Dim particulars As String
    Dim partamount As Double
    Dim accEntryId As String
    Dim accno As String
    Dim debit As Double
    Dim credit As Double
    Public Totamount As Double = 0.0
    Public totDebit As Double = 0.0
    Public totCredit As Double = 0.0
    Dim No As String = ""
    Dim command As Integer
    Public mode As String
    Public BANKACCNO As String
    Public cardID As String

    Sub selectCVNo()
        Dim StrID As String
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT checkVoucherNo from tblCheckVoucher order by checkVoucherNo DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 6, Len(OleDBDR(0)))
                txtCVNo.Text = "CV-" & Format(Val(StrID) + 1, "00000")
            Else
                txtCVNo.Text = "CV-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub save()
        If MsgBox("ARE YOU SURE YOU WANT TO CREATE AND SAVE CASH / CHECK VOUCHER ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Try
                Dim ac As New Accounting_class
                ac.command = command
                ac.transNo = txtCVNo.Text
                ac.refNo = txtReqNo.Text
                ac.transDate = Now
                ac.type = cmbType.Text
                ac.tinNo = txtTIN.Text
                ac.cardID = cardID
                ac.address = txtAddress.Text
                ac.totAmount = lblTotAmount.Text
                ac.amountinWords = txtAmountinWords.Text
                ac.remarks = txtMemo.Text
                ac.status = "Waiting for Approval"
                ac.insert_update_checkvoucher()
                saveParticulars()
                posPendingAccEntry()
                updateVoucherStatus()
                'updateRFP()
                MsgBox("TRANSACTION COMPLETED !", MsgBoxStyle.Information, "SUCCESS")
                Me.Close()
                frmVoucher_Payable_List.GET_PAYABLES()
                If MsgBox("DO YOU WANT TO PRINT CASH/CHECK VOUCHER ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
                    ac.command = 0
                    ac.searchValue = txtCVNo.Text
                    ac.GET_CHECK_VOUCHER_FORPRINT()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Sub print_cv_slip()

    End Sub
    Sub updateRFP()
        Dim req As New Puchase_Requisition_class
        req.command = 2
        req.transNo = txtReqNo.Text
        req.src = Form.ActiveForm.Text
        req.totAmount = Totamount
        req.status = txtCVNo.Text & " Prepared"
        req.insert_RFP()
    End Sub
    Sub saveParticulars()
        Dim ac As New Accounting_class
        Dim count As Integer = 0
        ac.command = 1
        For Each row As DataGridViewRow In dgvPart.Rows
            ac.transNo = txtCVNo.Text
            ac.remarks = row.Cells(1).Value
            ac.amountValue = row.Cells(2).Value
            ac.appliedValue = row.Cells(3).Value
            ac.voucherNo = row.Cells(0).Value
            ac.count = count
            ac.insert_update_particulars()
            count += 1
        Next
    End Sub
    Sub posPendingAccEntry()
        Dim ac As New Accounting_class
        Dim count As Integer = 0
        For Each row As DataGridViewRow In dgvPart.Rows
            ac.command = 0
            ac.transNo = txtCVNo.Text
            ac.accNo = row.Cells(4).Value
            ac.remarks = row.Cells(1).Value
            ac.totDebit = row.Cells(3).Value
            ac.totCredit = 0
            ac.status = "Pending"
            ac.count = count
            ac.insert_delete_pending_AccEntry()
            count += 1
        Next
    End Sub
    Sub updateVoucherStatus()
        Dim ac As New Accounting_class
        For Each row As DataGridViewRow In dgvPart.Rows
            If CDbl(row.Cells(2).Value) = CDbl(row.Cells(3).Value) Then
                ac.transNo = row.Cells(0).Value
                ac.update_voucher_status()
            End If
        Next
    End Sub

    Sub printCheque()

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'For Each row As DataGridViewRow In dgv.SelectedRows
        '    Totamount = Totamount - dgv.CurrentRow.Cells(1).Value
        '    dgv.Rows.Remove(row)
        '    lblTotAmount.Text = CDbl(Totamount).ToString("#,##0.00")
        'Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'For Each row As DataGridViewRow In dgv.SelectedRows
        '    totDebit = totDebit - dgv.CurrentRow.Cells(3).Value
        '    totCredit = totCredit - dgv.CurrentRow.Cells(4).Value
        '    dgv.Rows.Remove(row)
        '    lblDebit.Text = CDbl(totDebit).ToString("#,##0.00")
        '    lblCredit.Text = CDbl(totCredit).ToString("#,##0.00")
        'Next
    End Sub


    Private Sub txtAmountinWords_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmountinWords.TextChanged
        txtAmountinWords.Text = UCase(txtAmountinWords.Text)
    End Sub

    Private Sub btnGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub lblTotAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTotAmount.TextChanged
        If lblTotAmount.Text = "0" Then
            txtAmountinWords.Text = ""
        Else
            txtAmountinWords.Text = ConvertNumberToENG(CDbl(lblTotAmount.Text))
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If dgvPart.RowCount = 0 Or cmbType.SelectedIndex = -1 Then
            MsgBox("You can't save this transaction", MsgBoxStyle.Critical, "System Information")
            Exit Sub
        End If
        If btnSave.Text = "Record" Then
            command = 0
        ElseIf btnSave.Text = "Update" Then
            command = 1
        End If
        If lblTotAmount.Text = lblAA.Text Then
            save()
        Else
            MsgBox("THE AMOUNT YOU INPUT IS NOT BALANCED, PLEASE CHECK AND TRY AGAIN", MsgBoxStyle.Critical, "ERROR")
        End If
    End Sub
    'Sub getAccName()
    '    Dim ac As New Account_Class
    '    For Each row As DataGridViewRow In dgv.Rows
    '        ac.searchValue = row.Cells(0).Value
    '        ac.getaccountName()
    '        row.Cells(1).Value = ac.AccName
    '    Next
    'End Sub

    Private Sub frmCheckVoucher_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub frmCheckVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If btnSave.Text <> "Update" Then
            selectCVNo()
        End If
        updateTotal()
        cmbType.SelectedIndex = 0
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmAccountList.mode = "Checkvoucher"
        'frmAccountList.ShowDialog()
        'If frmAccountList.successClick = True Then
        '    Dim r As Integer = dgv.Rows.Count
        '    dgv.Rows.Add()
        '    dgv.Item(0, r).Value = frmAccountList.dgv.CurrentRow.Cells(0).Value
        '    dgv.Item(2, r).Value = txtMemo.Text
        '    dgv.Item(3, r).Value = "0.00"
        '    dgv.Item(4, r).Value = "0.00"
        '    frmAccountList.successClick = False
        'End If
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    'Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    '    Try
    '        If dgv.CurrentCell.ColumnIndex = 3 Then
    '            Dim dbt As Decimal = InputBox("Debit Value")
    '            dgv.CurrentRow.Cells(3).Value = Format(dbt, "N")

    '        ElseIf dgv.CurrentCell.ColumnIndex = 4 Then
    '            Dim cdt As Decimal = InputBox("Credit Value")
    '            dgv.CurrentRow.Cells(4).Value = Format(cdt, "N")
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub dgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'getAccName()
        'Dim cdt As Decimal
        'Dim dbt As Decimal
        'For Each row As DataGridViewRow In dgv.Rows
        '    dbt += row.Cells(3).Value
        '    cdt += row.Cells(4).Value
        'Next
        'lblDebit.Text = Format(dbt, "N")
        'lblCredit.Text = Format(cdt, "N")
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        Try
            lblTotAmount.Text = Format(CDbl(txtAmount.Text), "N")
        Catch ex As Exception
            lblTotAmount.Text = "0.00"
        End Try

    End Sub

    Private Sub lblTotAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTotAmount.Click

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'formBankSelection.get_CheckbookList()
        'formBankSelection.mode = "checkbookList"
        'formBankSelection.ShowDialog()
        'If formBankSelection.itemClicked = True Then
        '    checkbookID = formBankSelection.dgv.CurrentRow.Cells(0).Value
        '    txtBankName.Text = formBankSelection.dgv.CurrentRow.Cells(2).Value
        '    BANKACCNO = formBankSelection.dgv.CurrentRow.Cells(8).Value
        '    MsgBox(BANKACCNO)
        '    formBankSelection.itemClicked = False
        'End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    Dim particulars As String = InputBox("Particulars", "Please Enter")
        '    Dim xamount As Decimal = InputBox("Amount", "Please Enter")
        '    dgvPart.Rows.Add(particulars, xamount)
        'Catch ex As Exception
        '    MsgBox("Please Enter Numeric Amount", MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'For Each row As DataGridViewRow In dgvPart.SelectedRows
        '    dgvPart.Rows.Remove(row)
        'Next
    End Sub

    Private Sub dgvPart_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPart.CellMouseDoubleClick
        If dgvPart.CurrentCell.ColumnIndex = 3 Then
            Try
                Dim aa As Decimal = InputBox("Amount Applied Value")
                dgvPart.CurrentRow.Cells(3).Value = Format(aa, "N")
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub updateTotal()
        Dim totAA As Decimal = 0
        Dim totFP As Decimal = 0
        For Each row As DataGridViewRow In dgvPart.Rows
            If CDbl(row.Cells(2).Value) = CDbl(row.Cells(3).Value) Then
                row.Cells(1).Value = "Representing Full Payment of Voucher No. " & row.Cells(0).Value & ""
            ElseIf CDbl(row.Cells(3).Value) = 0 Then
            ElseIf CDbl(row.Cells(2).Value) > CDbl(row.Cells(3).Value) Then
                row.Cells(1).Value = "Representing Partial Payment of Voucher No. " & row.Cells(0).Value & ""
            End If
            totFP += CDbl(row.Cells(2).Value)
            totAA += CDbl(row.Cells(3).Value)
            lblFP.Text = totFP.ToString("N")
            lblAA.Text = totAA.ToString("N")
        Next
    End Sub

    Private Sub dgvPart_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPart.CellValueChanged
        updateTotal()
    End Sub

    Private Sub dgvPart_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPart.MouseDown
        Try
            If e.Button = MouseButtons.Right Then
                If dgvPart.SelectedRows.Count > 0 Then
                    dgvPart.ContextMenuStrip = ContextMenuStrip1
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgvPart.ContextMenuStrip = Nothing
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        For Each ROW As DataGridViewRow In dgvPart.SelectedRows
            dgvPart.Rows.Remove(ROW)
        Next
    End Sub

    Private Sub dgvPart_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPart.CellContentClick

    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtPayee.Text = "" Then
            Exit Sub
        End If
        itemSelectorForm.cardID = cardID
        itemSelectorForm.get_voucher_list()
        itemSelectorForm.ShowDialog()
        If itemSelectorForm.successClicked = True Then
            Dim AC As New Accounting_class
            Dim alreadyPut As Boolean = False
            For Each row As DataGridViewRow In itemSelectorForm.dgv.SelectedRows
                For Each dgvrow As DataGridViewRow In dgvPart.Rows
                    If row.Cells(1).Value = dgvrow.Cells(0).Value Then
                        alreadyPut = True
                    End If
                Next
                If alreadyPut = False Then
                    AC.command = 1
                    AC.transNo = row.Cells(1).Value
                    AC.GET_ACCNO_OF_TRNO()
                    dgvPart.Rows.Add(row.Cells(1).Value, row.Cells(1).Value, row.Cells(4).Value, CDbl(0).ToString("N"), AC.accNo)
                End If
            Next
            itemSelectorForm.successClicked = False
            updateTotal()
        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmCardListForSelection.formMode = "PAYABLE"
        frmCardListForSelection.ShowDialog()
        Try
            If frmCardListForSelection.itemClick = True Then
                cardID = frmCardListForSelection.LV.SelectedItems(0).SubItems(0).Text
                txtPayee.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(1).Text
                frmCardListForSelection.itemClick = False
            End If
            Dim ac As New Accounting_class
            ac.cardID = cardID
            ac.get_card_info()
            txtAddress.Text = ac.cardAddress
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each row As DataGridViewRow In dgvPart.SelectedRows
            dgvPart.Rows.Remove(row)
        Next
        updateTotal()
    End Sub
End Class