use DBCrud

create database DBCrud

create table employeers (
id_employeer int primary key identity,
name varchar(50),
email varchar(50),
salary int 


)

select * from employeers