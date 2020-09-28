Public Class frmDateGenerator
    Public mode As String
    Public isLastDay As Boolean


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        payrollMode = "Add"
        Dim Year As DateTime = DateTimePicker2.Value
        Dim Month As DateTime = DateTimePicker2.Value
        Dim years As Integer = Year.Year
        Dim months As Integer = Month.Month
        Dim days As Integer = System.DateTime.DaysInMonth(years, months)
        Dim daydate As DateTime = DateTimePicker2.Value
        If mode = "AddPayroll" Then
            frmPayroll.dtrFrom.Value = DateTimePicker1.Value
            frmPayroll.dtrTo.Value = DateTimePicker2.Value
            If daydate.Day = days Then
                isLastDay = True
            Else
                isLastDay = False
            End If
            payrollType = "Admin"
            frmPayroll.txtRegularHolidays.Enabled = True
            frmPayroll.txtNonWorkingHolidays.Enabled = True
            frmPayroll.txtLeavepay.Enabled = True
            frmPayroll.txtSSSLoan.Enabled = True
            frmPayroll.txtPagibigLoah.Enabled = True
            frmPayroll.txtLedgerBalance.Enabled = True
        End If
        frmPayroll.countsunday()
        frmPayroll.MdiParent = HRISMain
        Me.Close()
        frmPayroll.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class