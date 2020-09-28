Imports System.Data.SqlClient

Public Class frmManageCheckbook
    Dim bankID As String
    Dim command As String

    Sub Clear()
        generateCheckbookID()
        txtBankName.Text = ""
        bankID = ""
        txtStartCheckNo.Text = ""
        txtEndCheckNo.Text = ""
        btnSave.Text = "ADD"
    End Sub
    Private Sub frmManageBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_bankList()
        generateCheckbookID()
    End Sub
    Sub generateCheckbookID()
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
                .CommandText = "SELECT checkbookID from tblcheckBook order by checkbookID DESC"
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
            Dim cmd As New SqlCommand("select id,description,'0.00','0.00',Status from get_Banklist", conn)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            Dim c As Integer
            dgvBL.Rows.Clear()
            For Each row As DataRow In dt.Rows
                dgvBL.Rows.Add()
                dgvBL.Item(0, c).Value = row(0)
                dgvBL.Item(1, c).Value = row(1)
                dgvBL.Item(2, c).Value = row(2)
                dgvBL.Item(3, c).Value = row(3)
                dgvBL.Item(4, c).Value = row(4)
                c += 1
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub get_checkbookList()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select Bank_Description,Checkbook_ID,Checkno_LastUsed,Checkno_End,'0.00' from get_Checkbooklist where Bank_ID = '" & dgvBL.CurrentRow.Cells(0).Value & "'", conn)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            Dim c As Integer
            dgvCL.Rows.Clear()
            For Each row As DataRow In dt.Rows
                dgvCL.Rows.Add()
                dgvCL.Item(0, c).Value = row(0)
                dgvCL.Item(1, c).Value = row(1)
                dgvCL.Item(2, c).Value = row(2)
                dgvCL.Item(3, c).Value = row(3)
                dgvCL.Item(4, c).Value = row(4)
                c += 1
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Sub save()
        Try
            If MsgBox("Are You Sure ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim bc As New bank_class
                bc.command = command
                bc.checkbookID = txtID.Text
                bc.bankID = bankID
                bc.startCheckNo = txtStartCheckNo.Text
                bc.endCheckNo = txtEndCheckNo.Text
                bc.lastCheckNo = txtStartCheckNo.Text
                bc.status = "Active"
                bc.insert_update_checkbook()
                MsgBox("Checkbook Added Successfully !", MsgBoxStyle.Information, "Success")
                get_checkbookList()
                Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvBL_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBL.CellMouseClick
        get_checkbookList()
    End Sub

  
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "ADD" Then
            command = 0
        ElseIf btnSave.Text = "UPDATE" Then
            command = 1
        End If
        If txtBankName.Text <> "" Then
            save()
        End If


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'formBankSelection.get_bankList()
        'formBankSelection.ShowDialog()
        'If formBankSelection.itemClicked = True Then
        '    bankID = formBankSelection.dgv.CurrentRow.Cells(0).Value
        '    txtBankName.Text = formBankSelection.dgv.CurrentRow.Cells(1).Value
        '    formBankSelection.itemClicked = False
        'End If
    End Sub

    Private Sub BankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankToolStripMenuItem.Click
        frmManageBank.ShowDialog()
        get_bankList()
    End Sub

    Private Sub UPDATEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPDATEToolStripMenuItem.Click
        Dim BC As New bank_class
        txtID.Text = dgvCL.CurrentRow.Cells(1).Value
        BC.checkbookID = txtID.Text
        BC.get_checkbookInfo()
        bankID = BC.bankID
        txtBankName.Text = BC.bankDesc
        txtStartCheckNo.Text = BC.startCheckNo
        txtEndCheckNo.Text = BC.endCheckNo
        btnSave.Text = "UPDATE"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Clear()
    End Sub
    Private Sub btnSave_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.TextChanged
        If btnSave.Text = "ADD" Then
            txtBankName.Enabled = True
        ElseIf btnSave.Text = "UPDATE" Then
            txtBankName.Enabled = False
        End If
    End Sub

    Private Sub dgvCL_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCL.CellContentClick

    End Sub

    Private Sub dgvCL_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvCL.CellMouseDown
        Try
        If e.Button = MouseButtons.Right Then
            dgvCL.CurrentCell = dgvCL(e.ColumnIndex, e.RowIndex)
            dgvCL.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        dgvCL.ContextMenuStrip = Nothing
    End Sub


    Private Sub dgvBL_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBL.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgvBL.CurrentCell = dgvBL(e.ColumnIndex, e.RowIndex)
                dgvBL.ContextMenuStrip = ContextMenuStrip2
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip2_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles ContextMenuStrip2.Closed
        dgvBL.ContextMenuStrip = Nothing
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        bankID = dgvBL.CurrentRow.Cells(0).Value
        txtBankName.Text = dgvBL.CurrentRow.Cells(1).Value
    End Sub
End Class