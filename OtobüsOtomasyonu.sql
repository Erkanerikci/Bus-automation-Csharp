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
    (1, 'Bo�'),
    (2, 'Bo�'),
    (3, 'Bo�'),
    (4, 'Bo�'),
    (5, 'Bo�'),
    (6, 'Bo�'),
    (7, 'Bo�'),
    (8, 'Bo�'),
    (9, 'Bo�'),
    (10, 'Bo�'),
    (11, 'Bo�'),
    (12, 'Bo�'),
    (13, 'Bo�'),
    (14, 'Bo�'),
    (15, 'Bo�'),
    (16, 'Bo�'),
    (17, 'Bo�'),
    (18, 'Bo�'),
    (19, 'Bo�'),
    (20, 'Bo�'),
    (21, 'Bo�'),
    (22, 'Bo�'),
    (23, 'Bo�'),
    (24, 'Bo�'),
    (25, 'Bo�'),
    (26, 'Bo�'),
    (27, 'Bo�'),
    (28, 'Bo�'),
    (29, 'Bo�'),
    (30, 'Bo�'),
    (31, 'Bo�'), 
    (32, 'Bo�'), 
    (33, 'Bo�'),
    (34, 'Bo�'),
    (35, 'Bo�'), 
    (36, 'Bo�'), 
    (37, 'Bo�'), 
    (38, 'Bo�'); 

	select * from Otobus 
	cross join koltuklar 

	SELECT K.koltukno, K.durum, O.firma, O.kalkacak, O.inecek, O.saat, O.fiyat FROM Otobus O JOIN koltuklar K ON O.koltukid =6
	SELECT K.koltukno, K.durum, O.firma, O.kalkacak, O.inecek, O.saat, O.fiyat FROM Otobus O cross JOIN koltuklar K 

	update  koltuklar SET durum = 'Dolu' where koltukno = 6