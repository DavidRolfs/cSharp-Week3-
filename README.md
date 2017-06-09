
# Hair Salon

#### _June 09, 2017_

#### By _**David Rolfs**_

## Description

This application will let the owner manage Stylist and Client information using sql database. The user is able to add stylists to the database and assign specific clients to each employee. The user can update, edit, and delete clients.

## Setup/Installation Requirements

* Go to Github repository page https://github.com/DavidRolfs/cSharp-Week3-
* Click the "download or clone" button and copy the link.
* In your computers terminal type "git clone" & paste the copied link.
* Once downloaded enter dnu restore into the terminal.
* enter these commands into the terminal to create the database
* CREATE DATABASE hair_salon;
* go
* use hair_salon;
* go
* CREATE TABLE stylists (id Int Identity(1,1), name VARCHAR(255));
* go
* CREATE TABLE clients (id Int Identity(1,1), name VARCHAR(255), stylist_id INT);
* go
* quit
* Then enter dnx kestrel into the terminal.
* Open web browser of your choice and go to http://localhost:5004/ to view root page.

## Specs
| Description |
|-------------|
| User can View all Stylists |
| User can click on a Stylist and view all of their clients |
| User can add new Stylist |
| User can add clients to specific stylists |
| User can edit client information |
| User can delete a client |

## Support and contact details

rolfs97@yahoo.com

## Technologies Used

C#, Nancy, HTML, CSS, Bootstrap, Razor, .Net, xUnit, SQL
### License

MIT

Copyright (c) 2017 **_David Rolfs_**
