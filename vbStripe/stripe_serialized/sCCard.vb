Imports Newtonsoft.Json
Public Class sCCard
    Private _type As String
    <JsonProperty("type")> _
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
    Private _address_country As String
    Public Property address_country As String
        Get
            Return _address_country
        End Get
        Set(value As String)
            _address_country = value
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
    <JsonProperty("object")> _
     Public Property cobject As String
        Get
            Return _sobject
        End Get
        Set(value As String)
            _sobject = value
        End Set
    End Property
    Private _address_zip As String
    Public Property address_zip As String
        Get
            Return _address_zip
        End Get
        Set(value As String)
            _address_zip = value
        End Set
    End Property
    Private _address_line1 As String
    Public Property address_line1 As String
        Get
            Return _address_line1
        End Get
        Set(value As String)
            _address_line1 = value
        End Set
    End Property
    Private _address_line2 As String
    Public Property address_line2 As String
        Get
            Return _address_line2
        End Get
        Set(value As String)
            _address_line2 = value
        End Set
    End Property
    Private _fingerprint As String
    Public Property fingerprint As String
        Get
            Return _fingerprint
        End Get
        Set(value As String)
            _fingerprint = value
        End Set
    End Property
    Private _last4 As String
    Public Property last4 As String
        Get
            Return _last4
        End Get
        Set(value As String)
            _last4 = value
        End Set
    End Property
    Private _address_zip_check As String
    Public Property address_zip_check As String
        Get
            Return _address_zip_check
        End Get
        Set(value As String)
            _address_zip_check = value
        End Set
    End Property
    Private _person_name As String
    <JsonProperty("name")> _
     Public Property person_name As String
        Get
            Return _person_name
        End Get
        Set(value As String)
            _person_name = value
        End Set
    End Property
    Private _address_state As String
    Public Property address_state As String
        Get
            Return _address_state
        End Get
        Set(value As String)
            _address_state = value
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
    Private _address_line1_check As String
    Public Property address_line1_check As String
        Get
            Return _address_line1_check
        End Get
        Set(value As String)
            _address_line1_check = value
        End Set
    End Property
End Class
