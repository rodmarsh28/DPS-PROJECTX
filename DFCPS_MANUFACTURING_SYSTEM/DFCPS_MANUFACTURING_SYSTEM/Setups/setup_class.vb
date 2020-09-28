Imports System.Data.SqlClient

Public Class setup_class

    Public companyName As String
    Public companyAddress As String
    Public companyLogo As Byte()
    Public companyHeader As Byte()
    Sub insert_update_company()
        checkConn()
        Dim cmd = New SqlCommand("insert_update_company", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = Command()
            .Parameters.AddWithValue("@companyName", SqlDbType.VarChar).Value = companyName
            .Parameters.AddWithValue("@companyAddress", SqlDbType.VarChar).Value = companyAddress
            .Parameters.AddWithValue("@companyLogo", SqlDbType.Image).Value = companyLogo
            .Parameters.AddWithValue("@companyHeader", SqlDbType.Image).Value = companyHeader
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Sub get_company()
        Dim cmd = New SqlCommand("select companyName,companyAddress,companyLogo,companyHeader from tblCompany where companyID = 1", conn)
        Dim dr As SqlDataReader
        checkConn()
        dr = cmd.ExecuteReader
        If dr.Read Then
            companyName = dr.Item(0)
            companyAddress = dr.Item(1)
            companyLogo = CType(dr.Item(2), Byte())
            companyHeader = CType(dr.Item(3), Byte())
        End If
    End Sub
End Class
