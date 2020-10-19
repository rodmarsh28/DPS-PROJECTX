Public Class frmFileLeave
    Dim leavetypeTable As New DataTable
    Dim ltID As Integer
    Dim ltCredit As Integer
    Sub clear()
        txtLFN.Text = ""
        txtEmployeeID.Text = ""
        txtName.Text = ""
        txtPos.Text = ""
        txtDept.Text = ""
        txtDivision.Text = ""
        cmbLeaveType.Text = ""
        dtpFrom.Value = Now
        dtpTo.Value = Now
        txtNoOfDays.Text = ""
        cmbWithpay.Text = ""
        txtReason.Text = ""

    End Sub
    Sub generateLeaveFileNo()
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
                .CommandText = "SELECT * from tblLeave order by LeaveNo DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 7, Len(OleDBDR(0)))
                txtLFN.Text = "LFN-" & Format(Val(StrID) + 1, "00000")
            Else
                txtLFN.Text = "LFN-00001"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub save()
        If MsgBox("ARE YOU SURE?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = "INSERT INTO tblLeave VALUES('" & txtLFN.Text & _
                        "','" & dtpDateFilled.Value.ToString("MM/dd/yyyy") & _
                        "','" & txtEmployeeID.Text & _
                        "','" & ltID & _
                        "','" & txtReason.Text & _
                        "','" & dtpFrom.Value.ToString("MM/dd/yyyy") & _
                        "','" & dtpTo.Value.ToString("MM/dd/yyyy") & _
                        "','" & txtNoOfDays.Text & _
                        "','" & cmbWithpay.Text & "','Date Filed " & Now & "')"
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Employee Requested Leave Filed !", MsgBoxStyle.Information, "SUCCESS")
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If CDec(txtNoOfDays.Text) > CDec(lblCredit.Text) And cmbWithpay.Text = "Yes" Then
            MsgBox("You don't have enough leave credit withpay to proceed", MsgBoxStyle.Critical, "System Reminders")
            Exit Sub
        End If
        save()
    End Sub

    Private Sub frmFileLeave_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        clear()
    End Sub

    Private Sub frmFileLeave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateLeaveFileNo()
        cmbWithpay.SelectedIndex = 0
        'dtpFrom.Value = dtpFrom.Value.AddDays(1)
        'dtpTo.Value = dtpTo.Value.AddDays(1)
        'dtpFrom.Value = dtpFrom.Value.AddDays(-1)
        'dtpTo.Value = dtpTo.Value.AddDays(-1)
    End Sub

    Private Sub dtpFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFrom.LostFocus
        Dim datefrom As DateTime = Convert.ToDateTime(dtpFrom.Text)
        Dim dateto As DateTime = Convert.ToDateTime(dtpTo.Text)
        Dim ts As TimeSpan = dateto.Subtract(datefrom)
        If Convert.ToInt32(ts.Days) >= 0 Then
            txtNoOfDays.Text = Convert.ToInt32(ts.Days) + 1
        Else
            txtNoOfDays.Text = "0"
        End If
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged


    End Sub

    Private Sub dtpTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpTo.LostFocus
        Dim datefrom As DateTime = Convert.ToDateTime(dtpFrom.Text)
        Dim dateto As DateTime = Convert.ToDateTime(dtpTo.Text)
        Dim ts As TimeSpan = dateto.Subtract(datefrom)
        If Convert.ToInt32(ts.Days) >= 0 Then
            txtNoOfDays.Text = Convert.ToInt32(ts.Days) + 1
        Else
            txtNoOfDays.Text = "0"
        End If
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        'txtNoOfDays.Text = dtpTo.Value.Day - dtpFrom.Value.Day + 1
        'If txtNoOfDays.Text <= 0 Then
        '    txtNoOfDays.Text = "0"
        'End If

    End Sub

    Private Sub txtReason_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReason.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub txtEmployeeID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmployeeID.TextChanged
        Try
            Dim pc As New payroll_class
            pc.empid = txtEmployeeID.Text
            pc.get_employees_info()
            txtName.Text = pc.dtable.Rows(0).Item("Name").ToString
            txtDept.Text = pc.dtable.Rows(0).Item("department").ToString
            txtDivision.Text = pc.dtable.Rows(0).Item("division").ToString
            txtPos.Text = pc.dtable.Rows(0).Item("position").ToString
        Catch ex As Exception

        End Try
    End Sub
    Sub get_leave_type()
        Dim mc As New master_class
        mc.get_lt_list()
        For Each col As DataColumn In mc.dtable.Columns
            leavetypeTable.Columns.Add(col)
        Next
        For Each row As DataRow In mc.dtable.Rows
            leavetypeTable.Rows.Add(row(0), row(1), row(2))
        Next
    End Sub
    'Sub leavetype_combo()
    '    lblLabelCredit.Text = cmbLeaveType.Text
    'End Sub
   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim frm As New frmMasterList
            frm.mode = "Selection"
            frm.ShowDialog()
            If frm.isOk = True Then
                txtEmployeeID.Text = frm.dgw.CurrentRow.Cells(0).Value
                frm.isOk = False
            End If
            Dim mc As New master_class
            mc.command = ""
            mc.searchValue = txtEmployeeID.Text
            mc.get_emp_info()
            txtName.Text = mc.dtable.Rows(0).Item("lastname").ToString & ", " & mc.dtable.Rows(0).Item("firstname").ToString & " " & mc.dtable.Rows(0).Item("middlename").ToString
            txtPos.Text = mc.dtable.Rows(0).Item("position").ToString
            txtDept.Text = mc.dtable.Rows(0).Item("department").ToString
            txtDivision.Text = mc.dtable.Rows(0).Item("division").ToString

        Catch ex As Exception
        End Try

    End Sub
    'Sub get_remaining_leave()
    '    Dim mc As New master_class
    '    mc.command = ""
    '    mc.searchValue = txtEmployeeID.Text
    '    mc.dateTo = dtpTo.Value
    '    mc.leaveType = ltID
    '    mc.get_withpay_leave_credit()
    '    If mc.dtable.Rows.Count <> 0 Then
    '        lblSIL.Text = mc.dtable.Rows(0).Item("totalDays").ToString
    '    Else
    '        lblSIL.Text = "5"
    '    End If
    'End Sub

    'Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    'End Sub
    'Sub get_leaveType_credit()
    '    Dim mc As New master_class

    'End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmLeaveTypeSelection
        frm.empid = txtEmployeeID.Text
        frm.command = ""
        frm.dates = dtpTo.Value
        frm.get_withpay_leave_credit()
        frm.ShowDialog()
        If frm.isOK = True Then
            ltID = frm.dgv.CurrentRow.Cells(0).Value
            cmbLeaveType.Text = frm.dgv.CurrentRow.Cells(1).Value
            lblLeaveCredit.Text = frm.dgv.CurrentRow.Cells(1).Value & " Remaining Credit : "
            lblCredit.Text = CDec(frm.dgv.CurrentRow.Cells(4).Value)
        End If
    End Sub
End Class