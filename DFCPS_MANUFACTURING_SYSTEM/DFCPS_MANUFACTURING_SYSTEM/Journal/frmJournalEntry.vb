Public Class frmJournalEntry
    Dim command As Integer
    Public cardID As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmAccountList.successClick = False
        frmAccountList.ShowDialog()
        If frmAccountList.successClick = True Then
            dgv.Rows.Add(frmAccountList.dgv.CurrentRow.Cells(0).Value, "", txtmemo.text, "0.00", "0.00")
            dgv.ClearSelection()
        End If
    End Sub
    Sub generateNo()
        Try
            Dim SC As New systemSettings_class
            Dim NO As String
            Dim StrID As String
            SC.tableName = "tblGeneralJournal"
            SC.columnName = "GJNo"
            SC.series = "GJ-"
            SC.generateNo()
            StrID = Mid(SC.result, Len(SC.series) + 1, Len(SC.result))
            NO = SC.series & Format(Val(StrID) + 1, "00000")
            txtNo.Text = NO
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
    Sub rowUpdateFunc()
        Dim AC As New Account_Class
        Dim totDebit As Decimal = 0
        Dim totCredit As Decimal = 0
        Dim OB As Decimal = 0

        For Each row As DataGridViewRow In dgv.Rows
            AC.searchValue = row.Cells(0).Value
            AC.get_accountInfo()
            row.Cells(1).Value = AC.accDesc
            totDebit += CDec(row.Cells(3).Value)
            totCredit += CDec(row.Cells(4).Value)
            row.Cells(5).ReadOnly = True
            OB += CDec(row.Cells(3).Value) - CDec(row.Cells(4).Value)
        Next
        lblDebit.Text = totDebit.ToString("N")
        lblCredit.Text = totCredit.ToString("N")
        lblOB.Text = OB.ToString("N")
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Try
            If dgv.CurrentCell.ColumnIndex = 3 Then
                Dim dbt As Decimal = InputBox("Debit Value")
                dgv.CurrentRow.Cells(3).Value = Format(dbt, "N")
            ElseIf dgv.CurrentCell.ColumnIndex = 4 Then
                Dim cdt As Decimal = InputBox("Credit Value")
                dgv.CurrentRow.Cells(4).Value = Format(cdt, "N")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub dgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        rowUpdateFunc()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
            For Each row As DataGridViewRow In dgv.Rows
                dgv.Rows.Remove(row)
                rowUpdateFunc()
            Next
        End If
    End Sub
    Sub SAVE()
        Try
            If MsgBox("ARE YOU SURE YOU WANT TO SAVE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
                If btnSave.Text = "RECORD" Then
                    command = 0
                ElseIf btnSave.Text = "UPDATE" Then
                    command = 1
                End If
                Dim AC As New Accounting_class
                AC.command = command
                AC.transNo = txtNo.Text
                AC.transDate = dtpDate.Value.ToString("yyyy/MM/dd")
                AC.status = "Posted"
                AC.insert_generalJournal()
                saveAccEntry()
                MsgBox("This transaction is " & btnSave.Text & " successfully", MsgBoxStyle.Information, "System Information")
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub saveAccEntry()
        Dim ac As New accEntry_class
        ac.refno = txtNo.Text
        ac.SRC = Me.Text
        ac.cardID = cardID
        For Each row As DataGridViewRow In dgv.Rows
            ac.refno = txtNo.Text
            ac.account = row.Cells(0).Value
            ac.memo = row.Cells(2).Value
            ac.debit = row.Cells(3).Value
            ac.credit = row.Cells(4).Value
            ac.job = row.Cells(5).Value.text
            ac.insert_Acc_entry_class()
        Next
    End Sub
    Private Sub dgv_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        rowUpdateFunc()
    End Sub

    Private Sub frmJournalEntry_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmJournalEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateNo()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SAVE()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            frmCardListForSelection.formMode = ""
            frmCardListForSelection.ShowDialog()
            If frmCardListForSelection.itemClick = True Then
                cardID = frmCardListForSelection.LV.SelectedItems(0).SubItems(0).Text
                txtCardName.Text = frmCardListForSelection.LV.SelectedItems(0).SubItems(1).Text
                frmCardListForSelection.itemClick = False
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class