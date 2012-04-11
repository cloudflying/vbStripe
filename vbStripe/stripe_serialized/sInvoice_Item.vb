Imports Newtonsoft.Json
Public Class sInvoice_Item
    '{ "date": 1333234366, "currency": "usd", "description": "Setup Fee", "object": "invoiceitem", "livemode": false, 
    '"id": "ii_wLioGwPGFk5Z9Y", "amount": 10000, "customer": "cus_xbV8AXmkY62VDF" }

    Private _date As String
    <JsonProperty("date")> _
    Public Property dateInvoice As String
        Get
            Return _date
        End Get
        Set(value As String)
            _date = value
        End Set
    End Property

    Private _currency As String
    <JsonProperty("currency")> _
    Public Property currency As String
        Get
            Return _currency
        End Get
        Set(value As String)
            _currency = value
        End Set
    End Property

    Private _description As String
    <JsonProperty("description")> _
    Public Property description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Private _object As String
    <JsonProperty("object")> _
    Public Property objectString As String
        Get
            Return _object
        End Get
        Set(value As String)
            _object = value
        End Set
    End Property

    Private _livemode As Boolean
    <JsonProperty("livemode")> _
    Public Property livemode As Boolean
        Get
            Return _livemode
        End Get
        Set(value As Boolean)
            _livemode = value
        End Set
    End Property

    Private _id As String
    <JsonProperty("id")> _
    Public Property id As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property

    Private _amount As String
    <JsonProperty("amount")> _
    Public Property amount As String
        Get
            Return _amount
        End Get
        Set(value As String)
            _amount = value
        End Set
    End Property

    Private _customer As String
    <JsonProperty("customer")> _
    Public Property customer As String
        Get
            Return _customer
        End Get
        Set(value As String)
            _customer = value
        End Set
    End Property
End Class
