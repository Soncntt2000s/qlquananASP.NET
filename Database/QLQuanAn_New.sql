USE [master]
GO
/****** Object:  Database [QLQuanAn]    Script Date: 07/08/2020 4:38:39 CH ******/
CREATE DATABASE [QLQuanAn] ON  PRIMARY 
( NAME = N'QLQuanAn', FILENAME = N'E:\UNGDUNG\Microsoft SQL Sever\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLQuanAn.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLQuanAn_log', FILENAME = N'E:\UNGDUNG\Microsoft SQL Sever\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLQuanAn_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLQuanAn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLQuanAn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLQuanAn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLQuanAn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLQuanAn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLQuanAn] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLQuanAn] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLQuanAn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLQuanAn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLQuanAn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLQuanAn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLQuanAn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLQuanAn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLQuanAn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLQuanAn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLQuanAn] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLQuanAn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLQuanAn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLQuanAn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLQuanAn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLQuanAn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLQuanAn] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLQuanAn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLQuanAn] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLQuanAn] SET  MULTI_USER 
GO
ALTER DATABASE [QLQuanAn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLQuanAn] SET DB_CHAINING OFF 
GO
ALTER AUTHORIZATION ON DATABASE::[QLQuanAn] TO [sa]
GO
USE [QLQuanAn]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
ALTER AUTHORIZATION ON [dbo].[fuConvertToUnsign1] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[BanAn]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanAn](
	[idBan] [int] IDENTITY(1,1) NOT NULL,
	[TenBan] [nvarchar](100) NOT NULL,
	[TrangThai] [nvarchar](100) NOT NULL,
	[DaXoaBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[BanAn] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[idChiTiet] [int] IDENTITY(1,1) NOT NULL,
	[idHoaDon] [int] NOT NULL,
	[idMonAn] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idChiTiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[ChiTietHoaDon] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[idHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [datetime] NOT NULL,
	[DateCheckOut] [datetime] NULL,
	[idBanAn] [int] NOT NULL,
	[GiamGia] [int] NULL,
	[TrangThai] [int] NOT NULL,
	[TongTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[idHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[HoaDon] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[idMonAn] [int] IDENTITY(1,1) NOT NULL,
	[TenMon] [nvarchar](100) NOT NULL,
	[idThucDonMon] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
	[DaXoaMon] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[MonAn] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[TenNguoiDung] [nvarchar](100) NOT NULL,
	[TenHienThi] [nvarchar](100) NOT NULL,
	[SDT] [numeric](18, 0) NOT NULL,
	[Phai] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
	[DaNghi] [int] NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TenNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[NguoiDung] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[ThucDonMonAn]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThucDonMonAn](
	[idThucDon] [int] IDENTITY(1,1) NOT NULL,
	[LoaiThucPham] [nvarchar](100) NOT NULL,
	[DaXoaThucDon] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idThucDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[ThucDonMonAn] TO  SCHEMA OWNER 
GO
SET IDENTITY_INSERT [dbo].[BanAn] ON 

INSERT [dbo].[BanAn] ([idBan], [TenBan], [TrangThai], [DaXoaBan]) VALUES (1, N'Bàn Số 1', N'Trống', 0)
INSERT [dbo].[BanAn] ([idBan], [TenBan], [TrangThai], [DaXoaBan]) VALUES (2, N'Bàn Số 2', N'Trống', 0)
INSERT [dbo].[BanAn] ([idBan], [TenBan], [TrangThai], [DaXoaBan]) VALUES (3, N'Bàn Số 3', N'Trống', 0)
INSERT [dbo].[BanAn] ([idBan], [TenBan], [TrangThai], [DaXoaBan]) VALUES (4, N'Bàn Số 4', N'Trống', 0)
INSERT [dbo].[BanAn] ([idBan], [TenBan], [TrangThai], [DaXoaBan]) VALUES (5, N'Bàn Số 5', N'Trống', 0)
INSERT [dbo].[BanAn] ([idBan], [TenBan], [TrangThai], [DaXoaBan]) VALUES (6, N'Bàn Số 6', N'Trống', 0)
INSERT [dbo].[BanAn] ([idBan], [TenBan], [TrangThai], [DaXoaBan]) VALUES (7, N'Bàn Số 7', N'Trống', 0)
INSERT [dbo].[BanAn] ([idBan], [TenBan], [TrangThai], [DaXoaBan]) VALUES (8, N'Bàn Số 8', N'Trống', 0)
INSERT [dbo].[BanAn] ([idBan], [TenBan], [TrangThai], [DaXoaBan]) VALUES (9, N'Bàn Số 9', N'Trống', 1)
SET IDENTITY_INSERT [dbo].[BanAn] OFF
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON 

INSERT [dbo].[ChiTietHoaDon] ([idChiTiet], [idHoaDon], [idMonAn], [SoLuong]) VALUES (1, 1, 1, 3)
INSERT [dbo].[ChiTietHoaDon] ([idChiTiet], [idHoaDon], [idMonAn], [SoLuong]) VALUES (2, 2, 1, 2)
INSERT [dbo].[ChiTietHoaDon] ([idChiTiet], [idHoaDon], [idMonAn], [SoLuong]) VALUES (3, 3, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([idChiTiet], [idHoaDon], [idMonAn], [SoLuong]) VALUES (4, 4, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([idChiTiet], [idHoaDon], [idMonAn], [SoLuong]) VALUES (5, 5, 4, 7)
INSERT [dbo].[ChiTietHoaDon] ([idChiTiet], [idHoaDon], [idMonAn], [SoLuong]) VALUES (6, 6, 4, 7)
INSERT [dbo].[ChiTietHoaDon] ([idChiTiet], [idHoaDon], [idMonAn], [SoLuong]) VALUES (7, 8, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([idChiTiet], [idHoaDon], [idMonAn], [SoLuong]) VALUES (8, 8, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([idChiTiet], [idHoaDon], [idMonAn], [SoLuong]) VALUES (9, 8, 4, 7)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([idHoaDon], [DateCheckIn], [DateCheckOut], [idBanAn], [GiamGia], [TrangThai], [TongTien]) VALUES (1, CAST(N'2020-07-01T00:00:00.000' AS DateTime), CAST(N'2020-07-31T17:19:52.613' AS DateTime), 1, 0, 1, 10000)
INSERT [dbo].[HoaDon] ([idHoaDon], [DateCheckIn], [DateCheckOut], [idBanAn], [GiamGia], [TrangThai], [TongTien]) VALUES (2, CAST(N'2020-07-05T00:00:00.000' AS DateTime), CAST(N'2020-07-31T00:01:10.353' AS DateTime), 2, 0, 1, 175000)
INSERT [dbo].[HoaDon] ([idHoaDon], [DateCheckIn], [DateCheckOut], [idBanAn], [GiamGia], [TrangThai], [TongTien]) VALUES (3, CAST(N'2020-07-10T00:00:00.000' AS DateTime), CAST(N'2020-07-10T00:00:00.000' AS DateTime), 3, 0, 1, 10000)
INSERT [dbo].[HoaDon] ([idHoaDon], [DateCheckIn], [DateCheckOut], [idBanAn], [GiamGia], [TrangThai], [TongTien]) VALUES (4, CAST(N'2020-07-30T23:07:54.403' AS DateTime), CAST(N'2020-07-31T17:19:52.613' AS DateTime), 1, 0, 1, 10000)
INSERT [dbo].[HoaDon] ([idHoaDon], [DateCheckIn], [DateCheckOut], [idBanAn], [GiamGia], [TrangThai], [TongTien]) VALUES (5, CAST(N'2020-07-30T23:08:13.467' AS DateTime), CAST(N'2020-07-31T00:01:10.353' AS DateTime), 2, 0, 1, 175000)
INSERT [dbo].[HoaDon] ([idHoaDon], [DateCheckIn], [DateCheckOut], [idBanAn], [GiamGia], [TrangThai], [TongTien]) VALUES (6, CAST(N'2020-07-30T23:14:57.230' AS DateTime), CAST(N'2020-07-30T23:43:00.920' AS DateTime), 7, 0, 1, 45000)
INSERT [dbo].[HoaDon] ([idHoaDon], [DateCheckIn], [DateCheckOut], [idBanAn], [GiamGia], [TrangThai], [TongTien]) VALUES (8, CAST(N'2020-07-30T23:29:14.787' AS DateTime), CAST(N'2020-07-30T23:43:00.920' AS DateTime), 7, 0, 1, 45000)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
SET IDENTITY_INSERT [dbo].[MonAn] ON 

INSERT [dbo].[MonAn] ([idMonAn], [TenMon], [idThucDonMon], [DonGia], [DaXoaMon]) VALUES (1, N'NumberOne', 1, 10000, 0)
INSERT [dbo].[MonAn] ([idMonAn], [TenMon], [idThucDonMon], [DonGia], [DaXoaMon]) VALUES (2, N'Ốc Xào Sả Ớt', 2, 22000, 0)
INSERT [dbo].[MonAn] ([idMonAn], [TenMon], [idThucDonMon], [DonGia], [DaXoaMon]) VALUES (3, N'Bò lá lớp', 4, 10000, 0)
INSERT [dbo].[MonAn] ([idMonAn], [TenMon], [idThucDonMon], [DonGia], [DaXoaMon]) VALUES (4, N'Chân Gà Nướng', 3, 25000, 0)
INSERT [dbo].[MonAn] ([idMonAn], [TenMon], [idThucDonMon], [DonGia], [DaXoaMon]) VALUES (5, N'Lẫu thái cay', 4, 130000, 0)
INSERT [dbo].[MonAn] ([idMonAn], [TenMon], [idThucDonMon], [DonGia], [DaXoaMon]) VALUES (6, N'Tôm hùm hấp tỏi hồng kông', 1, 1241415, 0)
INSERT [dbo].[MonAn] ([idMonAn], [TenMon], [idThucDonMon], [DonGia], [DaXoaMon]) VALUES (7, N'Duôn dừa tắm nước nắm', 6, 999000, 1)
INSERT [dbo].[MonAn] ([idMonAn], [TenMon], [idThucDonMon], [DonGia], [DaXoaMon]) VALUES (8, N'Ốc Xào Sả Ớt', 4, 22000, 1)
INSERT [dbo].[MonAn] ([idMonAn], [TenMon], [idThucDonMon], [DonGia], [DaXoaMon]) VALUES (9, N'Thít quay', 3, 2352652, 1)
SET IDENTITY_INSERT [dbo].[MonAn] OFF
INSERT [dbo].[NguoiDung] ([TenNguoiDung], [TenHienThi], [SDT], [Phai], [DiaChi], [MatKhau], [DaNghi], [Type]) VALUES (N'admin', N'Nguyễn Văn C', CAST(14153153568 AS Numeric(18, 0)), N'Nam', N'Phú Nhuận', N'202CB962AC59075B964B07152D234B70', 0, 1)
INSERT [dbo].[NguoiDung] ([TenNguoiDung], [TenHienThi], [SDT], [Phai], [DiaChi], [MatKhau], [DaNghi], [Type]) VALUES (N'colen', N'Nguyễn Văn A', CAST(14153153568 AS Numeric(18, 0)), N'Nam', N'Phú Nhuận', N'202CB962AC59075B964B07152D234B70', 0, 1)
INSERT [dbo].[NguoiDung] ([TenNguoiDung], [TenHienThi], [SDT], [Phai], [DiaChi], [MatKhau], [DaNghi], [Type]) VALUES (N'nhanvien', N'Nguyễn Văn B', CAST(14153153568 AS Numeric(18, 0)), N'Nam', N'Phú Nhuận', N'202CB962AC59075B964B07152D234B70', 0, 0)
INSERT [dbo].[NguoiDung] ([TenNguoiDung], [TenHienThi], [SDT], [Phai], [DiaChi], [MatKhau], [DaNghi], [Type]) VALUES (N'son', N'Nguyễn Hồng Sơn', CAST(929021058 AS Numeric(18, 0)), N'Nam', N'Q12', N'E10ADC3949BA59ABBE56E057F20F883E', 1, 1)
SET IDENTITY_INSERT [dbo].[ThucDonMonAn] ON 

INSERT [dbo].[ThucDonMonAn] ([idThucDon], [LoaiThucPham], [DaXoaThucDon]) VALUES (1, N'Đồ uống', 0)
INSERT [dbo].[ThucDonMonAn] ([idThucDon], [LoaiThucPham], [DaXoaThucDon]) VALUES (2, N'Đồ xào', 0)
INSERT [dbo].[ThucDonMonAn] ([idThucDon], [LoaiThucPham], [DaXoaThucDon]) VALUES (3, N'Đồ nướng', 0)
INSERT [dbo].[ThucDonMonAn] ([idThucDon], [LoaiThucPham], [DaXoaThucDon]) VALUES (4, N'Món lẫu', 0)
INSERT [dbo].[ThucDonMonAn] ([idThucDon], [LoaiThucPham], [DaXoaThucDon]) VALUES (5, N'Món thủy hải sản', 0)
INSERT [dbo].[ThucDonMonAn] ([idThucDon], [LoaiThucPham], [DaXoaThucDon]) VALUES (6, N'Món đặt sản', 1)
INSERT [dbo].[ThucDonMonAn] ([idThucDon], [LoaiThucPham], [DaXoaThucDon]) VALUES (7, N'Đồ nướng', 1)
SET IDENTITY_INSERT [dbo].[ThucDonMonAn] OFF
ALTER TABLE [dbo].[BanAn] ADD  DEFAULT ((0)) FOR [DaXoaBan]
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  DEFAULT ((0)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [GiamGia]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[MonAn] ADD  DEFAULT (N'Chưa đặt tên') FOR [TenMon]
GO
ALTER TABLE [dbo].[MonAn] ADD  DEFAULT ((0)) FOR [DonGia]
GO
ALTER TABLE [dbo].[MonAn] ADD  DEFAULT ((0)) FOR [DaXoaMon]
GO
ALTER TABLE [dbo].[NguoiDung] ADD  DEFAULT ((0)) FOR [DaNghi]
GO
ALTER TABLE [dbo].[NguoiDung] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[ThucDonMonAn] ADD  DEFAULT ((0)) FOR [DaXoaThucDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([idMonAn])
REFERENCES [dbo].[MonAn] ([idMonAn])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([idHoaDon])
REFERENCES [dbo].[HoaDon] ([idHoaDon])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([idBanAn])
REFERENCES [dbo].[BanAn] ([idBan])
GO
ALTER TABLE [dbo].[MonAn]  WITH CHECK ADD FOREIGN KEY([idThucDonMon])
REFERENCES [dbo].[ThucDonMonAn] ([idThucDon])
GO
/****** Object:  StoredProcedure [dbo].[UpdateAccountByUser]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[UpdateAccountByUser]
@userName NVARCHAR(100) ,@name NVARCHAR (100),  @sdt NUMERIC,@phai NVARCHAR(10), @diachi NVARCHAR(100),  @matkhau NVARCHAR(100) 
AS
BEGIN
	UPDATE dbo.NguoiDung SET TenHienThi = @name, SDT = @sdt, Phai = @phai, DiaChi = @diachi WHERE TenNguoiDung = @userName AND MatKhau = @matkhau
END
GO
ALTER AUTHORIZATION ON [dbo].[UpdateAccountByUser] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_checkOutPassWord]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_checkOutPassWord]
@userName NVARCHAR(100), @pass NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.NguoiDung WHERE TenNguoiDung =  @userName AND  MatKhau = @pass 
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_checkOutPassWord] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteAccount]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_DeleteAccount]
@userName NVARCHAR(100) 
AS
BEGIN
	UPDATE dbo.NguoiDung SET DaNghi = 1  WHERE TenNguoiDung = @userName
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_DeleteAccount] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteCategory]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_DeleteCategory]
@madanhmuc INT
AS
BEGIN
	UPDATE dbo.ThucDonMonAn SET DaXoaThucDon = 1 WHERE idThucDon = @madanhmuc 
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_DeleteCategory] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteFoods]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_DeleteFoods]
@idmonan INT
AS
BEGIN
	UPDATE dbo.MonAn SET DaXoaMon = 1 WHERE idMonAn = @idmonan 
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_DeleteFoods] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteTable]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[USP_DeleteTable]
@tenban NVARCHAR(100) 
AS
BEGIN
	UPDATE dbo.BanAn SET  DaXoaBan = 1  WHERE TenBan = @tenban 
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_DeleteTable] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_GetIdCategoryByName]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[USP_GetIdCategoryByName]
@tendanhmuc NVARCHAR(100) 
AS
BEGIN
	SELECT idThucDon FROM dbo.ThucDonMonAn WHERE LoaiThucPham = @tendanhmuc AND DaXoaThucDon = 0
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_GetIdCategoryByName] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_GetListBillByDate]
@checkIn DATE , @checkOut DATE
AS
BEGIN
	SELECT hd.idHoaDon,ba.TenBan,hd.DateCheckIn,hd.DateCheckOut ,hd.GiamGia ,hd.TongTien  FROM HoaDon AS hd,BanAn AS ba WHERE hd.DateCheckIn >= @checkIn and hd.DateCheckOut <= @checkOut and hd.TrangThai = 1 and ba.idBan = hd.idBanAn 
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_GetListBillByDate] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_GetTableList]
AS SELECT * FROM dbo.BanAn WHERE DaXoaBan = 0
GO
ALTER AUTHORIZATION ON [dbo].[USP_GetTableList] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertAccount]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_InsertAccount]
@userName NVARCHAR(100) ,@name NVARCHAR (100),  @sdt NUMERIC,@phai NVARCHAR(10), @diachi NVARCHAR(100), @matkhau  NVARCHAR(100), @type INT
AS
BEGIN
	INSERT dbo.NguoiDung (TenNguoiDung,TenHienThi,SDT,Phai,DiaChi,MatKhau,Type) VALUES (@userName,@name,@sdt,@phai,@diachi,@matkhau,@type)
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_InsertAccount] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_InsertBill]
@idTable INT
AS
BEGIN
	INSERT dbo.HoaDon (DateCheckIn, DateCheckOut,idBanAn,GiamGia,TrangThai) VALUES (GETDATE(), NULL,@idTable,0,0)
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_InsertBill] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_InsertBillInfo]
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
ALTER AUTHORIZATION ON [dbo].[USP_InsertBillInfo] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertCategory]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[USP_InsertCategory]
@tendanhmuc NVARCHAR(100)
AS
BEGIN
	INSERT dbo.ThucDonMonAn(LoaiThucPham) VALUES (@tendanhmuc)
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_InsertCategory] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertFoods]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_InsertFoods]
 @tenmon NVARCHAR(100) ,  @iddanhmuc INT , @gia FLOAT , @daxoamon INT = 0
AS
BEGIN
	INSERT dbo.MonAn(TenMon,idThucDonMon,DonGia,DaXoaMon) VALUES (@tenmon,@iddanhmuc,@gia,@daxoamon)
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_InsertFoods] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertTable]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[USP_InsertTable]
@tenban NVARCHAR(100) ,@trangthai NVARCHAR (100) 
AS
BEGIN
	INSERT dbo.BanAn(TenBan,TrangThai) VALUES (@tenban,@trangthai)
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_InsertTable] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[USP_Login]
@userName NVARCHAR(100), @passWord NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.NguoiDung WHERE TenNguoiDung = @userName AND MatKhau = @passWord
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_Login] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_ResetAccount]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_ResetAccount]
@userName NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.NguoiDung SET MatKhau = CONVERT(VARCHAR(32), HashBytes('MD5', '123456'), 2) WHERE TenNguoiDung = @userName
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_ResetAccount] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTable]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_SwitchTable]
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
ALTER AUTHORIZATION ON [dbo].[USP_SwitchTable] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateCategory]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateCategory]
@madanhmuc INT, @tendanhmuc NVARCHAR(100) 
AS
BEGIN
	UPDATE dbo.ThucDonMonAn SET LoaiThucPham = @tendanhmuc WHERE idThucDon = @madanhmuc 
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_UpdateCategory] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateFoods]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_UpdateFoods]
 @idmonan INT ,  @tenmon NVARCHAR(100) ,  @iddanhmuc INT , @gia FLOAT
AS
BEGIN
	UPDATE dbo.MonAn SET TenMon = @tenmon, idThucDonMon = @iddanhmuc, DonGia = @gia WHERE idMonAn = @idmonan 
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_UpdateFoods] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_UpDatePassWordAccount]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_UpDatePassWordAccount]
@userName NVARCHAR(100), @pass NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.NguoiDung SET MatKhau = @pass WHERE TenNguoiDung = @userName
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_UpDatePassWordAccount] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateTable]    Script Date: 07/08/2020 4:38:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[USP_UpdateTable]
@maban NVARCHAR(100)  , @tenban  NVARCHAR(100) , @trangthai  NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.BanAn SET TenBan = @tenban, TrangThai = @trangthai WHERE idBan = @maban 
END
GO
ALTER AUTHORIZATION ON [dbo].[USP_UpdateTable] TO  SCHEMA OWNER 
GO
USE [master]
GO
ALTER DATABASE [QLQuanAn] SET  READ_WRITE 
GO
