
Public Class frmCheck_print_preview

    Private Sub frmCheck_print_preview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Sub print()
        Dim ac As New Accounting_class
        frmCheckPrint.rpttemp = New check_print
        ac.command = 0
        ac.transNo = frmCheckPrint.txtRefNo.Text
        ac.PRINT_CHECK()
        ac.rptDoc.PrintOptions.PrinterName = My.Settings.printerName
        ac.rptDoc.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("Please Feed you check before you press ok", MsgBoxStyle.OkOnly, "System Reminder")
        print()
        While MsgBox("Is Check is successfully printed ?", MsgBoxStyle.YesNo, "System Reminder") = MsgBoxResult.No
            print()
        End While
        MsgBox("Thank you", MsgBoxStyle.Information, "System Reminder")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class