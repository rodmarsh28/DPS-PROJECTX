Public Class frmManageOffenses
    Dim offenseID As Integer
    Dim occurenceTime As Integer
    Dim dgvSel As Integer
    Sub get_offenses_List()
        Dim mc As New master_class
        mc.get_offenses_List()
        dgvOff.Rows.Clear()
        For Each row As DataRow In mc.dtable.Rows
            dgvOff.Rows.Add(row(0), row(1))
        Next
        getIDNo()
    End Sub

    Sub get_occurrence_List()
        Dim mc As New master_class
        mc.offenseID = dgvOff.CurrentRow.Cells(0).Value
        mc.get_occurrence_List()
        dgvOcc.Rows.Clear()
        For Each row As DataRow In mc.dtable.Rows
            dgvOcc.Rows.Add(row(0), row(1))
        Next
        dgvOcc.ClearSelection()
        getIDNo()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtTypeOff.Text = "" Then
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            Dim mc As New master_class
            mc.offenseID = offenseID
            mc.offenseDesc = txtTypeOff.Text
            mc.insert_offenses()
            get_offenses_List()
            txtTypeOff.Text = ""
        End If
    End Sub
    Sub getIDNo()
        Dim no As Integer = 0
        For Each row As DataGridViewRow In dgvOff.Rows
                no = CInt(row.Cells(0).Value)
        Next
        offenseID = no + 1
        no = 0
        For Each row As DataGridViewRow In dgvOcc.Rows
            no = CInt(row.Cells(0).Value)
        Next
        occurenceTime = no + 1
        txtOccTimes.Text = occurenceTime
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If dgvOff.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            For Each row As DataGridViewRow In dgvOff.SelectedRows
                Dim mc As New master_class
                mc.offenseID = row.Cells(0).Value
                mc.delete_offenses()
                get_offenses_List()
            Next
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If dgvOff.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If txtOccTimes.Text = "" And IsNumeric(txtTypeOff) = False Then
            Exit Sub
        End If
        If txtCorrectiveActions.Text = "" Then
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            Dim mc As New master_class
            mc.occurrenceTimes = txtOccTimes.Text
            mc.correctiveActions = txtCorrectiveActions.Text
            mc.offenseID = dgvOff.CurrentRow.Cells(0).Value
            mc.insert_occurrence()
            get_occurrence_List()
            txtCorrectiveActions.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dgvOcc.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            For Each row As DataGridViewRow In dgvOff.SelectedRows
                Dim mc As New master_class
                mc.occurrenceTimes = dgvOcc.CurrentRow.Cells(0).Value
                mc.offenseID = dgvOff.CurrentRow.Cells(0).Value
                mc.delete_occurrence()
                get_occurrence_List()
            Next
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        'If dgvSel = 1 Then
        '    Dim mc As New master_class
        '    mc.offenseID = dgvOff.CurrentRow.Cells(0).Value
        '    mc.delete_offenses()
        'ElseIf dgvSel = 2 Then
        '    Dim mc As New master_class
        '    mc.offenseID = dgvOff.CurrentRow.Cells(0).Value
        '    mc.occurrenceTimes = dgvOcc.CurrentRow.Cells(0).Value
        '    mc.delete_occurrence()
        '    get_occurrence_List()
        'End If
    End Sub

    Private Sub dgvOff_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOff.CellMouseClick
        get_occurrence_List()
    End Sub

    Private Sub dgvOff_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOff.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgvOff.CurrentCell = dgvOff(e.ColumnIndex, e.RowIndex)
                dgvOff.ContextMenuStrip = ContextMenuStrip1
                dgvSel = 1
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgvOcc_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOcc.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgvOcc.CurrentCell = dgvOcc(e.ColumnIndex, e.RowIndex)
                dgvOcc.ContextMenuStrip = ContextMenuStrip1
                dgvSel = 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        dgvOff.ContextMenuStrip = Nothing
        dgvOcc.ContextMenuStrip = Nothing
    End Sub

    Private Sub dgvOff_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOff.CellContentClick

    End Sub

    Private Sub frmManageOffenses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_offenses_List()
    End Sub
End Class