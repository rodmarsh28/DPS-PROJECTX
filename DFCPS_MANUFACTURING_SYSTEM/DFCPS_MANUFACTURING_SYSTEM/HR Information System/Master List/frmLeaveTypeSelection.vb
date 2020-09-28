Public Class frmLeaveTypeSelection
    Public command As String
    Public searchValue As String
    Public type As String
    Public isOK As Boolean
    Public empid As String
    Public dates As DateTime

    Sub get_withpay_leave_credit()
        Dim mc As New master_class
        mc.command = ""
        mc.searchValue = empid
        mc.dateTo = dates
        mc.get_withpay_leave_credit()
        dgv.DataSource = mc.dtable
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv.AutoResizeColumns()
    End Sub



    Private Sub frmInfraction_offense_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_withpay_leave_credit()
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        isOK = True
        Me.Close()
    End Sub
End Class