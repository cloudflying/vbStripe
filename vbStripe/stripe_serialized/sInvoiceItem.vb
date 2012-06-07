Imports Newtonsoft.Json
Public Class sInvoiceItem

    '"amount": 60, "livemode": false, 
    '"currency": "usd", 
    '"date": 1333841992, 
    '"customer": "cus_pSzKD3AQpaX51v", 
    '"description": "20 minute phone call.", 
    '"object": "invoiceitem", 
    '"id": "ii_jUypKfKp9O8I5N", 
    '"invoice": "in_uS37HpgzCNLnHv"

    Private _amount As Integer
    Public Property amount As Integer
        Get
            Return _amount
        End Get
        Set(value As Integer)
            _amount = value
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

    Private _dateValue As String
    <JsonProperty("date")> _
    Public Property dateValue As String
        Get
            Return _dateValue
        End Get
        Set(value As String)
            _dateValue = value
        End Set
    End Property

    Private _customer As String
    Public Property customer As String
        Get
            Return _customer
        End Get
        Set(value As String)
            _customer = value
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

    Private _objectType As String
    <JsonProperty("object")> _
    Public Property objectType As String
        Get
            Return _objectType
        End Get
        Set(value As String)
            _objectType = value
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

    Private _invoice As String
    <JsonProperty("invoice")> _
    Public Property invoice As String
        Get
            Return _invoice
        End Get
        Set(value As String)
            _invoice = value
        End Set
    End Property
End Class
