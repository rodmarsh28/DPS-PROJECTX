Public Class frmSelectforInspection
    Sub searchRollNoForInspection()
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
                .CommandText = "SELECT dbo.tblCSRTR.CSRNO,dbo.tblCSRTR.CSRITEMNO,dbo.tblCSRTR.rollNo, dbo.tblDoffed.LOOMSNO, dbo.tblDoffed.mesh, dbo.tblDoffed.width, " & _
                    "dbo.tblCSRTR.outputQty,dbo.tblCSRTR.badLength FROM dbo.tblCSRTR INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                    "where dbo.tblCSRTR.status = 'PENDING FOR INSPECTION' and tblDoffed.rollNo like '%" & txtSearch.Text & "%' or " & _
                    "tblCSRTR.status = 'PENDING FOR INSPECTION' and tblDoffed.mesh like '%" & txtSearch.Text & "%' or " & _
                    "tblCSRTR.status = 'PENDING FOR INSPECTION' and tblCSRTR.CSRNO like '%" & txtSearch.Text & "%' or " & _
                    "tblCSRTR.status = 'PENDING FOR INSPECTION' and tblDoffed.width like '%" & txtSearch.Text & "%' " & _
                    "order by tblCSRTR.CSRNO asc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    Dim BAGLENGTH As Integer
                    BAGLENGTH = OleDBDR.Item(7)
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = OleDBDR.Item(0)
                    dgv.Item(1, c).Value = OleDBDR.Item(1)
                    dgv.Item(2, c).Value = OleDBDR.Item(2)
                    dgv.Item(3, c).Value = OleDBDR.Item(3)
                    dgv.Item(4, c).Value = OleDBDR.Item(4)
                    dgv.Item(5, c).Value = OleDBDR.Item(5)
                    dgv.Item(6, c).Value = OleDBDR.Item(6)
                    dgv.Item(7, c).Value = BAGLENGTH
                    c = c + 1

                End While
            End If
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub getRollNoForInspection()
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
                .CommandText = "SELECT dbo.tblCSRTR.CSRNO,dbo.tblCSRTR.CSRITEMNO,dbo.tblCSRTR.rollNo, dbo.tblDoffed.LOOMSNO, dbo.tblDoffed.mesh, dbo.tblDoffed.width, " & _
                    "dbo.tblCSRTR.outputQty,dbo.tblCSRTR.badLength FROM dbo.tblCSRTR INNER JOIN dbo.tblDoffed ON dbo.tblDoffed.rollNo = dbo.tblCSRTR.rollNo " & _
                    "where dbo.tblCSRTR.status = 'PENDING FOR INSPECTION' order by tblCSRTR.CSRNO asc"

            End With
            OleDBDR = OleDBC.ExecuteReader
            dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    Dim BAGLENGTH As Integer
                    BAGLENGTH = OleDBDR.Item(7) - 3
                    dgv.Rows.Add()
                    dgv.Item(0, c).Value = OleDBDR.Item(0)
                    dgv.Item(1, c).Value = OleDBDR.Item(1)
                    dgv.Item(2, c).Value = OleDBDR.Item(2)
                    dgv.Item(3, c).Value = OleDBDR.Item(3)
                    dgv.Item(4, c).Value = OleDBDR.Item(4)
                    dgv.Item(5, c).Value = OleDBDR.Item(5)
                    dgv.Item(6, c).Value = OleDBDR.Item(6)
                    dgv.Item(7, c).Value = BAGLENGTH
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
        frmPDIR.txtRollNo.Text = dgv.CurrentRow.Cells(2).Value
        frmPDIR.txtLoomNo.Text = dgv.CurrentRow.Cells(3).Value
        frmPDIR.txtMesh.Text = dgv.CurrentRow.Cells(4).Value
        frmPDIR.txtInputQTY.Text = dgv.CurrentRow.Cells(6).Value
        frmPDIR.txtGrossQty.Text = dgv.CurrentRow.Cells(6).Value
        frmPDIR.txtBadlength.Text = dgv.CurrentRow.Cells(7).Value
        frmPDIR.CSRITEMNO = dgv.CurrentRow.Cells(1).Value
        frmPDIR.txtNetQty.Text = "0"
        Me.Close()

    End Sub

    Private Sub frmSelectforInspection_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub frmSelectforInspection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getRollNoForInspection()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        searchRollNoForInspection()
    End Sub
End Class