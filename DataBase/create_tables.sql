create database Stock;
use Stock;

create table Products
(
  id int AUTO_INCREMENT primary KEY,
  product_type varchar(15),
  product_name varchar(15),
  stock_quantity int,
  purchase_price int,
  sale_price int,
  manufacturer varchar(15)
);

create table Auths
(
  id int AUTO_INCREMENT primary KEY,
  login varchar(15) not null,
  password varchar(15) not null
);