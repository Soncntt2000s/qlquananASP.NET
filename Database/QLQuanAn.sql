CREATE DATABASE QLQuanAn
GO

USE QLQuanAn
GO

---TẠO BẢNG NGƯỜI DÙNG
CREATE TABLE NguoiDung
(
	TenNguoiDung nvarchar(100) primary key,
	TenHienThi nvarchar(100) not null ,
	SDT numeric not null,
	Phai nvarchar(100) not null,
	DiaChi nvarchar(100) not null,
	MatKhau nvarchar(100) not null ,
	DaNghi int default 0 , --- 0 = chưa nghỉ|| 1 = đã nghỉ
	Type int not null default 0 -- 0 : staff || 1: admin
)
GO



---Tạo bảng BanAn
CREATE TABLE BanAn
(
	idBan int identity primary key,
	TenBan nvarchar(100) not null ,
	TrangThai nvarchar(100) not null,  ---Trống || Có người
	DaXoaBan int default 0  --- 0 = chưa xóa || 1 = đã xóa
)
GO

---Tạo bảng ThucDonMonAn
CREATE TABLE ThucDonMonAn
(
	idThucDon int identity primary key ,
	LoaiThucPham nvarchar(100) not null,
	DaXoaThucDon int default 0  --- 0 = chưa xóa || 1 = đã xóa
)
GO

--Tạo bảng MonAn
CREATE TABLE MonAn
(
	idMonAn int identity primary key,
	TenMon nvarchar(100) not null default N'Chưa đặt tên',
	idThucDonMon int not null,
	DonGia float not null default 0,
	DaXoaMon int default 0  --- 0 = chưa xóa || 1 = đã xóa

	foreign key (idThucDonMon) references dbo.ThucDonMonAn(idThucDon)
)
GO

---Tạo Bảng HoaDon
CREATE TABLE HoaDon
(
	idHoaDon int identity primary key,
	DateCheckIn DATETIME not null Default getdate(),
	DateCheckOut DATETIME ,
	idBanAn int not null,
	GiamGia int default 0,
	TrangThai int not null default 0, -- 0 = chưa thanh toán || 1 = đã thanh toán.
	TongTien float default 0

	foreign key (idBanAn) references dbo.BanAn(idBan)
)
GO


--Tạo Bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon
(
	idChiTiet int identity primary key,
	idHoaDon int not null,
	idMonAn int not null,
	SoLuong int not null default 0

	foreign key (idHoaDon) references dbo.HoaDon(idHoaDon),
	foreign key (idMonAn) references dbo.MonAn(idMonAn)
)
GO
		
insert into NguoiDung(TenNguoiDung,TenHienThi,SDT,Phai,DiaChi,MatKhau,DaNghi,Type) values (N'colen',N'Nguyễn Văn A',14153153568,N'Nam',N'Phú Nhuận',N'202CB962AC59075B964B07152D234B70',0,1);
insert into NguoiDung(TenNguoiDung,TenHienThi,SDT,Phai,DiaChi,MatKhau,DaNghi,Type)  values (N'nhanvien',N'Nguyễn Văn B',14153153568,N'Nam',N'Phú Nhuận',N'202CB962AC59075B964B07152D234B70',0,0);
insert into NguoiDung(TenNguoiDung,TenHienThi,SDT,Phai,DiaChi,MatKhau,DaNghi,Type)  values (N'admin',N'Nguyễn Văn C',14153153568,N'Nam',N'Phú Nhuận',N'202CB962AC59075B964B07152D234B70',0,1);



insert into ThucDonMonAn(LoaiThucPham,DaXoaThucDon) values(N'Đồ uống',0);
insert into ThucDonMonAn(LoaiThucPham,DaXoaThucDon) values(N'Đồ xào',0);
insert into ThucDonMonAn(LoaiThucPham,DaXoaThucDon) values(N'Đồ nướng',0);
insert into ThucDonMonAn(LoaiThucPham,DaXoaThucDon) values(N'Món lẫu',0);
insert into ThucDonMonAn(LoaiThucPham,DaXoaThucDon) values(N'Món thủy hải sản',0);
insert into ThucDonMonAn(LoaiThucPham,DaXoaThucDon) values(N'Món đặt sản',1);


insert into MonAn(TenMon,idThucDonMon,DonGia,DaXoaMon) values (N'NumberOne',01,10000,0);
insert into MonAn(TenMon,idThucDonMon,DonGia,DaXoaMon) values (N'Ốc Xào Sả Ớt',02,22000,0);
insert into MonAn(TenMon,idThucDonMon,DonGia,DaXoaMon) values (N'Bò lá lớp',03,10000,0);
insert into MonAn(TenMon,idThucDonMon,DonGia,DaXoaMon) values (N'Chân Gà Nướng',03,25000,0);
insert into MonAn(TenMon,idThucDonMon,DonGia,DaXoaMon) values (N'Lẫu thái cay',04,125000,0);
insert into MonAn(TenMon,idThucDonMon,DonGia,DaXoaMon) values (N'Tôm hùm hấp tỏi hồng kông',05,999000,0);
insert into MonAn(TenMon,idThucDonMon,DonGia,DaXoaMon) values (N'Duôn dừa tắm nước nắm',06,999000,1);
				


insert into BanAn(TenBan,TrangThai,DaXoaBan) values (N'Bàn Số 1',N'Trống',0);
insert into BanAn(TenBan,TrangThai,DaXoaBan) values (N'Bàn Số 2',N'Trống',0);
insert into BanAn(TenBan,TrangThai,DaXoaBan) values (N'Bàn Số 3',N'Trống',0);
insert into BanAn(TenBan,TrangThai,DaXoaBan) values (N'Bàn Số 4',N'Trống',0);
insert into BanAn(TenBan,TrangThai,DaXoaBan) values (N'Bàn Số 5',N'Trống',0);
insert into BanAn(TenBan,TrangThai,DaXoaBan) values (N'Bàn Số 6',N'Trống',0);
insert into BanAn(TenBan,TrangThai,DaXoaBan) values (N'Bàn Số 7',N'Trống',0);
insert into BanAn(TenBan,TrangThai,DaXoaBan) values (N'Bàn Số 8',N'Trống',0);
insert into BanAn(TenBan,TrangThai,DaXoaBan) values (N'Bàn Số 9',N'Trống',1);

insert into HoaDon(DateCheckIn,DateCheckOut,idBanAn,GiamGia,TrangThai,TongTien) values('2020/07/01','2020/07/01',1,0,1,30000);
insert into HoaDon(DateCheckIn,DateCheckOut,idBanAn,GiamGia,TrangThai,TongTien) values('2020/07/05','2020/07/05',2,0,1,20000);
insert into HoaDon(DateCheckIn,DateCheckOut,idBanAn,GiamGia,TrangThai,TongTien) values('2020/07/10','2020/07/10',3,0,1,10000);



insert into ChiTietHoaDon(idHoaDon,idMonAn,SoLuong) values (1,1,3);
insert into ChiTietHoaDon(idHoaDon,idMonAn,SoLuong) values (2,1,2);
insert into ChiTietHoaDon(idHoaDon,idMonAn,SoLuong) values (3,1,1);



GO


CREATE PROC USP_Login
@userName NVARCHAR(100), @passWord NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.NguoiDung WHERE TenNguoiDung = @userName AND MatKhau = @passWord
END
GO

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.BanAn WHERE DaXoaBan = 0
GO

CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT dbo.HoaDon (DateCheckIn, DateCheckOut,idBanAn,GiamGia,TrangThai) VALUES (GETDATE(), NULL,@idTable,0,0)
END
GO

CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT , @count INT
AS
BEGIN
	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1
	SELECT @isExitsBillInfo = idChiTiet , @foodCount = ct.SoLuong FROM  dbo.ChiTietHoaDon AS ct WHERE idHoaDon = @idBill AND idMonAn = @idFood
	IF(@isExitsBillInfo > 0)
		BEGIN
			DECLARE @newCount INT = @foodCount + @count
			IF(@newCount > 0)
				UPDATE dbo.ChiTietHoaDon SET SoLuong = @foodCount + @count WHERE idMonAn = @idFood
			ELSE 
				DELETE dbo.ChiTietHoaDon WHERE idHoaDon = @idBill AND idMonAn = @idFood
		END
	ELSE
		BEGIN
			INSERT dbo.ChiTietHoaDon (idHoaDon,idMonAn,SoLuong) VALUES (@idBill,@idFood,@count)
		END
END
GO




CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.ChiTietHoaDon  FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT  @idBill = idHoaDon FROM inserted
	DECLARE @idTable INT
	SELECT  @idTable = idBanAn  FROM dbo.HoaDon WHERE idHoaDon = @idBill AND TrangThai = 0

	UPDATE dbo.BanAn SET TrangThai = N'Có người' WHERE idBan = @idTable 
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.HoaDon FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT  @idBill = idHoaDon FROM inserted
	DECLARE @idTable INT
	SELECT  @idTable = idBanAn  FROM dbo.HoaDon WHERE idHoaDon = @idBill 
	DECLARE @count INT = 0
	SELECT  @count = COUNT(*) FROM dbo.HoaDon WHERE idBanAn = @idTable AND TrangThai = 0 
	IF(@count = 0)
		UPDATE dbo.BanAn SET TrangThai = N'Trống' WHERE idBan = @idTable
END
GO

CREATE PROC USP_SwitchTable
@idTable1 INT, @idTable2 INT
AS 
BEGIN
	DECLARE @idFirstBill INT 
	DECLARE @idseconrdBill INT
	SELECT @idseconrdBill = idHoaDon FROM dbo.HoaDon WHERE idBanAn = @idTable2 AND TrangThai = 0
	SELECT @idFirstBill = idHoaDon FROM dbo.HoaDon WHERE idBanAn = @idTable1 AND TrangThai = 0
	IF(@idFirstBill IS NULL)
	BEGIN
		INSERT dbo.HoaDon (DateCheckIn,DateCheckOut,idBanAn,TrangThai) VALUES (GETDATE(),NULL,@idTable1,0)
		SELECT @idFirstBill = MAX(idHoaDon) FROM dbo.HoaDon WHERE idBanAn = @idTable1 AND TrangThai = 0
	END
	IF(@idseconrdBill IS NULL)
	BEGIN
		INSERT dbo.HoaDon (DateCheckIn,DateCheckOut,idBanAn,TrangThai) VALUES (GETDATE(),NULL,@idTable2,0)
		SELECT @idseconrdBill = MAX(idHoaDon) FROM dbo.HoaDon WHERE idBanAn = @idTable2 AND TrangThai = 0
	END
	SELECT idChiTiet INTO IDBillInfoTable FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idseconrdBill
	UPDATE dbo.ChiTietHoaDon SET idHoaDon = @idseconrdBill WHERE idHoaDon = @idFirstBill
	UPDATE dbo.BanAn SET TrangThai = N'Trống' WHERE  idBan = @idTable1
	UPDATE dbo.ChiTietHoaDon SET idHoaDon = @idFirstBill WHERE idChiTiet IN (SELECT * FROM IDBillInfoTable)
	DELETE dbo.HoaDon WHERE idHoaDon = @idFirstBill
	DROP TABLE IDBillInfoTable
END
GO

CREATE PROC USP_GetListBillByDate
@checkIn DATE , @checkOut DATE
AS
BEGIN
	SELECT hd.idHoaDon,ba.TenBan,hd.DateCheckIn,hd.DateCheckOut ,hd.GiamGia ,hd.TongTien  FROM HoaDon AS hd,BanAn AS ba WHERE hd.DateCheckIn >= @checkIn and hd.DateCheckOut <= @checkOut and hd.TrangThai = 1 and ba.idBan = hd.idBanAn 
END
GO

select * from NguoiDung

CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100) ,@name NVARCHAR (100),  @sdt NUMERIC,@phai NVARCHAR(10), @diachi NVARCHAR(100), @type INT
AS
BEGIN
	UPDATE dbo.NguoiDung SET TenHienThi = @name, SDT = @sdt, Phai = @phai, DiaChi = @diachi, Type = @type WHERE TenNguoiDung = @userName
END
GO

CREATE PROC UpdateAccountByUser
@userName NVARCHAR(100) ,@name NVARCHAR (100),  @sdt NUMERIC,@phai NVARCHAR(10), @diachi NVARCHAR(100),  @matkhau NVARCHAR(100) 
AS
BEGIN
	UPDATE dbo.NguoiDung SET TenHienThi = @name, SDT = @sdt, Phai = @phai, DiaChi = @diachi WHERE TenNguoiDung = @userName AND MatKhau = @matkhau
END
GO

CREATE PROC USP_InsertAccount
@userName NVARCHAR(100) ,@name NVARCHAR (100),  @sdt NUMERIC,@phai NVARCHAR(10), @diachi NVARCHAR(100), @matkhau  NVARCHAR(100), @type INT
AS
BEGIN
	INSERT dbo.NguoiDung (TenNguoiDung,TenHienThi,SDT,Phai,DiaChi,MatKhau,Type) VALUES (@userName,@name,@sdt,@phai,@diachi,@matkhau,@type)
END
GO	

CREATE PROC USP_DeleteAccount
@userName NVARCHAR(100) 
AS
BEGIN
	UPDATE dbo.NguoiDung SET DaNghi = 1  WHERE TenNguoiDung = @userName
END
GO	

CREATE PROC USP_ResetAccount
@userName NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.NguoiDung SET MatKhau = CONVERT(VARCHAR(32), HashBytes('MD5', '123456'), 2) WHERE TenNguoiDung = @userName
END
GO	

CREATE PROC USP_UpDatePassWordAccount
@userName NVARCHAR(100), @pass NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.NguoiDung SET MatKhau = @pass WHERE TenNguoiDung = @userName
END
GO	

CREATE PROC USP_checkOutPassWord
@userName NVARCHAR(100), @pass NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.NguoiDung WHERE TenNguoiDung =  @userName AND  MatKhau = @pass 
END
GO	


CREATE PROC USP_InsertTable
@tenban NVARCHAR(100) ,@trangthai NVARCHAR (100) 
AS
BEGIN
	INSERT dbo.BanAn(TenBan,TrangThai) VALUES (@tenban,@trangthai)
END
GO	


CREATE PROC USP_DeleteTable
@tenban NVARCHAR(100) 
AS
BEGIN
	UPDATE dbo.BanAn SET  DaXoaBan = 1  WHERE TenBan = @tenban 
END
GO	


CREATE PROC USP_UpdateTable
@maban NVARCHAR(100)  , @tenban  NVARCHAR(100) , @trangthai  NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.BanAn SET TenBan = @tenban, TrangThai = @trangthai WHERE idBan = @maban 
END
GO	


CREATE PROC USP_InsertCategory
@tendanhmuc NVARCHAR(100)
AS
BEGIN
	INSERT dbo.ThucDonMonAn(LoaiThucPham) VALUES (@tendanhmuc)
END
GO	

CREATE PROC USP_DeleteCategory
@madanhmuc INT
AS
BEGIN
	UPDATE dbo.ThucDonMonAn SET DaXoaThucDon = 1 WHERE idThucDon = @madanhmuc 
END
GO	
CREATE PROC USP_UpdateCategory
@madanhmuc INT, @tendanhmuc NVARCHAR(100) 
AS
BEGIN
	UPDATE dbo.ThucDonMonAn SET LoaiThucPham = @tendanhmuc WHERE idThucDon = @madanhmuc 
END
GO	


CREATE PROC USP_GetIdCategoryByName
@tendanhmuc NVARCHAR(100) 
AS
BEGIN
	SELECT idThucDon FROM dbo.ThucDonMonAn WHERE LoaiThucPham = @tendanhmuc AND DaXoaThucDon = 0
END
GO	

CREATE PROC USP_UpdateFoods
 @idmonan INT ,  @tenmon NVARCHAR(100) ,  @iddanhmuc INT , @gia FLOAT
AS
BEGIN
	UPDATE dbo.MonAn SET TenMon = @tenmon, idThucDonMon = @iddanhmuc, DonGia = @gia WHERE idMonAn = @idmonan 
END
GO	

CREATE PROC USP_DeleteFoods
@idmonan INT
AS
BEGIN
	UPDATE dbo.MonAn SET DaXoaMon = 1 WHERE idMonAn = @idmonan 
END
GO	

CREATE PROC USP_InsertFoods
 @tenmon NVARCHAR(100) ,  @iddanhmuc INT , @gia FLOAT , @daxoamon INT = 0
AS
BEGIN
	INSERT dbo.MonAn(TenMon,idThucDonMon,DonGia,DaXoaMon) VALUES (@tenmon,@iddanhmuc,@gia,@daxoamon)
END
GO	

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
SELECT * FROM BanAn
SELECT * FROM ChiTietHoaDon
SELECT * FROM HoaDon
SELECT * FROM MonAn
SELECT * FROM NguoiDung
SELECT * FROM ThucDonMonAn
