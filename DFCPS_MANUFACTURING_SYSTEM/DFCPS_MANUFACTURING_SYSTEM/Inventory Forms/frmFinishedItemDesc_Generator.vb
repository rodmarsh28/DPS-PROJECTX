Public Class frmFinishedItemDesc_Generator
    Dim dgw As DataGridView
    Dim cms1 As String
    Public generate_clicked As Boolean
    
    Sub command_Data(ByVal Size As String, ByVal app As String, ByVal code As String, ByVal type As String, ByVal command As String, ByVal name As String)
        Dim spec1_ds As New invtry_dsTableAdapters.specs1TableAdapter
        spec1_ds.Connection.ConnectionString = My.Settings.connStringValue
        Dim spec2_ds As New invtry_dsTableAdapters.specs2TableAdapter
        spec2_ds.Connection.ConnectionString = My.Settings.connStringValue
        Dim color1_ds As New invtry_dsTableAdapters.color1TableAdapter
        color1_ds.Connection.ConnectionString = My.Settings.connStringValue
        Dim color2_ds As New invtry_dsTableAdapters.color2TableAdapter
        color2_ds.Connection.ConnectionString = My.Settings.connStringValue
        Dim denier_ds As New invtry_dsTableAdapters.denierTableAdapter
        denier_ds.Connection.ConnectionString = My.Settings.connStringValue
        Dim th_ds As New invtry_dsTableAdapters.tophemmedTableAdapter
        th_ds.Connection.ConnectionString = My.Settings.connStringValue
        Dim printed_ds As New invtry_dsTableAdapters.printedTableAdapter
        printed_ds.Connection.ConnectionString = My.Settings.connStringValue
        Dim ds
        If command = "select" Then
            dgvSpecs.DataSource = spec1_ds.GetData()
            dgvSpecs2.DataSource = spec2_ds.GetData()
            dgvColor.DataSource = color1_ds.GetData()
            dgvColor2.DataSource = color2_ds.GetData()
            dgvDenier.DataSource = denier_ds.GetData()
            dgvTH.DataSource = th_ds.GetData()
            dgvPrinted.DataSource = printed_ds.GetData()
            dgvSpecs.ClearSelection()
            dgvSpecs2.ClearSelection()
            dgvColor.ClearSelection()
            dgvColor2.ClearSelection()
            dgvDenier.ClearSelection()
            dgvTH.ClearSelection()
            dgvPrinted.ClearSelection()
        ElseIf command = "insert" Then
            If name = "dgvSpecs" Then
                spec1_ds.Insert(Size, app, code)
            ElseIf name = "dgvSpecs2" Then
                spec2_ds.Insert(Size, app, code)
            ElseIf name = "dgvColor" Then
                color1_ds.Insert(type, code)
            ElseIf name = "dgvColor2" Then
                color2_ds.Insert(type, code)
            ElseIf name = "dgvDenier" Then
                denier_ds.Insert(type, code)
            ElseIf name = "dgvTH" Then
                th_ds.Insert(type, code)
            ElseIf name = "dgvPrinted" Then
                printed_ds.Insert(type, code)
            End If
        ElseIf command = "delete" Then
            If name = "dgvSpecs" Then
                spec1_ds.Delete(code)
            ElseIf name = "dgvSpecs2" Then
                spec2_ds.Delete(code)
            ElseIf name = "dgvColor" Then
                color1_ds.Delete(code)
            ElseIf name = "dgvColor2" Then
                color2_ds.Delete(code)
            ElseIf name = "dgvDenier" Then
                denier_ds.Delete(code)
            ElseIf name = "dgvTH" Then
                th_ds.Insert(type, code)
            ElseIf name = "dgvPrinted" Then
                printed_ds.Insert(type, code)
            End If
        End If
    End Sub
    Sub popup_cms(ByVal cms As String, ByVal dgv As DataGridView)
        dgv.ContextMenuStrip = ContextMenuStrip1
        dgw = dgv
        cms1 = cms
       
    End Sub
    Sub command_data(ByVal Size As String, ByVal app As String, ByVal code As String, ByVal type As String, ByVal command As String, ByVal ds As invtry_dsTableAdapters.specs1TableAdapter)

      

    End Sub
    Private Sub dgvSpecs_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSpecs.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvSpecs", dgvSpecs)
            RemoveToolStripMenuItem.Enabled = True
        ElseIf e.Button = MouseButtons.Left Then
            dgvSpecs2.ClearSelection()
        End If
    End Sub

    Private Sub dgvSpecs2_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSpecs2.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvSpecs2", dgvSpecs2)
            RemoveToolStripMenuItem.Enabled = True
        ElseIf e.Button = MouseButtons.Left Then
            dgvSpecs.ClearSelection()
        End If
    End Sub


    Private Sub dgvDenier_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDenier.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvDenier", dgvDenier)
            RemoveToolStripMenuItem.Enabled = True
        End If
    End Sub



    Private Sub dgvColor_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvColor.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvColor", dgvColor)
            RemoveToolStripMenuItem.Enabled = True
        End If
    End Sub


    Private Sub dgvColor2_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvColor2.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvColor2", dgvColor2)
            RemoveToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub dgvTH_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTH.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvTH", dgvTH)
            RemoveToolStripMenuItem.Enabled = True
        End If
    End Sub
    Private Sub dgvPrinted_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPrinted.CellMouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvPrinted", dgvPrinted)
            RemoveToolStripMenuItem.Enabled = True
        End If
    End Sub

    
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Try
            If cms1 = "dgvSpecs" Or cms1 = "dgvSpecs2" Then
                Dim size = InputBox("Size", "Please input")
                Dim app = InputBox("Application", "Please input")
                Dim code = InputBox("Code", "Please input")
                If size <> "" And app <> "" And code <> "" Then
                    command_Data(size, app, code, "", "insert", cms1)
                    command_Data("", "", "", "", "select", "")
                End If
            Else
                Dim type = InputBox("Type", "Please input")
                Dim code = InputBox("Code", "Please input")
                If type <> "" And code <> "" Then
                    command_Data("", "", code, type, "insert", cms1)
                    command_Data("", "", "", "", "select", "")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            command_Data("", "", dgw.CurrentRow.Cells("Code").Value, "", "delete", cms1)
            command_Data("", "", "", "", "select", "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmFinishedItemDesc_Generator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSpecs.Columns.Clear()
        dgvSpecs2.Columns.Clear()
        dgvColor.Columns.Clear()
        dgvColor2.Columns.Clear()
        dgvDenier.Columns.Clear()
        dgvTH.Columns.Clear()
        dgvPrinted.Columns.Clear()
        command_Data("", "", "", "", "select", "")
    End Sub

    Private Sub dgvSpecs_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvSpecs.MouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvSpecs", dgvSpecs)
            RemoveToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub dgvSpecs2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvSpecs2.MouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvSpecs2", dgvSpecs2)
            RemoveToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub dgvDenier_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvDenier.MouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvDenier", dgvDenier)
            RemoveToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub dgvColor_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvColor.MouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvColor", dgvColor)
            RemoveToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub dgvColor2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvColor2.MouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvColor2", dgvColor2)
            RemoveToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub dgvTH_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvTH.MouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvTH", dgvTH)
            RemoveToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub dgvPrinted_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPrinted.MouseDown
        If e.Button = MouseButtons.Right Then
            popup_cms("dgvPrinted", dgvPrinted)
            RemoveToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            txtColor.Text += dgvColor2.SelectedRows.Item(0).Cells("Code").Value
        Catch ex As Exception

        End Try
        Try
            For Each r As DataGridViewRow In dgvColor.SelectedRows
                txtColor.Text += r.Cells("Code").Value
            Next
            txtColor.Text += "-"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtSpecs.Text = ""
        Try
            txtSpecs.Text = dgvSpecs.SelectedRows.Item(0).Cells("Code").Value
        Catch ex As Exception

        End Try
        Try
            txtSpecs.Text += dgvSpecs2.SelectedRows.Item(0).Cells("Code").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtDenier.Text = ""
        Try
            txtDenier.Text = dgvDenier.SelectedRows.Item(0).Cells("Code").Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        txtTH.Text = ""
        Try
            txtTH.Text = dgvTH.SelectedRows.Item(0).Cells("Code").Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        txtPrinted.Text = ""
        Try
            txtPrinted.Text = dgvPrinted.SelectedRows.Item(0).Cells("Code").Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If dgvColor2.SelectedRows.Count > 0 Then
                txtColor.Text += dgvColor2.SelectedRows.Item(0).Cells("Code").Value
                For Each r As DataGridViewRow In dgvColor.SelectedRows
                    txtColor.Text += r.Cells("Code").Value
                Next

            Else
                txtColor.Text += "PL" + dgvColor.SelectedRows.Item(0).Cells("Code").Value
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function generate_desc() As String
        Return txtSpecs.Text + "-" + txtDenier.Text + "-" + txtColor.Text + "-" + txtTH.Text + "-" + txtPrinted.Text
    End Function


    Private Sub dgvColor2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvColor2.KeyDown
        If e.KeyCode = Keys.Escape Then
            dgvColor2.ClearSelection()
        End If
    End Sub

    Private Sub dgvColor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvColor.KeyDown
        If e.KeyCode = Keys.Escape Then
            dgvColor.ClearSelection()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        generate_clicked = True
        Me.Close()
    End Sub
End Class