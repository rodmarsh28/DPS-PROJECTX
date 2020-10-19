Imports System.Data.SqlClient

Public Class frmDesciplinaryActionViewer
    Public empid As String
    Private Sub frmDesciplinaryActionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_disciplinaryaction_list()
    End Sub
    Sub get_disciplinaryaction_list()
        Dim mc As New master_class
        mc.command = ""
        mc.searchValue = empid
        mc.get_disciplinaryaction_list()
        For Each row As DataRow In mc.dtable.Rows
            dgv.Rows.Add(row(0), row(1), row(2), row(3), row(4))
        Next
        dgv.ClearSelection()
        dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            Try
                Dim cmd As New SqlCommand("delete tblDesciplinaryAction where descActionNo = '" & dgv.CurrentRow.Cells(0).Value & "'", conn)
                checkConn()
                cmd.ExecuteNonQuery()
                MsgBox("Delete Successfully", MsgBoxStyle.Information, "System Information")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            get_disciplinaryaction_list()
        End If
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

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgv.ContextMenuStrip = Nothing
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
End Class