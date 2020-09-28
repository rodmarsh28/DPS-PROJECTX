Imports System.Data.SqlClient

Public Class print_class
    Public rptForm As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Public ds As DataSet
    Public dstable As String
    Public qry As String
    Public dataArrange As ParamArrayAttribute
    Public rptViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Public reportForm As Windows.Forms.Form
    Public Function get_print_data() As DataTable
        Dim dt As New DataTable
        checkConn()
        Dim cmd As New SqlCommand(qry, conn)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        da.Fill(dt)
        Return dt
    End Function
    Public Sub print_data(ByVal printDtable As DataTable)
        rptForm.SetDataSource(printDtable)
        rptViewer.ReportSource = rptForm
        reportForm.ShowDialog()
    End Sub
End Class
