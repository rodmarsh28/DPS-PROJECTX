Imports System.Data.SqlClient

Public Class frmPurchases
    Public totAmount As Double
    Public formMode As String
    Public CardID As String
    Public RefNo As String
    Public totalBalance As Double
    Dim checkNo As String
    Dim amountPaid As String
    Dim PAYNO As String
    Public MEMO As String

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
                If lblFormMode.Text = "PURCHASE ORDER" Then
                    .CommandText = "SELECT purchaseOrderNo from tblPurchaseOrder order by purchaseOrderNo DESC"
                End If
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = OleDBDR.Item(0).Substring(OleDBDR.Item(0).Length - 5)
                transNo.Text = "PO-" & Format(Val(StrID) + 1, "00000")
            Else
                transNo.Text = "PO-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    'Sub clear()
    '    txtColor.Text = ""
    '    txtUnitPrice.Text = ""
    '    txtQty.Text = ""
    'End Sub
    Sub disposeform()
        generateNo()
        RefNo = ""
        CardID = ""
        txtName.Text = ""
        totAmount = 0.0
        lblTotal.Text = "Total" & vbCrLf & "Php " & Format(totAmount, "N")
        dgv.Rows.Clear()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    
    Sub RECORD_PO()
        Try
            Dim ac As New Account_Class
            Dim po_ds As New purchase_dsTableAdapters.tblPurchaseOrderTableAdapter
            po_ds.Connection.ConnectionString = My.Settings.connStringValue
            For Each row As DataGridViewRow In dgv.Rows
                If row.Cells(4).Value > 0 Then
                    po_ds.Insert(transNo.Text, Now, txtRefNo.Text, CardID, MainForm.LBLID.Text, row.Cells(1).Value, row.Cells(2).Value, CDec(row.Cells(3).Value), CDec(row.Cells(4).Value), CDec(row.Cells(5).Value), CDec(row.Cells(6).Value), CDec(row.Cells(7).Value), "", 0, Now)
                End If
            Next
            MsgBox(lblFormMode.Text & " POSTED !", MsgBoxStyle.Information, "SUCCESS")
            ac.insert_to_approval(transNo.Text, Now, "Purchase Order", "Waiting for approval")
            disposeform()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub RECEIVE_PURCHASED()
        Try
            Dim ac As New Account_Class
            Dim po_ds As New purchase_dsTableAdapters.tblPurchaseOrderTableAdapter
            po_ds.Connection.ConnectionString = My.Settings.connStringValue
            For Each row As DataGridViewRow In dgv.Rows
                If row.Cells(4).Value > 0 Then
                    po_ds.Insert(transNo.Text, Now, txtRefNo.Text, CardID, MainForm.LBLID.Text, row.Cells(1).Value, row.Cells(2).Value, CDec(row.Cells(3).Value), CDec(row.Cells(4).Value), CDec(row.Cells(5).Value), CDec(row.Cells(6).Value), CDec(row.Cells(7).Value), "", 0, Now)
                End If
            Next
            MsgBox(lblFormMode.Text & " POSTED !", MsgBoxStyle.Information, "SUCCESS")
            ac.insert_to_approval(transNo.Text, Now, "Purchase Order", "Waiting for approval")
            disposeform()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSAVE.Click
        If txtName.Text <> "" Then
            If MsgBox("Are You Sure ?", MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.Yes Then
                If lblFormMode.Text = "PURCHASE ORDER" Then
                    RECORD_PO()
                ElseIf lblFormMode.Text = "PURCHASE RECEIVING" Then
                    RECEIVE_PURCHASED()
                End If

            End If
        Else
            mb("error", "Please Select Supplier")
            Exit Sub
        End If
    End Sub

    Private Sub frmPurchases_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmSales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtQty.Focus()
        ElseIf e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control Then
            If MsgBox("ARE YOU SURE TO DELETE THIS ITEM?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
                For Each row As DataGridViewRow In dgv.SelectedRows
                    totAmount = totAmount - dgv.CurrentRow.Cells(6).Value
                    dgv.Rows.Remove(row)
                Next
                lblTotal.Text = "Php " & Format(totAmount, "N")
            End If

            'ElseIf e.KeyCode = Keys.F5 Then
            '    If MsgBox("ARE YOU SURE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            '        'If lblFormMode.Text = "PURCHASE REQUISITION" Then
            '        '    lblFormMode.Text = "PURCHASE ORDER"
            '        If lblFormMode.Text = "PURCHASE ORDER" Then
            '            lblFormMode.Text = "PURCHASE INVOICE"
            '        ElseIf lblFormMode.Text = "PURCHASE INVOICE" Then
            '            lblFormMode.Text = "PURCHASE REQUISITION"
            '        End If
            '        generateNo()
            '    End If
        End If
    End Sub

    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmPurchaseMain
        generateNo()
        totAmount = 0
        lblTotal.Text = "Php " & Format(totAmount, "N")
        'cmbPayment.SelectedIndex = 0
    End Sub
    Sub get_total()
        Try
            Dim totFA As Decimal = 0
            Dim totTax As Decimal = 0
            Dim totAmount As Decimal = 0
            For Each row As DataGridViewRow In dgv.Rows
                totFA = totFA + (CDec(row.Cells(3).Value) * CDec(row.Cells(4).Value))
                row.Cells(5).Value = (CDec(row.Cells(3).Value) * CDec(row.Cells(4).Value)).ToString("N")
                totTax = totTax + CDec(row.Cells(6).Value)
                totAmount = totAmount + CDec(row.Cells(5).Value) - CDec(row.Cells(6).Value)
                row.Cells(7).Value = (CDec(row.Cells(5).Value) - CDec(row.Cells(6).Value)).ToString("N")
            Next
            lblTotFAmnt.Text = totFA.ToString("N")
            lblTotTax.Text = totTax.ToString("N")
            lblTotAmount.Text = totAmount.ToString("N")
            lblTotal.Text = "Php " & totAmount.ToString("N")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtQty.Text = "" Then
            txtQty.Text = "1"
        End If
        InventoryList.mode = "Purchases"
        InventoryList.ShowDialog()
        If InventoryList.clickedItem = True Then
            Dim r As Integer = dgv.Rows.Count
            dgv.Rows.Add()
            dgv.Item(0, r).Value = InventoryList.dgv.CurrentRow.Cells(0).Value
            dgv.Item(1, r).Value = InventoryList.dgv.CurrentRow.Cells(1).Value
            dgv.Item(2, r).Value = InventoryList.dgv.CurrentRow.Cells(2).Value
            dgv.Item(3, r).Value = InventoryList.dgv.CurrentRow.Cells(3).Value
            dgv.Item(4, r).Value = txtQty.Text
            dgv.Item(5, r).Value = CDec(InventoryList.dgv.CurrentRow.Cells(3).Value) * CDec(txtQty.Text)
            lblTotal.Text = "Php " & Format(totAmount, "N")
            InventoryList.clickedItem = False
        End If

    End Sub
    Sub sumofAmount()
        totAmount = 0
        For i As Integer = 0 To dgv.Rows.Count() - 1 Step +1
            totAmount = totAmount + dgv.Rows(i).Cells(6).Value
        Next
        lblTotal.Text = "Php " & Format(totAmount, "N")
    End Sub


    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        frmCardListForSelection.formMode = "Purchase Invoice"
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
        If lblFormMode.Text = "PURCHASE ORDER" Then
            Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        ElseIf lblFormMode.Text = "PURCHASE RECEIVING" Then
            Me.BackColor = Color.White
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            frmGetRequisitionItemList.Close()
            frmGetRequisitionItemList.viewList_itemRequisition()
            frmGetRequisitionItemList.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Try
            Dim VALUE As Double = InputBox("Input Value")
            dgv.CurrentCell.Value = VALUE
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        Try
            get_total()
        Catch ex As Exception
        End Try
    End Sub

   
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class