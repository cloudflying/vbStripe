Public Class sCustomer

    Private _description As String
    Public Property description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
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
    Private _sobject As String
    Public Property sobject As String
        Get
            Return _sobject
        End Get
        Set(value As String)
            _sobject = value
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
    Private _liveMode As String
    Public Property liveMode As String
        Get
            Return _liveMode
        End Get
        Set(value As String)
            _liveMode = value
        End Set
    End Property
    Private _active_card As sCCard
    Public Property active_card As sCCard
        Get
            Return _active_card
        End Get
        Set(value As sCCard)
            _active_card = value
        End Set
    End Property


End Class
