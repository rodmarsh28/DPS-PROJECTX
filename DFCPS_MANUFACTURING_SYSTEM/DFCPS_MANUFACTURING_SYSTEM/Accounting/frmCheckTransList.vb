Public Class frmCheckTransList

    Private Sub frmCheckTransList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_checkIssued_List()
    End Sub
    Sub get_checkIssued_List()
        Dim ac As New Accounting_class
        ac.searchValue = txtSearch.Text
        ac.get_checkIssued_list()
        dgv.Rows.Clear()
        For Each row As DataRow In ac.dtable.Rows
            dgv.Rows.Add(row(0), row(1), row(2), row(3), row(4), CDec(row(5)).ToString("N"), row(6))
        Next
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        get_checkIssued_List()
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

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgv.ContextMenuStrip = Nothing
    End Sub

    Private Sub ClearedCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearedCheckToolStripMenuItem.Click
        Try
            Dim ac As New Accounting_class
            ac.status = "Cleared"
            ac.checkNo = dgv.CurrentRow.Cells(3).Value
            ac.update_checkTrans_status()
            MsgBox("This Check is cleared !", MsgBoxStyle.Information, "System Information")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CancelCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelCheckToolStripMenuItem.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
            Dim ac As New Accounting_class
            ac.checkNo = dgv.CurrentRow.Cells(3).Value
            ac.status = "Cancelled"
            ac.update_checkTrans_status()
            ac.command = 2
            ac.searchValue = dgv.CurrentRow.Cells(3).Value
            ac.GET_CV_DATA()
            ac.transNo = ac.dtable.Rows(0).Item(0)
            ac.status = "Waiting for check issuance"
            ac.update_checkvoucher_status()
            MsgBox("Success", MsgBoxStyle.Information, "System Information")
            get_checkIssued_List()
        End If
    End Sub
End Class