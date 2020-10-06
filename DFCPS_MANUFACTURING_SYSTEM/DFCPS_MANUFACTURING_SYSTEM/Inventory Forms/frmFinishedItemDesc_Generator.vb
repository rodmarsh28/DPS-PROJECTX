Public Class frmFinishedItemDesc_Generator
    Dim dgw As DataGridView
    Dim cms1 As String
    Private Sub dgvSpecs_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSpecs.CellContentClick

    End Sub
    Sub popup_cms(ByVal cms As String, ByVal dgv As DataGridView)
        dgv.ContextMenuStrip = ContextMenuStrip1
        dgw = dgv
        cms1 = cms
       
    End Sub
    Private Sub dgvSpecs_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSpecs.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvSpecs", dgvSpecs)
        ElseIf e.Button = MouseButtons.Left Then
            dgvSpecs2.ClearSelection()
        End If
    End Sub

    Private Sub dgvSpecs2_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSpecs2.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvSpecs2", dgvSpecs2)
        ElseIf e.Button = MouseButtons.Left Then
            dgvSpecs.ClearSelection()
        End If
    End Sub

    Private Sub dgvDenier_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDenier.CellContentClick

    End Sub

    Private Sub dgvDenier_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDenier.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvDenier", dgvDenier)
        End If
    End Sub



    Private Sub dgvColor_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvColor.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvColor", dgvColor)
        End If
    End Sub


    Private Sub dgvColor2_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvColor2.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvColor2", dgvColor2)
        End If
    End Sub

    Private Sub dgvTH_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTH.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvTH", dgvTH)
        End If
    End Sub
    Private Sub dgvPrinted_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPrinted.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvPrinted", dgvPrinted)
        End If
    End Sub

    
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Try
            If cms1 = "dgvSpecs" Or cms1 = "dgvSpecs2" Then
                Dim size = InputBox("Size", "Please input")
                Dim app = InputBox("Application", "Please input")
                Dim code = InputBox("Code", "Please input")
                dgw.Rows.Add(size, app, code)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            For Each row As DataGridViewRow In dgw.Rows
                dgw.Rows.Remove(row)
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class