Public Class public_event_class
    Private mValue As Integer
    Public Event VariableChanged(ByVal mvalue As Integer)
    Public Property Variable() As Integer
        Get
            Variable = mValue
        End Get
        Set(ByVal value As Integer)
            mValue = value
            RaiseEvent VariableChanged(mValue)
        End Set
    End Property
End Class
