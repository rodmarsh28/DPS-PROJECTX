Public Class frmLogin
    Sub Login()
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
                .CommandText = "select * from tblUsers where username = '" & txtUsername.Text & "' and password = '" & txtPassword.Text & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then

                If OleDBDR.Read Then
                    MsgBox("WELCOME " & OleDBDR.Item(3), MsgBoxStyle.Information, "ACCESS GRANTED ! ")
                    MainForm.LBLID.Text = OleDBDR.Item(0)
                    MainForm.LBLNAME.Text = OleDBDR.Item(3)
                    MainForm.LBLPOS.Text = OleDBDR.Item(4)
                    Me.Close()
                    MainForm.Show()
                End If

            Else

                MsgBox("INCORRECT USERNAME / PASSWORD", MsgBoxStyle.Critical, "ERROR")
                txtPassword.Text = ""
                txtPassword.Focus()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Login()
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        MainForm.Close()
    End Sub
    Private Sub frmLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            frmDatabaseSettings.ShowDialog()
        End If
    End Sub
End Class
