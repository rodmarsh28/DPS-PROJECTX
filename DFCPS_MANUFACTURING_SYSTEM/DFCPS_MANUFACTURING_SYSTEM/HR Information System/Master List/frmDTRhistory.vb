Public Class frmDTRhistory
    Public command As String
    Public searchValue As String
    Public type As String
    Public isOK As Boolean
    Public empid As String
    Public dates As DateTime

    Sub get_dtr_history()
        Dim mc As New master_class
        mc.command = "DTR_RECORD"
        mc.searchValue = txtSearch.Text
        mc.datetrans = Now
        mc.get_dtr_history()
        dgv.DataSource = mc.dtable
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv.AutoResizeColumns()
    End Sub



    Private Sub frmInfraction_offense_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_dtr_history()
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        isOK = True
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        get_dtr_history()
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

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            Try
                Dim mc As New master_class
                mc.transNo = dgv.CurrentRow.Cells(0).Value
                mc.dtrDate = dgv.CurrentRow.Cells(1).Value
                mc.delete_dtr_record()
                MsgBox("Record successfully deleted !", MsgBoxStyle.Information, "System Information")
                get_dtr_history()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        Dim frm As New frmDailyTimeRecording
        frm.mode = "Update"
        frm.dtpDate.Value = dgv.CurrentRow.Cells(1).Value
        frm.ShowDialog()
        get_dtr_history()
    End Sub
End Class