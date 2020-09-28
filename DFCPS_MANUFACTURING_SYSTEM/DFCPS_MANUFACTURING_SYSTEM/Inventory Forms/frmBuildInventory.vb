Public Class frmBuildInventory
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            For Each row As DataGridViewRow In dgv.Rows
                Dim dbcontext As New accountingDataContext
                Dim bi As New tblBuildInventory
                bi.buildInvNo = txtNo.Text
                bi.dateBuild = Now.Date.ToString("MM/dd/yyyy")
                bi.itemcode = row.Cells(0).Value
                bi.qty = CInt(row.Cells(3).Value)
                bi.remarks = txtRemarks.Text
                dbcontext.tblBuildInventories.InsertOnSubmit(bi)
                dbcontext.SubmitChanges()
            Next
            MsgBox("Build Successfully")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub generateNo()
        Try
            Dim SC As New systemSettings_class
            Dim NO As String
            Dim StrID As String
            SC.tableName = "tblBuildInventory"
            SC.columnName = "buildInvNo"
            SC.series = ""
            SC.generateNo()
            StrID = Mid(SC.result, Len(SC.series) + 1, Len(SC.result))
            NO = SC.series & Format(Val(StrID) + 1, "00000")
            txtNo.Text = NO
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtQty.Text = "" Then
            txtQty.Text = "1"
        End If
        InventoryList.mode = "Build"
        InventoryList.ShowDialog()
        If InventoryList.clickedItem = True Then
            Dim r As Integer = dgv.Rows.Count
            dgv.Rows.Add()
            dgv.Item(0, r).Value = InventoryList.dgv.CurrentRow.Cells(0).Value
            dgv.Item(1, r).Value = InventoryList.dgv.CurrentRow.Cells(1).Value
            dgv.Item(2, r).Value = InventoryList.dgv.CurrentRow.Cells(2).Value
            dgv.Item(3, r).Value = txtQty.Text
        End If
        lblCount.Text = dgv.Rows.Count
        dgv.ClearSelection()
        InventoryList.clickedItem = False
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub dgv_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgv.CurrentCell = dgv(e.ColumnIndex, e.RowIndex)
                dgv.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        For Each row As DataGridViewRow In dgv.SelectedRows
            dgv.Rows.Remove(row)
            lblCount.Text = dgv.Rows.Count
        Next
    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgv.ContextMenuStrip = Nothing
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub frmBuildInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateNo()
    End Sub
End Class