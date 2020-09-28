Public Class frmRecycle
    Dim RCC As String
    Dim totalInput As Double
    Dim totalOutput As Double
    Dim ITEMCODE As String
    Dim ItemExist As Boolean
    'Sub getColor()
    '    Try
    '        If conn.State = ConnectionState.Open Then
    '            OleDBC.Dispose()
    '            conn.Close()
    '        End If
    '        If conn.State <> ConnectionState.Open Then
    '            ConnectDatabase()
    '        End If
    '        With OleDBC
    '            .Connection = conn
    '            .CommandText = "SELECT Distinct COLOR from tblLoomSectionTR where COLOR <> ''"
    '        End With
    '        OleDBDR = OleDBC.ExecuteReader
    '        cmbColor.Items.Clear()
    '        If OleDBDR.HasRows Then
    '            While OleDBDR.Read
    '                cmbColor.Items.Add(OleDBDR.Item(0))
    '            End While

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally

    '    End Try
    'End Sub
    Sub generateRRNo()
        Dim StrID As String
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
                .CommandText = "SELECT * from tblRecycle order by RRNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                txtRRno.Text = "RR-" & Format(Val(StrID) + 1, "00000")

            Else
                txtRRno.Text = "RR-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub selectIfExist()
        Dim StrID As String
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
                .CommandText = "SELECT ITEMCODE from tblRecycleOutputTR where DESCRIPTION = 'COLOR " & cmbColor.Text & "'"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                ITEMCODE = OleDBDR.Item(0)
                ItemExist = True
            Else
                generateITEMCODE()
                ItemExist = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub generateITEMCODE()
        Dim StrID As String
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
                .CommandText = "SELECT ITEMCODE from tblRecycleOutputTR order by ITEMCODE DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                ITEMCODE = "RCL-" & Format(Val(StrID) + 1, "00000")
            Else
                ITEMCODE = "RCL-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub disposeForm()
        txtOperator.Text = ""
        dgvInput.Rows.Clear()
        dgvOutput.Rows.Clear()
        totalInput = 0
        totalOutput = 0
        lblTotInput.Text = "Total Input Wt. (KGS): " & totalInput
        lblTotOutput.Text = "Total Output Wt. (KGS): " & totalOutput
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Input As String = InputBox("Enter Input Wt.")
        If IsNumeric(Input) = False Then
            MsgBox("Please Put Correct Weight", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        Dim r As Integer = dgvInput.Rows.Count
        dgvInput.Rows.Add()
        dgvInput.Item(0, r).Value = r + 1
        dgvInput.Item(1, r).Value = Input
        totalInput = totalInput + Input
        lblTotInput.Text = "Total Input Wt. (KGS): " & totalInput

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Input As String = InputBox("Enter Output Wt.")
        If IsNumeric(Input) = False Then
            MsgBox("Please Put Correct Weight", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        Dim r As Integer = dgvOutput.Rows.Count
        dgvOutput.Rows.Add()
        dgvOutput.Item(0, r).Value = ITEMCODE
        dgvOutput.Item(1, r).Value = r + 1
        dgvOutput.Item(2, r).Value = cmbColor.Text
        dgvOutput.Item(3, r).Value = Input
        dgvOutput.Item(4, r).Value = "YES"
        totalOutput = totalOutput + Input
        lblTotOutput.Text = "Total Output Wt. (KGS): " & totalOutput
        Dim strID As String
        strID = Mid(ITEMCODE, 5, Len(ITEMCODE(0)))
        ITEMCODE = "RCL-" & Format(Val(StrID) + 1, "00000")
    End Sub

  

    Private Sub dgvInput_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInput.CellMouseDoubleClick
        Dim Input As String = InputBox("Enter Output Wt.")
        If IsNumeric(Input) = False Then
            MsgBox("Please Put Correct Weight", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        totalInput = totalInput - dgvInput.CurrentRow.Cells(1).Value
        totalInput = totalInput + Input
        lblTotInput.Text = "Total Input Wt. (KGS): " & totalInput
        dgvInput.CurrentRow.Cells(1).Value = Input
    End Sub

    Private Sub dgvInput_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInput.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgvInput.CurrentCell = dgvInput(e.ColumnIndex, e.RowIndex)
                dgvInput.ContextMenuStrip = ContextMenuStrip1
                RCC = "Input"
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgvOutput_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOutput.CellMouseDoubleClick
        Dim Input As String = InputBox("Enter Output Wt.")
        If IsNumeric(Input) = False Then
            MsgBox("Please Put Correct Weight", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        totalOutput = totalOutput - dgvOutput.CurrentRow.Cells(3).Value
        totalOutput = totalOutput + Input
        lblTotOutput.Text = "Total Input Wt. (KGS): " & totalOutput
        dgvOutput.CurrentRow.Cells(1).Value = Input
    End Sub

    Private Sub dgvOutput_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOutput.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgvOutput.CurrentCell = dgvOutput(e.ColumnIndex, e.RowIndex)
                dgvOutput.ContextMenuStrip = ContextMenuStrip1
                RCC = "Output"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SAVE()
        If dgvInput.Rows.Count = "0" Or dgvOutput.Rows.Count = "0" Then
            MsgBox("No Data can be Save", MsgBoxStyle.Critical, "Sorry")
            Exit Sub
        End If
        If MsgBox("ARE YOU SURE YOU WANT TO SAVE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = "INSERT INTO tblRecycle VALUES('" & txtRRno.Text & _
                        "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dtpDto.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & txtOperator.Text & _
                        "','" & txtVisor.Text & _
                        "','" & totalInput & _
                        "','" & totalOutput & _
                        "','" & txtRemarks.Text & "')"
                    .ExecuteNonQuery()
                End With
                saveItem()
                saveItem2()
                saveInventory()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Recycle Report Saved !", MsgBoxStyle.Information, "Success")
                DisposeForm()
                Me.Close()
            End Try
        End If
    End Sub
    Sub saveItem()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgvInput.RowCount
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
                .CommandText = "INSERT INTO tblRecycleInputTR VALUES('" & txtRRno.Text & _
                        "','" & dgvInput.Item(0, col).Value & _
                        "','" & dgvInput.Item(1, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub
    Sub saveItem2()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgvOutput.RowCount
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
                .CommandText = "INSERT INTO tblRecycleOutputTR VALUES('" & txtRRno.Text & _
                                "','" & dgvOutput.Item(1, col).Value & _
                                "','" & dgvOutput.Item(0, col).Value & _
                                "','Recycled Resin " & _
                                "','COLOR " & dgvOutput.Item(2, col).Value & _
                                "','KG " & _
                                "','" & dgvOutput.Item(3, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub
    Sub saveInventory()
        For Each row As DataGridViewRow In dgvOutput.Rows
            If row.Cells(4).Value = "YES" Then
                checkConn()
                With OleDBC
                    .Connection = conn
                    .CommandText = "INSERT INTO tblRMInventory VALUES('" & row.Cells(0).Value & _
                            "','" & row.Cells(1).Value & _
                            "','Recycled Resin','KG')"
                    .ExecuteNonQuery()
                End With
            End If
            checkConn()
            With OleDBC
                .Connection = conn
                .CommandText = "INSERT INTO tblRMInventoryTrans VALUES('" & txtRRno.Text & _
                        "','" & row.Cells(0).Value & _
                        "','" & row.Cells(3).Value & _
                        "','0.00')"
                .ExecuteNonQuery()
            End With
        Next
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        If RCC = "Input" Then
            If dgvInput.Rows.Count <> dgvInput.CurrentCell.RowIndex + 1 Then
                MsgBox("You Can't Delete this")
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgvInput.SelectedRows
                totalInput = totalInput - dgvInput.CurrentRow.Cells(1).Value
                lblTotInput.Text = "Total Input Wt. (KGS): " & totalInput
                dgvInput.Rows.Remove(row)
            Next
        ElseIf RCC = "Output" Then
            If dgvOutput.Rows.Count <> dgvOutput.CurrentCell.RowIndex + 1 Then
                MsgBox("You Can't Delete this")
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgvOutput.SelectedRows
                totalOutput = totalOutput - dgvOutput.CurrentRow.Cells(1).Value
                lblTotOutput.Text = "Total Input Wt. (KGS): " & totalOutput
                dgvOutput.Rows.Remove(row)
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVE()
    End Sub

    Private Sub frmRecycle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        disposeForm()
    End Sub

    Private Sub frmRecycle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateRRNo()
        generateITEMCODE()
    End Sub

    Private Sub dgvOutput_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOutput.CellContentClick

    End Sub

    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    perform = ""
    '    frmItemViewer.txtSearch.Text = "RCL"
    '    frmItemViewer.txtSearch.Enabled = False
    '    frmItemViewer.ShowDialog()
    '    If frmItemViewer.itemClicked = True Then
    '        Dim Input As String = InputBox("Enter Output Wt.")
    '        If IsNumeric(Input) = False Then
    '            MsgBox("Please Put Correct Weight", MsgBoxStyle.Critical, "Error")
    '            Exit Sub
    '        End If
    '        Dim r As Integer = dgvOutput.Rows.Count
    '        dgvOutput.Rows.Add()
    '        dgvOutput.Item(0, r).Value = frmItemViewer.dgv.CurrentRow.Cells(0).Value
    '        dgvOutput.Item(1, r).Value = r + 1
    '        dgvOutput.Item(2, r).Value = frmItemViewer.dgv.CurrentRow.Cells(2).Value
    '        dgvOutput.Item(3, r).Value = Input
    '        dgvOutput.Item(4, r).Value = "NO"
    '        totalOutput = totalOutput + Input
    '        lblTotOutput.Text = "Total Output Wt. (KGS): " & totalOutput
    '        frmItemViewer.itemClicked = False
    '    End If
    'End Sub
End Class