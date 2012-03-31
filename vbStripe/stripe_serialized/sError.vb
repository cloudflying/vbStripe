Imports Newtonsoft.Json

Public Class sError

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
    Private _message As String
    <JsonProperty("message")> _
    Public Property message As String
        Get
            Return _message
        End Get
        Set(value As String)
            _message = value
        End Set
    End Property
    Private _code As String
    <JsonProperty("code")> _
    Public Property code As String
        Get
            Return _code
        End Get
        Set(value As String)
            _code = value
        End Set
    End Property
    Private _param As String
    <JsonProperty("param")> _
    Public Property param As String
        Get
            Return _param
        End Get
        Set(value As String)
            _param = value
        End Set
    End Property



    
End Class
