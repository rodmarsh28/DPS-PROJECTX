Imports System.Data.SqlClient

Public Class SSS_contribution_table
    Dim command As Integer
    Sub SAVE()
        Try
            Dim row1 As Integer
            Dim col As Integer
            col = 0
            row1 = dgv.RowCount
            While col < row1
                Dim cmd As New SqlCommand("save_sss_cont_table", conn)
                checkConn()
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.AddWithValue("@countx", SqlDbType.Int).Value = col
                    .Parameters.AddWithValue("@salaryF", SqlDbType.Decimal).Value = dgv.Item(0, col).Value
                    .Parameters.AddWithValue("@salaryT", SqlDbType.Decimal).Value = dgv.Item(1, col).Value
                    .Parameters.AddWithValue("@salary", SqlDbType.Decimal).Value = dgv.Item(2, col).Value
                    .Parameters.AddWithValue("@ER", SqlDbType.Decimal).Value = dgv.Item(3, col).Value
                    .Parameters.AddWithValue("@EE", SqlDbType.Decimal).Value = dgv.Item(4, col).Value
                    .Parameters.AddWithValue("@EC", SqlDbType.Decimal).Value = dgv.Item(5, col).Value
                    .Parameters.AddWithValue("@TOTAL", SqlDbType.Decimal).Value = dgv.Item(6, col).Value
                End With
                cmd.ExecuteNonQuery()
                col = col + 1
            End While
        Catch ex As Exception

        Finally
            MsgBox("SSS CONTRIBUTION SAVED !", MsgBoxStyle.Information, "SUCCESS")
            Me.Close()
        End Try
    End Sub
    Sub get_exst_table()
        Try
            Dim cmd = New SqlCommand("select salaryF,salaryT,salary,ER,EE,EC,TOTAL from tblSSS_cont_table", conn)
            Dim dr As SqlDataReader
            checkConn()
            dr = cmd.ExecuteReader
            Dim c As Integer = 0
            dgv.Rows.Clear()
            If dr.HasRows Then
                While dr.Read
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = dr.Item(0)
                    dgv.Item(1, c).Value = dr.Item(1)
                    dgv.Item(2, c).Value = dr.Item(2)
                    dgv.Item(3, c).Value = dr.Item(3)
                    dgv.Item(4, c).Value = dr.Item(4)
                    dgv.Item(5, c).Value = dr.Item(5)
                    dgv.Item(6, c).Value = dr.Item(6)
                    c = c + 1
                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub

    'select salaryF,salaryT,salary,ER,EE,EC,TOTAL from tblSSS_cont_table
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If MsgBox("Are You Sure ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SAVE()
        End If
    End Sub

    Private Sub SSS_contribution_table_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_exst_table()
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub dgv_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        Try
            For Each row As DataGridViewRow In dgv.Rows
                    row.Cells(6).Value = CDbl(row.Cells(3).Value) + CDbl(row.Cells(4).Value) + CDbl(row.Cells(5).Value)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValueChanged
       
    End Sub

    Private Sub dgv_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgv.EditingControlShowing
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If

    End Sub
End Class