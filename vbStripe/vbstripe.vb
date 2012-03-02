Imports Microsoft.VisualBasic
Imports System.Net
Imports System.IO
Imports System.Xml
Imports System.Net.Mail
Imports System.Collections.Specialized
Imports System.Text
Imports System.Web
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class vbstripe


    Public acctToken As String = String.Empty
    Public RestProctocal As String = "https://"
    Public RestAPI As String = "api.stripe.com/v1"


    Public Function update_CustomerSubscription(customerId As String, plan As String, Optional coupon As String = "",
                                        Optional prorate As String = "", Optional trial_end As String = "",
                                        Optional ccNumber As String = "", Optional ccExp_Month As String = "",
                                        Optional ccExp_Year As String = "", Optional ccCVC As String = "",
                                        Optional ccName As String = "", Optional ccAddress_Line1 As String = "",
                                        Optional ccAddress_Line2 As String = "", Optional ccAddress_Zip As String = "",
                                        Optional ccAddress_State As String = "", Optional ccAddress_Country As String = "") As sSubscription

        If acctToken.Length < 10 Then
            Throw New ApplicationException("API not provided.")
        End If
        If customerId.Length < 3 Then
            Throw New ApplicationException("Customer ID not provided.")
        End If

        Dim apiURI As String = "/customers/" & customerId & "/subscription"
        Dim data As String = String.Empty

        data = "plan=" & plan
        If coupon.Length > 0 Then data &= "&coupon=" & coupon
        If prorate.Length > 0 Then data &= "&prorate=" & prorate
        If trial_end.Length > 0 Then data &= "&trial_end=" & trial_end

        If ccNumber.Length = 16 Then
            data &= "card[number]=" & ccNumber
            data &= "&card[exp_month]=" & ccExp_Month
            data &= "&card[exp_year]=" & ccExp_Year
            If Len(ccCVC) > 0 Then data &= "&card[cvc]=" & ccCVC
            If Len(ccName) > 0 Then data &= "&card[name]=" & ccName
            If Len(ccAddress_Line1) > 0 Then data &= "&card[address_line1]=" & ccAddress_Line1
            If Len(ccAddress_Line2) > 0 Then data &= "&card[address_line2]=" & ccAddress_Line2
            If Len(ccAddress_Zip) > 0 Then data &= "&card[address_zip]=" & ccAddress_Zip
            If Len(ccAddress_State) > 0 Then data &= "&card[address_state]=" & ccAddress_State
            If Len(ccAddress_Country) > 0 Then data &= "&card[address_country]=" & ccAddress_Country
        End If
        If Len(coupon) > 0 Then
            If Len(data) > 0 Then
                data &= "&coupon=" & coupon
            Else
                data &= "coupon=" & coupon
            End If
        End If
        Dim returnedData As String = sendReq(data, apiURI)
        Dim subScriber As sSubscription = JsonConvert.DeserializeObject(Of sSubscription)(returnedData)
        Return subScriber
    End Function

    Public Function delete_CustomerSubscription(customerID As String, Optional at_period_end As String = "") As sSubscription
        If acctToken.Length < 10 Then
            Throw New ApplicationException("API not provided.")
        End If
        If customerId.Length < 3 Then
            Throw New ApplicationException("Customer ID not provided.")
        End If

        Dim apiURI As String = "/customers/" & customerId & "/subscription"
        Dim data As String = String.Empty
        If at_period_end.Length > 0 Then data = "at_period_end=" & at_period_end
        Dim returnedData As String = sendDELETEReq(data, apiURI)
        Dim subScriber As sSubscription = JsonConvert.DeserializeObject(Of sSubscription)(returnedData)
        Return subScriber
    End Function

    Public Function create_Customer(Optional ccNumber As String = "", Optional ccExp_Month As String = "", Optional ccExp_Year As String = "",
                                     Optional ccCVC As String = "", Optional ccName As String = "",
                                     Optional ccAddress_Line1 As String = "", Optional ccAddress_Line2 As String = "",
                                     Optional ccAddress_Zip As String = "", Optional ccAddress_State As String = "",
                                     Optional ccAddress_Country As String = "", Optional description As String = "",
                                     Optional coupon As String = "", Optional email As String = "",
                                     Optional plan As String = "", Optional trial_end As String = "") As sCustomer

        If acctToken.Length < 10 Then
            Throw New ApplicationException("API not provided.")
        End If

        Dim apiURI As String = "/customers"
        Dim data As String = String.Empty

        If ccNumber.Length = 16 Then
            data &= "&card[number]=" & ccNumber
            data &= "&card[exp_month]=" & ccExp_Month
            data &= "&card[exp_year]=" & ccExp_Year
            If Len(ccCVC) > 0 Then data &= "&card[cvc]=" & ccCVC
            If Len(ccName) > 0 Then data &= "&card[name]=" & ccName
            If Len(ccAddress_Line1) > 0 Then data &= "&card[address_line1]=" & ccAddress_Line1
            If Len(ccAddress_Line2) > 0 Then data &= "&card[address_line2]=" & ccAddress_Line2
            If Len(ccAddress_Zip) > 0 Then data &= "&card[address_zip]=" & ccAddress_Zip
            If Len(ccAddress_State) > 0 Then data &= "&card[address_state]=" & ccAddress_State
            If Len(ccAddress_Country) > 0 Then data &= "&card[address_country]=" & ccAddress_Country
        End If

        If Len(description) > 0 Then data &= "&description=" & description
        If Len(coupon) > 0 Then data &= "&coupon=" & coupon
        If Len(email) > 0 Then data &= "&email=" & email
        If Len(plan) > 0 Then data &= "&plan=" & plan
        If Len(trial_end) > 0 Then data &= "&trial_end=" & trial_end

        Dim returnedData As String = sendReq(data, apiURI)
        Dim cust As sCustomer = JsonConvert.DeserializeObject(Of sCustomer)(returnedData)
        Return cust
    End Function

    Public Function update_Customer(customerId As String, Optional ccNumber As String = "", Optional ccExp_Month As String = "", Optional ccExp_Year As String = "",
                                    Optional ccCVC As String = "", Optional ccName As String = "",
                                    Optional ccAddress_Line1 As String = "", Optional ccAddress_Line2 As String = "",
                                    Optional ccAddress_Zip As String = "", Optional ccAddress_State As String = "",
                                    Optional ccAddress_Country As String = "", Optional description As String = "",
                                    Optional coupon As String = "", Optional email As String = "",
                                    Optional plan As String = "", Optional trial_end As String = "") As sCustomer

        If acctToken.Length < 10 Then
            Throw New ApplicationException("API not provided.")
        End If
        If customerId.Length < 3 Then
            Throw New ApplicationException("Customer ID not provided.")
        End If

        Dim apiURI As String = "/customers/" & customerId
        Dim data As String = String.Empty

        If ccNumber.Length = 16 Then
            data &= "card[number]=" & ccNumber
            data &= "&card[exp_month]=" & ccExp_Month
            data &= "&card[exp_year]=" & ccExp_Year
            If Len(ccCVC) > 0 Then data &= "&card[cvc]=" & ccCVC
            If Len(ccName) > 0 Then data &= "&card[name]=" & ccName
            If Len(ccAddress_Line1) > 0 Then data &= "&card[address_line1]=" & ccAddress_Line1
            If Len(ccAddress_Line2) > 0 Then data &= "&card[address_line2]=" & ccAddress_Line2
            If Len(ccAddress_Zip) > 0 Then data &= "&card[address_zip]=" & ccAddress_Zip
            If Len(ccAddress_State) > 0 Then data &= "&card[address_state]=" & ccAddress_State
            If Len(ccAddress_Country) > 0 Then data &= "&card[address_country]=" & ccAddress_Country
        End If

        If Len(description) > 0 Then
            If Len(data) > 0 Then
                data &= "&description=" & description
            Else
                data &= "description=" & description
            End If
        End If

        If Len(coupon) > 0 Then
            If Len(data) > 0 Then
                data &= "&coupon=" & coupon
            Else
                data &= "coupon=" & coupon
            End If
        End If
        If Len(email) > 0 Then
            If Len(data) > 0 Then
                data &= "&email=" & email
            Else
                data &= "email=" & email
            End If
        End If

        MsgBox(data)
        Dim returnedData As String = sendReq(data, apiURI)

        Dim cust As sCustomer = JsonConvert.DeserializeObject(Of sCustomer)(returnedData)
        Return cust
    End Function


    Public Function create_ChargeCreditCard(amount As Integer, currency As String, ccNumber As String, ccExp_Month As String, ccExp_Year As String,
                                     Optional ccCVC As String = "", Optional ccName As String = "", Optional ccAddress_Line1 As String = "",
                                     Optional ccAddress_Line2 As String = "", Optional ccAddress_Zip As String = "",
                                     Optional ccAddress_State As String = "",
                                     Optional ccAddress_Country As String = "", Optional description As String = "") As sCharge

        If acctToken.Length < 10 Then
            Throw New ApplicationException("API not provided.")
        End If
        If amount < 0 Then
            Throw New ApplicationException("Amount cannot be less than 0")
        End If
        If currency.Length < 1 Then
            currency = "usd"
        End If
        If ccNumber.Length <> 16 Then
            Throw New ApplicationException("Credit Card Number must be 16 digits")
        End If

        Dim apiURI As String = "/charges"
        Dim data As String = String.Empty

        data = "amount=" & amount
        data &= "&currency=" & currency
        data &= "&card[number]=" & ccNumber
        data &= "&card[exp_month]=" & ccExp_Month
        data &= "&card[exp_year]=" & ccExp_Year
        If Len(ccCVC) > 0 Then data &= "&card[cvc]=" & ccCVC
        If Len(ccName) > 0 Then data &= "&card[name]=" & ccName
        If Len(ccAddress_Line1) > 0 Then data &= "&card[address_line1]=" & ccAddress_Line1
        If Len(ccAddress_Line2) > 0 Then data &= "&card[address_line2]=" & ccAddress_Line2
        If Len(ccAddress_Zip) > 0 Then data &= "&card[address_zip]=" & ccAddress_Zip
        If Len(ccAddress_State) > 0 Then data &= "&card[address_state]=" & ccAddress_State
        If Len(ccAddress_Country) > 0 Then data &= "&card[address_country]=" & ccAddress_Country
        If Len(description) > 0 Then data &= "&description=" & description
        Dim returnedData As String = sendReq(data, apiURI)
        Dim charge As sCharge = JsonConvert.DeserializeObject(Of sCharge)(returnedData)
        Return charge
    End Function


    ''' <summary>
    ''' Send API request
    ''' </summary>
    ''' <param name="data">Form Variables to send with request</param>
    ''' <param name="apiURI">URI after (Must include starting /)</param>
    ''' <returns>JSON FROM stripe</returns>
    ''' <remarks></remarks>
    Private Function sendReq(ByVal data As String, ByVal apiURI As String) As String
        Dim uri As String = RestProctocal & RestAPI & apiURI
        Dim authInfo As String = acctToken & ":"
        authInfo = Convert.ToBase64String(Encoding.[Default].GetBytes(authInfo))

        Dim request As HttpWebRequest = HttpWebRequest.Create(uri)
        request.Method = WebRequestMethods.Http.Post
        request.ContentLength = data.Length
        request.Headers("Authorization") = "Basic " & authInfo
        request.ContentType = "application/x-www-form-urlencoded"
        Dim writer As New StreamWriter(request.GetRequestStream)
        writer.Write(data)
        writer.Close()
        Try
            Dim oResponse As HttpWebResponse = request.GetResponse()
            Dim reader As New StreamReader(oResponse.GetResponseStream())
            Dim tmp As String = reader.ReadToEnd()
            oResponse.Close()
            If oResponse.StatusCode = "200" Then
                Return tmp
            Else
                Throw New ApplicationException("Error Occurred, Code: " & oResponse.StatusCode)
            End If


        Catch ex As WebException
            If ex.Status = WebExceptionStatus.ProtocolError Then
                Throw New ApplicationException("ISSUES")
                ' Throw New ApplicationException(ex.Response, HttpWebResponse).StatusCode & " : " & CType(ex.Response, HttpWebResponse).StatusDescription
            Else
                Throw New ApplicationException(ex.Message)
            End If
        End Try
    End Function


    ''' <summary>
    ''' Send DELETE API request
    ''' </summary>
    ''' <param name="data">Form Variables to send with request</param>
    ''' <param name="apiURI">URI after (Must include starting /)</param>
    ''' <returns>JSON FROM stripe</returns>
    ''' <remarks></remarks>
    Private Function sendDELETEReq(ByVal data As String, ByVal apiURI As String) As String
        Dim uri As String = RestProctocal & RestAPI & apiURI
        Dim authInfo As String = acctToken & ":"
        authInfo = Convert.ToBase64String(Encoding.[Default].GetBytes(authInfo))

        Dim request As HttpWebRequest = HttpWebRequest.Create(uri)
        request.Method = "DELETE"
        request.ContentLength = data.Length
        request.Headers("Authorization") = "Basic " & authInfo
        request.ContentType = "application/x-www-form-urlencoded"
        Dim writer As New StreamWriter(request.GetRequestStream)
        writer.Write(data)
        writer.Close()
        Try
            Dim oResponse As HttpWebResponse = request.GetResponse()
            Dim reader As New StreamReader(oResponse.GetResponseStream())
            Dim tmp As String = reader.ReadToEnd()
            oResponse.Close()
            If oResponse.StatusCode = "200" Then
                Return tmp
            Else
                Throw New ApplicationException("Error Occurred, Code: " & oResponse.StatusCode)
            End If
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.ProtocolError Then
                Throw New ApplicationException("Problem: " & CType(ex.Response, HttpWebResponse).StatusCode & vbNewLine & CType(ex.Response, HttpWebResponse).StatusDescription)
                ' Throw New ApplicationException(ex.Response, HttpWebResponse).StatusCode & " : " & 
            Else
                Throw New ApplicationException(ex.Message)
            End If
        End Try
    End Function


    Public Function GetEpoch(dDate As DateTime) As Long
        Dim epoch As New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        Dim stringer As TimeSpan = dDate.Subtract(epoch)
        Return stringer.TotalSeconds
    End Function

End Class
