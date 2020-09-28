Public Class frmDoffed
    Sub clear()
        txtRollNo.Text = ""
        txtLoomNo.Text = ""
        txtMesh.Text = ""
        txtWidth.Text = ""
        txtLength.Text = ""
        txtWeight.Text = ""
        txtDoffer.Text = ""
    End Sub
    Sub generateRollNo()
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
                .CommandText = "SELECT max(rollNo) from tblDoffed "
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                If IsDBNull(OleDBDR.Item(0)) Then
                    txtRollNo.Text = "1"
                Else
                    txtRollNo.Text = OleDBDR.Item(0) + 1
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub getLoomsNo()
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
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    txtLoomNo.Items.Add(OleDBDR.Item(0))
                End While

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub save()
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
                    .CommandText = "INSERT INTO tblDoffed VALUES('" & txtRollNo.Text & _
                        "','" & dtpDoffDate.Value.ToString("MM/dd/yyyy") & _
                        "','" & txtLoomNo.Text & _
                        "','" & txtMesh.Text & _
                        "','" & txtWidth.Text & _
                        "','" & txtLength.Text & _
                        "','" & txtWeight.Text & _
                        "','" & txtDoffer.Text & "')"
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("DOFFED SAVED !", MsgBoxStyle.Information, "SUCCESS")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        save()
    End Sub

    Private Sub frmDoffed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateRollNo()
        getLoomsNo()
    End Sub
End Class