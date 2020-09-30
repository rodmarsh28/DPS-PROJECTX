Public Class frmAddItemsInventory
    Public mode As String
    Public SeriesNo As String
    Sub ItemType()
        If cmbItemType.Text = "Raw Materials" Then
            SeriesNo = "RM-"
        ElseIf cmbItemType.Text = "Finish Product" Then
            SeriesNo = "WP-"
        ElseIf cmbItemType.Text = "Item, Materials & Supplies" Then
            SeriesNo = "IM-"
        End If
    End Sub
    Sub generateItemNo()
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
                .CommandText = "SELECT ITEMNO from tblInvtry  where ITEMNO LIKE '" & SeriesNo & "%' order by ITEMNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                strID = OleDBDR.Item(0).Substring(OleDBDR.Item(0).Length - 5)
                txtItemno.Text = SeriesNo & Format(Val(strID) + 1, "00000")
            Else
                txtItemno.Text = SeriesNo & "00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub disposeform()
        txtItemno.Text = ""
        txtItemdesc.Text = ""
        txtAccCost.Text = ""
        txtAccIncome.Text = ""
        txtAccAsset.Text = ""
        txtUnitprice.Text = ""
        txtUnitCost.Text = "0.00"
        txtUnitPrice.Text = "0.00"
        chkBuy.Checked = False
        chkSell.Checked = False
        chkInv.Checked = False
        chkboxInactive.Checked = False
        dgv.Rows.Clear()
        cmbItemType.SelectedIndex = -1
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmAccountList.mode = "InventoryCost"
        frmAccountList.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmAccountList.mode = "InventoryIncome"
        frmAccountList.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmAccountList.mode = "InventoryAsset"
        frmAccountList.ShowDialog()
    End Sub

    Sub SAVE()

        If dgv.Rows.Count < 1 Then
            MsgBox("You have no unit entered. please retry", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If MsgBox("ARE YOU SURE YOU WANT TO SAVE ITEM ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Try

                Dim defbalQTY As Integer
                Dim inventoryClass As New inventory_class
                Dim pCount As Integer = 0
                For Each r As DataGridViewRow In dgv.Rows
                    inventoryClass.pCount = pCount
                    If r.Cells(3).Value = 1 Then
                        defbalQTY = CInt(r.Cells(1).Value)
                    End If

                    If chkBuy.Checked = True Then
                        inventoryClass.buy = "1"
                    Else
                        inventoryClass.buy = "0"
                    End If
                    If chkSell.Checked = True Then
                        inventoryClass.sell = "1"
                    Else
                        inventoryClass.sell = "0"
                    End If
                    If chkInv.Checked = True Then
                        inventoryClass.inv = "1"
                    Else
                        inventoryClass.inv = "0"
                    End If
                    If chkboxInactive.Checked = True Then
                        inventoryClass.status = "INACTIVE"
                    Else
                        inventoryClass.status = "ACTIVE"
                    End If

                    If btnAdd.Text = "Save Item" Then
                        inventoryClass.command = "Update"
                    ElseIf btnAdd.Text = "Add Item" Then
                        inventoryClass.command = "Add"
                    End If
                    inventoryClass.refNo = "BALANCE"
                    inventoryClass.itemNo = txtItemno.Text
                    inventoryClass.itemdesc = txtItemdesc.Text
                    inventoryClass.unitCost = txtUnitCost.Text
                    inventoryClass.unit = r.Cells(0).Value
                    inventoryClass.unitprice = txtUnitPrice.Text
                    inventoryClass.accCost = txtAccCost.Text
                    inventoryClass.accIncome = txtAccIncome.Text
                    inventoryClass.accAsset = txtAccAsset.Text
                    inventoryClass.minStock = r.Cells(2).Value
                    inventoryClass.balanceQty = r.Cells(1).Value
                    inventoryClass.isDefault = r.Cells(3).Value
                    inventoryClass.src = Me.Text
                    inventoryClass.insert_update_inventory_class()
                    pCount += 1
                Next
                inventoryClass.memo = "BEGINNING BALANCE"
                inventoryClass.debit = CDbl(txtUnitCost.Text) * CInt(defbalQTY)
                inventoryClass.credit = 0
                inventoryClass.insert_Acc_entry_class()
                saveAccountSettings()
                Me.Close()
                MsgBox("Item Saved !", MsgBoxStyle.Information, "Success")
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub saveAccountSettings()
        Dim sysSettings As New systemSettings_class
        sysSettings.settingsName = Me.Text & "_CostAcc"
        sysSettings.settingsValue = txtAccCost.Text
        sysSettings.insert_update_settingsVariable()
        sysSettings.settingsName = Me.Text & "_IncomeAcc"
        sysSettings.settingsValue = txtAccIncome.Text
        sysSettings.insert_update_settingsVariable()
        sysSettings.settingsName = Me.Text & "_AssetAcc"
        sysSettings.settingsValue = txtAccAsset.Text
        sysSettings.insert_update_settingsVariable()
    End Sub
    Sub getAccountSettings()
        Dim sysSettings As New systemSettings_class
        sysSettings.settingsName = Me.Text & "_CostAcc"
        sysSettings.settingsValue = txtAccCost.Text
        sysSettings.get_settingsValue()
        txtAccCost.Text = sysSettings.return_settingsValue
        sysSettings.settingsName = Me.Text & "_IncomeAcc"
        sysSettings.settingsValue = txtAccIncome.Text
        sysSettings.get_settingsValue()
        txtAccIncome.Text = sysSettings.return_settingsValue
        sysSettings.settingsName = Me.Text & "_AssetAcc"
        sysSettings.settingsValue = txtAccAsset.Text
        sysSettings.get_settingsValue()
        txtAccAsset.Text = sysSettings.return_settingsValue
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If cmbItemType.Text = "" Then
            Exit Sub
        End If
        SAVE()
    End Sub

    Private Sub cmbItemType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbItemType.SelectedIndexChanged
        ItemType()
        generateItemNo()
    End Sub

    Private Sub frmAddItemsInventory_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        disposeform()
    End Sub

    Private Sub frmAddItemsInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If btnAdd.Text = "Add Item" Then
            getAccountSettings()
        ElseIf mode = "Save Item" Then
        End If
    End Sub

    Private Sub txtAccCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccCost.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccCost.Text
        AC.get_accountInfo()
        lblAccCost.Text = AC.accDesc
    End Sub

    Private Sub txtAccIncome_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccIncome.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccIncome.Text
        AC.get_accountInfo()
        lblAccIncome.Text = AC.accDesc
    End Sub

    Private Sub txtAccAsset_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccAsset.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccAsset.Text
        AC.get_accountInfo()
        lblAccAsset.Text = AC.accDesc
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        For Each r As DataGridViewRow In dgv.SelectedRows
            dgv.Rows.Remove(r)
        Next
    End Sub




    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim UOM As String
            Dim BalanceQTY As Integer
            Dim minQty As Integer
            Dim haveDef As Integer
            UOM = InputBox("Please Enter Unit of Measurement", "Required")
          
            If UOM.Length <= 1 Then
                UOM = InputBox("Invalid Unt of Measurement", "Required")
                Exit Sub
            End If
            BalanceQTY = InputBox("Please Enter Balance Qty of Unit", "Required")
            minQty = InputBox("Please Enter Minumum Stock Level Qty", "Required")


            For Each r As DataGridViewRow In dgv.Rows
                If r.Cells(3).Value = 1 Then
                    haveDef = 1
                    Exit For
                End If
            Next
            If haveDef <> 1 Then
                MsgBox("This unit will be default automatically", MsgBoxStyle.OkOnly, "SYSTEM INFORMATION")
                dgv.Rows.Add(UOM, BalanceQTY, minQty, 1)
            Else
                dgv.Rows.Add(UOM, BalanceQTY, minQty, 0)
            End If
        Catch ex As Exception
            MsgBox("Invalid Input Data", MsgBoxStyle.OkOnly, "Error")
        End Try

    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        For Each r As DataGridViewRow In dgv.Rows
            r.Cells(3).Value = 0
        Next
        dgv.CurrentRow.Cells(3).Value = 1
    End Sub
End Class