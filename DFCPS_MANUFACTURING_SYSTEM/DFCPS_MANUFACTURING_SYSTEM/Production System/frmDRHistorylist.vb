Public Class frmDRHistorylist
    Sub loadDRHistory()
        Dim c As Integer = 0
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
                .CommandText = "SELECT dbo.tblDR.[DATE], " & _
                "dbo.tblDR.DRNO, " & _
                "dbo.tblJobOrder.CUSTOMER " & _
                "FROM dbo.tblDR  " & _
                "INNER JOIN dbo.tblJobOrder ON dbo.tblDR.JONO = dbo.tblJobOrder.JONO " & _
                "order by DRNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = Format(OleDBDR.Item(0), "MM/dd/yy hh:mm tt")
                    dgv.Item(1, c).Value = OleDBDR.Item(1)
                    dgv.Item(2, c).Value = OleDBDR.Item(2)
                    c = c + 1
                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub printDR()
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
                .CommandText = "SELECT dbo.tblDR.DRNO, " & _
                "dbo.tblDR.[DATE], " & _
                "dbo.tblDR.JONO, " & _
                "dbo.tblDR.REFNO, " & _
                "dbo.tblJobOrder.CUSTOMER, " & _
                "dbo.tblOrderReleasedTR.DESCRIPTION, " & _
                "dbo.tblOrderReleasedTR.WIDTH, " & _
                "dbo.tblOrderReleasedTR.LENGTH, " & _
                "dbo.tblOrderReleasedTR.COLOR, " & _
                "dbo.tblOrderReleasedTR.SEWNTYPE, " & _
                "dbo.tblOrderReleasedTR.PRINTED, " & _
                "dbo.tblOrderReleasedTR.RELEASED, " & _
                "dbo.tblSalesTR.UPRICE, " & _
                "dbo.tblSalesTR.UPRICE * dbo.tblOrderReleasedTR.RELEASED " & _
                "FROM dbo.tblOrderReleasedTR " & _
                "INNER JOIN dbo.tblJobOrder ON dbo.tblJobOrder.JONO = dbo.tblOrderReleasedTR.JONO " & _
                "INNER JOIN dbo.tblSalesTR ON dbo.tblJobOrder.SALESNO = dbo.tblSalesTR.SALESNO " & _
                "INNER JOIN dbo.tblDR ON dbo.tblOrderReleasedTR.DRNO = dbo.tblDR.DRNO " & _
                "WHERE " & _
                "CAST(dbo.tblOrderReleasedTR.WIDTH AS DECIMAL(20,0)) = CAST(dbo.tblSalesTR.WIDTH AS DECIMAL(20,0)) And " & _
                "CAST(dbo.tblOrderReleasedTR.LENGTH AS DECIMAL(20,0)) = CAST(dbo.tblSalesTR.LENGTH AS DECIMAL(20,0)) And " & _
                "dbo.tblOrderReleasedTR.COLOR = dbo.tblSalesTR.COLOR And " & _
                "dbo.tblOrderReleasedTR.SEWNTYPE = dbo.tblSalesTR.SEWNTYPE And " & _
                "dbo.tblOrderReleasedTR.PRINTED = dbo.tblSalesTR.PRINTED AND  " & _
                "dbo.tblOrderReleasedTR.DRNO = '" & dgv.CurrentRow.Cells(1).Value & "'"


            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("DRNO")
                .Columns.Add("DATE")
                .Columns.Add("JONO")
                .Columns.Add("REF")
                .Columns.Add("GPNO")
                .Columns.Add("CUSTOMER")
                .Columns.Add("DESCRIPTION")
                .Columns.Add("QTY")
                .Columns.Add("UNIT")
                .Columns.Add("UPRICE")
                .Columns.Add("AMOUNT")
                .Columns.Add("PREPAREDBY")
            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dt.Rows.Add(OleDBDR.Item(0),
                     Format(OleDBDR.Item(1), "MMM dd, yyyy hh:mm tt"),
                     OleDBDR.Item(2),
                     OleDBDR.Item(3),
                     OleDBDR.Item(0).Remove(0, 3),
                     OleDBDR.Item(4),
                     OleDBDR.Item(5),
                     Format(OleDBDR.Item(11), "N0"),
                     "PCS",
                     Format(OleDBDR.Item(12), "N"),
                     Format(OleDBDR.Item(13), "N"),
                     "DEVINE JENILIE BIÑAN")
                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New DRANDGP
            rptDoc.SetDataSource(dt)
            frmReportViewerNoDateRange.CrystalReportViewer1.ReportSource = rptDoc
            frmReportViewerNoDateRange.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmDRHistorylist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadDRHistory()
    End Sub

    Private Sub PrintDRGatepassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintDRGatepassToolStripMenuItem.Click
        printDR()
    End Sub



    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgv.ContextMenuStrip = ContextMenuStrip2
    End Sub


    Private Sub dgv_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgv.CurrentCell = dgv(e.ColumnIndex, e.RowIndex)
                dgv.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class