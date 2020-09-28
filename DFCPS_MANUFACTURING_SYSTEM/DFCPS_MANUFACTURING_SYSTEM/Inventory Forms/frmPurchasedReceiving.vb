Imports System.Data.SqlClient

Public Class frmPurchasedReceiving
    Public cardID As String
    Public invoiceNo As String
    Private WithEvents p_event As New public_event_class
    Public totAmount As Double
    Dim row1 As Integer

    Dim clearingAccount As String
    Dim allitemsreceived As Integer
    Dim lastvalueEntered As String
    Dim CVNO As String

    Private Sub VariableChanged(ByVal NewValue As Integer) Handles p_event.VariableChanged
    End Sub

    Sub generateNo()
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
                .CommandText = "SELECT purchaseReceivingNo from tblPurchaseReceived order by purchaseReceivingNo DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = OleDBDR.Item(0).Substring(OleDBDR.Item(0).Length - 5)
                transNo.Text = "REC-" & Format(Val(StrID) + 1, "00000")
            Else
                transNo.Text = "REC-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub frmPurchasedReceiving_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
            Me.Dispose()
    End Sub

    Private Sub frmPurchasedReceiving_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub frmPurchasedReceiving_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
       
    End Sub

    Private Sub frmPurchasedReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateNo()
        'get_exist_cvinfo()
        totAmount = 0.0
        lblTotal.Text = "Php " & Format(CDbl(totAmount), "N")
        dgv.Columns(5).ReadOnly = True
        dgv.Columns(1).ReadOnly = True
        dgv.Columns(2).ReadOnly = True
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
        InventoryList.mode = "Receiving"
        InventoryList.ShowDialog()
        If InventoryList.clickedItem = True Then
            Dim r As Integer = dgv.Rows.Count
            dgv.Rows.Add()
            dgv.Item(0, r).Value = InventoryList.dgv.CurrentRow.Cells(0).Value
            InventoryList.clickedItem = False
            txtQty.Text = "1"
            lblTotal.Text = "Php " & Format(totAmount, "N")
        End If
    End Sub
    Sub RECEIVEDITEMS()
        Try
            Dim col As Integer
            Dim command As Integer
            col = 0
            row1 = dgv.RowCount
            While col < row1
                If BTNSAVE.Text = "&POST" Then
                    command = 0
                Else
                    command = 1
                End If
                Dim cmd As New SqlCommand("insert_Purchase_Receiving", conn)
                conn.Close()
                ConnectDatabase()
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.AddWithValue("@COMMAND", SqlDbType.VarChar).Value = command
                    .Parameters.AddWithValue("@AIR", SqlDbType.Int).Value = allitemsreceived
                    .Parameters.AddWithValue("@TRANSNO", SqlDbType.VarChar).Value = transNo.Text
                    .Parameters.AddWithValue("@REFNO", SqlDbType.VarChar).Value = txtRefNo.Text
                    .Parameters.AddWithValue("@INVOICENO", SqlDbType.VarChar).Value = txtInvoice.Text
                    .Parameters.AddWithValue("@CARDID", SqlDbType.Date).Value = cardID
                    .Parameters.AddWithValue("@ITEMNO", SqlDbType.VarChar).Value = dgv.Item(0, col).Value
                    .Parameters.AddWithValue("@QTY", SqlDbType.VarChar).Value = dgv.Item(4, col).Value
                    .Parameters.AddWithValue("@UPRICE", SqlDbType.Decimal).Value = dgv.Item(3, col).Value
                    .Parameters.AddWithValue("@AMOUNT", SqlDbType.VarChar).Value = dgv.Item(5, col).Value
                    .Parameters.AddWithValue("@USERID", SqlDbType.VarChar).Value = MainForm.LBLID.Text
                    .Parameters.AddWithValue("@STATUS", SqlDbType.VarChar).Value = "PURCHASE RECEIVED " & Now.ToString("MM/dd/yyyy")
                End With
                cmd.ExecuteNonQuery()
                col = col + 1
            End While
            ADD_INVENTORY()
            'add_payables()
            account_entry()
            account_credit_entry()
            MsgBox(lblFormMode.Text & " POSTED !", MsgBoxStyle.Information, "SUCCESS")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub addVoucher()
        Dim AC As New Accounting_class
        AC.command = 0
        AC.transNo = txtInvoice.Text
        AC.refNo = ""
        AC.cardID = cardID
        AC.amount = CDec(lblTotal.Text)
        AC.remarks = "Payable for Purchase Received No: " & txtInvoice.Text
        AC.insert_update_voucher()
    End Sub
    Sub account_entry()
        Dim ac As New accEntry_class
        For Each row As DataGridViewRow In dgv.Rows
            ac.refno = txtInvoice.Text
            ac.account = row.Cells(6).Value
            ac.memo = txtMemo.Text
            ac.debit = row.Cells(5).Value
            ac.credit = 0
            ac.cardID = cardID
            ac.insert_Acc_entry_class()
        Next
    End Sub
    Sub account_credit_entry()
        Dim ac As New accEntry_class
        For Each row As DataGridViewRow In dgvAccEntry.Rows
            ac.refno = txtInvoice.Text
            ac.account = row.Cells(0).Value
            ac.memo = txtMemo.Text
            ac.debit = 0
            ac.credit = row.Cells(2).Value
            ac.cardID = cardID
            ac.insert_Acc_entry_class()
        Next
    End Sub
    Sub add_payables()
        Dim payable As New payable_class
        payable.command = 0
        payable.transNo = transNo.Text
        payable.src = Form.ActiveForm.Text
        payable.payment = cmbPayment.Text
        payable.dueDate = Format(DTPDUEDATE.Value, "yyyy/MM/dd")
        payable.totAmount = totAmount
        payable.status = "Item Received"
        payable.insert_update_payables()
    End Sub
    Sub ADD_INVENTORY()
        Dim inventoryClass As New inventory_class
        For Each row As DataGridViewRow In dgv.Rows
            inventoryClass.refNo = txtRefNo.Text
            inventoryClass.itemNo = row.Cells(0).Value
            inventoryClass.unitCost = row.Cells(3).Value
            inventoryClass.qty = row.Cells(4).Value
            inventoryClass.insert_invItem_transaction()
        Next

    End Sub
    Sub generateAccountEntry()
        Dim ac As New Account_Class
        ac.searchValue = dgv.CurrentRow.Cells(0).Value
        ac.get_itemAccountInfo()
        Dim hasrows As Integer = 0
        Dim totalAmount As Double
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells(6).Value = dgv.CurrentRow.Cells(6).Value Then
                totalAmount = CDbl(totalAmount) + CDbl(row.Cells(5).Value)
            End If
        Next
        For Each row As DataGridViewRow In dgvAccEntry.Rows
            If row.Cells(0).Value = ac.assetAcc Then
                row.Cells(2).Value = totalAmount
                hasrows = +1
            End If
          
        Next
        If hasrows < 1 Then
            Dim r As Integer = dgvAccEntry.Rows.Count
            dgvAccEntry.Rows.Add()
            dgvAccEntry.Item(0, r).Value = ac.assetAcc
            dgvAccEntry.Item(2, r).Value = dgv.CurrentRow.Cells(5).Value
            dgvAccEntry.Item(3, r).Value = "0.00"
        End If
    End Sub
    Private Sub lblTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTotal.TextChanged
    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    btnSearch.PerformClick()
        'End If

    End Sub
    Sub sumofAmount()
        totAmount = 0
        For i As Integer = 0 To dgv.Rows.Count() - 1 Step +1
            totAmount = totAmount + dgv.Rows(i).Cells(5).Value
        Next
        lblTotal.Text = "Php " & Format(totAmount, "N")
        lblTotDeb.Text = "Php " & Format(totAmount, "N")
    End Sub
    Sub sumofAmountPerAccount()
        totAmount = 0
      
    End Sub
    Sub get_purchased_items()
        Dim pc As New Puchase_Requisition_class
        pc.command = "PURCHASE_ORDER"
        pc.searchValue = txtRefNo.Text
        pc.get_purchased_items()
        For Each row As DataRow In pc.dtable.Rows
            Dim ac As New Account_Class
            ac.searchValue = row("ITEMNO")
            ac.get_itemAccountInfo()
            dgv.Rows.Add(row("ITEMNO"), ac.itemdesc, ac.unit, CDec(ac.unitprice), CDec(row("qty")).ToString("N"), (ac.unitprice * CDec(row("qty"))).ToString("N"))
        Next
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        If dgv.CurrentCell.ColumnIndex = 4 Then
            Try
                Dim qty As Integer = InputBox("Enter Qty")
                dgv.CurrentRow.Cells(4).Value = qty.ToString("N0")
                dgv.CurrentRow.Cells(5).Value = (CDec(dgv.CurrentRow.Cells(3).Value) * qty).ToString("N")
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub dgv_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDown

    End Sub


    Private Sub dgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        Try
            If dgv.CurrentCell.ColumnIndex = 5 Then
                Exit Sub
            End If
            If dgv.CurrentCell.ColumnIndex = 0 Then
                Dim ac As New Account_Class
                ac.searchValue = dgv.Item(0, dgv.Rows.Count).Value
                ac.get_itemAccountInfo()
                dgv.Rows(dgv.CurrentRow.Index).Cells(1).Value = ac.itemdesc
                dgv.Rows(dgv.CurrentRow.Index).Cells(2).Value = ac.unit
                dgv.Rows(dgv.CurrentRow.Index).Cells(3).Value = Format(ac.unitprice, "N")
                dgv.Rows(dgv.CurrentRow.Index).Cells(6).Value = ac.assetAcc
            End If
            dgv.Rows(dgv.CurrentRow.Index).Cells(5).Value = Format(CDbl(dgv.CurrentRow.Cells(3).Value) * CDbl(dgv.CurrentRow.Cells(4).Value), "N")
            sumofAmount()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            dgv.Rows.Clear()
            lblTotal.Text = totAmount
        End If

    End Sub

    Private Sub BTNSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSAVE.Click
        If txtName.Text <> "" Or invoiceNo <> "" Then
            If MsgBox("Are you sure ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If MsgBox("Did you received all your ordered items ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    allitemsreceived = 1
                Else
                    allitemsreceived = 0
                End If
                RECEIVEDITEMS()
                addVoucher()
            End If
        ElseIf dgvAccEntry.Rows.Count <> 0 Then
            MsgBox("Please Add Credit Accounts ", MsgBoxStyle.Critical, "Error")
        Else
            MsgBox("Please fillup all information ", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmGetRequisitionItemList
        frm.get_pending_po()
        frm.ShowDialog()
        If frmGetRequisitionItemList.mouseclicked = True Then
            txtRefNo.Text = frmGetRequisitionItemList.LV.SelectedItems(0).SubItems(2).Text
            frmGetRequisitionItemList.mouseclicked = False
            get_purchased_items()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        list_for_selected_accounts.get_clearing_accounts()
        list_for_selected_accounts.ShowDialog()
    End Sub

    Private Sub dgvAccEntry_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAccEntry.CellValueChanged
        Try
            Dim ac As New Account_Class
            For Each row As DataGridViewRow In dgvAccEntry.Rows
                ac.searchValue = row.Cells(0).Value
                ac.getaccountName()
                row.Cells(1).Value = ac.AccName
            Next
            Dim totalcrd As Double = 0
            For Each row As DataGridViewRow In dgvAccEntry.Rows
                totalcrd = totalcrd + CDbl(row.Cells(2).Value)
            Next
            lblTotCrd.Text = Format(totalcrd, "N")
        Catch ex As Exception

        End Try
    End Sub
    Public Sub colx(ByVal data As AutoCompleteStringCollection, ByVal c As String)
        Try
            checkConn()
            Dim cmd As New SqlCommand("select distinct itemno from tblInvtry ", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                data.Add(dr.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Private Sub dgv_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgv.EditingControlShowing
        Dim autocomplete As New autocomplete_class
        autocomplete.get_itemCode()
        If dgv.CurrentCell.ColumnIndex = 0 Then
            Dim text As TextBox = TryCast(e.Control, TextBox)
            If text IsNot Nothing Then
                text.AutoCompleteMode = AutoCompleteMode.Append
                text.AutoCompleteSource = AutoCompleteSource.CustomSource
                Dim data As AutoCompleteStringCollection = New AutoCompleteStringCollection()
                colx(data, dgv.CurrentCellAddress.ToString)
                text.AutoCompleteCustomSource = data
            End If
        ElseIf TypeOf e.Control Is TextBox Then
            Dim text As TextBox = TryCast(e.Control, TextBox)
            text.AutoCompleteCustomSource = Nothing
            text.AutoCompleteSource = AutoCompleteSource.None
            text.AutoCompleteMode = AutoCompleteMode.None
        End If
    End Sub

    Public Sub get_exist_cvinfo()
        Try
            Dim cmd As New SqlCommand("get_exist_cvinfo", conn)
            checkConn()
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@searchValue", SqlDbType.Int).Value = txtRefNo.Text
            End With
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            da.SelectCommand = cmd
            da.Fill(dt)
            dgvAccEntry.Rows.Clear()
            If dt.Rows.Count > 0 Then
                MsgBox("You already paid this order. automatically we will add credit account", MsgBoxStyle.OkOnly, "Information")
            End If
            For Each row As DataRow In dt.Rows
                dgvAccEntry.Rows.Add()
                dgvAccEntry.Item(0, dgv.Rows.Count).Value = row(1)
                dgvAccEntry.Item(2, dgv.Rows.Count).Value = row(2)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvAccEntry_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvAccEntry.MouseDoubleClick
        Try
            Dim amount As Double = InputBox("Enter Amount")
            dgvAccEntry.CurrentRow.Cells(2).Value = Format(amount, "N")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtQty.Text = "" Then
            txtQty.Text = "1"
        End If
        InventoryList.mode = "Receiving"
        InventoryList.ShowDialog()
        If InventoryList.clickedItem = True Then
            Dim r As Integer = dgv.Rows.Count
            dgv.Rows.Add()
            dgv.Item(0, r).Value = InventoryList.dgv.CurrentRow.Cells(0).Value
            dgv.Item(1, r).Value = InventoryList.dgv.CurrentRow.Cells(1).Value
            dgv.Item(2, r).Value = InventoryList.dgv.CurrentRow.Cells(2).Value
            dgv.Item(3, r).Value = InventoryList.dgv.CurrentRow.Cells(3).Value
            dgv.Item(4, r).Value = txtQty.Text
            dgv.Item(5, r).Value = CDbl(InventoryList.dgv.CurrentRow.Cells(3).Value) * CDbl(txtQty.Text)
            lblTotal.Text = "Php " & Format(totAmount, "N")
            InventoryList.clickedItem = False
        End If
    End Sub

    Private Sub dgvAccEntry_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAccEntry.CellContentClick

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmAccountList.ShowDialog()
        If frmAccountList.successClick Then
            Dim r As Integer = dgvAccEntry.Rows.Count
            dgvAccEntry.Rows.Add()
            dgvAccEntry.Item(0, r).Value = frmAccountList.dgv.CurrentRow.Cells(0).Value
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        For Each row As DataGridViewRow In dgvAccEntry.SelectedRows
            dgvAccEntry.Rows.Remove(row)
        Next
    End Sub

    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        frmCardListForSelection.formMode = "PURCHASE_RECEIVED"
        frmCardListForSelection.ShowDialog()
        Try
            If frmCardListForSelection.itemClick = True Then
                cardID = frmCardListForSelection.LV.SelectedItems(0).SubItems(0).Text
                txtName.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(1).Text
                frmCardListForSelection.itemClick = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtRefNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRefNo.TextChanged

    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class