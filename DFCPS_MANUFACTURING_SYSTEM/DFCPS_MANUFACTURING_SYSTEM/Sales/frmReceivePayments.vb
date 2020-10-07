Imports System.Data.SqlClient

Public Class frmReceivePayments
    Dim totalAmountApplied As Double = 0
    Public totalBalance As Double
    Public cardID As String
    Dim dt As New DataTable
    Dim rowIndex As Integer
    Public succesPay As Boolean
    Public MODE = "SALES INVOICE"
    Sub disposeForm()
        txtCustomerName.Text = ""
        cardID = ""
        txtChequeNo.Text = ""
        dtpcheckDate.Value = Now
        txtCheckAmount.Text = "0.00"
        txtCashAmount.Text = "0.00"
        txtMemo.Text = ""
        lblTotalAmountReceived.Text = "0.00"
        lblTotAmount.Text = "0.00"
        lblTotDiscount.Text = "0.00"
        lblTotalAmountApplied.Text = "0.00"
        lblOutBalance.Text = "0.00"
        dgv.Rows.Clear()
    End Sub
    Sub generatePaymentNo()
      Try
            Dim SC As New systemSettings_class
            Dim NO As String
            Dim StrID As String
            SC.tableName = "tblPaymentsReceived"
            SC.columnName = "paymentNo"
            SC.series = "RP-"
            SC.generateNo()
            StrID = Mid(SC.result, Len(SC.series) + 1, Len(SC.result))
            NO = SC.series & Format(Val(StrID) + 1, "00000")
            txtPaymentNo.Text = NO
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub getAccountSettings()
        Dim sysSettings As New systemSettings_class
        sysSettings.settingsName = Me.Text & "_ReceivableACC"
        sysSettings.settingsValue = txtRecvAccount.Text
        sysSettings.get_settingsValue()
        txtRecvAccount.Text = sysSettings.return_settingsValue
        sysSettings.settingsName = Me.Text & "_PaymentDepositACC"
        sysSettings.settingsValue = txtDepositAcc.Text
        sysSettings.get_settingsValue()
        txtDepositAcc.Text = sysSettings.return_settingsValue
        sysSettings.settingsName = Me.Text & "_PaymentDiscountACC"
        sysSettings.settingsValue = txtDiscountAcc.Text
        sysSettings.get_settingsValue()
        txtDiscountAcc.Text = sysSettings.return_settingsValue
    End Sub
  

    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
    
    Sub RECORDPAYMENTS()
            Dim paymethod As String
            Dim amountReceived As Decimal
            If chkCheck.Checked = True Then
                paymethod = "Check"
                amountReceived = CDec(txtCheckAmount.Text)
            ElseIf chkCash.Checked = True Then
                paymethod = "Cash"
                amountReceived = CDec(txtCashAmount.Text)
            End If
            Dim sc As New sales_class
            sc.transNo = txtPaymentNo.Text
            sc.paymethod = paymethod
            sc.cardId = cardID
            sc.checkno = txtChequeNo.Text
            sc.checkdate = dtpcheckDate.Value.ToString("yyyy/MM/dd")
            sc.totAmount = CDec(lblTotalAmountReceived.Text)
            sc.outBalance = CDec(lblOutBalance.Text)
            sc.overallBal = CDec(lblTotalAmountApplied.Text)
        sc.accNo = txtDepositAcc.Text


        For Each row As DataGridViewRow In dgv.Rows

            If CDec(row.Cells(6).Value) <> 0 Then
                sc.refNo = row.Cells(0).Value
                sc.discount = CDec(row.Cells(3).Value)
                sc.amountApplied = CDec(row.Cells(6).Value)
                sc.recieve_payments()
            End If
        Next
        acc_entry()
    End Sub
    Sub acc_entry()
        Dim ae As New accEntry_class
        For Each row As DataGridViewRow In dgv.Rows
            If CDec(row.Cells(6).Value) <> 0 Then
                ae.refno = txtPaymentNo.Text
                ae.SRC = row.Cells(0).Value
                ae.cardID = cardID
                ae.memo = "Discount Amount for Invoice No: " & row.Cells(0).Value
                ae.account = txtDiscountAcc.Text
                ae.debit = row.Cells(3).Value
                ae.credit = 0
                ae.insert_Acc_entry_class()
                ae.memo = "Amount Received: " & txtMemo.Text
                ae.account = txtDepositAcc.Text
                ae.debit = row.Cells(6).Value
                ae.credit = 0
                ae.insert_Acc_entry_class()
                ae.memo = "Payment Received for Invoice No: " & row.Cells(0).Value
                ae.account = txtRecvAccount.Text
                ae.debit = 0
                ae.credit = CDec(row.Cells(3).Value) + CDec(row.Cells(6).Value)
                ae.insert_Acc_entry_class()
            End If
        Next
    End Sub
    Sub recordCollection()
        Dim sc As New sales_class
        sc.collectionNo = txtCollection.Text
        sc.transNo = txtPaymentNo.Text
        sc.insert_collection()
    End Sub

    Private Sub txtAmountReceived_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmCardListForSelection.formMode = "ReceivePayments"
        frmCardListForSelection.ShowDialog()
        If frmCardListForSelection.itemClick = True Then
            cardID = frmCardListForSelection.LV.SelectedItems(0).SubItems(0).Text
            txtCustomerName.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(1).Text
            totalBalance = frmCardListForSelection.LV.SelectedItems(0).SubItems(4).Text
            get_invoice_list()
        End If

    End Sub
    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If GetActiveWindow = Me.Handle Then
            generatePaymentNo()
        End If
    End Sub

    Sub get_invoice_list()
        Try
        Dim sc As New sales_class
        Dim ac As New Accounting_class
        sc.accNo = txtRecvAccount.Text
        sc.searchValue = cardID
        sc.get_invoice_list()
        dgv.Rows.Clear()
        For Each row As DataRow In sc.dtable.Rows
                If row(3) > row(5) Then
                    dgv.Rows.Add(row(1), Format(row(2), "MM/dd/yyyy"), Format(CDec(row(3)), "N"), Format(CDec(row(4)), "N"), Format(CDec(row(5)), "N"), Format((CDec(row(3)) - CDec(row(4)) - CDec(row(5))), "N"), "0.00", "")
                End If
        Next
        ac.command = 0
        For Each row As DataGridViewRow In dgv.Rows
            ac.transNo = row.Cells(0).Value
            ac.memotype = "Receivable:"
            ac.GET_ACCNO_OF_TRNO()
            row.Cells(7).Value = ac.accNo
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmReceivePayments_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    End Sub
    Public Sub load_command()
        'Me.MdiParent = frmSalesMain
        getAccountSettings()
        generatePaymentNo()
        succesPay = False
    End Sub
    Private Sub frmReceivePayments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If chkCash.Checked = False And chkCheck.Checked = False Then
            Exit Sub
        End If
        If lblTotalAmountApplied.Text = lblTotalAmountReceived.Text And CDec(lblTotalAmountApplied.Text) > 0 Then
            If MsgBox("ARE YOU SURE YOU WANT TO RECORD PAYMENTS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
                Try
                    RECORDPAYMENTS()
                    If chkCollection.Checked = True Then
                        recordCollection()
                    End If
                    MsgBox(" PAYMENT POSTED !", MsgBoxStyle.Information, "SUCCESS")
                    disposeForm()
                    load_command()
                    If MODE = "SALES INVOICE" Then
                        succesPay = True
                        Me.Close()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Else
            MsgBox("The Amount Received and Amount Applied is not Equal", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Sub sum_value()
        Dim amountApplied As Decimal
        Dim totalAmount As Decimal
        Dim discount As Decimal
        For Each row As DataGridViewRow In dgv.Rows
            discount += CDec(row.Cells(3).Value)
            amountApplied += CDec(row.Cells(6).Value)
            totalAmount += CDec(row.Cells(5).Value)
        Next
        lblTotalAmountApplied.Text = amountApplied.ToString("N")
        lblTotAmount.Text = totalAmount.ToString("N")
        lblTotDiscount.Text = discount.ToString("N")
        lblOutBalance.Text = (CDec(lblTotalAmountReceived.Text - amountApplied)).ToString("N")
    End Sub

    Private Sub chkCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheck.CheckedChanged
        If chkCheck.Checked = True Then
            groupCheck.Enabled = True
            chkCash.Checked = False
            groupCash.Enabled = False
            txtCashAmount.Text = "0.00"
        Else
            groupCheck.Enabled = False
        End If
    End Sub

    Private Sub chkCash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCash.CheckedChanged
        If chkCash.Checked = True Then
            groupCash.Enabled = True
            chkCheck.Checked = False
            txtCheckAmount.Text = "0.00"
            groupCheck.Enabled = False
        Else
            groupCash.Enabled = False
        End If
    End Sub

    Private Sub txtDepositAcc_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepositAcc.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtDepositAcc.Text
        AC.get_accountInfo()
        txtAccountDesc.Text = AC.accDesc
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ss As New systemSettings_class
        frmAccountList.mode = ""
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtDepositAcc.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
            ss.settingsName = Me.Text & "_PaymentDepositACC"
            ss.settingsValue = txtDepositAcc.Text
            ss.insert_update_settingsVariable()
        End If
    End Sub

    Private Sub sumAmountApplied()
        Throw New NotImplementedException
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Try
            If dgv.CurrentCell.ColumnIndex = 3 Then
                Dim discount As Double = InputBox("Enter the Discount Amount you apply", "Discount Amount Apply")
                dgv.CurrentRow.Cells(3).Value = Format(discount, "N")
                dgv.CurrentRow.Cells(5).Value = Format(CDec(dgv.CurrentRow.Cells(2).Value) - discount - CDec(dgv.CurrentRow.Cells(4).Value), "N")
            ElseIf dgv.CurrentCell.ColumnIndex = 6 Then
                Dim amountApplied As Double = InputBox("Enter the amount you apply", "Amount Apply")
                If CDec(dgv.CurrentRow.Cells(3).Value) > CDec(amountApplied) Then
                    MsgBox("The amount you applied is not greater than discount you applied. Please input correctly", MsgBoxStyle.Critical, "SYSTEM INFORMATION")
                    Exit Sub
                ElseIf CDec(dgv.CurrentRow.Cells(5).Value) < CDec(amountApplied) Then
                    MsgBox("You Applied Greater than amount payable of this invoice. system will adjust the applied payment amount", MsgBoxStyle.Exclamation, "SYSTEM REMINDER")
                    dgv.CurrentRow.Cells(6).Value = dgv.CurrentRow.Cells(5).Value
                    Exit Sub
                End If
                dgv.CurrentRow.Cells(6).Value = Format(amountApplied, "N")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        sum_value()
    End Sub

    Private Sub txtCashAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCashAmount.TextChanged
        Try
            lblTotalAmountReceived.Text = CDec(txtCashAmount.Text).ToString("N")
            sum_value()
        Catch ex As Exception
            lblTotalAmountReceived.Text = "0.00"
        End Try
    End Sub

    Private Sub txtCheckAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCheckAmount.TextChanged
        Try
            lblTotalAmountReceived.Text = CDec(txtCheckAmount.Text).ToString("N")
            sum_value()
        Catch ex As Exception
            lblTotalAmountReceived.Text = "0.00"
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        For Each row As DataGridViewRow In dgv.SelectedRows
            dgv.Rows.Remove(row)
        Next
    End Sub

    Private Sub txtCustomerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerName.TextChanged
        'get_invoice_list()
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub chkCollection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCollection.CheckedChanged
        If chkCollection.Checked = True Then
            txtCollection.Visible = True
        Else
            txtCollection.Visible = False
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim ss As New systemSettings_class
        frmAccountList.mode = ""
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtDiscountAcc.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
            ss.settingsName = Me.Text & "_PaymentDiscountACC"
            ss.settingsValue = txtDiscountAcc.Text
            ss.insert_update_settingsVariable()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountAcc.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtDiscountAcc.Text
        AC.get_accountInfo()
        lblDiscountAcc.Text = AC.accDesc
    End Sub

    Private Sub txtChequeNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChequeNo.TextChanged

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim ss As New systemSettings_class
        frmAccountList.mode = ""
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtRecvAccount.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
            ss.settingsName = Me.Text & "_ReceivableACC"
            ss.settingsValue = txtRecvAccount.Text
            ss.insert_update_settingsVariable()
        End If
    End Sub

    Private Sub txtRecvAccount_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecvAccount.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtRecvAccount.Text
        AC.get_accountInfo()
        lblRecvAccount.Text = AC.accDesc
    End Sub
End Class