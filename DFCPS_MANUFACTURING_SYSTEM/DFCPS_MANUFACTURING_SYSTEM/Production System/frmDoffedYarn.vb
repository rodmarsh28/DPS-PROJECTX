Public Class frmDoffedYarn
    Dim TOTGROSSWT As Double = 0
    Dim TOTNETWT As Double = 0
    Dim doffno As Integer

    Sub generateDYRNo()
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
                .CommandText = "SELECT * from tblDYR order by DYNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                txtDYNo.Text = "DYR-" & Format(Val(StrID) + 1, "00000")

            Else
                txtDYNo.Text = "DYR-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub clear()
        txtDoffedNo.Text = ""
        ''txtNoofBobbins.Text = ""
        txtGrossWt.Text = "0"
        txtNetWt.Text = "0"
    End Sub
    Sub DisposeForm()
        clear()
        txtDYNo.Text = ""
        txtOperator.Text = ""
        txtVisor.Text = ""
        TOTGROSSWT = 0
        TOTNETWT = 0
        lblTotNetwt.Text = Format(TOTNETWT, "N")
        dgv.Rows.Clear()
    End Sub
    Sub SAVE()
        If dgv.Rows.Count = "0" Then
            MsgBox("No Data can be Save", MsgBoxStyle.Critical, "Sorry")
            Exit Sub
        End If
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
                    .CommandText = "INSERT INTO tblDYR VALUES('" & txtDYNo.Text & _
                        "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dtpDto.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dgv.Rows.Count & _
                        "','" & TOTNETWT & _
                        "','" & txtOperator.Text & _
                        "','" & txtVisor.Text & "','Saved Date " & Format(Now, "MM/dd/yyyy") & _
                        "','" & dtpTimeStart.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dgv.Item(7, dgv.Rows.Count - 1).Value & "')"
                    .ExecuteNonQuery()
                End With
                saveItem()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Doffed Yarn Report Saved !", MsgBoxStyle.Information, "Success")
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
                .CommandText = "INSERT INTO tblDYTR VALUES('" & txtDYNo.Text & _
                        "','" & dgv.Item(7, col).Value & _
                        "','" & dgv.Item(1, col).Value & _
                        "','" & dgv.Item(2, col).Value & _
                        "','" & dgv.Item(3, col).Value & _
                        "','" & dgv.Item(4, col).Value & _
                        "','" & dgv.Item(5, col).Value & _
                        "','" & dgv.Item(6, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
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
        dgv.ContextMenuStrip = ContextMenuStrip2
    End Sub

    Private Sub DELETEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEToolStripMenuItem.Click
        For Each row As DataGridViewRow In dgv.SelectedRows
            TOTNETWT = TOTNETWT - dgv.CurrentRow.Cells(6).Value
            lblTotNetwt.Text = Format(TOTNETWT, "N")
            dgv.Rows.Remove(row)
            doffno = doffno - 1
            txtDoffedNo.Text = doffno
        Next
    End Sub
    Sub timeArrange()
        txtTime.Value = dtpDFrom.Value.ToString("dd/MM/yyyy") & " " & txtTime.Value.ToString("hh:mm:00 tt")
        dtpTimeStart.Value = dtpDFrom.Value.ToString("dd/MM/yyyy") & " " & dtpTimeStart.Value.ToString("hh:mm:00 tt")
        If dtpDFrom.Value > txtTime.Value Then
            txtTime.Value = DateAdd(DateInterval.Day, +1, txtTime.Value)
            dtpTimeStart.Value = DateAdd(DateInterval.Day, +1, dtpTimeStart.Value)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtDoffedNo.Text = "" Or txtNoofBobbins.Text = "" Then
            Exit Sub
        End If
        timeArrange()
        Dim R As Integer = dgv.Rows.Count
        dgv.Rows.Add()
        dgv.Item(0, R).Value = txtTime.Text
        dgv.Item(1, R).Value = txtDoffedNo.Text
        dgv.Item(2, R).Value = txtNoofBobbins.Text
        dgv.Item(3, R).Value = txtNoofbags.Text
        dgv.Item(4, R).Value = txtWtofBag.Text
        dgv.Item(5, R).Value = txtGrossWt.Text
        dgv.Item(6, R).Value = txtNetWt.Text
        dgv.Item(7, R).Value = Format(txtTime.Value, "MM/dd/yyyy hh:mm tt")
        TOTGROSSWT = TOTGROSSWT + txtGrossWt.Text
        TOTNETWT = TOTNETWT + txtNetWt.Text

        lblTotNetwt.Text = Format(TOTNETWT, "N")
        clear()
        doffno = doffno + 1
        txtDoffedNo.Text = doffno

        txtTime.Focus()
    End Sub

    Private Sub frmDoffedYarn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DisposeForm()
    End Sub

    Private Sub frmDoffedYarn_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.PerformClick()
        End If
    End Sub

    Private Sub frmDoffedYarn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateDYRNo()
        doffno = 1
        txtDoffedNo.Text = doffno
        txtGrossWt.Text = "0"
        txtNetWt.Text = "0"
        txtNoofbags.Text = "0"
        txtWtofBag.Text = "0"
        txtNoofBobbins.Text = "0"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVE()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DisposeForm()
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim netwt As Double
        netwt = txtGrossWt.Text - ((txtWtofBag.Text * txtNoofbags.Text) + 0.175 * txtNoofBobbins.Text)
        txtNetWt.Text = netwt
    End Sub
End Class