create table CreditInfo (
	Id int IDENTITY(1,1) primary key,
	IdentityNumber varchar(11) not null,
	ApplicationDate date not null,
	CreditLimit int not null
);