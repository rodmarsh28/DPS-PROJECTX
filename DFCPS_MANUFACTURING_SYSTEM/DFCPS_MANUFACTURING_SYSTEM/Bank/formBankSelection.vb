Imports System.Data.SqlClient

Public Class formBankSelection
    Public itemClicked As Boolean
    Public mode As String
    Sub get_bankList()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select * from get_Banklist where ID like '%" & txtSearch.Text & "%' or description like '%" & txtSearch.Text & "%'", conn)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgv.DataSource = dt
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgv.AutoResizeColumns()
            dgv.Columns(0).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub get_CheckbookList()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select * from get_checkbooklist where checkbook_id like '%" & txtSearch.Text & "%' or bank_id like '%" & txtSearch.Text & "%' or bank_description like '%" & txtSearch.Text & "%'", conn)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgv.DataSource = dt
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgv.AutoResizeColumns()
            dgv.Columns(5).Visible = False
            dgv.Columns(6).Visible = False
            dgv.Columns(8).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub formBankSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Sub searchList()
        If mode = "bankList" Then
            get_bankList()
        ElseIf mode = "checkbookList" Then
            get_CheckbookList()
        End If
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        itemClicked = True
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        searchList()
    End Sub
End Class