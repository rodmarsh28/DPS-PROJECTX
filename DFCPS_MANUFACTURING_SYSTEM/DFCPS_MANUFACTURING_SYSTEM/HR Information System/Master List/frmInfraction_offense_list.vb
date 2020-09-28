Public Class frmInfraction_offense_list
    Public command As String
    Public searchValue As String
    Public type As String
    Public isOK As Boolean

    Sub get_infraction_offense_list()
        Dim mc As New master_class
        mc.command = command
        mc.searchValue = searchValue
        mc.get_infraction_offense_list()
        dgv.DataSource = mc.dtable
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv.AutoResizeColumns()
        If command = "infraction" Then
            dgv.Columns("infractionID").Visible = False
            dgv.Columns("specOffenseID").Visible = False
            dgv.Columns("offenseID").Visible = False
        ElseIf command = "offense" Then
            dgv.Columns("offenseID").Visible = False
        End If
    End Sub


    Private Sub frmInfraction_offense_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_infraction_offense_list()
    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        isOK = True
        Me.Close()
    End Sub
End Class