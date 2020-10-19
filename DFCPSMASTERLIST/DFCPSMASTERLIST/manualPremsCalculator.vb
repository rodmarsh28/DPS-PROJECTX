Public Class manualPremsCalculator
    Dim totalBP As Double
    Dim philhealthER As Double
    Dim sssER As Double
    Dim piER As Double
    Dim phno As Boolean = True
    Dim sssNo As Boolean = True
    Dim piNo As Boolean = True
    Sub calculate()
        Try

       
        totalBP = txtBP.Text
        If phno = True Then
            If totalBP <= 10000 Then
                txtPHEE.Text = "137.50"
            ElseIf totalBP <= 39999 Then
                txtPHEE.Text = Format(totalBP * 0.0275 / 2, "0.00")

            Else
                txtPHEE.Text = "550.00"
            End If
        Else
            txtPHEE.Text = "0.00"
        End If
        txtPHER.Text = txtPHEE.Text
        If sssNo = True Then
            If totalBP <= 1249.99 Then
                txtsss.Text = 36.3
                sssER = 83.7
            ElseIf totalBP <= 1749.99 Then
                txtsss.Text = 54.5
                sssER = 120.5
            ElseIf totalBP <= 2249.99 Then
                txtsss.Text = 72.7
                sssER = 157.3
            ElseIf totalBP <= 2749.99 Then
                txtsss.Text = 90.8
                sssER = 194.2
            ElseIf totalBP <= 3249.99 Then
                txtsss.Text = 109
                sssER = 231
            ElseIf totalBP <= 3749.99 Then
                txtsss.Text = 127.2
                sssER = 267.8
            ElseIf totalBP <= 4249.99 Then
                txtsss.Text = 145.3
                sssER = 304.7
            ElseIf totalBP <= 4749.99 Then
                txtsss.Text = 163.5
                sssER = 341.5
            ElseIf totalBP <= 5249.99 Then
                txtsss.Text = 181.7
                sssER = 378.3
            ElseIf totalBP <= 5749.99 Then
                txtsss.Text = 199.8
                sssER = 415.2
            ElseIf totalBP <= 6249.99 Then
                txtsss.Text = 218
                sssER = 452
            ElseIf totalBP <= 6749.99 Then
                txtsss.Text = 236.2
                sssER = 488.8
            ElseIf totalBP <= 7249.99 Then
                txtsss.Text = 254.3
                sssER = 525.7
            ElseIf totalBP <= 7749.99 Then
                txtsss.Text = 272.5
                sssER = 562.5
            ElseIf totalBP <= 8249.99 Then
                txtsss.Text = 290.7
                sssER = 599.3
            ElseIf totalBP <= 8749.99 Then
                txtsss.Text = 308.8
                sssER = 636.2
            ElseIf totalBP <= 9249.99 Then
                txtsss.Text = 327
                sssER = 673
            ElseIf totalBP <= 9749.99 Then
                txtsss.Text = 345.2
                sssER = 709.8
            ElseIf totalBP <= 10249.99 Then
                txtsss.Text = 363.3
                sssER = 746.7
            ElseIf totalBP <= 10749.99 Then
                txtsss.Text = 381.5
                sssER = 783.5
            ElseIf totalBP <= 11249.99 Then
                txtsss.Text = 399.7
                sssER = 820.3
            ElseIf totalBP <= 11749.99 Then
                txtsss.Text = 417.8
                sssER = 857.2
            ElseIf totalBP <= 12249.99 Then
                txtsss.Text = 436
                sssER = 894
            ElseIf totalBP <= 12749.99 Then
                txtsss.Text = 454.2
                sssER = 930.8
            ElseIf totalBP <= 13249.99 Then
                txtsss.Text = 472.3
                sssER = 967.7
            ElseIf totalBP <= 13749.99 Then
                txtsss.Text = 490.5
                sssER = 1004.5
            ElseIf totalBP <= 14249.99 Then
                txtsss.Text = 508.7
                sssER = 1041.3
            ElseIf totalBP <= 14749.99 Then
                txtsss.Text = 526.8
                sssER = 1078.2
            ElseIf totalBP <= 15249.99 Then
                txtsss.Text = 545
                sssER = 1135
            ElseIf totalBP <= 15749.99 Then
                txtsss.Text = 563.2
                sssER = 1171.8
            ElseIf totalBP <= 16249.99 Or totalBP >= 16249.99 Then
                txtsss.Text = 581.3
                sssER = 1208.7
            End If

        Else
            txtsss.Text = "0.00"
            sssER = 0.0
        End If
        txtssser.Text = sssER
        If piNo = True Then

            txtPIEE.Text = 100.0
            txtPIER.Text = 100.0

        Else
            txtPIEE.Text = "0.00"
            txtPIER.Text = 0.0
        End If
        Catch ex As Exception
            MsgBox("Basic pay input Error", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        calculate()
    End Sub

    Private Sub manualPremsCalculator_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            calculate()
        End If
    End Sub

    Private Sub manualPremsCalculator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class