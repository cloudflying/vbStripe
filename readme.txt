vbStripe Stripe API Library

Class library created for .net 3.5 or higher. 

Instructions for use:

Imports Newtonsoft.Json
Imports vbStripe

Dim stripe As New vbStripe.vbstripe
stripe.acctToken = API KEY

### Create New Customer
Dim newCustomer As vbStripe.sCustomer = stripe.create_Customer("4242424242424242", "12", "2015", "123", "John Doe", "123 Village Rd", , "06281", "CT", "USA", "John Doe Account", , "email@email.com")


...more stuff coming soon

Justin

