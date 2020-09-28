Public Class frmStockOut
    Sub clear()
        txtColor.Text = ""
        txtQty.Text = ""
    End Sub
    Sub disposeform()
        txtSalesNo.Text = ""
        TXTREMARKS.Text = ""
        txtWidth.Text = ""
        txtHeight.Text = ""
        dgv.Rows.Clear()
        clear()
    End Sub

    Private Sub frmStockOut_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        disposeform()
    End Sub
    Sub generateSTONo()
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
                .CommandText = "SELECT * from tblStockOut order by STONO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                txtSalesNo.Text = "STO-" & Format(Val(StrID) + 1, "00000")

            Else
                txtSalesNo.Text = "STO-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub


    Private Sub frmStockOut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button4.PerformClick()
        End If
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If txtQty.Text = "" Then
            txtQty.Text = "0.00"
        End If
        If txtWidth.Text = "" Or txtColor.Text = "" Or cmbSewnType.Text = "" Then
            Exit Sub
        End If
        Dim R As Integer = dgv.Rows.Count
        dgv.Rows.Add()
        dgv.Item(0, R).Value = txtWidth.Text
        dgv.Item(1, R).Value = txtHeight.Text
        dgv.Item(2, R).Value = txtColor.Text
        dgv.Item(3, R).Value = cmbSewnType.Text
        dgv.Item(4, R).Value = txtPrinted.Text
        dgv.Item(5, R).Value = txtQty.Text
        clear()
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
                    .CommandText = "INSERT INTO tblStockOut VALUES('" & txtSalesNo.Text & _
                        "','" & dtpDate.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & TXTREMARKS.Text & "')"
                    .ExecuteNonQuery()
                End With
                saveItem()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Stockout Saved !", MsgBoxStyle.Information, "Success")
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
                .CommandText = "INSERT INTO tblStockOutTR VALUES('" & txtSalesNo.Text & _
                        "','" & dgv.Item(0, col).Value & _
                        "','" & dgv.Item(1, col).Value & _
                        "','" & dgv.Item(2, col).Value & _
                        "','" & dgv.Item(3, col).Value & _
                        "','" & dgv.Item(4, col).Value & _
                        "','" & dgv.Item(5, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVE()
    End Sub

    Private Sub frmStockOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateSTONo()
    End Sub


    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        txtWidth.Text = dgv.CurrentRow.Cells(0).Value
        txtHeight.Text = dgv.CurrentRow.Cells(1).Value
        txtColor.Text = dgv.CurrentRow.Cells(2).Value
        cmbSewnType.Text = dgv.CurrentRow.Cells(3).Value
        txtPrinted.Text = dgv.CurrentRow.Cells(4).Value
        txtQty.Text = dgv.CurrentRow.Cells(5).Value
        For Each row As DataGridViewRow In dgv.SelectedRows
            dgv.Rows.Remove(row)
        Next
    End Sub
End Class