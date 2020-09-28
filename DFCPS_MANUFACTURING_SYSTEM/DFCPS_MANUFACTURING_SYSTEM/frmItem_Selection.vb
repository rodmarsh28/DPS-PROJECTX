Public Class frmItem_Selection
    Public successClicked As Boolean
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmAddItemsInventory
        frm.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Sub get_item_masterlist()
        Dim ic As New inventory_class
        ic.SearchValue = txtSearch.Text
        ic.get_item_masterlist()
        dgv.Rows.Clear()
        For Each row As DataRow In ic.dtable.Rows
            dgv.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6))
        Next
    End Sub

    Private Sub frmItem_Selection_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            successClicked = True
            Me.Close()
        End If
    End Sub
    Private Sub frmItem_masterlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_item_masterlist()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        get_item_masterlist()
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        successClicked = True
        Me.Close()
    End Sub
End Class