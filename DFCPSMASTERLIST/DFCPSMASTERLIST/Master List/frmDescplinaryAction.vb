Public Class frmDescplinaryAction
    Dim infractionID As Integer
    Dim occurrenceTimes As Integer
    Dim specOffID As Integer
    Dim offenseID As Integer
    Sub generateDescActionNo()
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
                .CommandText = "SELECT * from tblDesciplinaryAction order by descActionNo DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 7, Len(OleDBDR(0)))
                txtDescActNo.Text = "DSA-" & Format(Val(StrID) + 1, "00000")
            Else
                txtDescActNo.Text = "DSA-00001"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub save()
        If MsgBox("ARE YOU SURE?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Dim mc As New master_class
            mc.transNo = txtDescActNo.Text
            mc.datetrans = dtpDate.Value
            mc.empID = txtEmp.Text
            mc.infractionID = infractionID
            mc.occurrenceTimes = occurrenceTimes
            mc.specOffID = specOffID
            mc.offenseID = offenseID
            mc.dateOfOffense = dtpDateOfOffense.Value
            mc.writenExplanation = txtWrittenExp.Text
            mc.witness = txtWitness.Text
            mc.insert_Disciplinary_Action()
        End If
    End Sub
    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            save()
            MsgBox("Disciplinary Action Report Recorded", MsgBoxStyle.Information, "System Information")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub txtDetailsOfIncident_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub frmDescplinaryAction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateDescActionNo()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmInfraction_offense_list
        frm.command = "infraction"
        frm.searchValue = ""
        frm.ShowDialog()
        If frm.isOK = True Then
            infractionID = frm.dgv.CurrentRow.Cells(0).Value
            txtInfractions.Text = frm.dgv.CurrentRow.Cells(1).Value
            specOffID = frm.dgv.CurrentRow.Cells(2).Value
            txtSpecOff.Text = frm.dgv.CurrentRow.Cells(3).Value
            offenseID = frm.dgv.CurrentRow.Cells(4).Value
            frm.isOK = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmInfraction_offense_list
        frm.command = "offense"
        frm.searchValue = offenseID
        frm.ShowDialog()
        If frm.isOK = True Then
            offenseID = frm.dgv.CurrentRow.Cells(0).Value
            txtOccurrence.Text = frm.dgv.CurrentRow.Cells(2).Value
            occurrenceTimes = frm.dgv.CurrentRow.Cells(2).Value
            txtCorrectiveActions.Text = frm.dgv.CurrentRow.Cells(3).Value
            frm.isOK = False
        End If
    End Sub

    Private Sub txtEmployeeID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim frm As New frmMasterList
            frm.mode = "Selection"
            frm.ShowDialog()
            If frm.isOk = True Then
                txtEmp.Text = frm.dgw.CurrentRow.Cells(0).Value
                frm.isOk = False
            End If
            Dim mc As New master_class
            mc.command = ""
            mc.searchValue = txtEmp.Text
            mc.get_emp_info()
            txtName.Text = mc.dtable.Rows(0).Item("lastname").ToString & ", " & mc.dtable.Rows(0).Item("firstname").ToString & " " & mc.dtable.Rows(0).Item("middlename").ToString
            txtPos.Text = mc.dtable.Rows(0).Item("position").ToString
            txtDept.Text = mc.dtable.Rows(0).Item("department").ToString
            txtDiv.Text = mc.dtable.Rows(0).Item("division").ToString
            dtpDH.Value = mc.dtable.Rows(0).Item("datehired").ToString
        Catch ex As Exception
        End Try
    End Sub
End Class