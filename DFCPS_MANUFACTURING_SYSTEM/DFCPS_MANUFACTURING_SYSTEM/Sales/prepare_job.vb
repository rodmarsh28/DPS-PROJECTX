Imports System.Data.SqlClient

Public Class prepare_job
    Public mode As String
    Public dsource
    Sub generateNo()
        Try
            Dim SC As New systemSettings_class
            Dim NO As String
            Dim StrID As String
            SC.tableName = "tblJoBOrder"
            SC.columnName = "JONO"
            SC.series = "JO-"
            SC.generateNo()
            StrID = Mid(SC.result, Len(SC.series) + 1, Len(SC.result))
            NO = SC.series & Format(Val(StrID) + 1, "00000")
            TXTJONO.Text = NO
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Public Sub get_card_id(ByVal id As String)
        Dim dt As New DataTable
        checkConn()
        Dim cmd As New SqlCommand(
        "SELECT " & _
        "dbo.tblCardsProfile.cardID, " & _
        "dbo.tblCardsProfile.cardName, " & _
        "dbo.tblCardsProfile.cardAddress " & _
        "FROM " & _
        "dbo.tblSalesOrder " & _
        "INNER JOIN " & _
        "dbo.tblCardsProfile ON " & _
        "dbo.tblSalesOrder.cardID = dbo.tblCardsProfile.cardID " & _
        "where tblSalesOrder.salesOrderNo = '" & id & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dt)
        For Each r As DataRow In dt.Rows
            cardid = r(0)
            cardname = r(1)
            TXTCUS.Text = r(1)
            cardAddress = r(2)
        Next

    End Sub
    Sub get_sales_order_items(ByVal id As String)
        Dim dt As New DataTable
        checkConn()
        Dim cmd As New SqlCommand(
        "SELECT dbo.tblSalesOrder.salesOrderNo, " & _
         "dbo.tblSalesItemsTR.itemNo, " & _
         "dbo.InventoryListAllView.ITEMDESC, " & _
         "dbo.InventoryListAllView.UNIT, " & _
         "dbo.tblSalesItemsTR.pc AS request_qty, " & _
         "dbo.InventoryListAllView.PC_QTY AS onhand_qty, dbo.tblSalesOrder.cardid  " & _
        "FROM " & _
        "dbo.tblSalesOrder " & _
         "INNER JOIN dbo.tblSalesItemsTR ON dbo.tblSalesOrder.salesOrderNo = dbo.tblSalesItemsTR.transNo " & _
         "INNER JOIN dbo.InventoryListAllView ON dbo.tblSalesItemsTR.itemNo = dbo.InventoryListAllView.ITEMNO " & _
         "where dbo.tblSalesOrder.salesOrderNo = '" & id & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dt)
        dgv.Rows.Clear()
        For Each r As DataRow In dt.Rows
            dgv.Rows.Add(r(1), r(2), r(3), r(4), r(5), r(4))
        Next

    End Sub
    Sub insert_update_jo()
        If mode = "Save" Then
            For Each r As DataGridViewRow In dgv.Rows
                Dim cmd As New SqlCommand("insert into tblJobOrder values('" & TXTJONO.Text & "', '" & Now & "','" & TXTREF.Text & "', '" & cardid & "','', '" & r.Cells(0).Value & "', '" & r.Cells(3).Value & "', '" & r.Cells(4).Value & "')", conn)
                checkConn()
                cmd.ExecuteNonQuery()
            Next
        Else
        End If
    End Sub
    Public cardid As String
    Public cardname As String
    Public cardAddress As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
            Try
            If mode = "Update" Then
                    update_info_data()
                    MsgBox("Transaction Saved", MsgBoxStyle.Information, "SYSTEM INFORMATION")
                    Me.Close()
            Else
                If insert_info_data() = "Success" Then
                    MsgBox("Transaction Saved", MsgBoxStyle.Information, "SYSTEM INFORMATION")
                    Me.Close()
                End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub prepare_job_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If mode = "Update" Then
        Else
            generateNo()
        End If

    End Sub

    Private Sub TXTREF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTREF.TextChanged
        If mode = "Update" Then
        Else

         
        End If


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        InventoryList.mode = "Order"
        InventoryList.ShowDialog()
        If InventoryList.clickedItem = True Then
            Dim r As Integer = dgv.Rows.Count
            With dgv
                .Rows.Add()
                .Item(0, r).Value = InventoryList.dgv.CurrentRow.Cells(0).Value
                .Item(1, r).Value = InventoryList.dgv.CurrentRow.Cells(1).Value
                .Item(2, r).Value = InventoryList.dgv.CurrentRow.Cells(2).Value
                .Item(3, r).Value = "0"
                .Item(4, r).Value = InventoryList.dgv.CurrentRow.Cells(4).Value
                .Item(5, r).Value = "0"
            End With
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For Each r As DataGridViewRow In dgv.SelectedRows
            dgv.Rows.Remove(r)
        Next
    End Sub

    Sub get_info_data(ByVal id As String)
        Dim sc As New sales_class
        For Each xdata In sc.get_info_data(id)
            TXTJONO.Text = xdata.JOB_NO
            TXTREF.Text = xdata.REFNO
            TXTCUS.Text = xdata.CUSTOMER
            cardid = xdata.cardid
            dgv.Rows.Add(xdata.ITEMNO, xdata.DESCRIPTION, xdata.UNIT, xdata.QTY, xdata.ONHAND_QTY, xdata.QTY)
        Next
    End Sub
    Function insert_info_data() As String
        Dim db_sales As New salesDataContext

        Dim jobs As New tblJobOrder
        jobs.JONO = TXTJONO.Text
        jobs.DATE = Now
        jobs.REFNO = TXTREF.Text
        jobs.CARDID = cardid
        jobs.REMARKS = ""
        db_sales.tblJobOrders.InsertOnSubmit(jobs)
        db_sales.SubmitChanges()
        For Each row As DataGridViewRow In dgv.Rows
            db_sales = New salesDataContext
            Dim j = New tblJob_item
            j.JONO = TXTJONO.Text
            j.ITEMCODE = row.Cells(0).Value
            j.QTY = CInt(row.Cells(5).Value)
            j.ONHAND_QTY = CInt(row.Cells(4).Value)
            db_sales.tblJob_items.InsertOnSubmit(j)
            db_sales.SubmitChanges()
        Next

        Try

            Return "Success"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function
    Sub update_info_data()
        Dim sc As New sales_class
        If sc.update_job_data(TXTJONO.Text, TXTREF.Text, cardid, "") = "Success" Then
            For Each row As DataGridViewRow In dgv.Rows
                If sc.update_job_items(TXTJONO.Text, row.Cells(0).Value, row.Cells(5).Value, row.Cells(4).Value, "") <> "Success" Then
                    Exit Sub
                End If
            Next
        End If
    End Sub


    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Try
            If dgv.CurrentCell.ColumnIndex = 5 Then
                Dim JOBQTY As Integer = InputBox("JOB QTY")
                dgv.CurrentRow.Cells(5).Value = JOBQTY.ToString("N0")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim sc As New sales_class
        Dim frm As New frmsales_list_selector
        frm.MODE = "SALES ORDER"
        frm.GET_SALE_LIST()
        frm.ShowDialog()
        If frm.successClick = True Then
            TXTREF.Text = frm.DGV.CurrentRow.Cells(1).Value
            get_sales_order_items(TXTREF.Text)
            get_card_id(TXTREF.Text)
        End If
    End Sub
End Class