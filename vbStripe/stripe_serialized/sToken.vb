Imports Newtonsoft.Json
Public Class sToken

    Private _used As Boolean
    Public Property used As Boolean
        Get
            Return _used
        End Get
        Set(value As Boolean)
            _used = value
        End Set
    End Property
    Private _created As String
    Public Property created As String
        Get
            Return _created
        End Get
        Set(value As String)
            _created = value
        End Set
    End Property
    Private _livemode As Boolean
    Public Property livemode As Boolean
        Get
            Return _livemode
        End Get
        Set(value As Boolean)
            _livemode = value
        End Set
    End Property
    Private _currency As String
    Public Property currency As String
        Get
            Return _currency
        End Get
        Set(value As String)
            _currency = value
        End Set
    End Property
    Private _obj As String
    <JsonProperty("object")> _
    Public Property obj As String
        Get
            Return _obj
        End Get
        Set(value As String)
            _obj = value
        End Set
    End Property
    Private _card As sCCard
    Public Property card As sCCard
        Get
            Return _card
        End Get
        Set(value As sCCard)
            _card = value
        End Set
    End Property
    Private _id As String
    Public Property id As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property
    Private _amount As Integer
    Public Property amount As Integer
        Get
            Return _amount
        End Get
        Set(value As Integer)
            _amount = value
        End Set
    End Property
End Class
