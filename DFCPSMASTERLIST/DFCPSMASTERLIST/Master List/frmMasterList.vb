Public Class frmMasterList
    Public mode As String
    Public isOk As Boolean
    Sub viewEmployees()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblEmployeesInfo.employeeID,dbo.tblEmployeesInfo.lastname,dbo.tblEmployeesInfo.firstname," & _
                    "dbo.tblEmployeesInfo.middlename,dbo.tblEmployeesInfo.gender,dbo.tblEmployeesInfo.[position],dbo.tblEmployeesInfo.department," & _
                    "dbo.tblEmployeesInfo.division,dbo.tblEmployeesInfo.workingStatus FROM dbo.tblEmployeesInfo order by lastname asc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1) & ", " & OleDBDR.Item(2) & " " & OleDBDR.Item(3) & "."
                    dgw.Item(2, c).Value = OleDBDR.Item(4)
                    dgw.Item(3, c).Value = OleDBDR.Item(5)
                    dgw.Item(4, c).Value = OleDBDR.Item(6)
                    dgw.Item(5, c).Value = OleDBDR.Item(7)
                    dgw.Item(6, c).Value = OleDBDR.Item(8)
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub SearchEmployees()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblEmployeesInfo.employeeID,dbo.tblEmployeesInfo.lastname,dbo.tblEmployeesInfo.firstname," & _
                    "dbo.tblEmployeesInfo.middlename,dbo.tblEmployeesInfo.gender,dbo.tblEmployeesInfo.[position],dbo.tblEmployeesInfo.department," & _
                    "dbo.tblEmployeesInfo.division,dbo.tblEmployeesInfo.workingStatus FROM dbo.tblEmployeesInfo where employeeID like '%" & txtSearch.Text & "%' " & _
                    "or lastname like '%" & txtSearch.Text & "%' or firstname like '%" & txtSearch.Text & "%' or middlename like '%" & txtSearch.Text & "%' order by lastname asc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1) & ", " & OleDBDR.Item(2) & " " & OleDBDR.Item(3) & "."
                    dgw.Item(2, c).Value = OleDBDR.Item(4)
                    dgw.Item(3, c).Value = OleDBDR.Item(5)
                    dgw.Item(4, c).Value = OleDBDR.Item(6)
                    dgw.Item(5, c).Value = OleDBDR.Item(7)
                    dgw.Item(6, c).Value = OleDBDR.Item(8)
                    c = c + 1
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub viewDisciplinaryAction()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblDesciplinaryAction.descActionNo,dbo.tblDesciplinaryAction.[date],dbo.tblDesciplinaryAction.typeofViolation," & _
                    "dbo.tblDesciplinaryAction.actionTaken,dbo.tblDesciplinaryAction.punishDateFrom,dbo.tblDesciplinaryAction.punishDateTo FROM dbo.tblDesciplinaryAction " & _
                    "where employeeID ='" & dgw.CurrentRow.Cells(0).Value & "'"

            End With
            OleDBDR = OleDBC.ExecuteReader
            frmDesciplinaryActionViewer.dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    frmDesciplinaryActionViewer.dgv.Rows.Add()
                    frmDesciplinaryActionViewer.dgv.Item(0, c).Value = OleDBDR.Item(0)
                    frmDesciplinaryActionViewer.dgv.Item(1, c).Value = Format(OleDBDR.Item(1), ("MM/dd/yyyy"))
                    frmDesciplinaryActionViewer.dgv.Item(2, c).Value = OleDBDR.Item(2)
                    frmDesciplinaryActionViewer.dgv.Item(3, c).Value = OleDBDR.Item(3)
                    If OleDBDR.Item(4) = "01/01/1900" And OleDBDR.Item(5) = "01/01/1900" Then
                        frmDesciplinaryActionViewer.dgv.Item(4, c).Value = "None"
                        frmDesciplinaryActionViewer.dgv.Item(5, c).Value = "None"
                    Else
                        frmDesciplinaryActionViewer.dgv.Item(4, c).Value = Format(OleDBDR.Item(4), ("MM/dd/yyyy"))
                        frmDesciplinaryActionViewer.dgv.Item(5, c).Value = Format(OleDBDR.Item(5), ("MM/dd/yyyy"))
                    End If

                    frmDesciplinaryActionViewer.dgv.Item(6, c).Value = DateDiff(DateInterval.Day, OleDBDR.Item(4), OleDBDR.Item(5))
                    c = c + 1
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub updateEmployeesInfo()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT * FROM dbo.tblEmployeesInfo where employeeID = '" & dgw.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                If OleDBDR.Read Then
                    frmAddEmployees.txtemID.Text = OleDBDR.Item(0)
                    frmAddEmployees.txtln.Text = OleDBDR.Item(1)
                    frmAddEmployees.txtFn.Text = OleDBDR.Item(2)
                    frmAddEmployees.txtMn.Text = OleDBDR.Item(3)
                    frmAddEmployees.txtAdd.Text = OleDBDR.Item(4)
                    frmAddEmployees.txtCN.Text = OleDBDR.Item(5)
                    frmAddEmployees.txtHomeNo.Text = OleDBDR.Item(6)
                    frmAddEmployees.txtreligion.Text = OleDBDR.Item(7)
                    frmAddEmployees.txtGender.Text = OleDBDR.Item(8)
                    frmAddEmployees.txtBD.Value = OleDBDR.Item(9)
                    frmAddEmployees.txtCS.Text = OleDBDR.Item(10)
                    frmAddEmployees.txtDept.Text = OleDBDR.Item(11)
                    frmAddEmployees.txtDivision.Text = OleDBDR.Item(12)
                    frmAddEmployees.txtPos.Text = OleDBDR.Item(13)
                    frmAddEmployees.txtRate.Text = Format(OleDBDR.Item(14), "N")
                    frmAddEmployees.txtGradeLevel.Text = OleDBDR.Item(15)
                    frmAddEmployees.txtPM.Text = OleDBDR.Item(16)
                    frmAddEmployees.txtDH.Value = OleDBDR.Item(17)
                    frmAddEmployees.txtStatus.Text = OleDBDR.Item(18)
                    frmAddEmployees.txtField.Text = OleDBDR.Item(19)
                    frmAddEmployees.txtSSSNo.Text = OleDBDR.Item(20)
                    frmAddEmployees.txtTinNo.Text = OleDBDR.Item(21)
                    frmAddEmployees.txtPINo.Text = OleDBDR.Item(22)
                    frmAddEmployees.txtPHNo.Text = OleDBDR.Item(23)
                    If OleDBDR.Item(24) = "1-15" Then
                        frmAddEmployees.sssDedDate.SelectedIndex = 0
                    ElseIf OleDBDR.Item(24) = "16-30" Then
                        frmAddEmployees.sssDedDate.SelectedIndex = 1
                    End If
                    If OleDBDR.Item(25) = "1-15" Then
                        frmAddEmployees.tinDedDate.SelectedIndex = 0
                    ElseIf OleDBDR.Item(25) = "16-30" Then
                        frmAddEmployees.tinDedDate.SelectedIndex = 1
                    End If
                    If OleDBDR.Item(26) = "1-15" Then
                        frmAddEmployees.piDedDate.SelectedIndex = 0
                    ElseIf OleDBDR.Item(26) = "16-30" Then
                        frmAddEmployees.piDedDate.SelectedIndex = 1
                    End If
                    If OleDBDR.Item(27) = "1-15" Then
                        frmAddEmployees.phDedDate.SelectedIndex = 0
                    ElseIf OleDBDR.Item(27) = "16-30" Then
                        frmAddEmployees.phDedDate.SelectedIndex = 1
                    End If
                    frmAddEmployees.cmbDedB.Text = OleDBDR.Item(28)
                End If
                updateSpouseInfo()
                updateChildrenInfo()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub updateSpouseInfo()
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
                .CommandText = "SELECT * FROM dbo.tblSpouseInfo where employeeID = '" & dgw.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                If OleDBDR.Read Then
                    frmAddEmployees.txtSpouseLN.Text = OleDBDR.Item(2)
                    frmAddEmployees.txtSpouseFN.Text = OleDBDR.Item(3)
                    frmAddEmployees.txtSpouseMN.Text = OleDBDR.Item(4)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub updateChildrenInfo()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT * FROM dbo.tblChildrenInfo where employeeID = '" & dgw.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            frmAddEmployees.dgws.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    frmAddEmployees.dgws.Rows.Add()
                    frmAddEmployees.dgws.Item(0, c).Value = OleDBDR.Item(2)
                    frmAddEmployees.dgws.Item(1, c).Value = OleDBDR.Item(3)
                    frmAddEmployees.dgws.Item(2, c).Value = OleDBDR.Item(4)
                    c = c + 1
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub frmMasterList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewEmployees()
        dgw.ClearSelection()

    End Sub

    Private Sub ViewDiscplinaryActionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        viewDisciplinaryAction()
        frmDesciplinaryActionViewer.ShowDialog()
    End Sub

    Private Sub DesciplinaryActionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesciplinaryActionToolStripMenuItem.Click
        frmDescplinaryAction.txtEmp.Enabled = False
        frmDescplinaryAction.txtEmp.Text = dgw.CurrentRow.Cells(0).Value
        frmDescplinaryAction.ShowDialog()
    End Sub


    Private Sub dgw_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgw.CellMouseDoubleClick
        If mode = "Selection" Then
            isOk = True
            Me.Close()
        End If
    End Sub

    Private Sub dgw_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgw.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgw.CurrentCell = dgw(e.ColumnIndex, e.RowIndex)
                dgw.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgw.ContextMenuStrip = ContextMenuStrip2

    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub UpdateEmployeeInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateEmployeeInformationToolStripMenuItem.Click
        updateEmployeesInfo()
        frmAddEmployees.cmbAdd.Text = "Update"
        frmAddEmployees.ShowDialog()
    End Sub

    Private Sub FileALeaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileALeaveToolStripMenuItem.Click
        Dim frm As New frmFileLeave
        frm.txtEmployeeID.Enabled = False
        frm.txtEmployeeID.Text = dgw.CurrentRow.Cells(0).Value
        frm.ShowDialog()
    End Sub

    Private Sub ViewDesciplinaryActionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewDesciplinaryActionsToolStripMenuItem.Click
        Dim frm As New frmDesciplinaryActionViewer
        frm.empid = dgw.CurrentRow.Cells(0).Value
        frm.ShowDialog()
    End Sub



    Private Sub ViewFiledLeaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewFiledLeaveToolStripMenuItem.Click
        Dim frm As New frmEmpLeaveViewer
        frm.empid = dgw.CurrentRow.Cells(0).Value
        frm.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SearchEmployees()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click

    End Sub
End Class