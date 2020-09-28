Public Class frmManageInfractions
    Public infractionID As Integer
    Public specOffID As Integer
    Public dgvSel As Integer

    Sub getIDNo()
        Dim no As Integer = 0
        For Each row As DataGridViewRow In dgvInfraction.Rows
                no = CInt(row.Cells(0).Value)
        Next
        infractionID = no + 1
        no = 0
        For Each row As DataGridViewRow In dgvSpecOff.Rows
                no = CInt(row.Cells(0).Value)
        Next
        specOffID = no + 1
    End Sub
    Sub get_infraction_List()
        Dim mc As New master_class
        mc.get_infraction_List()
        dgvInfraction.Rows.Clear()
        For Each row As DataRow In mc.dtable.Rows
            dgvInfraction.Rows.Add(row(0), row(1))
        Next
        getIDNo()
    End Sub
    Sub get_specOffense_List()
        Dim mc As New master_class
        mc.infractionID = dgvInfraction.CurrentRow.Cells(0).Value
        mc.get_SpecOff_List()
        dgvSpecOff.Rows.Clear()
        For Each row As DataRow In mc.dtable.Rows
            dgvSpecOff.Rows.Add(row(0), row(1), row(2), row(3))
        Next
        dgvSpecOff.ClearSelection()
        getIDNo()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtInfraction.Text = "" Then
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            Dim mc As New master_class
            mc.infractionID = infractionID
            mc.infractionDesc = txtInfraction.Text
            mc.insert_infraction()
            get_infraction_List()
            txtInfraction.Text = ""
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSpecOff.CellContentClick
        If dgvSpecOff.CurrentCell.ColumnIndex = 3 Then

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If dgvInfraction.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            Dim mc As New master_class
            For Each row As DataGridViewRow In dgvInfraction.SelectedRows
                mc.infractionID = row.Cells(0).Value
                mc.delete_infraction()
                get_infraction_List()
            Next
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If dgvInfraction.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        Dim frm As New diagSpecOffensesx
        frm.ShowDialog()
        If frm.add = True Then
            Dim mc As New master_class
            mc.specOffID = specOffID
            mc.specoffDesc = frm.txtSpecific.Text
            mc.offenseID = frm.dgvOff.CurrentRow.Cells(0).Value
            mc.infractionID = dgvInfraction.CurrentRow.Cells(0).Value
            mc.insert_specOffense()
            get_specOffense_List()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dgvSpecOff.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            Dim mc As New master_class
            For Each row As DataGridViewRow In dgvSpecOff.SelectedRows
                mc.infractionID = dgvInfraction.CurrentRow.Cells(0).Value
                mc.specOffID = row.Cells(0).Value
                mc.offenseID = row.Cells(2).Value
                mc.delete_specOffense()
                get_specOffense_List()
            Next
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvSel = 1 Then
            Dim mc As New master_class
            mc.infractionID = dgvInfraction.CurrentRow.Cells(0).Value
            mc.delete_infraction()
        ElseIf dgvSel = 2 Then
            Dim mc As New master_class
            mc.infractionID = dgvInfraction.CurrentRow.Cells(0).Value
            mc.specOffID = dgvSpecOff.CurrentRow.Cells(0).Value
            mc.delete_specOffense()
        End If
    End Sub


    Private Sub dgvInfraction_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInfraction.CellMouseClick
        get_specOffense_List()
    End Sub



    Private Sub dgvInfraction_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInfraction.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgvInfraction.CurrentCell = dgvInfraction(e.ColumnIndex, e.RowIndex)
                dgvInfraction.ContextMenuStrip = ContextMenuStrip1
                dgvSel = 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        dgvInfraction.ContextMenuStrip = Nothing
        dgvSpecOff.ContextMenuStrip = Nothing
    End Sub

    Private Sub dgvSpecOff_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSpecOff.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgvSpecOff.CurrentCell = dgvSpecOff(e.ColumnIndex, e.RowIndex)
                dgvSpecOff.ContextMenuStrip = ContextMenuStrip1
                dgvSel = 2
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmManageInfractions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_infraction_List()
        dgvSpecOff.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
End Class