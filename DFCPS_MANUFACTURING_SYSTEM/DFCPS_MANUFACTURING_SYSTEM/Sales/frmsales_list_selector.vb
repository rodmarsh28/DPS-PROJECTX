Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class frmsales_list_selector
    Dim rowIndex As Integer
    Public MODE As String
    Dim cardID As String
    Dim cardName As String
    Dim payment As String
    Public DT As New DataTable
    Public successClick As Boolean
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
            Dim cmd As New SqlCommand("GET_SALES_LIST_FOR-REF", conn)
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
            DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            DGV.Columns(1).Width = 100
        Catch ex As Exception
        End Try
    End Sub
   
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        GET_SALE_LIST()
    End Sub

    Private Sub SalesTransactionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GET_SALE_LIST()
    End Sub

    Private Sub PrintPreviewDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewDialog1.Load

    End Sub
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True

  

    Private Sub ToolStripStatusLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub

    Private Sub DGV_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDoubleClick
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Reminder") = MsgBoxResult.Yes Then
            successClick = True
            Me.Close()
        End If
    End Sub
End Class