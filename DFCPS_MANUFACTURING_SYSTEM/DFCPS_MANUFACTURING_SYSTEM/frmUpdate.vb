Imports System.IO, System.Net, System.Web
Imports MadMilkman.Ini
Public Class frmUpdate
    Dim currVersion As String
    Dim nVersion As String
    Dim ini As New IniFile()

    Sub checkLatestVersion()
        ini.Load(My.Application.Info.DirectoryPath + "\Settings.ini")
        Dim clientyPath As String = My.Application.Info.DirectoryPath
        Dim serverDirectory As String = ini.Sections("Directory").Keys("server").Value
        Try
            Dim read As System.IO.StreamReader = New System.IO.StreamReader(serverDirectory + "\Version.txt")
            nVersion = read.ReadToEnd().ToString
            currVersion = Application.ProductVersion
            lblversion.Text = currVersion
            If currVersion < nVersion Then
                ProgressBar1.Value = 100
                If MsgBox("New version is detected (" & nVersion & ")", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Process.Start(My.Application.Info.DirectoryPath + "\Updatetool.exe")
                    Application.Exit()
                End If
            Else
                MsgBox("You system is up to date !", MsgBoxStyle.Information, "SYSTEM INFORMATION")
            End If


        Catch ex As Exception

        End Try


    End Sub
 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProgressBar1.Value = 30
        checkLatestVersion()
    End Sub


    Private Sub frmUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 
        ProgressBar1.Value = 0
        currVersion = Application.ProductVersion
    End Sub
End Class
