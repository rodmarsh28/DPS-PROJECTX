Public Class frmCashRequisition
    Public notimesedit As Integer
    Sub generateNo()
        Try
            Dim SC As New systemSettings_class
            Dim NO As String
            Dim StrID As String
            SC.tableName = "tblCashRequisition"
            SC.columnName = "CRSNO"
            SC.series = "CRS-"
            SC.generateNo()
            StrID = Mid(SC.result, Len(SC.series) + 1, Len(SC.result))
            NO = SC.series & Format(Val(StrID) + 1, "00000")
            txtNo.Text = NO
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If txtCardID.Text = "" Then
        '    Exit Sub
        'End If
        'itemSelectorForm.cardID = txtCardID.Text
        'itemSelectorForm.get_voucher_list()
        'itemSelectorForm.ShowDialog()
        'If itemSelectorForm.successClicked = True Then
        '    Dim AC As New Accounting_class
        '    Dim alreadyPut As Boolean = False
        '    For Each row As DataGridViewRow In itemSelectorForm.dgv.SelectedRows
        '        For Each dgvrow As DataGridViewRow In dgv.Rows
        '            If row.Cells(1).Value = dgvrow.Cells(0).Value Then
        '                alreadyPut = True
        '            End If
        '        Next
        '        If alreadyPut = False Then
        '            AC.command = 1
        '            AC.transNo = row.Cells(1).Value
        '            AC.GET_ACCNO_OF_TRNO()
        '            dgv.Rows.Add(row.Cells(1).Value, row.Cells(1).Value, row.Cells(4).Value, CDbl(0).ToString("N"), AC.accNo)
        '        End If
        '    Next
        '    itemSelectorForm.successClicked = False
        '    updateTotValue()
        'End If
        Dim particulars As String = InputBox("Particulars", "System Dialog")
        dgv.Rows.Add(particulars, "0.00", "0.00")
        updateTotValue()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmCardListForSelection.formMode = "PAYABLE"
        frmCardListForSelection.ShowDialog()
        Try
            If frmCardListForSelection.itemClick = True Then
                txtCardID.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(0).Text
                txtCardName.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(1).Text
                frmCardListForSelection.itemClick = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each row As DataGridViewRow In dgv.SelectedRows
            dgv.Rows.Remove(row)
        Next
        updateTotValue()
    End Sub
    Sub updateTotValue()
        Dim totAmount As Decimal = 0
        Dim totaa As Decimal = 0
        For Each row As DataGridViewRow In dgv.Rows
            totAmount = totAmount + row.Cells(1).Value
            totaa = totaa + row.Cells(2).Value
        Next
        lblTotAmount.Text = totAmount.ToString("N")
        lblAA.Text = totaa.ToString("N")
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Try
            If dgv.CurrentCell.ColumnIndex = 1 Then
                Dim amount As Decimal = InputBox("Amount Value", "System Dialog")
                dgv.CurrentRow.Cells(1).Value = amount.ToString("N")
            ElseIf dgv.CurrentCell.ColumnIndex = 2 Then
                Dim amountApplied As Decimal = InputBox("Applied Amount Value", "System Dialog")
                dgv.CurrentRow.Cells(2).Value = amountApplied.ToString("N")
            End If
            Catch ex As Exception
        End Try

    End Sub

    Private Sub dgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        updateTotValue()
    End Sub

    Sub SAVE()
        Dim ac As New Accounting_class
        Dim count As Integer = 0
        For Each ROW As DataGridViewRow In dgv.Rows
            If btnSave.Text = "Update" Then
                ac.command = 2
            Else
                ac.command = 0
            End If
            ac.transNo = txtNo.Text
            ac.cardID = txtCardID.Text
            ac.particulars = ROW.Cells(0).Value
            ac.amount = ROW.Cells(1).Value
            ac.amountValue = ROW.Cells(2).Value
            ac.remarks = txtRemarks.Text
            ac.totAmount = lblTotAmount.Text
            ac.appliedValue = lblAA.Text
            ac.status = "Waiting for Approval"
            ac.notimesedit = notimesedit
            ac.count = count
            ac.insert_update_cashRequistion()
            count += 1
        Next
    End Sub
    Sub print_slip()
        Dim ac As New Accounting_class
        ac.command = 0
        ac.searchValue = txtNo.Text
        ac.GET_CASH_REQUISISTION_FORPRINT()
    End Sub

    Private Sub frmCashRequisition_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmCashRequisition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If btnSave.Text <> "Update" Then
            generateNo()
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
            Try
                    SAVE()
                    print_slip()
                MsgBox("Cash Requisition Posted !", MsgBoxStyle.Information, "System Reminder")
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        print_slip()
    End Sub
End Class