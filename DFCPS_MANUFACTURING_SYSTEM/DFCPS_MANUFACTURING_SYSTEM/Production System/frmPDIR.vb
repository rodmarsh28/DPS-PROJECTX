Public Class frmPDIR
    Public CSRITEMNO As String
    Dim ADD As String
    Sub generateFPINo()
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
                .CommandText = "SELECT * from tblFPI order by FPINO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                txtPDIR.Text = "FPI-" & Format(Val(StrID) + 1, "00000")

            Else
                txtPDIR.Text = "FPI-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    'Sub getLoomsNo()
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
    '            .CommandText = "SELECT tblDoffed.rollNo, tblLoomSectionTR.DOFFED, tblLoomSectionTR.LOOMSNO FROM dbo.tblLoomSection INNER JOIN " & _
    '                            "dbo.tblLoomSectionTR ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO INNER JOIN dbo.tblDoffed ON " & _
    '                            "dbo.tblLoomSectionTR.LTRNO = dbo.tblDoffed.LTRNO" & _
    '                            " where tblDoffed.rollNo = '" & cmbRollno.Text & "'"
    '        End With
    '        OleDBDR = OleDBC.ExecuteReader
    '        If OleDBDR.Read Then
    '            txtLoomNo.Text = OleDBDR.Item(2)
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally

    '    End Try
    'End Sub
    'Sub getRollNo()
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
    '            .CommandText = "SELECT * from tblDoffed order by rollNo DESC"
    '        End With
    '        OleDBDR = OleDBC.ExecuteReader
    '        cmbRollno.Items.Clear()
    '        If OleDBDR.HasRows Then
    '            While OleDBDR.Read
    '                cmbRollno.Items.Add(OleDBDR.Item(0))
    '            End While

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally

    '    End Try
    'End Sub
    Sub clear()
        txtLoomNo.Text = ""
        txtInputQTY.Text = ""
        txtBadlength.Text = ""
        txtWeavReject.Text = ""
        txtPrintReject.Text = ""
        txtSewingReject.Text = ""
        txtGrossQty.Text = ""
        txtNetQty.Text = ""
        txtRemarks.Text = ""
        txtRollNo.Text = ""
        txtLoomNo.Text = ""
        txtWidth.Text = ""
        txtColor.Text = ""
        txtMesh.Text = ""
    End Sub
    Sub DisposeForm()
        clear()
        txtPDIR.Text = ""
        txtInspector.Text = ""
        txtVisor.Text = ""
        txtCustomer.Text = ""
        dgv.Rows.Clear()
    End Sub
    Sub SAVE()
        If dgv.Rows.Count = "0" Then
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
                    .CommandText = "INSERT INTO tblFPI VALUES('" & txtPDIR.Text & _
                        "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dtpDto.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dgv.Rows.Count & _
                        "','" & txtInspector.Text & _
                        "','" & txtVisor.Text & "','Saved Date " & Format(Now, "MM/dd/yyyy") & "')"
                    .ExecuteNonQuery()
                End With
                saveItem()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Cutting & Sewing Daily Report Saved !", MsgBoxStyle.Information, "Success")
                DisposeForm()
                Me.Close()
            End Try
        End If
    End Sub

    Sub saveItem()
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
                .CommandText = "INSERT INTO tblFPITR VALUES('" & txtPDIR.Text & _
                        "','" & dgv.Item(0, col).Value & _
                        "','" & dgv.Item(4, col).Value & _
                        "','" & dgv.Item(5, col).Value & _
                        "','" & dgv.Item(6, col).Value & _
                        "','" & dgv.Item(7, col).Value & _
                         "','" & dgv.Item(9, col).Value & _
                        "','" & dgv.Item(10, col).Value & _
                        "','" & dgv.Item(11, col).Value & _
                        "','" & dgv.Item(12, col).Value & _
                        "','" & dgv.Item(13, col).Value & _
                        "','" & dgv.Item(14, col).Value & _
                        "','" & dgv.Item(15, col).Value & _
                        "','" & dgv.Item(16, col).Value & _
                        "','" & dgv.Item(17, col).Value & _
                        "','" & dgv.Item(18, col).Value & "'); " & _
                        "update tblCSRTR SET status = 'INSPECTION DONE (" & Format(dtpDFrom.Value, "MM/dd/yyyy") & "' " & _
                        "where CSRITEMNO = '" & dgv.Item(0, col).Value & "'"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub

    Private Sub cmbRollno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub frmPDIR_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DisposeForm()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtRollNo.Text = "" Or txtLoomNo.Text = "" Or txtInputQTY.Text = "" Or txtBadlength.Text = "" Or txtWeavReject.Text = "" Or txtPrintReject.Text = "" Or txtSewingReject.Text = "" Or cmbSewnType.Text = "" Then
            Exit Sub
        End If
        Dim R As Integer = dgv.Rows.Count
        dgv.Rows.Add()
        dgv.Item(0, R).Value = CSRITEMNO
        dgv.Item(1, R).Value = txtCustomer.Text
        dgv.Item(2, R).Value = txtMesh.Text
        dgv.Item(3, R).Value = txtRollNo.Text
        dgv.Item(4, R).Value = txtWidth.Text
        dgv.Item(5, R).Value = txtBadlength.Text
        dgv.Item(6, R).Value = txtColor.Text
        dgv.Item(7, R).Value = cmbSewnType.Text
        dgv.Item(8, R).Value = txtLoomNo.Text
        dgv.Item(9, R).Value = txtInputQTY.Text
        dgv.Item(10, R).Value = txtWeavReject.Text
        dgv.Item(11, R).Value = wrWt.Text
        dgv.Item(12, R).Value = txtPrintReject.Text
        dgv.Item(13, R).Value = prWt.Text
        dgv.Item(14, R).Value = txtSewingReject.Text
        dgv.Item(15, R).Value = srWt.Text
        dgv.Item(16, R).Value = txtGrossQty.Text
        dgv.Item(17, R).Value = txtNetQty.Text
        dgv.Item(18, R).Value = txtRemarks.Text
        clear()
    End Sub

    Private Sub frmPDIR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateFPINo()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVE()
    End Sub
    Sub compute()
        If txtWeavReject.Text = "" Then
            txtWeavReject.Text = "0"
        End If
        If txtPrintReject.Text = "" Then
            txtPrintReject.Text = "0"
        End If
        If txtSewingReject.Text = "" Then
            txtSewingReject.Text = "0"
        End If
        If prWt.Text = "" Then
            prWt.Text = "0"
        End If
        If wrWt.Text = "" Then
            wrWt.Text = "0"
        End If
        If srWt.Text = "" Then
            srWt.Text = "0"
        End If
        Dim netqty As Integer = 0
        Dim gross As Integer
        Dim wr As Integer
        Dim pr As Integer
        Dim sr As Integer
        txtGrossQty.Text = txtInputQTY.Text
        gross = txtGrossQty.Text
        wr = txtWeavReject.Text
        pr = txtPrintReject.Text
        sr = txtSewingReject.Text

        netqty = (gross - (wr + pr + sr))
        txtNetQty.Text = netqty
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmSelectforInspection.ShowDialog()
    End Sub

    Private Sub txtGrossQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrossQty.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        compute()
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
    Sub addDuplicateData()
        Dim R As Integer = dgv.Rows.Count
        Dim qty As String = InputBox("Please Input QTY")
        If IsNumeric(qty) Then
            dgv.Rows.Add()
            dgv.Item(0, R).Value = dgv.CurrentRow.Cells(0).Value
            dgv.Item(1, R).Value = dgv.CurrentRow.Cells(1).Value
            dgv.Item(2, R).Value = dgv.CurrentRow.Cells(2).Value
            dgv.Item(3, R).Value = dgv.CurrentRow.Cells(3).Value
            dgv.Item(4, R).Value = dgv.CurrentRow.Cells(4).Value
            dgv.Item(5, R).Value = "0"
            dgv.Item(6, R).Value = dgv.CurrentRow.Cells(6).Value
            dgv.Item(7, R).Value = "0"
            dgv.Item(8, R).Value = "0"
            dgv.Item(9, R).Value = "0"
            dgv.Item(10, R).Value = "0"
            dgv.Item(11, R).Value = "0"
            dgv.Item(12, R).Value = "0"
            dgv.Item(13, R).Value = "0"
            dgv.CurrentRow.Cells(14).Value = dgv.CurrentRow.Cells(14).Value - qty
            dgv.Item(14, R).Value = qty
            dgv.Item(15, R).Value = ADD
            dgv.Item(16, R).Value = ""
        Else
            MsgBox("Please Input Numeric Only", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub TopSewnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopSewnToolStripMenuItem.Click
        If dgv.CurrentRow.Cells(15).Value = "STANDARD" Then
            ADD = "TOP SEWN"
            addDuplicateData()
        End If
    End Sub

    Private Sub StandardSewnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardSewnToolStripMenuItem.Click
        If dgv.CurrentRow.Cells(15).Value = "TOP SEWN" Then
            ADD = "STANDARD"
            addDuplicateData()
        End If
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

End Class