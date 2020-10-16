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
        Catch ex As Exception
        End Try
    End Sub


    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        GET_SALE_LIST()
    End Sub

    Private Sub SalesTransactionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Dim frm As New prepare_job
        frm.MdiParent = frmSalesMain
        frm.StartPosition = FormStartPosition.CenterParent
        frm.TXTREF.Text = DGV.CurrentRow.Cells(1).Value
        frm.get_sales_order_items(DGV.CurrentRow.Cells(1).Value)
        frm.get_card_id(DGV.CurrentRow.Cells(1).Value)
        frm.generateNo()
        frm.Show()
    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub

    Private Sub DGV_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV.MouseDown
        If e.Button = MouseButtons.Right Then
            If DGV.SelectedRows.Count > 0 Then
                If MODE = "QUOTATION" Then
                    DGV.ContextMenuStrip = cmsSalesQuotation
                ElseIf MODE = "SALES ORDER" Then
                    DGV.ContextMenuStrip = cmsSalesOrder
                ElseIf MODE = "JOB ORDER" Then
                    DGV.ContextMenuStrip = cmsJobOrder
                    If DGV.CurrentRow.Cells(5).Value = "Job Finished" Then
                        tmsJobFinished.Enabled = False
                        tmsUpdate.Enabled = False
                        tmsCancelJob.Enabled = False
                    Else
                        tmsJobFinished.Enabled = True
                        tmsUpdate.Enabled = True
                        tmsCancelJob.Enabled = True
                    End If
                ElseIf MODE = "SALES CASH INVOICE" Then
                    DGV.ContextMenuStrip = cmsCashInvoice
                ElseIf MODE = "SALES CHARGE INVOICE" Then
                    DGV.ContextMenuStrip = cmsChargeInvoice
                ElseIf MODE = "SALES DELIVER" Then
                    DGV.ContextMenuStrip = cmsDeliver
                End If
            End If
        End If
    End Sub
    Sub get_data_update(ByVal param As List(Of String))
        Dim qc As qry_class
        qc.qry = "SELECT " & _
        "tblJobOrder.JONO, " & _
        "tblJobOrder.[DATE], " & _
        "tblJobOrder.REFNO, " & _
        "tblJobOrder.CARDID, " & _
        "tblJobOrder.REMARKS, " & _
        "tblJobOrder.ITEMNO, " & _
        "tblJobOrder.QTY, " & _
        "tblJobOrder.ONHAND_QTY " & _
        "FROM " & _
        "tblJobOrder where JONO = '" & DGV.CurrentRow.Cells(1).Value & "'"
        Dim dt As DataTable = qc.get_qry_data
        Dim cdt As New DataTable
        cdt.Columns.Add("dbcolName")
        cdt.Columns.Add("parName")
        cdt.Columns.Add("dbValue")
        cdt.Columns.Add("parType")
        Dim res As String()
        For Each c As DataColumn In dt.Columns
            If IsNumeric(param.IndexOf(c.ColumnName)) = True Then
                Dim e As Integer = param.IndexOf(c.ColumnName)
                res = param.Item(e).Split(",")
                cdt.Rows.Add(c.ColumnName, res(1), dt.Rows(0).Item(c).ToString, res(2))
                CType(Me.Controls(res(1)), TextBox).Text = dt.Rows(0).Item(c).ToString
            End If

        Next
    End Sub


    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsPrint.Click

        'Dim sc As New sales_class
        'sc.print_job_order(DGV.CurrentRow.Cells(1).Value)
        Dim pc As New print_class
        Dim sc As New sales_class
        pc.rptForm = New rpt_JO
        pc.rptViewer = report_viewer.CrystalReportViewer1
        pc.reportForm = report_viewer
        Dim ds As New sales_ds
        Dim dt As DataTable = ds.Tables("JOTABLE")
        For Each row In sc.get_info_data(DGV.CurrentRow.Cells(1).Value)
            dt.Rows.Add(row.job_no, row.trDate, row.CUSTOMER, row.DESCRIPTION, row.QTY, row.REMARKS, row.pDate, MainForm.logo, MainForm.header)
        Next
        pc.print_data(dt)
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsUpdate.Click
        prepare_job.mode = "Update"
        prepare_job.get_info_data(DGV.CurrentRow.Cells(1).Value)
        prepare_job.MdiParent = frmSalesMain
        prepare_job.StartPosition = FormStartPosition.CenterParent
        prepare_job.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsJobFinished.Click

        Try
            If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "SYSTEM REMINDER") = MsgBoxResult.Yes Then
                Dim sc As New sales_class
                sc.update_job_data(DGV.CurrentRow.Cells(1).Value, DGV.CurrentRow.Cells(2).Value, DGV.CurrentRow.Cells(3).Value, "Job Finished", "", MainForm.LBLID.Text)
                MsgBox("STATUS UPDATED", MsgBoxStyle.Information, "SYSTEM INFORMATION")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

  
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim sc As New sales_class
        sc.print_sales(DGV.CurrentRow.Cells(1).Value, "SALES ORDER")
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

        Dim sc As New sales_class
        sc.print_sales(DGV.CurrentRow.Cells(1).Value, "QUOTATION")

    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim sc As New sales_class
        sc.print_sales(DGV.CurrentRow.Cells(1).Value, "SALES CASH INVOICE")
    End Sub

    Private Sub ToolStripMenuItem3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Dim sc As New sales_class
        sc.print_DR(DGV.CurrentRow.Cells(1).Value)
    End Sub

    Private Sub cmsCashInvoice_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsCashInvoice.Opening

    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Dim sc As New sales_class
        sc.print_sales(DGV.CurrentRow.Cells(1).Value, "SALES CHARGE INVOICE")
    End Sub

    Private Sub CancelSalesOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelSalesOrderToolStripMenuItem.Click
        Try
            If DGV.CurrentRow.Cells(4).Value = "Closed" Or DGV.CurrentRow.Cells(4).Value = "Cancelled" Then
                MsgBox("This transaction is not available for that command. ", MsgBoxStyle.Critical, "Error")
            End If
            If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
                Dim sc As New sales_class
                sc.update_salesOrder_status(DGV.CurrentRow.Cells(1).Value, "Cancelled")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CancelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelToolStripMenuItem.Click
        Try
            If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
                Dim sc As New sales_class
                sc.update_salesQuotation_status(DGV.CurrentRow.Cells(1).Value, "Cancelled")
            End If
            MsgBox("STATUS UPDATED", MsgBoxStyle.Information, "SYSTEM INFORMATION")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CancelInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelInvoiceToolStripMenuItem.Click
        Try
            If DGV.CurrentRow.Cells(4).Value = "All ordered items delivered" Or DGV.CurrentRow.Cells(4).Value = "Cancelled" Then
                MsgBox("This transaction is not available for that command. ", MsgBoxStyle.Critical, "Error")
            
                Exit Sub

            End If
            If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
                Dim sc As New sales_class
                sc.update_salesCash_status(DGV.CurrentRow.Cells(1).Value, "Cancelled")
                Dim ac As New Account_Class
                ac.reverse_accEntry(DGV.CurrentRow.Cells(1).Value, "Cancelled")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tmsCancelJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsCancelJob.Click
        Try
            If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
                Dim sc As New sales_class
                sc.update_job_data(DGV.CurrentRow.Cells(1).Value, DGV.CurrentRow.Cells(2).Value, DGV.CurrentRow.Cells(3).Value, "Job Finished", "", MainForm.LBLID.Text)
                MsgBox("STATUS UPDATED", MsgBoxStyle.Information, "SYSTEM INFORMATION")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Try
            If DGV.CurrentRow.Cells(4).Value = "All ordered items delivered" Or DGV.CurrentRow.Cells(4).Value = "Cancelled" Then
                MsgBox("This transaction is not available for that command. ", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.Yes Then
                Dim sc As New sales_class
                sc.update_salesCharge_status(DGV.CurrentRow.Cells(1).Value, "Cancelled")
                Dim ac As New Account_Class
                ac.reverse_accEntry(DGV.CurrentRow.Cells(1).Value, "Cancelled")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub UpdateToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click

    End Sub

    Private Sub PrintDeliveryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintDeliveryToolStripMenuItem.Click
        Dim sc As New sales_class
        sc.print_sales(DGV.CurrentRow.Cells(1).Value, "SALES DELIVER")
    End Sub
End Class