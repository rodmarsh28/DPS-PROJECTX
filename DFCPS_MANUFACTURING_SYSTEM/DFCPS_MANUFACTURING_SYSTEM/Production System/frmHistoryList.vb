Public Class frmHistoryList
    Sub CLSviewer()
        Dim c As Integer = 0
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblLoomSection.CLSNO,dbo.tblLoomSection.DATEFROM,dbo.tblLoomSection.DATETO,dbo.tblLoomSection.LOOMSCOUNT," & _
                    "dbo.tblLoomSection.TOTMETERSPROD,dbo.tblLoomSection.TOTEFF,dbo.tblLoomSection.VISOR FROM dbo.tblLoomSection ORDER BY CLSNO DESC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvCLS.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgvCLS.Rows.Add()
                    dgvCLS.Item(0, c).Value = OleDBDR.Item(0)
                    dgvCLS.Item(1, c).Value = Format(OleDBDR.Item(1), "MM/dd hh:mm tt") & " - " & Format(OleDBDR.Item(2), "MM/dd hh:mm tt yyyy")
                    dgvCLS.Item(2, c).Value = OleDBDR.Item(3)
                    dgvCLS.Item(3, c).Value = OleDBDR.Item(4)
                    dgvCLS.Item(4, c).Value = OleDBDR.Item(5)
                    dgvCLS.Item(5, c).Value = OleDBDR.Item(6)
                    c = c + 1

                End While
            End If
            dgvCLS.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub QAviewer()
        Dim c As Integer = 0
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblQA.QANO,dbo.tblQA.dFrom,dbo.tblQA.dTo,dbo.tblQA.QA,dbo.tblQA.MESH,dbo.tblQA.CUSTOMER,dbo.tblQA.SUPERVISOR " & _
                    "FROM dbo.tblQA " & _
                    "ORDER BY dbo.tblQA.QANO DESC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvQA.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgvQA.Rows.Add()
                    dgvQA.Item(0, c).Value = OleDBDR.Item(0)
                    dgvQA.Item(1, c).Value = Format(OleDBDR.Item(1), "MM/dd hh:mm tt") & " - " & Format(OleDBDR.Item(2), "MM/dd hh:mm tt yyyy")
                    dgvQA.Item(2, c).Value = OleDBDR.Item(3)
                    dgvQA.Item(3, c).Value = OleDBDR.Item(4)
                    dgvQA.Item(4, c).Value = OleDBDR.Item(5)
                    dgvQA.Item(5, c).Value = OleDBDR.Item(6)
                    c = c + 1

                End While
            End If
            dgvQA.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub RMWviewer()
        Dim c As Integer = 0
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT rmwno,[date],reqby FROM dbo.tblRMW ORDER BY [date] DESC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvRMW.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgvRMW.Rows.Add()
                    dgvRMW.Item(0, c).Value = OleDBDR.Item(0)
                    dgvRMW.Item(1, c).Value = Format(OleDBDR.Item(1), "MM/dd/yyyy hh:mm tt")
                    dgvRMW.Item(2, c).Value = OleDBDR.Item(2)
                    c = c + 1

                End While
            End If
            dgvRMW.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Sub Dirviewer()
        Dim c As Integer = 0
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblFPI.fpiNo,dbo.tblFPI.dFrom,dbo.tblFPI.dTo,dbo.tblFPI.inspector,dbo.tblFPI.supervisor FROM dbo.tblFPI " & _
                    "ORDER BY dbo.tblFPI.fpiNo DESC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvDir.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgvDir.Rows.Add()
                    dgvDir.Item(0, c).Value = OleDBDR.Item(0)
                    dgvDir.Item(1, c).Value = Format(OleDBDR.Item(1), "MM/dd hh:mm tt") & " - " & Format(OleDBDR.Item(2), "MM/dd hh:mm tt yyyy")
                    dgvDir.Item(2, c).Value = OleDBDR.Item(3)
                    dgvDir.Item(3, c).Value = OleDBDR.Item(4)
                    c = c + 1

                End While
            End If
            dgvDir.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub DYRviewer()
        Dim c As Integer = 0
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblDYR.DYNO,dbo.tblDYR.dFrom,dbo.tblDYR.dTo,dbo.tblDYR.OPERATOR,dbo.tblDYR.VISOR FROM dbo.tblDYR " & _
                    "ORDER BY dbo.tblDYR.DYNO DESC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvDYR.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgvDYR.Rows.Add()
                    dgvDYR.Item(0, c).Value = OleDBDR.Item(0)
                    dgvDYR.Item(1, c).Value = Format(OleDBDR.Item(1), "MM/dd hh:mm tt") & " - " & Format(OleDBDR.Item(2), "MM/dd hh:mm tt yyyy")
                    dgvDYR.Item(2, c).Value = OleDBDR.Item(3)
                    dgvDYR.Item(3, c).Value = OleDBDR.Item(4)
                    c = c + 1
                End While
            End If
            dgvDYR.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub DSCviewer()
        Dim c As Integer = 0
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblCSR.CSRNO,dbo.tblCSR.dFrom,dbo.tblCSR.dTo,dbo.tblCSR.Operator,dbo.tblCSR.Supervisor FROM dbo.tblCSR " & _
                    "ORDER BY dbo.tblCSR.CSRNO DESC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvDSC.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgvDSC.Rows.Add()
                    dgvDSC.Item(0, c).Value = OleDBDR.Item(0)
                    dgvDSC.Item(1, c).Value = Format(OleDBDR.Item(1), "MM/dd hh:mm tt") & " - " & Format(OleDBDR.Item(2), "MM/dd hh:mm tt yyyy")
                    dgvDSC.Item(2, c).Value = OleDBDR.Item(3)
                    dgvDSC.Item(3, c).Value = OleDBDR.Item(4)
                    c = c + 1
                End While
            End If
            dgvDSC.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub MRviewer()
        Dim c As Integer = 0
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblMR.MRNO,dbo.tblMR.dfrom,dbo.tblMR.dTo,dbo.tblMR.OPERATOR,dbo.tblMR.VISOR FROM dbo.tblMR " & _
                    "ORDER BY dbo.tblMR.MRNO DESC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvMR.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgvMR.Rows.Add()
                    dgvMR.Item(0, c).Value = OleDBDR.Item(0)
                    dgvMR.Item(1, c).Value = Format(OleDBDR.Item(1), "MM/dd hh:mm tt") & " - " & Format(OleDBDR.Item(2), "MM/dd hh:mm tt yyyy")
                    dgvMR.Item(2, c).Value = OleDBDR.Item(3)
                    dgvMR.Item(3, c).Value = OleDBDR.Item(4)
                    c = c + 1
                End While
            End If
            dgvMR.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub FYRviewer()
        Dim c As Integer = 0
        Try
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT dbo.tblPDORFY.FYRNO,dbo.tblPDORFY.dFrom,dbo.tblPDORFY.dTo,dbo.tblPDORFY.Operator,dbo.tblPDORFY.Visor FROM dbo.tblPDORFY " & _
                    "ORDER BY dbo.tblPDORFY.FYRNO DESC"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgvFYR.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgvFYR.Rows.Add()
                    dgvFYR.Item(0, c).Value = OleDBDR.Item(0)
                    dgvFYR.Item(1, c).Value = Format(OleDBDR.Item(1), "MM/dd hh:mm tt") & " - " & Format(OleDBDR.Item(2), "MM/dd hh:mm tt yyyy")
                    dgvFYR.Item(2, c).Value = OleDBDR.Item(3)
                    dgvFYR.Item(3, c).Value = OleDBDR.Item(4)
                    c = c + 1
                End While
            End If
            dgvFYR.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub frmHistoryList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CLSviewer()
        QAviewer()
        'DRviewer()
        Dirviewer()
        DYRviewer()
        DSCviewer()
        MRviewer()
        FYRviewer()
        RMWviewer()

    End Sub

    Private Sub dgvDR_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
End Class