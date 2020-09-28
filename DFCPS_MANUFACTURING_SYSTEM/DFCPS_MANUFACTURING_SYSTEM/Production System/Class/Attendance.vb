Imports System.Data.SqlClient

Public Class Attendance
    Public datefrom As DateTime
    Public dateto As DateTime
    Public departmentID As String
    Public dsx As New Attendace_DS
    Public sunday As Integer

    Sub get_attendance_summary()
        Try
            count_sundays()
            checkConn()
            Dim cmd As New SqlCommand("GET_ATTENDANCE_SUMMARY", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@datefrom", SqlDbType.VarChar).Value = Format(datefrom, "yyyy/MM/dd")
                .Parameters.AddWithValue("@dateto", SqlDbType.VarChar).Value = Format(dateto, "yyyy/MM/dd")
                .Parameters.AddWithValue("@departmentID", SqlDbType.VarChar).Value = departmentID
                .Parameters.AddWithValue("@sundaysCount", SqlDbType.VarChar).Value = sunday
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            da.Fill(dsx, "Attendance_Record_Summary")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub get_Breaktime_Late_summary()
        Try
            checkConn()
            Dim cmd As New SqlCommand("GET_BREAKTIME_LATE_SUMMARY", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@datefrom", SqlDbType.VarChar).Value = Format(datefrom, "yyyy/MM/dd")
                .Parameters.AddWithValue("@dateto", SqlDbType.VarChar).Value = Format(dateto, "yyyy/MM/dd")
                .Parameters.AddWithValue("@departmentID", SqlDbType.VarChar).Value = departmentID
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            da.Fill(dsx, "Breaktime_Late_Summary")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub count_sundays()
        sunday = 0
        Dim totalday As Integer = dateto.Day - datefrom.Day
        Dim i As Integer = 0
        Dim dates As DateTime = datefrom
        While i <= totalday
            i = i + 1
            If dates.DayOfWeek = DayOfWeek.Sunday Then
                sunday = sunday + 1
            End If
            dates = DateAdd(DateInterval.Day, 1, dates)
        End While
    End Sub



End Class
