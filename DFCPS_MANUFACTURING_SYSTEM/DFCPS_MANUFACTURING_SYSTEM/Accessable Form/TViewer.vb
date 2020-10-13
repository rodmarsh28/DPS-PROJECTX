Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class TViewer


    Dim rowIndex As Integer
    Public MODE As String
    Dim cardID As String
    Dim cardName As String


    Sub GET_SALE_LIST(ByVal transNo As String, ByVal status As String, ByVal type As String)

        Try
            Dim ac As New account_dsTableAdapters.approvalListTA
            Dim dt As New account_ds.approvalListTableDataTable
            ac.Fill(dt, transNo, status, type)
            DGV.DataSource = dt
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TViewer_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If MODE = "All" Then
            GET_SALE_LIST(txtSearch.Text, "", "")
        ElseIf MODE = "Pending" Then
            GET_SALE_LIST(txtSearch.Text, "Waiting for approval", "")
        End If
    End Sub



    Private Sub SalesTransactionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PrintPreviewDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private mRow As Integer = 0
    Private newpage As Boolean = True


    

    Private Sub PrintJobOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            DGV.ContextMenuStrip = cmsPA
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If MODE = "All" Then
            GET_SALE_LIST(txtSearch.Text, "", "")
        ElseIf MODE = "Pending" Then
            GET_SALE_LIST(txtSearch.Text, "Waiting for approval", "")
        End If
    End Sub
End Class