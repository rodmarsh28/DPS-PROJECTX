Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class TransactionViewer
    Dim rowIndex As Integer
    Public MODE As String
    Dim cardID As String
    Dim cardName As String
    Dim payment As String
    Public DT As New DataTable


    Sub get_info_purchaseOrder()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select distinct tblCardsProfile.cardID,tblCardsProfile.cardName,PAYMENT from tblPurchaseOrder inner join tblCardsProfile on tblPurchaseOrder.cardid = tblCardsProfile.cardid where purchaseOrderNo = '" & LV.SelectedItems(0).SubItems(1).Text & "'", conn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                cardID = dr.Item(0)
                cardName = dr.Item(1)
                payment = dr.Item(2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub loadData()
        If MODE = "GET_REQUISITION" Then
            get_pending_requisition()
        ElseIf MODE = "GET_PURCHASEORDER" Then
            get_pending_purchaseOrder()
        ElseIf MODE = "GET_RFP" Then
            get_pending_RFP()
        ElseIf MODE = "GET_CV" Then
            get_pending_checkVoucher()
        ElseIf MODE = "GET_CASH_REQUISITION" Then
            get_pending_cash_requisition()
        End If
    End Sub
    Sub get_pending_requisition()
        Dim dt As New DataTable
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_requisition_data", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = 0
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = txtSearch.Text
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            LV.Items.Clear()
            LV.Columns.Clear()
            For Each col As DataColumn In dt.Columns
                LV.Columns.Add(col.ToString)
            Next
            For Each row As DataRow In dt.Rows
                Dim lst As ListViewItem
                lst = LV.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
                For i As Integer = 1 To dt.Columns.Count - 1
                    lst.SubItems.Add(If(row(i) IsNot Nothing, row(i).ToString, ""))
                Next
            Next
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            If rowIndex < LV.Items.Count Then
                LV.Items(rowIndex).Selected = True
            End If
            lblItemCount.Text = Format(LV.Items.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub get_pending_cash_requisition()
        Dim dt As New DataTable
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_cash_requisition_list", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = Command()
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = txtSearch.Text
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            LV.Items.Clear()
            LV.Columns.Clear()
            For Each col As DataColumn In dt.Columns
                LV.Columns.Add(col.ToString)
            Next
            For Each row As DataRow In dt.Rows
                Dim lst As ListViewItem
                lst = LV.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
                For i As Integer = 1 To dt.Columns.Count - 1
                    lst.SubItems.Add(If(row(i) IsNot Nothing, row(i).ToString, ""))
                Next
            Next
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            If rowIndex < LV.Items.Count Then
                LV.Items(rowIndex).Selected = True
            End If
            lblItemCount.Text = Format(LV.Items.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Sub get_pending_purchaseOrder()
        Dim dt As New DataTable
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_PurchaseOrder_list", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = txtSearch.Text
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            LV.Items.Clear()
            LV.Columns.Clear()
            For Each col As DataColumn In dt.Columns
                LV.Columns.Add(col.ToString)
            Next
            For Each row As DataRow In dt.Rows
                Dim lst As ListViewItem
                lst = LV.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
                For i As Integer = 1 To dt.Columns.Count - 1
                    lst.SubItems.Add(If(row(i) IsNot Nothing, row(i).ToString, ""))
                Next
            Next
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            If rowIndex < LV.Items.Count Then
                LV.Items(rowIndex).Selected = True
            End If
            lblItemCount.Text = Format(LV.Items.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub get_pending_RFP()
        Dim dt As New DataTable
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_RFP_list", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = txtSearch.Text
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            LV.Items.Clear()
            LV.Columns.Clear()
            For Each col As DataColumn In dt.Columns
                LV.Columns.Add(col.ToString)
            Next
            For Each row As DataRow In dt.Rows
                Dim lst As ListViewItem
                lst = LV.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
                For i As Integer = 1 To dt.Columns.Count - 1
                    lst.SubItems.Add(If(row(i) IsNot Nothing, row(i).ToString, ""))
                Next
            Next
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            If rowIndex < LV.Items.Count Then
                LV.Items(rowIndex).Selected = True
            End If
            lblItemCount.Text = Format(LV.Items.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub get_pending_checkVoucher()
        Dim dt As New DataTable
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_checkVoucher_list", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = txtSearch.Text
                .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = 0
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            LV.Items.Clear()
            LV.Columns.Clear()
            For Each col As DataColumn In dt.Columns
                LV.Columns.Add(col.ToString)
            Next
            For Each row As DataRow In dt.Rows
                Dim lst As ListViewItem
                lst = LV.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
                For i As Integer = 1 To dt.Columns.Count - 1
                    lst.SubItems.Add(If(row(i) IsNot Nothing, row(i).ToString, ""))
                Next
            Next
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            If rowIndex < LV.Items.Count Then
                LV.Items(rowIndex).Selected = True
            End If
            lblItemCount.Text = Format(LV.Items.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub TransactionViewer_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub


    Private Sub TransactionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        loadData()
    End Sub

    Private Sub LV_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV.MouseClick
        Try
            If e.Button = MouseButtons.Right Then
                If LV.SelectedItems.Count > 0 Then
                    If MODE = "GET_REQUISITION" Then
                        LV.ContextMenuStrip = cmsRequisition
                    ElseIf MODE = "GET_PURCHASEORDER" Then
                        LV.ContextMenuStrip = cmsPurchaseOrder
                    ElseIf MODE = "GET_RFP" Then
                        LV.ContextMenuStrip = cmsRFP
                    ElseIf MODE = "GET_CV" Then
                        LV.ContextMenuStrip = cmsCV
                    ElseIf MODE = "GET_CASH_REQUISITION" Then
                        LV.ContextMenuStrip = cmsCashRequisition
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmsRequisition_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles cmsRequisition.Closing
        LV.ContextMenuStrip = disable_context
    End Sub

    Private Sub IssueRequisitionSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IssueRequisitionSlipToolStripMenuItem.Click

    End Sub

    Private Sub PreparePurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreparePurchaseOrderToolStripMenuItem.Click
        frmPurchases.txtRefNo.Text = LV.SelectedItems(0).SubItems(1).Text
        frmPurchases.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        get_info_purchaseOrder()
        frmPurchasedReceiving.txtRefNo.Text = LV.SelectedItems(0).SubItems(1).Text
        frmPurchasedReceiving.cardID = cardID
        frmPurchasedReceiving.txtName.Text = cardName
        If payment = "CREDIT" Then
            frmPurchasedReceiving.cmbPayment.SelectedIndex = 0
        ElseIf payment = "CASH" Then
            frmPurchasedReceiving.cmbPayment.SelectedIndex = 1
        End If
        frmPurchasedReceiving.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        frmCheckVoucher.txtAmount.Text = LV.SelectedItems(0).SubItems(2).Text
        frmCheckVoucher.txtReqNo.Text = LV.SelectedItems(0).SubItems(1).Text
        frmCheckVoucher.txtAmount.Enabled = False
        frmCheckVoucher.ShowDialog()

    End Sub

    Private Sub PrepareCheckPrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareCheckPrintToolStripMenuItem.Click
        Try
            If LV.SelectedItems(0).SubItems(4).Text Like "Approved by *" Then
                Dim AC As New Accounting_class
                AC.command = 1
                AC.searchValue = LV.SelectedItems(0).SubItems(1).Text
                AC.GET_CV_DATA()
                Dim type As String = AC.dtable.Rows(0).Item(2).ToString
                If type = "CASH" Then
                    frmIssueCash.cardID = LV.SelectedItems(0).SubItems(2).Text
                    frmIssueCash.txtRefNo.Text = LV.SelectedItems(0).SubItems(1).Text
                    frmIssueCash.txtAmount.Text = LV.SelectedItems(0).SubItems(3).Text
                    frmIssueCash.ShowDialog()
                ElseIf type = "CHECK" Then
                    AC.cardID = LV.SelectedItems(0).SubItems(2).Text
                    AC.get_card_info()
                    frmCheckPrint.txtRefNo.Text = LV.SelectedItems(0).SubItems(1).Text
                    frmCheckPrint.cardID = AC.cardID
                    frmCheckPrint.txtPayee.Text = AC.cardName
                    For Each ROW As DataRow In AC.dtable.Rows
                        frmCheckPrint.txtRemarks.Text = ROW(7)
                    Next
                    frmCheckPrint.txtTotAmount.Text = CDbl(LV.SelectedItems(0).SubItems(3).Text).ToString("N")
                    frmCheckPrint.ShowDialog()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub PrepareCheckVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Warning") = MsgBoxResult.Yes Then
            Dim ac As New Accounting_class
            ac.command = 1
            ac.searchValue = LV.SelectedItems(0).SubItems(1).Text
            ac.get_cash_requisition_data_to_prep_cv()
            For Each row As DataRow In DT.Rows
                frmCheckVoucher.txtReqNo.Text = row(0)
                frmCheckVoucher.cardID = row(1)
                frmCheckVoucher.txtPayee.Text = row(2)
                frmCheckVoucher.txtAddress.Text = row(3)
                frmCheckVoucher.txtAmount.Text = CDec(row(4)).ToString("N")
                frmCheckVoucher.dgvPart.Rows.Add(row(5), row(6), CDec(row(7)).ToString("N"), CDec(row(8)).ToString("N"), row(9))
            Next
            frmCheckVoucher.ShowDialog()
        End If
    End Sub

    Private Sub ApproveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApproveToolStripMenuItem.Click
        If LV.SelectedItems(0).SubItems(4).Text <> "Waiting for Approval" Then
            MsgBox("You can't do that", MsgBoxStyle.Critical, "System Information")
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Warning") = MsgBoxResult.Yes Then
            Dim ac As New Accounting_class
            ac.transNo = LV.SelectedItems(0).SubItems(1).Text
            ac.status = "Approved by UserID : " & MainForm.LBLID.Text
            ac.update_cash_requisition_status()
        End If
    End Sub
    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If GetActiveWindow = Me.Handle Then
            loadData()
        End If
    End Sub

    Private Sub LV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV.SelectedIndexChanged
        Try
            rowIndex = LV.FocusedItem.Index
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PrintCheckVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCheckVoucherToolStripMenuItem.Click
        Dim ac As New Accounting_class
        If LV.SelectedItems(0).SubItems(4).Text Like "Check No.*" Then
            ac.command = 1
        ElseIf LV.SelectedItems(0).SubItems(4).Text Like "Cash Issued*" Then
            ac.command = 3
        Else
            ac.command = 0
        End If
        ac.searchValue = LV.SelectedItems(0).SubItems(1).Text
        ac.GET_CHECK_VOUCHER_FORPRINT()
    End Sub

    Private Sub PrintCashCheckRequisitionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCashCheckRequisitionToolStripMenuItem.Click
        Dim ac As New Accounting_class
        ac.searchValue = LV.SelectedItems(0).SubItems(1).Text
        ac.GET_CASH_REQUISISTION_FORPRINT()
    End Sub

    Private Sub ApproveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApproveToolStripMenuItem1.Click
        If LV.SelectedItems(0).SubItems(4).Text Like "Approved by UserID*" Then
            MsgBox("You can't do that", MsgBoxStyle.Critical, "System Information")
            Exit Sub
        End If
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Warning") = MsgBoxResult.Yes Then
            Dim ac As New Accounting_class
            ac.transNo = LV.SelectedItems(0).SubItems(1).Text
            ac.status = "Approved by UserID : " & MainForm.LBLID.Text
            ac.update_checkvoucher_status()
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If LV.SelectedItems(0).SubItems(4).Text <> "Waiting for Approval" Then
            MsgBox("You can't update if request is approved", MsgBoxStyle.Critical, "System Reminders")
            Exit Sub
        End If
        Dim ac As New Accounting_class
        ac.command = 2
        ac.searchValue = LV.SelectedItems(0).SubItems(1).Text
        ac.GET_CASH_FOR_UPDATE()
        For Each row As DataRow In ac.dtable.Rows
            frmCashRequisition.txtNo.Text = row(0)
            frmCashRequisition.txtCardID.Text = row(2)
            frmCashRequisition.txtCardName.Text = row(3)
            frmCashRequisition.dgv.Rows.Add(row(4), CDec(row(5)).ToString("N"), CDec(row(6)).ToString("N"))
            frmCashRequisition.txtRemarks.Text = row(7)
            frmCashRequisition.notimesedit = row(8) + 1
        Next
        frmCashRequisition.updateTotValue()
        frmCashRequisition.btnSave.Text = "Update"
        frmCashRequisition.ShowDialog()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        If LV.SelectedItems(0).SubItems(4).Text <> "Waiting for Approval" Then
            MsgBox("You can't update if request is approved", MsgBoxStyle.Critical, "System Reminders")
            Exit Sub
        End If
        Dim ac As New Accounting_class
        ac.command = 1
        ac.searchValue = LV.SelectedItems(0).SubItems(1).Text
        ac.GET_CV_DATA()
        For Each row As DataRow In ac.dtable.Rows
            frmCheckVoucher.txtCVNo.Text = row(0)
            frmCheckVoucher.txtReqNo.Text = row(1)
            If row(2) = "CHECK" Then
                frmCheckVoucher.cmbType.SelectedIndex = 0
            ElseIf row(2) = "CASH" Then
                frmCheckVoucher.cmbType.SelectedIndex = 1
            End If
            frmCheckVoucher.txtTIN.Text = row(3)
            frmCheckVoucher.cardID = row(4)
            frmCheckVoucher.txtPayee.Text = row(5)
            frmCheckVoucher.txtAddress.Text = row(6)
            frmCheckVoucher.txtMemo.Text = row(7)
            frmCheckVoucher.txtAmount.Text = CDec(row(8)).ToString("N")
            frmCheckVoucher.dgvPart.Rows.Add(row(9), row(10), CDec(row(11)).ToString("N"), CDec(row(12)).ToString("N"), row(13))
            frmCheckVoucher.txtAmountinWords.Text = row(14)
        Next
        frmCheckVoucher.updateTotal()
        frmCheckVoucher.btnSave.Text = "Update"
        frmCheckVoucher.ShowDialog()
    End Sub
    Private Sub PrintPageHandler(ByVal sender As Object, ByVal args As PrintPageEventArgs)
        Dim lvwItem As ListViewItem
        Dim lvwSubItem As ListViewItem.ListViewSubItem
        Dim xPos As Integer = 0
        Dim yPos As Integer = 0
        yPos = 100
        Using headerFont As New Font("Arial", 10, FontStyle.Bold)
            xPos = 50
            For Each ch As ColumnHeader In LV.Columns
                args.Graphics.DrawString(ch.Text, headerFont, Brushes.Black, xPos, yPos)
                xPos += 130
            Next
        End Using
        yPos = 0
        Dim listviewcount As Integer = 1
        For Each lvwItem In LV.Items
            xPos = 50
            For Each lvwSubItem In lvwItem.SubItems
                yPos = 100 + (listviewcount * 15)
                args.Graphics.DrawString(lvwSubItem.Text(), _
                        New Font("Arial", 8, FontStyle.Regular), _
                        Brushes.Black, xPos, yPos)
                xPos += 130
            Next
            listviewcount += 1
        Next
        xPos = 50
        yPos = 130 + (LV.Items.Count.ToString + 3 * 15)
        args.Graphics.DrawString("Item's count: " & LV.Items.Count.ToString("N0"), _
                       New Font("Arial", 9, FontStyle.Bold), _
                       Brushes.Black, xPos, yPos)
    End Sub

    Private Sub PrepareCheckVoucherToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrepareCheckVoucherToolStripMenuItem.Click
        If LV.SelectedItems(0).SubItems(4).Text Like "Approved by UserID*" Then
            frmCheckVoucher.txtReqNo.Text = LV.SelectedItems(0).SubItems(1).Text
            frmCheckVoucher.ShowDialog()
        Else
            MsgBox("You can't do that", MsgBoxStyle.Critical, "System Information")
        End If
    End Sub

    Private Sub ToolStripStatusLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        Try

            Dim prn As New Printing.PrintDocument
            prn.PrinterSettings.PrinterName = My.Settings.printerName
            AddHandler prn.PrintPage, AddressOf Me.PrintPageHandler
            PrintPreviewDialog1.Document = prn
            PrintPreviewDialog1.ShowDialog()
            'prn.Print()
            'RemoveHandler prn.PrintPage, AddressOf Me.PrintPageHandler

        Catch ex As Exception
            MsgBox("Please setup printer", MsgBoxStyle.Critical, "System Information")
        End Try
    End Sub
End Class