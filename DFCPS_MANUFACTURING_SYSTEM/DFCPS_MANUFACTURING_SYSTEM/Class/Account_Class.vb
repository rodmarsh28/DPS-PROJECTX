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
End Class
