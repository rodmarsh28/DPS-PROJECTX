﻿Imports System.Data.SqlClient

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

            If mode = "Update" Then

                For Each r As DataGridViewRow In dgv.Rows
                    update_info_data(TXTJONO.Text, "")
                Next
                MsgBox("Transaction Saved", MsgBoxStyle.Information, "SYSTEM INFORMATION")
                Me.Close()


            Else
                If insert_info_data() = "Success" Then
                    MsgBox("Transaction Saved", MsgBoxStyle.Information, "SYSTEM INFORMATION")
                    Me.Close()
                End If
            End If
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
            get_sales_order_items()
            get_card_id()
        End If


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

    Sub get_info_data(ByVal id As String)
        Dim db_sales As New salesDataContext
        Dim data = From job In db_sales.tblJobOrders, jo_item In db_sales.tblJob_items, card In db_sales.tblCardsProfiles, item In db_sales.tblInvtries _
                   Where job.CARDID = card.cardID And job.JONO = jo_item.JONO And jo_item.ITEMCODE = item.ITEMNO And job.JONO = id
                   Select JOB_NO = job.JONO, REFNO = job.REFNO, cardid = job.CARDID, CUSTOMER = card.cardName, _
                                    ITEMNO = jo_item.ITEMCODE, DESCRIPTION = item.ITEMDESC, UNIT = item.UNIT, QTY = jo_item.QTY, ONHAND_QTY = jo_item.ONHAND_QTY, REMARKS = job.REMARKS


        For Each xdata In data
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
    Function update_info_data(ByVal id As String, ByVal remarks As String) As String
        Try
            Dim db_sales As New salesDataContext
            Dim data = (From jo In db_sales.tblJobOrders _
                        Where jo.JONO = id _
                        Select jo).FirstOrDefault
            data.DATE = Now
            data.JONO = id
            data.REFNO = TXTREF.Text
            data.CARDID = cardid
            data.REMARKS = ""
            db_sales.SubmitChanges()
            For Each row As DataGridViewRow In dgv.Rows
                Dim ITEMCODE As String = row.Cells(0).Value
                Dim dbx As New salesDataContext
                Dim X = (From jo_item In dbx.tblJob_items _
                        Where jo_item.JONO = id And jo_item.ITEMCODE = ITEMCODE _
                        Select jo_item).FirstOrDefault
                X.JONO = id
                X.ITEMCODE = row.Cells(0).Value
                X.QTY = CInt(row.Cells(5).Value)
                X.ONHAND_QTY = CInt(row.Cells(4).Value)
                dbx.SubmitChanges()
            Next
            Return "Success"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function


    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Try
            If dgv.CurrentCell.ColumnIndex = 5 Then
                Dim JOBQTY As Integer = InputBox("JOB QTY")
                dgv.CurrentRow.Cells(5).Value = JOBQTY.ToString("N0")
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class