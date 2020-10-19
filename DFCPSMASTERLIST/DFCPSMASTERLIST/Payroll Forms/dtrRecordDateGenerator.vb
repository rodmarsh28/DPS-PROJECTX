Public Class dtrRecordDateGenerator

    Public mode As String
    Sub print_dtr_record_summary()
        Dim mc As New master_class
        mc.dateFrom = Format(dtpFrom.Value, "yyyy/MM/dd")
        mc.dateTo = Format(dtpTo.Value, "yyyy/MM/dd")
        mc.dtr_record_report()
        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        If mode = "Total" Then
            rptDoc = New dtrReport
        ElseIf mode = "Daily" Then
            rptDoc = New dtrDailyReport
        End If
        rptDoc.SetDataSource(mc.ds)
        rptDoc.SetParameterValue("daterange", Format(dtpFrom.Value, "yyyy/MM/dd") & " - " & Format(dtpTo.Value, "yyyy/MM/dd"))
        rptDoc.SetParameterValue("preparedby", HRISMain.lblUsername.Text)
        HRISReportViewer.CrystalReportViewer1.ReportSource = rptDoc
        Me.Close()
        HRISReportViewer.ShowDialog()
    End Sub
    Sub get_leave_record()
        Dim mc As New master_class
        mc.command = 0
        mc.dateFrom = Format(dtpFrom.Value, "yyyy/MM/dd")
        mc.dateTo = Format(dtpTo.Value, "yyyy/MM/dd")
        mc.searchValue = ""
        mc.get_leave_record()
        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        rptDoc = New leaveReport
        rptDoc.SetDataSource(mc.ds)
        rptDoc.SetParameterValue("daterange", Format(dtpFrom.Value, "yyyy/MM/dd") & " - " & Format(dtpTo.Value, "yyyy/MM/dd"))
        rptDoc.SetParameterValue("preparedby", HRISMain.lblUsername.Text)
        HRISReportViewer.CrystalReportViewer1.ReportSource = rptDoc
        Me.Close()
        HRISReportViewer.ShowDialog()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If mode = "Leave" Then
                get_leave_record()
            Else
                print_dtr_record_summary()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class