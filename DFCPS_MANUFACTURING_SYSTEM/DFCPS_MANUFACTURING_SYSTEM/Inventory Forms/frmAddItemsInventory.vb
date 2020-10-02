Public Class frmAddItemsInventory
    Public mode As String
    Public SeriesNo As String
    Dim cur_balQty As Integer
    Dim cur_pcQty As Integer
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
        txtPC.Text = "0"
        txtBalQty.Text = "0"
        txtMinQTY.Text = "0"
        txtUnitCost.Text = "0.00"
        txtUnitPrice.Text = "0.00"
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
            Try
                Dim src As String = Form.ActiveForm.Text
                Dim Ref As String = "BALANCE"
                Dim tr_qty As Integer
                Dim pcQTY As Integer
                Dim inventoryClass As New inventory_class
                Dim sc As New systemSettings_class
                If btnAdd.Text = "Save Item" Then
                    Ref = sc.insert_tr_update_logs(src, txtItemno.Text)
                    If Ref = "Cancel" Then
                        Exit Sub
                    End If
                    inventoryClass.command = "Update"
                    tr_qty = CInt(txtBalQty.Text) - cur_balQty
                    pcQTY = CInt(txtPC.Text) - cur_pcQty
                    inventoryClass.memo = "ADJUST BALANCE"
                ElseIf btnAdd.Text = "Add Item" Then
                    inventoryClass.command = "Add"
                    tr_qty = CInt(txtBalQty.Text)
                    pcQTY = CInt(txtPC.Text)
                    inventoryClass.memo = "BEGINNING BALANCE"
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

                inventoryClass.src = src
                inventoryClass.refNo = Ref
                inventoryClass.itemNo = txtItemno.Text
                inventoryClass.itemdesc = txtItemdesc.Text
                inventoryClass.unitCost = txtUnitCost.Text
                inventoryClass.unit = txtUnit.Text
                inventoryClass.pcQty = pcQTY
                inventoryClass.unitprice = txtUnitPrice.Text
                inventoryClass.accCost = txtAccCost.Text
                inventoryClass.accIncome = txtAccIncome.Text
                inventoryClass.accAsset = txtAccAsset.Text
                inventoryClass.minStock = txtMinQTY.Text
                inventoryClass.balanceQty = tr_qty
                inventoryClass.src = Me.Text
                inventoryClass.insert_update_inventory_class()

                inventoryClass.debit = CDbl(txtUnitCost.Text) * tr_qty
                inventoryClass.credit = 0
                inventoryClass.insert_Acc_entry_class()
                saveAccountSettings()
                Me.Close()
                MsgBox("Item Saved !", MsgBoxStyle.Information, "Success")
                If btnAdd.Text = "Save Item" Then
                    sc.dc.SubmitChanges()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
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
    Sub update_load()

        Dim ic As New inventory_class
        Dim data = ic.get_inv_item_info(txtItemno.Text)
        txtItemdesc.Text = data.ITEMDESC
        txtAccAsset.Text = data.ASSETACC
        txtAccCost.Text = data.COSTOFSALESACC
        txtAccIncome.Text = data.INCOMEACC
        chkBuy.Checked = ic.check_state(data.BUYABLE)
        chkSell.Checked = ic.check_state(data.SELLABLE)
        chkInv.Checked = ic.check_state(data.INVENTORABLE)
        txtUnit.Text = data.UNIT
        cur_balQty = data.QTY
        cur_pcQty = data.PC_QTY
        txtBalQty.Text = data.QTY
        txtPC.Text = data.PC_QTY
        txtUnitPrice.Text = data.UNITPRICE
        txtMinQTY.Text = data.MINQTY
        txtUnitCost.Text = Format(data.UNITCOST, "N")
        cmbItemType.Text = ic.get_ItemType(txtItemno.Text)
        txtItemno.Enabled = False

    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If cmbItemType.Text = "" Then
            Exit Sub
        End If
        SAVE()
    End Sub

    Private Sub cmbItemType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbItemType.SelectedIndexChanged
        If btnAdd.Text = "Add Item" Then
            ItemType()
            generateItemNo()
        ElseIf btnAdd.Text = "Save Item" Then

        End If
       
    End Sub

    Private Sub frmAddItemsInventory_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        disposeform()
    End Sub

    Private Sub frmAddItemsInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If btnAdd.Text = "Add Item" Then
            getAccountSettings()
        ElseIf mode = "Save Item" Then
            update_load()
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



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub




    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
      

    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
       
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class