create database OtobusOtomasyonu
use OtobusOtomasyonu

create table Admin (
	kullanici varchar(max),
	sifre int

)
drop table Admin
insert into Admin(kullanici,sifre)
values('Admin',123456)

create table Otobus(
	id int primary key,
	firma varchar(max),
	kalkacak varchar(max),
	inecek varchar(max),
	saat time,
	fiyat int,
	koltukid int identity(1,1),
	resim image
)
drop table Otobus

create table koltuklar(
	koltukid int identity(1,1) primary key,
	koltukno int,
	durum varchar(max)
)


INSERT INTO koltuklar (koltukno, durum)
VALUES 
    (1, 'Boþ'),
    (2, 'Boþ'),
    (3, 'Boþ'),
    (4, 'Boþ'),
    (5, 'Boþ'),
    (6, 'Boþ'),
    (7, 'Boþ'),
    (8, 'Boþ'),
    (9, 'Boþ'),
    (10, 'Boþ'),
    (11, 'Boþ'),
    (12, 'Boþ'),
    (13, 'Boþ'),
    (14, 'Boþ'),
    (15, 'Boþ'),
    (16, 'Boþ'),
    (17, 'Boþ'),
    (18, 'Boþ'),
    (19, 'Boþ'),
    (20, 'Boþ'),
    (21, 'Boþ'),
    (22, 'Boþ'),
    (23, 'Boþ'),
    (24, 'Boþ'),
    (25, 'Boþ'),
    (26, 'Boþ'),
    (27, 'Boþ'),
    (28, 'Boþ'),
    (29, 'Boþ'),
    (30, 'Boþ'),
    (31, 'Boþ'), 
    (32, 'Boþ'), 
    (33, 'Boþ'),
    (34, 'Boþ'),
    (35, 'Boþ'), 
    (36, 'Boþ'), 
    (37, 'Boþ'), 
    (38, 'Boþ'); 

	select * from Otobus 
	cross join koltuklar 

	SELECT K.koltukno, K.durum, O.firma, O.kalkacak, O.inecek, O.saat, O.fiyat FROM Otobus O JOIN koltuklar K ON O.koltukid =6
	SELECT K.koltukno, K.durum, O.firma, O.kalkacak, O.inecek, O.saat, O.fiyat FROM Otobus O cross JOIN koltuklar K 

	update  koltuklar SET durum = 'Dolu' where koltukno = 6