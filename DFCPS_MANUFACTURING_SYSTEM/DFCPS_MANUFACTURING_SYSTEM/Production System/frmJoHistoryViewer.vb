Imports System.Data.SqlClient

Public Class frmJoHistoryViewer
    Sub loadJOHistory()
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
                .CommandText = "SELECT dbo.tblJobOrder.[DATE], " & _
                            "dbo.tblJobOrder.JONO, " & _
                            "dbo.tblJobOrder.SALESNO, " & _
                            "dbo.tblJobOrder.CUSTOMER, " & _
                            "sum(dbo.tblJobOrderTR.QTY) as QTY, " & _
                            "sum(dbo.tblOrderReleasedTR.RELEASED) as RELEASED " & _
                             "FROM dbo.tblJobOrder " & _
                            "FULL OUTER JOIN dbo.tblJobOrderTR ON dbo.tblJobOrder.JONO = dbo.tblJobOrderTR.JONO " & _
                            "FULL OUTER JOIN dbo.tblOrderReleasedTR ON dbo.tblJobOrder.JONO = dbo.tblOrderReleasedTR.JONO " & _
                            "GROUP BY " & _
                            "dbo.tblJobOrder.JONO, " & _
                            "dbo.tblJobOrder.[DATE], " & _
                             "dbo.tblJobOrder.SALESNO, " & _
                            "dbo.tblJobOrder.CUSTOMER " & _
                            " ORDER BY dbo.tblJobOrder.[DATE] DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    Dim QTY As Integer = OleDBDR.Item(4)
                    Dim RELEASED As Integer
                    If IsDBNull(OleDBDR.Item(5)) = True Then
                        RELEASED = 0
                    Else
                        RELEASED = OleDBDR.Item(5)
                    End If
                    If QTY > RELEASED Then
                        dgv.Rows.Add()
                        dgv.Item(0, c).Value = Format(OleDBDR.Item(0), "MM/dd/yy")
                        dgv.Item(1, c).Value = OleDBDR.Item(1)
                        dgv.Item(2, c).Value = OleDBDR.Item(2)
                        dgv.Item(3, c).Value = OleDBDR.Item(3)
                        c = c + 1
                    End If
                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub get_jo_history()
        Dim dt As New DataTable
        checkConn()
        Dim cmd As New SqlCommand("GET_JO_HISTORY", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If row(6) = "UNRELEASED" Then
                dgv.Rows.Add(row(0), row(1), row(2), row(3))
            End If
        Next
    End Sub
    Sub JobOrderSlip()
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
                .CommandText = "SELECT dbo.tblJobOrderTR.JONO, " & _
                "dbo.tblJobOrder.[DATE], " & _
                "dbo.tblJobOrder.SALESNO, " & _
                "dbo.tblJobOrder.CUSTOMER, " & _
                "dbo.tblJobOrderTR.DESCRIPTION, " & _
                "dbo.tblJobOrderTR.QTY " & _
                "FROM dbo.tblJobOrder " & _
                "INNER JOIN dbo.tblJobOrderTR ON dbo.tblJobOrder.JONO = dbo.tblJobOrderTR.JONO " & _
                "WHERE tblJobOrderTR.JONO = '" & dgv.CurrentRow.Cells(1).Value & "'"

            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("JONO")
                .Columns.Add("DATE")
                .Columns.Add("REF")
                .Columns.Add("CUSTOMER")
                .Columns.Add("DESCRIPTION")
                .Columns.Add("QTY")
            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dt.Rows.Add(OleDBDR.Item(0),
                     Format(OleDBDR.Item(1), "MMM dd, yyyy hh:mm tt"),
                     OleDBDR.Item(2),
                     OleDBDR.Item(3),
                     OleDBDR.Item(4),
                     Format(OleDBDR.Item(5), "N0"))
                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New JobOrder
            rptDoc.SetDataSource(dt)
            frmReportViewerNoDateRange.CrystalReportViewer1.ReportSource = rptDoc
            frmReportViewerNoDateRange.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmJoHistoryViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_jo_history()
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

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgv.ContextMenuStrip = ContextMenuStrip2
    End Sub

    Private Sub PrintJobOrderSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintJobOrderSlipToolStripMenuItem.Click
        JobOrderSlip()
    End Sub

    Private Sub ReleaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleaseOrderToolStripMenuItem.Click
        Dim c As Integer = 0
        Dim itemscount As Integer = 0
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
                .CommandText = "WITH JOBORDER AS " & _
                            "(SELECT  " & _
                            "dbo.tblJobOrderTR.jono as JONo, " & _
                            "dbo.tblJobOrderTR.DESCRIPTION AS D, " & _
                            "dbo.tblJobOrderTR.WIDTH AS W, " & _
                            "dbo.tblJobOrderTR.LENGTH AS L, " & _
                            "dbo.tblJobOrderTR.COLOR AS C, " & _
                            "dbo.tblJobOrderTR.SEWNTYPE AS S, " & _
                            "dbo.tblJobOrderTR.PRINTED AS P, " & _
                            "sum(dbo.tblJobOrderTR.QTY) as QTY, " & _
                            "0 AS RELEASED " & _
                            "FROM " & _
                            "dbo.tblJobOrder " & _
                            "INNER JOIN dbo.tblJobOrderTR ON dbo.tblJobOrder.JONO = dbo.tblJobOrderTR.JONO " & _
                            "GROUP BY  " & _
                            "dbo.tblJobOrderTR.jono, " & _
                            "dbo.tblJobOrderTR.DESCRIPTION, " & _
                            "dbo.tblJobOrderTR.WIDTH, " & _
                            "dbo.tblJobOrderTR.LENGTH, " & _
                            "dbo.tblJobOrderTR.COLOR, " & _
                            "dbo.tblJobOrderTR.SEWNTYPE, " & _
                            "dbo.tblJobOrderTR.PRINTED " & _
                            "UNION " & _
                            "SELECT " & _
                            "dbo.tblOrderReleasedTR.jono as JONo, " & _
                            "dbo.tblOrderReleasedTR.DESCRIPTION AS D, " & _
                            "dbo.tblOrderReleasedTR.WIDTH AS W, " & _
                            "dbo.tblOrderReleasedTR.LENGTH AS L, " & _
                            "dbo.tblOrderReleasedTR.COLOR AS C, " & _
                            "dbo.tblOrderReleasedTR.SEWNTYPE AS S, " & _
                            "dbo.tblOrderReleasedTR.PRINTED AS P, " & _
                            "0 AS QTY, " & _
                            "SUM(dbo.tblOrderReleasedTR.RELEASED) AS RELEASED " & _
                            "FROM " & _
                            "dbo.tblOrderReleasedTR " & _
                            "GROUP BY " & _
                            "dbo.tblOrderReleasedTR.jono, " & _
                            "dbo.tblOrderReleasedTR.DESCRIPTION, " & _
                            "dbo.tblOrderReleasedTR.WIDTH, " & _
                            "dbo.tblOrderReleasedTR.LENGTH, " & _
                            "dbo.tblOrderReleasedTR.COLOR, " & _
                            "dbo.tblOrderReleasedTR.SEWNTYPE, " & _
                            "dbo.tblOrderReleasedTR.PRINTED) " & _
                            "SELECT D,cast(W as decimal(20,0)),cast(L as decimal(20,0)),C,S,P,SUM(QTY)-SUM(RELEASED)  " & _
                            "FROM JOBORDER " & _
                             "WHERE JONO = '" & dgv.CurrentRow.Cells(1).Value & "'" & _
                            "GROUP BY " & _
                            "D,	cast (W AS DECIMAL ( 20, 0 )) ,cast (L AS DECIMAL ( 20, 0 )), c, S, P "

            End With
            OleDBDR = OleDBC.ExecuteReader
            frmReleaseOrder.dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                frmReleaseOrder.JONO = dgv.CurrentRow.Cells(1).Value
                While OleDBDR.Read
                    If OleDBDR.Item(6) <> "0" Then
                        frmReleaseOrder.dgv.Rows.Add()
                        frmReleaseOrder.dgv.Item(0, c).Value = OleDBDR.Item(0)
                        frmReleaseOrder.dgv.Item(1, c).Value = OleDBDR.Item(1)
                        frmReleaseOrder.dgv.Item(2, c).Value = OleDBDR.Item(2)
                        frmReleaseOrder.dgv.Item(3, c).Value = OleDBDR.Item(3)
                        frmReleaseOrder.dgv.Item(4, c).Value = OleDBDR.Item(4)
                        frmReleaseOrder.dgv.Item(5, c).Value = OleDBDR.Item(5)
                        frmReleaseOrder.dgv.Item(6, c).Value = OleDBDR.Item(6)
                        frmReleaseOrder.dgv.Item(7, c).Value = OleDBDR.Item(6)
                        frmReleaseOrder.SALESNO = dgv.CurrentRow.Cells(2).Value
                        itemscount = itemscount + 1
                        c = c + 1
                    End If
                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        If itemscount = 0 Then
            MsgBox("Job order is already released !", MsgBoxStyle.Exclamation, "Sorry")
        Else
            frmReleaseOrder.ShowDialog()
        End If
    End Sub
End Class