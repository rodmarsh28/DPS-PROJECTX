Imports System.Data.SqlClient

Public Class frmJob_list
    Public HASROWS As Boolean
    Public clickedItem As Boolean
    Sub get_job_list()
        Try
            Dim ic As New inventory_class
            ic.get_job_list()
            dgv.Rows.Clear()
            For Each row As DataRow In ic.dtable.Rows
                dgv.Rows.Add(CDate(row(0)).ToString("MM/dd/yyyy"), row(1), row(2))
            Next
            dgv.ClearSelection()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        clickedItem = True
        Me.Close()
    End Sub

    Private Sub frmJob_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_job_list()
    End Sub
End Class