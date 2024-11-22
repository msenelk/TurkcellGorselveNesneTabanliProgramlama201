-- SELECT sütunAdlarý from table
-- * all => Tamamý
-- metinsel deðerler '' tek týrnak arasýna yazýlýr.
-- or => ve demek
-- and => ve demek

-- SELECT KOMUTU

Select * from TblKitaplar
-- TblKitaplar ýn tüm elamanlarýný yazdýrýr

Select Kitapad,Yazar from TblKitaplar
-- TblKitaplar tablosunun sadece Kitapad ve Yazar sütunlarýný yazdýrýr.

Select Sayfa from TblKitaplar
-- TblKitaplar tablosunun sadece Sayfa sütununu yazdýrýr.

-- ÞARTLI SORGULAMALAR
-- Where þartý yazarýz

Select * from TblKitaplar where KitapAd='yaban'
-- TblKitaplar tablosunda KitapAdý sütununda 'yaban' içeren verileri tüm satýrlarýyla getir.

Select * from TblKitaplar where Yazar='jules verne'

Select * from TblKitaplar where Sayfa > 250
-- sayfa sayýsý 250 üstü kitaplar

Select * from TblKitaplar where Yazar='jules verne' or Yazar='dostoyevski'

Select * from TblKitaplar where yazar='charles dickens' and KitapId=8


-- INSERT KOMUTU
-- Insert into tabloIsmi (column1,column2...) values (v1,v2,..)
-- Parametreler hiyerarþik sýralamaya sahiptir

Select * from TblKitaplar

insert into TblKitaplar(KitapAd,Yazar,Sayfa) values('Anadolu Notlarý','Reþat Nuri Gültekin','230')
-- insert into TabloAdi(buraya eklenecek sütünlarý yazdýk) values(sütunlarý sýrasýna göre deðer atamasý yapýyoruz)

insert into TblKitaplar(KitapAd) values('Siyah Lale')
-- Sadece KitapAd a ekleme yaptýk diðer bilgiler null olarak kayýt edildi.

-- DELETE KOMUTU
-- Delete from tabloAdi where ...
-- Id yazmayý sakýn unutma..

Delete from TblKitaplar where KitapId=10
-- 10 numaralý ýd kitabý sil.

Select * from TblKitaplar
insert into TblKitaplar(KitapAd) values('Palto')

-- UPDATE KOMUTU
-- update tabloAdi set column=value,column2=value2 ....
update TblKitaplar set Yazar='Nikolay Gogol', Sayfa=180 where KitapAd='Palto'
-- KitapAd = palto olan satýra Yazar ve Sayfa bilgisi ekledik.

-- Aggregate Nedir?

-- Kümeleme anlamýna gelmektedir.
-- Count => Bir tabloda istenen deðerin kaç adet olduðunu verir.
-- Sum => Bir sütuna ait deðerlerin toplamýný verir.
-- Avg => Ortalama
-- Min => Minimumu
-- Max => Maksimum

-- COUNT FONKSÝYONU
-- Bir tabloda istenen nitelikteki deðerin kaç adet olduðunu veren komuttur.
-- Select count(*) ftom tabloAdi

Select COUNT(*) from TblKitaplar where yazar='Jules Verne'

-- Alias
-- Takma Ad
Select count(*) as 'Kitap Sayýsý' from TblKitaplar
-- as yapýsý ile ilgili satýra baþlýk atadýk.

-- SUM FONKSÝYONU
-- Bir tabloda ilgili sütuna ait deðerlerin toplamýný hesaplayan fonksiyondur.
-- Select sum(sütunAdý) from TabloAdi

-- decimal(4,2) => virgülün saðýndaki deðer sayýnýn virgülden sonra kaç basamak alacaðýný belirtir.
-- solundaki deðer ise sayýnýn virgülden sonraki deðer dahil toplam kaç basamak alacaðýný belirtir.

Select * from TblKitaplar

select sum(fiyat) as 'Toplam fiyat' from TblKitaplar

Select sum(fiyat) From TblKitaplar where Yazar='jules verne'

-- AVG FONKSÝYONU
-- Bir tabloda ilgili sütuna ait deðerlerin ortlamasýný hesaplayan fonksiyondur.
-- Select avg(sütunAdý) from TabloAdi

Select avg(fiyat) as 'Ortalama Fiyat' from TblKitaplar
-- TblKitaplar tablosunun fiyatlarýnýn ortalamasý

Select avg(fiyat) as 'Ortalama Fiyat' from TblKitaplar where Yazar='Jules Verne'
-- TblKitaplar tablosunun Yazar da Jules Verne olan kitaplarýn ortalamasý

-- MÝN ve MAX FONKSÝYONU
-- Bir tabloda ilgili sütuna ait deðerler içinde en küçük ve en büyük deðerleri bulan donksiyondur.
-- Select Min(sütunAdý) from TabloAdi
-- Select Max(sütunAdý) from TabloAdi

Select Min(fiyat) as 'En Düþük fiyat',Max(fiyat) as 'En Yüksek Fiyat' from TblKitaplar
-- TblKitaplar da en düþük ve en yüksek fiyatý bulduk

Select max(KitapAd) from TblKitaplar
-- Alfabetik olarak Z'ye en yakýn hangisiyse onu getirir. 

Select * from TblYayinevi

-- Ýç Ýçe Sorgu
Select * from TblKitaplar where Fiyat=(select min(fiyat) from TblKitaplar)

Update TblKitaplar Set Fiyat=Fiyat+1 where Yayýnevi=(Select Id from TblYayinevi where Ad='Jupiter')

-- Alt Sorgu Nedir?
-- Bir tabloda ekleme, silme, güncelleme ve listeleme iþlemlerinin kendisine veya bir baþka tabloya göre yapýlmasýdýr.

Select * from TblKitaplar where Yayýnevi=(select Id from TblYayinevi where Ad='Jupiter')

-- Gruplandýrma Nedir?
-- Tablolarýmýzý belirli kriterlere göre gruplandýrmak istediðimiz zaman kullandýðýmýz yapýlardýr.
-- Komut = Group By

update TblKitaplar set Yazar='Alexander Dumas' where KitapId=9

Select Yazar, Count(*) 'Kitap Sayýsý' from TblKitaplar group by Yazar

select Yayýnevi, count(*) from TblKitaplar group by Yayýnevi

-- Ýliþki Nedir?
-- Tablolar arasýnda yapýlacak baðlantý ile;
-- Veri tekrarýnýn önlenmesi
-- Veri tabanýna olan hakimiyetin arttýrýlmasý
-- Veri tutarlýlýðýnýn saðlanmasý
-- Verilere daha hýzlý eriþimin saðlanmasý
-- iþ yükünün azaltýlmasý gibi olanaklar saðlayan veri tabaný bileþenidir.

-- Ýliþki Türleri Nelerdir?

-- Bire - bir iliþki
-- Sadece bir ürüne ait - Tc

-- Bire - çok iliþki

-- Çoka - çok iliþki

--	SQL Komutlarý
-- SqlConnection : Baðlantý Sýnýfý
-- SqlCommand : Komut Sýnýfý
-- Sql DataAdapter : Köprü Sýnýfý
-- DataTable : Veri Tablosu

-- Birleþtirmeler
-- SQL : Join
-- Birden fazla tabloyu tek tablo gibi gösermek veya bir tabloda bulunan ID alanýnýn diðer tablodaki isim deðerine karþýlýk gelecek þekilde hazýrlanmasýdýr.

-- Inner Join i kullanacaðýz.
-- Select column1, column2... from table Inner Join Table2
-- On Table1.ColumnY=Table22.ColumunY

select UrunId,UrunAd, Stok, AlisFiyat, SatisFiyat, Ad from TblUrunler
Inner Join TblKategori
On TblUrunler.Kategori=TblKategori.Id

Select * from TblUrunler where Stok=(select max(stok) from TblUrunler)

Select Count(*) from TblUrunler where Kategori=(select Id from TblKategori where Ad='Beyaz Eþya')

Select Stok*(SatisFiyat - AlisFiyat) from TblUrunler where UrunAd='Laptop'

select UrunAd, Stok, AlisFiyat,SatisFiyat,(SatisFiyat-AlisFiyat) as 'Bir ürünün kar oraný', stok*(SatisFiyat-AlisFiyat) as 'Toplam Stokla Çarpýlan sonuç' from TblUrunler where Kategori=(Select ID From TblKategori where Ad='Beyaz Eþya')

Select sum(stok*(SatisFiyat-AlisFiyat)) as 'Toplam Stokla Çarpýlan Sonuç' from TblUrunler where Kategori=(Select ID From TblKategori where Ad='Beyaz Eþya')



select Ad, Count(*) From TblUrunler inner join TblKategori 
on TblUrunler.Kategori=TblKategori.Id
Group By Ad

