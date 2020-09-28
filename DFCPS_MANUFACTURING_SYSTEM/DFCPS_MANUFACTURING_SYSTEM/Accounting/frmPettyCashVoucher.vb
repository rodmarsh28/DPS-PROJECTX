Public Class frmPettyCashVoucher
    Dim PARTICULARS As String
    Dim DEBIT As Double
    Dim AMOUNT As Double
    Dim totAmount As Double
    Dim TotDebit As Double
    Sub clear()
        txtPayee.Text = ""
        txtIDNo.Text = ""
        txtSection.Text = ""
        txtDepartment.Text = ""
        txtReceivedBy.Text = ""
        dgw.Rows.Clear()
        totAmount = 0.0
        TotDebit = 0.0
        lblTotAmount.Text = "0.00"
        lblTotDebit.Text = "0.00"
    End Sub
    Sub autoCompletePayee()
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
                .CommandText = "SELECT Distinct PAYEE from tblPCV "
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    col.Add(OleDBDR.Item(0))
                End While
                txtPayee.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtPayee.AutoCompleteCustomSource = col
                txtPayee.AutoCompleteMode = AutoCompleteMode.Suggest
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
  
    Sub autoCompleteSection()
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
                .CommandText = "SELECT Distinct SECTION from tblPCV "
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    col.Add(OleDBDR.Item(0))
                End While
                txtSection.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtSection.AutoCompleteCustomSource = col
                txtSection.AutoCompleteMode = AutoCompleteMode.Suggest
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub autoCompleteDepartment()
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
                .CommandText = "SELECT Distinct DEPARTMENT from tblPCV "
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    col.Add(OleDBDR.Item(0))
                End While
                txtDepartment.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtDepartment.AutoCompleteCustomSource = col
                txtDepartment.AutoCompleteMode = AutoCompleteMode.Suggest
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub generatePCVNo()
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
                .CommandText = "SELECT * from tblPCV order by PCVNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 7, Len(OleDBDR(0)))
                txtPCVNo.Text = "PCV-" & Format(Val(StrID) + 1, "00000")
            Else
                txtPCVNo.Text = "PCV-00001"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub save()
        If MsgBox("ARE YOU SURE YOU WANT TO SAVE PETTY CASH VOUCHER ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
       
        End If
    End Sub
      Sub updateStatus()

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
                .CommandText = "update tblPODESC SET POSTATUS= 'WAITING FOR ITEMS RECEIVED' where PONO ='" & txtRefNo.Text & "' " & _
                               "update tblRFP SET status= 'PETTY CASH ISSUED' where RFPNO ='" & txtRefNo.Text & "'"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
        End Try

    End Sub
    Sub dgwItemProcess()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgw.RowCount
        While col < row1
            PARTICULARS = dgw.Item(0, col).Value
            DEBIT = dgw.Item(1, col).Value
            AMOUNT = dgw.Item(2, col).Value
            saveItem()
            col = col + 1
        End While

    End Sub
    Sub saveItem()
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
                .CommandText = "INSERT INTO tblPCVItems VALUES('" & txtPCVNo.Text & _
                    "','" & PARTICULARS & _
                    "','" & DEBIT & _
                    "','" & AMOUNT & "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim parts As String = InputBox("Please Enter PARTICULARS")
        If parts = " " Or parts = "" Then
            MessageBox.Show("You must enter a Particular to Continue")
            Exit Sub
        End If
        Dim debt As String = InputBox("Please Enter Debit Amount")
        If debt = " " Or debt = "" Then
            MessageBox.Show("You must enter a Amount to Continue")
            Exit Sub
        ElseIf Not IsNumeric(debt) Then
            MessageBox.Show("You must enter a Numeric Value to Continue")
            Exit Sub
        End If
        Dim r As Integer
        r = dgw.Rows.Count
        dgw.Rows.Add()
        dgw.Item(0, r).Value = parts
        dgw.Item(1, r).Value = debt
        dgw.Item(2, r).Value = debt
        TotDebit = TotDebit + debt
        totAmount = totAmount + debt
        lblTotDebit.Text = TotDebit.ToString("n2")
        lblTotAmount.Text = totAmount.ToString("n2")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each row As DataGridViewRow In dgw.SelectedRows
            totAmount = lblTotAmount.Text - dgw.CurrentRow.Cells(2).Value
            TotDebit = lblTotDebit.Text - dgw.CurrentRow.Cells(1).Value
            dgw.Rows.Remove(row)
            lblTotDebit.Text = TotDebit.ToString("n2")
            lblTotAmount.Text = totAmount.ToString("n2")
        Next
    End Sub

    Private Sub frmPettyCashVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generatePCVNo()
        autoCompletePayee()

        autoCompleteSection()
        autoCompleteDepartment()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        save()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRefNo.TextChanged

    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        mode = "PCV"
    End Sub
End Class