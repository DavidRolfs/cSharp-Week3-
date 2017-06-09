CREATE DATABASE hair_salon;
go
use hair_salon;
go
CREATE TABLE stylists (id Int Identity(1,1), name VARCHAR(255));
go
CREATE TABLE clients (id Int Identity(1,1), name VARCHAR(255), stylist_id INT);
go
