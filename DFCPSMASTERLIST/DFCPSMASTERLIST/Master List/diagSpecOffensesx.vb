Public Class diagSpecOffensesx
    Public offenseID As String
    Public add As Boolean
    Sub get_offenses_List()
        Dim mc As New master_class
        mc.get_offenses_List()
        dgvOff.Rows.Clear()
        For Each row As DataRow In mc.dtable.Rows
            dgvOff.Rows.Add(row(0), row(1))
        Next
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        add = True
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub diagSpecOffensesx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_offenses_List()
    End Sub
End Class