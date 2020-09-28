Public Class frmDailyTimeRecording
    Public mode As String
    Private Sub frmDailyTimeRecording_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_active_emp()
        If mode = "Update" Then
            Exit Sub
        End If
        generateRecordNo()
    End Sub
    Sub generateRecordNo()
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
                .CommandText = "SELECT * from tblDTRrecord order by dtrRecordNo DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                Dim no As Integer
                no = CDec(OleDBDR.Item(0)) + 1
                lblRecordNo.Text = no
            Else
                lblRecordNo.Text = "1"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub insert_dtr_record()
        Dim mc As New master_class
        mc.loopcount = 0
        mc.transNo = lblRecordNo.Text
        mc.datetrans = dtpDate.Value
        mc.delete_exst_dtrRecord()
        mc.remarks = txtRemarks.Text
        For Each row As DataGridViewRow In dgv.Rows
            mc.loopcount += 1
            mc.empID = row.Cells(0).Value
            mc.wH = row.Cells(2).Value
            mc.aH = row.Cells(3).Value
            mc.rhC = row.Cells(4).Value
            mc.nwhC = row.Cells(5).Value
            mc.rhH = row.Cells(6).Value
            mc.nwhH = row.Cells(7).Value
            mc.otH = row.Cells(8).Value
            mc.otnH = row.Cells(9).Value
            mc.rdrH = row.Cells(10).Value
            mc.latemins = row.Cells(11).Value
            mc.insert_dtr_record()
        Next
    End Sub
    Sub get_active_emp()
        Try
            Dim mc As New master_class
            Dim hc As New HRIS_class
            If mode = "Update" Then
                mc.command = "1"
                dtpDate.Enabled = False
            Else
                mc.command = "0"
                dtpDate.Enabled = True
            End If
            mc.datetrans = dtpDate.Value
            mc.get_active_emp()
            dgv.Rows.Clear()
            For Each row As DataRow In mc.dtable.Rows
                Dim laborcost = hc.get_labor_cost(row(0), row("crh"), row("clatem"), CDec(row("coth")) + CDec(row("cotNonh")), row("crdr"), row("crhr"), row("cnwhr"))
                Dim deptID = mc.get_dept_id(row("empid"))
                lblRecordNo.Text = row(13)
                With hc.get_dept_acc(deptID)
                    dgv.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), row(10), row(11), hc.get_dept_acc(deptID), .sssPayAcc, .piPayAcc, .phPayAcc, .taxAcc, .indirectAcc, .directAcc, laborcost.Item1, laborcost.Item2)
                    txtRemarks.Text = row(12)
                End With
            Next
            If mode <> "Update" Then
                generateRecordNo()
            End If
            lblcount.Text = dgv.Rows.Count
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            Try
                insert_dtr_record()
                MsgBox("Transaction Recorded Successfully", MsgBoxStyle.Information, "System Information")
                If mode = "Update" Then
                    Me.Close()
                Else
                    get_active_emp()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim frm As New frmEmployeeName
        frm.mode = "Attendance"
        For Each row As DataGridViewRow In dgv.Rows
            frm.EmployeeIDss.Items.Add(row.Cells(0).Value)
            frm.combocount = dgv.Rows.Count
        Next
        frm.showEmployee()
        frm.ShowDialog()
        If frm.successClicked = True Then
            dgv.Rows.Add(frm.dgw.CurrentRow.Cells(0).Value, frm.dgw.CurrentRow.Cells(1).Value, "0", "0", "0", "0", "0", "0", "0", "0", "0")
            frm.successClicked = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each row As DataGridViewRow In dgv.SelectedRows
            dgv.Rows.Remove(row)
        Next
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub


    Private Sub dgv_CellValuePushed(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles dgv.CellValuePushed
        Try
            Dim hc As New HRIS_class
            For Each row As DataGridViewRow In dgv.Rows
                row.Cells(21).Value = hc.get_labor_cost(row.Cells(0).Value, row.Cells(2).Value, _
                                                        row.Cells(11).Value, CDec(row.Cells(8).Value + row.Cells(9).Value), _
                                                        row.Cells(10).Value, row.Cells(6).Value, row.Cells(7).Value)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        lblcount.Text = dgv.Rows.Count
    End Sub
    Private Sub dgv_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        lblcount.Text = dgv.Rows.Count
    End Sub
    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        get_active_emp()
    End Sub
End Class