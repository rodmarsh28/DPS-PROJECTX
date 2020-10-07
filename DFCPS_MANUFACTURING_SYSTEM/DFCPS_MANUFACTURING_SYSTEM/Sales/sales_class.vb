Imports System.Data.SqlClient

Public Class sales_class
    Public command As Integer
    Public commands As String
    Public transNo As String
    Public transcount As Integer
    Public transType As String
    Public refNo As String
    Public cardId As String
    Public remarks As String
    Public totFAmnt As Decimal
    Public totDiscount As Decimal
    Public totAmount As Decimal
    Public itemCode As String
    Public qty As Integer
    Public uprice As Decimal
    Public discount As Decimal
    Public amount As Decimal
    Public status As String
    Public checkno As String
    Public checkdate As DateTime
    Public amountApplied As Decimal
    Public outBalance As Decimal
    Public overallBal As Decimal
    Public accNo As String
    Public paymethod As String
    Public dtable As New DataTable
    Public searchValue As String
    Public cost As Decimal
    Public collectionNo As String
    Public dt As DataTable
    Public pc As Integer
    Public sales_db As New salesDataContext()
    Sub insert_update_sales()
        Dim cmd As New SqlCommand("insert_update_sales", conn)
        conn.Close()
        ConnectDatabase()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@processCount", SqlDbType.Int).Value = transcount
            .Parameters.AddWithValue("@salesMode", SqlDbType.VarChar).Value = transType
            .Parameters.AddWithValue("@salesno", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@refNo", SqlDbType.VarChar).Value = refNo
            .Parameters.AddWithValue("@cardID", SqlDbType.VarChar).Value = cardId
            .Parameters.AddWithValue("@totFAmnt", SqlDbType.Decimal).Value = totFAmnt
            .Parameters.AddWithValue("@totDis", SqlDbType.Decimal).Value = totDiscount
            .Parameters.AddWithValue("@totalAmount", SqlDbType.Decimal).Value = totAmount
            .Parameters.AddWithValue("@userid", SqlDbType.VarChar).Value = MainForm.LBLID.Text
            .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status
            .Parameters.AddWithValue("@itemNo", SqlDbType.VarChar).Value = itemCode
            .Parameters.AddWithValue("@qty", SqlDbType.Int).Value = qty
            .Parameters.AddWithValue("@uprice", SqlDbType.Decimal).Value = uprice
            .Parameters.AddWithValue("@amount", SqlDbType.Decimal).Value = amount
            .Parameters.AddWithValue("@discount", SqlDbType.Decimal).Value = discount
            .Parameters.AddWithValue("@cost", SqlDbType.Decimal).Value = cost
            .Parameters.AddWithValue("@pcQTY", SqlDbType.Decimal).Value = pc
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Sub recieve_payments()
        Dim cmd As New SqlCommand("insert_ReceivedPayments", conn)
        conn.Close()
        ConnectDatabase()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@paymentNo", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@paymethod", SqlDbType.VarChar).Value = paymethod
            .Parameters.AddWithValue("@cardID", SqlDbType.VarChar).Value = cardId
            .Parameters.AddWithValue("@userid", SqlDbType.VarChar).Value = MainForm.LBLID.Text
            .Parameters.AddWithValue("@checkno", SqlDbType.VarChar).Value = checkNo
            .Parameters.AddWithValue("@checkdate", SqlDbType.Date).Value = checkdate.ToString("yyyy/MM/dd")
            .Parameters.AddWithValue("@amountReceived", SqlDbType.Decimal).Value = totAmount
            .Parameters.AddWithValue("@outOFBalance", SqlDbType.Decimal).Value = outBalance
            .Parameters.AddWithValue("@overAllBalance", SqlDbType.Decimal).Value = overallBal
            .Parameters.AddWithValue("@invoiceNo", SqlDbType.VarChar).Value = refNo
            .Parameters.AddWithValue("@amountDiscount", SqlDbType.Decimal).Value = discount
            .Parameters.AddWithValue("@amountApplied", SqlDbType.Decimal).Value = amountApplied
            .Parameters.AddWithValue("@depositToAccount", SqlDbType.VarChar).Value = accNo
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Sub insert_collection()
        Dim cmd As New SqlCommand("insert_collection", conn)
        conn.Close()
        ConnectDatabase()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@collectionNo", SqlDbType.VarChar).Value = collectionNo
            .Parameters.AddWithValue("@paymentNo", SqlDbType.VarChar).Value = transNo
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Sub get_invoice_list()
        checkConn()
        Dim cmd As New SqlCommand("get_invoice_list", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@recvaccNo", SqlDbType.VarChar).Value = accNo
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_sales_items()
        checkConn()
        Dim cmd As New SqlCommand("get_sales_items", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = commands
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_order_no()
        checkConn()
        Dim cmd As New SqlCommand("SELECT dbo.[Sales Invoice].refNo FROM dbo.[Sales Invoice] where [No] = '" & searchValue & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Public Sub update_salesQuotation_status(ByVal id As String, ByVal status As String)
        checkConn()
        Dim cmd As New SqlCommand("update tblSalesQuotation set status = '" & status & "' where Quoteno = '" & id & "'", conn)
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub update_salesOrder_status(ByVal id As String, ByVal status As String)
        checkConn()
        Dim cmd As New SqlCommand("update tblSalesOrder set status = '" & status & "' where salesOrderNo = '" & id & "'", conn)
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub update_salesCharge_status(ByVal id As String, ByVal status As String)
        checkConn()
        Dim cmd As New SqlCommand("update tblSalesChargeInvoice set status = '" & status & "' where salesChargeInvoiceNo = '" & id & "'", conn)
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub update_salesCash_status(ByVal id As String, ByVal status As String)
        checkConn()
        Dim cmd As New SqlCommand("update tblSalesCashInvoice set status = '" & status & "' where salesCashInvoiceNo = '" & id & "'", conn)
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub update_salesDeliver_status(ByVal id As String, ByVal status As String)
        checkConn()
        Dim cmd As New SqlCommand("update tblSalesDeliver set status = '" & status & "' where salesDeliverNo = '" & id & "'", conn)
        cmd.ExecuteNonQuery()
    End Sub

    Sub prepareJob()
        Dim cmd As New SqlCommand("SELECT * FROM JOB_PREPARATION_VIEW where TRNO = '" & searchValue & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Public  Function get_info_data(ByVal id As String)
        Dim db_sales As New salesDataContext
        Dim data = From job In db_sales.tblJobOrders, jo_item In db_sales.tblJob_items, card In db_sales.tblCardsProfiles, item In db_sales.tblInvtries, u In db_sales.tblItem_units _
                   Where job.CARDID = card.cardID And job.JONO = jo_item.JONO And jo_item.ITEMCODE = item.ITEMNO And job.JONO = id
                   Select JOB_NO = job.JONO, REFNO = job.REFNO, trDATE = job.DATE, cardid = job.CARDID, CUSTOMER = card.cardName, _
                                    ITEMNO = jo_item.ITEMCODE, DESCRIPTION = item.ITEMDESC, UNIT = u.unit_desc, QTY = jo_item.QTY, ONHAND_QTY = jo_item.ONHAND_QTY, REMARKS = job.REMARKS Distinct
        Return data
    End Function
    Public Overridable Function update_job_data(ByVal id As String, ByVal ref As String, ByVal cardid As String, ByVal remarks As String) As String
        Try
            Dim db_sales As New salesDataContext
            Dim data = (From jo In db_sales.tblJobOrders _
                        Where jo.JONO = id _
                        Select jo).FirstOrDefault
            data.DATE = Now
            data.JONO = id
            data.REFNO = ref
            data.CARDID = cardid
            data.REMARKS = remarks
            db_sales.SubmitChanges()
            Return "Success"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Overridable Function update_job_items(ByVal id As String, ByVal itemcode As String, ByVal qty As String, ByVal onhand_qty As String, ByVal remarks As String) As String
        Try
            Dim dbx As New salesDataContext
            Dim X = (From jo_item In dbx.tblJob_items _
                    Where jo_item.JONO = id And jo_item.ITEMCODE = itemcode _
                    Select jo_item).FirstOrDefault
            X.JONO = id
            X.ITEMCODE = itemcode
            X.QTY = CInt(qty)
            X.ONHAND_QTY = CInt(onhand_qty)
            dbx.SubmitChanges()
            Return "Success"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Sub print_DR(ByVal id As String)
        Dim ds As New sales_dsTableAdapters.DRTABLETableAdapter
        Dim dt As New sales_ds
        ds.Fill(dt.Tables("DRTABLE"), id)

        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        rptDoc = New rpt_drandgp
        rptDoc.SetDataSource(dt.Tables("DRTABLE"))
        print_slip_viewer.CrystalReportViewer1.ReportSource = rptDoc
        print_slip_viewer.ShowDialog()
    End Sub
  
    Sub print_sales(ByVal id As String, ByVal form As String)
        Dim ds As New sales_dsTableAdapters.salesTA
        Dim dt As New sales_ds
        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        rptDoc = New rpt_sales
        If form = "QUOTATION" Then
            ds.qryQuote(dt.Tables("salesTable"), id)
        ElseIf form = "SALES ORDER" Then
            ds.qryOrder(dt.Tables("salesTable"), id)
        ElseIf form = "SALES CASH INVOICE" Then
            ds.qryCash(dt.Tables("salesTable"), id)
        ElseIf form = "SALES CHARGE INVOICE" Then
            ds.qryCharge(dt.Tables("salesTable"), id)
        ElseIf form = "SALES DELIVER" Then
            ds.qryDeliver(dt.Tables("salesTable"), id)
        End If
        rptDoc.SetDataSource(dt.Tables("salesTable"))
        print_slip_viewer.CrystalReportViewer1.ReportSource = rptDoc
        rptDoc.SetParameterValue("title", form)
        print_slip_viewer.ShowDialog()
    End Sub
    Sub print_job_order(ByVal jono As String)
        checkConn()
        Dim ds As New sales_ds
        Dim dt As New DataTable
        Dim cmd As New SqlCommand(
        "SELECT " & _
        "tblJobOrder.JONO, " & _
        "convert(varchar,tblJobOrder.[DATE],101), " & _
        "tblJobOrder.CARDID, " & _
        "tblJobOrder.ITEMNO, " & _
        "tblJobOrder.QTY, " & _
        "tblJobOrder.REMARKS " & _
        "FROM " & _
        "tblJobOrder " & _
        "where jono = '" & jono & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            ds.Tables("JOTABLE").Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), "", MainForm.logo, MainForm.header)
        Next
        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        rptDoc = New rpt_JO
        rptDoc.SetDataSource(ds.Tables("JOTABLE"))
        print_slip_viewer.CrystalReportViewer1.ReportSource = rptDoc
        print_slip_viewer.ShowDialog()
    End Sub
End Class
