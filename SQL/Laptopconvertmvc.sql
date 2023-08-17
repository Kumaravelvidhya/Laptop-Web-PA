--create table
create table Laptop
(
Id int primary key identity(1,1),
Name nvarchar (200) not null,
Email nvarchar(200) not null,
Message nvarchar (500) not null
)
select * from Laptop
drop table Laptop
--insert records
create or alter procedure insertlaptop(@Name nvarchar(200),@Email nvarchar(200),@Message nvarchar(500))
as
begin 
insert into Laptop(Name,Email,Message)values(@Name,@Email,@Message)
end
exec insertlaptop 'vidhya','vidhya34@gmail.com','good'
Create procedure selectlaptop
as
begin
select * from Laptop
end
exec selectlaptop