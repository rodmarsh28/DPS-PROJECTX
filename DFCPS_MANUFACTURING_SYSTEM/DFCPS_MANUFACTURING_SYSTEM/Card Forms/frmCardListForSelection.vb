Imports System.Data.SqlClient

Public Class frmCardListForSelection
    Public formMode As String
    Public filterCardType As String
    Dim rowIndex As Integer
    Dim dt As New DataTable
    Public itemClick As Boolean
    Sub filterType()
        If formMode = "ReceivePayments" Then
            filterCardType = "and cardType = 'Customer' "
        ElseIf formMode = "" Then

        End If
    End Sub
    'Sub showtextboxwatermark()
    '    If txtSearch.Text = "" Then
    '        txtSearch.Text = "   Enter Card ID or Name here to search ..."
    '        txtSearch.ForeColor = Color.Silver
    '    End If
    'End Sub
    'Sub hidetextboxwatermark()
    '    If txtSearch.Text = "   Enter Card ID or Name here to search ..." Then
    '        txtSearch.Text = ""
    '        txtSearch.ForeColor = Color.Black
    '    End If
    'End Sub

    Private Sub frmCardListForSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetCardList()
    End Sub
    Sub GetCardList()
        Try
            checkConn()
            strSQL = " select * from CardListView " & _
                "where cardID like '%" & txtSearch.Text & "%' " & filterCardType & " or  cardName like '%" & txtSearch.Text & "%' " & filterCardType
            Dim da As New SqlDataAdapter(strSQL, conn)
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
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub txtSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.Click
        'hidetextboxwatermark()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        itemClick = True
        Try
            If formMode = "ReceivePayments" Then
                frmReceivePayments.cardID = LV.SelectedItems(0).SubItems(0).Text
                frmReceivePayments.txtCustomerName.Text = LV.SelectedItems(0).SubItems(1).Text
                frmReceivePayments.totalBalance = LV.SelectedItems(0).SubItems(4).Text
                Me.Close()
            ElseIf formMode = "Sales Invoice" Then
                frmSalesInvoice.CardID = LV.SelectedItems(0).SubItems(0).Text
                frmSalesInvoice.txtName.Text = LV.SelectedItems(0).SubItems(1).Text
                frmSalesInvoice.totalBalance = LV.SelectedItems(0).SubItems(4).Text
                Me.Close()
            ElseIf formMode = "Purchase Invoice" Then
                frmPurchases.CardID = LV.SelectedItems(0).SubItems(0).Text
                frmPurchases.txtName.Text = LV.SelectedItems(0).SubItems(1).Text
                frmPurchases.totalBalance = LV.SelectedItems(0).SubItems(4).Text
                Me.Close()
            Else
                Me.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        GetCardList()
    End Sub
    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If GetActiveWindow = Me.Handle Then
            GetCardList()
        End If
    End Sub

    Private Sub LV_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV.MouseClick
        Try
            rowIndex = LV.FocusedItem.Index
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV.SelectedIndexChanged

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        CardProfile.ShowDialog()
    End Sub
End Class