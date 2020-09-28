Public Class SaveStorePDFFiles
    'Class SurroundingClass
    '    Public Sub SaveFile()
    '        Dim fd As OpenFileDialog = New OpenFileDialog()
    '        fd.Filter = "pdf file|*.pdf"

    '        If fd.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '            Dim filebyte As Byte() = Nothing
    '            Dim con As SqlConnection = New SqlConnection("Data Source=LOCALHOS-A4AE79\LOCALHOST1;Initial Catalog=library_alborz;Integrated Security=True")
    '            Dim cmd As SqlCommand = Nothing
    '            filebyte = System.IO.File.ReadAllBytes(fd.FileName)
    '            cmd = New SqlCommand("Insert into pdftbl ( pdffld ) Values(@pdf)", con)
    '            cmd.Parameters.Add("@pdf", SqlDbType.Binary).Value = filebyte
    '            con.Open()
    '            cmd.ExecuteNonQuery()
    '            con.Close()
    '            Interaction.MsgBox("File saved into database", MsgBoxStyle.Information)
    '        End If
    '    End Sub
    '---------------------
    '    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Dim strsql As String = Nothing
    '        Dim con As SqlConnection = New SqlConnection("Data Source=LOCALHOS-A4AE79\LOCALHOST1;Initial Catalog=library_alborz;Integrated Security=True")
    '        Dim da As SqlDataAdapter = New SqlDataAdapter()
    '        Dim ds As DataSet = New DataSet()

    '        Try
    '            strsql = "select pdffld from  pdftbl "
    '            da = New SqlDataAdapter(strsql, con)
    '            da.Fill(ds, "tbl")
    '            Dim pdfData As Byte() = Convert.ToByte(ds.Tables("tbl").Rows(0)(0))

    '            Using ms As MemoryStream = New MemoryStream(pdfData, 0, pdfData.Length)
    '                ms.Write(pdfData, 0, pdfData.Length)
    '                PdfDocument1.Load(ms)
    '                PdfPageView1.Document = PdfDocument1
    '                PdfPageView1.Refresh()
    '            End Using

    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString())
    '        End Try
    '    End Sub
    'End Class
End Class
