Public Class sPlan
    Private _amount As String
    Public Property amount As String
        Get
            Return _amount
        End Get
        Set(value As String)
            _amount = value
        End Set
    End Property
    Private _interval As String
    Public Property interval As String
        Get
            Return _interval
        End Get
        Set(value As String)
            _interval = value
        End Set
    End Property
    Private _sobject As String
    Public Property sobject As String
        Get
            Return _sobject
        End Get
        Set(value As String)
            _sobject = value
        End Set
    End Property
    Private _trial_period_days As String
    Public Property trial_period_days As String
        Get
            Return _trial_period_days
        End Get
        Set(value As String)
            _trial_period_days = value
        End Set
    End Property

End Class
