Public Class frmPDOR
    Dim tabt As Integer
    Sub clear()
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""

    End Sub
    Sub DisposeForm()
        clear()
        txtFYRNo.Text = ""
        txtOperator.Text = ""
        txtCustomer.Text = ""
        txtVisor.Text = ""
        txtMesh.Text = ""
        txtWaste.Text = ""
        dgv.Rows.Clear()
        INDICATORLIST()
    End Sub
    Sub INDICATORLIST()
        txtIndicator.Items.Clear()
        txtIndicator.Items.Add("H1")
        txtIndicator.Items.Add("H2")
        txtIndicator.Items.Add("H3")
        txtIndicator.Items.Add("H4")
        txtIndicator.Items.Add("H5")
        txtIndicator.Items.Add("H6")
        txtIndicator.Items.Add("H7")
        txtIndicator.Items.Add("H8")
        txtIndicator.Items.Add("H9")
        txtIndicator.Items.Add("H10")
        txtIndicator.Items.Add("H11")
        txtIndicator.Items.Add("H12")
        txtIndicator.Items.Add("SFC")
        txtIndicator.Items.Add("A/C")
        txtIndicator.Items.Add("QBT")
        txtIndicator.Items.Add("TOR")
        txtIndicator.Items.Add("TUR")
        txtIndicator.Items.Add("EXT")
        txtIndicator.Items.Add("Four")
        txtIndicator.Items.Add("Three")
        txtIndicator.Items.Add("One")
        txtIndicator.Items.Add("PG")
        txtIndicator.Items.Add("SO")
        txtIndicator.Items.Add("AN")
    End Sub
    Sub generateFYRNo()
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
                .CommandText = "SELECT * from tblPDORFY order by FYRNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                txtFYRNo.Text = "FYR-" & Format(Val(StrID) + 1, "00000")

            Else
                txtFYRNo.Text = "FYR-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtIndicator.Text = "" Then
            Exit Sub
        End If
        Dim R As Integer = dgv.Rows.Count
        dgv.Rows.Add()
        dgv.Item(0, R).Value = txtIndicator.Text
        dgv.Item(1, R).Value = t1.Text
        dgv.Item(2, R).Value = t2.Text
        dgv.Item(3, R).Value = t3.Text
        dgv.Item(4, R).Value = t4.Text
        dgv.Item(5, R).Value = t5.Text
        dgv.Item(6, R).Value = t6.Text
        dgv.Item(7, R).Value = t7.Text
        dgv.Item(8, R).Value = t8.Text
        clear()
        If txtIndicator.Items.Count = "1" Then
            txtIndicator.Items.Clear()
        Else
            txtIndicator.Items.Remove(txtIndicator.Text)
            txtIndicator.Text = txtIndicator.Items(0)
            t1.Focus()
        End If

    End Sub
    Sub timeArrange()
        txtTime1.Value = dtpDFrom.Value.ToString("dd/MM/yyyy") & " " & txtTime1.Value.ToString("hh:mm:00 tt")
        txtTime2.Value = dtpDFrom.Value.ToString("dd/MM/yyyy") & " " & txtTime2.Value.ToString("hh:mm:00 tt")
        txtTime3.Value = dtpDFrom.Value.ToString("dd/MM/yyyy") & " " & txtTime3.Value.ToString("hh:mm:00 tt")
        txtTime4.Value = dtpDFrom.Value.ToString("dd/MM/yyyy") & " " & txtTime4.Value.ToString("hh:mm:00 tt")
        If dtpDFrom.Value > txtTime1.Value Then
            txtTime1.Value = DateAdd(DateInterval.Day, +1, txtTime1.Value)
        End If
        If dtpDFrom.Value > txtTime2.Value Then
            txtTime2.Value = DateAdd(DateInterval.Day, +1, txtTime2.Value)
        End If
        If dtpDFrom.Value > txtTime3.Value Then
            txtTime3.Value = DateAdd(DateInterval.Day, +1, txtTime3.Value)
        End If
        If dtpDFrom.Value > txtTime4.Value Then
            txtTime4.Value = DateAdd(DateInterval.Day, +1, txtTime4.Value)
        End If
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
                timeArrange()
                With OleDBC
                    .Connection = conn
                    .CommandText = "INSERT INTO tblPDORFY VALUES('" & txtFYRNo.Text & _
                        "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dtpDto.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & txtMesh.Text & _
                        "','" & txtWaste.Text & _
                        "','" & Format(txtTime1.Value, "MM/dd/yyyy hh:mm tt") & _
                        "','" & Format(txtTime2.Value, "MM/dd/yyyy hh:mm tt") & _
                        "','" & Format(txtTime3.Value, "MM/dd/yyyy hh:mm tt") & _
                        "','" & Format(txtTime4.Value, "MM/dd/yyyy hh:mm tt") & _
                        "','" & txtCustomer.Text & _
                        "','" & txtOperator.Text & _
                        "','" & txtVisor.Text & "','Saved Date " & Format(Now, "MM/dd/yyyy") & "')"
                    .ExecuteNonQuery()
                End With
                saveItem()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Flat Yarn Machine Daily Report Saved !", MsgBoxStyle.Information, "Success")
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
                .CommandText = "INSERT INTO tblPDORFYTR VALUES('" & txtFYRNo.Text & _
                        "','" & dgv.Item(0, col).Value & _
                        "','" & dgv.Item(1, col).Value & _
                        "','" & dgv.Item(2, col).Value & _
                        "','" & dgv.Item(3, col).Value & _
                        "','" & dgv.Item(4, col).Value & _
                        "','" & dgv.Item(5, col).Value & _
                        "','" & dgv.Item(6, col).Value & _
                        "','" & dgv.Item(7, col).Value & _
                        "','" & dgv.Item(8, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub

    Private Sub frmPDOR_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        DisposeForm()
    End Sub

    Private Sub frmPDOR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            Button3.PerformClick()
        ElseIf e.KeyCode = Keys.F1 Then
            If tabt = 0 Then
                t2.Focus()
            ElseIf tabt = 1 Then
                t4.Focus()
            ElseIf tabt = 2 Then
                t6.Focus()
            ElseIf tabt = 3 Then
                t8.Focus()
            End If
            If tabt < 4 Then
                tabt = tabt + 1
            Else
                tabt = 0
            End If
        End If
    End Sub
    Private Sub frmPDOR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tabt = 0
        generateFYRNo()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVE()
    End Sub
    Private Sub DELETEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEToolStripMenuItem.Click
        For Each row As DataGridViewRow In dgv.SelectedRows
            txtIndicator.Items.Add(dgv.CurrentRow.Cells(0).Value)
            dgv.Rows.Remove(row)
        Next
    End Sub
    Private Sub t1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t1.TextChanged
        t3.Text = t1.Text
        t5.Text = t1.Text
        t7.Text = t1.Text
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DisposeForm()
        Me.Close()
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
        dgv.ContextMenuStrip = ContextMenuStrip2
    End Sub

End Class