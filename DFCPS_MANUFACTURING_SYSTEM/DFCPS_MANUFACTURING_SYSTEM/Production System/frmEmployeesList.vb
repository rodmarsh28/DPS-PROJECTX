Public Class frmEmployeesList
    Public FORMSTATUS As String
    Sub EmployeesList()
        Dim c As Integer = 0
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
                .CommandText = "SELECT employeeID,lastname + ', ' + firstname + ' ' + middlename, position from get_employees_list where employeeID LIKE '%" & txtSearch.Text & "%' " & _
                    " and Department = 'LOOMS' OR lastname LIKE '%" & txtSearch.Text & "%' and Department = 'LOOMS' order by employeeID "

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = OleDBDR.Item(0)
                    dgv.Item(1, c).Value = OleDBDR.Item(1)
                    dgv.Item(2, c).Value = OleDBDR.Item(2)
                    c = c + 1

                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub frmEmployeesList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        If FORMSTATUS = "CLS" Then
            frmCircularLoomsSec.biono = dgv.CurrentRow.Cells(0).Value
            frmCircularLoomsSec.txtOperator.Text = dgv.CurrentRow.Cells(1).Value
            'ElseIf FORMSTATUS = "ATT" Then
            '    frmAddAttendance.txtBioNo.Text = dgv.CurrentRow.Cells(0).Value
            '    frmAddAttendance.txtName.Text = dgv.CurrentRow.Cells(1).Value
            '    frmAddAttendance.txtPos.Text = dgv.CurrentRow.Cells(2).Value
            'ElseIf FORMSTATUS = "BT" Then
            '    DailyBreaktime.txtBioNo.Text = dgv.CurrentRow.Cells(0).Value
            '    DailyBreaktime.txtName.Text = dgv.CurrentRow.Cells(1).Value
            '    DailyBreaktime.txtPos.Text = dgv.CurrentRow.Cells(2).Value
        End If
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        EmployeesList()
    End Sub
End Class