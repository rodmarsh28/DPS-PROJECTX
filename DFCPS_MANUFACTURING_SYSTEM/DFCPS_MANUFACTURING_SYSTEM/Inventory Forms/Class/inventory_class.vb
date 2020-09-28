Imports System.Data.SqlClient

Public Class inventory_class
    Public command As String
    Public itemNo As String
    Public itemdesc As String
    Public unitCost As Double
    Public unit As String
    Public unitprice As Double
    Public buy As String
    Public sell As String
    Public inv As String
    Public accCost As String
    Public accIncome As String
    Public accAsset As String
    Public minStock As String
    Public status As String
    Public balanceQty As Integer
    Public qty As Integer
    Public src As String

    Public entryMode As String
    Public refNo As String
    Public memo As String
    Public debit As Double
    Public credit As Double

    Public IssuanceNo As String
    Public IssuanceDate As DateTime
    Public totalItemCount As Integer
    Public totalCost As Decimal
    Public chargeToAccount As String
    Public remarks As String
    Public transNo As String
    Public transDate As String
    Public approvedBy As String
    Public job As String = ""
    Public oqty As Decimal
    Public ounit As String
    Public cardid As String
    Public dtable As New DataTable

    Property SearchValue As String



    Public Sub insert_update_inventory_class()

        Try
            Dim cmd As New SqlCommand("insert_update_inventory", conn)
            checkConn()
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
                .Parameters.AddWithValue("@itemNo", SqlDbType.VarChar).Value = itemNo
                .Parameters.AddWithValue("@itemdesc", SqlDbType.VarChar).Value = itemdesc
                .Parameters.AddWithValue("@unitCost", SqlDbType.Decimal).Value = unitCost
                .Parameters.AddWithValue("@unit", SqlDbType.VarChar).Value = unit
                .Parameters.AddWithValue("@unitprice", SqlDbType.Decimal).Value = unitprice
                .Parameters.AddWithValue("@buy", SqlDbType.VarChar).Value = buy
                .Parameters.AddWithValue("@sell", SqlDbType.VarChar).Value = sell
                .Parameters.AddWithValue("@inv", SqlDbType.VarChar).Value = inv
                .Parameters.AddWithValue("@accCost", SqlDbType.VarChar).Value = accCost
                .Parameters.AddWithValue("@accIncome", SqlDbType.VarChar).Value = accIncome
                .Parameters.AddWithValue("@accAsset", SqlDbType.VarChar).Value = accAsset
                .Parameters.AddWithValue("@minStock", SqlDbType.Int).Value = minStock
                .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status
                .Parameters.AddWithValue("@balanceQty", SqlDbType.Int).Value = balanceQty
                .Parameters.AddWithValue("@oqty", SqlDbType.Int).Value = oqty
                .Parameters.AddWithValue("@ounit", SqlDbType.Int).Value = ounit
                .Parameters.AddWithValue("@src", SqlDbType.VarChar).Value = Form.ActiveForm.Text
            End With
            cmd.ExecuteNonQuery()
            MsgBox("Item Saved !", MsgBoxStyle.Information, "Success")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub insert_Acc_entry_class()
        Try
            Dim cmd As New SqlCommand("insert_Acc_entry", conn)
            checkConn()
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@job", SqlDbType.VarChar).Value = job
                .Parameters.AddWithValue("@cardID", SqlDbType.VarChar).Value = ""
                .Parameters.AddWithValue("@refNo", SqlDbType.VarChar).Value = refNo
                .Parameters.AddWithValue("@src", SqlDbType.VarChar).Value = Form.ActiveForm.Text
                .Parameters.AddWithValue("@accNo", SqlDbType.VarChar).Value = accAsset
                .Parameters.AddWithValue("@memo", SqlDbType.VarChar).Value = memo
                .Parameters.AddWithValue("@debit", SqlDbType.Decimal).Value = debit
                .Parameters.AddWithValue("@credit", SqlDbType.Decimal).Value = credit
                .Parameters.AddWithValue("@USERID", SqlDbType.VarChar).Value = MainForm.LBLID.Text
            End With
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub insert_invItem_transaction()
        Try
            Dim cmd As New SqlCommand("insert_invItem_transaction", conn)
            checkConn()
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@itemNo", SqlDbType.Int).Value = itemNo
                .Parameters.AddWithValue("@refNo", SqlDbType.VarChar).Value = refNo
                .Parameters.AddWithValue("@src", SqlDbType.VarChar).Value = Form.ActiveForm.Text
                .Parameters.AddWithValue("@unitCost", SqlDbType.Decimal).Value = unitCost
                .Parameters.AddWithValue("@qty", SqlDbType.Int).Value = qty
                .Parameters.AddWithValue("@job", SqlDbType.Int).Value = job
                .Parameters.AddWithValue("@oqty", SqlDbType.Int).Value = oqty
            End With
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub insert_itemWidthrawal()
        Try
            Dim cmd As New SqlCommand("insert_item_issuance", conn)
            checkConn()
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@issuanceNo", SqlDbType.Int).Value = IssuanceNo
                .Parameters.AddWithValue("@refNo", SqlDbType.Int).Value = refNo
                .Parameters.AddWithValue("@transDate", SqlDbType.DateTime2).Value = IssuanceDate
                .Parameters.AddWithValue("@totalItemCount", SqlDbType.VarChar).Value = totalItemCount
                .Parameters.AddWithValue("@totalCost", SqlDbType.Decimal).Value = totalCost
                .Parameters.AddWithValue("@chargeToAccount", SqlDbType.Int).Value = chargeToAccount
                .Parameters.AddWithValue("@userid", SqlDbType.Decimal).Value = MainForm.LBLID.Text
                .Parameters.AddWithValue("@status", SqlDbType.Decimal).Value = status
            End With
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub insert_rmw()
        Dim cmd As New SqlCommand("insert_update_rawmats_widthrawal", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@transNo", SqlDbType.Int).Value = transNo
            .Parameters.AddWithValue("@transDate", SqlDbType.DateTime2).Value = transDate
            .Parameters.AddWithValue("@remarks", SqlDbType.VarChar).Value = memo
            .Parameters.AddWithValue("@approvedBy", SqlDbType.Decimal).Value = approvedBy
            .Parameters.AddWithValue("@userid", SqlDbType.Decimal).Value = MainForm.LBLID.Text
            .Parameters.AddWithValue("@status", SqlDbType.Decimal).Value = status
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub insert_rmp()
        Dim cmd As New SqlCommand("insert_update_rawmats_produced", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@transNo", SqlDbType.Int).Value = transNo
            .Parameters.AddWithValue("@transDate", SqlDbType.DateTime2).Value = transDate
            .Parameters.AddWithValue("@remarks", SqlDbType.VarChar).Value = memo
            .Parameters.AddWithValue("@userid", SqlDbType.Decimal).Value = MainForm.LBLID.Text
            .Parameters.AddWithValue("@status", SqlDbType.Decimal).Value = status
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub get_inventory_perjob()
        Dim cmd As New SqlCommand("select UNITCOST from invtrylistPerjob where ITEMNO = '" & itemNo & "' AND job = '" & job & "'", conn)
        checkConn()
        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Public Sub get_job_list()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select transDate, salesOrderNo, cardName from unclosed_sales_order", conn)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            da.Fill(dtable)
        Catch ex As Exception
        End Try
    End Sub

    Sub get_item_masterlist()
        Throw New NotImplementedException
    End Sub

End Class