Public Class frmDatabaseSettings
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.mServer = txtServer.Text
        My.Settings.mDBname = txtDBname.Text
        My.Settings.mUserDB = txtUser.Text
        My.Settings.mPassDB = txtPass.Text
        My.Settings.Save()
        MsgBox("CONNECTION OF DATABASE SAVED !", MsgBoxStyle.Information, "SUCCESS")
        My.Settings.Reload()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                strConnString = "Data Source=" & txtServer.Text & ";" & _
                       "Initial Catalog=" & txtDBname.Text & ";" & _
                       "User ID=" & txtUser.Text & ";" & _
                       "Password=" & txtPass.Text
                conn.ConnectionString = strConnString
                conn.Open()
                MsgBox("SUCCESS CONNECTION !")
            End If
        Catch ex As Exception
            MsgBox("WRONG DATABASE INFORMATION", MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub frmDatabaseConnection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtServer.Text = My.Settings.mServer
        txtDBname.Text = My.Settings.mDBname
        txtUser.Text = My.Settings.mUserDB
        txtPass.Text = My.Settings.mPassDB
        Button1.Focus()
    End Sub
End Class