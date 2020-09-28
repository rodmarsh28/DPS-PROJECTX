Imports System.Data.SqlClient

Public Class bank_class


    Public command As Integer


    Public bankID As String
    Public bankDesc As String
    Public accountName As String
    Public accNo As String
    Public status As String
    Public Sub insert_update_bank()
        Dim cmd As New SqlCommand("insert_update_bank", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@bankID", SqlDbType.VarChar).Value = bankID
            .Parameters.AddWithValue("@bankDesc", SqlDbType.VarChar).Value = bankDesc
            .Parameters.AddWithValue("@accountName", SqlDbType.VarChar).Value = accountName
            .Parameters.AddWithValue("@accNo", SqlDbType.Decimal).Value = accNo
            .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status
        End With
        cmd.ExecuteNonQuery()
    End Sub

    Public checkbookID As String
    Public startCheckNo As String
    Public endCheckNo As String
    Public lastCheckNo As String
    Public Sub insert_update_checkbook()
        Dim cmd As New SqlCommand("insert_update_checkbook", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.Int).Value = command
            .Parameters.AddWithValue("@checkbookID", SqlDbType.VarChar).Value = checkbookID
            .Parameters.AddWithValue("@bankID", SqlDbType.VarChar).Value = bankID
            .Parameters.AddWithValue("@startCheckNo", SqlDbType.VarChar).Value = startCheckNo
            .Parameters.AddWithValue("@endCheckNo", SqlDbType.VarChar).Value = endCheckNo
            .Parameters.AddWithValue("@lastCheckNo", SqlDbType.VarChar).Value = lastCheckNo
            .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub get_bankInfo()
        Dim cmd As New SqlCommand("select bankDesc,accountName,accNo from tblBank where bankID = '" & bankID & "'", conn)
        checkConn()
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.Read Then
            bankDesc = reader.Item(0)
            accountName = reader.Item(1)
            accNo = reader.Item(2)
        End If
    End Sub
    Public Sub get_checkbookInfo()
        Dim cmd As New SqlCommand("select Bank_ID,Bank_Description,Checkno_Start,Checkno_End from get_Checkbooklist where Checkbook_ID = '" & checkbookID & "'", conn)
        checkConn()
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.Read Then
            bankID = reader.Item(0)
            bankDesc = reader.Item(1)
            startCheckNo = reader.Item(2)
            endCheckNo = reader.Item(3)
        End If
    End Sub

    
End Class
