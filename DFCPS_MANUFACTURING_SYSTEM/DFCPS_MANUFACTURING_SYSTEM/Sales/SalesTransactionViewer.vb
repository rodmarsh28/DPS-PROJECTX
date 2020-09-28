Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class SalesTransactionViewer
    Dim rowIndex As Integer
    Public MODE As String
    Dim cardID As String
    Dim cardName As String
    Dim payment As String
    Public DT As New DataTable
    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    Private pages As Dictionary(Of Integer, pageDetails)
    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer
    
    Sub GET_SALE_LIST()
        Dim dt As New DataTable
        Try
            checkConn()
            Dim cmd As New SqlCommand("GET_SALES_LIST", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@COMMAND", SqlDbType.VarChar).Value = MODE
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = txtSearch.Text
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            DGV.DataSource = dt
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV.AutoResizeColumns()
            DGV.Columns(1).Width = 100
        Catch ex As Exception
        End Try
    End Sub
    

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        GET_SALE_LIST()
    End Sub

    Private Sub SalesTransactionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmSalesMain
        GET_SALE_LIST()
    End Sub

    Private Sub PrintPreviewDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewDialog1.Load

    End Sub
 
    Private mRow As Integer = 0
    Private newpage As Boolean = True
    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object,
          ByVal e As PrintEventArgs) Handles PrintDocument1.BeginPrint
        mRow = 0
        newpage = True
        PrintPreviewDialog1.PrintPreviewControl.StartPage = 0
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1.0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object,
                        ByVal e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        ' sets it to show '...' for long text
        Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
        fmt.LineAlignment = StringAlignment.Center
        fmt.Trimming = StringTrimming.EllipsisCharacter
        Dim y As Int32 = e.MarginBounds.Top
        Dim rc As Rectangle
        Dim x As Int32
        Dim h As Int32 = 0
        Dim row As DataGridViewRow

        ' print the header text for a new page
        '   use a grey bg just like the control
        If newpage Then
            row = DGV.Rows(mRow)
            x = e.MarginBounds.Left
            For Each cell As DataGridViewCell In row.Cells
                ' since we are printing the control's view,
                ' skip invidible columns
                If cell.Visible Then
                    rc = New Rectangle(x, y, cell.Size.Width + 15, cell.Size.Height)

                    e.Graphics.FillRectangle(Brushes.LightGray, rc)
                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    ' reused in the data pront - should be a function
                    Select Case DGV.Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                        Case DataGridViewContentAlignment.BottomRight,
                             DataGridViewContentAlignment.MiddleRight
                            fmt.Alignment = StringAlignment.Far
                            rc.Offset(-1, 0)
                        Case DataGridViewContentAlignment.BottomCenter,
                            DataGridViewContentAlignment.MiddleCenter
                            fmt.Alignment = StringAlignment.Center
                        Case Else
                            fmt.Alignment = StringAlignment.Near
                            rc.Offset(2, 0)
                    End Select

                    e.Graphics.DrawString(DGV.Columns(cell.ColumnIndex).HeaderText,
                                                DGV.Font, Brushes.Black, rc, fmt)
                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                End If
            Next
            y += h

        End If
        newpage = False

        ' now print the data for each row
        Dim thisNDX As Int32
        For thisNDX = mRow To DGV.RowCount - 1
            ' no need to try to print the new row
            If DGV.Rows(thisNDX).IsNewRow Then Exit For

            row = DGV.Rows(thisNDX)
            x = e.MarginBounds.Left
            h = 0

            ' reset X for data
            x = e.MarginBounds.Left

            ' print the data
            For Each cell As DataGridViewCell In row.Cells
                If cell.Visible Then
                    rc = New Rectangle(x, y, cell.Size.Width + 15, cell.Size.Height)

                    ' SAMPLE CODE: How To 
                    ' up a RowPrePaint rule
                    'If Convert.ToDecimal(row.Cells(5).Value) < 9.99 Then
                    '    Using br As New SolidBrush(Color.MistyRose)
                    '        e.Graphics.FillRectangle(br, rc)
                    '    End Using
                    'End If

                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    Select Case DGV.Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                        Case DataGridViewContentAlignment.BottomRight,
                             DataGridViewContentAlignment.MiddleRight
                            fmt.Alignment = StringAlignment.Far
                            rc.Offset(-1, 0)
                        Case DataGridViewContentAlignment.BottomCenter,
                            DataGridViewContentAlignment.MiddleCenter
                            fmt.Alignment = StringAlignment.Center
                        Case Else
                            fmt.Alignment = StringAlignment.Near
                            rc.Offset(2, 0)
                    End Select

                    e.Graphics.DrawString(cell.FormattedValue.ToString(),
                                          DGV.Font, Brushes.Black, rc, fmt)

                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                End If

            Next
            y += h
            ' next row to print
            mRow = thisNDX + 1

            If y + h > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                ' mRow -= 1   causes last row to rePrint on next page
                newpage = True
                Return
            End If
        Next


    End Sub

    Private Sub ToolStripStatusLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    Private Sub PrintJobOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintJobOrderToolStripMenuItem.Click
        prepare_job.MdiParent = frmSalesMain
        prepare_job.StartPosition = FormStartPosition.CenterParent
        prepare_job.TXTREF.Text = DGV.CurrentRow.Cells(1).Value
        prepare_job.Show()
    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub

    Private Sub DGV_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV.MouseDown
        If e.Button = MouseButtons.Right Then
            If DGV.SelectedRows.Count > 0 Then
                If MODE = "SALES QUOTATION" Then
                    DGV.ContextMenuStrip = cmsSalesQuotation
                ElseIf MODE = "SALES ORDER" Then
                    DGV.ContextMenuStrip = cmsSalesOrder
                End If
            End If
        End If
    End Sub
End Class