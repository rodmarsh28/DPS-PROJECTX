Public Class AddNewItem

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub
    Sub clear()
        txtDescription.Text = ""
        txtUnit.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If InventoryList.mode = "Item Requisition" Then
            Dim r As Integer = frmItemRequisition.dgv.Rows.Count
            frmItemRequisition.dgv.Rows.Add()
            frmItemRequisition.dgv.Item(0, r).Value = ""
            frmItemRequisition.dgv.Item(1, r).Value = txtDescription.Text
            frmItemRequisition.dgv.Item(2, r).Value = txtUnit.Text
            frmItemRequisition.dgv.Item(3, r).Value = 0
            frmItemRequisition.dgv.Item(4, r).Value = frmItemRequisition.txtQty.Text
            Me.Close()
            InventoryList.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub AddNewItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub AddNewItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class