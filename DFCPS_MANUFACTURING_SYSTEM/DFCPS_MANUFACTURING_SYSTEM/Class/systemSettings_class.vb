Imports System.Data.SqlClient
Imports System.Linq ' need to add 
Public Class systemSettings_class
    Public settingsName As String
    Public settingsValue As String
    Public return_settingsValue As String

    Public dt As DataTable
    Public dc As New salesDataContext
    Public Sub insert_update_settingsVariable()
        Try
            Dim cmd As New SqlCommand("insert_settingsVariable", conn)
            checkConn()
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@settingsName", SqlDbType.Int).Value = settingsName
                .Parameters.AddWithValue("@settingsValue", SqlDbType.VarChar).Value = settingsValue
            End With
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub get_settingsValue()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select_settingsVariable", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@settingsName", SqlDbType.VarChar).Value = settingsName
                .Parameters.AddWithValue("@settingsValue", SqlDbType.VarChar).Value = settingsValue
            End With
            OleDBDR = cmd.ExecuteReader
            If OleDBDR.Read Then
                return_settingsValue = OleDBDR.Item(0)
            Else
                return_settingsValue = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Public tableName As String
    Public columnName As String
    Public series As String
    Public result As String
    Public Sub generateNo()
        Dim cmd As New SqlCommand("select max(" & columnName & ") from " & tableName & "", conn)
        checkConn()
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.Read Then
            If IsDBNull(reader.Item(0)) <> True Then
                result = reader.Item(0)
            Else
                result = series & "00000"
            End If
        End If
    End Sub
    Public Function insert_tr_update_logs(ByVal src As String, ByVal refno As String) As String
        Dim fRes As New frmReason
        If fRes.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Return "Cancel"
            Exit Function
        End If

        Dim logs As New tblTrans_update_log
        Dim seriesID As String = Year(Now).ToString & Month(Now).ToString("00") & "-"
        Dim last_id As String
        Dim sid As String
        Dim DATA
        Try
            DATA = (From l In dc.tblTrans_update_logs _
                     Select l.UPDATE_LOG_ID).Max()
            last_id = Data
        Catch ex As Exception
            last_id = seriesID & "0000000"
        End Try
        sid = Mid(last_id, Len(seriesID) + 1, Len(last_id))
        Dim log_id = seriesID & Format(Val(sid) + 1, "0000000")
        logs.UPDATE_LOG_ID = log_id
        logs.SRC = src
        logs.TR_NO = refno
        logs.DATE_OF_ACTION = Now
        logs.REASON_OF_ACTION = fRes.cmbReason.Text
        logs.REMARKS = fRes.txtRemarks.Text
        dc.tblTrans_update_logs.InsertOnSubmit(logs)
        Return log_id
    End Function
    Public Sub isDataupdated()
        Try
            lastrowchanges()
        Catch ex As Exception
        End Try
    End Sub
End Class
