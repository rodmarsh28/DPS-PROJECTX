Imports System.Drawing.Printing

Public Class HRISprintDialog

    Private Sub printDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim pkInstalledPrinters As String

        ' Find all printers installed
        For Each pkInstalledPrinters In _
            PrinterSettings.InstalledPrinters
            cmbPrinterList.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        ' Set the combo to the first printer in the list
        cmbPrinterList.SelectedIndex = 0
        cmbPrinterList.Text = My.Settings.printerName
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.printerName = cmbPrinterList.Text
        frmPrintPremsPaymentSum.printPremsSum()
    End Sub
End Class