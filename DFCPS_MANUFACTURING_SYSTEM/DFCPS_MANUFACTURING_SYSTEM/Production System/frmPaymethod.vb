Public Class frmPaymethod
    Public mode As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If mode = "Sales" Then
            frmSales.lblMode.Text = ComboBox1.Text
            If ComboBox1.Text = "CHEQUE (POSTDATE)" Then
                frmSales.postChequeDate = dtp.Value
            Else
                frmSales.postChequeDate = "01/01/1970 00:00"
            End If
            Me.Close()
        ElseIf mode = "Pay" Then
            frmSalesHistoryViewer.lblmode = ComboBox1.Text
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "CHEQUE (POSTDATE)" Then
            lblDtp.Visible = True
            dtp.Visible = True
        Else
            lblDtp.Visible = False
            dtp.Visible = False
        End If
    End Sub

    Private Sub frmPaymethod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDtp.Visible = False
        dtp.Visible = False
    End Sub
End Class