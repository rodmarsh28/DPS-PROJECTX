Public Class frmAddEmployees
    Dim lastname As String
    Dim firstname As String
    Dim middlename As String
    Sub clear()
        txtemID.Text = ""
        txtln.Text = ""
        txtFn.Text = ""
        txtMn.Text = ""
        txtAdd.Text = ""
        txtCN.Text = ""
        txtBD.Text = Now
        txtGender.Text = ""
        txtCS.Text = ""
        txtHomeNo.Text = ""
        txtPos.Text = ""
        txtRate.Text = ""
        txtPM.Text = ""
        txtDH.Text = Now
        txtStatus.Text = ""
        txtSSSNo.Text = ""
        txtTinNo.Text = ""
        txtPINo.Text = ""
        txtPHNo.Text = ""
        txtreligion.Text = ""
        txtGradeLevel.Text = ""
        txtDept.Text = ""
        txtDivision.Text = ""
        cmbDedB.Text = ""
        txtSpouseLN.Text = ""
        txtSpouseFN.Text = ""
        txtSpouseMN.Text = ""
        lblAge.Text = "0 Years Old"
        ym.Text = "0 Years and 0 Months"
        dgws.Rows.Clear()

    End Sub
    Sub generateEmployeeID()
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
                .CommandText = "SELECT * from tblEmployeesInfo order by employeeID DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 7, Len(OleDBDR(0)))
                txtemID.Text = "EN-" & Format(Val(StrID) + 1, "00000")
            Else
                txtemID.Text = "EN-00001"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub save()
        If MsgBox("ARE YOU SURE YOU WANT TO ADD THIS EMPLOYEE INFORMATIONS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = "INSERT INTO tblEmployeesInfo VALUES('" & txtemID.Text & _
                        "','" & txtln.Text & _
                        "','" & txtFn.Text & _
                        "','" & txtMn.Text & _
                        "','" & txtAdd.Text & _
                        "','" & txtCN.Text & _
                        "','" & txtHomeNo.Text & _
                        "','" & txtreligion.Text & _
                        "','" & txtGender.Text & _
                        "','" & txtBD.Value.ToString("MM/dd/yyyy") & _
                        "','" & txtCS.Text & _
                        "','" & txtDept.Text & _
                        "','" & txtDeptID.Text & _
                        "','" & txtPos.Text & _
                        "','" & txtRate.Text & _
                        "','" & txtGradeLevel.Text & _
                        "','" & txtPM.Text & _
                        "','" & txtDH.Value.ToString("MM/dd/yyyy") & _
                        "','" & txtStatus.Text & _
                        "','" & txtField.Text & _
                        "','" & txtSSSNo.Text & _
                        "','" & txtTinNo.Text & _
                        "','" & txtPINo.Text & _
                        "','" & txtPHNo.Text & _
                        "','" & sssDedDate.Text & _
                        "','" & tinDedDate.Text & _
                        "','" & piDedDate.Text & _
                        "','" & phDedDate.Text & _
                        "','" & cmbDedB.Text & "','Employees Info Added " & Now.ToString("MM/dd/yyyy") & "' )"
                    .ExecuteNonQuery()
                End With
                If txtSpouseLN.Text = "" And txtSpouseFN.Text = "" And txtSpouseMN.Text = "" Then
                Else
                    saveSpouse()
                End If
                If dgws.RowCount = "0" Then
                Else
                    dgwItemProcess()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Employee Information Added !", MsgBoxStyle.Information, "SUCCESS")
                clear()
                Me.Close()
            End Try
        End If
    End Sub

    Sub saveSpouse()
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
                .CommandText = "INSERT INTO tblSpouseInfo VALUES('" & txtemID.Text & _
                    "','" & txtSpouseLN.Text & _
                    "','" & txtSpouseFN.Text & _
                    "','" & txtSpouseMN.Text & "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub saveChildren()
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
                .CommandText = "INSERT INTO tblChildrenInfo VALUES('" & txtemID.Text & _
                    "','" & lastname & _
                    "','" & firstname & _
                    "','" & middlename & "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub UpdateEmployee()
        If MsgBox("ARE YOU SURE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
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
                    .CommandText = "update tblEmployeesInfo SET lastname = '" & txtln.Text & _
                                    "',firstname = '" & txtFn.Text & _
                                    "',middlename = '" & txtMn.Text & _
                                    "',address = '" & txtAdd.Text & _
                                    "',contactNo = '" & txtCN.Text & _
                                    "',homeNo = '" & txtHomeNo.Text & _
                                    "',religion = '" & txtreligion.Text & _
                                    "',gender = '" & txtGender.Text & _
                                    "',birthdate = '" & txtBD.Value.ToString("MM/dd/yyyy") & _
                                    "',civilstatus = '" & txtCS.Text & _
                                    "',department = '" & txtDept.Text & _
                                    "',division = '" & txtDivision.Text & _
                                    "',position = '" & txtPos.Text & _
                                    "',rate = '" & txtRate.Text & _
                                    "',grade = '" & txtGradeLevel.Text & _
                                    "',payMethod = '" & txtPM.Text & _
                                    "',dateHired = '" & txtDH.Value.ToString("MM/dd/yyyy") & _
                                    "',workingStatus = '" & txtStatus.Text & _
                                    "',field = '" & txtField.Text & _
                                    "',sssno = '" & txtSSSNo.Text & _
                                    "',tinno = '" & txtTinNo.Text & _
                                    "',pino = '" & txtPINo.Text & _
                                    "',phno = '" & txtPHNo.Text & _
                                    "',allowbenefitsdeduction = '" & cmbDedB.Text & _
                                    "',remarks = 'Updated Last " & Now.ToString("MM/dd/yyyy") & "' " & _
                                    "where employeeID = '" & txtemID.Text & "'"
                    .ExecuteNonQuery()
                End With
                updateSpouseInfo()
                deleteExistingChildrenInfo()
                dgwItemProcess()
                MsgBox("EMPLOYEES INFORMATION UPDATED", MsgBoxStyle.Information, "SUCCESS")
                Me.Close()
                frmMasterList.viewEmployees()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If
    End Sub
    Sub updateSpouseInfo()
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
                .CommandText = "DELETE FROM tblSpouseInfo  where employeeID = '" & txtemID.Text & "' " & _
                                "INSERT INTO tblSpouseInfo VALUES('" & txtemID.Text & _
                                "','" & txtSpouseLN.Text & _
                                "','" & txtSpouseFN.Text & _
                                "','" & txtSpouseMN.Text & "')"

                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Sub deleteExistingChildrenInfo()
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
                .CommandText = "DELETE FROM tblChildrenInfo where employeeID = '" & txtemID.Text & "'"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Sub dgwItemProcess()
        Dim row1 As Integer
        Dim col As Integer
        col = 0
        row1 = dgws.RowCount
        While col < row1
            lastname = dgws.Item(0, col).Value
            firstname = dgws.Item(1, col).Value
            middlename = dgws.Item(2, col).Value
            saveChildren()
            col = col + 1

        End While
    End Sub

    Private Sub frmAddEmployees_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        clear()
    End Sub


    Private Sub frmAddEmployees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cmbAdd.Text = "Add" Then
            generateEmployeeID()
        End If
    End Sub

    Private Sub btnAddChildren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddChildren.Click
        Dim ln As String = InputBox("Last Name", "Please Fill the Box")
        If ln = " " Or ln = "" Then
            MessageBox.Show("You must enter lastname")
            Exit Sub
        End If
        Dim fn As String = InputBox("First Name", "Please Fill the Box")
        If fn = " " Or fn = "" Then
            MessageBox.Show("You must enter firstname")
            Exit Sub
        End If
        Dim mn As String = InputBox("Middle Name", "Please Fill the Box")
        If mn = " " Or mn = "" Then
            MessageBox.Show("You must enter middlename")
            Exit Sub
        End If
        Dim rows As Integer = dgws.RowCount
        dgws.Rows.Add()
        dgws.Item(0, rows).Value = ln
        dgws.Item(1, rows).Value = fn
        dgws.Item(2, rows).Value = mn
        dgws.ClearSelection()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For Each row As DataGridViewRow In dgws.SelectedRows
            dgws.Rows.Remove(row)
        Next
    End Sub

    Private Sub cmbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAdd.Click
        If cmbAdd.Text = "Add" Then
            save()
        ElseIf cmbAdd.Text = "Update" Then
            UpdateEmployee()
        End If

    End Sub

    Private Sub txtDH_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDH.ValueChanged
        Try
            Dim months As Integer = DateDiff(DateInterval.Month, txtDH.Value, Now)
            Dim getYear As Double = months / 12
            If getYear >= 1 Then
                months = months Mod 12
                If getYear.ToString("0.00").Length = "4" Then
                    ym.Text = getYear.ToString.Substring(0, 1) & " Years and " & months & " Months"
                ElseIf getYear.ToString("0.00").Length = "5" Then
                    ym.Text = getYear.ToString.Substring(0, 2) & " Years and " & months & " Months"
                End If
            Else
                ym.Text = "0 Years and " & months & " Months"

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCancel.Click
        Me.Close()
    End Sub

    Private Sub txtBD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBD.ValueChanged
        Dim days As Integer = DateDiff(DateInterval.Day, txtBD.Value, Now)
        Dim getyear As Double = days / 365
        If getyear.ToString("0.00").Length = "4" Then
            lblAge.Text = getyear.ToString.Substring(0, 1) & " Years Old"
        ElseIf getyear.ToString("0.00").Length = "5" Then
            lblAge.Text = getyear.ToString.Substring(0, 2) & " Years Old"
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DepartmentList.successClicked = False
        DepartmentList.get_department_List()
        DepartmentList.ShowDialog()
        If DepartmentList.successClicked = True Then
            txtDeptID.Text = DepartmentList.LV.SelectedItems(0).SubItems(0).Text
            txtDept.Text = DepartmentList.LV.SelectedItems(0).SubItems(1).Text
            DepartmentList.successClicked = False
        End If
    End Sub
End Class