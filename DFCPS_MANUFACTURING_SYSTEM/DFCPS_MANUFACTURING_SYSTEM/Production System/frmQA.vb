Public Class frmQA
    Sub generateQANo()
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
                .CommandText = "SELECT * from tblQA order by QANO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 4, Len(OleDBDR(0)))
                txtQAno.Text = "QA-" & Format(Val(StrID) + 1, "00000")

            Else
                txtQAno.Text = "QA-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub DisposeForm()
        txtQAno.Text = ""
        txtMesh.Text = ""
        'txtCustomer.Text = ""
        'txtVisor.Text = ""
        AD1.Text = ""
        AT1.Text = ""
        RPM1.Text = ""
        AD2.Text = ""
        AT2.Text = ""
        RPM2.Text = ""
        AD3.Text = ""
        AT3.Text = ""
        RPM3.Text = ""
        txtRemarks.Text = ""
    End Sub
  
    Sub SAVE()
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
                    .CommandText = "INSERT INTO tblQA VALUES('" & txtQAno.Text & _
                        "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dtpDto.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & txtQA.Text & _
                        "','" & txtMesh.Text & _
                        "','" & txtCos.Text & _
                        "','" & txtVisor.Text & _
                        "','" & AD1.Text & _
                        "','" & AT1.Text & _
                        "','" & RPM1.Text & _
                        "','" & AD2.Text & _
                        "','" & AT2.Text & _
                        "','" & RPM2.Text & _
                        "','" & AD3.Text & _
                        "','" & AT3.Text & _
                        "','" & RPM3.Text & _
                        "','" & txtRemarks.Text & "')"
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("QA DAILY REPORT SAVED !", MsgBoxStyle.Information, "SUCCESS")
                DisposeForm()
                'Me.Close()
                generateQANo()
            End Try
        End If
    End Sub

 

 

    Private Sub frmQA_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DisposeForm()
    End Sub

    Private Sub frmQA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateQANo()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVE()
    End Sub
   
    

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
  

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub
End Class