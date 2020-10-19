Imports System.Data.SqlClient

Public Class frmEmpLeaveViewer
    Public empid As String
    Private Sub frmEmpLeaveViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_employees_leave_list()
    End Sub
    Sub get_employees_leave_list()
        Dim mc As New master_class
        mc.command = ""
        mc.searchValue = empid
        mc.get_employees_leave_list()
        For Each row As DataRow In mc.dtable.Rows
            dgv.Rows.Add(row(0), row(1), row(3), row(7), row(5), row(6), row(8), row(4))
        Next
        dgv.ClearSelection()
        dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
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
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            Try
                Dim cmd As New SqlCommand("delete tblLeave where LeaveNo = '" & dgv.CurrentRow.Cells(0).Value & "'", conn)
                checkConn()
                cmd.ExecuteNonQuery()
                MsgBox("Delete Successfully", MsgBoxStyle.Information, "System Information")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        get_employees_leave_list()
    End Sub
End Class