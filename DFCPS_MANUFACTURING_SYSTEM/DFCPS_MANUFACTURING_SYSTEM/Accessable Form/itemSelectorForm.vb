Imports System.Data.SqlClient

Public Class itemSelectorForm
    Public successClicked As Boolean = False
    Public cardID As String
    Sub get_voucher_list()
        Dim cmd As New SqlCommand("get_voucher_list", conn)
        checkConn()
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = "Open"
            .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = cardID

        End With
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)
        dgv.DataSource = dt
        dgv.AutoResizeColumns()
        dgv.Columns(2).Visible = False
        dgv.Columns(3).Visible = False
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        If dgv.CurrentRow.Cells(0).Value <> "" Then
            successClicked = True
            Me.Close()
        End If
    End Sub

    Private Sub itemSelectorForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            If dgv.CurrentRow.Cells(0).Value <> "" Then
                successClicked = True
                Me.Close()
            End If
        End If
    End Sub

    Private Sub itemSelectorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class