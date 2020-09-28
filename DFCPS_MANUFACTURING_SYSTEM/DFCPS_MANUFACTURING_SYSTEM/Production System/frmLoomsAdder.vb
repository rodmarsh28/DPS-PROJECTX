Public Class frmLoomsAdder
    Dim STATUS As String
    Sub getLoomList()
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
                .CommandText = "SELECT * from tblLooms "
            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim c As Integer = 0
            If OleDBDR.HasRows Then
                dgw.Rows.Clear()
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1)
                    dgw.Item(2, c).Value = OleDBDR.Item(2)
                    If OleDBDR.Item(2) = "Enable" Then
                        dgw.Rows(c).Cells(2).Style.BackColor = Color.Green
                    Else
                        dgw.Rows(c).Cells(2).Style.BackColor = Color.Red
                    End If
                    c = c + 1
                End While
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub generateLoomNo()
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
                .CommandText = "SELECT * from tblLooms order by loomNo DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 1, Len(OleDBDR(0)))
                txtLOOMNo.Text = Format(Val(StrID) + 1, "000")

            Else
                txtLOOMNo.Text = "001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub Addloom()
        If MsgBox("ARE YOU SURE YOU WANT TO ADD ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = "INSERT INTO tblLooms VALUES('" & txtLOOMNo.Text & _
                        "','" & txtLoomDesc.Text & _
                        "','Enable')"
                    .ExecuteNonQuery()
                End With
                MsgBox("LOOM ADDED SUCCESSFULLY", MsgBoxStyle.Information, "SUCCESS")
                getLoomList()
                generateLoomNo()
                txtLoomDesc.Text = ""
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtLoomDesc.Text = "" Then
            MsgBox("PLEASE INPUT LOOM DESCRIPTION", MsgBoxStyle.Critical, "ERROR")
        Else
            Addloom()
        End If

    End Sub

    Private Sub frmLoomsAdder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub
    Private Sub frmLoomsAdder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateLoomNo()
        getLoomList()
    End Sub

    Private Sub DISABLEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DISABLEToolStripMenuItem.Click
        If dgw.CurrentRow.Cells(2).Value = "Enable" Then
            STATUS = "Disable"
        ElseIf dgw.CurrentRow.Cells(2).Value = "Disable" Then
            STATUS = "Enable"
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
                .CommandText = "update tblLooms set status = '" & STATUS & "' where LoomNo = '" & dgw.CurrentRow.Cells(0).Value & "'"
                .ExecuteNonQuery()
            End With
            getLoomList()
            MsgBox("Loom You Selected is " & STATUS, MsgBoxStyle.Information, "Success")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub

    Private Sub dgw_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgw.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgw.CurrentCell = dgw(e.ColumnIndex, e.RowIndex)
                dgw.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgw.ContextMenuStrip = ContextMenuStrip2
    End Sub
End Class