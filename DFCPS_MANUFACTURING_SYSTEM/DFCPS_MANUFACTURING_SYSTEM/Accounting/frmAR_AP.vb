Imports System.Data.SqlClient

Public Class frmAR_AP
    Public MODE As String
    Sub GET_PAYABLES()
        Try
            checkConn()
            Dim cmd As New SqlCommand("GET_PAYABLES", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@SEARCHVALUE", SqlDbType.VarChar).Value = txtSearch.Text
            End With
            Dim da As New SqlDataAdapter(cmd)
            Dim DT As New DataTable
            da.SelectCommand = cmd
            da.Fill(DT)
            dgv.DataSource = DT
            dgv.AutoResizeColumns()
            lblCount.Text = Format(dgv.Rows.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub GET_RECEIVABLES()
        Try
            checkConn()
            Dim cmd As New SqlCommand("GET_RECEIVABLES", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@SEARCHVALUE", SqlDbType.VarChar).Value = txtSearch.Text
            End With
            Dim da As New SqlDataAdapter(cmd)
            Dim DT As New DataTable
            da.SelectCommand = cmd
            da.Fill(DT)
            dgv.DataSource = DT
            dgv.AutoResizeColumns()
            lblCount.Text = Format(dgv.Rows.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub frmAR_AP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If MODE = "Payables" Then
            GET_PAYABLES()
        ElseIf MODE = "Receivables" Then
            GET_RECEIVABLES()
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ar_pr_settings.ShowDialog()
    End Sub
End Class