-- SELECT s�tunAdlar� from table
-- * all => Tamam�
-- metinsel de�erler '' tek t�rnak aras�na yaz�l�r.
-- or => ve demek
-- and => ve demek

-- SELECT KOMUTU

Select * from TblKitaplar
-- TblKitaplar �n t�m elamanlar�n� yazd�r�r

Select Kitapad,Yazar from TblKitaplar
-- TblKitaplar tablosunun sadece Kitapad ve Yazar s�tunlar�n� yazd�r�r.

Select Sayfa from TblKitaplar
-- TblKitaplar tablosunun sadece Sayfa s�tununu yazd�r�r.

-- �ARTLI SORGULAMALAR
-- Where �art� yazar�z

Select * from TblKitaplar where KitapAd='yaban'
-- TblKitaplar tablosunda KitapAd� s�tununda 'yaban' i�eren verileri t�m sat�rlar�yla getir.

Select * from TblKitaplar where Yazar='jules verne'

Select * from TblKitaplar where Sayfa > 250
-- sayfa say�s� 250 �st� kitaplar

Select * from TblKitaplar where Yazar='jules verne' or Yazar='dostoyevski'

Select * from TblKitaplar where yazar='charles dickens' and KitapId=8


-- INSERT KOMUTU
-- Insert into tabloIsmi (column1,column2...) values (v1,v2,..)
-- Parametreler hiyerar�ik s�ralamaya sahiptir

Select * from TblKitaplar

insert into TblKitaplar(KitapAd,Yazar,Sayfa) values('Anadolu Notlar�','Re�at Nuri G�ltekin','230')
-- insert into TabloAdi(buraya eklenecek s�t�nlar� yazd�k) values(s�tunlar� s�ras�na g�re de�er atamas� yap�yoruz)

insert into TblKitaplar(KitapAd) values('Siyah Lale')
-- Sadece KitapAd a ekleme yapt�k di�er bilgiler null olarak kay�t edildi.

-- DELETE KOMUTU
-- Delete from tabloAdi where ...
-- Id yazmay� sak�n unutma..

Delete from TblKitaplar where KitapId=10
-- 10 numaral� �d kitab� sil.

Select * from TblKitaplar
insert into TblKitaplar(KitapAd) values('Palto')

-- UPDATE KOMUTU
-- update tabloAdi set column=value,column2=value2 ....
update TblKitaplar set Yazar='Nikolay Gogol', Sayfa=180 where KitapAd='Palto'
-- KitapAd = palto olan sat�ra Yazar ve Sayfa bilgisi ekledik.

-- Aggregate Nedir?

-- K�meleme anlam�na gelmektedir.
-- Count => Bir tabloda istenen de�erin ka� adet oldu�unu verir.
-- Sum => Bir s�tuna ait de�erlerin toplam�n� verir.
-- Avg => Ortalama
-- Min => Minimumu
-- Max => Maksimum

-- COUNT FONKS�YONU
-- Bir tabloda istenen nitelikteki de�erin ka� adet oldu�unu veren komuttur.
-- Select count(*) ftom tabloAdi

Select COUNT(*) from TblKitaplar where yazar='Jules Verne'

-- Alias
-- Takma Ad
Select count(*) as 'Kitap Say�s�' from TblKitaplar
-- as yap�s� ile ilgili sat�ra ba�l�k atad�k.

-- SUM FONKS�YONU
-- Bir tabloda ilgili s�tuna ait de�erlerin toplam�n� hesaplayan fonksiyondur.
-- Select sum(s�tunAd�) from TabloAdi

-- decimal(4,2) => virg�l�n sa��ndaki de�er say�n�n virg�lden sonra ka� basamak alaca��n� belirtir.
-- solundaki de�er ise say�n�n virg�lden sonraki de�er dahil toplam ka� basamak alaca��n� belirtir.

Select * from TblKitaplar

select sum(fiyat) as 'Toplam fiyat' from TblKitaplar

Select sum(fiyat) From TblKitaplar where Yazar='jules verne'

-- AVG FONKS�YONU
-- Bir tabloda ilgili s�tuna ait de�erlerin ortlamas�n� hesaplayan fonksiyondur.
-- Select avg(s�tunAd�) from TabloAdi

Select avg(fiyat) as 'Ortalama Fiyat' from TblKitaplar
-- TblKitaplar tablosunun fiyatlar�n�n ortalamas�

Select avg(fiyat) as 'Ortalama Fiyat' from TblKitaplar where Yazar='Jules Verne'
-- TblKitaplar tablosunun Yazar da Jules Verne olan kitaplar�n ortalamas�

-- M�N ve MAX FONKS�YONU
-- Bir tabloda ilgili s�tuna ait de�erler i�inde en k���k ve en b�y�k de�erleri bulan donksiyondur.
-- Select Min(s�tunAd�) from TabloAdi
-- Select Max(s�tunAd�) from TabloAdi

Select Min(fiyat) as 'En D���k fiyat',Max(fiyat) as 'En Y�ksek Fiyat' from TblKitaplar
-- TblKitaplar da en d���k ve en y�ksek fiyat� bulduk

Select max(KitapAd) from TblKitaplar
-- Alfabetik olarak Z'ye en yak�n hangisiyse onu getirir. 

Select * from TblYayinevi

-- �� ��e Sorgu
Select * from TblKitaplar where Fiyat=(select min(fiyat) from TblKitaplar)

Update TblKitaplar Set Fiyat=Fiyat+1 where Yay�nevi=(Select Id from TblYayinevi where Ad='Jupiter')

-- Alt Sorgu Nedir?
-- Bir tabloda ekleme, silme, g�ncelleme ve listeleme i�lemlerinin kendisine veya bir ba�ka tabloya g�re yap�lmas�d�r.

Select * from TblKitaplar where Yay�nevi=(select Id from TblYayinevi where Ad='Jupiter')

-- Grupland�rma Nedir?
-- Tablolar�m�z� belirli kriterlere g�re grupland�rmak istedi�imiz zaman kulland���m�z yap�lard�r.
-- Komut = Group By

update TblKitaplar set Yazar='Alexander Dumas' where KitapId=9

Select Yazar, Count(*) 'Kitap Say�s�' from TblKitaplar group by Yazar

select Yay�nevi, count(*) from TblKitaplar group by Yay�nevi

-- �li�ki Nedir?
-- Tablolar aras�nda yap�lacak ba�lant� ile;
-- Veri tekrar�n�n �nlenmesi
-- Veri taban�na olan hakimiyetin artt�r�lmas�
-- Veri tutarl�l���n�n sa�lanmas�
-- Verilere daha h�zl� eri�imin sa�lanmas�
-- i� y�k�n�n azalt�lmas� gibi olanaklar sa�layan veri taban� bile�enidir.

-- �li�ki T�rleri Nelerdir?

-- Bire - bir ili�ki
-- Sadece bir �r�ne ait - Tc

-- Bire - �ok ili�ki

-- �oka - �ok ili�ki

--	SQL Komutlar�
-- SqlConnection : Ba�lant� S�n�f�
-- SqlCommand : Komut S�n�f�
-- Sql DataAdapter : K�pr� S�n�f�
-- DataTable : Veri Tablosu

-- Birle�tirmeler
-- SQL : Join
-- Birden fazla tabloyu tek tablo gibi g�sermek veya bir tabloda bulunan ID alan�n�n di�er tablodaki isim de�erine kar��l�k gelecek �ekilde haz�rlanmas�d�r.

-- Inner Join i kullanaca��z.
-- Select column1, column2... from table Inner Join Table2
-- On Table1.ColumnY=Table22.ColumunY

select UrunId,UrunAd, Stok, AlisFiyat, SatisFiyat, Ad from TblUrunler
Inner Join TblKategori
On TblUrunler.Kategori=TblKategori.Id

Select * from TblUrunler where Stok=(select max(stok) from TblUrunler)

Select Count(*) from TblUrunler where Kategori=(select Id from TblKategori where Ad='Beyaz E�ya')

Select Stok*(SatisFiyat - AlisFiyat) from TblUrunler where UrunAd='Laptop'

select UrunAd, Stok, AlisFiyat,SatisFiyat,(SatisFiyat-AlisFiyat) as 'Bir �r�n�n kar oran�', stok*(SatisFiyat-AlisFiyat) as 'Toplam Stokla �arp�lan sonu�' from TblUrunler where Kategori=(Select ID From TblKategori where Ad='Beyaz E�ya')

Select sum(stok*(SatisFiyat-AlisFiyat)) as 'Toplam Stokla �arp�lan Sonu�' from TblUrunler where Kategori=(Select ID From TblKategori where Ad='Beyaz E�ya')



select Ad, Count(*) From TblUrunler inner join TblKategori 
on TblUrunler.Kategori=TblKategori.Id
Group By Ad

