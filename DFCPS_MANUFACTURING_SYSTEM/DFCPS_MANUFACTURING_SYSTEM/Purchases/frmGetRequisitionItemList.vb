Imports System.Data.SqlClient

Public Class frmGetRequisitionItemList
    Dim dt As New DataTable
    Dim rowindex As Integer
    Public mouseclicked As Boolean
    Sub viewList_itemRequisition()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select itemno,[desc],req_qty from Item_requisition where requisition_no = '" & frmPurchases.txtRefNo.Text & "'", conn)
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
            If rowindex < LV.Items.Count Then
                LV.Items(rowindex).Selected = True
            End If
            lblItemCount.Text = Format(LV.Items.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub viewList_purchaseOrder()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select tblPurchaseOrder.itemNo,itemdesc,qty from tblPurchaseOrder inner join tblInvtry on tblinvtry.itemno = tblPurchaseOrder.itemno where purchaseOrderNo = '" & frmPurchasedReceiving.txtRefNo.Text & "'", conn)
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
            If rowindex < LV.Items.Count Then
                LV.Items(rowindex).Selected = True
            End If
            lblItemCount.Text = Format(LV.Items.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Sub get_pending_po()
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_PurchaseOrder_list", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = ""
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
            If rowindex < LV.Items.Count Then
                LV.Items(rowindex).Selected = True
            End If
            lblItemCount.Text = Format(LV.Items.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub frmGetRequisitionItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LV_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV.MouseDoubleClick
        If LV.SelectedItems.Count <= 0 Then
            mouseclicked = True
            Me.Close()
        End If
    End Sub

    Private Sub LV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV.SelectedIndexChanged

    End Sub
End Class