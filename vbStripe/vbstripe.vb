#Region " Imports "
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
#End Region

Public Class vbstripe

    Public acctToken As String = String.Empty
    Public RestProctocal As String = "https://"
    Public RestAPI As String = "api.stripe.com/v1"
    Public stripeError As sError

    ' #### CUSTOMERS ####

#Region "Customers : Create"
    ''' <summary>
    ''' Create A new customer. No information is required, I would suggest using email address just to have some kind of information attached to the customer. If you provide a Credit Card Number you need to provide the expiration information.
    ''' </summary>
    ''' <param name="ccNumber">Credit Card Number: The card number, as a string without any separators.</param>
    ''' <param name="ccExp_Month">Credit Card Expiration Month: Two digit number representing the card's expiration month.</param>
    ''' <param name="ccExp_Year">Credit Card Expiration Year: Four digit number representing the card's expiration year.</param>
    ''' <param name="ccCVC">Credit Card CVC: Card security code</param>
    ''' <param name="ccName">Name on Credit Card: Cardholder's full name.</param>
    ''' <param name="ccAddress_Line1">Credit Card Address1 on File, optional</param>
    ''' <param name="ccAddress_Line2">Credit Card Address2 on File, optional</param>
    ''' <param name="ccAddress_Zip">Credit Card Zip on File, optional</param>
    ''' <param name="ccAddress_State">Credit Card State on File, optional</param>
    ''' <param name="ccAddress_Country">Credit Card Country on File, optional</param>
    ''' <param name="description">An arbitrary string which you can attach to a customer object. It is displayed alongside the customer in the web interface. </param>
    ''' <param name="coupon">If you provide a coupon code, the customer will have a discount applied on all recurring charges. Charges you create through the API will not have the discount.</param>
    ''' <param name="email">The customer's email address. It is displayed alongside the customer in the web interface and can be useful for searching and tracking. </param>
    ''' <param name="plan">The identifier of the plan to subscribe the customer to. If provided, the returned customer object has a 'subscription' attribute describing the state of the customer's subscription. </param>
    ''' <param name="trial_end">UTC integer timestamp representing the end of the trial period the customer will get before being charged for the first time. If set, trial_end will override the default trial period of the plan the customer is being subscribed to. </param>
    ''' <returns>Returns a sCustomer (Stripe Customer) result.</returns>
    ''' <remarks>https://stripe.com/docs/api#create_customer</remarks>
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
#End Region

#Region "Customers : Delete"
    ''' <summary>
    ''' Delete's a customer using CustomerID
    ''' </summary>
    ''' <param name="customerId">The identifier of the customer to be deleted. </param>
    ''' <returns>Boolean - true = Deleted | false = something went wrong</returns>
    ''' <remarks>https://stripe.com/docs/api#delete_customer</remarks>
    Public Function deleteCustomer(customerId As String) As Boolean
        If acctToken.Length < 10 Then
            Throw New ApplicationException("API not provided.")
        End If
        If customerId.Length < 3 Then
            Throw New ApplicationException("Customer ID not provided.")
        End If

        Dim apiURI As String = "/customers/" & customerId
        Dim data As String = String.Empty
        Try
            sendDELETEReq(data, apiURI)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
#End Region

#Region "Customers : Update  ### NEEDS COMMENTS ###"
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

#End Region

#Region "Customers : Retrieve - N/A"

#End Region

#Region "Customers : List All - N/A"

#End Region


    ' #### Subscriptions ####

#Region "Subscriptions : Update  ### NEEDS COMMENTS ###"
    Public Function update_CustomerSubscription(customerId As String, plan As String, Optional coupon As String = "",
                                        Optional prorate As String = "", Optional trial_end As String = "", Optional ccToken As String = "",
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

        If ccNumber.Length = 16 And ccToken.Length < 1 Then
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
        ElseIf ccToken.Length > 5 Then
            data &= "&card=" & ccToken
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
#End Region

#Region "Subscriptions : Delete  #### NEEDS COMMENTS ###"
    Public Function delete_CustomerSubscription(customerID As String, Optional at_period_end As String = "") As sSubscription
        If acctToken.Length < 10 Then
            Throw New ApplicationException("API not provided.")
        End If
        If customerID.Length < 3 Then
            Throw New ApplicationException("Customer ID not provided.")
        End If

        Dim apiURI As String = "/customers/" & customerID & "/subscription"
        Dim data As String = String.Empty
        If at_period_end.Length > 0 Then data = "at_period_end=" & at_period_end
        Dim returnedData As String = sendDELETEReq(data, apiURI)
        Dim subScriber As sSubscription = JsonConvert.DeserializeObject(Of sSubscription)(returnedData)
        Return subScriber
    End Function
#End Region

    ' #### Charges ####

#Region "Charges : Create   #### NEEDS COMMENTS ###"
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

    Public Function create_ChargeToken(amount As Integer, currency As String, token As String, Optional ccName As String = "", Optional description As String = "") As sCharge

        If acctToken.Length < 10 Then
            Throw New ApplicationException("API not provided.")
        End If
        If amount < 0 Then
            Throw New ApplicationException("Amount cannot be less than 0")
        End If
        If currency.Length < 1 Then
            currency = "usd"
        End If
        If token.Length < 14 Then
            Throw New ApplicationException("Token Invalid")
        End If

        Dim apiURI As String = "/charges"
        Dim data As String = String.Empty

        data = "amount=" & amount
        data &= "&currency=" & currency
        data &= "&card=" & token
        If Len(description) > 0 Then data &= "&description=" & description
        Dim returnedData As String = sendReq(data, apiURI)
        Dim charge As sCharge = JsonConvert.DeserializeObject(Of sCharge)(returnedData)
        Return charge
    End Function
#End Region

#Region "Charges : Retrieve - N/A"

#End Region

#Region "Charges : List - N/A"

#End Region

#Region "Charges : Refund"
    ''' <summary>
    ''' Creates a refund for any charge that has taken place.
    ''' </summary>
    ''' <param name="id">The identifier of the charge to be refunded. </param>
    ''' <param name="amount">OPTIONAL, A positive integer in cents representing how much of this charge to refund. Can only refund up to the unrefunded amount remaining of the charge. </param>
    ''' <returns>sCharge object</returns>
    ''' <remarks>Amount defaults to entire charge.</remarks>
    Function refundCharge(id As String, Optional amount As Integer = 0) As sCharge
        If acctToken.Length < 10 Then
            Throw New ApplicationException("API not provided.")
        End If
        Dim apiURI As String = "/charges/" & id & "/refund"
        Dim data As String = String.Empty
        If amount <> 0 Then data = "amount=" & amount
        ' # vvvv Perform Action vvvv
        Dim returnedData As String = sendReq(data, apiURI)
        Dim charge As sCharge = JsonConvert.DeserializeObject(Of sCharge)(returnedData)
        Return charge
    End Function
#End Region

    ' #### Tokens - COMING SOON ####

#Region "Tokens : Create - N/A"
    Public Function create_cardToken(ccNumber As String, ccExp_Month As String, ccExp_Year As String,
                              Optional ccCVC As String = "", Optional ccName As String = "", Optional ccAddress_Line1 As String = "",
                              Optional ccAddress_Line2 As String = "", Optional ccAddress_Zip As String = "",
                              Optional ccAddress_State As String = "",
                              Optional ccAddress_Country As String = "") As sToken
        If acctToken.Length < 10 Then
            Throw New ApplicationException("API not provided.")
        End If

        If ccNumber.Length <> 16 Then
            Throw New ApplicationException("Credit Card Number must be 16 digits")
        End If

        Dim apiURI As String = "/tokens"
        Dim data As String = String.Empty
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
        Dim returnedData As String = sendReq(data, apiURI)
        Dim token As sToken = JsonConvert.DeserializeObject(Of sToken)(returnedData)
        Return token
    End Function
#End Region

#Region "Tokens : Retrieve - N/A"

#End Region

    ' #### Plans - COMING SOON ####


    ' #### Invoices - COMING SOON ####


    ' #### Coupons - COMING SOON #####


    ' #### Events - COMING SOON #####

    ' ### FUNCTIONS ###

#Region "API HTTP Requests"
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
                Dim read As New StreamReader(ex.Response.GetResponseStream())
                Dim tmp As String = read.ReadToEnd()
                read.Close()
                stripeError = JsonConvert.DeserializeObject(Of sError)(tmp)
                ' Throw New ApplicationException("ISSUES")
                Throw New ApplicationException(CType(ex.Response, HttpWebResponse).StatusCode & " : " & tmp)
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
#End Region

#Region "Misc Functions - Epoch Date Converters, etc..."
    Public Function GetEpoch(dDate As DateTime) As Long
        Dim epoch As New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        Dim stringer As TimeSpan = dDate.Subtract(epoch)
        Return stringer.TotalSeconds
    End Function
#End Region

End Class
