Public Class frmItemRequisition
    Public departmentID As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtQty.Text = "" Then
            txtQty.Text = "1"
        End If
        InventoryList.mode = "Item Requisition"
        InventoryList.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        DepartmentList.mode = "Item Requisition"
        DepartmentList.ShowDialog()
    End Sub

    Sub generateNo()
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
                .CommandText = "SELECT requisition_no from item_requisition order by requisition_no DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                strID = OleDBDR.Item(0).Substring(OleDBDR.Item(0).Length - 5)
                txtNo.Text = "REQ-" & Format(Val(strID) + 1, "00000")
            Else
                txtNo.Text = "REQ-" & "00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        frmAccountList.mode = "Item Requisition"
        frmAccountList.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Are you sure to post this ?", MsgBoxStyle.YesNo, "Are You Sure ?") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        Dim requisition As New Puchase_Requisition_class
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgv.RowCount
        While col < row1
            requisition.requisitionNo = txtNo.Text
            requisition.DepartmentNo = departmentID
            requisition.remarks = txtRemarks.Text
            requisition.itemCode = dgv.Item(0, col).Value
            requisition.Desc = dgv.Item(1, col).Value
            requisition.unit = dgv.Item(2, col).Value
            requisition.onhand = dgv.Item(3, col).Value
            requisition.qty = dgv.Item(4, col).Value
            requisition.insert_update_itemrequisition()
            col = col + 1
        End While

        MsgBox("ITEM REQUISITION POSTED !", MsgBoxStyle.Information, "SUCCESS")
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmItemRequisition_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control Then
            For Each row As DataGridViewRow In dgv.SelectedRows
                dgv.Rows.Remove(row)
            Next
        End If
    End Sub

    Private Sub frmItemRequisition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmPurchaseMain
        generateNo()
    End Sub
End Class