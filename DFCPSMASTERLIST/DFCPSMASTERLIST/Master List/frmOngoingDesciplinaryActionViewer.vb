Public Class frmOngoingDesciplinaryActionViewer
    Sub showOngoingDA()
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
                .CommandText = "SELECT dbo.tblDesciplinaryAction.descActionNo,dbo.tblEmployeesInfo.lastname,dbo.tblEmployeesInfo.firstname," & _
                    "dbo.tblEmployeesInfo.middlename,dbo.tblEmployeesInfo.[position],dbo.tblEmployeesInfo.department,dbo.tblEmployeesInfo.division," & _
                    "dbo.tblDesciplinaryAction.typeofViolation,dbo.tblDesciplinaryAction.actionTaken,dbo.tblDesciplinaryAction.punishDateFrom," & _
                    "dbo.tblDesciplinaryAction.punishDateTo FROM dbo.tblDesciplinaryAction INNER JOIN dbo.tblEmployeesInfo ON " & _
                    "dbo.tblEmployeesInfo.employeeID = dbo.tblDesciplinaryAction.employeeID " & _
                    "where '" & Format(Now, "MM/dd/yyyy") & "' between punishDateFrom and punishDateTo order by descActionNo desc"
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
                    dgw.Item(6, c).Value = OleDBDR.Item(8)
                    dgw.Item(7, c).Value = Format(OleDBDR.Item(9), "MM/dd/yyyy")
                    dgw.Item(8, c).Value = Format(OleDBDR.Item(10), "MM/dd/yyyy")
                    dgw.Item(9, c).Value = DateDiff(DateInterval.Day, OleDBDR.Item(9), OleDBDR.Item(10)) + 1
                    c = c + 1
                End While
                dgw.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub frmOngoingDesciplinaryActionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showOngoingDA()

    End Sub

    Private Sub dgw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub
End Class