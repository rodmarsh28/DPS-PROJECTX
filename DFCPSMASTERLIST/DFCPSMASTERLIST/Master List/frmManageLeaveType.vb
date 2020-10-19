Public Class frmManageLeaveType
    Dim ltID As Integer
    Sub get_lt_list()
        Dim mc As New master_class
        mc.get_lt_list()
        dgv.Rows.Clear()
        For Each row As DataRow In mc.dtable.Rows
            dgv.Rows.Add(row(0), row(1), row(2))
        Next
        getIDNo()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtLT.Text = "" Then
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            Dim mc As New master_class
            mc.ltID = ltID
            mc.leaveType = txtLT.Text
            mc.days = txtDays.Text
            txtLT.Text = ""
            txtDays.Text = ""
            mc.insert_lt()

        End If
        get_lt_list()
    End Sub
    Sub getIDNo()
        Dim no As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            no = CInt(row.Cells(0).Value)
        Next
        ltID = no + 1
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If dgv.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            For Each row As DataGridViewRow In dgv.SelectedRows
                Dim mc As New master_class
                mc.ltID = row.Cells(0).Value
                mc.delete_lt()
                get_lt_list()
            Next
        End If
    End Sub










    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        dgv.ContextMenuStrip = Nothing
    End Sub

    Private Sub dgvOff_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub frmManageOffenses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_lt_list()
    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        getIDNo()
    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        getIDNo()
    End Sub
End Class