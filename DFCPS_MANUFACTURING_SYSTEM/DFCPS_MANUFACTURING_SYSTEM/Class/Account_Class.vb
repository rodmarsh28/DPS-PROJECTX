Imports System.Data.SqlClient

Public Class Account_Class
    Public searchValue As String
    Public accountNo As String
    Public header As String
    Public subheader As String
    Public dept As String
    Public accDesc As String

    Public AccName As String
    Public itemdesc As String
    Public unit As String
    Public unitprice As Double
    Public qty As Integer
    Public inventorable As Boolean
    Public buyable As Boolean
    Public sellable As Boolean
    Public costAcc As String
    Public incomeAcc As String
    Public assetAcc As String
    Public job_no As String
    Public dtable As New DataTable

    Public Sub reverse_accEntry(ByVal id As String, ByVal memo As String)
        Dim ds As New account_dsTableAdapters.tblAccEntryTableAdapter
        ds.Connection.ConnectionString = My.Settings.connStringValue
        Dim dt As New account_ds.tblAccEntryDataTable
        ds.Fill(dt, id)
        For Each a As DataRow In dt.Rows
            ds.Insert(Now, a(1), a(2), a(3), memo, a(6), a(5), a(7), a(8), a(9))
        Next


    End Sub
    Public Sub get_accountInfo()
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_AccountInfo", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
            End With
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.Read Then
                accountNo = reader.Item(0)
                header = reader.Item(1)
                subheader = reader.Item(2)
                dept = reader.Item(3)
                accDesc = reader.Item(4)
            Else
                accountNo = ""
                header = ""
                subheader = ""
                dept = ""
                accDesc = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Public Sub get_itemAccountInfo()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select itemdesc,unit,unitprice,buyable,sellable,inventorable,costofsalesAcc,incomeAcc,assetAcc from tblInvtry where itemno = '" & searchValue & "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.Read Then
                itemdesc = dr.Item(0)
                unit = dr.Item(1)
                unitprice = dr.Item(2)
                qty = 1
                If dr.Item(3) = 1 Then
                    buyable = True
                Else
                    buyable = False
                End If
                If dr.Item(4) = 1 Then
                    sellable = True
                Else
                    sellable = False
                End If
                If dr.Item(5) = 1 Then
                    inventorable = True
                Else
                    inventorable = False
                End If
                costAcc = dr.Item(6)
                incomeAcc = dr.Item(7)
                assetAcc = dr.Item(8)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Public Sub getaccountName()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select accountName from tblCOA where accNo = '" & searchValue & "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.Read Then
                accName = dr.Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Public Sub checkInventoryInfo()
        checkConn()
        Dim cmd As New SqlCommand("checkInventoryInfo", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@itemNo", SqlDbType.VarChar).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Public Sub check_acc_endingbalance()
        checkConn()
        Dim cmd As New SqlCommand("select * from account_balance where accno ='" & accountNo & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Public Sub check_acc_endingbalance_perjob()
        checkConn()
        Dim cmd As New SqlCommand("select * from account_balance where accno ='" & accountNo & "' and job = '" & job_no & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Public Sub insert_to_approval(ByVal refno As String, ByVal transdate As DateTime, ByVal type As String, ByVal status As String)
        Dim acc_ds As New account_dsTableAdapters.tblApprovalTableAdapter
        acc_ds.Connection.ConnectionString = My.Settings.connStringValue
        acc_ds.Insert(refno, transdate, type, "", Now, "", "")
    End Sub
    Public Sub update_approval_status(ByVal refno As String, ByVal transdate As DateTime, ByVal type As String, ByVal status As String, ByVal dateUpdated As DateTime, ByVal userid As String, ByVal remarks As String)
        Dim acc_ds As New account_dsTableAdapters.tblApprovalTableAdapter
        acc_ds.Connection.ConnectionString = My.Settings.connStringValue
        Dim dst As New account_ds.tblApprovalDataTable
        acc_ds.Fill(dst, refno)
        For Each row As DataRow In dst.Rows
            row.Item("refNo") = refno
            row.Item("status") = status
            row.Item("dateUpdated") = dateUpdated
            row.Item("userID") = userid
            row.Item("remarks") = remarks
        Next
        acc_ds.Update(dst)
    End Sub
End Class
