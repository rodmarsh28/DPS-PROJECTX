Imports System.Data.SqlClient


Public Class CardList
    Dim dt As New DataTable
    Public formMode As String
    Dim rowIndexClick As Integer = 0
    Sub GetCardList()
        Dim CardType As String
        If cmbCardType.Text = "All" Then
            CardType = ""
        Else
            CardType = "and cardType = '" & cmbCardType.Text & "'"
        End If
        Try
            checkConn()
            strSQL = " select * from CardListView " & _
                "where cardID like '%" & txtSearch.Text & "%' " & CardType & " or  cardName like '%" & txtSearch.Text & "%' " & CardType
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
            If rowIndexClick < LV.Items.Count Then
                LV.Items(rowIndexClick).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim frm As New CardProfile
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.MdiParent = frmAccountingMain
        frm.Show()
    End Sub

    Private Sub CardList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        GetCardList()
    End Sub

    Private Sub CardList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbCardType.SelectedIndex = 0
        GetCardList()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        rowIndexClick = 0
        GetCardList()
    End Sub
    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If GetActiveWindow = Me.Handle Then
            GetCardList()
        End If
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgv_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

    End Sub

    Private Sub LV_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV.MouseClick
        Try
            rowIndexClick = LV.FocusedItem.Index
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV.SelectedIndexChanged

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim frm As New CardProfile
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.MdiParent = frmAccountingMain

        Dim ac As New Accounting_class
        ac.cardID = LV.SelectedItems(0).SubItems(0).Text
        ac.get_card_info()
        frm.txtCardName.Text = ac.cardName
        frm.txtCardAddress.Text = ac.cardAddress
        frm.txtCardCN.Text = ac.cardCN
        frm.cmbCardType.Text = ac.cardType
        frm.txtCardNo.Text = ac.cardID
        frm.cmbDesignation.Text = ac.designation
        frm.txtCardCreditLimit.Text = ac.creditlimit
        If ac.allowCredit = "1" Then
            frm.chkAllowCredit.Checked = True
        Else
            frm.chkAllowCredit.Checked = False
        End If
        If ac.cardStatus = "ACTIVE" Then
            frm.chkboxInactiveCard.Checked = False
        Else
            frm.chkboxInactiveCard.Checked = True
        End If
        frm.btnSave.Text = "Update"
        frm.cmbCardType.Enabled = False
        frm.txtCardNo.Enabled = False
        frm.Show()
    End Sub

    Private Sub cmbCardType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCardType.SelectedIndexChanged
        GetCardList()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class