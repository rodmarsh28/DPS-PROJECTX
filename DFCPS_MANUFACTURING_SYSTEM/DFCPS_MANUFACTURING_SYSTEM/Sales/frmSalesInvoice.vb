Public Class frmSalesInvoice

    Public formMode As String
    Public CardID As String = ""
    Public RefNo As String
    Public totalBalance As Double
    Dim checkNo As String
    Dim amountPaid As String
    Dim PAYNO As String
    Dim seriesNo As String
    Dim series As String
    Public successPay As Boolean
    Public order_no As String
    Public perf_command As String

    Sub ItemType()
        If lblFormMode.Text = "QUOTATION" Then
            series = "SQ-"
        ElseIf lblFormMode.Text = "SALES ORDER" Then
            series = "SO-"
        ElseIf lblFormMode.Text = "SALES CASH INVOICE" Then
            series = "SCHI-"
        ElseIf lblFormMode.Text = "SALES CHARGE INVOICE" Then
            series = "SCRI-"
        ElseIf lblFormMode.Text = "SALES DELIVER" Then
            series = "DR-"
        End If
    End Sub


    Sub generateNo()
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
                If lblFormMode.Text = "QUOTATION" Then
                    .CommandText = "SELECT quoteNo from tblSalesQuotation order by quoteNo DESC"
                ElseIf lblFormMode.Text = "SALES ORDER" Then
                    .CommandText = "SELECT salesOrderNo from tblSalesOrder order by salesOrderNo DESC"
                ElseIf lblFormMode.Text = "SALES CASH INVOICE" Then
                    .CommandText = "SELECT salesCashInvoiceNo from tblsalesCashInvoice order by salesCashInvoiceNo DESC"
                ElseIf lblFormMode.Text = "SALES CHARGE INVOICE" Then
                    .CommandText = "SELECT salesChargeInvoiceNo from tblsalesChargeInvoice order by salesChargeInvoiceNo DESC"
                ElseIf lblFormMode.Text = "SALES DELIVER" Then
                    .CommandText = "SELECT salesDeliverNo from tblsalesDeliver order by salesDeliverNo DESC"
                End If
            End With
            OleDBDR = OleDBC.ExecuteReader
            ItemType()
            If OleDBDR.Read Then
                StrID = OleDBDR.Item(0).Substring(OleDBDR.Item(0).Length - 5)
                txtSalesNo.Text = series + Format(Val(StrID) + 1, "00000")
            Else
                txtSalesNo.Text = series + "00001"
            End If
            seriesNo = txtSalesNo.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    
    Sub GET_TOTAL()
        Dim totFA As Decimal = 0
        Dim totDis As Decimal = 0
        Dim totAmount As Decimal = 0
        Dim totWt As Decimal = 0
        For Each row As DataGridViewRow In dgv.Rows

            row.Cells(7).Value = ((CDec(row.Cells(3).Value) * CDec(row.Cells(5).Value)) - CDec(row.Cells(6).Value)).ToString("N")
            totFA = totFA + (CDec(row.Cells(3).Value) * CDec(row.Cells(5).Value))
            totDis = totDis + CDec(row.Cells(6).Value)
            totAmount = totAmount + CDec(row.Cells(7).Value)
            row.Cells(4).Value = CDec(row.Cells(10).Value) * CDec(row.Cells(5).Value).ToString("N")
            totWt += CDec(row.Cells(4).Value)
        Next
        lblTotFAmnt.Text = totFA.ToString("N")
        lblTotDis.Text = totDis.ToString("N")
        lblTotAmount.Text = totAmount.ToString("N")
        lblTotWt.Text = totWt.ToString("N")
        lblTotal.Text = "Php " & totAmount.ToString("N")
        Dim ic As New inventory_class
        Try
            For Each row As DataGridViewRow In dgv.Rows
                If row.Cells(9).Value.ToString <> "" Then
                    ic.itemNo = row.Cells(0).Value
                    ic.job = row.Cells(9).Value
                    ic.get_inventory_perjob()
                    row.Cells(4).Value = ic.dtable.Rows(0).Item(0).ToString
                End If
            Next
        Catch ex As Exception
        End Try
        'Dim sc As New sales_class
        'If lblFormMode.Text = "SALES DELIVER" Or lblFormMode.Text = "SALES CASH INVOICE" Or lblFormMode.Text = "SALES CHARGE INVOICE" Then
        '    sc.searchValue = txtRefNo.Text
        '    sc.get_order_no()
        '    order_no = sc.dtable.Rows(0).Item(0).ToString
        '    For Each row As DataGridViewRow In dgv.Rows
        '        row.Cells(8).Value = order_no
        '    Next
        'End If
    End Sub
    Sub disposeform()
        txtSalesNo.Text = ""
        txtRefNo.Text = ""
        RefNo = ""
        CardID = ""
        txtName.Text = ""
        lblTotal.Text = "Php 0.00"
        dgv.Rows.Clear()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub insert_update_sales()
        Try
            Dim sc As New sales_class
            sc.transcount = 0
            sc.transNo = seriesNo
            sc.transType = lblFormMode.Text
            sc.refNo = txtRefNo.Text
            sc.cardId = CardID
            sc.totFAmnt = CDec(lblTotFAmnt.Text)
            sc.totDiscount = CDec(lblTotDis.Text)
            sc.totAmount = CDec(Mid(lblTotal.Text, 4))
            sc.status = ""
            For Each row As DataGridViewRow In dgv.Rows
                sc.itemCode = row.Cells(0).Value
                sc.uprice = row.Cells(3).Value
                sc.qty = row.Cells(4).Value
                sc.pc = row.Cells(5).Value
                sc.discount = row.Cells(6).Value
                sc.amount = row.Cells(7).Value
                sc.cost = row.Cells(8).Value
                sc.insert_update_sales()
                sc.transcount += 1
            Next

            If lblFormMode.Text = "SALES ORDER" Then
                sc.update_salesQuotation_status(txtRefNo.Text, "Closed")
            ElseIf lblFormMode.Text = "SALES CASH INVOICE" Then
                sc.update_salesOrder_status(txtRefNo.Text, "Closed")
            ElseIf lblFormMode.Text = "SALES CHARGE INVOICE" Then
                sc.update_salesOrder_status(txtRefNo.Text, "Closed")
            ElseIf lblFormMode.Text = "SALES DELIVER" And chkClosed.Checked = True Then
                sc.update_salesCash_status(txtRefNo.Text, "All ordered items delivered")
                sc.update_salesCharge_status(txtRefNo.Text, "All ordered items delivered")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub save()
        If MsgBox("ARE YOU SURE TO POST THIS TRANSACTION?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SYSTEM REMINDER") = MsgBoxResult.Yes Then
            If lblFormMode.Text = "SALES CASH INVOICE" Or lblFormMode.Text = "SALES CHARGE INVOICE" Then

                If lblFormMode.Text = "SALES CASH INVOICE" Then
                    'prepare_job.cardID = CardID
                    'prepare_job.txtCustomerName.Text = txtName.Text
                    'prepare_job.dgv.Rows.Add(txtSalesNo.Text, "Open", Now.ToString("MM/dd/yyyy"), CDec(lblTotFAmnt.Text).ToString("N"), "0.00", CDec(lblTotFAmnt.Text).ToString("N"), "0.00")
                    'prepare_job.ShowDialog()
                End If
            ElseIf lblFormMode.Text = "SALES DELIVER" Then
                Dim ic As New inventory_class
                'item_transaction() '
                For Each row As DataGridViewRow In dgv.Rows
                    ic.refNo = seriesNo
                    ic.itemNo = row.Cells(0).Value
                    ic.unitCost = CDec(row.Cells(8).Value) / CDec(row.Cells(4).Value)
                    ic.qty = "-" & row.Cells(4).Value
                    ic.pcQty = "-" & row.Cells(5).Value
                    ic.job = txtJob.Text
                    ic.insert_invItem_transaction()
                Next
            End If
            If lblFormMode.Text = "SALES CASH INVOICE" Then
                frmReceivePayments.MODE = "SALES INVOICE"
                frmReceivePayments.cardID = CardID
                frmReceivePayments.txtRecvAccount.Text = txtARAcc.Text
                frmReceivePayments.txtCustomerName.Text = txtName.Text
                frmReceivePayments.load_command()
                frmReceivePayments.dgv.Rows.Clear()
                frmReceivePayments.dgv.Rows.Add(txtSalesNo.Text, Now.ToString("MM/dd/yyyy"), lblTotFAmnt.Text, lblTotDis.Text, "0.00", lblTotAmount.Text, "0.00", txtARAcc.Text)
                frmReceivePayments.ShowDialog()
                If frmReceivePayments.succesPay <> True Then
                    Exit Sub
                End If
            End If
            If lblFormMode.Text = "SALES CASH INVOICE" Or lblFormMode.Text = "SALES CHARGE INVOICE" Or lblFormMode.Text = "SALES DELIVER" Then
                invAssetEntry()
            End If
            insert_update_sales()
            MsgBox(lblFormMode.Text & " Posted !", MsgBoxStyle.Information, "System Information")
            If lblFormMode.Text = "SALES ORDER" Then
                If MsgBox("DO YOU WANT TO CREATE JOB ORDER NOW?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SYSTEM REMINDER") = MsgBoxResult.Yes Then
                    Dim frm As New prepare_job
                    frm.StartPosition = FormStartPosition.CenterScreen
                    frm.Show()
                    frm.TXTREF.Text = txtSalesNo.Text
                    frm.get_sales_order_items(txtSalesNo.Text)
                    frm.get_card_id(txtSalesNo.Text)
                    frm.generateNo()
                End If
            ElseIf lblFormMode.Text = "SALES DELIVER" Then
                If MsgBox("DO YOU WANT TO PRINT DELIVERY RECEIPT AND GATEPASS NOW?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SYSTEM REMINDER") = MsgBoxResult.Yes Then
                    Dim sc As New sales_class
                    sc.print_DR(seriesNo)
                End If
            ElseIf lblFormMode.Text = "QUOTATION" Then
                If MsgBox("DO YOU WANT TO PRINT QUOTATION NOW?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SYSTEM REMINDER") = MsgBoxResult.Yes Then
                    Dim sc As New sales_class
                    sc.print_sales(seriesNo, lblFormMode.Text)
                End If
            End If
            disposeform()
            load_commands()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dgv.RowCount = 0 Then
            Exit Sub
        End If
        If lblFormMode.Text = "SALES DELIVER" Then
            If txtRefNo.Text = "" Then
                Exit Sub
            ElseIf CDec(lblTotWt.Text) <= 0 Then
                MsgBox("Item Weight Required to proceed !", MsgBoxStyle.Critical, "SYSTEM INFORMATION")
                Exit Sub
            End If
        End If
        Try
            save()
            'update_date_row_changes()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmSalesInvoice_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmSales_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        disposeform()
    End Sub

    Private Sub frmSales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtQty.Focus()
        ElseIf e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control Then
            If MsgBox("ARE YOU SURE TO DELETE THIS ITEM?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
                For Each row As DataGridViewRow In dgv.SelectedRows
                    dgv.Rows.Remove(row)
                Next
                GET_TOTAL()
            End If
          
        ElseIf e.KeyCode = Keys.F5 Then
            If MsgBox("ARE YOU SURE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
                If lblFormMode.Text = "QUOTATION" Then
                    lblFormMode.Text = "SALES ORDER"
                ElseIf lblFormMode.Text = "SALES ORDER" Then
                    lblFormMode.Text = "SALES CASH INVOICE"
                ElseIf lblFormMode.Text = "SALES CASH INVOICE" Then
                    lblFormMode.Text = "SALES CHARGE INVOICE"
                ElseIf lblFormMode.Text = "SALES CHARGE INVOICE" Then
                    lblFormMode.Text = "SALES DELIVER"
                ElseIf lblFormMode.Text = "SALES DELIVER" Then
                    lblFormMode.Text = "QUOTATION"
                End If
                generateNo()
                load_commands()
                dgv.Rows.Clear()
                txtRefNo.Text = ""
            End If
            End If
    End Sub
    'Sub get_sales_info(ByVal id As String, ByVal type As String)
    '    Dim ds As New sales_dsTableAdapters.salesInfoTableAdapter
    '    Dim dt As New DataTable
    '    ds.Fill(dt, id)

    '    txtSalesNo.Text = dt.Rows(0).Item(0).ToString
    '    txtName.Text = dt.Rows(0).Item(0).ToString
    '    txtRefNo.Text = dt.Rows(0).Item(0).ToString
    '    txtMemo.Text = dt.Rows(0).Item(0).ToString
    '    txtARAcc.Text = dt.Rows(0).Item(0).ToString
    '    txtMemo.Text = dt.Rows(0).Item(0).ToString
    '    CardID = dt.Rows(0).Item(0).ToString
    '    dgv.Rows.Clear()
    '    For Each row As DataRow In dt.Rows
    '        dgv.Rows.Add(row(0), row(0), row(0), row(0), row(0), row(0), row(0), row(0), row(0), row(0))
    '    Next

    'End Sub
    Sub load_commands()
        Me.MdiParent = frmSalesMain
        generateNo()
        lblTotal.Text = "Php 0.00"
        Dim ss As New systemSettings_class
        ss.settingsName = Me.Text & "_SalesARACC"
        ss.settingsValue = txtARAcc.Text
        ss.get_settingsValue()
        txtARAcc.Text = ss.return_settingsValue
        If lblFormMode.Text = "SALES CASH INVOICE" Or lblFormMode.Text = "SALES CHARGE INVOICE" Then
            Button4.Enabled = True
            txtMemo.Enabled = True
        Else
            Button4.Enabled = False
            txtMemo.Enabled = False
        End If
        If lblFormMode.Text = "SALES DELIVER" Or lblFormMode.Text = "SALES CASH INVOICE" Or lblFormMode.Text = "SALES CHARGE INVOICE" Then
            Button5.Enabled = True
        Else
            Button5.Enabled = False
        End If
        If lblFormMode.Text = "SALES DELIVER" Then
            chkClosed.Visible = True
            dgv.Columns(4).Visible = True
            dgv.Columns(4).HeaderText = "Wt.(KG)"
            dgv.Columns(5).HeaderText = "Pc"
        Else
            chkClosed.Visible = False
            dgv.Columns(4).Visible = False
            dgv.Columns(4).HeaderText = "Wt.(KG)"
            dgv.Columns(5).HeaderText = "Qty"
        End If
    End Sub
    Function isExist(ByVal id As String) As String
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells(0).Value = id Then
                Return row.Index
                Exit Function
            End If
        Next
        Return "NOT EXISTED"
    End Function
    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If lblFormMode.Text = "SALES DELIVER" Then
            If txtRefNo.Text = "" Then
                Exit Sub
            End If
        End If
        If txtQty.Text = "" Then
            txtQty.Text = "1"
        End If
        InventoryList.mode = "Sales"
        InventoryList.clickedItem = False
        InventoryList.ShowDialog()

        If InventoryList.clickedItem = True Then

            Dim qty As Decimal
            Dim r As Integer = dgv.Rows.Count

            Dim INDEX As String
            INDEX = isExist(InventoryList.dgv.CurrentRow.Cells(0).Value)
            If lblFormMode.Text = "SALES DELIVER" Then
                If CDec(txtQty.Text) > CDec(InventoryList.dgv.CurrentRow.Cells(9).Value) Then
                    MsgBox("Our stock onhand is insufficient for your requested qty to deliver !", MsgBoxStyle.Critical, "SYSTEM INFORMATION")
                    Exit Sub
                End If
            End If
            If INDEX <> "NOT EXISTED" Then
                If lblFormMode.Text = "SALES DELIVER" Then
                    'qty = InputBox("Please Enter Weight Qty", "Required")
                    dgv.Rows(CInt(INDEX)).Cells(4).Value = (CDec(InventoryList.dgv.CurrentRow.Cells(4).Value) / CDec(InventoryList.dgv.CurrentRow.Cells(9).Value)) * CDec(txtQty.Text)
                    dgv.Rows(CInt(INDEX)).Cells(5).Value = txtQty.Text
                    dgv.Rows(CInt(INDEX)).Cells(10).Value = CDec(InventoryList.dgv.CurrentRow.Cells(4).Value) / CDec(InventoryList.dgv.CurrentRow.Cells(9).Value)
                Else
                    dgv.Rows(CInt(INDEX)).Cells(4).Value = "0"
                    dgv.Rows(CInt(INDEX)).Cells(5).Value = txtQty.Text
                    dgv.Rows(CInt(INDEX)).Cells(10).Value = "0"

                End If
                Exit Sub
            Else
                With dgv
                    .Rows.Add()
                    .Item(0, r).Value = InventoryList.dgv.CurrentRow.Cells(0).Value
                    .Item(1, r).Value = InventoryList.dgv.CurrentRow.Cells(1).Value
                    .Item(2, r).Value = InventoryList.dgv.CurrentRow.Cells(2).Value
                    .Item(3, r).Value = InventoryList.dgv.CurrentRow.Cells(3).Value
                    .Item(6, r).Value = "0.00"
                    If lblFormMode.Text = "SALES DELIVER" Then
                        'qty = InputBox("Please Enter Weight Qty", "Required")
                        .Item(4, r).Value = (CDec(InventoryList.dgv.CurrentRow.Cells(4).Value) / CDec(InventoryList.dgv.CurrentRow.Cells(9).Value)) * CDec(txtQty.Text)
                        .Item(5, r).Value = txtQty.Text
                        .Columns("Qty").Visible = True
                        .Columns(5).HeaderText = "Pc"
                        .Item(10, r).Value = CDec(InventoryList.dgv.CurrentRow.Cells(4).Value) / CDec(InventoryList.dgv.CurrentRow.Cells(9).Value)
                    Else
                        .Columns("Qty").Visible = False
                        .Columns(5).HeaderText = "Qty"
                        .Item(4, r).Value = "0"
                        .Item(5, r).Value = txtQty.Text
                        .Item(10, r).Value = "0"
                    End If
                    .Item(7, r).Value = CDbl(InventoryList.dgv.CurrentRow.Cells(3).Value) * CDbl(txtQty.Text)
                    .Item(8, r).Value = CDbl(InventoryList.dgv.CurrentRow.Cells(8).Value) * CDbl(txtQty.Text)
                End With
            End If
            txtQty.Text = "1"
            GET_TOTAL()
        End If
        dgv.Select()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub
    Sub invAssetEntry()
        Dim ac As New Account_Class
        Dim ae As New accEntry_class
        Dim ic As New inventory_class
        ae.refno = seriesNo
        If lblFormMode.Text = "SALES CASH INVOICE" Or lblFormMode.Text = "SALES CHARGE INVOICE" Then
            ae.SRC = Me.Text
            ae.account = txtARAcc.Text
            ae.memo = "Receivable: " & txtMemo.Text
            ae.debit = CDec(lblTotFAmnt.Text).ToString("N")
            ae.credit = 0
            ae.job = txtJob.Text
            ae.cardID = CardID
            ae.insert_Acc_entry_class()
            For Each row As DataGridViewRow In dgv.Rows
                'check inventory info'
                ac.searchValue = row.Cells(0).Value
                ac.checkInventoryInfo()
                'sales'
                ae.SRC = row.Cells(0).Value
                ae.account = ac.dtable.Rows(0).Item("INCOMEACC")
                ae.memo = "Sales: " & txtMemo.Text
                ae.debit = 0
                ae.credit = CDec(row.Cells(7).Value)
                ae.job = txtJob.Text
                ae.insert_Acc_entry_class()
            Next
        End If
        If lblFormMode.Text = "SALES DELIVER" Then
            For Each row As DataGridViewRow In dgv.Rows
                'check inventory info'
                ac.searchValue = row.Cells(0).Value
                ac.checkInventoryInfo()
                'cost of sales'
                ae.SRC = row.Cells(0).Value
                ae.account = ac.dtable.Rows(0).Item("COSTOFSALESACC")
                ae.memo = "Cost of sales: " & txtMemo.Text
                ae.debit = ac.dtable.Rows(0).Item("UNITCOST") * CDec(row.Cells(4).Value)
                ae.credit = 0
                ae.job = txtJob.Text
                ae.insert_Acc_entry_class()
                'inventory'
                ae.account = ac.dtable.Rows(0).Item("ASSETACC")
                ae.memo = "Inventory: " & txtMemo.Text
                ae.debit = 0
                ae.credit = ac.dtable.Rows(0).Item("UNITCOST") * CDec(row.Cells(4).Value)
                ae.job = txtJob.Text
                ae.insert_Acc_entry_class()
            Next
        End If
    End Sub
    Sub get_item_from_ref(ByVal mode As String)
        Dim sc As New sales_class
        sc.dtable.Reset()
        sc.commands = mode
        sc.searchValue = frmsales_list_selector.DGV.CurrentRow.Cells(1).Value
        sc.cardId = CardID
        sc.get_sales_items()
        dgv.Rows.Clear()
        For Each row As DataRow In sc.dtable.Rows
            CardID = row(1)
            txtName.Text = row(2)
            dgv.Rows.Add(row(3), row(4), row(5), CDec(row(7)).ToString("N"), CDec(row(6)).ToString("N"), CDec(row(10)).ToString("N"), CDec(row(8)).ToString("N"), "0.00", row(9), "", row(11))
        Next
        frmsales_list_selector.successClick = False
        GET_TOTAL()
        dgv.ClearSelection()
    End Sub
    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        frmCardListForSelection.formMode = "Sales Invoice"
        frmCardListForSelection.itemClick = False
        frmCardListForSelection.filterType()
        frmCardListForSelection.ShowDialog()
        If frmCardListForSelection.itemClick = True Then
            CardID = frmCardListForSelection.LV.SelectedItems(0).SubItems(0).Text
            txtName.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(1).Text
            totalBalance = frmCardListForSelection.LV.SelectedItems(0).SubItems(4).Text
        End If

    End Sub

    Private Sub lblFormMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFormMode.Click
       
    End Sub

    Private Sub lblFormMode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblFormMode.TextChanged
        If lblFormMode.Text = "QUOTATION" Then
            Me.BackColor = System.Drawing.SystemColors.Info
        ElseIf lblFormMode.Text = "SALES ORDER" Then
            Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        ElseIf lblFormMode.Text = "SALES CASH INVOICE" Then
            Me.BackColor = Color.White
        ElseIf lblFormMode.Text = "SALES CHARGE INVOICE" Then
            Me.BackColor = Color.PeachPuff
        ElseIf lblFormMode.Text = "SALES DELIVER" Then
            Me.BackColor = Color.OldLace
        End If
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        'Try
        '    If dgv.CurrentCell.ColumnIndex = 5 Then
        '        Dim dsc As Decimal = InputBox("Debit Value")
        '        dgv.CurrentRow.Cells(5).Value = Format(dsc, "N")
        '        dgv.CurrentRow.Cells(6).Value = ((CDec(dgv.CurrentRow.Cells(3).Value) * CDec(dgv.CurrentRow.Cells(4).Value)) - CDec(dgv.CurrentRow.Cells(5).Value)).ToString("N")
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Try
            If dgv.CurrentCell.ColumnIndex = 4 Then
                Dim qty As Decimal = InputBox("Qty", "System Information")
                dgv.CurrentRow.Cells(4).Value = Format(qty, "N")
            ElseIf dgv.CurrentCell.ColumnIndex = 5 Then
                Dim qty As Decimal = InputBox("PC Qty", "System Information")
                dgv.CurrentRow.Cells(5).Value = Format(qty, "N")
                
            End If
            GET_TOTAL()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                If dgv.SelectedRows.Count > 0 Then
                    dgv.ContextMenuStrip = ContextMenuStrip1
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        GET_TOTAL()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try

            If lblFormMode.Text = "QUOTATION" Then
                Exit Sub
            ElseIf lblFormMode.Text = "SALES ORDER" Then
                perf_command = "Quotation"
                frmsales_list_selector.MODE = "QUOTATION"
            ElseIf lblFormMode.Text = "SALES CASH INVOICE" Then
                perf_command = "Sales Order"
                frmsales_list_selector.MODE = "SALES ORDER"
            ElseIf lblFormMode.Text = "SALES CHARGE INVOICE" Then
                perf_command = "Sales Order"
                frmsales_list_selector.MODE = "SALES ORDER"
            ElseIf lblFormMode.Text = "SALES DELIVER" Then
                perf_command = "Sales Invoice"
                frmsales_list_selector.MODE = "SALES INVOICE"
            End If
            frmsales_list_selector.cardID = CardID
            frmsales_list_selector.ShowDialog()
            If frmsales_list_selector.successClick = True Then
                txtRefNo.Text = frmsales_list_selector.DGV.CurrentRow.Cells(1).Value
                get_item_from_ref(perf_command)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ss As New systemSettings_class
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtARAcc.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
            ss.settingsName = Me.Text & "_SalesARACC"
            ss.settingsValue = txtARAcc.Text
            ss.insert_update_settingsVariable()
            frmAccountList.successClick = False
        End If
    End Sub

    Private Sub txtARAcc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtARAcc.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtARAcc.Text
        AC.get_accountInfo()
        lblARAcc.Text = AC.accDesc
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtSalesDisAcc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        GET_TOTAL()
    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        GET_TOTAL()
    End Sub

    Private Sub ClearJobToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearJobToolStripMenuItem.Click
        dgv.CurrentRow.Cells(8).Value = ""
    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgv.ContextMenuStrip = ContextMenuStrip1
    End Sub
    
 

  
    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmsales_list_selector.MODE = "Job"
        frmsales_list_selector.ShowDialog()
        If frmsales_list_selector.successClick = True Then
            txtJob.Text = frmsales_list_selector.DGV.CurrentRow.Cells(0).Value
        End If
    End Sub

    Private Sub txtRefNo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRefNo.MouseDown
       
    End Sub

    Private Sub txtRefNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRefNo.TextChanged

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        txtRefNo.Text = ""
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        CardID = ""
        txtName.Text = ""
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        txtJob.Text = ""
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class