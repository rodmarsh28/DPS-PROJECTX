Imports System.Data.SqlClient

Public Class prepare_job

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
    Sub get_card_id()
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
        "where tblSalesOrder.salesOrderNo = '" & TXTREF.Text & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dt)
        For Each r As DataRow In dt.Rows
            cardid = r(0)
            cardname = r(1)
            TXTCUS.Text = r(2)
            cardAddress = r(1)
        Next
     
    End Sub
    Sub get_sales_order_items()
        Dim dt As New DataTable
        checkConn()
        Dim cmd As New SqlCommand(
        "SELECT dbo.tblSalesOrder.salesOrderNo, " & _
         "dbo.tblSalesItemsTR.itemNo, " & _
         "dbo.InventoryListAllView.ITEMDESC, " & _
         "dbo.InventoryListAllView.UNIT, " & _
         "dbo.tblSalesItemsTR.qty AS request_qty, " & _
         "dbo.InventoryListAllView.QTY AS onhand_qty, dbo.tblSalesOrder.cardid  " & _
        "FROM " & _
        "dbo.tblSalesOrder " & _
         "INNER JOIN dbo.tblSalesItemsTR ON dbo.tblSalesOrder.salesOrderNo = dbo.tblSalesItemsTR.transNo " & _
         "INNER JOIN dbo.InventoryListAllView ON dbo.tblSalesItemsTR.itemNo = dbo.InventoryListAllView.ITEMNO " & _
         "where dbo.tblSalesOrder.salesOrderNo = '" & TXTREF.Text & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dt)
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
                Dim sc As New sales_class
                mode = "Save"
                insert_update_jo()
                sc.print_job_order(TXTJONO.Text)
                MsgBox("Success", MsgBoxStyle.Information, "System Information")
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub prepare_job_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateNo()
    End Sub

    Private Sub TXTREF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTREF.TextChanged
        get_sales_order_items()
        get_card_id()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        InventoryList.mode = "Order"
        InventoryList.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For Each r As DataGridViewRow In dgv.SelectedRows
            dgv.Rows.Remove(r)
        Next
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Try
            If dgv.CurrentCell.ColumnIndex = 5 Then
                Dim JOBQTY As Decimal = InputBox("JOB QTY")
                dgv.CurrentRow.Cells(5).Value = Format(JOBQTY, "N0")
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class