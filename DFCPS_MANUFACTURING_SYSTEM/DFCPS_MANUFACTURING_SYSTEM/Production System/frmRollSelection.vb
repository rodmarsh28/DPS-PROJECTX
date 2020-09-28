Public Class frmRollSelection
    Public mode
    Sub searchRollNo()
        Dim c As Integer = 0
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
                .CommandText = "SELECT dbo.tblDoffed.rollNo,dbo.tblDoffed.LOOMSNO,dbo.tblDoffed.mesh,dbo.tblDoffed.color,dbo.tblDoffed.width,dbo.tblDoffed.length,dbo.tblDoffed.denier " & _
                    "FROM dbo.tblDoffed " & _
                    "where length <> '0' and rollNo like '%" & txtSearch.Text & "%' AND status = 'Available' or " & _
                    "length <> '0' and mesh like '%" & txtSearch.Text & "%' AND status = 'Available' or " & _
                    "length <> '0' and width like '%" & txtSearch.Text & "%' AND status = 'Available' or " & _
                    "length <> '0' and length like '%" & txtSearch.Text & "%' AND status = 'Available' or " & _
                    "length <> '0' and denier like '%" & txtSearch.Text & "%' AND status = 'Available' " & _
                    "order by rollno desc "

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = OleDBDR.Item(0)
                    dgv.Item(1, c).Value = OleDBDR.Item(1)
                    dgv.Item(2, c).Value = OleDBDR.Item(2)
                    dgv.Item(3, c).Value = OleDBDR.Item(3)
                    dgv.Item(4, c).Value = OleDBDR.Item(4)
                    dgv.Item(5, c).Value = OleDBDR.Item(5)
                    c = c + 1

                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub searchAllRollNo()
        Dim c As Integer = 0
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
                .CommandText = "SELECT dbo.tblDoffed.rollNo,dbo.tblDoffed.LOOMSNO,dbo.tblDoffed.mesh,dbo.tblDoffed.color,dbo.tblDoffed.width,dbo.tblDoffed.length,dbo.tblDoffed.denier " & _
                    "FROM dbo.tblDoffed " & _
                    "where rollNo like '%" & txtSearch.Text & "%'  or " & _
                    "mesh like '%" & txtSearch.Text & "%' or " & _
                    "width like '%" & txtSearch.Text & "%'  or " & _
                    "length like '%" & txtSearch.Text & "%'  or " & _
                    " denier like '%" & txtSearch.Text & "%'  " & _
                    "order by rollno desc "

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = OleDBDR.Item(0)
                    dgv.Item(1, c).Value = OleDBDR.Item(1)
                    dgv.Item(2, c).Value = OleDBDR.Item(2)
                    dgv.Item(3, c).Value = OleDBDR.Item(3)
                    dgv.Item(4, c).Value = OleDBDR.Item(4)
                    dgv.Item(5, c).Value = OleDBDR.Item(5)
                    c = c + 1

                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub getRollNo()
        Dim c As Integer = 0
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
                .CommandText = "SELECT dbo.tblDoffed.rollNo,dbo.tblDoffed.LOOMSNO,dbo.tblDoffed.mesh,dbo.tblDoffed.width,dbo.tblDoffed.color,dbo.tblDoffed.length,dbo.tblDoffed.denier " & _
                    "FROM dbo.tblDoffed " & _
                    "where length <> '0' AND status = 'Available' order by rollno desc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = OleDBDR.Item(0)
                    dgv.Item(1, c).Value = OleDBDR.Item(1)
                    dgv.Item(2, c).Value = OleDBDR.Item(2)
                    dgv.Item(3, c).Value = OleDBDR.Item(3)
                    dgv.Item(4, c).Value = OleDBDR.Item(4)
                    dgv.Item(5, c).Value = OleDBDR.Item(5)
                    c = c + 1

                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        If mode = "PRINTING" Then
            frmPrinting.txtRollno1.Text = dgv.CurrentRow.Cells(0).Value
            frmPrinting.txtLoomno.Text = dgv.CurrentRow.Cells(1).Value
            frmPrinting.txtRollMesh.Text = dgv.CurrentRow.Cells(2).Value
            frmPrinting.txtRollWidth.Text = dgv.CurrentRow.Cells(4).Value
            frmPrinting.cmbRollColor.Text = dgv.CurrentRow.Cells(3).Value

        ElseIf mode = "CUTTING" Then
            frmPDORCutting.txtRollNo.Text = dgv.CurrentRow.Cells(0).Value
            frmPDORCutting.txtLoomNo.Text = dgv.CurrentRow.Cells(1).Value
            frmPDORCutting.txtMesh.Text = dgv.CurrentRow.Cells(2).Value
            frmPDORCutting.txtInputLength.Text = dgv.CurrentRow.Cells(5).Value
            frmPDORCutting.actualLength = dgv.CurrentRow.Cells(5).Value
        End If
        Me.Close()
    End Sub

    Private Sub frmRollSelection_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub frmRollSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If mode = "PRINTING" Then
            searchAllRollNo()
        ElseIf mode = "CUTTING" Then
            searchRollNo()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If mode = "PRINTING" Then
            searchAllRollNo()
        ElseIf mode = "CUTTING" Then
            searchRollNo()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class