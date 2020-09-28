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
        txtUnit.Text = ""
        txtUnitprice.Text = ""
        txtBalQty.Text = "0"
        txtOqty.Text = "0"
        txtOunit.Text = ""
        txtMinStock.Text = ""
        chkBuy.Checked = False
        chkSell.Checked = False
        chkInv.Checked = False
        chkboxInactive.Checked = False
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
        If MsgBox("ARE YOU SURE YOU WANT TO SAVE ITEM ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Dim inventoryClass As New inventory_class
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
            If txtMinStock.Text = "" Or IsNumeric(txtMinStock.Text) = False Then
                txtMinStock.Text = "0"
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
            inventoryClass.unit = txtUnit.Text
            inventoryClass.unitprice = txtUnitprice.Text
            inventoryClass.accCost = txtAccCost.Text
            inventoryClass.accIncome = txtAccIncome.Text
            inventoryClass.accAsset = txtAccAsset.Text
            inventoryClass.minStock = txtMinStock.Text
            inventoryClass.balanceQty = txtBalQty.Text
            inventoryClass.ounit = txtOunit.Text
            inventoryClass.oqty = txtOqty.Text
            inventoryClass.src = Me.Text
            inventoryClass.insert_update_inventory_class()

            If txtBalQty.Text <> "0" Then
                inventoryClass.memo = "BEGINNING BALANCE"
                inventoryClass.debit = CDbl(txtUnitCost.Text) * CDbl(txtBalQty.Text)
                inventoryClass.credit = 0
                inventoryClass.insert_Acc_entry_class()
            End If
            saveAccountSettings()
            Me.Close()
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
        If cmbItemType.Text = "" Or txtUnit.Text = "" Then
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
End Class