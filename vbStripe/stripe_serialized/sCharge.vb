Public Class sCharge
    Private _amount As String
    Public Property amount As String
        Get
            Return _amount
        End Get
        Set(value As String)
            _amount = value
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
    Private _currency As String
    Public Property currency As String
        Get
            Return _currency
        End Get
        Set(value As String)
            _currency = value
        End Set
    End Property
    Private _description As String
    Public Property description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property
    Private _paid As String
    Public Property paid As String
        Get
            Return _paid
        End Get
        Set(value As String)
            _paid = value
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
    Private _fee As String
    Public Property fee As String
        Get
            Return _fee
        End Get
        Set(value As String)
            _fee = value
        End Set
    End Property
    Private _refunded As String
    Public Property refunded As String
        Get
            Return _refunded
        End Get
        Set(value As String)
            _refunded = value
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
    Private _address_zip_check As Boolean
    Public Property address_zip_check As Boolean
        Get
            Return _address_zip_check
        End Get
        Set(value As Boolean)
            _address_zip_check = value
        End Set
    End Property

End Class
