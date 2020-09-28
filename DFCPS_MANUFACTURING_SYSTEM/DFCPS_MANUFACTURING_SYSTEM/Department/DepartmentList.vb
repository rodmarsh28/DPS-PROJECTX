Imports System.Data.SqlClient


Public Class DepartmentList
    Dim dt As New DataTable
    Public formMode As String
    Dim rowIndex As Integer = 0
    Public mode As String
    Public successClicked As Boolean

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        DepartmentProfile.mode = "Add"
        DepartmentProfile.ShowDialog()
    End Sub

 
    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If GetActiveWindow = Me.Handle Then
        '    get_department_List()
        'End If
    End Sub

    Sub get_department_List()
        Try
            checkConn()
            Dim cmd As New SqlCommand("get_dept_list_func", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@searchValue", SqlDbType.VarChar).Value = txtSearch.Text
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            LV.Items.Clear()
            For Each row As DataRow In dt.Rows
                Dim lst As ListViewItem
                lst = LV.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
                For i As Integer = 1 To dt.Columns.Count - 1
                    lst.SubItems.Add(If(row(i) IsNot Nothing, row(i).ToString, ""))
                Next
            Next
            If rowIndex < LV.Items.Count Then
                LV.Items(rowIndex).Selected = True
            End If
            lblItemsCount.Text = Format(LV.Items.Count, "N0")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub LV_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles LV.ItemSelectionChanged
        Try
            rowIndex = LV.FocusedItem.Index
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LV_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV.MouseDoubleClick
        If mode = "Item Requisition" Then
            Try
                frmItemRequisition.departmentID = LV.FocusedItem.SubItems(0).Text
                frmItemRequisition.txtDepartment.Text = LV.FocusedItem.SubItems(1).Text

            Catch ex As Exception
            End Try
        End If
        successClicked = True
        Me.Close()
    End Sub



    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        get_department_List()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        DepartmentProfile.mode = "Edit"
        DepartmentProfile.ShowDialog()
    End Sub
End Class