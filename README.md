# ConsignmentShop
IAmTimCorey tutorial - Creating a C# Application: From idea to finished product

Create an application that can be used by consignment shops to run their business. You need to
know who the Individuals/Vendors are who have Items in the shop and you need to associate
thses vendors with their items. Each vendor should be assigned a standard commission, but
that may need to be changed on a per-vendor basis. The applicatiion should track how much
should be paid to each vendor as well as how much money  should be paid to the store.

Requirements:
1. list of Vendors
2. List of Items per vendor
3. Each vendor should have a default commission rate
4. Commissions can change
5. Track how much to pay the vendor
6. Track how much to pay the stor

Classes:

Vendor
FirstName: string
LastName: string
Commission: double
PaymentDue: decimal

Item
Title: string
Description: string
Price: decimal
Sold: boolean
PaymentDistributed: boolean
Owner: Vendor

Store
Name: string
Vendors: Vendor
Items: Item
