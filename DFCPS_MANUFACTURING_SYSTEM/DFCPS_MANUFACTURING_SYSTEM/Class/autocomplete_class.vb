Imports System.Data.SqlClient

Public Class autocomplete_class
    Public outputData As String
    Public COL As New AutoCompleteStringCollection

    Public Sub get_AccountNo()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select accNo from tblCOA ", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                COL.Add(dr.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Public Sub get_itemCode()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select distinct itemno from tblInvtry ", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    COL.Add(dr.Item(0))
                End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
End Class
