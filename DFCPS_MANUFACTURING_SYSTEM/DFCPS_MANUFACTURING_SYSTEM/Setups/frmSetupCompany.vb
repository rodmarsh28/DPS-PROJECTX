Imports System.IO
Imports System.Drawing.Imaging

Public Class frmSetupCompany
    Public Shared Function ImgToByteArray(ByVal img As Image, ByVal imgFormat As ImageFormat) As Byte()
        Dim tmpData As Byte()
        Using ms As New MemoryStream()
            img.Save(ms, imgFormat)

            tmpData = ms.ToArray
        End Using              ' dispose of memstream
        Return tmpData
    End Function
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        OpenFileDialog1.Filter = "Image Files(*.png; *.jpg; *.bmp)|*.png; *.jpg; *.bmp"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim fileName As String = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
            pHeader.Image = New Bitmap(OpenFileDialog1.FileName)
            Me.pHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        End If
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        OpenFileDialog1.Filter = "Image Files(*.png; *.jpg; *.bmp)|*.png; *.jpg; *.bmp"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim fileName As String = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
            pLogo.Image = New Bitmap(OpenFileDialog1.FileName)
            Me.pLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        End If
    End Sub
    Sub insert_update_company()
        Dim cvtLogo As New ImageConverter
        Dim cvtHeader As New ImageConverter
        Dim pc As New setup_class
        pc.companyName = txtCompanyName.Text
        pc.companyAddress = txtCompanyAddress.Text
        pc.companyLogo = CType(cvtLogo.ConvertTo(pLogo.Image, GetType(Byte())), Byte())
        pc.companyHeader = CType(cvtHeader.ConvertTo(pHeader.Image, GetType(Byte())), Byte())
        pc.insert_update_company()
    End Sub
    Sub load_company()
        Dim pc As New setup_class
        pc.get_company()
        Dim pxlogo As New MemoryStream(pc.companyLogo)
        Dim pxheader As New MemoryStream(pc.companyHeader)
        txtCompanyName.Text = pc.companyName
        txtCompanyAddress.Text = pc.companyAddress
        pLogo.Image = Image.FromStream(pxlogo)
        pLogo.SizeMode = PictureBoxSizeMode.StretchImage
        pHeader.Image = Image.FromStream(pxheader)
        pHeader.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub


    Private Sub frmAddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            load_company()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        insert_update_company()
    End Sub
End Class