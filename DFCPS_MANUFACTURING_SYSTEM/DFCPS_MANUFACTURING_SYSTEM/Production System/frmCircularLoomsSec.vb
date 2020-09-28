Public Class frmCircularLoomsSec
    Dim mesh As Double
    Dim widths As Double
    Dim doffed As Double
    Dim rpm As Double
    Public beginning As Double
    Public ending As Double
    Public prod As Double
    Public prodperday As Double
    Public effs As Double
    Public totProd As Double
    Public totEff As Double
    Public totaleff As Double
    Public totLooms As Double
    Dim totHourShift As Double
    Dim rollNo As Integer
    Dim ltrno As Integer
    Dim doffedlength As String
    Dim doffedwt As String
    Dim sizeMesh As String
    Dim sizeWidth As String
    Dim denier As Double
    Dim Color As String
    Public editmode As Boolean = False
    Dim rolls As String
    Dim looms As String
    Public biono As String
    Sub CLEAR()
        lblRollNo.Text = "0"
        txtDoffed.Text = ""
        txtDoffedWt.Text = ""
        txtBeginning.Text = ""
        txtEnding.Text = ""
        txtProduction.Text = ""
        txtEffiency.Text = ""
        txtRemarks.Text = ""
        TXTWASTE.Text = "0"
    End Sub
    Sub autoOperator()
        Try
            Dim col As New AutoCompleteStringCollection

            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "SELECT Distinct OPERATOR from tblLoomSectionTR "
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    col.Add(OleDBDR.Item(0))
                End While
                txtOperator.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtOperator.AutoCompleteCustomSource = col
                txtOperator.AutoCompleteMode = AutoCompleteMode.Suggest
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub DisposeForm()
        CLEAR()
        txtCos.Text = ""
        txtMTN.Text = ""
        txtOperator.Text = ""
        txtVisor.Text = ""
        totProd = 0
        totEff = 0
        totaleff = 0
        lblprod.Text = totProd
        lbleff.Text = Format(totaleff, "N")
        dgv.Rows.Clear()
        lblRollNo.Text = "0"
    End Sub

    Sub generateCLSNo()
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
                .CommandText = "SELECT * from tblLoomSection order by CLSNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 7, Len(OleDBDR(0)))
                txtCLSNO.Text = "CLS-" & Format(Val(StrID) + 1, "00000")

            Else
                txtCLSNO.Text = "CLS-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub getLoomsNo()
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
                .CommandText = "SELECT * from tblLooms where STATUS = 'Enable' order by loomNo DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            cmbLoomsNo.Items.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    cmbLoomsNo.Items.Add(OleDBDR.Item(0))
                End While

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub getLastEnding()
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
                .CommandText = "SELECT ENDING from tblLoomSection INNER JOIN dbo.tblLoomSectionTR ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                    "where LOOMSNO = '" & cmbLoomsNo.Text & "' order by Dateto desc"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                If OleDBDR.Read Then
                    If IsDBNull(OleDBDR.Item(0)) Then
                        txtBeginning.Text = ""
                        txtBeginning.Enabled = True
                    Else
                        txtBeginning.Text = OleDBDR.Item(0)
                        txtBeginning.Enabled = False
                    End If
                    

                End If
           
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub generateRollNo()
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
                .CommandText = "SELECT max(rollNo) from dbo.tblDoffed"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                If IsDBNull(OleDBDR.Item(0)) Then
                    rollNo = 1
                    lblRollNo.Text = rollNo
                Else
                    rollNo = OleDBDR.Item(0) + 1
                    lblRollNo.Text = rollNo
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub generateLTRNo()
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
                .CommandText = "SELECT max(LTRNO) from tblLoomSectionTR "
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                ltrno = OleDBDR.Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub SAVE()

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
                .CommandText = "INSERT INTO tblLoomSection VALUES('" & txtCLSNO.Text & _
                    "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                    "','" & dtpDto.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                    "','" & txtCos.Text & _
                    "','" & txtMTN.Text & _
                    "','" & txtVisor.Text & _
                    "','" & dgv.Rows.Count & _
                    "','" & lblprod.Text & _
                    "','" & lbleff.Text & "','Date Created " & Format(Now, "MM/dd/yyyy") & "')"
                .ExecuteNonQuery()
            End With
            saveItem()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MsgBox("LOOMS SECTION DAILY REPORT SAVED !", MsgBoxStyle.Information, "SUCCESS")
            cmbLoomsNo.Text = ""
            DisposeForm()
            generateCLSNo()
            getLoomsNo()
        End Try
    End Sub
    Sub calculatDenier()
        Dim gsm As Double = 0
        Dim meshwf As Integer = 0
        Dim warp As Integer = 0
        If sizeMesh = "10x10" Then
            meshwf = 10
            warp = 10
        ElseIf sizeMesh = "12x12" Then
            meshwf = 12
            warp = 12
        End If
        gsm = (doffedwt * 1000) / ((sizeWidth * 2) * (doffedlength * 100)) * 10000
        If doffedwt = 0 Then
            denier = 0
        Else
            denier = gsm * 9000 / ((meshwf + warp) * 39.37)
        End If

    End Sub
    Sub saveDoffed()
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
                .CommandText = "INSERT INTO tblDoffed VALUES('" & rolls & _
                    "','" & looms & _
                    "','" & sizeMesh & _
                    "','" & sizeWidth & _
                    "','" & doffedlength & _
                    "','" & doffedwt & _
                    "','" & Format(denier, "N") & _
                    "','" & Color & _
                    "','ZALDY FERRAN','Available','" & biono & "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub saveItem()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgv.RowCount
        While col < row1
            If dgv.Item(6, col).Value <> "0" Then
                doffedlength = dgv.Item(7, col).Value
                doffedwt = dgv.Item(8, col).Value
                sizeMesh = dgv.Item(1, col).Value
                sizeWidth = dgv.Item(2, col).Value
                rolls = dgv.Item(6, col).Value
                looms = dgv.Item(0, col).Value
                Color = dgv.Item(9, col).Value
                biono = dgv.Item(12, col).Value
                calculatDenier()
                saveDoffed()

            End If
            If conn.State = ConnectionState.Open Then
                OleDBC.Dispose()
                conn.Close()
            End If
            If conn.State <> ConnectionState.Open Then
                ConnectDatabase()
            End If
            With OleDBC
                .Connection = conn
                .CommandText = "INSERT INTO tblLoomSectionTR VALUES('" & txtCLSNO.Text & _
                        "','" & dgv.Item(0, col).Value & _
                        "','" & dgv.Item(1, col).Value & _
                        "','" & dgv.Item(2, col).Value & _
                        "','" & dgv.Item(3, col).Value & _
                        "','" & dgv.Item(4, col).Value & _
                        "','" & dgv.Item(5, col).Value & _
                        "','" & dgv.Item(6, col).Value & _
                        "','" & dgv.Item(7, col).Value & _
                        "','" & dgv.Item(8, col).Value & _
                        "','" & dgv.Item(9, col).Value & _
                        "','" & dgv.Item(10, col).Value & _
                        "','" & dgv.Item(11, col).Value & _
                        "','" & dgv.Item(12, col).Value & _
                        "','" & dgv.Item(13, col).Value & _
                        "','" & dgv.Item(14, col).Value & "')"
                .ExecuteNonQuery()
            End With

            col = col + 1

        End While
    End Sub

    Private Sub frmCircularLoomsSec_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DisposeForm()
    End Sub

    Private Sub frmCircularLoomsSec_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            delete()
        End If
    End Sub


    Private Sub frmCircularLoomsSec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If mode = "CLS-Update" Then
        ElseIf mode = "CLS-Add" Then
            generateCLSNo()
            getLoomsNo()
            lblRollNo.Text = "0"
            TXTWASTE.Text = "0.00"
            frmEmployeesList.EmployeesList()
            'generateRollNo()
        End If
        
        'autoOperator()
        txtWidth.Enabled = False
        txtDoffed.Enabled = False
        txtDoffedWt.Enabled = False
        txtRPM.Enabled = False
        txtOperator.Enabled = False
        txtBeginning.Enabled = False
        txtEnding.Enabled = False
        txtRemarks.Enabled = False
        txtMesh.Enabled = False
        lblRollNo.Enabled = False
        TXTWASTE.Enabled = False
        txtColor.Enabled = False



    End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    If txtMesh.Text = "" Or txtWidth.Text = "" Or txtRPM.Text = "" Or txtBeginning.Text = "" Or txtEnding.Text = "" Then
    '        MsgBox("Please Input All Feilds", MsgBoxStyle.Critical, "Error")
    '        Exit Sub

    '    End If
    '    totHourShift = (DateDiff(DateInterval.Minute, dtpDFrom.Value, dtpDto.Value) / 60)
    '    If txtDoffed.Text = "" Then
    '        txtDoffed.Text = "0"
    '    End If
    '    If txtDoffedWt.Text = "" Then
    '        txtDoffedWt.Text = "0"
    '    End If
    '    If txtMesh.Text = "10x10" Then
    '        mesh = 10
    '    ElseIf txtMesh.Text = "12x12" Then
    '        mesh = 12
    '    End If
    '    widths = txtWidth.Text
    '    doffed = txtDoffed.Text
    '    rpm = txtRPM.Text
    '    beginning = txtBeginning.Text
    '    ending = txtEnding.Text



    '    If ending <= beginning Then
    '        If txtDoffed.Text = "" Or txtDoffed.Text = "0" Then
    '            MsgBox("Please Input Doffed", MsgBoxStyle.Critical, "Error")
    '            Exit Sub
    '        End If
    '        prod = txtDoffed.Text - beginning + ending
    '    Else
    '        prod = ending - beginning
    '    End If
    '    prodperday = (rpm * 60 * totHourShift * 6) / (mesh * 39.37) * 0.95
    '    effs = prod * 100 / prodperday

    '    txtEffiency.Text = Format(effs, "N")
    '    txtProduction.Text = prod
    'End Sub

    Sub delete()
        For Each row As DataGridViewRow In dgv.SelectedRows
            
            totProd = totProd - dgv.CurrentRow.Cells(10).Value
            totEff = totEff - dgv.CurrentRow.Cells(11).Value
            cmbLoomsNo.Items.Add(dgv.CurrentRow.Cells(0).Value)
            dgv.Rows.Remove(row)
            totaleff = totEff / dgv.Rows.Count
        Next
        lblprod.Text = totProd
        lbleff.Text = Format(totaleff, "N")
    End Sub

    Private Sub cmbLoomsNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoomsNo.SelectedIndexChanged
        If cmbLoomsNo.Text = "" Then
            txtWidth.Enabled = False
            txtDoffed.Enabled = False
            txtDoffedWt.Enabled = False
            txtRPM.Enabled = False
            txtBeginning.Enabled = False
            txtEnding.Enabled = False
            txtRemarks.Enabled = False
            txtMesh.Enabled = False
            lblRollNo.Enabled = False
            TXTWASTE.Enabled = False
            txtColor.Enabled = False
        Else
            txtWidth.Enabled = True
            txtDoffed.Enabled = True
            txtDoffedWt.Enabled = True
            txtRPM.Enabled = True
            txtBeginning.Enabled = True
            txtEnding.Enabled = True
            txtRemarks.Enabled = True
            txtMesh.Enabled = True
            lblRollNo.Enabled = True
            TXTWASTE.Enabled = True
            txtColor.Enabled = True
        End If
        getLastEnding()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If lblRollNo.Text <> "0" And txtDoffed.Text = "0" And txtDoffedWt.Text = "0" Then
            MsgBox("Please Input Doffed Length", MsgBoxStyle.Critical, "Error")
            Exit Sub
        ElseIf txtDoffed.Text <> "0" And txtDoffedWt.Text = "0" Then
            If MsgBox("ARE YOU SURE YOU WANT TO ADD THIS WITHOUT DOFFED WEIGHT ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.No Then
                Exit Sub
            Else
                txtDoffedWt.Text = "0"
            End If
        End If
        If cmbLoomsNo.Text = "" Or txtMesh.Text = "" Or txtRPM.Text = "" Or txtBeginning.Text = "" Or txtEnding.Text = "" Or txtProduction.Text = "" Or txtEffiency.Text = "" Then
            MsgBox("Please Compute first before Adding", MsgBoxStyle.Critical, "Error")
            Exit Sub

        End If

        Dim c As Integer = dgv.Rows.Count
        Dim ln As String = cmbLoomsNo.Text
        dgv.Rows.Add()
        dgv.Item(0, c).Value = cmbLoomsNo.Text
        dgv.Item(1, c).Value = txtMesh.Text
        dgv.Item(2, c).Value = txtWidth.Text
        dgv.Item(3, c).Value = txtRPM.Text
        dgv.Item(4, c).Value = txtBeginning.Text
        dgv.Item(5, c).Value = txtEnding.Text
        If txtDoffed.Text = "0" Then
            dgv.Item(6, c).Value = "0"
        Else
            dgv.Item(6, c).Value = Format(Now, "yyyy") & "-" & lblRollNo.Text
        End If

        dgv.Item(7, c).Value = txtDoffed.Text
        dgv.Item(8, c).Value = txtDoffedWt.Text
        dgv.Item(9, c).Value = txtColor.Text
        dgv.Item(10, c).Value = txtProduction.Text
        dgv.Item(11, c).Value = txtEffiency.Text
        dgv.Item(12, c).Value = biono
        dgv.Item(13, c).Value = TXTWASTE.Text
        dgv.Item(14, c).Value = txtRemarks.Text

        totProd = totProd + prod
        totEff = totEff + txtEffiency.Text
        totaleff = totEff / dgv.Rows.Count
        If editmode = False And txtDoffed.Text <> "0" Then
            rollNo = rollNo + 1
            lblRollNo.Text = rollNo
        End If
        CLEAR()
        lblprod.Text = totProd
        lbleff.Text = Format(totaleff, "N")

        cmbLoomsNo.Items.Remove(ln)
        c = c + 1
        editmode = False

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        MsgBox(totHourShift)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("ARE YOU SURE YOU WANT TO SAVE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            If mode = "CLS-Update" Then
                deleteData()
                deleteData2()
                SAVE()
                'frmCLSViewer.historyviewer()
                Me.Close()
            ElseIf mode = "CLS-Add" Then
                SAVE()
            End If
        End If
        'Try
        '    For Each row As DataGridViewRow In dgv.Rows
        '        If conn.State = ConnectionState.Open Then
        '            OleDBC.Dispose()
        '            conn.Close()
        '        End If
        '        If conn.State <> ConnectionState.Open Then
        '            ConnectDatabase()
        '        End If
        '        With OleDBC
        '            .Connection = conn
        '            .CommandText = "update tblLoomSectionTR set EFFIENCY = '" & row.Cells(10).Value & "' " & _
        '                "where CLSNO='" & txtCLSNO.Text & "' AND loomSNo = '" & row.Cells(0).Value & "' "
        '            .ExecuteNonQuery()
        '        End With
        '    Next
        '    If conn.State = ConnectionState.Open Then
        '        OleDBC.Dispose()
        '        conn.Close()
        '    End If
        '    If conn.State <> ConnectionState.Open Then
        '        ConnectDatabase()
        '    End If
        '    With OleDBC
        '        .Connection = conn
        '        .CommandText = "update tblLoomSection set TOTEFF = '" & lbleff.Text & "' where CLSNO='" & txtCLSNO.Text & "' "
        '        .ExecuteNonQuery()
        '    End With
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    MsgBox("Efficiency Update Success", MsgBoxStyle.Information, "")
        '    Me.Close()
        'End Try
    End Sub

    Sub deleteData()
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
                .CommandText = "DELETE FROM tblLoomSection where CLSNO='" & txtCLSNO.Text & "'; " & _
                                "DELETE FROM tblLoomSectionTR where CLSNO='" & txtCLSNO.Text & "'
                .ExecuteNonQuery()
            End With
        Catch
        End Try

    End Sub
    Sub deleteData2()
        MsgBox(txtCLSNO.Text)
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
                .CommandText = "DELETE tblDoffed where rollNo in (select tblDoffed.rollNo FROM dbo.tblLoomSection " & _
                    "INNER JOIN dbo.tblLoomSectionTR ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                    "INNER JOIN dbo.tblDoffed ON dbo.tblLoomSectionTR.rollNo = dbo.tblDoffed.rollNo where tblLoomSection.CLSNO = '" & txtCLSNO.Text & "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        lblprod.Text = totProd
        lbleff.Text = Format(totaleff, "N")
        cmbLoomsNo.Items.Add(dgv.CurrentRow.Cells(0).Value)
        cmbLoomsNo.Text = dgv.CurrentRow.Cells(0).Value
        txtMesh.Text = dgv.CurrentRow.Cells(1).Value
        txtWidth.Text = dgv.CurrentRow.Cells(2).Value
        txtRPM.Text = dgv.CurrentRow.Cells(3).Value
        txtBeginning.Text = dgv.CurrentRow.Cells(4).Value
        txtEnding.Text = dgv.CurrentRow.Cells(5).Value
        lblRollNo.Text = dgv.CurrentRow.Cells(6).Value
        lblRollNo.Text = lblRollNo.Text.Remove(0, 5)
        txtDoffed.Text = dgv.CurrentRow.Cells(7).Value
        txtDoffedWt.Text = dgv.CurrentRow.Cells(8).Value
        txtColor.Text = dgv.CurrentRow.Cells(9).Value
        txtProduction.Text = dgv.CurrentRow.Cells(10).Value
        txtEffiency.Text = dgv.CurrentRow.Cells(11).Value
        txtOperator.Text = dgv.CurrentRow.Cells(12).Value
        biono = dgv.CurrentRow.Cells(12).Value
        TXTWASTE.Text = dgv.CurrentRow.Cells(13).Value
        txtRemarks.Text = dgv.CurrentRow.Cells(14).Value
        delete()
        editmode = True
    End Sub

    Private Sub dgv_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgv.CurrentCell = dgv(e.ColumnIndex, e.RowIndex)
                dgv.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        dgv.ContextMenuStrip = ContextMenuStrip2
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        totHourShift = (DateDiff(DateInterval.Minute, dtpDFrom.Value, dtpDto.Value) / 60) - 1
        MsgBox(totHourShift)
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        If txtDoffed.Text = "" Then
            txtDoffed.Text = "0"
        End If
        If txtMesh.Text = "10x10" Then
            mesh = 10
        ElseIf txtMesh.Text = "12x12" Then
            mesh = 12
        End If
        MsgBox(mesh)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        'If dgv.CurrentRow.Cells(6).Value <> "0" Then
        '    rollNo = rollNo - 1
        '    lblRollNo.Text = rollNo
        'End If
        delete()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        MsgBox(totaleff & " " & dgv.Rows.Count)
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub txtMesh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMesh.SelectedIndexChanged

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If txtMesh.Text = "" Or txtWidth.Text = "" Or txtRPM.Text = "" Or txtBeginning.Text = "" Or txtEnding.Text = "" Then
            MsgBox("Please Input All Feilds", MsgBoxStyle.Critical, "Error")
            Exit Sub

        End If
        totHourShift = (DateDiff(DateInterval.Minute, dtpDFrom.Value, dtpDto.Value) / 60)
        If txtDoffed.Text = "" Then
            txtDoffed.Text = "0"
        End If
        If txtDoffedWt.Text = "" Then
            txtDoffedWt.Text = "0"
        End If
        If txtMesh.Text = "10x10" Then
            mesh = 10
        ElseIf txtMesh.Text = "12x12" Then
            mesh = 12
        End If
        widths = txtWidth.Text
        doffed = txtDoffed.Text
        rpm = txtRPM.Text
        beginning = txtBeginning.Text
        ending = txtEnding.Text


        If txtDoffed.Text <> "" Then
            If lblRollNo.Text = "" Then
                MsgBox("Please Enter Roll no.")
                Exit Sub
            ElseIf txtDoffed.Text = "" Then
                MsgBox("Please Enter Doffed Weight")
                Exit Sub
            End If
            prod = txtDoffed.Text - beginning + ending
        Else
            prod = ending - beginning
        End If
        prodperday = (rpm * 60 * totHourShift * 6) / (mesh * 39.37) * 0.95
        effs = prod * 100 / prodperday

        txtEffiency.Text = Format(effs, "N")
        txtProduction.Text = prod
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmEmployeesList.FORMSTATUS = "CLS"
        frmEmployeesList.ShowDialog()
    End Sub

    Private Sub txtBeginning_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBeginning.TextChanged

    End Sub
End Class