Imports System.Data.SqlClient

Public Class DepartmentProfile
    Public mode
    Public SeriesNo

    Sub disposeForm()
        chkboxInactiveDept.Checked = False
        txtDeptNo.Text = ""
        txtDept.Text = ""

    End Sub
    Sub generateDeptNo()
        Dim strID As String
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
                .CommandText = "SELECT departmentNo from tblDepartmentProfile order by departmentNo DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                strID = OleDBDR.Item(0)
                txtDeptNo.Text = Format(Val(strID) + 1, "00000")
            Else
                txtDeptNo.Text = "00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub insert_update_deparment()
        Dim status As String
        If chkboxInactiveDept.Checked = True Then
            status = "Inactive"
        Else
            status = "Active"
        End If
        Try
            Dim cmd As New SqlCommand("insert_update_department", conn)
            checkConn()
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@Mode", SqlDbType.Int).Value = btnSave.Text
                .Parameters.AddWithValue("@departmentNo", SqlDbType.VarChar).Value = txtDeptNo.Text
                .Parameters.AddWithValue("@department", SqlDbType.VarChar).Value = txtDept.Text
                .Parameters.AddWithValue("@sssAccount", SqlDbType.VarChar).Value = txtAccSSS.Text
                .Parameters.AddWithValue("@hdmfAccount", SqlDbType.VarChar).Value = txtAccHDMF.Text
                .Parameters.AddWithValue("@phAccount", SqlDbType.VarChar).Value = txtAccPH.Text
                .Parameters.AddWithValue("@taxAccount", SqlDbType.VarChar).Value = txtAccTax.Text
                .Parameters.AddWithValue("@costBenefitsAccount", SqlDbType.VarChar).Value = txtExpBenifits.Text
                .Parameters.AddWithValue("@costAccount", SqlDbType.VarChar).Value = txtLaborCostAcc.Text
                .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status
            End With
            cmd.ExecuteNonQuery()
            MsgBox("Department Saved !", MsgBoxStyle.Information, "Success")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub saveAccountSettings()
        Dim sysSettings As New systemSettings_class
        sysSettings.settingsName = Me.Text & "_SSSAcc"
        sysSettings.settingsValue = txtAccSSS.Text
        sysSettings.insert_update_settingsVariable()
        sysSettings.settingsName = Me.Text & "_HDMFAcc"
        sysSettings.settingsValue = txtAccHDMF.Text
        sysSettings.insert_update_settingsVariable()
        sysSettings.settingsName = Me.Text & "_PHAcc"
        sysSettings.settingsValue = txtAccPH.Text
        sysSettings.insert_update_settingsVariable()
        sysSettings.settingsName = Me.Text & "_TaxAcc"
        sysSettings.settingsValue = txtAccTax.Text
        sysSettings.settingsName = Me.Text & "_CostAcc"
        sysSettings.settingsValue = txtLaborCostAcc.Text
        sysSettings.insert_update_settingsVariable()
        sysSettings.settingsName = Me.Text & "_ExpBenifitsAcc"
        sysSettings.settingsValue = txtExpBenifits.Text
        sysSettings.insert_update_settingsVariable()
    End Sub

    Sub getAccountSettings()
        Dim sysSettings As New systemSettings_class
        sysSettings.settingsName = Me.Text & "_SSSAcc"
        sysSettings.settingsValue = txtAccSSS.Text
        sysSettings.get_settingsValue()
        txtAccSSS.Text = sysSettings.return_settingsValue
        sysSettings.settingsName = Me.Text & "_HDMFAcc"
        sysSettings.settingsValue = txtAccHDMF.Text
        sysSettings.get_settingsValue()
        txtAccHDMF.Text = sysSettings.return_settingsValue
        sysSettings.settingsName = Me.Text & "_PHAcc"
        sysSettings.settingsValue = txtAccPH.Text
        sysSettings.get_settingsValue()
        txtAccPH.Text = sysSettings.return_settingsValue
        sysSettings.settingsName = Me.Text & "_TaxAcc"
        sysSettings.settingsValue = txtAccTax.Text
        sysSettings.get_settingsValue()
        txtLaborCostAcc.Text = sysSettings.return_settingsValue
        sysSettings.settingsName = Me.Text & "_CostAcc"
        sysSettings.settingsValue = txtLaborCostAcc.Text
        sysSettings.get_settingsValue()
        txtLaborCostAcc.Text = sysSettings.return_settingsValue
        sysSettings.settingsName = Me.Text & "_ExpBenifitsAcc"
        sysSettings.settingsValue = txtExpBenifits.Text
        sysSettings.get_settingsValue()
        txtExpBenifits.Text = sysSettings.return_settingsValue
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "Are you Sure") = MsgBoxResult.Yes Then
                insert_update_deparment()
                saveAccountSettings()
                DepartmentList.get_department_List()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DepartmentProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If btnSave.Text = "Add" Then
            generateDeptNo()
            getAccountSettings()

        ElseIf mode = "Save" Then
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtAccSSS.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtAccHDMF.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtAccPH.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtExpBenifits.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtLaborCostAcc.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
        End If
    End Sub

    Private Sub txtAccSSS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccSSS.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccSSS.Text
        AC.get_accountInfo()
        lblAccSSS.Text = AC.accDesc
    End Sub

    Private Sub txtAccHDMF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccHDMF.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccHDMF.Text
        AC.get_accountInfo()
        lblAccHDMF.Text = AC.accDesc
    End Sub

    Private Sub txtAccPH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccPH.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccPH.Text
        AC.get_accountInfo()
        lblAccPH.Text = AC.accDesc
    End Sub

    Private Sub txtLaborCostAcc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLaborCostAcc.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtLaborCostAcc.Text
        AC.get_accountInfo()
        lblLaborCostAcc.Text = AC.accDesc
    End Sub
    Private Sub txtExpBenifits_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExpBenifits.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtExpBenifits.Text
        AC.get_accountInfo()
        lblExpBenifits.Text = AC.accDesc
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtAccTax.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
        End If
    End Sub

    Private Sub txtAccTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccTax.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccTax.Text
        AC.get_accountInfo()
        lblAccTax.Text = AC.accDesc
    End Sub
End Class