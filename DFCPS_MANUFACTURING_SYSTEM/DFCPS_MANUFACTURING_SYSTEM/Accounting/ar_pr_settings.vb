Imports System.Data.SqlClient

Public Class ar_pr_settings

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmAccountList.mode = "Checkvoucher"
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            Dim r As Integer = dgvAP.Rows.Count
            dgvAP.Rows.Add()
            dgvAP.Item(0, r).Value = frmAccountList.dgv.CurrentRow.Cells(0).Value
            frmAccountList.successClick = False
            updateSettings()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmAccountList.mode = "Checkvoucher"
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            Dim r As Integer = dgvAR.Rows.Count
            dgvAR.Rows.Add()
            dgvAR.Item(0, r).Value = frmAccountList.dgv.CurrentRow.Cells(0).Value
            frmAccountList.successClick = False
            updateSettings()
        End If
    End Sub

    Sub updateSettings()
        Dim ac As New Accounting_class
        ac.DELETE_ARPRSettings()
        For Each row As DataGridViewRow In dgvAP.Rows
            ac.type = "AP"
            ac.accNo = row.Cells(0).Value
            ac.insert_ARPRSettings()
        Next
        For Each row As DataGridViewRow In dgvAR.Rows
            ac.type = "AR"
            ac.accNo = row.Cells(0).Value
            ac.insert_ARPRSettings()
        Next
    End Sub

    Private Sub dgvAP_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAP.CellValueChanged
        Dim ac As New Account_Class
        For Each row As DataGridViewRow In dgvAP.Rows
            ac.searchValue = row.Cells(0).Value
            ac.getaccountName()
            row.Cells(1).Value = ac.AccName
        Next
    End Sub

    Private Sub dgvAR_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAR.CellValueChanged
        Dim ac As New Account_Class
        For Each row As DataGridViewRow In dgvAR.Rows
            ac.searchValue = row.Cells(0).Value
            ac.getaccountName()
            row.Cells(1).Value = ac.AccName
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each row As DataGridViewRow In dgvAP.SelectedRows
            dgvAP.Rows.Remove(row)
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For Each row As DataGridViewRow In dgvAR.SelectedRows
            dgvAR.Rows.Remove(row)
        Next
    End Sub
    Sub GET_SETTINGS_AP()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select accNo from tblArPrSettings where TYPE = 'AP'", conn)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            dt.Rows.Clear()
            dgvAP.Rows.Clear()
            da.Fill(dt)
            Dim C As Integer = 0
            For Each ROW As DataRow In dt.Rows
                dgvAP.Rows.Add()
                dgvAP.Item(0, C).Value = ROW(0)
                C += 1
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub GET_SETTINGS_AR()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select accNo from tblArPrSettings where TYPE = 'AR'", conn)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            dt.Rows.Clear()
            dgvAR.Rows.Clear()
            da.Fill(dt)
            Dim C As Integer = 0
            For Each ROW As DataRow In dt.Rows
                dgvAR.Rows.Add()
                dgvAR.Item(0, C).Value = ROW(0)
                C += 1
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub ar_pr_settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GET_SETTINGS_AP()
        GET_SETTINGS_AR()
    End Sub
End Class