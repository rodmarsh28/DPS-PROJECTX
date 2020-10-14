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
                dgv.Columns(5).HeaderText = "Onhand"
            ElseIf ComboBox1.Text = "Sold" Then
                command = 1
                dgv.Columns(5).HeaderText = "Qty"
            ElseIf ComboBox1.Text = "Inventoried" Then
                command = 2
                dgv.Columns(5).HeaderText = "Qty"
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
            dgv.Rows.Clear()
            For Each r As DataRow In dt.Rows
                dgv.Rows.Add(r(0), r(1), r(2), r(3), r(4), r(5), r("PC_QTY"))
            Next
            lblNoCountAll.Text = Format(dgv.Rows.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub frmInventory_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        GetItemsinInventoryAll()
    End Sub




    Private Sub frmInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'GetItemsinInventoryAll()
    End Sub

    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If GetActiveWindow = Me.Handle Then
        '    GetItemsinInventoryAll()
        'End If
    End Sub


    

    Private Sub txtSearchAll_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchAll.TextChanged
        rowIndex = 0
        GetItemsinInventoryAll()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmAddItemsInventory
        frm.btnAdd.Text = "Save Item"
        frm.MdiParent = frmInventorySystemMain
        frm.StartPosition = FormStartPosition.CenterParent
        frm.txtItemno.Text = dgv.CurrentRow.Cells(0).Value
        frm.update_load(dgv.CurrentRow.Cells(0).Value)
        frm.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        GetItemsinInventoryAll()
    End Sub



    Private Sub frmInventory_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            dgv.Columns(6).Visible = True
        Else
            dgv.Columns(6).Visible = False
        End If
    End Sub
End Class