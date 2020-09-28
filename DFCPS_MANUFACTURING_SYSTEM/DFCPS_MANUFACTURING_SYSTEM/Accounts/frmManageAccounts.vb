Public Class frmManageAccounts
    Sub clearDesc()
        txtHeader.Text = ""
        txtSubHeader.Text = ""
        txtDept.Text = ""
        txtAccount.Text = ""
        txtBalance.Text = ""
        textboxWatermarksPatternLostFocus()
    End Sub
    Sub textboxWatermarksPatternLostFocus()
        If txtHeader.Text = "" Then
            txtHeader.Text = "   Header Name ..."
            txtHeader.ForeColor = Color.Silver
        End If
        If txtSubHeader.Text = "" Then
            txtSubHeader.Text = "   Sub Header Name ..."
            txtSubHeader.ForeColor = Color.Silver
        End If
        If txtDept.Text = "" Then
            txtDept.Text = "   Department Name ..."
            txtDept.ForeColor = Color.Silver
        End If
        If txtAccount.Text = "" Then
            txtAccount.Text = "   Account Name ..."
            txtAccount.ForeColor = Color.Silver
        End If
        If txtBalance.Text = "" Then
            txtBalance.Text = "   Account Balance ..."
            txtBalance.ForeColor = Color.Silver
        End If
    End Sub
    Private Sub frmManageAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getMaxHeaderNo()
        textboxWatermarksPatternLostFocus()
        txtAccount.Enabled = False
        txtBalance.Enabled = False
        Button2.Enabled = False
        txtDept.Enabled = False
        Button4.Enabled = False
        txtSubHeader.Enabled = False
        Button3.Enabled = False
        dgvSubHeader.Rows.Clear()
        dgvDept.Rows.Clear()
        dgvAccount.Rows.Clear()
    End Sub
    Sub getMaxHeaderNo()
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
                .CommandText = "SELECT isnull(max(accHeaderNo),0)+1 from tblAccHeader "
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                txtHeaderNo.Text = OleDBDR.Item(0)
            End If
            showHeaderList()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub showHeaderList()
        Try
            Dim c As Integer = 0
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT accHeaderNo,accHeader from tblAccHeader "
            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvHeader.Rows.Clear()
            While OleDBDR.Read
                dgvHeader.Rows.Add()
                dgvHeader.Item(0, c).Value = OleDBDR.Item(0)
                dgvHeader.Item(1, c).Value = OleDBDR.Item(1)
                c += 1
            End While
            dgvHeader.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub showsUBHeaderList()
        Try
            Dim c As Integer = 0
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT accsUBHeaderNo,SUBHeader " & _
                    "from tblAccSUBHeader " & _
                    "INNER JOIN dbo.tblAccHeader ON dbo.tblAccHeader.accHeaderNo = dbo.tblAccSubHeader.accHeaderNo " & _
                    "where tblAccSubHeader.accHeaderNo = '" & dgvHeader.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvSubHeader.Rows.Clear()
            While OleDBDR.Read
                dgvSubHeader.Rows.Add()
                dgvSubHeader.Item(0, c).Value = OleDBDR.Item(0)
                dgvSubHeader.Item(1, c).Value = OleDBDR.Item(1)
                c += 1
            End While
            dgvSubHeader.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub showDeptList()
        Try
            Dim c As Integer = 0
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT accDepartmentNo,accDepartment " & _
                    "from tblAccDepartment " & _
                    "INNER JOIN dbo.tblAccSubHeader ON dbo.tblAccSubHeader.accSubheaderNo = dbo.tblAccDepartment.accSubHeaderNo " & _
                    "where tblaccDepartment.accSubHeaderNo = '" & dgvSubHeader.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvDept.Rows.Clear()
            While OleDBDR.Read
                dgvDept.Rows.Add()
                dgvDept.Item(0, c).Value = OleDBDR.Item(0)
                dgvDept.Item(1, c).Value = OleDBDR.Item(1)
                c += 1
            End While
            dgvDept.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub showAccountList()
        Try
            Dim c As Integer = 0
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT accNo,accountName,balance " & _
                    "from tblCOA " & _
                    "INNER JOIN dbo.tblAccDepartment ON dbo.tblAccDepartment.accDepartmentNo = dbo.tblCOA.accDepartmentNo " & _
                    "where tblCOA.accDepartmentNo = '" & dgvDept.CurrentRow.Cells(0).Value & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvAccount.Rows.Clear()
            While OleDBDR.Read
                dgvAccount.Rows.Add()
                dgvAccount.Item(0, c).Value = OleDBDR.Item(0)
                dgvAccount.Item(1, c).Value = OleDBDR.Item(1)
                dgvAccount.Item(2, c).Value = OleDBDR.Item(2)
                c += 1
            End While
            dgvAccount.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub saveAccountHeader()
        If MsgBox("ARE YOU SURE YOU WANT TO ADD ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = "INSERT INTO tblAccHeader VALUES('" & txtHeaderNo.Text & "','" & txtHeader.Text & "')"
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("ACCOUNT HEADER ADDED !", MsgBoxStyle.Information, "SUCCESS")
                clearDesc()
                showHeaderList()
            End Try
        End If
    End Sub
    Sub saveAccountSubHeader()
        If MsgBox("ARE YOU SURE YOU WANT TO ADD ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = "INSERT INTO tblAccSubHeader VALUES('" & txtSubheaderNo.Text & "','" & dgvHeader.CurrentRow.Cells(0).Value & "','" & txtSubHeader.Text & "')"
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("ACCOUNT SUB HEADER ADDED !", MsgBoxStyle.Information, "SUCCESS")
                clearDesc()
                showsUBHeaderList()
            End Try
        End If
    End Sub
    Sub saveAccountDepartment()
        If MsgBox("ARE YOU SURE YOU WANT TO ADD ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = "INSERT INTO tblAccDepartment VALUES('" & txtDeptNo.Text & "','" & dgvSubHeader.CurrentRow.Cells(0).Value & "','" & txtDept.Text & "')"
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("ACCOUNT DEPARTMENT ADDED !", MsgBoxStyle.Information, "SUCCESS")
                clearDesc()
                showDeptList()
            End Try
        End If
    End Sub
    Sub saveAccount()
        If MsgBox("ARE YOU SURE YOU WANT TO ADD ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = "INSERT INTO tblCOA VALUES('" & txtAccountNo.Text & "','" & dgvDept.CurrentRow.Cells(0).Value & "','" & txtAccount.Text & "','" & CDbl(txtBalance.Text) & "')"
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("ACCOUNT ADDED !", MsgBoxStyle.Information, "SUCCESS")
                clearDesc()
                showAccountList()
            End Try
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtHeader.Text = "" Or txtHeader.Text = "   Header Name ..." Then
            Exit Sub
        End If
        saveAccountHeader()
        getMaxHeaderNo()
    End Sub

    Private Sub dgvHeader_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvHeader.CellMouseClick
        txtSubheaderNo.Text = dgvHeader.CurrentRow.Cells(0).Value & "-000"
        showsUBHeaderList()
        dgvAccount.Rows.Clear()
        txtAccount.Enabled = False
        txtBalance.Enabled = False
        Button2.Enabled = False
        dgvDept.Rows.Clear()
        txtDept.Enabled = False
        Button4.Enabled = False
        txtSubHeader.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtSubHeader.Text = "" Or txtSubHeader.Text = "   Sub Header Name ..." Then
            Exit Sub
        End If
        saveAccountSubHeader()
    End Sub

    Private Sub dgvSubHeader_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSubHeader.CellMouseClick
        txtDeptNo.Text = dgvSubHeader.CurrentRow.Cells(0).Value & "-000"
        showDeptList()
        dgvAccount.Rows.Clear()
        txtAccount.Enabled = False
        txtBalance.Enabled = False
        Button2.Enabled = False
        txtDept.Enabled = True
        Button4.Enabled = True
        txtSubHeader.Enabled = True
        Button3.Enabled = True
    End Sub
    Private Sub dgvDept_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDept.CellMouseClick
        txtAccountNo.Text = dgvDept.CurrentRow.Cells(0).Value & "-0000"
        showAccountList()
        txtAccount.Enabled = True
        txtBalance.Enabled = True
        Button2.Enabled = True
        txtDept.Enabled = True
        Button4.Enabled = True
        txtSubHeader.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If txtDept.Text = "" Or txtDept.Text = "   Department Name ..." Then
            Exit Sub
        End If
        saveAccountDepartment()
    End Sub

 

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBalance.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If
    End Sub

    Private Sub txtHeader_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHeader.Click
        If txtHeader.Text = "   Header Name ..." Then
            txtHeader.Text = ""
            txtHeader.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtsubHeader_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubHeader.click
        If txtSubHeader.Text = "   Sub Header Name ..." Then
            txtSubHeader.Text = ""
            txtSubHeader.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtDept_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDept.Click
        If txtDept.Text = "   Department Name ..." Then
            txtDept.Text = ""
            txtDept.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtAccount_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccount.Click
        If txtAccount.Text = "   Account Name ..." Then
            txtAccount.Text = ""
            txtAccount.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtBalance_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBalance.Click
        If txtBalance.Text = "   Account Balance ..." Then
            txtBalance.Text = ""
            txtBalance.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtHeader_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHeader.LostFocus
        textboxWatermarksPatternLostFocus()
    End Sub
    Private Sub txtsubHeader_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubHeader.LostFocus
        textboxWatermarksPatternLostFocus()
    End Sub
    Private Sub txtDept_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDept.LostFocus
        textboxWatermarksPatternLostFocus()
    End Sub
    Private Sub txtAccount_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccount.LostFocus
        textboxWatermarksPatternLostFocus()
    End Sub
    Private Sub txtBalance_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBalance.LostFocus
        textboxWatermarksPatternLostFocus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtAccount.Text = "" Or txtBalance.Text = "" Or txtAccount.Text = "   Account Name ..." Or txtBalance.Text = "   Account Balance ..." Then
            Exit Sub
        End If
        saveAccount()
    End Sub

    Private Sub dgvDept_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDept.CellContentClick

    End Sub

    Private Sub txtHeader_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeader.TextChanged

    End Sub
End Class