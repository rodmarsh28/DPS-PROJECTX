Partial Class DataSet1
   

   


    Partial Class RawMatsInventoryTableDataTable

        Private Sub RawMatsInventoryTableDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.TYPEColumn.ColumnName) Then
            End If

        End Sub

    End Class


End Class
