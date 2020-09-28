Imports System.Data.SqlClient

Public Class frmManageBank
    Public command As Integer
    Private Sub frmManageBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateBankID()
        get_bankList()
    End Sub
    Sub CLEAR()
        generateBankID()
        get_bankList()
        txtDesc.Text = ""
        txtAccName.Text = ""
        txtAccAsset.Text = ""
        txtBal.Text = "0.00"
        btnSave.Text = "ADD"
    End Sub

    Sub generateBankID()
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
                .CommandText = "SELECT bankID from tblBank order by bankID DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 1, Len(OleDBDR(0)))
                txtID.Text = Format(Val(StrID) + 1, "00000")
            Else
                txtID.Text = "00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub get_bankList()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select id,description,balance,'0.00',Status from get_Banklist", conn)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            Dim c As Integer
            dgv.Rows.Clear()
            For Each row As DataRow In dt.Rows
                dgv.Rows.Add()
                dgv.Item(0, c).Value = row(0)
                dgv.Item(1, c).Value = row(1)
                dgv.Item(2, c).Value = row(2)
                dgv.Item(3, c).Value = row(3)
                dgv.Item(4, c).Value = row(4)
                c += 1
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            txtAccAsset.Text = frmAccountList.dgv.CurrentRow.Cells(0).Value
        End If
    End Sub

    Private Sub txtAccAsset_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccAsset.TextChanged
        Dim AC As New Account_Class
        AC.searchValue = txtAccAsset.Text
        AC.get_accountInfo()
        lblAccAsset.Text = AC.accDesc
    End Sub

    Private Sub txtBal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBal.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If

    End Sub
    Sub save()
        If MsgBox("Are You Sure ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim ac As New accEntry_class
            Dim bc As New bank_class
            bc.command = command
            bc.bankID = txtID.Text
            bc.bankDesc = txtDesc.Text
            bc.accountName = txtAccName.Text
            bc.accNo = txtAccAsset.Text
            bc.status = "Active"
            bc.insert_update_bank()
            If CDec(txtBal.Text) <> 0 Then
                ac.refno = txtID.Text
                ac.SRC = Me.Text
                ac.account = txtAccAsset.Text
                ac.memo = "Beginning Balance"

                If CDec(txtBal.Text) < 0 Then
                    ac.debit = 0
                    ac.credit = CDec(txtBal.Text) * CDec(txtBal.Text)
                ElseIf CDec(txtBal.Text) > 0 Then
                    ac.debit = CDec(txtBal.Text)
                    ac.credit = 0
                Else
                End If
                ac.insert_Acc_entry_class()
            End If
            MsgBox("Bank Added Successfully !", MsgBoxStyle.Information, "Success")
            CLEAR()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "ADD" Then
            command = 0
        ElseIf btnSave.Text = "UPDATE" Then
            command = 1
        End If
        save()
    End Sub

    Private Sub UPDATEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPDATEToolStripMenuItem.Click
        Dim BC As New bank_class
        txtID.Text = dgv.CurrentRow.Cells(0).Value
        BC.bankID = dgv.CurrentRow.Cells(0).Value
        BC.get_bankInfo()
        txtDesc.Text = BC.bankDesc
        txtAccName.Text = BC.accountName
        txtAccAsset.Text = BC.accNo
        btnSave.Text = "UPDATE"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CLEAR()
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub dgv_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseClick
    End Sub

    Private Sub dgv_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgv.CurrentCell = dgv(e.ColumnIndex, e.RowIndex)
                dgv.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.MouseLeave
        dgv.ContextMenuStrip = Nothing
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub INACTIVEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INACTIVEToolStripMenuItem.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "Are you sure?") = MsgBoxResult.Yes Then
            checkConn()
            Dim cmd As New SqlCommand("update tblBank set Status = 'Inactive' where bankID = '" & dgv.CurrentRow.Cells(0).Value & "'", conn)
            cmd.ExecuteNonQuery()
            MsgBox("Success", MsgBoxStyle.Information)
        End If
        CLEAR()
    End Sub

    Private Sub ActiveBankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiveBankToolStripMenuItem.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "Are you sure?") = MsgBoxResult.Yes Then
            checkConn()
            Dim cmd As New SqlCommand("update tblBank set Status = 'Active' where bankID = '" & dgv.CurrentRow.Cells(0).Value & "'", conn)
            cmd.ExecuteNonQuery()
            MsgBox("Success", MsgBoxStyle.Information)
        End If
        CLEAR()
    End Sub
End Class