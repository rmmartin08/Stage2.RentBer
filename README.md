# Stage2.RentBer

## Welcome to RentBer

Hello, and welcome to RentBer, from the same company that brought you GrillBer!

RentBer allows renters and property owners to share information about their properties, rental agreements, and payments.

We have some initial work done on the front and the back end, but we need your help to make RentBer even Better!


## ERD
![ERD](/ERD.jpg)
 
## RentBer Requirements:

1. Renter's should be able to see their payment history **_Top Priority!__ Do this first!**
    - This should happen on the renterPage
    - The list of unpaid payments should be in the Due Rental Payments
        - Unpaid payments have a property called IsPaid
    - The list of paid payments should be in the Paid Rental Payments
    - Each payment should have the following properties displayed:
        - Due Date
        - Amount Paid/To Pay
        - Owner Name
    - Payed payments should also include Date Paid
1. Renter's should be able to mark a due rental payment as paid
    - The Date Paid should be today's date.
1. A bug has been discovered with some zip codes.
    - Using the provided `Rentber.db` file and visit http://127.0.0.1:8080/renterPage/renterPage.html?renterId=f32b4b09-6809-40b7-b2e6-eb7239119ac9
        - This should be the renter page of Myrtia Maggill'Andreis
    - Look at the property details. All zip codes should be 5 digits, and Myrtia's zip code should be `02203`
    - Figure out why the zip code is missing the leading zero, and provide a solution to display and store them correctly.
1. Owners should be able to mark a payment as paid on the owner page
1. Users should be able to create new Owners and Renters
    - Use the provided location on the index.html page
1. Owners should be able to add the following on their page
    - Properties
    - Upcoming Payments
    - New Rentals Agreements 

