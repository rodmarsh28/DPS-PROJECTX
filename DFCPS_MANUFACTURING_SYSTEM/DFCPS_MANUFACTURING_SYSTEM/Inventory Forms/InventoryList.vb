Imports System.Data.SqlClient

Public Class InventoryList
    Dim buyable As String
    Dim sellable As String
    Dim inventorable As String
    Dim costacc As String
    Dim incomeacc As String
    Dim assetacc As String
    Public mode As String
    Public clickedItem As Boolean
    Public command As Integer
    Dim dt As New DataTable
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewItem.Click
        If mode = "Item Requisition" Then
            AddNewItem.ShowDialog()
        ElseIf mode = "Sales" Or mode = "Issuance" Or mode = "Purchases" Or mode = "Order" Then
            frmAddItemsInventory.cmbItemType.SelectedIndex = 1
            frmAddItemsInventory.btnAdd.Text = "Add Item"
            frmAddItemsInventory.ShowDialog()
        Else
            frmAddItemsInventory.cmbItemType.SelectedIndex = 1
            frmAddItemsInventory.btnAdd.Text = "Add Item"
            frmAddItemsInventory.ShowDialog()
        End If
        getItemlist()
    End Sub
    Sub getItemlist()
        Dim cmd
        If mode = "Sales" Then
            dgv.Columns(4).Visible = False
            dgv.Columns(9).Visible = True
            dgv.Columns(9).HeaderText = "Onhand"
            cmd = New SqlCommand("get_item_sellable", conn)
            dgv.Columns(3).HeaderText = "Sell Price"
        ElseIf mode = "Purchases" Then
            dgv.Columns(4).Visible = True
            dgv.Columns(9).Visible = False
            dgv.Columns(9).HeaderText = "Onhand"
            cmd = New SqlCommand("get_item_buyable", conn)
            dgv.Columns(3).HeaderText = "Sell Price"
        ElseIf mode = "Issuance" Or mode = "Item Requisition" Or mode = "Receiving" Then
            dgv.Columns(4).Visible = True
            dgv.Columns(9).Visible = False
            dgv.Columns(9).HeaderText = "Onhand"
            cmd = New SqlCommand("get_item_inventoriable", conn)
            dgv.Columns(3).HeaderText = "Cost"
        ElseIf mode = "Rawmats" Then
            dgv.Columns(4).Visible = True
            dgv.Columns(9).Visible = True
            dgv.Columns(9).HeaderText = "PC_QTY"
            cmd = New SqlCommand("get_item_rawmats", conn)
            dgv.Columns(3).HeaderText = "Cost"
        Else
            dgv.Columns(4).Visible = True
            dgv.Columns(9).Visible = False
            dgv.Columns(9).HeaderText = "Onhand"
            cmd = New SqlCommand("get_item_inventoriable", conn)
            dgv.Columns(3).HeaderText = "Cost"
        End If
        conn.Close()
        ConnectDatabase()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@SEARCH_VALUE", SqlDbType.VarChar).Value = txtSearch.Text
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        dt.Rows.Clear()
        da.Fill(dt)
        dgv.Rows.Clear()
        For Each row As DataRow In dt.Rows
            dgv.Rows.Add(row(0), row(1), row(2), CDec(row(3)).ToString("N"), CDec(row(4)).ToString("N0"), row(5), row(6), row(7), CDec(row(8)).ToString("N"), CDec(row(9)).ToString("N0"))
        Next
        dgv.ClearSelection()
        lblItemsCount.Text = Format(dgv.Rows.Count, "N0")
    End Sub
    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If GetActiveWindow = Me.Handle Then
            getItemlist()
        End If
    End Sub

    Private Sub InventoryList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getItemlist()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        getItemlist()
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        clickedItem = True
        If mode = "Sales" Then
            Me.Close()
        ElseIf mode = "Purchases" Then
            Me.Close()
        ElseIf mode = "Item Requisition" Then
            Dim r As Integer = frmItemRequisition.dgv.Rows.Count
            frmItemRequisition.dgv.Rows.Add()
            frmItemRequisition.dgv.Item(0, r).Value = dgv.CurrentRow.Cells(0).Value
            frmItemRequisition.dgv.Item(1, r).Value = dgv.CurrentRow.Cells(1).Value
            frmItemRequisition.dgv.Item(2, r).Value = dgv.CurrentRow.Cells(2).Value
            frmItemRequisition.dgv.Item(3, r).Value = dgv.CurrentRow.Cells(4).Value
            frmItemRequisition.dgv.Item(4, r).Value = frmItemRequisition.txtQty.Text
            Me.Close()
        ElseIf mode = "Issuance" Then
            Dim r As Integer = frmItemsIssuance.dgv.Rows.Count
            frmItemsIssuance.dgv.Rows.Add()
            frmItemsIssuance.dgv.Item(0, r).Value = dgv.CurrentRow.Cells(0).Value
            frmItemsIssuance.dgv.Item(1, r).Value = dgv.CurrentRow.Cells(1).Value
            frmItemsIssuance.dgv.Item(2, r).Value = dgv.CurrentRow.Cells(2).Value
            frmItemsIssuance.dgv.Item(3, r).Value = dgv.CurrentRow.Cells(4).Value
            frmItemsIssuance.dgv.Item(4, r).Value = frmItemsIssuance.txtQty.Text
            frmItemsIssuance.dgv.Item(5, r).Value = CDbl(dgv.CurrentRow.Cells(3).Value) * CDbl(frmItemsIssuance.txtQty.Text)
            frmItemsIssuance.dgv.Item(6, r).Value = dgv.CurrentRow.Cells(7).Value
            Me.Close()
        ElseIf mode = "Order" Then
            Me.Close()
        ElseIf mode = "Receiving" Then
            Me.Close()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                clickedItem = True
                If mode = "Sales" Then
                    Me.Close()
                ElseIf mode = "Purchases" Then
                    Me.Close()
                ElseIf mode = "Item Requisition" Then
                    Dim r As Integer = frmItemRequisition.dgv.Rows.Count
                    frmItemRequisition.dgv.Rows.Add()
                    frmItemRequisition.dgv.Item(0, r).Value = dgv.CurrentRow.Cells(0).Value
                    frmItemRequisition.dgv.Item(1, r).Value = dgv.CurrentRow.Cells(1).Value
                    frmItemRequisition.dgv.Item(2, r).Value = dgv.CurrentRow.Cells(2).Value
                    frmItemRequisition.dgv.Item(3, r).Value = dgv.CurrentRow.Cells(4).Value
                    frmItemRequisition.dgv.Item(4, r).Value = frmItemRequisition.txtQty.Text
                    Me.Close()
                ElseIf mode = "Issuance" Then
                    Dim r As Integer = frmItemsIssuance.dgv.Rows.Count
                    frmItemsIssuance.dgv.Rows.Add()
                    frmItemsIssuance.dgv.Item(0, r).Value = dgv.CurrentRow.Cells(0).Value
                    frmItemsIssuance.dgv.Item(1, r).Value = dgv.CurrentRow.Cells(1).Value
                    frmItemsIssuance.dgv.Item(2, r).Value = dgv.CurrentRow.Cells(2).Value
                    frmItemsIssuance.dgv.Item(3, r).Value = dgv.CurrentRow.Cells(4).Value
                    frmItemsIssuance.dgv.Item(4, r).Value = frmItemsIssuance.txtQty.Text
                    frmItemsIssuance.dgv.Item(5, r).Value = CDbl(dgv.CurrentRow.Cells(3).Value) * CDbl(frmItemsIssuance.txtQty.Text)
                    frmItemsIssuance.dgv.Item(6, r).Value = dgv.CurrentRow.Cells(7).Value
                    Me.Close()
                ElseIf mode = "Order" Then
                    Me.Close()
                ElseIf mode = "Receiving" Then
                    Me.Close()
                Else
                    Me.Close()
                End If
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Escape Then
                clickedItem = False
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class