Imports System.Data.SqlClient

Public Class frmVoucher_Payable_List
    Dim Status As String
    Dim DT As New DataTable
    Public successClicked As Boolean
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmCardListForSelection.formMode = "PAYABLE"
        frmCardListForSelection.ShowDialog()
        Try
            If frmCardListForSelection.itemClick = True Then
                txtCardID.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(0).Text
                txtCardName.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(1).Text
                lblBalance.Text = CDbl(frmCardListForSelection.LV.SelectedItems(0).SubItems(4).Text).ToString("N")
                frmCardListForSelection.itemClick = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub GET_PAYABLES()
        If CheckBox1.Checked = True Then
            Status = "All"
        Else
            Status = "Open"
        End If
        Dim cmd As New SqlCommand("get_voucher_list", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = Status
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = txtCardID.Text

        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)
        dgv.Rows.Clear()
        For Each row As DataRow In dt.Rows
            dgv.Rows.Add(row(0), row(1), CDbl(row(4)).ToString("N"), row(5))
        Next
    End Sub

    Private Sub txtCardID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCardID.TextChanged
        GET_PAYABLES()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        GET_PAYABLES()
    End Sub

    Private Sub frmVoucher_Payable_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckBox1.Checked = False
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub


    Private Sub dgv_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv.MouseDown
        Try
            If e.Button = MouseButtons.Right Then
                If dgv.SelectedRows.Count > 0 Then
                    dgv.ContextMenuStrip = ContextMenuStrip1
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgv.ContextMenuStrip = Nothing
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub PaySelectedPayablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaySelectedPayablesToolStripMenuItem.Click
        frmCheckVoucher.mode = "Voucher"
        Dim AC As New Accounting_class
        Dim totFP As Decimal
        For Each row As DataGridViewRow In dgv.SelectedRows
            AC.command = 1
            AC.transNo = row.Cells(1).Value
            AC.GET_ACCNO_OF_TRNO()
            frmCheckVoucher.dgvPart.Rows.Add(row.Cells(1).Value, row.Cells(1).Value, row.Cells(2).Value, CDbl(0).ToString("N"), AC.accNo)
            totFP += CDbl(row.Cells(2).Value)
        Next
        AC.cardID = txtCardID.Text
        AC.get_card_info()
        frmCheckVoucher.cardID = txtCardID.Text
        frmCheckVoucher.txtPayee.Text = AC.cardName
        frmCheckVoucher.txtAddress.Text = AC.cardAddress
        frmCheckVoucher.lblFP.Text = totFP.ToString("N")
        frmCheckVoucher.ShowDialog()
    End Sub

    Private Sub PrintVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintVoucherToolStripMenuItem.Click
        Dim AC As New Accounting_class
        AC.transNo = dgv.CurrentRow.Cells(1).Value
        AC.PRINT_VOUCHER_SLIP()
    End Sub

    Private Sub txtCardName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCardName.TextChanged

    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton1.ButtonClick
        Dim ac As New Accounting_class
        ac.status = "Open"
        ac.searchValue = ""
        ac.get_open_voucher
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtCardID.Text = ""
        txtCardName.Text = ""
    End Sub
End Class