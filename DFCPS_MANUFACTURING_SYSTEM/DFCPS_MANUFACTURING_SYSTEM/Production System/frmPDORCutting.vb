Public Class frmPDORCutting
    Dim balanceLength As Double
    Public actualLength As Double
    Sub generateCSRNo()
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
                .CommandText = "SELECT * from tblCSR order by CSRNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                txtCSRNo.Text = "CSR-" & Format(Val(StrID) + 1, "00000")

            Else
                txtCSRNo.Text = "CSR-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    'Sub getLoomsNo()
    '    Try
    '        If conn.State = ConnectionState.Open Then
    '            OleDBC.Dispose()
    '            conn.Close()
    '        End If
    '        If conn.State <> ConnectionState.Open Then
    '            ConnectDatabase()
    '        End If
    '        With OleDBC
    '            .Connection = conn
    '            .CommandText = "SELECT * from tblLooms where STATUS = 'Enable' order by loomNo DESC"
    '        End With
    '        OleDBDR = OleDBC.ExecuteReader
    '        cmbLoomsNo.Items.Clear()
    '        If OleDBDR.HasRows Then
    '            While OleDBDR.Read
    '                cmbLoomsNo.Items.Add(OleDBDR.Item(0))
    '            End While

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally

    '    End Try
    'End Sub
    'Sub getLoomsNo()
    '    Try
    '        If conn.State = ConnectionState.Open Then
    '            OleDBC.Dispose()
    '            conn.Close()
    '        End If
    '        If conn.State <> ConnectionState.Open Then
    '            ConnectDatabase()
    '        End If
    '        With OleDBC
    '            .Connection = conn
    '            .CommandText = "SELECT * from tblDoffed where rollNo = '" & cmbRollNo.Text & "'"
    '        End With
    '        OleDBDR = OleDBC.ExecuteReader
    '        If OleDBDR.Read Then
    '            txtLoomNo.Text = OleDBDR.Item(0)
    '            txtInputLength.Text = OleDBDR.Item(5)
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally

    '    End Try
    'End Sub
    'Sub getRollNo()
    '    Try
    '        If conn.State = ConnectionState.Open Then
    '            OleDBC.Dispose()
    '            conn.Close()
    '        End If
    '        If conn.State <> ConnectionState.Open Then
    '            ConnectDatabase()
    '        End If
    '        With OleDBC
    '            .Connection = conn
    '            .CommandText = "SELECT * from tblDoffed order by rollNo DESC"
    '        End With
    '        OleDBDR = OleDBC.ExecuteReader
    '        cmbRollNo.Items.Clear()
    '        If OleDBDR.HasRows Then
    '            While OleDBDR.Read
    '                cmbRollNo.Items.Add(OleDBDR.Item(0))
    '            End While

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally

    '    End Try
    'End Sub
    Sub clear()

        txtLoomNo.Text = ""
        txtInputLength.Text = ""
        txtOutputQty.Text = ""
        txtBadLength.Text = ""
        txtRollNo.Text = ""
        txtMesh.Text = ""

    End Sub
    Sub DisposeForm()
        clear()
        txtCSRNo.Text = ""
        txtOperator.Text = ""
        txtVisor.Text = ""
        txtCustomer.Text = ""
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
                    .CommandText = "INSERT INTO tblCSR VALUES('" & txtCSRNo.Text & _
                        "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dtpDto.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dgv.Rows.Count & _
                        "','" & txtOperator.Text & _
                        "','" & txtVisor.Text & "','Saved Date " & Format(Now, "MM/dd/yyyy") & "')"
                    .ExecuteNonQuery()
                End With
                saveItem()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Cutting & Sewing Daily Report Saved !", MsgBoxStyle.Information, "Success")
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
                    If dgv.Item(7, col).Value = "0" Then
                        .CommandText = "INSERT INTO tblCSRTR VALUES('" & txtCSRNo.Text & _
                              "','" & dgv.Item(0, col).Value & _
                              "','" & dgv.Item(2, col).Value & _
                              "','" & dgv.Item(4, col).Value & _
                              "','" & dgv.Item(5, col).Value & _
                              "','" & dgv.Item(6, col).Value & _
                              "','" & dgv.Item(7, col).Value & _
                              "','" & dgv.Item(11, col).Value & _
                              "','" & dgv.Item(12, col).Value & _
                              "','" & dgv.Item(10, col).Value & "','PENDING FOR INSPECTION'); " & _
                              "Update tblDoffed set Length = '" & dgv.Item(7, col).Value & "', " & _
                              "status = 'Stock Out' " & _
                              "Where rollNo = '" & dgv.Item(2, col).Value & "'"
                    Else
                        .CommandText = "INSERT INTO tblCSRTR VALUES('" & txtCSRNo.Text & _
                                "','" & dgv.Item(0, col).Value & _
                                "','" & dgv.Item(2, col).Value & _
                                "','" & dgv.Item(4, col).Value & _
                                "','" & dgv.Item(5, col).Value & _
                                "','" & dgv.Item(6, col).Value & _
                                "','" & dgv.Item(7, col).Value & _
                                "','" & dgv.Item(11, col).Value & _
                                "','" & dgv.Item(12, col).Value & _
                                "','" & dgv.Item(10, col).Value & "','PENDING FOR INSPECTION'); " & _
                                "Update tblDoffed set Length = '" & dgv.Item(7, col).Value & "' " & _
                                "Where rollNo = '" & dgv.Item(2, col).Value & "'"
                    End If

                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
            col = col + 1
        End While
    End Sub
    Private Sub dgv_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Try
            If e.Button = MouseButtons.Right Then
                dgv.CurrentCell = dgv(e.ColumnIndex, e.RowIndex)
                dgv.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub delete()
        For Each row As DataGridViewRow In dgv.SelectedRows
            dgv.Rows.Remove(row)
        Next
    End Sub
    Private Sub DELETEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEToolStripMenuItem.Click
        delete()
    End Sub
    Sub timeArrange()
        txtTimeStart.Value = dtpDFrom.Value.ToString("dd/MM/yyyy") & " " & txtTimeStart.Value.ToString("hh:mm:00 tt")
        timeEnd.Value = dtpDFrom.Value.ToString("dd/MM/yyyy") & " " & timeEnd.Value.ToString("hh:mm:00 tt")
        If dtpDFrom.Value > timeStart.Value Then
            txtTimeStart.Value = DateAdd(DateInterval.Day, +1, txtTimeStart.Value)
        End If
        If dtpDFrom.Value > timeEnd.Value Then
            timeEnd.Value = DateAdd(DateInterval.Day, +1, timeEnd.Value)
        End If
    End Sub

    Private Sub frmPDORCutting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DisposeForm()
    End Sub
    Private Sub frmPDORCutting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateCSRNo()
    End Sub
    Sub updateRoll()

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVE()

    End Sub
    Sub calculate()
        Dim al As Double
        al = actualLength - txtInputLength.Text
       
        'balanceLength = (((txtInputLength.Text * 100) - (txtBadLength.Text * txtOutputQty.Text)) / 100) + al
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtRollNo.Text = "" Or txtLoomNo.Text = "" Or txtInputLength.Text = "" Or txtOutputQty.Text = "" Or txtBadLength.Text = "" Then
            Exit Sub
        End If
        calculate()
        timeArrange()
        Dim R As Integer = dgv.Rows.Count
        dgv.Rows.Add()
        dgv.Item(0, R).Value = txtCustomer.Text
        dgv.Item(1, R).Value = txtMesh.Text
        dgv.Item(2, R).Value = txtRollNo.Text
        dgv.Item(3, R).Value = txtLoomNo.Text
        dgv.Item(4, R).Value = txtInputLength.Text
        dgv.Item(5, R).Value = txtOutputQty.Text
        dgv.Item(6, R).Value = txtBadLength.Text
        If txtBalLength.Text = "" Then
            dgv.Item(7, R).Value = "0"
        Else
            dgv.Item(7, R).Value = txtBalLength.Text
        End If
        dgv.Item(8, R).Value = txtTimeStart.Text
        dgv.Item(9, R).Value = timeEnd.Text
        dgv.Item(10, R).Value = txtRemarks.Text
        dgv.Item(11, R).Value = Format(txtTimeStart.Value, "MM/dd/yyyy hh:mm tt")
        dgv.Item(12, R).Value = Format(timeEnd.Value, "MM/dd/yyyy hh:mm tt")

        clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        DisposeForm()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmRollSelection.mode = "CUTTING"
        frmRollSelection.ShowDialog()
    End Sub
    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        txtCustomer.Text = dgv.CurrentRow.Cells(0).Value
        txtMesh.Text = dgv.CurrentRow.Cells(1).Value
        txtRollNo.Text = dgv.CurrentRow.Cells(2).Value
        txtLoomNo.Text = dgv.CurrentRow.Cells(3).Value
        txtInputLength.Text = dgv.CurrentRow.Cells(4).Value
        txtOutputQty.Text = dgv.CurrentRow.Cells(5).Value
        txtBadLength.Text = dgv.CurrentRow.Cells(6).Value
        txtRemarks.Text = dgv.CurrentRow.Cells(10).Value
        DELETE()
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub txtBalLength_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBalLength.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub

End Class