Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class frmProductionMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub



    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub CircularLoomSectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CircularLoomSectionToolStripMenuItem.Click
        mode = "CLS-Add"
        frmCircularLoomsSec.ShowDialog()
    End Sub

    Private Sub CircularLoomHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CircularLoomHistoryToolStripMenuItem.Click
        frmCLSViewer.ShowDialog()
    End Sub

    Private Sub DailyReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub BackupDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DofferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DofferToolStripMenuItem.Click
        frmDoffed.ShowDialog()
    End Sub

    Private Sub AddLoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddLoomToolStripMenuItem.Click
        frmLoomsAdder.ShowDialog()
    End Sub

    Private Sub QAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QAToolStripMenuItem.Click
        frmQA.ShowDialog()
    End Sub

    Private Sub PDORToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDORToolStripMenuItem.Click
        frmPDOR.ShowDialog()
    End Sub

    Private Sub MixingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MixingToolStripMenuItem.Click
        frmMixingReport.ShowDialog()
    End Sub


    Private Sub FinishedProductionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinishedProductionToolStripMenuItem.Click
        frmPDIR.ShowDialog()
    End Sub

    Private Sub DoffedYarnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoffedYarnToolStripMenuItem.Click
        frmDoffedYarn.ShowDialog()
    End Sub

    Private Sub PDORCUTTINGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDORCUTTINGToolStripMenuItem.Click
        frmPDORCutting.ShowDialog()
    End Sub

    Private Sub REPORTHISTORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REPORTHISTORYToolStripMenuItem.Click
        frmHistoryList.ShowDialog()
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    lbldate.Text = Format(Now, "MM/dd/yyyy")
    '    lbltime.Text = Format(Now, "hh:mm:ss tt")
    'End Sub



  

    Private Sub SummaryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("ALL")
        frmReportViewer.cmbGrouping.Items.Add("Daily")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.lbltypeOfReport.Text = "Doffed Yarn Summary Report"
        frmReportViewer.ShowDialog()


    End Sub

    Private Sub SummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("ALL")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.cmbGrouping.Items.Add("Per Operator")
        frmReportViewer.lbltypeOfReport.Text = "Circular Looms Section Summary Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub ChartAnalyticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Daily")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.lbltypeOfReport.Text = "Doffed Yarn Chart Analytical Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub ChartAnalyticsReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Daily")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.cmbGrouping.Items.Add("Per Operator")
        frmReportViewer.lbltypeOfReport.Text = "Circular Looms Section Chart Analytical Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub SummaryToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("ALL")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.lbltypeOfReport.Text = "Looms Doffed Summary Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub ChartAnalyticalReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        selectcmbGroupingforLD()
        frmReportViewer.lbltypeOfReport.Text = "Looms Doffed Chart Analytical Report"
        frmReportViewer.ShowDialog()
    End Sub
    Sub selectcmbGroupingforLD()
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
                .CommandText = "SELECT distinct dbo.tblDoffed.mesh,dbo.tblDoffed.width FROM dbo.tblLoomSection INNER JOIN dbo.tblLoomSectionTR " & _
                    "ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO  INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblLoomSectionTR.rollNo "
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    frmReportViewer.cmbGrouping.Items.Add("Daily (" & OleDBDR.Item(0) & " - " & OleDBDR.Item(1) & ")")
                    frmReportViewer.cmbGrouping.Items.Add("Monthly (" & OleDBDR.Item(0) & " - " & OleDBDR.Item(1) & ")")
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub selectcmbGroupingforFP()
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
                .CommandText = "SELECT distinct dbo.tblDoffed.mesh, dbo.tblDoffed.width FROM dbo.tblCSRTR INNER JOIN dbo.tblFPITR ON dbo.tblCSRTR.CSRITEMNO = dbo.tblFPITR.CSRITEMNO " & _
                    "INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    frmReportViewer.cmbGrouping.Items.Add("Daily (" & OleDBDR.Item(0) & " - " & OleDBDR.Item(1) & ")")
                    frmReportViewer.cmbGrouping.Items.Add("Monthly (" & OleDBDR.Item(0) & " - " & OleDBDR.Item(1) & ")")
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SummaryToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("ALL")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.lbltypeOfReport.Text = "Finished Product Summary Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub ChartAnalyticsReprortToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        selectcmbGroupingforFP()
        frmReportViewer.lbltypeOfReport.Text = "Finished Product Analytical Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub DatabaseSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmDatabaseSettings.ShowDialog()
    End Sub

    Private Sub ChartAnalyticsReportToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Daily")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.lbltypeOfReport.Text = "Doffed Yarn Waste Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub RejectWasteReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Daily")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.lbltypeOfReport.Text = "Reject Waste Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub RollStockInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RollStockInventoryToolStripMenuItem.Click
        frmRollStocks.ShowDialog()
    End Sub

    Private Sub ProducedAndWasteGraphicalReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProducedAndWasteGraphicalReportToolStripMenuItem.Click
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Daily")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.lbltypeOfReport.Text = "Yarn Production Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub LoomsProductionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoomsProductionReportToolStripMenuItem.Click
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Daily")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.cmbGrouping.Items.Add("Per Loom")
        frmReportViewer.lbltypeOfReport.Text = "Looms Production Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub YarnDiffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Daily")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.lbltypeOfReport.Text = "Diff Yarn Production Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub CuttingSewingProductionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuttingSewingProductionReportToolStripMenuItem.Click
        frmReportViewer.cmbGrouping.Items.Add("Daily")
        frmReportViewer.cmbGrouping.Items.Add("Monthly")
        frmReportViewer.lbltypeOfReport.Text = "Cutting & Sewing Production Report"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub BagInventoryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
                "Select DISTINCT " & _
                 "dbo.tblFPITR.WIDTH AS W, " & _
                 "dbo.tblFPITR.baglength AS L, " & _
                 "dbo.tblFPITR.COLOR AS C, " & _
                 "dbo.tblFPITR.SEWNTYPE AS S, " & _
                "'' AS P, " & _
                 "SUM ( dbo.tblFPITR.netQTY ) AS NETQTY, " & _
                 "0 AS Adjustment, " & _
                 "0 AS stockOut, " & _
                 "0 AS SALESQTY  " & _
                "FROM " & _
                 "dbo.tblFPITR " & _
                "GROUP BY " & _
                 "dbo.tblFPITR.WIDTH, " & _
                 "dbo.tblFPITR.baglength, " & _
                 "dbo.tblFPITR.COLOR, " & _
                "dbo.tblFPITR.SEWNTYPE UNION " & _
                "SELECT " & _
                 "dbo.tblAdjustmentTR.WIDTH AS W, " & _
                 "dbo.tblAdjustmentTR.LENGTH AS L, " & _
                 "dbo.tblAdjustmentTR.COLOR AS C, " & _
                 "dbo.tblAdjustmentTR.SEWNTYPE AS S, " & _
                "dbo.tblAdjustmentTR.PRINTED AS P, " & _
                 "0 AS NETQTY, " & _
                 "SUM ( dbo.tblAdjustmentTR.QTY ) AS ADJUSTMENT, " & _
                 "0 AS STOCKOUT, " & _
                 "0 AS SALESQTY  " & _
                "FROM " & _
                "dbo.tblAdjustmentTR " & _
                "GROUP by " & _
                 "dbo.tblAdjustmentTR.WIDTH, " & _
                 "dbo.tblAdjustmentTR.LENGTH, " & _
                 "dbo.tblAdjustmentTR.SEWNTYPE, " & _
                 "dbo.tblAdjustmentTR.PRINTED, " & _
                "dbo.tblAdjustmentTR.COLOR union  " & _
                "SELECT " & _
                 "dbo.tblStockOutTR.WIDTH AS W, " & _
                 "dbo.tblStockOutTR.BAGLENTH AS L, " & _
                 "dbo.tblStockOutTR.COLOR AS C, " & _
                 "dbo.tblStockOutTR.SEWNTYPE AS S, " & _
                "'' AS P, " & _
                 "0 AS NETQTY, " & _
                 "0 AS ADJUSTMENT, " & _
                 "SUM ( dbo.tblStockOutTR.QTY ) AS STOCKOUT, " & _
                 "0 AS SALESQTY  " & _
                "FROM " & _
                "dbo.tblStockOutTR " & _
                "GROUP by  " & _
                 "dbo.tblStockOutTR.WIDTH, " & _
                 "dbo.tblStockOutTR.BAGLENTH, " & _
                 "dbo.tblStockOutTR.SEWNTYPE, " & _
                "dbo.tblStockOutTR.COLOR UNION  " & _
                "SELECT " & _
                 "dbo.tblSalesTR.WIDTH AS W, " & _
                 "dbo.tblSalesTR.LENGTH AS L, " & _
                 "dbo.tblSalesTR.COLOR AS C, " & _
                 "dbo.tblSalesTR.SEWNTYPE AS S, " & _
                 "dbo.tblSalesTR.PRINTED AS P, " & _
                 "0 AS NETQTY, " & _
                 "0 AS ADJUSTMENT, " & _
                 "0 AS STOCKOUT, " & _
                 "SUM ( dbo.tblSalesTR.QTY ) AS SALESQTY  " & _
                "FROM " & _
                "dbo.tblSalesTR " & _
                "WHERE dbo.tblSalesTR.bagtype <> 'RECLAIMED' " & _
                "GROUP BY  " & _
                "dbo.tblSalesTR.WIDTH, " & _
                "dbo.tblSalesTR.LENGTH, " & _
                "dbo.tblSalesTR.SEWNTYPE, " & _
                "dbo.tblSalesTR.PRINTED, " & _
                "dbo.tblSalesTR.COLOR " & _
                "UNION " & _
                 "SELECT " & _
                "dbo.tblManualPrintingTR.WIDTH AS W, " & _
                "dbo.tblManualPrintingTR.BAGL AS L, " & _
                "dbo.tblManualPrintingTR.BAGCOLOR AS C, " & _
                "dbo.tblManualPrintingTR.SEWNTYPE AS S, " & _
                "'PRINTED' AS P, " & _
                "SUM(dbo.tblManualPrintingTR.OUTPUTQTY) AS NETQTY, " & _
                "0 AS ADJUSTMENT, " & _
                "0 AS STOCKOUT, " & _
                "0 AS SALESQTY " & _
                "FROM " & _
                "dbo.tblManualPrintingTR " & _
                "INNER JOIN dbo.tblPrinting ON dbo.tblPrinting.PRNO = dbo.tblManualPrintingTR.PRNO " & _
                "GROUP BY  " & _
                "dbo.tblManualPrintingTR.WIDTH, " & _
                "dbo.tblManualPrintingTR.BAGL, " & _
                "dbo.tblManualPrintingTR.BAGCOLOR, " & _
                "dbo.tblManualPrintingTR.SEWNTYPE " & _
                "UNION " & _
                "SELECT " & _
                "dbo.tblManualPrintingTR.WIDTH AS W, " & _
                "dbo.tblManualPrintingTR.BAGL AS L, " & _
                "dbo.tblManualPrintingTR.BAGCOLOR AS C, " & _
                "dbo.tblManualPrintingTR.SEWNTYPE AS S, " & _
                "'' AS P, " & _
                "- + SUM(dbo.tblManualPrintingTR.INPUTQTY) AS NETQTY, " & _
                "0 AS ADJUSTMENT, " & _
                "0 AS STOCKOUT, " & _
                "0 AS SALESQTY " & _
                "FROM " & _
                "dbo.tblManualPrintingTR " & _
                "INNER JOIN dbo.tblPrinting ON dbo.tblPrinting.PRNO = dbo.tblManualPrintingTR.PRNO " & _
                "GROUP BY  " & _
                "dbo.tblManualPrintingTR.WIDTH, " & _
                "dbo.tblManualPrintingTR.BAGL, " & _
                "dbo.tblManualPrintingTR.BAGCOLOR, " & _
                "dbo.tblManualPrintingTR.SEWNTYPE " & _
                 ") SELECT " & _
                 "W, " & _
                 "L, " & _
                 "C, " & _
                 "S, " & _
                 "P, " & _
                 "SUM ( NETQTY ) + SUM ( ADJUSTMENT ) AS NETQTY, " & _
                 "SUM ( ADJUSTMENT ) AS ADJUSTMENT, " & _
                 "SUM ( STOCKOUT ) AS STOCKOUT, " & _
                 "SUM ( SALESQTY ) AS SALESQTY, " & _
                 "SUM ( NETQTY ) + SUM ( ADJUSTMENT ) - SUM ( STOCKOUT ) - SUM ( SALESQTY ) AS TOTAL  " & _
                "FROM " & _
                "TOTAL " & _
               " GROUP BY  " & _
               " W, " & _
               " L, " & _
               " c, " & _
              "  S, " & _
               " P " & _
               " ORDER BY  " & _
              "  W, L "


            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("size")
                .Columns.Add("netQTY")
                .Columns.Add("stockOutQTY")
                .Columns.Add("soldQTY")
                .Columns.Add("availableQTY")
            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    If OleDBDR.Item(9) > "0.00" Then
                        Dim SEWNTYPE As String
                        If OleDBDR.Item(3) = "STANDARD" Then
                            If OleDBDR.Item(4) = "PRINTED" Then
                                SEWNTYPE = " (" & OleDBDR.Item(4) & ")"
                            Else
                                SEWNTYPE = ""
                            End If
                        ElseIf OleDBDR.Item(3) = "TOP SEWN" Then
                            SEWNTYPE = " (" & OleDBDR.Item(3) & " " & OleDBDR.Item(4) & ")"
                        End If
                        dt.Rows.Add(Format(OleDBDR.Item(0), "N0") & "x" & Format(OleDBDR.Item(1), "N0") & " - " & OleDBDR.Item(2) & SEWNTYPE,
                        Format(OleDBDR.Item(5), "N0"),
                        Format(OleDBDR.Item(7), "N0"),
                        Format(OleDBDR.Item(8), "N0"),
                        Format(OleDBDR.Item(9), "N0"))
                    ElseIf OleDBDR.Item(9) <= "0.00" Then
                        Dim SEWNTYPE As String
                        If OleDBDR.Item(3) = "STANDARD" Then
                            If OleDBDR.Item(4) = "PRINTED" Then
                                SEWNTYPE = " (" & OleDBDR.Item(4) & ")"
                            Else
                                SEWNTYPE = ""
                            End If
                        ElseIf OleDBDR.Item(3) = "TOP SEWN" Then
                            SEWNTYPE = " (" & OleDBDR.Item(3) & " " & OleDBDR.Item(4) & ")"
                        End If
                        dt.Rows.Add(Format(OleDBDR.Item(0), "N0") & "x" & Format(OleDBDR.Item(1), "N0") & " - " & OleDBDR.Item(2) & SEWNTYPE,
                        Format(OleDBDR.Item(5), "N0"),
                       0,
                        Format(OleDBDR.Item(5), "N0"),
                        0)
                    End If
                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New SackInventoryReport
            rptDoc.SetDataSource(dt)
            frmReportViewerNoDateRange.CrystalReportViewer1.ReportSource = rptDoc
            frmReportViewerNoDateRange.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddSalesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmSales.ShowDialog()
    End Sub

    Private Sub StockOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AddEditEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAddEmployees.ShowDialog()
    End Sub

    'Private Sub AddAttendaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    frmEmployeesList.EmployeesList()
    '    frmAddAttendance.ShowDialog()
    'End Sub

    Private Sub PerOperatorPerformanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PerOperatorPerformanceReportToolStripMenuItem.Click

    End Sub

    Private Sub ATTENDANCEEFFICIENCYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ATTENDANCEEFFICIENCYToolStripMenuItem.Click
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Per Operator")
        frmReportViewer.lbltypeOfReport.Text = "Operator Performance Report (Attendance / Efficiency)"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub ProductionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionToolStripMenuItem.Click
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Per Operator")
        frmReportViewer.lbltypeOfReport.Text = "Operator Performance Report (Production)"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub RankingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RankingReportToolStripMenuItem.Click
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Per Operator")
        frmReportViewer.lbltypeOfReport.Text = "Operator Performance Report (Ranking)"
        frmReportViewer.ShowDialog()
    End Sub

   

    Private Sub RawMaterialsInventoryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim dsx As New DataSet1
            checkConn()
            Dim cmd As New SqlCommand("GET_RAWMATS_INVENTORY", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SEARCHVALUE", SqlDbType.VarChar).Value = ""
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            da.Fill(dsx, "RawMatsInventoryTable")
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New RAWMATSINVENTORYReport
            rptDoc.SetDataSource(dsx)
            frmReportViewerNoDateRange.CrystalReportViewer1.ReportSource = rptDoc
            frmReportViewerNoDateRange.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub getOperatorNames()
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
                .CommandText = "SELECT Distinct name from tblEmployeesInfo "
            End With
            OleDBDR = OleDBC.ExecuteReader
            frmReportViewer.cmbGrouping.Items.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    frmReportViewer.cmbGrouping.Items.Add(OleDBDR.Item(0))
                End While

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub getCustomers()
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
                .CommandText = "SELECT Distinct CUSTOMERNAME from tblSales "
            End With
            OleDBDR = OleDBC.ExecuteReader
            frmReportViewer.cmbGrouping.Items.Clear()
            frmReportViewer.cmbGrouping.Items.Add("All")
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    frmReportViewer.cmbGrouping.Items.Add(OleDBDR.Item(0))
                End While
            End If
            frmReportViewer.cmbGrouping.SelectedIndex = "0"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub



    Private Sub StockOutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmStockOut.ShowDialog()
    End Sub

    Private Sub RecycleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecycleReportToolStripMenuItem.Click
        frmRecycle.ShowDialog()
    End Sub


    Private Sub ProductionDailyPerOperatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionDailyPerOperatorToolStripMenuItem.Click
        frmReportViewer.cmbGrouping.Items.Clear()
        getOperatorNames()
        frmReportViewer.lbltypeOfReport.Text = "Production Daily (Per Operator)"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub CrusherReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrusherReportToolStripMenuItem.Click
        frmCrusher.ShowDialog()
    End Sub

    Private Sub SummaryToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add("Daily")
        frmReportViewer.lbltypeOfReport.Text = "Sales Report(Summary Matrix)"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub PrintingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintingToolStripMenuItem.Click
        frmPrinting.ShowDialog()
    End Sub

    Private Sub JobOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobOrderToolStripMenuItem.Click
        frmJoHistoryViewer.ShowDialog()
    End Sub

    Private Sub PrinterSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ProductionPrintDialog.ShowDialog()
    End Sub

    Private Sub DeliveryReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryReceiptToolStripMenuItem.Click
        frmDRHistorylist.ShowDialog()
    End Sub

    Private Sub PaidUnpaidReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        getCustomers()
        frmReportViewer.lbltypeOfReport.Text = "Sales Report(Paid/Unpaid Report)"
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub ImportAttendaceRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmImportAttendace.ShowDialog()
    End Sub

    Private Sub AddItemsInInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub AddBreaktimeRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DailyBreaktime.ShowDialog()
    'End Sub

    Private Sub AttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.lbltypeOfReport.Text = "Attendance Record Summary"
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add(" ")
        frmReportViewer.cmbGrouping.SelectedIndex = 0
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub BreaktimeLateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReportViewer.lbltypeOfReport.Text = "Breaktime Late Record Summary"
        frmReportViewer.cmbGrouping.Items.Clear()
        frmReportViewer.cmbGrouping.Items.Add(" ")
        frmReportViewer.cmbGrouping.SelectedIndex = 0
        frmReportViewer.ShowDialog()
    End Sub

    Private Sub InventoryListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmInventory.ShowDialog()
    End Sub

    Private Sub RawMaterialsInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RawMaterialsInventoryToolStripMenuItem.Click

    End Sub
End Class
