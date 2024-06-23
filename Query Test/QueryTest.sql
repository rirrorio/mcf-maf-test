-- 1. Kolom yang dijadikan primary key dan foreign key di table 
--     a. Table Pembayaran:
--         - PK : NoKontrak
--         - FK : KodeCabang (dari Table Cabang)
--         - FK : KodeMotor (dari Table Motor )
--     b. Table Cabang :
--         - PK : KodeCabang
--     c. Table Motor :
--         - PK : KodeMotorw


-- 2. Query untuk menampilkan data pembayaran yang dibayarpada tanggal 20-10-2014.
SELECT *
FROM TabelPembayaran
WHERE TglBayar BETWEEN '2014-10-20 00:00:00' AND '2014-10-20 23:59:59';


-- 3. Query untuk menambahkan data pada tabel "Cabang", dengan informasi berikut: kode cabang 200, nama cabang Tangerang:
INSERT INTO TabelCabang (KodeCabang, NamaCabang)
VALUES (200, 'Tangerang');

-- 4. Query untuk update data "Kode Motor" pada tabel "Pembayaran" menjadi "001" untuk semua Cabang Jakarta:
UPDATE TabelPembayaran
SET KodeMotor = '001'
WHERE KodeCabang = (SELECT KodeCabang FROM TabelCabang WHERE NamaCabang = 'Jakarta');


-- 5. Menampilkan NoKontrak, TglBayar, JumlahBayar, kodeCabang, NamaCabang, NoKwitansi, KodeMoytor, NamaMotor.
SELECT p.NoKontrak, p.TglBayar, p.JumlahBayar, p.KodeCabang, c.NamaCabang, p.NoKwitansi, p.KodeMotor, m.NamaMotor
FROM TabelPembayaran p
JOIN TabelCabang c ON p.KodeCabang = c.KodeCabang
JOIN TabelMotor m ON p.KodeMotor = m.KodeMotor
ORDER BY p.TglBayar DESC;

-- 6. Menampilkan KodeCabang, NamaCabang, NoKontrak, NoKwitansi. 
SELECT c.KodeCabang, c.NamaCabang, p.NoKontrak, p.NoKwitansi
FROM TabelPembayaran p
LEFT JOIN TabelCabang c ON p.KodeCabang = c.KodeCabang
ORDER BY p.KodeCabang ASC;

-- 7. Menampilkan KodeCabang, NamaCabang, TotalData, TotalBayar.
SELECT c.KodeCabang, c.NamaCabang, COUNT(p.NoKontrak) AS TotalData, COALESCE(SUM(p.JumlahBayar), 0) AS TotalBayar
FROM TabelCabang c
LEFT JOIN TabelPembayaran p ON c.KodeCabang = p.KodeCabang
GROUP BY c.KodeCabang, c.NamaCabang
ORDER BY c.KodeCabang;








    