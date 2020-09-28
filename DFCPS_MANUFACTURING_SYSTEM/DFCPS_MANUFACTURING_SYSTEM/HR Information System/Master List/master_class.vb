Imports System.Data.SqlClient


Public Class master_class
    Public loopcount As Integer
    Public command As String
    Public searchValue As String
    Public offenseID As Integer
    Public offenseDesc As String
    Public occurrenceTimes As Integer
    Public correctiveActions As String
    Public infractionID As Integer
    Public infractionDesc As String
    Public specOffID As Integer
    Public specoffDesc As String
    Public ID As String
    Public dtable As New DataTable
    Public empID As String
    Public transNo As String
    Public datetrans As DateTime
    Public dateOfOffense As DateTime
    Public writenExplanation As String
    Public witness As String
    Public type As String
    Public dateFrom As DateTime
    Public dateTo As DateTime
    Public wH As Decimal
    Public aH As Decimal
    Public rhC As Decimal
    Public nwhC As Decimal
    Public rhH As Decimal
    Public nwhH As Decimal
    Public otH As Decimal
    Public otnH As Decimal
    Public rdrH As Decimal
    Public latemins As Decimal
    Public remarks As String
    Public ltID As Integer
    Public leaveType As String
    Public days As Decimal
    Public dtrDate As String
    Public ds As New HRISDATASET

    Sub insert_offenses()
        Dim cmd As New SqlCommand("insert into tblOffenses values('" & offenseID & "','" & offenseDesc & "',0)", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub insert_occurrence()
        Dim cmd As New SqlCommand("insert into tblOccurrence values('" & occurrenceTimes & "','" & correctiveActions & "','" & offenseID & "',0)", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub insert_infraction()
        Dim cmd As New SqlCommand("insert into tblInfractions values('" & infractionID & "','" & infractionDesc & "',0)", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub insert_specOffense()
        Dim cmd As New SqlCommand("insert into tblSpecOffense values('" & specOffID & "','" & specoffDesc & "','" & offenseID & "','" & infractionID & "',0)", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub delete_offenses()
        Dim cmd As New SqlCommand("delete tblOffenses where offenseID = '" & offenseID & "'; delete tblOccurrence where offenseID = '" & offenseID & "'", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub delete_occurrence()
        Dim cmd As New SqlCommand("delete tblOccurrence where  occurrenceTimes = '" & occurrenceTimes & "' and offenseID = '" & offenseID & "'", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub delete_infraction()
        Dim cmd As New SqlCommand("delete tblInfractions  where infractionID = '" & infractionID & "'; delete tblSpecOffense  where infractionID = '" & infractionID & "'", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub delete_specOffense()
        Dim cmd As New SqlCommand("delete tblSpecOffense  where specOffenseID = '" & specOffID & "' and infractionID = '" & infractionID & "'", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub get_offenses_List()
        checkConn()
        Dim cmd = New SqlCommand("select offenseID,typeOfOffenses from tblOffenses", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_lt_list()
        checkConn()
        Dim cmd = New SqlCommand("select leaveTypeID,leaveType,days from tblLeaveType", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_occurrence_List()
        checkConn()
        Dim cmd = New SqlCommand("select occurrenceTimes,correctiveActions from tblOccurrence where offenseID = '" & offenseID & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_infraction_List()
        checkConn()
        Dim cmd = New SqlCommand("select infractionID,infractionDesc from tblInfractionS", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_SpecOff_List()
        checkConn()
        Dim cmd = New SqlCommand("select specOffenseID,specOffenseDesc,tblSpecOffense.offenseID,typeOfOffenses from tblSpecOffense inner join tblOffenses on " & _
                                 "tblOffenses.offenseID = tblSpecOffense.offenseID where infractionID = '" & infractionID & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub insert_lt()
        Dim cmd As New SqlCommand("insert into tblLeaveType values('" & ltID & "','" & leaveType & "','" & days & "')", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub delete_lt()
        Dim cmd As New SqlCommand("delete tblleavetype where leavetypeID ='" & ltID & "'", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub delete_dtr_record()
        Dim cmd As New SqlCommand("delete tblDTRrecord where DTRRECORDNO ='" & transNo & "' and convert(varchar,dtrdate,111) = '" & dtrDate & "'", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub insert_Disciplinary_Action()
        Dim cmd As New SqlCommand("insert into tblDesciplinaryAction values('" & transNo & "','" & datetrans & "','" & empID & "', " & _
                                  "'" & infractionID & "','" & specOffID & "','" & offenseID & "','" & occurrenceTimes & "','" & dateOfOffense & "'" & _
                                  ",'" & writenExplanation & "','" & witness & "','')", conn)
        checkConn()
        cmd.ExecuteNonQuery()
    End Sub
    Sub get_infraction_offense_list()
        checkConn()
        Dim cmd = New SqlCommand("get_infraction_offense_list", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_emp_info()
        checkConn()
        Dim cmd = New SqlCommand("get_emp_info", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_withpay_leave_credit()
        checkConn()
        Dim cmd = New SqlCommand("get_withpay_leave_credit", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
            .Parameters.AddWithValue("@yearNow", SqlDbType.VarChar).Value = dateTo
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_employees_leave_list()
        checkConn()
        Dim cmd = New SqlCommand("get_employees_leave_list", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_disciplinaryaction_list()
        checkConn()
        Dim cmd = New SqlCommand("get_disciplinaryaction_list", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub get_active_emp()
        checkConn()
        Dim cmd = New SqlCommand("get_active_emp", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@dateTrans", SqlDbType.DateTime2).Value = datetrans
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub insert_dtr_record()
        checkConn()
        Dim cmd = New SqlCommand("insert_dtr_record", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = loopcount
            .Parameters.AddWithValue("@transNo", SqlDbType.VarChar).Value = transNo
            .Parameters.AddWithValue("@transDate", SqlDbType.DateTime2).Value = datetrans
            .Parameters.AddWithValue("@empid", SqlDbType.VarChar).Value = empID
            .Parameters.AddWithValue("@wH", SqlDbType.VarChar).Value = wH
            .Parameters.AddWithValue("@aH", SqlDbType.VarChar).Value = aH
            .Parameters.AddWithValue("@rhC", SqlDbType.VarChar).Value = rhC
            .Parameters.AddWithValue("@nwhC", SqlDbType.VarChar).Value = nwhC
            .Parameters.AddWithValue("@rhH", SqlDbType.VarChar).Value = rhH
            .Parameters.AddWithValue("@nwhH", SqlDbType.VarChar).Value = nwhH
            .Parameters.AddWithValue("@otH", SqlDbType.VarChar).Value = otH
            .Parameters.AddWithValue("@otnH", SqlDbType.VarChar).Value = otnH
            .Parameters.AddWithValue("@rdrH", SqlDbType.VarChar).Value = rdrH
            .Parameters.AddWithValue("@latemins", SqlDbType.VarChar).Value = latemins
            .Parameters.AddWithValue("@remarks", SqlDbType.VarChar).Value = remarks
            .Parameters.AddWithValue("@userid", SqlDbType.VarChar).Value = ""
        End With
        cmd.ExecuteNonQuery()
    End Sub
    Sub get_dtr_history()
        checkConn()
        Dim cmd = New SqlCommand("get_dtr_history", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@dateTrans", SqlDbType.VarChar).Value = datetrans
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dtable)
    End Sub
    Sub delete_exst_dtrRecord()
        checkConn()
        Dim cmd = New SqlCommand("delete_exst_dtrRecord", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@transDate", SqlDbType.DateTime2).Value = datetrans
        End With
        cmd.ExecuteNonQuery()
    End Sub

    Sub dtr_record_report()
        checkConn()
        Dim cmd = New SqlCommand("get_dtr_record_summary", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@dfrom", SqlDbType.DateTime2).Value = dateFrom
            .Parameters.AddWithValue("@dto", SqlDbType.DateTime2).Value = dateTo
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(ds, "dtrRecordTable")
    End Sub

    Sub get_leave_record()
        checkConn()
        Dim cmd = New SqlCommand("get_leave_record", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@dfrom", SqlDbType.DateTime2).Value = dateFrom
            .Parameters.AddWithValue("@dto", SqlDbType.DateTime2).Value = dateTo
            .Parameters.AddWithValue("@searchValue", SqlDbType.DateTime2).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(ds, "leaveTable")
    End Sub

    Sub get_emp_list()
        checkConn()
        Dim cmd = New SqlCommand("get_emp_list", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@command", SqlDbType.VarChar).Value = command
            .Parameters.AddWithValue("@searchValue", SqlDbType.DateTime2).Value = searchValue
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(ds, "empDataTable")
    End Sub
    Public Function get_dept_id(ByVal empId As String) As String
        Dim dt As New DataTable
        checkConn()
        Dim cmd As New SqlCommand("select department from tblEmployeesInfo where employeeID = '" & empId & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Return dt.Rows(0).Item("department")
    End Function
End Class
