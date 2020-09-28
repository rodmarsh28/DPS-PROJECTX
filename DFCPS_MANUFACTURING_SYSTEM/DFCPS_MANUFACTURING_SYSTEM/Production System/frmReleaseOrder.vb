Public Class frmReleaseOrder
    Public JONO As String
    Public DRNO As String
    Public SALESNO As String

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Dim qty As String = InputBox("Please Enter Qty", "Entry")
        Dim ExQty As Integer = dgv.CurrentRow.Cells(7).Value
        If IsNumeric(qty) Then
            If qty <= ExQty Then
                dgv.CurrentRow.Cells(6).Value = qty
            Else
                MsgBox("You can't Release higher than order", MsgBoxStyle.Exclamation, "Sorry")
            End If
        ElseIf IsNumeric(qty) = False Then
            MsgBox("Please Input Numeric", MsgBoxStyle.Critical, "Error")
        End If
    End Sub


    Private Sub frmReleaseOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control Then
            If MsgBox("ARE YOU SURE TO DELETE THIS ITEM?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
                For Each row As DataGridViewRow In dgv.SelectedRows
                    dgv.Rows.Remove(row)
                Next
            End If
        End If
    End Sub
    Sub printDR()
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
                .CommandText = "SELECT dbo.tblDR.DRNO, " & _
                "dbo.tblDR.[DATE], " & _
                "dbo.tblDR.JONO, " & _
                "dbo.tblDR.REFNO, " & _
                "dbo.tblJobOrder.CUSTOMER, " & _
                "dbo.tblOrderReleasedTR.DESCRIPTION, " & _
                "dbo.tblOrderReleasedTR.WIDTH, " & _
                "dbo.tblOrderReleasedTR.LENGTH, " & _
                "dbo.tblOrderReleasedTR.COLOR, " & _
                "dbo.tblOrderReleasedTR.SEWNTYPE, " & _
                "dbo.tblOrderReleasedTR.PRINTED, " & _
                "dbo.tblOrderReleasedTR.RELEASED, " & _
                "dbo.tblSalesTR.UPRICE, " & _
                "dbo.tblSalesTR.UPRICE * dbo.tblOrderReleasedTR.RELEASED " & _
                "FROM dbo.tblOrderReleasedTR " & _
                "INNER JOIN dbo.tblJobOrder ON dbo.tblJobOrder.JONO = dbo.tblOrderReleasedTR.JONO " & _
                "INNER JOIN dbo.tblSalesTR ON dbo.tblJobOrder.SALESNO = dbo.tblSalesTR.SALESNO " & _
                "INNER JOIN dbo.tblDR ON dbo.tblOrderReleasedTR.DRNO = dbo.tblDR.DRNO " & _
                "WHERE " & _
                "CAST(dbo.tblOrderReleasedTR.WIDTH AS DECIMAL(20,0)) = CAST(dbo.tblSalesTR.WIDTH AS DECIMAL(20,0)) And " & _
                "CAST(dbo.tblOrderReleasedTR.LENGTH AS DECIMAL(20,0)) = CAST(dbo.tblSalesTR.LENGTH AS DECIMAL(20,0)) And " & _
                "dbo.tblOrderReleasedTR.COLOR = dbo.tblSalesTR.COLOR And " & _
                "dbo.tblOrderReleasedTR.SEWNTYPE = dbo.tblSalesTR.SEWNTYPE And " & _
                "dbo.tblOrderReleasedTR.PRINTED = dbo.tblSalesTR.PRINTED AND  " & _
                "dbo.tblOrderReleasedTR.DRNO = '" & DRNO & "'"


            End With
            OleDBDR = OleDBC.ExecuteReader
            Dim dt As New DataTable
            With dt
                .Columns.Add("DRNO")
                .Columns.Add("DATE")
                .Columns.Add("JONO")
                .Columns.Add("REF")
                .Columns.Add("GPNO")
                .Columns.Add("CUSTOMER")
                .Columns.Add("DESCRIPTION")
                .Columns.Add("QTY")
                .Columns.Add("UNIT")
                .Columns.Add("UPRICE")
                .Columns.Add("AMOUNT")
                .Columns.Add("PREPAREDBY")
            End With
            If OleDBDR.HasRows Then
                While OleDBDR.Read
                    dt.Rows.Add(OleDBDR.Item(0),
                     Format(OleDBDR.Item(1), "MMM dd, yyyy hh:mm tt"),
                     OleDBDR.Item(2),
                     OleDBDR.Item(3),
                     OleDBDR.Item(0).Remove(0, 3),
                     OleDBDR.Item(4),
                     OleDBDR.Item(5),
                     Format(OleDBDR.Item(11), "N0"),
                     "PCS",
                     Format(OleDBDR.Item(12), "N"),
                     Format(OleDBDR.Item(13), "N"),
                     "DEVINE JENILIE BIÑAN")
                End While
            End If
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New DRANDGP
            rptDoc.SetDataSource(dt)
            frmReportViewerNoDateRange.CrystalReportViewer1.ReportSource = rptDoc
            rptDoc.PrintOptions.PrinterName = My.Settings.printerName
            rptDoc.PrintToPrinter(1, False, 0, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub generateDRNo()
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
                .CommandText = "SELECT * from tblDR order by DRNO DESC"
            End With
            OleDBDR = OleDBC.ExecuteReader
            If OleDBDR.Read Then
                StrID = Mid(OleDBDR(0), 5, Len(OleDBDR(0)))
                DRNO = "DR-" & Format(Val(StrID) + 1, "00000")
            Else
                DRNO = "DR-00001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Sub SAVEDR()
        If MsgBox("ARE YOU SURE THIS TRANSACTION ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            Try
                Dim REMARKS As String = InputBox("REMARKS", "RELEASE ITEMS")
                If conn.State = ConnectionState.Open Then
                    OleDBC.Dispose()
                    conn.Close()
                End If
                If conn.State <> ConnectionState.Open Then
                    ConnectDatabase()
                End If
                With OleDBC
                    .Connection = conn
                    .CommandText = "INSERT INTO tblDR VALUES('" & DRNO & _
                        "','" & Format(Now, "MM/dd/yyyy hh:mm tt") & _
                        "','" & SALESNO & _
                        "','" & JONO & _
                        "','" & REMARKS & "')"
                    .ExecuteNonQuery()
                End With
                Release()
                printDR()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub Release()

        If dgv.Rows.Count = "0" Then
            MsgBox("No Data can be Save", MsgBoxStyle.Critical, "Sorry")
            Exit Sub
        End If

        Try
            Dim row1 As Integer
            Dim col As Integer
            col = 0
            row1 = dgv.RowCount
            While col < row1
                Dim wPrints As String
                If conn.State = ConnectionState.Open Then
                    OleDBC.Dispose()
                    conn.Close()
                End If
                If conn.State <> ConnectionState.Open Then
                    ConnectDatabase()
                End If
                With OleDBC
                    .Connection = conn
                    .CommandText = "INSERT INTO tblOrderReleasedTR VALUES('" & DRNO & _
                        "','" & JONO & _
                        "','" & dgv.Item(0, col).Value & _
                        "','" & dgv.Item(1, col).Value & _
                        "','" & dgv.Item(2, col).Value & _
                        "','" & dgv.Item(3, col).Value & _
                        "','" & dgv.Item(4, col).Value & _
                        "','" & dgv.Item(5, col).Value & _
                        "','" & CInt(dgv.Item(6, col).Value) & "')"
                    .ExecuteNonQuery()
                End With
                col = col + 1
            End While
            MsgBox("Item is successfully released", MsgBoxStyle.Information, "Success")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmReleaseOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        generateDRNo()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SAVEDR()
    End Sub
End Class