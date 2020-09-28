Public Class frmCrusher
    Sub getColor()
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
                .CommandText = "SELECT Distinct COLOR from tblLoomSectionTR where COLOR <> ''"
            End With
            OleDBDR = OleDBC.ExecuteReader
            cmbColor.Items.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    cmbColor.Items.Add(OleDBDR.Item(0))
                End While

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub disposeform()
        txtOperator.Text = ""
        txtVisor.Text = ""
        txtRemarks.Text = ""
        txtWt.Text = ""
        dgv.Rows.Clear()
    End Sub

    Sub generateCRRNo()
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
                .CommandText = "SELECT * from tblCrusher order by CRUSHERNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                TXTCRRNO.Text = "CRR-" & Format(Val(StrID) + 1, "00000")

            Else
                TXTCRRNO.Text = "CRR-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
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
                    .CommandText = "INSERT INTO tblCrusher VALUES('" & TXTCRRNO.Text & _
                        "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dtpDto.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & txtOperator.Text & _
                        "','" & txtVisor.Text & _
                        "','" & txtRemarks.Text & "')"
                    .ExecuteNonQuery()
                End With
                saveItem()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Crusher Report Saved !", MsgBoxStyle.Information, "Success")
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
                .CommandText = "INSERT INTO tblCrusherTR VALUES('" & TXTCRRNO.Text & _
                        "','" & dgv.Item(0, col).Value & _
                        "','" & dgv.Item(1, col).Value & _
                        "','" & dgv.Item(2, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub

    Private Sub frmCrusher_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        disposeform()
    End Sub
    Private Sub frmCrusher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateCRRNo()
        getColor()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtWt.Text = "" Or IsNumeric(txtWt.Text) = False Then
            Exit Sub
        End If
        Dim r As Integer = dgv.Rows.Count
        dgv.Rows.Add()
        dgv.Item(0, r).Value = cmbYarnKind.Text
        dgv.Item(1, r).Value = cmbColor.Text
        dgv.Item(2, r).Value = txtWt.Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVE()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class