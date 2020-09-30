Imports System.Data.SqlClient

Public Class qry_class
    Public qry As String
    Public qrytype As String
    Public db_table As String
    Public db_condition As String
    Public paramValue As List(Of String)

    Public db_col_list As List(Of String)

    Public Function get_qry_data() As DataTable
        Dim dt As New DataTable
        checkConn()
        Dim cmd As New SqlCommand(qry, conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dt)
        Return dt
    End Function

    Public Function insert_data() As String
        Try
            Dim cmd As New SqlCommand(qry, conn)
            checkConn()
            cmd.ExecuteNonQuery()
            Return "Success"
        Catch ex As Exception
            rollback_changes(qry.Replace("Select", "Delete"))
            Return ex.Message
        End Try
    End Function
    Public Sub rollback_changes(ByVal delqry As String)
        Dim succ As Boolean
        While succ <> True
            Try
                Dim cmd As New SqlCommand(delqry, conn)
                checkConn()
                cmd.ExecuteNonQuery()
                succ = True
            Catch ex As Exception
                succ = False
            End Try
        End While

    End Sub
    Public Function update_data() As String
        Dim str As String
        str = qrytype & " " & "set "
        For i = 0 To db_col_list.Count
            str = str & db_col_list.Item(i) & " = " & paramValue.Item(i) & ", "
        Next
        str = Left(str, 0)
        Try
            checkConn()
            Dim cmd As New SqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            Return "Success"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Function fill_textbox_toupdate() As String
        Dim str As String
        str = qrytype & " " & "set "
        For i = 0 To db_col_list.Count
            str = str & db_col_list.Item(i) & " = " & paramValue.Item(i) & ", "
        Next
        str = Left(str, 0)
        Try
            checkConn()
            Dim cmd As New SqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            Return "Success"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

   
End Class
