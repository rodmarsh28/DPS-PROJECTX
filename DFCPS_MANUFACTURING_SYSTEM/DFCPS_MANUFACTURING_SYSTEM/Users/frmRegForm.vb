Public Class frmRegForm
    Sub selectUserId()
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
                .CommandText = "SELECT * from tblUsers order by userID DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 7, Len(OleDBDR(0)))
                txtUserID.Text = "USR-" & Format(Val(StrID) + 1, "00000")

            Else
                txtUserID.Text = "USR-00001"

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub save()
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
                .CommandText = "INSERT INTO tblUsers VALUES('" & txtUserID.Text & _
                    "','" & txtUsername.Text & _
                    "','" & txtPass.Text & _
                    "','" & txtFn.Text & " " & txtMi.Text & ". " & txtLn.Text & _
                    "','" & cmbAccRole.Text & _
                    "','YES')"
                .ExecuteNonQuery()
            End With
            MsgBox("REGISTERED SUCCESSFULLY", MsgBoxStyle.Information, "SUCCESS")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReg.Click
        If txtFn.Text = "" Or txtMi.Text = "" Or txtLn.Text = "" Or txtPass.Text = "" Or cmbAccRole.Text = "" Then
            MsgBox("PLEASE FILL ALL FIELDS", MsgBoxStyle.Critical, "ERROR")
        ElseIf txtPass.Text <> txtRepass.Text Then
            MsgBox("YOUR PASSWORD DID NOT MATCH", MsgBoxStyle.Critical, "ERROR")
            txtPass.Text = ""
            txtRepass.Text = ""
        Else
            save()
        End If
    End Sub

    Private Sub frmRegForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selectUserId()
    End Sub
End Class