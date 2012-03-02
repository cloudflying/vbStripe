Public Class sCCard
    Private _type As String
    Public Property type As String
        Get
            Return _type
        End Get
        Set(value As String)
            _type = value
        End Set
    End Property
    Private _exp_month As String
    Public Property exp_month As String
        Get
            Return _exp_month
        End Get
        Set(value As String)
            _exp_month = value
        End Set
    End Property
    Private _exp_year As String
    Public Property exp_year As String
        Get
            Return _exp_year
        End Get
        Set(value As String)
            _exp_year = value
        End Set
    End Property
    Private _country As String
    Public Property country As String
        Get
            Return _country
        End Get
        Set(value As String)
            _country = value
        End Set
    End Property
    Private _cvc_check As String
    Public Property cvc_check As String
        Get
            Return _cvc_check
        End Get
        Set(value As String)
            _cvc_check = value
        End Set
    End Property
    Private _sobject As String
    Public Property cobject As String
        Get
            Return _sobject
        End Get
        Set(value As String)
            _sobject = value
        End Set
    End Property
End Class
