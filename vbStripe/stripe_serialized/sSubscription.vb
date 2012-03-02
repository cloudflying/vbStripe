Public Class sSubscription
    Private _status As String
    Public Property status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property
    Private _trial_end As String
    Public Property trial_end As String
        Get
            Return _trial_end
        End Get
        Set(value As String)
            _trial_end = value
        End Set
    End Property
    Private _current_period_start As String
    Public Property current_period_start As String
        Get
            Return _current_period_start
        End Get
        Set(value As String)
            _current_period_start = value
        End Set
    End Property
    Private _plan As sPlan
    Public Property plan As sPlan
        Get
            Return _plan
        End Get
        Set(value As sPlan)
            _plan = value
        End Set
    End Property
    Private _start As String
    Public Property start As String
        Get
            Return _start
        End Get
        Set(value As String)
            _start = value
        End Set
    End Property
    Private _current_period_end As String
    Public Property current_period_end As String
        Get
            Return _current_period_end
        End Get
        Set(value As String)
            _current_period_end = value
        End Set
    End Property
    Private _ended_at As String
    Public Property ended_at As String
        Get
            Return _ended_at
        End Get
        Set(value As String)
            _ended_at = value
        End Set
    End Property
    Private _canceled_at As String
    Public Property canceled_at As String
        Get
            Return _canceled_at
        End Get
        Set(value As String)
            _canceled_at = value
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
    Private _trial_start As String
    Public Property trial_start As String
        Get
            Return _trial_start
        End Get
        Set(value As String)
            _trial_start = value
        End Set
    End Property

End Class
