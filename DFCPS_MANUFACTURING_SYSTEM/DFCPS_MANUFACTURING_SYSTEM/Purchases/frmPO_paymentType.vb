Imports System.Data.SqlClient

Public Class frmPO_paymentType
    Dim paymentNo
   
    Sub generatePaymentNo()
        Dim strID As String
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
                .CommandText = "SELECT paymentNo from tblPaymentsReceived order by paymentNo DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                strID = OleDBDR.Item(0)
                paymentNo = Format(Val(strID) + 1, "00000")
            Else
                paymentNo = "00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Are You Sure ?", MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.Yes Then
            If cmbPaymenType.SelectedIndex <> -1 Then
                frmPurchases.RECORDPURCHASES()
            End If

        End If
    End Sub

    Private Sub frmPO_paymentType_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub cmbPaymenType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaymenType.SelectedIndexChanged
        If cmbPaymenType.Text = "CREDIT" Then
            txtChequeNo.Enabled = False
        ElseIf cmbPaymenType.Text = "CREDIT - PDC" Then
            txtChequeNo.Enabled = True
        End If
    End Sub
End Class