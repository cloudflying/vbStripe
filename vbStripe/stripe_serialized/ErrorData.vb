Imports Newtonsoft.Json
Public Class ErrorData
    Private _errorinfo As sError
    <JsonProperty("error")> _
    Public Property errorinfo As sError
        Get
            Return _errorinfo
        End Get
        Set(value As sError)
            _errorinfo = value
        End Set
    End Property
End Class
