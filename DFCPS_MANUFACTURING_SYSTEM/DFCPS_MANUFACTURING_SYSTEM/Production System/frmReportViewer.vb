Imports System.IO
Public Class frmReportViewer
    Dim picbyte As Byte()
    Dim dgv As DataGridView
    Dim stream As New MemoryStream()
    Private Function ImageToStream(ByVal fileName As String) As Byte()

tryagain:
        Try
            Dim image As New Bitmap(fileName)
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            GoTo tryagain
        End Try

        Return stream.ToArray()
    End Function
    Sub loomsSectionReport()
        Dim gn As String
        Dim st As String
        Dim c1 As String
        Dim c2 As String
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                If cmbGrouping.Text = "Per Operator" Then
                    .CommandText = "SELECT dbo.tblLoomSectionTR.LOOMSNO, dbo.tblLoomSection.DATEFROM, dbo.tblLoomSection.DATETO, dbo.tblLoomSectionTR.MESH, dbo.tblLoomSectionTR.PRODUCTION, " & _
                        "dbo.tblLoomSectionTR.EFFIENCY, dbo.tblLoomSectionTR.OPERATOR FROM dbo.tblLoomSection INNER JOIN dbo.tblLoomSectionTR " & _
                        "ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                         "where dateto between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') order by OPERATOR ASC"
                Else
                    .CommandText = "SELECT dbo.tblLoomSection.CLSNO,dbo.tblLoomSection.DATEFROM,dbo.tblLoomSection.DATETO,dbo.tblLoomSection.LOOMSCOUNT," & _
                        "dbo.tblLoomSection.TOTMETERSPROD,dbo.tblLoomSection.TOTEFF FROM dbo.tblLoomSection " & _
                         "where dateto between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "')  order by dateTo asc"
                End If

            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("typeOfReport")
                .Columns.Add("clsNo")
                .Columns.Add("date")
                .Columns.Add("itemCount")
                .Columns.Add("totProd")
                .Columns.Add("totEff")
                .Columns.Add("groupname")
                .Columns.Add("searchtype")
                .Columns.Add("dateRange")
                .Columns.Add("c1")
                .Columns.Add("c2")


            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    If cmbGrouping.Text = "Daily" Then
                        gn = Format(OleDBDR.Item(1), "MMMM dd, yyyy")
                        st = "Total Efficiency / Daily"
                        c1 = "CLSNO."
                    ElseIf cmbGrouping.Text = "Monthly" Then
                        gn = Format(OleDBDR.Item(1), "MMMM yyyy")
                        st = "Total Efficiency / Monthly"
                        c1 = "CLSNO."
                    ElseIf cmbGrouping.Text = "ALL" Then
                        gn = Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy")
                        st = "Total Efficiency"
                        c1 = "CLSNO."
                    ElseIf cmbGrouping.Text = "Per Operator" Then
                        gn = OleDBDR.Item(6)
                        st = "Total Efficiency / Operator Name"
                        c1 = "LOOM NO."
                    End If
                    dt.Rows.Add(lbltypeOfReport.Text,
                                OleDBDR.Item(0),
                                OleDBDR.Item(1),
                                OleDBDR.Item(3),
                                OleDBDR.Item(4),
                                OleDBDR.Item(5),
                                gn,
                                st,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                c1,
                                c2)
                End While
            Else
                MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                Exit Sub
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            If lbltypeOfReport.Text = "Circular Looms Section Summary Report" Then
                rptDoc = New circularLoomsReport
            ElseIf lbltypeOfReport.Text = "Circular Looms Section Chart Analytical Report" Then
                rptDoc = New circularLoomsAnalyticsReport
            End If
            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub doffedYarnSummaryReport()
        Dim gn As String
        Dim st As String
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblDYR.dTo,dbo.tblDYR.DYNO,dbo.tblDYR.DOFFEDCOUNT,SUM(dbo.tblDYTR.NOOFBOBBINS),SUM(dbo.tblDYRTR.GROSSWT),dbo.tblDYR.TOTALNETWT " & _
                    "FROM dbo.tblDYR INNER JOIN dbo.tblDYTR ON dbo.tblDYTR.DYNO = dbo.tblDYR.DYNO " & _
                    "where dto between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                    "GROUP BY dbo.tblDYR.DYNO,dbo.tblDYR.dFrom,dbo.tblDYR.dTo,dbo.tblDYR.DOFFEDCOUNT,dbo.tblDYR.TOTALNETWT order by dto asc"


            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt

                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("date")
                .Columns.Add("formNo")
                .Columns.Add("doffedCount")
                .Columns.Add("bobbinsCount")
                .Columns.Add("grossWeight")
                .Columns.Add("netWeight")


            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    If cmbGrouping.Text = "Daily" Then
                        gn = Format(OleDBDR.Item(0), "MMMM dd, yyyy")
                        st = "Daily Grouping"

                    ElseIf cmbGrouping.Text = "Monthly" Then
                        gn = Format(OleDBDR.Item(0), "MMMM yyyy")
                        st = "Monthly Grouping"


                    ElseIf cmbGrouping.Text = "ALL" Then
                        gn = Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy")
                        st = "ALL"

                    End If
                    dt.Rows.Add(lbltypeOfReport.Text,
                                gn,
                                st,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                Format(OleDBDR.Item(0), "MM/dd/yyyy"),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2),
                                OleDBDR.Item(3),
                                OleDBDR.Item(4),
                                OleDBDR.Item(5))



                End While
            Else
                MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                Exit Sub
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            If lbltypeOfReport.Text = "Doffed Yarn Summary Report" Then
                rptDoc = New doffedYarnReport
            ElseIf lbltypeOfReport.Text = "Doffed Yarn Chart Analytical Report" Then
                rptDoc = New doffedYarnReportAnalytics
            End If

            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub LoomsdoffedReport()
        Dim gn As String
        Dim st As String
        Dim meshQry As String
        Dim widthQry As String
        Dim qry As String

        If lbltypeOfReport.Text = "Looms Doffed Chart Analytical Report" Then
            If cmbGrouping.Text.Substring(0, 5) = "Daily" Then
                meshQry = cmbGrouping.Text.Substring(7, 5)
                widthQry = cmbGrouping.Text.Substring(15, 2)
            ElseIf cmbGrouping.Text.Substring(0, 7) = "Monthly" Then
                meshQry = cmbGrouping.Text.Substring(9, 5)
                widthQry = cmbGrouping.Text.Substring(17, 2)
            End If

            qry = " and tblDoffed.mesh = '" & meshQry & "' and tblDoffed.width = '" & widthQry & "' "
        End If


        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblLoomSection.DATETO,dbo.tblLoomSectionTR.LOOMSNO,dbo.tblDoffed.rollNo,dbo.tblDoffed.mesh,dbo.tblDoffed.width,dbo.tblDoffed.denier," & _
                    "dbo.tblLoomSectionTR.DOFFEDL,dbo.tblLoomSectionTR.DOFFEDWT FROM dbo.tblLoomSection INNER JOIN dbo.tblLoomSectionTR ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO  " & _
                    "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblLoomSectionTR.rollNo " & _
                    "where DATETO between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & qry & "  order by DATETO asc"


            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt

                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("date")
                .Columns.Add("loomNo")
                .Columns.Add("rollNo")
                .Columns.Add("size")
                .Columns.Add("denier")
                .Columns.Add("weight")
                .Columns.Add("length")


            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    If lbltypeOfReport.Text = "Looms Doffed Chart Analytical Report" Then
                        If cmbGrouping.Text.Substring(0, 5) = "Daily" Then
                            gn = Format(OleDBDR.Item(0), "MMMM dd, yyyy")
                            st = "Daily Grouping"
                        ElseIf cmbGrouping.Text.Substring(0, 7) = "Monthly" Then
                            gn = Format(OleDBDR.Item(0), "MMMM yyyy")
                            st = "Monthly Grouping"
                        End If
                    ElseIf lbltypeOfReport.Text = "Looms Doffed Summary Report" Then
                        If cmbGrouping.Text = "Daily" Then
                            gn = Format(OleDBDR.Item(0), "MMMM dd, yyyy")
                            st = "Daily Grouping"
                        ElseIf cmbGrouping.Text = "Monthly" Then
                            gn = Format(OleDBDR.Item(0), "MMMM yyyy")
                            st = "Monthly Grouping"
                        ElseIf cmbGrouping.Text = "ALL" Then
                            gn = Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy")
                            st = "ALL"
                        End If
                    End If

                    dt.Rows.Add(lbltypeOfReport.Text,
                                gn,
                                st,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                Format(OleDBDR.Item(0), "MM/dd/yyyy"),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2),
                                OleDBDR.Item(3) & " - " & OleDBDR.Item(4),
                                OleDBDR.Item(5),
                                OleDBDR.Item(6),
                                OleDBDR.Item(7))



                End While
            Else
                MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                Exit Sub
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            If lbltypeOfReport.Text = "Looms Doffed Summary Report" Then
                rptDoc = New loomsDoffedReport
            ElseIf lbltypeOfReport.Text = "Looms Doffed Chart Analytical Report" Then
                rptDoc = New loomsDoffedReportAnalytics
            End If

            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub FPReport()
        Dim gn As String
        Dim st As String
        Dim meshQry As String
        Dim widthQry As String
        Dim qry As String

        If lbltypeOfReport.Text = "Finished Product Analytical Report" Then
            If cmbGrouping.Text.Substring(0, 5) = "Daily" Then
                meshQry = cmbGrouping.Text.Substring(7, 5)
                widthQry = cmbGrouping.Text.Substring(15, 2)
            ElseIf cmbGrouping.Text.Substring(0, 7) = "Monthly" Then
                meshQry = cmbGrouping.Text.Substring(9, 5)
                widthQry = cmbGrouping.Text.Substring(17, 2)
            End If

            qry = " and tblDoffed.mesh = '" & meshQry & "' and tblDoffed.width = '" & widthQry & "' "
        End If


        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblCSR.dTo,dbo.tblDoffed.rollNo,dbo.tblDoffed.mesh,dbo.tblDoffed.width,dbo.tblCSRTR.inputLength,dbo.tblCSRTR.badLength,dbo.tblCSRTR.outputQty," & _
                    "dbo.tblFPITR.weavReject,dbo.tblFPITR.printReject,dbo.tblFPITR.sewingReject,dbo.tblFPITR.netQTY " & _
                    "FROM dbo.tblCSR INNER JOIN dbo.tblCSRTR ON dbo.tblCSRTR.CSRNO = dbo.tblCSR.CSRNO INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                    "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                    "where dto between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & qry & "  order by dto asc"


            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt

                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("date")
                .Columns.Add("rollNo")
                .Columns.Add("size")
                .Columns.Add("inputLength")
                .Columns.Add("bagLength")
                .Columns.Add("outputQTY")
                .Columns.Add("wr")
                .Columns.Add("pr")
                .Columns.Add("sr")
                .Columns.Add("netQty")


            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    If lbltypeOfReport.Text = "Finished Product Analytical Report" Then
                        If cmbGrouping.Text.Substring(0, 5) = "Daily" Then
                            gn = Format(OleDBDR.Item(0), "MMMM dd, yyyy")
                            st = "Daily Grouping"
                        ElseIf cmbGrouping.Text.Substring(0, 7) = "Monthly" Then
                            gn = Format(OleDBDR.Item(0), "MMMM yyyy")
                            st = "Monthly Grouping"
                        End If
                    ElseIf lbltypeOfReport.Text = "Finished Product Summary Report" Then
                        If cmbGrouping.Text = "Daily" Then
                            gn = Format(OleDBDR.Item(0), "MMMM dd, yyyy")
                            st = "Daily Grouping"
                        ElseIf cmbGrouping.Text = "Monthly" Then
                            gn = Format(OleDBDR.Item(0), "MMMM yyyy")
                            st = "Monthly Grouping"
                        ElseIf cmbGrouping.Text = "ALL" Then
                            gn = Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy")
                            st = "ALL"
                        End If
                    End If
                    dt.Rows.Add(lbltypeOfReport.Text,
                                gn,
                                st,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                Format(OleDBDR.Item(0), "MM/dd/yyyy"),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2) & " - " & OleDBDR.Item(3),
                                OleDBDR.Item(4),
                                OleDBDR.Item(5),
                                OleDBDR.Item(6),
                                OleDBDR.Item(7),
                                OleDBDR.Item(8),
                                OleDBDR.Item(9),
                                OleDBDR.Item(10))



                End While
            Else
                MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                Exit Sub
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            If lbltypeOfReport.Text = "Finished Product Summary Report" Then
                rptDoc = New FinishProductSummaryReport
            ElseIf lbltypeOfReport.Text = "Finished Product Analytical Report" Then
                rptDoc = New FinishProductAnalyticsReport
            End If

            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub DYWasteReport()
        Dim gn As String
        Dim st As String
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblPDORFY.dTo,dbo.tblPDORFY.WasteYarn FROM dbo.tblPDORFY " & _
                            "where dto between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & "  order by dto asc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("DYdate")
                .Columns.Add("DYwaste")

            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    If cmbGrouping.Text = "Daily" Then
                        gn = Format(OleDBDR.Item(0), "MMMM dd, yyyy")
                        st = "Daily Grouping"

                    ElseIf cmbGrouping.Text = "Monthly" Then
                        gn = Format(OleDBDR.Item(0), "MMMM yyyy")
                        st = "Monthly Grouping"


                    ElseIf cmbGrouping.Text = "ALL" Then
                        gn = Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy")
                        st = "ALL"

                    End If
                    dt.Rows.Add(lbltypeOfReport.Text,
                                gn,
                                st,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                Format(OleDBDR.Item(0), "MM/dd/yyyy"),
                                OleDBDR.Item(1))




                End While
            Else
                MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                Exit Sub
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New DYWasteReportAnalytics

            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub RejectWasteReport()
        Dim gn As String
        Dim st As String
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblFPI.dTo,dbo.tblFPITR.weavReject,dbo.tblFPITR.printReject,dbo.tblFPITR.sewingReject FROM dbo.tblFPITR INNER JOIN dbo.tblFPI ON dbo.tblFPITR.fpiNo = dbo.tblFPI.fpiNo " & _
                             "where dto between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & "  order by dto asc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("FPIdate")
                .Columns.Add("FPIwr")
                .Columns.Add("FPIpr")
                .Columns.Add("FPIsr")

            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    If cmbGrouping.Text = "Daily" Then
                        gn = Format(OleDBDR.Item(0), "MMMM dd, yyyy")
                        st = "Daily Grouping"

                    ElseIf cmbGrouping.Text = "Monthly" Then
                        gn = Format(OleDBDR.Item(0), "MMMM yyyy")
                        st = "Monthly Grouping"


                    ElseIf cmbGrouping.Text = "ALL" Then
                        gn = Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy")
                        st = "ALL"

                    End If
                    dt.Rows.Add(lbltypeOfReport.Text,
                                gn,
                                st,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                Format(OleDBDR.Item(0), "MM/dd/yyyy"),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2),
                                OleDBDR.Item(3))




                End While
            Else
                MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                Exit Sub
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New RejectWasteReportAnalytics

            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub YarnProductionReport()
        Dim gn As String
        Dim st As String
        Dim dformat As String


        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT convert(date,[date]) AS DATES, " & _
                            "sum(dbo.tblRMWTR.QTY) AS WIDRAWQTY, " & _
                            "'0' AS WASTEQTY, " & _
                            "'0' AS NETWTPRODUCED, " & _
                            "'0' AS HOURS " & _
                            "FROM dbo.tblRMW " & _
                            "INNER JOIN dbo.tblRMWTR ON dbo.tblRMW.RMWNO = dbo.tblRMWTR.RMWNO " & _
                            "where [date] between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                            "GROUP BY convert(date,[date]) " & _
                            "UNION " & _
                            "SELECT convert(date,dfrom) AS DATES, " & _
                            "'0' AS WIDRAWQTY, " & _
                            "sum(WasteYarn) AS WASTEQTY, " & _
                            "'0' AS NETWTPRODUCED, " & _
                            "'0' AS HOURS " & _
                            "from tblPDORFY " & _
                            "where dfrom between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                            "GROUP BY convert(date,dfrom) " & _
                            "UNION " & _
                            "SELECT convert(date,dfrom) AS DATES, " & _
                            "'0' AS WIDRAWQTY, " & _
                            "'0' AS WASTEQTY, " & _
                            "sum(TOTALNETWT) AS NETWTPRODUCED, " & _
                            "SUM(DATEDIFF(HOUR, timeStart, timeEnd)) AS HOURS " & _
                            "from tblDYR " & _
                            "where dfrom between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                            "GROUP BY convert(date,dfrom) " & _
                            "order by dates asc "



            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            Dim dt1 As New DataTable
            With dt

                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("date")
                .Columns.Add("RawMaterialsWidraw")
                .Columns.Add("waste")
                .Columns.Add("netWt")
                .Columns.Add("HOURS")

            End With
            If OleDBDR.HasRows Then
                Dim dater As DateTime = dfrom.Text
                While dater <= dto.Value
                    While OleDBDR.Read
                        If dater < OleDBDR.Item(0) Then
                            'dater = DateAdd(DateInterval.Day, 1, dater)
                        ElseIf dater > OleDBDR.Item(0) Then
                            dater = OleDBDR.Item(0)
                        End If
                        If cmbGrouping.Text = "Daily" Then
                            dformat = "MMM dd"
                            gn = Format(OleDBDR.Item(0), dformat)
                            st = "Daily"
                        ElseIf cmbGrouping.Text = "Weekly" Then
                            dformat = "MMMM"
                            Dim dateday As Integer = Format(OleDBDR.Item(0), "dd")
                            If dateday <= 7 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 1 - 7"
                                st = "Weekly"
                            ElseIf dateday <= 14 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 8 - 14"
                                st = "Weekly"
                            ElseIf dateday <= 21 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 15 - 21"
                                st = "Weekly"
                            ElseIf dateday <= 31 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 22 - " & Format(dto.Value, "dd")
                                st = "Weekly"
                            End If
                        ElseIf cmbGrouping.Text = "Monthly" Then
                            dformat = "MMM yyyy"
                            gn = Format(OleDBDR.Item(0), dformat)
                            st = "Monthly"
                        ElseIf cmbGrouping.Text = "ALL" Then
                            dformat = "MMM dd, yyyy"
                            gn = Format(dfrom.Value, dformat) & " - " & Format(dto.Value, dformat)
                            st = "ALL"
                        End If
                        Dim ndate As DateTime = OleDBDR.Item(0)
                        While dater <= ndate
                            If dater = ndate Then
                                dt.Rows.Add("YARN",
                                            gn,
                                            (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                            Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                            OleDBDR.Item(0),
                                            OleDBDR.Item(1),
                                            OleDBDR.Item(2),
                                            OleDBDR.Item(3),
                                            OleDBDR.Item(4))
                            Else
                                Dim gs As String
                                If dater > OleDBDR.Item(0) Then
                                    gs = Format(OleDBDR.Item(0), dformat)
                                Else
                                    gs = Format(dater, dformat)
                                End If
                                dt.Rows.Add("YARN",
                                            gs,
                                              (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                            Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                            dater,
                                            "0",
                                            "0",
                                            "0",
                                            "0")
                            End If
                            dater = DateAdd(DateInterval.Day, 1, dater)
                        End While
                    End While
                    Dim g As String
                    g = Format(dater, dformat)
                    dt.Rows.Add("YARN",
                                g,
                              (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                dater,
                                "0",
                                "0",
                                "0",
                                "0")
                    dater = DateAdd(DateInterval.Day, 1, dater)
                End While

            Else
                'MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                'Exit Sub
                Dim dater As DateTime = dfrom.Text
                While dater <= dto.Value
                    If cmbGrouping.Text = "Daily" Then
                        dformat = "MMM dd"
                        gn = Format(dater, dformat)
                        st = "Daily"
                    ElseIf cmbGrouping.Text = "Weekly" Then
                        dformat = "MMMM"
                        Dim dateday As Integer = Format(dater, "dd")
                        If dateday <= 7 Then
                            gn = Format(dater, dformat) & " 1 - 7"
                            st = "Weekly"
                        ElseIf dateday <= 14 Then
                            gn = Format(dater, dformat) & " 8 - 14"
                            st = "Weekly"
                        ElseIf dateday <= 21 Then
                            gn = Format(dater, dformat) & " 15 - 21"
                            st = "Weekly"
                        ElseIf dateday <= 31 Then
                            gn = Format(dater, dformat) & " 22 - " & Format(dto.Value, "dd")
                            st = "Weekly"
                        End If
                    ElseIf cmbGrouping.Text = "Monthly" Then
                        dformat = "MMM yyyy"
                        gn = Format(dater, dformat)
                        st = "Monthly"
                    ElseIf cmbGrouping.Text = "ALL" Then
                        dformat = "MMM dd, yyyy"
                        gn = Format(dfrom.Value, dformat) & " - " & Format(dto.Value, dformat)
                        st = "ALL"
                    End If
                    Dim g As String
                    g = Format(dater, dformat)
                    dt.Rows.Add("Circular Loom",
                                g,
                              (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                dater,
                                "0",
                                "0",
                                "0",
                                "0")
                    dater = DateAdd(DateInterval.Day, 1, dater)

                End While
            End If

            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New YarnProductionReport


            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub LoomsProductionReport()
        Dim gn As String
        Dim st As String
        Dim dformat As String


        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT convert(date,datefrom) AS DATES,dbo.tblLoomSectionTR.LOOMSNO,'',dbo.tblLoomSectionTR.PRODUCTION," & _
                             "dbo.tblLoomSectionTR.EFFIENCY,dbo.tblLoomSectionTR.DOFFEDL,dbo.tblLoomSectionTR.DOFFEDWT,dbo.tblLoomSectionTR.WASTE FROM dbo.tblLoomSection INNER JOIN dbo.tblLoomSectionTR " & _
                                         "ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                                         "where DATEFROM between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                         "order by dates asc "



            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            Dim dt1 As New DataTable
            With dt
                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("dfrom")
                .Columns.Add("loomsNo")
                .Columns.Add("loomsCount")
                .Columns.Add("operator")
                .Columns.Add("production")
                .Columns.Add("eff")
                .Columns.Add("doffedL")
                .Columns.Add("doffedWT")
                .Columns.Add("waste")

            End With
            If OleDBDR.HasRows Then
                Dim dater As DateTime = dfrom.Text
                While dater <= dto.Value
                    While OleDBDR.Read
                        If dater < OleDBDR.Item(0) Then
                            'dater = DateAdd(DateInterval.Day, 1, dater)
                        ElseIf dater > OleDBDR.Item(0) Then
                            dater = OleDBDR.Item(0)
                        End If
                        If cmbGrouping.Text = "Daily" Then
                            dformat = "MMM dd"
                            gn = Format(OleDBDR.Item(0), dformat)
                            st = "Daily"
                        ElseIf cmbGrouping.Text = "Weekly" Then
                            dformat = "MMMM"
                            Dim dateday As Integer = Format(OleDBDR.Item(0), "dd")
                            If dateday <= 7 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 1 - 7"
                                st = "Weekly"
                            ElseIf dateday <= 14 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 8 - 14"
                                st = "Weekly"
                            ElseIf dateday <= 21 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 15 - 21"
                                st = "Weekly"
                            ElseIf dateday <= 31 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 22 - " & Format(dto.Value, "dd")
                                st = "Weekly"
                            End If
                        ElseIf cmbGrouping.Text = "Monthly" Then
                            dformat = "MMM yyyy"
                            gn = Format(OleDBDR.Item(0), dformat)
                            st = "Monthly"
                        ElseIf cmbGrouping.Text = "ALL" Then
                            dformat = "MMM dd, yyyy"
                            gn = Format(dfrom.Value, dformat) & " - " & Format(dto.Value, dformat)
                            st = "ALL"
                        End If
                        Dim ndate As DateTime = OleDBDR.Item(0)
                        While dater <= ndate
                            If dater = ndate Then
                                dt.Rows.Add("CIRCULAR LOOM",
                                 gn,
                                (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                OleDBDR.Item(0),
                                OleDBDR.Item(1),
                                 "1",
                                 OleDBDR.Item(2),
                                 OleDBDR.Item(3),
                                 OleDBDR.Item(4),
                                 OleDBDR.Item(5),
                                 OleDBDR.Item(6),
                                 OleDBDR.Item(7))
                            Else
                                Dim gs As String
                                If dater > OleDBDR.Item(0) Then
                                    gs = Format(OleDBDR.Item(0), dformat)
                                Else
                                    gs = Format(dater, dformat)
                                End If
                                dt.Rows.Add("CIRCULAR LOOM",
                                            gs,
                                              (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                            Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                            dater,
                                            "0",
                                            "0",
                                            "0",
                                            "0",
                                            "0",
                                            "0",
                                            "0",
                                            "0")
                            End If
                            dater = DateAdd(DateInterval.Day, 1, dater)
                        End While
                    End While
                    Dim g As String
                    g = Format(dater, dformat)
                    dt.Rows.Add("CIRCULAR LOOM",
                                g,
                              (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                dater,
                                 "0",
                                 "0",
                                 "0",
                                 "0",
                                 "0",
                                 "0",
                                 "0",
                                 "0")
                    dater = DateAdd(DateInterval.Day, 1, dater)
                End While

            Else
                'MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                'Exit Sub
                Dim dater As DateTime = dfrom.Text
                While dater <= dto.Value
                    If cmbGrouping.Text = "Daily" Then
                        dformat = "MMM dd"
                        gn = Format(dater, dformat)
                        st = "Daily"
                    ElseIf cmbGrouping.Text = "Weekly" Then
                        dformat = "MMMM"
                        Dim dateday As Integer = Format(dater, "dd")
                        If dateday <= 7 Then
                            gn = Format(dater, dformat) & " 1 - 7"
                            st = "Weekly"
                        ElseIf dateday <= 14 Then
                            gn = Format(dater, dformat) & " 8 - 14"
                            st = "Weekly"
                        ElseIf dateday <= 21 Then
                            gn = Format(dater, dformat) & " 15 - 21"
                            st = "Weekly"
                        ElseIf dateday <= 31 Then
                            gn = Format(dater, dformat) & " 22 - " & Format(dto.Value, "dd")
                            st = "Weekly"
                        End If
                    ElseIf cmbGrouping.Text = "Monthly" Then
                        dformat = "MMM yyyy"
                        gn = Format(dater, dformat)
                        st = "Monthly"
                    ElseIf cmbGrouping.Text = "ALL" Then
                        dformat = "MMM dd, yyyy"
                        gn = Format(dfrom.Value, dformat) & " - " & Format(dto.Value, dformat)
                        st = "ALL"
                    End If
                    Dim g As String
                    g = Format(dater, dformat)
                    dt.Rows.Add("Circular Loom",
                                g,
                              (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                dater,
                                "0",
                                "0",
                                "0",
                                "0",
                                "0",
                                "0",
                                "0",
                                "0")
                    dater = DateAdd(DateInterval.Day, 1, dater)

                End While
            End If

            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New LoomProductionReport
            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CSProductionReport()
        Dim gn As String
        Dim st As String
        Dim dformat As String


        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblCSR.dFrom,dbo.tblCSRTR.rollNo,dbo.tblCSRTR.inputLength,dbo.tblCSRTR.outputQty,dbo.tblCSRTR.badLength," & _
                                "dbo.tblFPITR.weavReject,dbo.tblFPITR.netQTY FROM dbo.tblCSRTR INNER JOIN dbo.tblCSR ON dbo.tblCSR.CSRNO = dbo.tblCSRTR.CSRNO " & _
                                "INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                                "where tblCSR.dfrom between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                "order by tblCSR.dfrom asc "



            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            Dim dt1 As New DataTable
            With dt
                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("dfrom")
                .Columns.Add("rollNo")
                .Columns.Add("rollCount")
                .Columns.Add("InputL")
                .Columns.Add("outputQTY")
                .Columns.Add("bagL")
                .Columns.Add("weavReject")
                .Columns.Add("netQTY")

            End With
            If OleDBDR.HasRows Then
                Dim dater As DateTime = dfrom.Text
                While dater <= dto.Value
                    While OleDBDR.Read
                        If dater < OleDBDR.Item(0) Then
                            'dater = DateAdd(DateInterval.Day, 1, dater)
                        ElseIf dater > OleDBDR.Item(0) Then
                            dater = OleDBDR.Item(0)
                        End If
                        If cmbGrouping.Text = "Daily" Then
                            dformat = "MMM dd"
                            gn = Format(OleDBDR.Item(0), dformat)
                            st = "Daily"
                        ElseIf cmbGrouping.Text = "Weekly" Then
                            dformat = "MMMM"
                            Dim dateday As Integer = Format(OleDBDR.Item(0), "dd")
                            If dateday <= 7 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 1 - 7"
                                st = "Weekly"
                            ElseIf dateday <= 14 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 8 - 14"
                                st = "Weekly"
                            ElseIf dateday <= 21 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 15 - 21"
                                st = "Weekly"
                            ElseIf dateday <= 31 Then
                                gn = Format(OleDBDR.Item(0), dformat) & " 22 - " & Format(dto.Value, "dd")
                                st = "Weekly"
                            End If
                        ElseIf cmbGrouping.Text = "Monthly" Then
                            dformat = "MMM yyyy"
                            gn = Format(OleDBDR.Item(0), dformat)
                            st = "Monthly"
                        ElseIf cmbGrouping.Text = "ALL" Then
                            dformat = "MMM dd, yyyy"
                            gn = Format(dfrom.Value, dformat) & " - " & Format(dto.Value, dformat)
                            st = "ALL"
                        End If
                        Dim ndate As DateTime = OleDBDR.Item(0)
                        While dater <= ndate
                            If dater = ndate Then
                                dt.Rows.Add("CIRCULAR LOOM",
                                 gn,
                                (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                OleDBDR.Item(0),
                                OleDBDR.Item(1),
                                "1",
                                 OleDBDR.Item(2),
                                 OleDBDR.Item(3),
                                 OleDBDR.Item(4),
                                 OleDBDR.Item(5),
                                 OleDBDR.Item(6))
                            Else
                                Dim gs As String
                                If dater > OleDBDR.Item(0) Then
                                    gs = Format(OleDBDR.Item(0), dformat)
                                Else
                                    gs = Format(dater, dformat)
                                End If
                                dt.Rows.Add("CIRCULAR LOOM",
                                            gs,
                                              (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                            Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                            dater,
                                            "0",
                                            "0",
                                            "0",
                                            "0",
                                            "0",
                                            "0",
                                            "0")
                            End If
                            dater = DateAdd(DateInterval.Day, 1, dater)
                        End While
                    End While
                    Dim g As String
                    g = Format(dater, dformat)
                    dt.Rows.Add("CIRCULAR LOOM",
                                g,
                              (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                dater,
                                 "0",
                                 "0",
                                 "0",
                                 "0",
                                 "0",
                                 "0",
                                 "0")
                    dater = DateAdd(DateInterval.Day, 1, dater)
                End While

            Else
                'MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                'Exit Sub
                Dim dater As DateTime = dfrom.Text
                While dater <= dto.Value
                    If cmbGrouping.Text = "Daily" Then
                        dformat = "MMM dd"
                        gn = Format(dater, dformat)
                        st = "Daily"
                    ElseIf cmbGrouping.Text = "Weekly" Then
                        dformat = "MMMM"
                        Dim dateday As Integer = Format(dater, "dd")
                        If dateday <= 7 Then
                            gn = Format(dater, dformat) & " 1 - 7"
                            st = "Weekly"
                        ElseIf dateday <= 14 Then
                            gn = Format(dater, dformat) & " 8 - 14"
                            st = "Weekly"
                        ElseIf dateday <= 21 Then
                            gn = Format(dater, dformat) & " 15 - 21"
                            st = "Weekly"
                        ElseIf dateday <= 31 Then
                            gn = Format(dater, dformat) & " 22 - " & Format(dto.Value, "dd")
                            st = "Weekly"
                        End If
                    ElseIf cmbGrouping.Text = "Monthly" Then
                        dformat = "MMM yyyy"
                        gn = Format(dater, dformat)
                        st = "Monthly"
                    ElseIf cmbGrouping.Text = "ALL" Then
                        dformat = "MMM dd, yyyy"
                        gn = Format(dfrom.Value, dformat) & " - " & Format(dto.Value, dformat)
                        st = "ALL"
                    End If
                    Dim g As String
                    g = Format(dater, dformat)
                    dt.Rows.Add("Circular Loom",
                                g,
                              (DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                dater,
                                "0",
                                "0",
                                "0",
                                "0",
                                "0",
                                "0",
                                "0")
                    dater = DateAdd(DateInterval.Day, 1, dater)

                End While
            End If

            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New CSProductionReport
            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub PerOperatorReport()
        Dim gn As String
        Dim st As String
        Dim dformat As String


        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT CONVERT(DATE,dbo.tblLoomSection.DATEFROM) AS DATES, " & _
                                "dbo.tblEmployeesInfo.NAME, " & _
                                "dbo.tblLoomSectionTR.EFFIENCY, " & _
                                "dbo.tblLoomSectionTR.WASTE, " & _
                                "'0' AS NOOFWORKEDHOURS, " & _
                                "'0' AS LATE " & _
                                "FROM dbo.tblLoomSectionTR " & _
                                "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblLoomSectionTR.BIONO " & _
                                "INNER JOIN dbo.tblLoomSection ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                                "where CONVERT(DATE,dbo.tblLoomSection.DATEFROM) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                "UNION " & _
                                "SELECT CONVERT(DATE,dbo.tblAttendance.AM_IN) AS DATES, " & _
                                "dbo.tblEmployeesInfo.NAME, " & _
                                "'0', " & _
                                "'0', " & _
                                "dbo.tblAttendance.NOOFWORKEDHOURS AS NOOFWORKEDHOURS, " & _
                                "dbo.tblAttendance.LATE_MINS AS LATE " & _
                                "FROM dbo.tblAttendance " & _
                                "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblAttendance.BIONO = dbo.tblEmployeesInfo.BIONO " & _
                                "where CONVERT(DATE,dbo.tblAttendance.AM_IN) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                "order by dates asc "


            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt

                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("date")
                .Columns.Add("NAME")
                .Columns.Add("EFFICIENCY")
                .Columns.Add("COUNT")
                .Columns.Add("WASTE")
                .Columns.Add("NOOFWORKEDHOURS")
                .Columns.Add("LATE")

            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    If cmbGrouping.Text = "Per Operator" Then
                        gn = OleDBDR.Item(1)
                        st = "Per Operator"
                    End If
                    Dim COUNT As Integer
                    If OleDBDR.Item(2) <> "0" Then
                        COUNT = "1"
                    Else
                        COUNT = "0"
                    End If
                    dt.Rows.Add(lbltypeOfReport.Text,
                                gn,
                                st,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                OleDBDR.Item(0),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2),
                                COUNT,
                                OleDBDR.Item(3),
                                OleDBDR.Item(4),
                                OleDBDR.Item(5))
                End While
            Else
                MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                Exit Sub

            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New PerformanceReport
            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub PerOperatorCSReport()
        Dim gn As String
        Dim st As String
        Dim dformat As String


        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "WITH TOTAL AS (SELECT " & _
                 "dbo.tblEmployeesInfo.NAME AS name, " & _
                 "SUM(dbo.tblLoomSectionTR.EFFIENCY)/count(tblLoomSectionTR.LOOMSNO) AS eff, " & _
                 "SUM(dbo.tblLoomSectionTR.PRODUCTION) AS doffed, " & _
                 "0 AS inputqty, " & _
                 "0 AS netqty, " & _
                 "0 AS reject  " & _
                "FROM " & _
                "dbo.tblLoomSectionTR " & _
                 "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblLoomSectionTR.BIONO " & _
                 "INNER JOIN dbo.tblLoomSection ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                  "where CONVERT(DATE,DATEFROM) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                 "GROUP BY dbo.tblEmployeesInfo.NAME " & _
                "UNION " & _
                "SELECT " & _
                 "dbo.tblEmployeesInfo.NAME AS name, " & _
                 "0 AS eff, " & _
                 "0 AS doffed, " & _
                 "SUM(dbo.tblFPITR.inputQTY) AS inputqty, " & _
                 "SUM(dbo.tblFPITR.netQTY) AS netqty, " & _
                 "SUM(dbo.tblFPITR.weavReject) AS reject " & _
                "FROM " & _
                "dbo.tblDoffed " & _
                 "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblDoffed.BIONO = dbo.tblEmployeesInfo.BIONO " & _
                 "INNER JOIN dbo.tblCSRTR ON dbo.tblCSRTR.rollNo = dbo.tblDoffed.rollNo " & _
                 "INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                 "INNER JOIN dbo.tblCSR ON dbo.tblCSRTR.CSRNO = dbo.tblCSR.CSRNO " & _
                 "INNER JOIN dbo.tblLoomSectionTR ON dbo.tblCSRTR.rollNo = dbo.tblLoomSectionTR.rollNo " & _
                 "INNER JOIN dbo.tblLoomSection ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                 "where CONVERT(DATE,tblLoomSection.datefrom) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                 "GROUP BY NAME) " & _
                 "SELECT name as name, SUM(EFF) as toteff,SUM(DOFFED) as totdoffed,SUM(INPUTQTY) as inputqty,SUM(NETQTY) as netqty,SUM(REJECT) as reject " & _
                "FROM TOTAL " & _
                "GROUP BY NAME " & _
                "ORDER BY " & _
                "inputQTY DESC "


            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt

                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("NAME")
                .Columns.Add("EFFICIENCY")
                .Columns.Add("PRODUCTIONMETERS")
                .Columns.Add("INPUT")
                .Columns.Add("NET")
                .Columns.Add("REJECT")


            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    If cmbGrouping.Text = "Per Operator" Then
                        gn = OleDBDR.Item(0)
                        st = "Per Operator"
                    End If

                    dt.Rows.Add(lbltypeOfReport.Text,
                                gn,
                                st,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                OleDBDR.Item(0),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2),
                                OleDBDR.Item(3),
                                OleDBDR.Item(4),
                                OleDBDR.Item(5))
                End While
            Else
                MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                Exit Sub
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New PerformanceCSReport
            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub RankingReport()
        Dim gn As String
        Dim st As String
        Dim dformat As String


        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "WITH total AS (" & _
                                "SELECT tblEmployeesInfo.NAME, " & _
                                "DENSE_RANK() OVER (ORDER BY SUM(dbo.tblLoomSectionTR.EFFIENCY) / COUNT(dbo.tblLoomSectionTR.LOOMSNO) DESC) AS EFF, " & _
                                "0 as DOFFEDL, " & _
                                "0 AS INPUTQTY, " & _
                                "0 AS NETOUTPUT, " & _
                                "0 AS wastePercent " & _
                                "FROM " & _
                                "dbo.tblLoomSectionTR " & _
                                "INNER JOIN dbo.tblLoomSection ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                                "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblLoomSectionTR.BIONO = dbo.tblEmployeesInfo.BIONO " & _
                                 "where CONVERT(DATE,DATEFROM) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                "GROUP BY tblEmployeesInfo.NAME " & _
                                "UNION " & _
                                "SELECT " & _
                                "tblEmployeesInfo.NAME, " & _
                                "0 AS EFF, " & _
                                "DENSE_RANK() OVER (ORDER BY SUM(dbo.tblLoomSectionTR.DOFFEDL) DESC) AS DOFFEDL, " & _
                                "0 AS INPUTQTY, " & _
                                "0 AS NETOUTPUT, " & _
                                "0 AS wastePercent " & _
                                "FROM " & _
                                "dbo.tblLoomSectionTR " & _
                                "INNER JOIN dbo.tblLoomSection ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                                "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblLoomSectionTR.BIONO = dbo.tblEmployeesInfo.BIONO " & _
                                "where CONVERT(DATE,DATEFROM) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                "GROUP BY tblEmployeesInfo.NAME " & _
                                "UNION " & _
                                "SELECT " & _
                                "tblEmployeesInfo.NAME, " & _
                                "0 AS EFF, " & _
                                "0 AS DOFFEDL, " & _
                                "DENSE_RANK() OVER (ORDER BY SUM(dbo.tblFPITR.inputQTY) DESC) AS INPUTQTY, " & _
                                "0 AS NETOUTPUT, " & _
                                "0 AS wastePercent " & _
                                "FROM " & _
                                "dbo.tblCSRTR " & _
                                "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                                "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblDoffed.BIONO " & _
                                "INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                                "INNER JOIN dbo.tblCSR ON dbo.tblCSR.CSRNO = dbo.tblCSRTR.CSRNO " & _
                                "INNER JOIN dbo.tblLoomSectionTR ON dbo.tblCSRTR.rollNo = dbo.tblLoomSectionTR.rollNo " & _
                 "INNER JOIN dbo.tblLoomSection ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                 "where CONVERT(DATE,tblLoomSection.datefrom) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                "GROUP BY tblEmployeesInfo.NAME " & _
                                "UNION " & _
                                "SELECT " & _
                                "tblEmployeesInfo.NAME, " & _
                                "0 AS EFF, " & _
                                "0 AS DOFFEDL, " & _
                                "0 AS INPUTQTY, " & _
                                "DENSE_RANK() OVER (ORDER BY SUM(dbo.tblFPITR.netQTY) DESC) AS NETOUTPUT, " & _
                                "0 AS wastePercent " & _
                                "FROM " & _
                                "dbo.tblCSRTR " & _
                                "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                                "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblDoffed.BIONO " & _
                                "INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                                "INNER JOIN dbo.tblCSR ON dbo.tblCSR.CSRNO = dbo.tblCSRTR.CSRNO " & _
                             "INNER JOIN dbo.tblLoomSectionTR ON dbo.tblCSRTR.rollNo = dbo.tblLoomSectionTR.rollNo " & _
                 "INNER JOIN dbo.tblLoomSection ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                 "where CONVERT(DATE,tblLoomSection.datefrom) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                "GROUP BY tblEmployeesInfo.NAME " & _
                                "UNION " & _
                                "SELECT " & _
                                "tblEmployeesInfo.NAME, " & _
                                "0 AS EFF, " & _
                                "0 AS DOFFEDL, " & _
                                "0 AS INPUTQTY, " & _
                                "0 AS NETOUTPUT, " & _
                                "DENSE_RANK() OVER (ORDER BY (SUM(dbo.tblFPITR.weavReject)/SUM(dbo.tblFPITR.inputQTY)) ASC) AS wastePercent " & _
                                "FROM " & _
                                "dbo.tblCSRTR " & _
                                "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                                "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblDoffed.BIONO " & _
                                "INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                                "INNER JOIN dbo.tblCSR ON dbo.tblCSR.CSRNO = dbo.tblCSRTR.CSRNO " & _
                       "INNER JOIN dbo.tblLoomSectionTR ON dbo.tblCSRTR.rollNo = dbo.tblLoomSectionTR.rollNo " & _
                 "INNER JOIN dbo.tblLoomSection ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                 "where CONVERT(DATE,tblLoomSection.datefrom) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                "GROUP BY tblEmployeesInfo.NAME ) " & _
                                "select NAME AS NAME,SUM(EFF) AS TOTEFF,SUM(DOFFEDL) AS TOTDOFFED,SUM(INPUTQTY) AS TOTINPUTQTY,SUM(NETOUTPUT) TOTNET," & _
                                "SUM ( wastePercent ) AS PERCENTWASTE, " & _
                                "CASE " & _
                                "WHEN SUM ( EFF ) = 0 THEN " & _
                                "( " & _
                                "Select COUNT " & _
                                "( DISTINCT tblEmployeesInfo.NAME ) + 1 " & _
                                "FROM " & _
                                "dbo.tblCSRTR " & _
                                "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                                "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblDoffed.BIONO " & _
                                "INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                                "INNER JOIN dbo.tblCSR ON dbo.tblCSR.CSRNO = dbo.tblCSRTR.CSRNO " & _
                                "where CONVERT(DATE,dfrom) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                 ") ELSE SUM ( EFF )  " & _
                                 "END + " & _
                                "CASE " & _
                                  "WHEN SUM ( DOFFEDL ) = 0 THEN " & _
                                  "( " & _
                                  "Select COUNT " & _
                                   "( DISTINCT tblEmployeesInfo.NAME ) + 1  " & _
                                "FROM " & _
                                "dbo.tblCSRTR " & _
                               "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                               "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblDoffed.BIONO " & _
                               "INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                               "INNER JOIN dbo.tblCSR ON dbo.tblCSR.CSRNO = dbo.tblCSRTR.CSRNO  " & _
                               "where CONVERT(DATE,dfrom) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                  ") ELSE SUM ( DOFFEDL )  " & _
                                 "END + " & _
                                "CASE " & _
                                  "WHEN SUM ( INPUTQTY ) = 0 THEN " & _
                                  "( " & _
                                  "Select COUNT " & _
                                   "( DISTINCT tblEmployeesInfo.NAME ) + 1  " & _
                                "FROM " & _
                                "dbo.tblCSRTR " & _
                               "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                               "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblDoffed.BIONO " & _
                               "INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                               "INNER JOIN dbo.tblCSR ON dbo.tblCSR.CSRNO = dbo.tblCSRTR.CSRNO " & _
                               "where CONVERT(DATE,dfrom) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                  ") ELSE SUM ( INPUTQTY ) " & _
                                 "END + " & _
                                "CASE " & _
                                  "WHEN SUM ( NETOUTPUT ) = 0 THEN " & _
                                  "( " & _
                                  "Select COUNT " & _
                                   "( DISTINCT tblEmployeesInfo.NAME ) + 1  " & _
                                "FROM " & _
                                "dbo.tblCSRTR " & _
                               "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                               "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblDoffed.BIONO " & _
                               "INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                               "INNER JOIN dbo.tblCSR ON dbo.tblCSR.CSRNO = dbo.tblCSRTR.CSRNO " & _
                               "where CONVERT(DATE,dfrom) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                  ") ELSE SUM ( NETOUTPUT ) " & _
                                 "END + " & _
                                "CASE " & _
                                  "WHEN SUM ( wastePercent ) = 0 THEN " & _
                                  "( " & _
                                  "Select COUNT " & _
                                "( DISTINCT tblEmployeesInfo.NAME ) + 1  " & _
                                "FROM " & _
                                "dbo.tblCSRTR " & _
                               "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                               "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblDoffed.BIONO " & _
                               "INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                               "INNER JOIN dbo.tblCSR ON dbo.tblCSR.CSRNO = dbo.tblCSRTR.CSRNO " & _
                               "where CONVERT(DATE,dfrom) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                                  ") ELSE SUM ( wastePercent ) " & _
                                 "END AS TOTALSCORE  " & _
                                "FROM TOTAL " & _
                                "GROUP BY Name " & _
                                "ORDER BY TOTALSCORE ASC "

            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt

                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("NAME")
                .Columns.Add("EFFICIENCY")
                .Columns.Add("PRODUCTIONMETERS")
                .Columns.Add("INPUT")
                .Columns.Add("OUTPUT")
                .Columns.Add("WASTE")
                .Columns.Add("totalScore")
                .Columns.Add("RANKNO.")

            End With
            If OleDBDR.HasRows Then
                Dim lastScore As Integer = 0
                Dim RANKNO As Integer = 0
                While OleDBDR.Read
                    If cmbGrouping.Text = "Per Operator" Then
                        gn = OleDBDR.Item(0)
                        st = "Per Operator"
                    End If
                    If lastScore = OleDBDR.Item(6) Then
                        RANKNO = RANKNO
                    Else
                        RANKNO = RANKNO + 1
                    End If
                    lastScore = OleDBDR.Item(6)
                    dt.Rows.Add(lbltypeOfReport.Text,
                                gn,
                                st,
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                OleDBDR.Item(0),
                                OleDBDR.Item(1),
                                OleDBDR.Item(2),
                                OleDBDR.Item(3),
                                OleDBDR.Item(4),
                                OleDBDR.Item(5),
                                OleDBDR.Item(6),
                                RANKNO)
                End While
            Else
                MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                Exit Sub
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New OperatorRankingReport
            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub getPicture()
        Dim ds As New DataTable

        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT IMAGE from tblEmployeesInfo WHERE NAME = '" & cmbGrouping.Text & "'"

            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                If OleDBDR.Read Then
                    DGVS.Rows.Add()
                    DGVS.Item(0, 0).Value = OleDBDR.Item(0)
                    PictureBox1.Image = Image.FromStream(New IO.MemoryStream(CType(DGVS.Item(0, 0).Value, Byte())))
                    PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                    picbyte = stream.ToArray
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub PerOperatorDailyReport()
        Dim gn As String
        Dim st As String
        Dim dformat As String

        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "WITH TOTAL AS ( " & _
                            "SELECT " & _
                             "CONVERT ( DATE, DATEFROM ) as date, " & _
                             "dbo.tblEmployeesInfo.NAME AS name, " & _
                             "SUM ( dbo.tblLoomSectionTR.EFFIENCY ) / COUNT ( tblLoomSectionTR.LOOMSNO ) AS eff, " & _
                             "SUM ( dbo.tblLoomSectionTR.PRODUCTION ) AS doffed, " & _
                             "0 AS inputqty, " & _
                             "0 AS netqty, " & _
                             "SUM ( dbo.tblLoomSectionTR.WASTE ) AS reject  " & _
                            "FROM " & _
                            "dbo.tblLoomSectionTR " & _
                             "INNER JOIN dbo.tblEmployeesInfo ON dbo.tblEmployeesInfo.BIONO = dbo.tblLoomSectionTR.BIONO " & _
                             "INNER JOIN dbo.tblLoomSection ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                            "GROUP by  " & _
                            "CONVERT ( DATE, DATEFROM ), " & _
                            "dbo.tblEmployeesInfo.NAME " & _
                             ") SELECT " & _
                             "date as date, " & _
                             "name AS name, " & _
                             "SUM ( EFF ) AS toteff, " & _
                             "SUM ( DOFFED ) AS totdoffed, " & _
                             "SUM ( INPUTQTY ) AS inputqty, " & _
                             "SUM ( NETQTY ) AS netqty, " & _
                             "SUM ( REJECT ) AS reject " & _
                            "FROM " & _
                            "TOTAL " & _
                             "where CONVERT(DATE,date) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                             "and name = '" & cmbGrouping.Text & "' " & _
                            "GROUP by " & _
                             "date, " & _
                            "Name " & _
                            "ORDER by  " & _
                             "date asc "


            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt

                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("DATE")
                .Columns.Add("NAME")
                .Columns.Add("EFFICIENCY")
                .Columns.Add("PRODUCTIONMETERS")
                .Columns.Add("INPUT")
                .Columns.Add("NET")
                .Columns.Add("REJECT")
                .Columns.Add("IMAGE")


            End With
            If OleDBDR.HasRows Then
                Dim dater As DateTime = dfrom.Text
                While dater <= dto.Value
                    While OleDBDR.Read
                        If dater < OleDBDR.Item(0) Then
                            'dater = DateAdd(DateInterval.Day, 1, dater)
                        ElseIf dater > OleDBDR.Item(0) Then
                            dater = OleDBDR.Item(0)
                        End If
                        gn = Format(OleDBDR.Item(0), "MMM dd")
                        Dim ndate As DateTime = OleDBDR.Item(0)
                        While dater <= ndate
                            If dater = ndate Then
                                dt.Rows.Add("",
                                 gn,
                                "",
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                OleDBDR.Item(0),
                                cmbGrouping.Text,
                                 OleDBDR.Item(2),
                                 OleDBDR.Item(3),
                                 OleDBDR.Item(4),
                                 OleDBDR.Item(5),
                                 OleDBDR.Item(6),
                               picbyte)
                            Else
                                Dim gs As String
                                If dater > OleDBDR.Item(0) Then
                                    gs = OleDBDR.Item(0)
                                Else
                                    gs = dater
                                End If
                                dt.Rows.Add("",
                                gn,
                                "",
                                Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                        dater,
                                     cmbGrouping.Text,
                                        "0",
                                        "0",
                                        "0",
                                        "0",
                                        "0",
                                         picbyte)
                            End If
                            dater = DateAdd(DateInterval.Day, 1, dater)
                        End While
                    End While
                    Dim g As String
                    g = dater
                    dt.Rows.Add("",
                            gn,
                            "",
                            Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                                    dater,
                                   cmbGrouping.Text,
                                    "0",
                                    "0",
                                    "0",
                                    "0",
                                    "0",
                                    picbyte)
                    dater = DateAdd(DateInterval.Day, 1, dater)
                End While

            Else
                'MsgBox("No Data for this Date Range", MsgBoxStyle.Exclamation, "Sorry")
                'Exit Sub
                Dim dater As DateTime = dfrom.Text
                While dater <= dto.Value

                    Dim g As String
                    g = dater
                    dt.Rows.Add("",
                            gn,
                            "",
                            Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                           dater,
                         cmbGrouping.Text,
                            "0",
                            "0",
                            "0",
                            "0",
                            "0",
                            picbyte)
                    dater = DateAdd(DateInterval.Day, 1, dater)

                End While
            End If

            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New PerformanceDailyReport
            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub SummaryMatrixReport()
        Dim gn As String
        Dim st As String
        Dim dformat As String


        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT convert(date,dbo.tblSales.SALESDATE), " & _
                            "dbo.tblSales.CUSTOMERNAME, " & _
                            "dbo.tblSalesTR.WIDTH, " & _
                            "dbo.tblSalesTR.LENGTH, " & _
                            "dbo.tblSalesTR.COLOR, " & _
                            "dbo.tblSalesTR.SEWNTYPE, " & _
                            "dbo.tblSalesTR.UPRICE, " & _
                            "SUM(dbo.tblSalesTR.QTY) as qty, " & _
                            "SUM(dbo.tblSalesTR.AMOUNT) as amount " & _
                             "FROM dbo.tblSales " & _
                            "INNER JOIN dbo.tblSalesTR ON dbo.tblSales.SALESNO = dbo.tblSalesTR.SALESNO " & _
                            "where CONVERT(DATE,SALESDATE) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & _
                            " GROUP by " & _
                            "dbo.tblSales.SALESDATE, " & _
                            "dbo.tblSales.CUSTOMERNAME, " & _
                            "dbo.tblSalesTR.WIDTH, " & _
                            "dbo.tblSalesTR.LENGTH, " & _
                            "dbo.tblSalesTR.COLOR, " & _
                            "dbo.tblSalesTR.SEWNTYPE, " & _
                             "dbo.tblSalesTR.UPRICE "
            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            Dim dt1 As New DataTable
            With dt
                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("date")
                .Columns.Add("costumer")
                .Columns.Add("description")
                .Columns.Add("unitprice")
                .Columns.Add("qty")
                .Columns.Add("amount")


            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    gn = OleDBDR.Item(0)
                    If OleDBDR.Item(5) = "STANDARD" Then
                        dt.Rows.Add("",
                            gn,
                             "",
                             Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                             Format(OleDBDR.Item(0), "MM/dd/yyyy"),
                             OleDBDR.Item(1),
                             OleDBDR.Item(2) & " X " & OleDBDR.Item(3) & " (" & OleDBDR.Item(4) & ")",
                             Format(OleDBDR.Item(6), "N"),
                            Format(OleDBDR.Item(7), "N"),
                            Format(OleDBDR.Item(8), "N"))
                    Else
                        dt.Rows.Add("",
                            gn,
                             "",
                             Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                 Format(OleDBDR.Item(0), "MM/dd/yyyy"),
                 OleDBDR.Item(1),
                    OleDBDR.Item(2) & " X " & OleDBDR.Item(3) & " (" & OleDBDR.Item(4) & ") - " & OleDBDR.Item(5),
                   Format(OleDBDR.Item(6), "N"),
                    Format(OleDBDR.Item(7), "N"),
                    Format(OleDBDR.Item(8), "N"))
                    End If

                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New SalesReport
            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub SalesReportPU()
        Dim gn As String
        Dim st As String
        Dim dformat As String


        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                Dim Customername As String
                If cmbGrouping.Text = "All" Then
                    Customername = ""
                Else
                    Customername = "and CUSTOMERNAME = '" & cmbGrouping.Text & "' "
                End If
                .CommandText = "SELECT dbo.tblSales.SALESDATE AS SALESDATE, " & _
                             "dbo.tblsalestr.SALESNO AS SALESNO, " & _
                             "dbo.tblSales.CUSTOMERNAME AS CUSTOMERNAME, " & _
                             "CONVERT ( " & _
                             "VARCHAR ( 255 ), " & _
                             "CAST ( width AS DECIMAL ( 20, 0 ) )) + 'x' + CONVERT ( " & _
                             "VARCHAR ( 255 ), " & _
                             "CAST ( length AS INT )) + ' - ' + Color + " & _
                            "CASE sewnType  " & _
                             "WHEN 'STANDARD' THEN " & _
                            "CASE PRINTED " & _
                             "WHEN 'PRINTED' THEN " & _
                            "' (' + PRINTED + ')' ELSE '' " & _
                             "END ELSE ' (' + sewnType + ' ' + PRINTED + ')' " & _
                             "END AS DETAILS, " & _
                             "dbo.tblSalesTR.QTY AS QTY, " & _
                             "dbo.tblSalesTR.UPRICE AS UPRICE, " & _
                             "dbo.tblSalesTR.AMOUNT AS AMOUNT, " & _
                             "0 AS TOTALAMOUNT, " & _
                             "0 AS CASH, " & _
                             "0 AS ODC, " & _
                             "0 AS PDC, " & _
                             "0 as balance " & _
                             "FROM dbo.tblSales " & _
                             "INNER JOIN dbo.tblSalesTR ON dbo.tblSales.SALESNO = dbo.tblSalesTR.SALESNO " & _
                            "where CONVERT(DATE,SALESDATE) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & Customername & _
                            "UNION SELECT " & _
                             "SALESDATE AS SALESDATE, " & _
                             "SALESNO AS SALESNO, " & _
                             "CUSTOMERNAME AS CUSTOMERNAME, " & _
                             "DETAILS AS DETAILS, " & _
                             "QTY AS QTY, " & _
                             "UPRICE AS UPRICE, " & _
                             "AMOUNT AS AMOUNT, " & _
                             "TOTALAMOUNT AS TOTALAMOUNT, " & _
                             "SUM ( CASH ) AS CASH, " & _
                             "SUM ( ODC ) AS ODC, " & _
                             "SUM ( PDC ) AS PDC, " & _
                             "TOTALAMOUNT - (SUM(CASH)+SUM(ODC)+SUM(PDC)) " & _
                            "FROM (SELECT dbo.tblsales.SALESDATE AS SALESDATE, " & _
                             "dbo.tblsales.SALESNO AS SALESNO, " & _
                             "dbo.tblSales.CUSTOMERNAME AS CUSTOMERNAME, " & _
                            "'TOTAL PAID' DETAILS, " & _
                             "0 AS QTY, " & _
                             "0 AS UPRICE, " & _
                             "0 AS AMOUNT, " & _
                             "tblSales.TOTALAMOUNT AS TOTALAMOUNT, " & _
                            "CASE WHEN dbo.tblPaid.PAYTYPE = 'CASH' " & _
                             "OR dbo.tblPaid.PAYTYPE = 'CASH (PARTIAL)' THEN " & _
                             "ISNULL( SUM ( dbo.tblPaid.AMOUNTPAID ), 0 ) ELSE 0 " & _
                             "END AS CASH, " & _
                            "CASE WHEN dbo.tblPaid.PAYTYPE = 'CHEQUE' " & _
                              "OR dbo.tblPaid.PAYTYPE = 'CHEQUE (PARTIAL)' THEN " & _
                               "ISNULL( SUM ( dbo.tblPaid.AMOUNTPAID ), 0 ) ELSE 0 " & _
                              "END AS ODC, " & _
                             "CASE WHEN dbo.tblPaid.PAYTYPE = 'CHEQUE (POSTDATE)' THEN " & _
                               "ISNULL( SUM ( dbo.tblPaid.AMOUNTPAID ), 0 ) ELSE 0 " & _
                              "END AS PDC " & _
                            "FROM dbo.tblSales  " & _
                            "LEFT JOIN dbo.tblPaid ON dbo.tblSales.SALESNO = dbo.tblPaid.SALESNO " & _
                            "GROUP BY  " & _
                            "dbo.TBLSALES.SALESDATE, " & _
                            "dbo.tblsales.SALESNO, " & _
                            "dbo.tblSales.CUSTOMERNAME, " & _
                            "dbo.tblsales.TOTALAMOUNT, " & _
                            "PAYTYPE " & _
                             ") AS SUBT " & _
                             "where CONVERT(DATE,SALESDATE) between '" & Format(dfrom.Value, "MM/dd/yyyy") & "' and dateadd(day,1,'" & Format(dto.Value, "MM/dd/yyyy") & "') " & Customername & _
                            "GROUP BY  " & _
                            "SALESDATE, " & _
                            "SALESNO, " & _
                            "Customername, " & _
                            "DETAILS, " & _
                            "QTY, " & _
                            "UPRICE, " & _
                            "AMOUNT, " & _
                            "TOTALAMOUNT "
            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            Dim dt1 As New DataTable
            With dt
                .Columns.Add("typeOfReport")
                .Columns.Add("groupname")
                .Columns.Add("searchType")
                .Columns.Add("dateRange")
                .Columns.Add("date")
                .Columns.Add("slsno")
                .Columns.Add("customer")
                .Columns.Add("description")
                .Columns.Add("qty")
                .Columns.Add("uprice")
                .Columns.Add("amount")
                .Columns.Add("totalAmount")
                .Columns.Add("cash")
                .Columns.Add("odc")
                .Columns.Add("pdc")
                .Columns.Add("balance")

            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    gn = OleDBDR.Item(0)
                    dt.Rows.Add("",
                        gn,
                         "",
                         Format(dfrom.Value, "MMMM dd, yyyy") & " - " & Format(dto.Value, "MMMM dd, yyyy"),
                         Format(OleDBDR.Item(0), "MM/dd/yyyy hh:mm tt"),
                         OleDBDR.Item(1),
                         OleDBDR.Item(2),
                         OleDBDR.Item(3),
                         Format(OleDBDR.Item(4), "N0"),
                         Format(OleDBDR.Item(5), "N"),
                         Format(OleDBDR.Item(6), "N"),
                         Format(OleDBDR.Item(7), "N"),
                         Format(OleDBDR.Item(8), "N"),
                         Format(OleDBDR.Item(9), "N"),
                         Format(OleDBDR.Item(10), "N"),
                         Format(OleDBDR.Item(11), "N"))

                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New PerCustomerSalesReportTry
            rptDoc.SetDataSource(dt)
            CrystalReportViewer1.ReportSource = rptDoc
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Sub print_attendance_summary()
    '    Dim get_attendance As New Attendance
    '    get_attendance.datefrom = dfrom.Value
    '    get_attendance.dateto = dto.Value
    '    get_attendance.departmentID = "1"
    '    get_attendance.get_attendance_summary()
    '    Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
    '    rptDoc = New Attendance_Record_Summary
    '    rptDoc.SetDataSource(get_attendance.dsx)
    '    rptDoc.SetParameterValue("Preparedby", "Devine")
    '    CrystalReportViewer1.ReportSource = rptDoc
    'End Sub
    'Sub print_BreaktimeLate_record_summary()
    '    Dim get_attendance As New Attendance
    '    get_attendance.datefrom = dfrom.Value
    '    get_attendance.dateto = dto.Value
    '    get_attendance.departmentID = "1"
    '    get_attendance.get_Breaktime_Late_summary()
    '    Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
    '    rptDoc = New Breaktime_Record_Summary
    '    rptDoc.SetDataSource(get_attendance.dsx)
    '    rptDoc.SetParameterValue("Preparedby", "Devine")
    '    CrystalReportViewer1.ReportSource = rptDoc
    'End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cmbGrouping.Text = "" Then
            MsgBox("Please Select Data Grouping", MsgBoxStyle.Critical)
        Else


            If lbltypeOfReport.Text = "Doffed Yarn Summary Report" Or lbltypeOfReport.Text = "Doffed Yarn Chart Analytical Report" Then
                doffedYarnSummaryReport()
            ElseIf lbltypeOfReport.Text = "Circular Looms Section Summary Report" Or lbltypeOfReport.Text = "Circular Looms Section Chart Analytical Report" Then
                loomsSectionReport()
            ElseIf lbltypeOfReport.Text = "Looms Doffed Summary Report" Or lbltypeOfReport.Text = "Looms Doffed Chart Analytical Report" Then
                LoomsdoffedReport()
            ElseIf lbltypeOfReport.Text = "Finished Product Summary Report" Or lbltypeOfReport.Text = "Finished Product Analytical Report" Then
                FPReport()
            ElseIf lbltypeOfReport.Text = "Doffed Yarn Waste Report" Then
                DYWasteReport()
            ElseIf lbltypeOfReport.Text = "Reject Waste Report" Then
                RejectWasteReport()
            ElseIf lbltypeOfReport.Text = "Yarn Production Report" Then
                If cmbGrouping.Text = "Weekly" Then
                    Dim lastday As Integer
                    lastday = DateTime.DaysInMonth(Format(dfrom.Value, "yyyy"), Format(dfrom.Value, "MM"))
                    dfrom.Value = "01/" & Format(dfrom.Value, "MM") & "/" & Format(dfrom.Value, "yyyy")
                    dto.Value = lastday & "/" & Format(dfrom.Value, "MM") & "/" & Format(dfrom.Value, "yyyy")
                End If
                YarnProductionReport()
                'MsgBox((DateDiff(DateInterval.Day, dfrom.Value, dto.Value) + 1) * 24)
            ElseIf lbltypeOfReport.Text = "Looms Production Report" Then
                If cmbGrouping.Text = "Weekly" Then
                    Dim lastday As Integer
                    lastday = DateTime.DaysInMonth(Format(dfrom.Value, "yyyy"), Format(dfrom.Value, "MM"))
                    dfrom.Value = "01/" & Format(dfrom.Value, "MM") & "/" & Format(dfrom.Value, "yyyy")
                    dto.Value = lastday & "/" & Format(dfrom.Value, "MM") & "/" & Format(dfrom.Value, "yyyy")
                End If
                LoomsProductionReport()
            ElseIf lbltypeOfReport.Text = "Diff Yarn Production Report" Then
                If cmbGrouping.Text = "Weekly" Then
                    Dim lastday As Integer
                    lastday = DateTime.DaysInMonth(Format(dfrom.Value, "yyyy"), Format(dfrom.Value, "MM"))
                    dfrom.Value = "01/" & Format(dfrom.Value, "MM") & "/" & Format(dfrom.Value, "yyyy")
                    dto.Value = lastday & "/" & Format(dfrom.Value, "MM") & "/" & Format(dfrom.Value, "yyyy")

                End If
            ElseIf lbltypeOfReport.Text = "Cutting & Sewing Production Report" Then
                CSProductionReport()
            ElseIf lbltypeOfReport.Text = "Operator Performance Report (Attendance / Efficiency)" Then
                PerOperatorReport()
            ElseIf lbltypeOfReport.Text = "Operator Performance Report (Production)" Then
                PerOperatorCSReport()
            ElseIf lbltypeOfReport.Text = "Operator Performance Report (Ranking)" Then
                RankingReport()
            ElseIf lbltypeOfReport.Text = "Production Daily (Per Operator)" Then
                getPicture()
                PerOperatorDailyReport()
            ElseIf lbltypeOfReport.Text = "Sales Report(Summary Matrix)" Then
                SummaryMatrixReport()
            ElseIf lbltypeOfReport.Text = "Sales Report(Paid/Unpaid Report)" Then
                SalesReportPU()


            End If
        End If
    End Sub
   

    Private Sub frmReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class