Public Class frmGLreportViewer
    Dim searchListValue As String = ""
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            DGV.Rows.Add(frmAccountList.dgv.CurrentRow.Cells(0).Value)
            frmAccountList.successClick = False
            getAccName()
        End If
    End Sub
    Sub getAccName()
        Dim ac As New Account_Class
        For Each row As DataGridViewRow In dgv.Rows
            ac.searchValue = row.Cells(0).Value
            ac.getaccountName()
            row.Cells(1).Value = ac.AccName
        Next
    End Sub

    Sub mergelist()
        Dim ac As New Accounting_class
        For Each row As DataGridViewRow In DGV.Rows
            ac.accNo = row.Cells(0).Value
            ac.addtoTempAccnoList()
        Next
    End Sub
    Sub PRINT_GL()
        If cmbSearchType.Text <> "All Accounts" Then
            mergelist()
        End If
        Dim AC As New Accounting_class
        AC.DFROM = dtpfrom.Value.ToString("dd/MM/yyyy")
        AC.DTO = dtpTo.Value.ToString("dd/MM/yyyy")
        AC.SEARCHTYPE = cmbSearchType.Text
        AC.PRINT_GENERAL_LEDGER()
        AC.deleteTemp()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        For Each row As DataGridViewRow In DGV.SelectedRows
            DGV.Rows.Remove(row)
        Next
    End Sub

    Private Sub DGV_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellValueChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        mergelist()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If cmbSearchType.SelectedIndex = -1 Then
            MsgBox("Please Select Search Method", MsgBoxStyle.Critical, "Failed")
            Exit Sub
        End If
        PRINT_GL()
    End Sub

    Private Sub cmbSearchType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchType.SelectedIndexChanged
        If cmbSearchType.Text = "All Accounts" Then
            DGV.Enabled = False
            btnAdd.Enabled = False
            btnDel.Enabled = False
        Else
            DGV.Enabled = True
            btnAdd.Enabled = True
            btnDel.Enabled = True
        End If
    End Sub
End Class