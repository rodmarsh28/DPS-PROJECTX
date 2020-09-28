Public Class frmPrinting
    Sub clearRoll()
        txtRollCustomer.Text = ""
        txtRollMesh.Text = ""
        txtRollno1.Text = ""
        txtLoomno.Text = ""
        txtRollWidth.Text = ""
        cmbRollColor.Text = ""
        txtInputL.Text = ""
        txtInputW.Text = ""
        txtOutputL.Text = ""
        txtOutputW.Text = ""
        InkRollCons.Text = ""
    End Sub
    Sub clearManual()
        txtManualCustomer.Text = ""
        txtManualMesh.Text = ""
        txtRollno2.Text = ""
        txtManualWidth.Text = ""
        txtBagL.Text = ""
        txtColor.Text = ""
        txtSewnType.Text = ""
        txtInputQty.Text = ""
        txtPrintDefect.Text = ""
        txtDefWt.Text = ""
        txtOutputQty.Text = ""
        txtManualInkCons.Text = ""
    End Sub
    Sub clearInk()
        txtCqty.Text = ""
        txtSqty.Text = ""
    End Sub
    Sub disposeForm()
        txtPRno.Text = ""
        txtQA.Text = ""
        txtRemarks.Text = ""
        clearManual()
        clearRoll()
        dgvInk.Rows.Clear()
        dgvManual.Rows.Clear()
        dgvRoll.Rows.Clear()
    End Sub
    Sub getColor()
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
                .CommandText = "SELECT Distinct COLOR from tblLoomSectionTR where COLOR <> ''"
            End With
            OleDBDR = OleDBC.ExecuteReader
            cmbRollColor.Items.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    cmbRollColor.Items.Add(OleDBDR.Item(0))
                End While
                cmbRollColor.Items.Add("Assorted")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub generatePRNo()
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
                .CommandText = "SELECT * from tblPrinting order by PRNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                txtPRno.Text = "PR-" & Format(Val(StrID) + 1, "00000")

            Else
                txtPRno.Text = "PR-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub frmPrinting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getColor()
        generatePRNo()
    End Sub
    Sub SAVE()
        If dgvRoll.Rows.Count = "0" And dgvManual.Rows.Count = "0" Then
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
                    .CommandText = "INSERT INTO tblPrinting VALUES('" & txtPRno.Text & _
                        "','" & dtpDFrom.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & dtpDto.Value.ToString("MM/dd/yyyy hh:mm tt") & _
                        "','" & txtQA.Text & _
                        "','" & txtVisor.Text & _
                        "','" & txtRemarks.Text & "')"
                    .ExecuteNonQuery()
                End With
                saveRollItem()
                saveManualItem()
                saveInkMixture()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Printing Report Saved !", MsgBoxStyle.Information, "Success")
                disposeForm()
                Me.Close()
            End Try
        End If
    End Sub
    Sub saveRollItem()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgvRoll.RowCount
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
                .CommandText = "INSERT INTO tblRollPrinting VALUES('" & txtPRno.Text & _
                        "','" & dgvRoll.Item(0, col).Value & _
                        "','" & dgvRoll.Item(1, col).Value & _
                        "','" & dgvRoll.Item(2, col).Value & _
                        "','" & dgvRoll.Item(3, col).Value & _
                        "','" & dgvRoll.Item(4, col).Value & _
                        "','" & dgvRoll.Item(5, col).Value & _
                        "','" & dgvRoll.Item(6, col).Value & _
                        "','" & dgvRoll.Item(7, col).Value & _
                        "','" & dgvRoll.Item(8, col).Value & _
                        "','" & dgvRoll.Item(9, col).Value & _
                        "','" & dgvRoll.Item(10, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub
    Sub saveManualItem()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgvManual.RowCount
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
                .CommandText = "INSERT INTO tblManualPrintingTR VALUES('" & txtPRno.Text & _
                        "','" & dgvManual.Item(0, col).Value & _
                        "','" & dgvManual.Item(1, col).Value & _
                        "','" & dgvManual.Item(2, col).Value & _
                        "','" & dgvManual.Item(3, col).Value & _
                        "','" & dgvManual.Item(4, col).Value & _
                        "','" & dgvManual.Item(5, col).Value & _
                        "','" & dgvManual.Item(6, col).Value & _
                        "','" & dgvManual.Item(7, col).Value & _
                        "','" & dgvManual.Item(8, col).Value & _
                        "','" & dgvManual.Item(9, col).Value & _
                        "','" & dgvManual.Item(10, col).Value & _
                        "','" & dgvManual.Item(11, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub
    Sub saveInkMixture()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgvInk.RowCount
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
                .CommandText = "INSERT INTO tblInkMixtureTR VALUES('" & txtPRno.Text & _
                        "','" & dgvInk.Item(0, col).Value & _
                        "','" & dgvInk.Item(1, col).Value & _
                        "','" & dgvInk.Item(2, col).Value & "')"
                .ExecuteNonQuery()
            End With
            col = col + 1
        End While
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If txtCqty.Text = "" Or txtSqty.Text = "" Then
            Exit Sub
        End If
        Dim r As Integer = dgvInk.Rows.Count
        dgvInk.Rows.Add()
        dgvInk.Item(0, r).Value = cmbColor.Text
        dgvInk.Item(1, r).Value = txtCqty.Text
        dgvInk.Item(2, r).Value = txtSqty.Text
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim r As Integer = dgvRoll.Rows.Count
        dgvRoll.Rows.Add()
        dgvRoll.Item(0, r).Value = txtRollCustomer.Text
        dgvRoll.Item(1, r).Value = txtRollMesh.Text
        dgvRoll.Item(2, r).Value = txtRollno1.Text
        dgvRoll.Item(3, r).Value = txtLoomno.Text
        dgvRoll.Item(4, r).Value = txtRollWidth.Text
        dgvRoll.Item(5, r).Value = cmbRollColor.Text
        dgvRoll.Item(6, r).Value = txtInputL.Text
        dgvRoll.Item(7, r).Value = txtInputW.Text
        dgvRoll.Item(8, r).Value = txtOutputL.Text
        dgvRoll.Item(9, r).Value = txtOutputW.Text
        dgvRoll.Item(10, r).Value = InkRollCons.Text
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim r As Integer = dgvManual.Rows.Count
        dgvManual.Rows.Add()
        dgvManual.Item(0, r).Value = txtManualCustomer.Text
        dgvManual.Item(1, r).Value = txtManualMesh.Text
        dgvManual.Item(2, r).Value = txtRollno2.Text
        dgvManual.Item(3, r).Value = txtManualWidth.Text
        dgvManual.Item(4, r).Value = txtBagL.Text
        dgvManual.Item(5, r).Value = txtColor.Text
        dgvManual.Item(6, r).Value = txtSewnType.Text
        dgvManual.Item(7, r).Value = txtInputQty.Text
        If txtPrintDefect.Text = "" Then
            dgvManual.Item(8, r).Value = "0"
        Else
            dgvManual.Item(8, r).Value = txtPrintDefect.Text
        End If
        If txtDefWt.Text = "" Then
            dgvManual.Item(9, r).Value = "0"
        Else
            dgvManual.Item(9, r).Value = txtDefWt.Text
        End If
        dgvManual.Item(10, r).Value = txtOutputQty.Text
        dgvManual.Item(11, r).Value = txtManualInkCons.Text
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmRollSelection.mode = "PRINTING"
        frmRollSelection.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVE()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
       
    End Sub
End Class