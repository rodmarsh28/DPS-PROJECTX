Public Class CardProfile
    Public mode
    Public SeriesNo
    Sub ItemType()
        If cmbCardType.Text = "Customer" Then
            SeriesNo = "CUS-"
        ElseIf cmbCardType.Text = "Supplier" Then
            SeriesNo = "SUP-"
        ElseIf cmbCardType.Text = "Employee" Then
            SeriesNo = "EN-"
        End If
    End Sub
    Sub disposeForm()
        chkboxInactiveCard.Checked = False
        chkAllowCredit.Checked = False
        txtCardNo.Text = ""
        txtCardName.Text = ""
        txtCardAddress.Text = ""
        txtCardCN.Text = ""
        txtCardCreditLimit.Text = ""
        cmbCardType.SelectedIndex = -1
        cmbDesignation.SelectedIndex = -1

    End Sub
    Sub generateCardNo()
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
                .CommandText = "SELECT cardID from tblCardsProfile  where cardID LIKE '" & SeriesNo & "%' order by cardID DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                strID = OleDBDR.Item(0).Substring(OleDBDR.Item(0).Length - 5)
                txtCardNo.Text = SeriesNo & Format(Val(strID) + 1, "00000")
            Else
                txtCardNo.Text = SeriesNo & "00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub SAVE()
        If MsgBox("ARE YOU SURE YOU WANT TO SAVE CARD PROFILE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Try
                If conn.State = ConnectionState.Open Then
                    OleDBC.Dispose()
                    conn.Close()
                End If
                If conn.State <> ConnectionState.Open Then
                    ConnectDatabase()
                End If
                Dim allowCredit As Integer
                Dim status As String
                If chkAllowCredit.Checked = True Then
                    allowCredit = "1"
                Else
                    allowCredit = "0"
                End If
                If chkboxInactiveCard.Checked = True Then
                    status = "INACTIVE"
                Else
                    status = "ACTIVE"
                End If
                With OleDBC
                    .Connection = conn
                    .CommandText = "INSERT INTO tblCardsProfile VALUES('" & txtCardNo.Text & _
                        "','" & txtCardName.Text & _
                        "','" & txtCardAddress.Text & _
                        "','" & txtCardCN.Text & _
                        "','" & cmbCardType.Text & _
                        "','" & cmbDesignation.Text & _
                        "','" & allowCredit & _
                        "','" & txtCardCreditLimit.Text & _
                        "','" & status & "')"
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Profile Saved !", MsgBoxStyle.Information, "Success")
                disposeForm()
                'Me.Close()
            End Try
        End If
    End Sub
    Sub UPDATECARD()
        If MsgBox("ARE YOU SURE YOU WANT TO SAVE CARD PROFILE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Try
                If conn.State = ConnectionState.Open Then
                    OleDBC.Dispose()
                    conn.Close()
                End If
                If conn.State <> ConnectionState.Open Then
                    ConnectDatabase()
                End If
                Dim allowCredit As Integer
                Dim status As String
                If chkAllowCredit.Checked = True Then
                    allowCredit = "1"
                Else
                    allowCredit = "0"
                End If
                If chkboxInactiveCard.Checked = True Then
                    status = "INACTIVE"
                Else
                    status = "ACTIVE"
                End If
                With OleDBC
                    .Connection = conn
                    .CommandText = "UPDATE tblCardsProfile SET CARDNAME = '" & txtCardName.Text & _
                        "',CARDADDRESS = '" & txtCardAddress.Text & _
                        "',CARDCN = '" & txtCardCN.Text & _
                        "',CARDTYPE = '" & cmbCardType.Text & _
                        "',DESIGNATION = '" & cmbDesignation.Text & _
                        "',ALLOWCREDIT = '" & allowCredit & _
                        "',CREDITLIMIT = '" & txtCardCreditLimit.Text & _
                        "',CARDSTATUS = '" & status & "' where cardID = '" & txtCardNo.Text & "'"
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Profile Saved !", MsgBoxStyle.Information, "Success")
                disposeForm()
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub cmbCardType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCardType.SelectedIndexChanged
        ItemType()
        generateCardNo()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cmbCardType.Text = "" Then
            Exit Sub
        End If
        If btnSave.Text = "Update" Then
            UPDATECARD()
        Else
            SAVE()
        End If
    End Sub

    Private Sub txtCardCreditLimit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCardCreditLimit.TextChanged
        Try
            If txtCardCreditLimit.Text = "" Then
                txtCardCreditLimit.Text = "0.00"
                txtCardCreditLimit.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class