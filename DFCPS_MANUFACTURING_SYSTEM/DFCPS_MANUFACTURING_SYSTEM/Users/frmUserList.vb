Public Class frmUserList

    Private Sub frmUserList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showallUsers()
        disableCommand()

    End Sub
    Sub clear()
        txtPass.Text = ""
        txtRepass.Text = ""
    End Sub
    Sub showallUsers()

        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "select * from tblUsers"
            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1)
                    dgw.Item(2, c).Value = OleDBDR.Item(4)
                    dgw.Item(3, c).Value = OleDBDR.Item(5)
                    c = c + 1
                End While
            End If
            dgw.ClearSelection()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub disableCommand()
        txtPass.Enabled = False
        txtRepass.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub
    Sub enableCommand()
        txtPass.Enabled = True
        txtRepass.Enabled = True
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub DISABLEUSERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DISABLEUSERToolStripMenuItem.Click
        enableCommand()
        dgw.Enabled = False
        txtPass.Focus()
    End Sub

    Private Sub DISABLEUSERToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DISABLEUSERToolStripMenuItem1.Click
        If MsgBox("ARE YOU SURE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Dim status As String
            If dgw.CurrentRow.Cells(3).Value = "YES" Then
                status = "NO"
            Else
                status = "YES"
            End If
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
                    .CommandText = "update tblUsers SET isActive = '" & status & "' where userID = '" & dgw.CurrentRow.Cells(0).Value & "'"
                    .ExecuteNonQuery()
                End With
                MsgBox("STATUS UPDATED", MsgBoxStyle.Information, "SUCCESS")
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
            showallUsers()
        End If
    End Sub
    Sub savePassword()
        If MsgBox("ARE YOU SURE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Dim status As String
            If dgw.CurrentRow.Cells(3).Value = "YES" Then
                status = "NO"
            Else
                status = "YES"
            End If
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
                    .CommandText = "update tblUsers SET password = '" & txtPass.Text & "' where userID = '" & dgw.CurrentRow.Cells(0).Value & "'"
                    .ExecuteNonQuery()
                End With
                MsgBox("PASSWORD CHANGED !", MsgBoxStyle.Information, "SUCCESS")
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
            showallUsers()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
        disableCommand()
        dgw.Enabled = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtPass.Text <> txtRepass.Text Then
            MsgBox("THE PASSWORD YOU ENTERED IS NOT MATCH", MsgBoxStyle.Critical, "ERROR")
            clear()
            txtPass.Focus()
        ElseIf txtPass.Text = "" And txtRepass.Text = "" Then
            MsgBox("YOU CAN'T INPUT BLANK PASSWORD", MsgBoxStyle.Critical, "ERROR")
            clear()
            txtPass.Focus()
        Else
            savePassword()
            clear()
            disableCommand()
            dgw.Enabled = True
        End If
    End Sub

    Private Sub dgw_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgw.CellMouseDown
        If e.Button = MouseButtons.Right Then
            dgw.CurrentCell = dgw(e.ColumnIndex, e.RowIndex)
            dgw.ContextMenuStrip = ContextMenuStrip1
        End If

    End Sub

    Private Sub ContextMenuStrip1_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles ContextMenuStrip1.Closed
        dgw.ContextMenuStrip = ContextMenuStrip2
    End Sub

   
End Class