Imports System.Data.OleDb

Public Class frmImportAttendace
    Dim accConn As New OleDbConnection
    Dim accCmd As New OleDbCommand
    Dim accDr As OleDbDataReader
    Dim totalWorked As Double
    Dim totalLate As Integer
    Public Sub accConnectDatabase()
        strConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & OpenFileDialog1.FileName & ";Persist Security Info=False;"
        accConn.ConnectionString = strConnString
        accConn.Open()
    End Sub
    Sub LoadAttendaceRecord()
        Dim c As Integer = 0
        Try
            accConnectDatabase()
            With accCmd
                .Connection = accConn
                .CommandText = "TRANSFORM First([%$##@_Alias].xtime) AS FirstOfxtime " & _
                "SELECT [%$##@_Alias].date, [%$##@_Alias].badgenumber,name " & _
                "FROM (SELECT distinct FORMAT(checktime,'yyyy/MM/dd') as [date],badgenumber,name,FORMAT(checktime,'hh:mm') as xtime, " & _
                "'1' as type " & _
                "FROM CHECKINOUT INNER JOIN USERINFO ON CHECKINOUT.USERID = USERINFO.USERID " & _
                "where  checktype = 'I' and  FORMAT(checktime,'hh:mm') between '05:00' and '09:00' and defaultdeptid =21 " & _
                "union all  " & _
                "SELECT distinct FORMAT(checktime,'yyyy/MM/dd') as [date],badgenumber,name,FORMAT(checktime,'hh:mm') as xtime, " & _
                "'2' as type " & _
                "FROM CHECKINOUT INNER JOIN USERINFO ON CHECKINOUT.USERID = USERINFO.USERID " & _
                "where  checktype = 'O'and FORMAT(checktime,'hh:mm') between '10:30' and '13:00' and defaultdeptid =21 " & _
                "union all  " & _
                "SELECT distinct FORMAT(checktime,'yyyy/MM/dd') as [date],badgenumber,name,FORMAT(checktime,'hh:mm') as xtime, " & _
                "'3' as type " & _
                "FROM CHECKINOUT INNER JOIN USERINFO ON CHECKINOUT.USERID = USERINFO.USERID " & _
                "where checktype = 'I' and FORMAT(checktime,'hh:mm') between '11:30' and '14:00' and defaultdeptid =21 " & _
                "union all  " & _
                "SELECT distinct FORMAT(checktime,'yyyy/MM/dd') as [date],badgenumber,name,FORMAT(checktime,'hh:mm') as xtime, " & _
                "'4' as type " & _
                "FROM CHECKINOUT INNER JOIN USERINFO ON CHECKINOUT.USERID = USERINFO.USERID " & _
                "where checktype = 'O' and FORMAT(checktime,'hh:mm')  between '16:00' and '18:00' and defaultdeptid =21 " & _
                ")  AS [%$##@_Alias] " & _
                " where date between '" & Format(dFrom.Value, "yyyy/MM/dd") & "' and '" & Format(dTo.Value, "yyyy/MM/dd") & "' " & _
                "GROUP BY [%$##@_Alias].date, [%$##@_Alias].badgenumber,name " & _
                "ORDER BY [%$##@_Alias].date " & _
                "PIVOT [%$##@_Alias].type "


            End With
            accDr = accCmd.ExecuteReader
            dgv.Rows.Clear()
            If accDr.HasRows Then
                While accDr.Read
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = accDr.Item(1)
                    dgv.Item(1, c).Value = accDr.Item(2)
                    If IsDBNull(accDr.Item(3)) = True Then
                        dgv.Rows(c).Cells(2).Style.BackColor = Color.Red
                    Else
                        dgv.Item(2, c).Value = accDr.Item(0) & " " & accDr.Item(3) & ":00"
                    End If
                    If IsDBNull(accDr.Item(4)) = True Then
                        dgv.Rows(c).Cells(3).Style.BackColor = Color.Red
                    Else
                        dgv.Item(3, c).Value = accDr.Item(0) & " " & accDr.Item(4) & ":00"
                    End If
                    If IsDBNull(accDr.Item(5)) = True Then
                        dgv.Rows(c).Cells(4).Style.BackColor = Color.Red
                    Else
                        dgv.Item(4, c).Value = accDr.Item(0) & " " & accDr.Item(5) & ":00"
                    End If
                    If IsDBNull(accDr.Item(6)) = True Then
                        dgv.Rows(c).Cells(5).Style.BackColor = Color.Red
                    Else
                        dgv.Item(5, c).Value = accDr.Item(0) & " " & accDr.Item(6) & ":00"
                    End If
                    dgv.Item(8, c).Value = accDr.Item(0)
                    get_totalWorkedHours_late()
                    dgv.Item(6, c).Value = totalWorked.ToString("0.0")
                    dgv.Item(7, c).Value = totalLate
                    c = c + 1
                End While
            End If
            dgv.ClearSelection()
            lblCount.Text = dgv.Rows.Count
            accConn.Close()
            accCmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub ImportRecords()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgv.RowCount
        While col < row1
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "INSERT INTO tblAttendance VALUES('" & dgv.Item(0, col).Value & _
                    "','" & dgv.Item(8, col).Value & _
                    "','" & dgv.Item(2, col).Value & _
                    "','" & dgv.Item(3, col).Value & _
                    "','" & dgv.Item(4, col).Value & _
                    "','" & dgv.Item(5, col).Value & _
                    "','" & dgv.Item(6, col).Value & _
                    "','" & dgv.Item(7, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
            ProgressBar1.Value = ProgressBar1.Value + 1
        End While
        MsgBox("Attendace Record Succesfully Imported", MsgBoxStyle.Information, "Success")
        ProgressBar1.Value = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Microsoft Access Database(*.mdb)|*.mdb"
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            If MsgBox("Are you sure you want to load this database file ?", MsgBoxStyle.YesNo, "Are you sure ?") = MsgBoxResult.Yes Then
                txtDir.Text = OpenFileDialog1.FileName
                LoadAttendaceRecord()
            End If
        End If
    End Sub
    Sub get_totalWorkedHours_late()
        Dim AmWorked As Double
        Dim PmWorked As Double

        Dim amLate As Integer
        Dim pmLate As Integer

        Dim amIn As DateTime
        Dim amOut As DateTime
        Dim pmIn As DateTime
        Dim pmOut As DateTime
        If dgv.Rows(dgv.Rows.Count - 1).Cells(2).Value <> "" Then
            amIn = dgv.Rows(dgv.Rows.Count - 1).Cells(2).Value
        End If
        If dgv.Rows(dgv.Rows.Count - 1).Cells(3).Value <> "" Then
            amOut = dgv.Rows(dgv.Rows.Count - 1).Cells(3).Value
        End If
        If dgv.Rows(dgv.Rows.Count - 1).Cells(4).Value <> "" Then
            pmIn = dgv.Rows(dgv.Rows.Count - 1).Cells(4).Value
        End If
        If dgv.Rows(dgv.Rows.Count - 1).Cells(5).Value <> "" Then
            pmOut = dgv.Rows(dgv.Rows.Count - 1).Cells(5).Value
        End If
        If dgv.Rows(dgv.Rows.Count - 1).Cells(2).Value <> "" And dgv.Rows(dgv.Rows.Count - 1).Cells(3).Value <> "" Then
            AmWorked = DateDiff(DateInterval.Minute, amIn, amOut) / 60
            If amIn > CDate(dgv.Rows(dgv.Rows.Count - 1).Cells(8).Value & " " & "08:00:00") Then
                amLate = DateDiff(DateInterval.Second, CDate(dgv.Rows(dgv.Rows.Count - 1).Cells(8).Value & " " & "08:00:00"), amIn) / 60
            Else
                amLate = 0
            End If
        Else
            AmWorked = 0
            amLate = 0
        End If
        If dgv.Rows(dgv.Rows.Count - 1).Cells(4).Value <> "" And dgv.Rows(dgv.Rows.Count - 1).Cells(5).Value <> "" Then
            PmWorked = DateDiff(DateInterval.Minute, pmIn, pmOut) / 60

        Else
            PmWorked = 0
        End If
            If dgv.Rows(dgv.Rows.Count - 1).Cells(3).Value <> "" And dgv.Rows(dgv.Rows.Count - 1).Cells(4).Value <> "" Then
                If DateAdd(DateInterval.Hour, 1, amOut) < pmIn Then
                    pmLate = DateDiff(DateInterval.Second, DateAdd(DateInterval.Hour, 1, amOut), pmIn) / 60
                Else
                    pmLate = 0
                End If
            Else
                pmLate = 0
        End If
        If dgv.Rows(dgv.Rows.Count - 1).Cells(2).Value <> "" And dgv.Rows(dgv.Rows.Count - 1).Cells(5).Value <> "" Then
            totalWorked = (DateDiff(DateInterval.Minute, amIn, pmOut) / 60) - 1
        Else
            totalWorked = AmWorked + PmWorked
        End If
        totalLate = amLate + pmLate
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Are you sure you want to import this record ?", MsgBoxStyle.YesNo, "Are you sure ?") = MsgBoxResult.Yes Then
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = dgv.Rows.Count
            ImportRecords()
        End If
    End Sub




    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Dim time As String = InputBox("Please Enter Time")
            If time = "" Then
                Exit Sub
            End If
        dgv.CurrentCell.Value = dgv.CurrentRow.Cells(8).Value & " " & time & ":00"
        dgv.CurrentCell.Style.BackColor = Color.White
        Dim AmWorked As Double
        Dim PmWorked As Double

        Dim amLate As Integer
        Dim pmLate As Integer

        Dim amIn As DateTime
        Dim amOut As DateTime
        Dim pmIn As DateTime
        Dim pmOut As DateTime
        Try
        If dgv.CurrentCell.Value <> "" Then
            amIn = dgv.CurrentRow.Cells(2).Value
        End If
        If dgv.CurrentCell.Value <> "" Then
            amOut = dgv.CurrentRow.Cells(3).Value
        End If
        If dgv.CurrentCell.Value <> "" Then
            pmIn = dgv.CurrentRow.Cells(4).Value
        End If
        If dgv.CurrentCell.Value <> "" Then
            pmOut = dgv.CurrentRow.Cells(5).Value
            End If
        Catch ex As Exception
            MsgBox("Error Input", MsgBoxStyle.Critical, "Error")
        End Try
        If dgv.CurrentRow.Cells(2).Value <> "" And dgv.CurrentRow.Cells(3).Value <> "" Then
            AmWorked = DateDiff(DateInterval.Minute, amIn, amOut) / 60
            If amIn > CDate(dgv.CurrentRow.Cells(8).Value & " " & "08:00:00") Then
                amLate = DateDiff(DateInterval.Second, CDate(dgv.CurrentRow.Cells(8).Value & " " & "08:00:00"), amIn) / 60
            Else
                amLate = 0
            End If
        Else
            AmWorked = 0
            amLate = 0
        End If
        If dgv.CurrentRow.Cells(4).Value <> "" And dgv.CurrentRow.Cells(5).Value <> "" Then
            PmWorked = DateDiff(DateInterval.Minute, pmIn, pmOut) / 60

        Else
            PmWorked = 0
        End If
        If dgv.CurrentRow.Cells(3).Value <> "" And dgv.CurrentRow.Cells(4).Value <> "" Then
            If DateAdd(DateInterval.Hour, 1, amOut) < pmIn Then
                pmLate = DateDiff(DateInterval.Second, DateAdd(DateInterval.Hour, 1, amOut), pmIn) / 60
            Else
                pmLate = 0
            End If
        Else
            pmLate = 0
        End If
        totalWorked = AmWorked + PmWorked
        totalLate = amLate + pmLate
        dgv.CurrentRow.Cells(6).Value = totalWorked.ToString("0.0")
        dgv.CurrentRow.Cells(7).Value = totalLate
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class