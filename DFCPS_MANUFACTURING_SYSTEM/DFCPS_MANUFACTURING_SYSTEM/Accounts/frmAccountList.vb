Public Class frmAccountList
    Public mode As String
    Public successClick As Boolean
    Sub showAccountList()
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
                .CommandText = "SELECT dbo.tblCOA.accNo, " & _
                "dbo.tblAccHeader.accHeader, " & _
                "dbo.tblAccSubHeader.subHeader, " & _
                "dbo.tblAccDepartment.accDepartment, " & _
                "dbo.tblCOA.accountName " & _
                "FROM dbo.tblAccHeader " & _
                "INNER JOIN dbo.tblAccSubHeader ON dbo.tblAccHeader.accHeaderNo = dbo.tblAccSubHeader.accHeaderno " & _
                "INNER JOIN dbo.tblAccDepartment ON dbo.tblAccSubHeader.accSubHeaderNo = dbo.tblAccDepartment.accSubHeaderNo " & _
                "INNER JOIN dbo.tblCOA ON dbo.tblAccDepartment.AccDepartmentNo = dbo.tblCOA.accDepartmentNo " & _
                "where tblCOA.accNo like '%" & txtSearch.Text & "%' or  tblAccHeader.accHeader like '%" & txtSearch.Text & "%' or tblAccSubHeader.subHeader like '%" & txtSearch.Text & "%' " & _
                "or tblAccDepartment.accDepartment like '%" & txtSearch.Text & "%' or tblCOA.accountName like '%" & txtSearch.Text & "%'"


            End With
            OleDBDR = OleDBC.ExecuteReader
            dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = OleDBDR.Item(0)
                    dgv.Item(1, c).Value = OleDBDR.Item(1) & " " & OleDBDR.Item(2) & " " & OleDBDR.Item(3) & " " & OleDBDR.Item(4)
                    dgv.Item(2, c).Value = OleDBDR.Item(4)
                    c = c + 1

                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub frmAccountList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showAccountList()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        showAccountList()
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim sysSettings As New systemSettings_class
        If mode = "InventoryCost" Then
            frmAddItemsInventory.txtAccCost.Text = dgv.CurrentRow.Cells(0).Value
            sysSettings.settingsName = frmAddItemsInventory.Text & "_CostAcc"
            sysSettings.settingsValue = frmAddItemsInventory.txtAccCost.Text
            sysSettings.insert_update_settingsVariable()
        ElseIf mode = "InventoryIncome" Then
            frmAddItemsInventory.txtAccIncome.Text = dgv.CurrentRow.Cells(0).Value
            sysSettings.settingsName = frmAddItemsInventory.Text & "_IncomeAcc"
            sysSettings.settingsValue = frmAddItemsInventory.txtAccIncome.Text
            sysSettings.insert_update_settingsVariable()
        ElseIf mode = "InventoryAsset" Then
            frmAddItemsInventory.txtAccAsset.Text = dgv.CurrentRow.Cells(0).Value
            sysSettings.settingsName = frmAddItemsInventory.Text & "_AssetAcc"
            sysSettings.settingsValue = frmAddItemsInventory.txtAccAsset.Text
            sysSettings.insert_update_settingsVariable()

            'ElseIf mode = "SalesDeposit" Then
            '    frmPOPaymentType.txtDepositAcc.Text = dgv.CurrentRow.Cells(0).Value
            '    sysSettings.settingsName = frmPOPaymentType.Text & "_DepositACC"
            '    sysSettings.settingsValue = frmPOPaymentType.txtDepositAcc.Text
            '    sysSettings.insert_update_settingsVariable()

            'ElseIf mode = "ReceivedPayments" Then
            '    prepare_job.txtDepositAcc.Text = dgv.CurrentRow.Cells(0).Value
            '    sysSettings.settingsName = prepare_job.Text & "_DepositACC"
            '    sysSettings.settingsValue = prepare_job.txtDepositAcc.Text
            '    sysSettings.insert_update_settingsVariable()
        Else
            Me.Close()
        End If
        successClick = True
        Me.Close()
    End Sub
End Class