Imports System.Data.SqlClient
Imports System.Linq ' need to add 
Public Class systemSettings_class
    Public settingsName As String
    Public settingsValue As String
    Public return_settingsValue As String

    Public dt As DataTable
    Public Sub insert_update_settingsVariable()
        Try
            Dim cmd As New SqlCommand("insert_settingsVariable", conn)
            checkConn()
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@settingsName", SqlDbType.Int).Value = settingsName
                .Parameters.AddWithValue("@settingsValue", SqlDbType.VarChar).Value = settingsValue
            End With
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub get_settingsValue()
        Try
            checkConn()
            Dim cmd As New SqlCommand("select_settingsVariable", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@settingsName", SqlDbType.VarChar).Value = settingsName
                .Parameters.AddWithValue("@settingsValue", SqlDbType.VarChar).Value = settingsValue
            End With
            OleDBDR = cmd.ExecuteReader
            If OleDBDR.Read Then
                return_settingsValue = OleDBDR.Item(0)
            Else
                return_settingsValue = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub
    Public tableName As String
    Public columnName As String
    Public series As String
    Public result As String
    Public Sub generateNo()
        Dim cmd As New SqlCommand("select max(" & columnName & ") from " & tableName & "", conn)
        checkConn()
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.Read Then
            If IsDBNull(reader.Item(0)) <> True Then
                result = reader.Item(0)
            Else
                result = series & "00000"
            End If
        End If
    End Sub
    Public Sub isDataupdated()
        Try
            lastrowchanges()
            'If hasdbupdated = True Then


            '    If Application.OpenForms().OfType(Of SalesTransactionViewer).Any Then
            '        SalesTransactionViewer.GET_SALE_LIST()
            '    End If
            '    If Application.OpenForms().OfType(Of itemSelectorForm).Any Then
            '        itemSelectorForm.get_voucher_list()
            '    End If
            '    If Application.OpenForms().OfType(Of TransactionViewer).Any Then
            '        TransactionViewer.loadData()
            '    End If
            '    If Application.OpenForms().OfType(Of frmCheckTransList).Any Then
            '        frmCheckTransList.get_checkIssued_List()
            '    End If
            '    If Application.OpenForms().OfType(Of frmVoucher_Payable_List).Any Then
            '        frmVoucher_Payable_List.GET_PAYABLES()
            '    End If
            '    If Application.OpenForms().OfType(Of frmVoucher_Payable_List).Any Then
            '        frmVoucher_Payable_List.GET_PAYABLES()
            '    End If
            '    If Application.OpenForms().OfType(Of frmVoucher_Payable_List).Any Then
            '        frmVoucher_Payable_List.GET_PAYABLES()
            '    End If
            '    If Application.OpenForms().OfType(Of frmAccountList).Any Then
            '        frmAccountList.showAccountList()
            '    End If
            '    If Application.OpenForms().OfType(Of frmManageAccounts).Any Then
            '        frmManageAccounts.showHeaderList()
            '        frmManageAccounts.showsUBHeaderList()
            '        frmManageAccounts.showDeptList()
            '        frmManageAccounts.showAccountList()
            '    End If
            '    If Application.OpenForms().OfType(Of formBankSelection).Any Then
            '        formBankSelection.searchList()
            '    End If
            '    If Application.OpenForms().OfType(Of CardList).Any Then
            '        CardList.GetCardList()
            '    End If
            '    If Application.OpenForms().OfType(Of CardProfile).Any Then
            '        CardProfile.generateCardNo()
            '    End If
            '    If Application.OpenForms().OfType(Of CardList).Any Then
            '        CardList.GetCardList()
            '    End If
            '    If Application.OpenForms().OfType(Of frmCardListForSelection).Any Then
            '        frmCardListForSelection.GetCardList()
            '    End If
            '    If Application.OpenForms().OfType(Of DepartmentList).Any Then
            '        DepartmentList.get_department_List()
            '    End If
            '    If Application.OpenForms().OfType(Of frmAddItemsInventory).Any Then
            '        frmAddItemsInventory.ItemType()
            '        frmAddItemsInventory.generateItemNo()
            '    End If
            '    If Application.OpenForms().OfType(Of frmInventory).Any Then
            '        frmInventory.GetItemsinInventoryAll()
            '    End If
            '    If Application.OpenForms().OfType(Of InventoryList).Any Then
            '        InventoryList.getItemlist()
            '    End If
            '    If Application.OpenForms().OfType(Of frmRawMaterialProduced).Any Then
            '        frmRawMaterialProduced.generateIssuanceNo()
            '    End If
            '    If Application.OpenForms().OfType(Of frmMaterialWidthrawal).Any Then
            '        frmMaterialWidthrawal.generateIssuanceNo()

            '    End If

            '        last_row_change = latest_row_change
            '    End If
        Catch ex As Exception
        End Try
    End Sub
End Class
