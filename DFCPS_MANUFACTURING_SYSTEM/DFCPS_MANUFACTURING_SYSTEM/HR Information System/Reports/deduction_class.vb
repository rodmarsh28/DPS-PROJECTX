Imports System.Data.SqlClient

Public Class deduction_class
    Public monthNo As Integer
    Public monthName As String
    Public dts As New DataTable

    Public Sub print_sssLoan_summary()
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_sssloan_summary", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@monthNo", SqlDbType.Int).Value = monthNo
            End With
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            dts.Rows.Clear()
            dts.Columns.Clear()
            With dts
                .Columns.Add("dateofprems")
                .Columns.Add("department")
                .Columns.Add("sssNo")
                .Columns.Add("type")
                .Columns.Add("empid")
                .Columns.Add("name")
                .Columns.Add("amount")
            End With
            For Each row As DataRow In dt.Rows
                dts.Rows.Add(monthName, row(0), row(1), row(2), row(3), row(4), Format(row(5), "N"))
            Next
           
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Public Sub print_piLoan_summary()
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_piloan_summary", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@monthNo", SqlDbType.Int).Value = monthNo
            End With
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            dts.Rows.Clear()
            dts.Columns.Clear()
            With dts
                .Columns.Add("dateofprems")
                .Columns.Add("department")
                .Columns.Add("mid")
                .Columns.Add("type")
                .Columns.Add("empid")
                .Columns.Add("name")
                .Columns.Add("amount")
            End With
            For Each row As DataRow In dt.Rows
                dts.Rows.Add(monthName, row(0), row(1), row(2), row(3), row(4), Format(row(5), "N"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
End Class
