Public Class frmRawMaterialProduced
    Dim endingbalance As Decimal
    Dim totalCost As Decimal
    Sub generateIssuanceNo()
        Try
            Dim SC As New systemSettings_class
            Dim NO As String
            Dim StrID As String
            SC.tableName = "tblRMP"
            SC.columnName = "RMPNO"
            SC.series = "RMP-"
            SC.generateNo()
            StrID = Mid(SC.result, Len(SC.series) + 1, Len(SC.result))
            NO = SC.series & Format(Val(StrID) + 1, "00000")
            txtIssuanceNo.Text = NO
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") Then
            save()
        End If
    End Sub
    Sub saveaccEntry()
        Dim ae As New accEntry_class
        ae.refno = txtIssuanceNo.Text
        ae.SRC = Me.Text
        ae.account = txtAccount.Text
        ae.memo = txtMemo.Text
        ae.debit = 0
        ae.credit = lblTotalCost.Text
        ae.insert_Acc_entry_class()
        For Each row As DataGridViewRow In dgv.Rows
            ae.account = row.Cells("assetAccount").Value
            ae.debit = row.Cells("Amount").Value
            ae.credit = 0
            ae.job = txtJONo.Text
            ae.insert_Acc_entry_class()
        Next
    End Sub
    Sub save()
        Try
            Dim inventoryClass As New inventory_class
            inventoryClass.command = 0
            inventoryClass.src = Me.Text
            inventoryClass.refNo = txtIssuanceNo.Text
            inventoryClass.transNo = txtIssuanceNo.Text
            inventoryClass.transDate = Format(Now, "MM/dd/yyyy")
            inventoryClass.memo = txtMemo.Text
            inventoryClass.status = "inventory stocked-in in warehouse"
            inventoryClass.insert_rmp()
            For Each row As DataGridViewRow In dgv.Rows
                inventoryClass.itemNo = row.Cells(0).Value
                inventoryClass.unitCost = row.Cells("Unit_Cost").Value
                inventoryClass.qty = row.Cells("Qty").Value
                inventoryClass.job = txtJONo.Text
                inventoryClass.insert_invItem_transaction()
            Next
            saveaccEntry()
            MsgBox("Success", MsgBoxStyle.Information, "System Information")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub get_account_balance()
        Dim ac As New Account_Class
        ac.accountNo = txtAccount.Text
        ac.check_acc_endingbalance()
        endingbalance = ac.dtable.Rows(0).Item("balance")
    End Sub
    Sub get_account_balance_perjob()
        Dim ac As New Account_Class
        ac.accountNo = txtAccount.Text
        ac.check_acc_endingbalance()
        endingbalance = ac.dtable.Rows(0).Item("balance")
    End Sub

    Private Sub frmRawMaterialProduced_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmRawMaterialProduced_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
                For Each row As DataGridViewRow In dgv.SelectedRows
                    dgv.Rows.Remove(row)
                Next
            End If
        End If
    End Sub

    Private Sub frmWidthrawItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateIssuanceNo()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtAccount.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
            get_account_balance()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtQty.Text = "" Then
            txtQty.Text = "1"
        End If
        InventoryList.mode = "Rawmats"
        InventoryList.command = 0
        InventoryList.ShowDialog()
        If InventoryList.clickedItem = True Then
            dgv.Rows.Add(InventoryList.dgv.CurrentRow.Cells(0).Value, InventoryList.dgv.CurrentRow.Cells(1).Value, _
                         InventoryList.dgv.CurrentRow.Cells(2).Value, txtQty.Text, _
                         "0.00", _
                         "0.00", InventoryList.dgv.CurrentRow.Cells("AssetAccount").Value)
            InventoryList.clickedItem = False
        End If
        ROWCHANGES()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            frmGetRequisitionItemList.Close()
            frmGetRequisitionItemList.viewList_itemRequisition()
            frmGetRequisitionItemList.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAccount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccount.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccount.Text
        AC.get_accountInfo()
        lblAccount.Text = AC.accDesc
    End Sub
    Sub ROWCHANGES()
        Dim totalCost As Decimal
        Dim totalQTY As Decimal
        For Each row As DataGridViewRow In dgv.Rows
            totalQTY += CDec(row.Cells("Qty").Value)
        Next
        For Each row As DataGridViewRow In dgv.Rows
            row.Cells("Unit_Cost").Value = (endingbalance / totalQTY).ToString("N")
            row.Cells("Amount").Value = ((endingbalance / totalQTY) * CDec(row.Cells("Qty").Value)).ToString("N")
            totalCost += CDec(row.Cells("Amount").Value).ToString("N")
        Next
        lblTotalCost.Text = totalCost.ToString("N")
    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        ROWCHANGES()
    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        ROWCHANGES()
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmJob_list.ShowDialog()
        If frmJob_list.clickedItem = True Then
            txtJONo.Text = frmJob_list.dgv.CurrentRow.Cells(1).Value
            frmJob_list.clickedItem = False
        End If
    End Sub
End Class