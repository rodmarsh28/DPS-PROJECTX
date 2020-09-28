Public Class frmBackupDatabase
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    FolderBrowserDialog1.Description = "Select Folder to Save Backup"
    '    If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
    '        dir.Text = FolderBrowserDialog1.SelectedPath & "\"
    '        My.Settings.backupDirectory = FolderBrowserDialog1.SelectedPath & "\"
    '    End If
    'End Sub


    Private Sub frmBackupAndRestore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dir.Text = My.Settings.backupDirectory
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'frmLoading.ShowDialog()
        If dir.Text = "" Then
            MsgBox("Please select folder first", MsgBoxStyle.Critical, "error")
        Else
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
                    .CommandText = "BACKUP DATABASE DFCPSMASTERLISTDB TO DISK = '" & dir.Text & "DATABASE-" & Now.ToString("MM-dd-yyyy") & ".bak' "
                    .ExecuteNonQuery()
                End With
                'frmLoading.Close()
                MsgBox("Backup Success", MsgBoxStyle.Information, "Success")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

End Class