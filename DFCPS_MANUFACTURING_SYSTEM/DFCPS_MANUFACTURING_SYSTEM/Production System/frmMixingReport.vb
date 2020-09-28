Public Class frmMixingReport
    Dim ppWt As Double = 0
    Dim caWt As Double = 0
    Dim modWt As Double = 0
    Dim col1Wt As Double = 0
    Dim col2Wt As Double = 0
    Dim othersWt As Double = 0
    Dim rrWt As Double = 0
    Dim Total As Double = 0

    Sub generateMRNo()
        Dim StrID As String
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT * from tblMR order by MRNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 4, Len(OleDBDR(0)))
                txtMRNo.Text = "MR-" & Format(Val(StrID) + 1, "00000")

            Else
                txtMRNo.Text = "MR-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub clear()
        txt1.Text = ""
        txt2.Text = ""
        txt3.Text = ""
        txt4.Text = ""
        txt5.Text = ""
        txt6.Text = ""
        txt7.Text = ""
        txt8.Text = ""
        txt9.Text = ""
        txt10.Text = ""
        txt11.Text = ""
        txt12.Text = ""
        txt13.Text = ""
        txt14.Text = ""
    End Sub
    Sub DisposeForm()
        clear()
        txtMRNo.Text = ""
        txtOperator.Text = ""
        txtVisor.Text = ""
        txtMesh.Text = ""
        txtppBrand.Text = ""
        txtCbrand.Text = ""
        txtModBrand.Text = ""
        txtColBrand.Text = ""
        txtCol2Brand.Text = ""
        txtOtherBrand.Text = ""
        ppWt = 0
        caWt = 0
        modWt = 0
        col1Wt = 0
        col2Wt = 0
        othersWt = 0
        rrWt = 0
        Total = 0
        lblPPTot.Text = Format(ppWt, "N")
        lblCaTot.Text = Format(caWt, "N")
        lblModTot.Text = Format(modWt, "N")
        lblCol1Tot.Text = Format(col1Wt, "N")
        lblCol2Tot.Text = Format(col2Wt, "N")
        lblOthersTot.Text = Format(othersWt, "N")
        lblRR.Text = Format(rrWt, "N")
        lblTotal.Text = Format(Total, "N")

        dgv.Rows.Clear()
    End Sub
    Sub convertToZero()
        If txt1.Text = "" Then
            txt1.Text = "0"
        End If
        If txt2.Text = "" Then
            txt2.Text = "0"
        End If
        If txt3.Text = "" Then
            txt3.Text = "0"
        End If
        If txt4.Text = "" Then
            txt4.Text = "0"
        End If
        If txt5.Text = "" Then
            txt5.Text = "0"
        End If
        If txt6.Text = "" Then
            txt6.Text = "0"
        End If
        If txt7.Text = "" Then
            txt7.Text = "0"
        End If
        If txt8.Text = "" Then
            txt8.Text = "0"
        End If
        If txt9.Text = "" Then
            txt9.Text = "0"
        End If
        If txt10.Text = "" Then
            txt10.Text = "0"
        End If
        If txt11.Text = "" Then
            txt11.Text = "0"
        End If
        If txt12.Text = "" Then
            txt12.Text = "0"
        End If
        If txt13.Text = "" Then
            txt13.Text = "0"
        End If
        If txt14.Text = "" Then
            txt14.Text = "0"
        End If
    End Sub
    Sub SAVE()
        If MsgBox("ARE YOU SURE YOU WANT TO SAVE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Try
                If conn.State = ConnectionState.Open Then
                    OleDBC.Dispose()
                    conn.Close()
                End If
                If conn.State <> ConnectionState.Open Then
                    ConnectDatabase()
                End If
                With OleDBC
                    .Connection = conn
                    .CommandText = "INSERT INTO tblMR VALUES('" & txtMRNo.Text & _
                        "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & txtOperator.Text & _
                        "','" & txtVisor.Text & _
                        "','" & dgv.Rows.Count & _
                        "','" & ppWt & _
                        "','" & caWt & _
                        "','" & modWt & _
                        "','" & col1Wt & _
                        "','" & col2Wt & _
                        "','" & rrWt & _
                        "','" & othersWt & _
                        "','" & Total & "','Saved Date " & Format(Now, "MM/dd/yyyy") & "')"
                    .ExecuteNonQuery()
                End With
                saveItem()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Mixing Report Saved !", MsgBoxStyle.Information, "Success")
                DisposeForm()
                Me.Close()
            End Try
        End If
    End Sub

    Sub saveItem()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgv.RowCount
        While col < row1
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "INSERT INTO tblMRTR VALUES('" & txtMRNo.Text & _
                        "','" & dgv.Item(23, col).Value & _
                        "','" & dgv.Item(1, col).Value & _
                        "','" & dgv.Item(2, col).Value & _
                        "','" & dgv.Item(3, col).Value & _
                        "','" & dgv.Item(4, col).Value & _
                        "','" & dgv.Item(5, col).Value & _
                        "','" & dgv.Item(6, col).Value & _
                        "','" & dgv.Item(7, col).Value & _
                        "','" & dgv.Item(8, col).Value & _
                        "','" & dgv.Item(9, col).Value & _
                        "','" & dgv.Item(10, col).Value & _
                        "','" & dgv.Item(11, col).Value & _
                        "','" & dgv.Item(12, col).Value & _
                        "','" & dgv.Item(13, col).Value & _
                        "','" & dgv.Item(14, col).Value & _
                        "','" & dgv.Item(15, col).Value & _
                        "','" & dgv.Item(16, col).Value & _
                        "','" & dgv.Item(17, col).Value & _
                        "','" & dgv.Item(18, col).Value & _
                        "','" & dgv.Item(19, col).Value & _
                        "','" & dgv.Item(20, col).Value & _
                        "','" & dgv.Item(21, col).Value & _
                        "','" & dgv.Item(22, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub
    Sub timeArrange()
        txtTime.Value = dtpDFrom.Value.ToString("dd/MM/yyyy") & " " & txtTime.Value.ToString("hh:mm:00 tt")
        If dtpDFrom.Value > txtTime.Value Then
            txtTime.Value = DateAdd(DateInterval.Day, +1, txtTime.Value)
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        convertToZero()
        timeArrange()
        If txtMesh.Text = "" Then
            Exit Sub
        End If
        Dim R As Integer = dgv.Rows.Count
        dgv.Rows.Add()
        dgv.Item(0, R).Value = txtTime.Text
        dgv.Item(1, R).Value = txtMesh.Text
        dgv.Item(2, R).Value = txtppBrand.Text
        dgv.Item(3, R).Value = txt1.Text
        dgv.Item(4, R).Value = txt2.Text
        dgv.Item(5, R).Value = txtCbrand.Text
        dgv.Item(6, R).Value = txt3.Text
        dgv.Item(7, R).Value = txt4.Text
        dgv.Item(8, R).Value = txtModBrand.Text
        dgv.Item(9, R).Value = txt5.Text
        dgv.Item(10, R).Value = txt6.Text
        dgv.Item(11, R).Value = txtColBrand.Text
        dgv.Item(12, R).Value = txt7.Text
        dgv.Item(13, R).Value = txt8.Text
        dgv.Item(14, R).Value = txtCol2Brand.Text
        dgv.Item(15, R).Value = txt9.Text
        dgv.Item(16, R).Value = txt10.Text
        dgv.Item(17, R).Value = txtRR.Text
        dgv.Item(18, R).Value = txt13.Text
        dgv.Item(19, R).Value = txt14.Text
        dgv.Item(20, R).Value = txtOtherBrand.Text
        dgv.Item(21, R).Value = txt11.Text
        dgv.Item(22, R).Value = txt12.Text
        dgv.Item(23, R).Value = Format(txtTime.Value, "MM/dd/yyyy hh:mm tt")

        ppWt = ppWt + txt1.Text
        caWt = caWt + txt3.Text
        modWt = modWt + txt5.Text
        col1Wt = col1Wt + txt7.Text
        col2Wt = col2Wt + txt9.Text
        othersWt = othersWt + txt11.Text
        rrWt = rrWt + txt13.Text
        Total = ppWt + caWt + modWt + col1Wt + col2Wt + rrWt + othersWt


        lblPPTot.Text = Format(ppWt, "N")
        lblCaTot.Text = Format(caWt, "N")
        lblModTot.Text = Format(modWt, "N")
        lblCol1Tot.Text = Format(col1Wt, "N")
        lblCol2Tot.Text = Format(col2Wt, "N")
        lblRR.Text = Format(rrWt, "N")
        lblOthersTot.Text = Format(othersWt, "N")
        lblTotal.Text = Format(Total, "N")

    End Sub

    Private Sub frmMixingReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DisposeForm()
    End Sub

    Private Sub frmMixingReport_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.PerformClick()
        End If
    End Sub

    Private Sub frmMixingReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateMRNo()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        For Each row As DataGridViewRow In dgv.SelectedRows
            ppWt = ppWt - dgv.CurrentRow.Cells(3).Value
            caWt = caWt - dgv.CurrentRow.Cells(6).Value
            modWt = modWt - dgv.CurrentRow.Cells(9).Value
            col1Wt = col1Wt - dgv.CurrentRow.Cells(12).Value
            col2Wt = col2Wt - dgv.CurrentRow.Cells(15).Value
            rrWt = rrWt - dgv.CurrentRow.Cells(18).Value
            othersWt = othersWt - dgv.CurrentRow.Cells(21).Value
            Total = ppWt + caWt + modWt + col1Wt + col2Wt + rrWt + othersWt
            dgv.Rows.Remove(row)
            lblPPTot.Text = Format(ppWt, "N")
            lblCaTot.Text = Format(caWt, "N")
            lblModTot.Text = Format(modWt, "N")
            lblCol1Tot.Text = Format(col1Wt, "N")
            lblCol2Tot.Text = Format(col2Wt, "N")
            lblRR.Text = Format(rrWt, "N")
            lblOthersTot.Text = Format(othersWt, "N")
            lblTotal.Text = Format(Total, "N")
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVE()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgv.ContextMenuStrip = ContextMenuStrip2
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

 
    Private Sub Label26_Click(sender As System.Object, e As System.EventArgs) Handles Label26.Click

    End Sub

    'Private Sub B1_Click(sender As System.Object, e As System.EventArgs) Handles B1.Click
    '    perform = "B1"
    '    frmItemViewer.ShowDialog()
    'End Sub

    'Private Sub B2_Click(sender As System.Object, e As System.EventArgs) Handles B2.Click
    '    perform = "B2"
    '    frmItemViewer.ShowDialog()
    'End Sub

    'Private Sub B3_Click(sender As System.Object, e As System.EventArgs) Handles B3.Click
    '    perform = "B3"
    '    frmItemViewer.ShowDialog()
    'End Sub

    'Private Sub B4_Click(sender As System.Object, e As System.EventArgs) Handles B4.Click
    '    perform = "B4"
    '    frmItemViewer.ShowDialog()
    'End Sub

    'Private Sub B5_Click(sender As System.Object, e As System.EventArgs) Handles B5.Click
    '    perform = "B5"
    '    frmItemViewer.ShowDialog()
    'End Sub

    'Private Sub B6_Click(sender As System.Object, e As System.EventArgs) Handles B6.Click
    '    perform = "B6"
    '    frmItemViewer.ShowDialog()
    'End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    perform = "B7"
    '    frmItemViewer.ShowDialog()
    'End Sub
End Class