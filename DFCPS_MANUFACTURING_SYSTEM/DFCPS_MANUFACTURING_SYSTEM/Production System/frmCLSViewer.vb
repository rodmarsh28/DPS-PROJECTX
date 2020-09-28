Public Class frmCLSViewer
    Dim maxCSRDATE As DateTime
    Dim clsDate As DateTime
    Sub historyviewer()
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
                .CommandText = "SELECT dbo.tblLoomSection.CLSNO,dbo.tblLoomSection.DATEFROM,dbo.tblLoomSection.LOOMSCOUNT," & _
                    "dbo.tblLoomSection.TOTMETERSPROD,dbo.tblLoomSection.TOTEFF FROM dbo.tblLoomSection ORDER BY CLSNO DESC"

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
                    c = c + 1

                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub frmCLSViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        historyviewer()
        dgv.ClearSelection()
        getMaxCLSNo()
    End Sub
    Sub updateForm()
        Dim c As Integer = 0
        mode = "CLS-Update"
        frmCircularLoomsSec.getLoomsNo()
        frmCircularLoomsSec.generateRollNo()
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
                .CommandText = "SELECT dbo.tblLoomSection.CLSNO,dbo.tblLoomSection.DATEFROM,dbo.tblLoomSection.DATETO,dbo.tblLoomSection.COSTUMER," & _
                    "dbo.tblLoomSection.MAINTENANCE,dbo.tblLoomSection.VISOR,dbo.tblLoomSectionTR.LOOMSNO,dbo.tblLoomSectionTR.MESH,dbo.tblLoomSectionTR.WIDTH," & _
                    "dbo.tblLoomSectionTR.RPM,dbo.tblLoomSectionTR.BEGINNING,dbo.tblLoomSectieronTR.ENDING,dbo.tblLoomSectionTR.rollNo,dbo.tblLoomSectionTR.DOFFEDL," & _
                    "dbo.tblLoomSectionTR.DOFFEDWT,dbo.tblLoomSectionTR.COLOR,dbo.tblLoomSectionTR.PRODUCTION,dbo.tblLoomSectionTR.EFFIENCY,dbo.tblLoomSectionTR.BIONO,dbo.tblLoomSectionTR.WASTE,dbo.tblLoomSectionTR.REMARKS " & _
                    "FROM dbo.tblLoomSection INNER JOIN dbo.tblLoomSectionTR ON dbo.tblLoomSection.CLSNO = dbo.tblLoomSectionTR.CLSNO " & _
                    "where dbo.tblLoomSection.CLSNO = '" & dgv.CurrentRow.Cells(0).Value & "'"

            End With
            OleDBDR = OleDBC.ExecuteReader
            frmCircularLoomsSec.dgv.Rows.Clear()
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    frmCircularLoomsSec.txtCLSNO.Text = OleDBDR.Item(0)
                    frmCircularLoomsSec.dtpDFrom.Value = OleDBDR.Item(1)
                    frmCircularLoomsSec.dtpDto.Value = OleDBDR.Item(2)
                    frmCircularLoomsSec.txtCos.Text = OleDBDR.Item(3)
                    frmCircularLoomsSec.txtMTN.Text = OleDBDR.Item(4)
                    frmCircularLoomsSec.txtVisor.Text = OleDBDR.Item(5)
                    frmCircularLoomsSec.dgv.Rows.Add()
                    frmCircularLoomsSec.dgv.Item(0, c).Value = OleDBDR.Item(6)
                    frmCircularLoomsSec.dgv.Item(1, c).Value = OleDBDR.Item(7)
                    frmCircularLoomsSec.dgv.Item(2, c).Value = OleDBDR.Item(8)
                    frmCircularLoomsSec.dgv.Item(3, c).Value = OleDBDR.Item(9)
                    frmCircularLoomsSec.dgv.Item(4, c).Value = OleDBDR.Item(10)
                    frmCircularLoomsSec.dgv.Item(5, c).Value = OleDBDR.Item(11)
                    frmCircularLoomsSec.dgv.Item(6, c).Value = OleDBDR.Item(12)
                    frmCircularLoomsSec.dgv.Item(7, c).Value = OleDBDR.Item(13)
                    frmCircularLoomsSec.dgv.Item(8, c).Value = OleDBDR.Item(14)
                    frmCircularLoomsSec.dgv.Item(9, c).Value = OleDBDR.Item(15)
                    frmCircularLoomsSec.dgv.Item(10, c).Value = OleDBDR.Item(16)
                    frmCircularLoomsSec.dgv.Item(11, c).Value = OleDBDR.Item(17)
                    frmCircularLoomsSec.dgv.Item(12, c).Value = OleDBDR.Item(18)
                    frmCircularLoomsSec.dgv.Item(13, c).Value = OleDBDR.Item(19)
                    frmCircularLoomsSec.dgv.Item(14, c).Value = OleDBDR.Item(20)

                    frmCircularLoomsSec.totProd = frmCircularLoomsSec.totProd + OleDBDR.Item(16)
                    frmCircularLoomsSec.totEff = frmCircularLoomsSec.totEff + OleDBDR.Item(17)
                    frmCircularLoomsSec.totaleff = frmCircularLoomsSec.totEff / frmCircularLoomsSec.dgv.Rows.Count


                    frmCircularLoomsSec.lblprod.Text = frmCircularLoomsSec.totProd
                    frmCircularLoomsSec.lbleff.Text = Format(frmCircularLoomsSec.totaleff, "N")

                    frmCircularLoomsSec.cmbLoomsNo.Items.Remove(OleDBDR.Item(6))
                    c = c + 1
                End While
            End If
            frmCircularLoomsSec.dgv.ClearSelection()
            frmEmployeesList.EmployeesList()
            frmCircularLoomsSec.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub dgv_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDown
        Try
            If e.Button = MouseButtons.Right Then
                dgv.CurrentCell = dgv(e.ColumnIndex, e.RowIndex)
                dgv.ContextMenuStrip = ContextMenuStrip1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        clsDate = dgv.CurrentRow.Cells(1).Value
        If clsDate <= maxCSRDATE Then
            MsgBox("You Cant Update this Form", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        updateForm()
    End Sub
    Sub getMaxCLSNo()
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
                .CommandText = "SELECT max(dfrom) from tblCSR "
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                maxCSRDATE = OleDBDR.Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        dgv.ContextMenuStrip = ContextMenuStrip2
    End Sub

    Private Sub ViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class