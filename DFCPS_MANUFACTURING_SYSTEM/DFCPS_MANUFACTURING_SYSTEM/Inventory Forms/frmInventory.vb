Imports System.Data.SqlClient

Public Class frmInventory
    Dim command As Integer = 0
    Dim rowIndex As Integer
    Dim dt As New DataTable
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmAddItemsInventory.btnAdd.Text = "Add Item"
        frmAddItemsInventory.ShowDialog()
    End Sub

    Sub GetItemsinInventoryAll()
        Try
            checkConn()
            If ComboBox1.Text = "All" Then
                command = 0
                LV.Columns(5).Text = "Onhand"
            ElseIf ComboBox1.Text = "Sold" Then
                command = 1
                LV.Columns(5).Text = "Qty"
            ElseIf ComboBox1.Text = "Inventoried" Then
                command = 2
                LV.Columns(5).Text = "Qty"
            End If
            Dim cmd As New SqlCommand("get_InventoryList", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = txtSearchAll.Text
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
                LV.Items.Clear()
                For Each row As DataRow In dt.Rows
                    Dim lst As ListViewItem
                    lst = LV.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
                For i As Integer = 1 To dt.Columns.Count - 1
                    lst.SubItems.Add(If(row(i) IsNot Nothing, row(i).ToString, ""))
                Next
                Next
                If rowIndex < LV.Items.Count Then
                    LV.Items(rowIndex).Selected = True
                End If
            lblNoCountAll.Text = Format(LV.Items.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub frmInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetItemsinInventoryAll()
    End Sub

    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If GetActiveWindow = Me.Handle Then
        '    GetItemsinInventoryAll()
        'End If
    End Sub


    Private Sub LV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV.SelectedIndexChanged
        Try
            rowIndex = LV.FocusedItem.Index
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtSearchAll_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchAll.TextChanged
        rowIndex = 0
        GetItemsinInventoryAll()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmAddItemsInventory.btnAdd.Text = "Save Item"
        frmAddItemsInventory.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        GetItemsinInventoryAll()
    End Sub
End Class