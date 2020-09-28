Imports System.Drawing.Printing
Public Class frmSystemSettings
    Dim printername As String = My.Settings.printerName
    Sub GET_PRINTER_LIST()
        Dim pkInstalledPrinters As String

        ' Find all printers installed
        For Each pkInstalledPrinters In _
            PrinterSettings.InstalledPrinters
            cbPrinter.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        ' Set the combo to the first printer in the list
        Dim c As Integer = 0
        For Each item As String In cbPrinter.Items
            If item = printername Then
                cbPrinter.SelectedIndex = c
            ElseIf printername = "" Or IsDBNull(printername) = True Then
                cbPrinter.SelectedIndex = -1
            End If
            c += 1
        Next
    End Sub

    Private Sub frmSystemSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GET_PRINTER_LIST()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.YesNo, "System Reminders") = MsgBoxResult.Yes Then
            My.Settings.printerName = cbPrinter.Text
            MsgBox("Settings Saved !", MsgBoxStyle.Information, "System Reminders")
        End If
    End Sub
End Class