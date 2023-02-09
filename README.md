# HelioGaming
REST API project for fun


Implement an application in C# \ .Net to manage the following two entities: companies and persons.

Company
- Add
o Company Name (string) (Unique)
o Registration Date (date)
- View: display / retrieve all
o Also calculate number of persons linked to the company

Person
- Add
o Full Name (string)
o Phone number (string)
o Address (string)
o Company (drop down / link)
- View All: display / retrieve all
o Search: to check through all fields including Company Name
o View Profile
▪ Edit
▪ Remove

- Wild card: opens a random profile’s edit page.
Further instructions:
- Company needs to be stored in a separate table and linked via a foreign key.
- Wild card: random pick functionality should be implemented in backend.
- Search: needs to work on all fields including Company.
