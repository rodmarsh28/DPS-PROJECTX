Imports System.Data.SqlClient

Public Class Accounting_class
    Public command As Integer = 0


    Public transNo As String
    Public transDate As DateTime
    Public refNo As String
    Public tinNo As String
    Public payee As String
    Public address As String
    Public checkbookid As String
    Public checkNo As String
    Public totAmount As Double
    Public totDebit As Double
    Public totCredit As Double
    Public amountinWords As String
    Public status As String
    Public remarks As String
    Public value As Decimal
    Public cardID As String
    Public amount As Decimal
    Public amountValue As Decimal
    Public appliedValue As Decimal
    Public CHECKDATE As DateTime
    Public src As String
    Public MEMO As String
    Public rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Public searchValue As String
    Public voucherNo As String
    Public particulars As String
    Public dtable As New DataTable
    Public notimesedit As Integer = 0
    Public count As Integer
    Public vno As String
    Public type As String
    Public memotype As String = ""
    Public Sub insert_update_checkvoucher()
        Dim cmd As New SqlCommand("insert_update_checkVoucher", conn)
            checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@transNo", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@refNo", SqlDbType.VarChar).Value = refNo
            .Parameters.AddWithValue("@transdate", SqlDbType.VarChar).Value = transDate
            .Parameters.AddWithValue("@type", SqlDbType.Decimal).Value = type
            .Parameters.AddWithValue("@tinNo", SqlDbType.Decimal).Value = tinNo
            .Parameters.AddWithValue("@payee", SqlDbType.VarChar).Value = cardID
            .Parameters.AddWithValue("@address", SqlDbType.Decimal).Value = address
            .Parameters.AddWithValue("@totalAmount", SqlDbType.VarChar).Value = totAmount
            .Parameters.AddWithValue("@amountInwords", SqlDbType.VarChar).Value = amountinWords
            .Parameters.AddWithValue("@remarks", SqlDbType.VarChar).Value = remarks
            .Parameters.AddWithValue("@userid", SqlDbType.VarChar).Value = MainForm.LBLID.Text
            .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status
        End With
            cmd.ExecuteNonQuery()
    End Sub
    Public Sub insert_update_cashRequistion()
        Dim cmd As New SqlCommand("insert_update_cashRequistion", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@transNo", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@CARDID", SqlDbType.VarChar).Value = cardID
            .Parameters.AddWithValue("@particulars", SqlDbType.VarChar).Value = particulars
            .Parameters.AddWithValue("@amount", SqlDbType.Decimal).Value = amount
            .Parameters.AddWithValue("@amountApplied", SqlDbType.Decimal).Value = amountValue
            .Parameters.AddWithValue("@REMARKS", SqlDbType.VarChar).Value = remarks
            .Parameters.AddWithValue("@totalAmount", SqlDbType.Decimal).Value = totAmount
            .Parameters.AddWithValue("@totalAmountAPPLIED", SqlDbType.Decimal).Value = appliedValue
            .Parameters.AddWithValue("@userid", SqlDbType.VarChar).Value = MainForm.LBLID.Text
            .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status
            .Parameters.AddWithValue("@notimesedit", SqlDbType.VarChar).Value = notimesedit
            .Parameters.AddWithValue("@count", SqlDbType.VarChar).Value = count
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Sub insert_update_voucher()
        Dim cmd As New SqlCommand("insert_update_voucher", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@No", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@ref", SqlDbType.VarChar).Value = refNo
            .Parameters.AddWithValue("@cardID", SqlDbType.VarChar).Value = cardID
            .Parameters.AddWithValue("@amount", SqlDbType.Decimal).Value = amount
            .Parameters.AddWithValue("@remarks", SqlDbType.VarChar).Value = remarks
            .Parameters.AddWithValue("@userid", SqlDbType.VarChar).Value = MainForm.LBLID.Text
            .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = "Open"
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Sub insert_update_particulars()
        Dim cmd As New SqlCommand("insert_update_particulars", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@transNo", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@particulars", SqlDbType.VarChar).Value = remarks
            .Parameters.AddWithValue("@amountValue", SqlDbType.VarChar).Value = amountValue
            .Parameters.AddWithValue("@appliedValue", SqlDbType.VarChar).Value = appliedValue
            .Parameters.AddWithValue("@voucherNo", SqlDbType.VarChar).Value = voucherNo
            .Parameters.AddWithValue("@count", SqlDbType.Int).Value = count
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Sub insert_delete_pending_AccEntry()
        Dim cmd As New SqlCommand("insert_delete_pending_accEntry", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@transNo", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@accno", SqlDbType.VarChar).Value = accNo
            .Parameters.AddWithValue("@memo", SqlDbType.VarChar).Value = remarks
            .Parameters.AddWithValue("@debit", SqlDbType.Decimal).Value = totDebit
            .Parameters.AddWithValue("@credit", SqlDbType.Decimal).Value = totCredit
            .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status
            .Parameters.AddWithValue("@count", SqlDbType.Int).Value = count
        End With
        cmd.ExecuteNonQuery()
    End Sub

    Public Sub insert_CheckTransaction()
        Dim cmd As New SqlCommand("insert_update_checkTransaction", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@transNo", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@checkbookID", SqlDbType.VarChar).Value = checkbookid
            .Parameters.AddWithValue("@checkNo", SqlDbType.VarChar).Value = checkNo
            .Parameters.AddWithValue("@cardID", SqlDbType.VarChar).Value = cardID
            .Parameters.AddWithValue("@Amount", SqlDbType.VarChar).Value = amount
            .Parameters.AddWithValue("@checkdate", SqlDbType.DateTime).Value = CHECKDATE
            .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status
            .Parameters.AddWithValue("@userID", SqlDbType.VarChar).Value = MainForm.LBLID.Text
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub insert_generalJournal()
        Dim cmd As New SqlCommand("insert_general_journal", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@GJNO", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@DATETRANS", SqlDbType.VarChar).Value = transDate
            .Parameters.AddWithValue("@USERID", SqlDbType.VarChar).Value = MainForm.LBLID.Text
            .Parameters.AddWithValue("@STATUS", SqlDbType.VarChar).Value = status
        End With
        cmd.ExecuteNonQuery()
    End Sub
    

    Public accNo As String
    Public Sub DELETE_ARPRSettings()
        Dim cmd As New SqlCommand("delete tblArPrSettings", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub insert_ARPRSettings()
        Dim cmd As New SqlCommand("insert into tblArPrSettings values ('" & type & "','" & accNo & "')", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub update_checkvoucher_status()
        Dim cmd As New SqlCommand("update tblCheckVoucher set status = '" & status & "' where checkVoucherNo = '" & transNo & "'", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub update_cash_requisition_status()
        Dim cmd As New SqlCommand("update tblcashrequisition set status = '" & status & "' where crsno = '" & transNo & "'", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub update_voucher_status()
        Dim cmd As New SqlCommand("update tblVoucher set status = 'Closed' where VoucherNo = '" & transNo & "'", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub update_checkTrans_status()
        Dim cmd As New SqlCommand("update tblCheckTransaction set status = '" & status & "' where checkNo = '" & checkNo & "'", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub GET_ACCNO_OF_TRNO()
        checkConn()
        Dim cmd As New SqlCommand("GET_ACCNO_OF_TRNO", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@COMMAND", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@SEARCHVALUE", SqlDbType.VarChar).Value = transNo
            '.Parameters.AddWithValue("@memotype", SqlDbType.VarChar).Value = memotype
        End With
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.HasRows Then
            If reader.Read Then
                accNo = reader.Item(0)
            End If
        End If
    End Sub
    Public cardName As String
    Public cardAddress As String
    Public cardCN As String
    Public cardType As String
    Public designation As String
    Public allowCredit As String
    Public creditlimit As Decimal
    Public cardStatus As String
    Public Sub get_card_info()
        checkConn()
        Dim cmd As New SqlCommand("get_card_info", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@SEARCHVALUE", SqlDbType.VarChar).Value = cardID
        End With
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.HasRows Then
            If reader.Read Then
                cardName = reader.Item(1)
                cardAddress = reader.Item(2)
                cardCN = reader.Item(3)
                cardType = reader.Item(4)
                designation = reader.Item(5)
                allowCredit = reader.Item(6)
                creditlimit = reader.Item(7)
                cardStatus = reader.Item(8)
            End If
        End If
    End Sub
    Sub get_temp_accEntry()
        checkConn()
        Dim cmd As New SqlCommand("get_temp_accEntry_thenInsert", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@refno", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@src", SqlDbType.VarChar).Value = src
            .Parameters.AddWithValue("@userid", SqlDbType.VarChar).Value = MainForm.LBLID.Text
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub get_cash_requisition_data_to_prep_cv()
        Dim dt As New DataTable
        checkConn()
        Dim cmd As New SqlCommand("get_cash_requisition_list", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        dt.Rows.Clear()
        da.Fill(TransactionViewer.DT)
    End Sub
    '\'REPORTING AREA
    Public Sub PRINT_VOUCHER_SLIP()
        Try
            frmLoading.Show()
            checkConn()
            Dim cmd As New SqlCommand("get_voucher_slip", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@transNo", SqlDbType.VarChar).Value = transNo
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim ds As New accountingDS
            Dim dt As New DataTable
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                ds.Tables("VOUCHERTABLE").Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), MainForm.logo, MainForm.header)
            Next
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New vouchersPayable
            rptDoc.SetDataSource(ds.Tables("VOUCHERTABLE"))
            report_viewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
            report_viewer.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Public DFROM As DateTime
    Public DTO As DateTime
    Public SEARCHTYPE As String
    Public ACCLIST As String
    Public Sub PRINT_GENERAL_LEDGER()
        Try
            frmLoading.Show()
            checkConn()
            Dim cmd As New SqlCommand("GET_GL_DATA", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@DFROM", SqlDbType.VarChar).Value = DFROM
                .Parameters.AddWithValue("@DTO", SqlDbType.VarChar).Value = DTO
                .Parameters.AddWithValue("@SEARCHTYPE", SqlDbType.VarChar).Value = SEARCHTYPE
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim ds As New accountingDS
            Dim dt As New DataTable
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                ds.Tables("GLTABLE").Rows.Add(DFROM, DTO, row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), MainForm.logo, MainForm.header)
            Next
            rptDoc = New generalLedger
            rptDoc.SetDataSource(ds.Tables("GLTABLE"))
            frmGLreportViewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Public Sub PRINT_CHECK()
        Try
            checkConn()
            Dim cmd As New SqlCommand("PRINT_CHECK", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@COMMAND", SqlDbType.VarChar).Value = command
                .Parameters.AddWithValue("@TRANSNO", SqlDbType.VarChar).Value = transNo
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim ds As New accountingDS
            Dim dt As New DataTable
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                ds.Tables("CHECKTABLE").Rows.Add(row(0), row(1), CDbl(row(2)).ToString("N"), ConvertNumberToENG(CDbl(row(2))) & " Only", CDate(row(3)).ToString("MMM dd, yyyy"))
            Next
            rptDoc = frmCheckPrint.rpttemp
            rptDoc.SetDataSource(ds.Tables("CHECKTABLE"))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Public Sub GET_CASH_FOR_UPDATE()
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_cash_requisition_list", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@COMMAND", SqlDbType.VarChar).Value = command
                .Parameters.AddWithValue("@SEARCHVALUE", SqlDbType.VarChar).Value = searchValue
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            da.Fill(dtable)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Public Sub get_checkIssued_list()
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_checkIssued_list", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@COMMAND", SqlDbType.VarChar).Value = command
                .Parameters.AddWithValue("@SEARCHVALUE", SqlDbType.VarChar).Value = searchValue
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            da.Fill(dtable)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Public Sub GET_CV_DATA()
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_checkVoucher_list", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@COMMAND", SqlDbType.VarChar).Value = command
                .Parameters.AddWithValue("@SEARCHVALUE", SqlDbType.VarChar).Value = searchValue
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            da.Fill(dtable)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Public Sub GET_CASH_REQUISISTION_FORPRINT()
        Try
            frmLoading.Show()
            checkConn()
            Dim cmd As New SqlCommand("GET_CASH_REQUISISTION_FORPRINT", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@COMMAND", SqlDbType.VarChar).Value = command
                .Parameters.AddWithValue("@SEARCHVALUE", SqlDbType.VarChar).Value = searchValue
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim ds As New accountingDS
            Dim dt As New DataTable
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                ds.Tables("CASHREQTABLE").Rows.Add(row(0), CDate(row(1)).ToString("MMM dd, yyyy"), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), MainForm.logo, MainForm.header)
            Next
            rptDoc = New cashRequisition
            rptDoc.SetDataSource(ds.Tables("CASHREQTABLE"))
            rptDoc.SetParameterValue("PreparedBy", MainForm.LBLNAME.Text)
            report_viewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
            report_viewer.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Public Sub GET_CHECK_VOUCHER_FORPRINT()
        Try
            frmLoading.Show()
            checkConn()
            Dim cmd As New SqlCommand("GET_CHECK_VOUCHER_FORPRINT", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@COMMAND", SqlDbType.VarChar).Value = command
                .Parameters.AddWithValue("@SEARCHVALUE", SqlDbType.VarChar).Value = searchValue
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim ds As New accountingDS
            Dim dt As New DataTable
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                Dim ref As String
                If CDec(row(16)) = 0 Then
                    ref = Mid(row(12), Len(row(12)) - 8)
                Else
                    ref = ""
                End If
                ds.Tables("CVTABLE").Rows.Add(row(0), CDate(row(1)).ToString("MMMM dd, yyyy"), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), row(10), ConvertNumberToENG(CDec(row(10))), row(11), _
                                              ref, row(13), row(14), row(15), row(16), MainForm.LBLNAME.Text, MainForm.logo, MainForm.header)
            Next
            rptDoc = New CV_SLIP
            rptDoc.SetDataSource(ds.Tables("CVTABLE"))
            report_viewer.CrystalReportViewer1.ReportSource = rptDoc
            frmLoading.Close()
            report_viewer.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Public Sub get_open_voucher()
        Try
            Dim ds As New accountingDS
            checkConn()
            Dim cmd As New SqlCommand("get_voucher_list", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            da.Fill(ds, "openVoucherTable")
            rptDoc = New payable_list
            rptDoc.SetDataSource(ds.Tables("openVoucherTable"))
            report_viewer.CrystalReportViewer1.ReportSource = rptDoc
            rptDoc.SetParameterValue("PreparedBy", MainForm.LBLNAME.Text)
            report_viewer.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    
    Public Sub addtoTempAccnoList()
        Dim cmd As New SqlCommand("insert into TEMPACCNOLIST values('" & accNo & "')", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub deleteTemp()
        Dim cmd As New SqlCommand("delete TEMPACCNOLIST", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
End Class
