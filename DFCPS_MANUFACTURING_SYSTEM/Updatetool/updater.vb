Imports System.IO, System.Net, System.Web, System
Imports MadMilkman.Ini
Public Class updater
    Dim client As New System.Net.WebClient
    Dim ini As New IniFile()
   
    Sub processUpdate()
        Try
            ini.Load(My.Application.Info.DirectoryPath + "\Settings.ini")
            Dim clientyPath As String = My.Application.Info.DirectoryPath + "\"
            Dim serverDirectory As String = ini.Sections("Directory").Keys("server").Value + "\"
            Dim FileToCopy(6) As String
            FileToCopy(0) = "DFCPS_MANAGEMENT_SYSTEM.application"
            FileToCopy(1) = "DFCPS_MANAGEMENT_SYSTEM.exe"
            FileToCopy(2) = "DFCPS_MANAGEMENT_SYSTEM.exe.config"
            FileToCopy(3) = "DFCPS_MANAGEMENT_SYSTEM.exe.manifest"
            FileToCopy(4) = "DFCPS_MANAGEMENT_SYSTEM.pdb"
            FileToCopy(5) = "DFCPS_MANAGEMENT_SYSTEM.xml"
            Dim s As String
            For Each s In FileToCopy
                ProgressBar1.Value += 100 / FileToCopy.Length
                If s <> "" Then
                    If System.IO.File.Exists(serverDirectory + s) = True Then
                        System.IO.File.Copy(serverDirectory + s, clientyPath + s, True)
                    Else
                        MsgBox("There was a problem updating system from the server. please ask for technical assistance", MsgBoxStyle.Critical, "SYSTEM INFORMATION")
                        Process.Start(clientyPath + "\DFCPS_MANAGEMENT_SYSTEM.exe")
                        Application.Exit()
                        Exit Sub
                    End If
                End If
            Next
            MsgBox("You system is up to date !", MsgBoxStyle.Information, "SYSTEM INFORMATION")
            Process.Start(clientyPath + "\DFCPS_MANAGEMENT_SYSTEM.exe")
            Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub updater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim pslist() As Process
        Dim pExit As Boolean = False
        pslist = Process.GetProcesses()
        For Each p As Process In pslist
            If "DFCPS_MANAGEMENT_SYSTEM" = p.ProcessName Then
                p.Kill()
            End If
        Next
            Process.Start(My.Application.Info.DirectoryPath + "\Updatetool.exe")
            ProgressBar1.Value = 0
            processUpdate()
    End Sub
End Class
