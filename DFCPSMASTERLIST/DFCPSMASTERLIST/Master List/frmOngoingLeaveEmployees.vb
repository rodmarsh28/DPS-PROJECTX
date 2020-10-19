Public Class frmOngoingLeaveEmployees
    Sub showOngoingLeaveEmployees()
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            Dim c As Integer
            c = 0
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblLeave.leaveNo,dbo.tblEmployeesInfo.lastname,dbo.tblEmployeesInfo.firstname,dbo.tblEmployeesInfo.middlename," & _
                                "dbo.tblEmployeesInfo.[position],dbo.tblEmployeesInfo.department,dbo.tblEmployeesInfo.division,dbo.tblLeave.leaveType,dbo.tblLeave.dateFrom," & _
                                "dbo.tblLeave.dateTo,dbo.tblLeave.totalDays FROM dbo.tblEmployeesInfo INNER JOIN dbo.tblLeave ON dbo.tblEmployeesInfo.employeeID = dbo.tblLeave.employeeID " & _
                                "where '" & Format(Now, "MM/dd/yyyy") & "' between datefrom and dateto order by leaveNo desc"
            End With
            OleDBDR = OleDBC.ExecuteReader
            dgw.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgw.Rows.Add()
                    dgw.Item(0, c).Value = OleDBDR.Item(0)
                    dgw.Item(1, c).Value = OleDBDR.Item(1) & ", " & OleDBDR.Item(2) & " " & OleDBDR.Item(3) & "."
                    dgw.Item(2, c).Value = OleDBDR.Item(4)
                    dgw.Item(3, c).Value = OleDBDR.Item(5)
                    dgw.Item(4, c).Value = OleDBDR.Item(6)
                    dgw.Item(5, c).Value = OleDBDR.Item(7)
                    dgw.Item(6, c).Value = Format(OleDBDR.Item(8), "MM/dd/yyyy")
                    dgw.Item(7, c).Value = Format(OleDBDR.Item(9), "MM/dd/yyyy")
                    dgw.Item(8, c).Value = OleDBDR.Item(10)
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmOngoingLeaveEmployees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showOngoingLeaveEmployees()
    End Sub
End Class