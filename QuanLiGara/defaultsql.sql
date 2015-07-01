CREATE DATABASE QLGR
go
use QLGR
go
CREATE TABLE [dbo].[Account] (
    [UserName] VARCHAR (30) NOT NULL,
    [PassWord] VARCHAR (30) NOT NULL,
    [Loai]     VARCHAR (30) NOT NULL,
    CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED ([UserName] ASC)
);

GO

CREATE TABLE [dbo].[HIEUXE] (
    [MaHX]      NVARCHAR (10) NOT NULL,
    [TenHieuXe] NVARCHAR (20) NULL,
    CONSTRAINT [PK_HIEUXE] PRIMARY KEY CLUSTERED ([MaHX] ASC)
);

GO

CREATE TABLE [dbo].[THAMSO] (
    [SuaChuaToiDa] INT NOT NULL,
	[ChenhLech] INT NOT NULL
);

GO

CREATE TABLE [dbo].[TIENCONG] (
    [MaTienCong]  NVARCHAR (10) NOT NULL,
    [TenCongViec] NVARCHAR (30) NULL,
    [TienCong]    MONEY         NULL,
    CONSTRAINT [PK_TIENCONG] PRIMARY KEY CLUSTERED ([MaTienCong] ASC)
);

GO

CREATE TABLE [dbo].[VATTU] (
    [MaVatTu]  NVARCHAR (10) NOT NULL,
    [TenVatTu] NVARCHAR (30) NULL,
    [DonGia]   MONEY         NULL,
    [SoLuong]  INT           NULL,
    CONSTRAINT [PK_VATTU] PRIMARY KEY CLUSTERED ([MaVatTu] ASC)
);

GO

CREATE TABLE [dbo].[HOSONHAPHANG] (
    [MaNH]         NVARCHAR (50) NOT NULL,
    [TenNCC]       NVARCHAR (50) NULL,
    [DiaChi]       NVARCHAR (50) NULL,
    [DienThoai]    NVARCHAR (50) NULL,
    [NgayNhapHang] DATE          NULL,
    [TongCong]     MONEY         NULL,
    [Email]        NVARCHAR (50) NULL,
    CONSTRAINT [PK_HOSONHAPHANG] PRIMARY KEY CLUSTERED ([MaNH] ASC)
);

GO

CREATE TABLE [dbo].[PHIEUNHAPHANG] (
    [MaPhieuNhap] NVARCHAR (50) NOT NULL,
    [MaVatTu]     NVARCHAR (10) NULL,
    [SoLuong]     INT           NULL,
    [ThanhTien]   MONEY         NULL,
    [MaNH]        NVARCHAR (50) NULL,
    CONSTRAINT [PK_PHIEUNHAPHANG] PRIMARY KEY CLUSTERED ([MaPhieuNhap] ASC),
    CONSTRAINT [FK_PHIEUNHAPHANG_HOSONHAPHANG] FOREIGN KEY ([MaNH]) REFERENCES [dbo].[HOSONHAPHANG] ([MaNH]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_PHIEUNHAPHANG_VATTU] FOREIGN KEY ([MaVatTu]) REFERENCES [dbo].[VATTU] ([MaVatTu])
);

GO

CREATE TABLE [dbo].[HOSOSUACHUA] (
    [MaHSSC]       NVARCHAR (50) NOT NULL,
    [TenChuXe]     NVARCHAR (50) NULL,
    [BienSo]       NVARCHAR (50) NULL,
    [MaHX]         NVARCHAR (10) NULL,
    [DiaChi]       NVARCHAR (50) NULL,
    [DienThoai]    NVARCHAR (50) NULL,
    [NgayTiepNhan] DATE          NULL,
    [TongCong]     MONEY         NULL,
    [Email]        NVARCHAR (50) NULL,
    CONSTRAINT [PK_HOSOSUACHUA] PRIMARY KEY CLUSTERED ([MaHSSC] ASC),
    CONSTRAINT [FK_HOSOSUACHUA_HIEUXE] FOREIGN KEY ([MaHX]) REFERENCES [dbo].[HIEUXE] ([MaHX])
);

GO

CREATE TABLE [dbo].[PHIEUSUACHUA] (
    [MaPhieuSC]   NVARCHAR (50) NOT NULL,
    [NoiDung]     NVARCHAR (50) NULL,
    [MaVatTu]     NVARCHAR (10) NULL,
    [SoLuong]     INT           NULL,
    [MaTienCong]  NVARCHAR (10) NULL,
    [ThanhTien]   MONEY         NULL,
    [MaHSSC]      NVARCHAR (50) NULL,
    [NgaySuaChua] DATE          NULL,
    CONSTRAINT [PK_PHIEUSUACHUA] PRIMARY KEY CLUSTERED ([MaPhieuSC] ASC),
    CONSTRAINT [FK_PHIEUSUACHUA_HOSOSUACHUA] FOREIGN KEY ([MaHSSC]) REFERENCES [dbo].[HOSOSUACHUA] ([MaHSSC]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_PHIEUSUACHUA_TIENCONG] FOREIGN KEY ([MaTienCong]) REFERENCES [dbo].[TIENCONG] ([MaTienCong]),
    CONSTRAINT [FK_PHIEUSUACHUA_VATTU] FOREIGN KEY ([MaVatTu]) REFERENCES [dbo].[VATTU] ([MaVatTu])
);

GO
CREATE TABLE [dbo].[DANHSACHXE] (
    [MaXe]   NVARCHAR (50) NOT NULL,
    [MaHSSC] NVARCHAR (50) NOT NULL,
    [TienNo] MONEY         NULL,
    CONSTRAINT [PK_DANHSACHXE] PRIMARY KEY CLUSTERED ([MaXe] ASC, [MaHSSC] ASC),
    CONSTRAINT [FK_DANHSACHXE_HOSOSUACHUA] FOREIGN KEY ([MaHSSC]) REFERENCES [dbo].[HOSOSUACHUA] ([MaHSSC]) ON DELETE CASCADE ON UPDATE CASCADE
);

GO

CREATE TABLE [dbo].[PHIEUTHUTIEN] (
    [MaThuTien]   NVARCHAR (10) NOT NULL,
    [NgayThuTien] DATE          NULL,
    [SoTienThu]   MONEY         NULL,
    [MaHSSC]      NVARCHAR (50) NULL,
    CONSTRAINT [PK_PHIEUTHUTIEN] PRIMARY KEY CLUSTERED ([MaThuTien] ASC),
    CONSTRAINT [FK_PHIEUTHUTIEN_HOSOSUACHUA] FOREIGN KEY ([MaHSSC]) REFERENCES [dbo].[HOSOSUACHUA] ([MaHSSC]) ON DELETE CASCADE ON UPDATE CASCADE
);

GO

CREATE PROCEDURE [dbo].[BaoCaoDoanhThu]
@Thang INT=1
AS
BEGIN
    SET NOCOUNT ON;
    SELECT HIEUXE.TenHieuXe,
           (SELECT count(*)
            FROM   HOSOSUACHUA
            WHERE  HIEUXE.MaHX = HOSOSUACHUA.MaHX
                   AND MONTH(HOSOSUACHUA.NgayTiepNhan) = @Thang) AS SoLuotSua,
           (SELECT Sum(HOSOSUACHUA.TongCong)
            FROM   HOSOSUACHUA
            WHERE  HIEUXE.MaHX = HOSOSUACHUA.MaHX
                   AND MONTH(HOSOSUACHUA.NgayTiepNhan) = @Thang) AS DoanhSo,
           (SELECT Sum(TongCong)
            FROM   HOSOSUACHUA
            WHERE  (SELECT sum(TongCong)   FROM   HOSOSUACHUA  WHERE  MONTH(HOSOSUACHUA.NgayTiepNhan) = @Thang) <> 0 and HIEUXE.MaHX = HOSOSUACHUA.MaHX
                   AND MONTH(HOSOSUACHUA.NgayTiepNhan) = @Thang) / CAST ((SELECT sum(TongCong)
                                                                          FROM   HOSOSUACHUA
                                                                          WHERE  MONTH(HOSOSUACHUA.NgayTiepNhan) = @Thang) AS FLOAT) AS TiLe
    FROM   HIEUXE;
END

GO
CREATE PROCEDURE [dbo].[BaoCaoTon]
@Thang INT=1
AS
BEGIN
    SET NOCOUNT ON;
    SELECT VATTU.TenVatTu,
           VATTU.SoLuong AS Ton,
           (SELECT sum(PHIEUSUACHUA.SoLuong)
            FROM   PHIEUSUACHUA
            WHERE  VATTU.MaVatTu = PHIEUSUACHUA.MaVatTu
                   AND MONTH(PHIEUSUACHUA.NgaySuaChua) = @Thang) AS PhatSinh
    FROM   VATTU;
END

GO

INSERT INTO [dbo].[Account] ([UserName], [PassWord], [Loai]) VALUES (N'admin', N'123456', N'admin')
INSERT INTO [dbo].[Account] ([UserName], [PassWord], [Loai]) VALUES (N'nv1', N'123456', N'nv')
INSERT INTO [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (N'AU', N'Audi')
INSERT INTO [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (N'BU', N'Bugati')
INSERT INTO [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (N'DU', N'Ducati')
INSERT INTO [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (N'FO', N'Ford')
INSERT INTO [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (N'HD', N'HonDa')
INSERT INTO [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (N'ME', N'Mescedes')
INSERT INTO [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (N'SU', N'Suzuki')
INSERT INTO [dbo].[HIEUXE] ([MaHX], [TenHieuXe]) VALUES (N'TO', N'Toyota')
INSERT INTO [dbo].[THAMSO] ([SuaChuaToiDa], [ChenhLech]) VALUES (40, 10)
INSERT INTO [dbo].[TIENCONG] ([MaTienCong], [TenCongViec], [TienCong]) VALUES (N'TC1', N'Sơn ', CAST(100000.0000 AS Money))
INSERT INTO [dbo].[TIENCONG] ([MaTienCong], [TenCongViec], [TienCong]) VALUES (N'TC2', N'Thay Kiếng Hậu', CAST(500000.0000 AS Money))
INSERT INTO [dbo].[TIENCONG] ([MaTienCong], [TenCongViec], [TienCong]) VALUES (N'TC3', N'Thay Căm Xe', CAST(500000.0000 AS Money))
INSERT INTO [dbo].[TIENCONG] ([MaTienCong], [TenCongViec], [TienCong]) VALUES (N'TC4', N'Thay lốp xe ', CAST(200000.0000 AS Money))
INSERT INTO [dbo].[TIENCONG] ([MaTienCong], [TenCongViec], [TienCong]) VALUES (N'TC5', N'Rửa xe ', CAST(50000.0000 AS Money))
INSERT INTO [dbo].[TIENCONG] ([MaTienCong], [TenCongViec], [TienCong]) VALUES (N'TC6', N'Không', CAST(0.0000 AS Money))
INSERT INTO [dbo].[VATTU] ([MaVatTu], [TenVatTu], [DonGia], [SoLuong]) VALUES (N'VT1', N'Bánh xe', CAST(3000000.0000 AS Money), 70)
INSERT INTO [dbo].[VATTU] ([MaVatTu], [TenVatTu], [DonGia], [SoLuong]) VALUES (N'VT2', N'Lốp Xe', CAST(2000000.0000 AS Money), 97)
INSERT INTO [dbo].[VATTU] ([MaVatTu], [TenVatTu], [DonGia], [SoLuong]) VALUES (N'VT3', N'Cửa Kính', CAST(1250000.0000 AS Money), 100)
INSERT INTO [dbo].[VATTU] ([MaVatTu], [TenVatTu], [DonGia], [SoLuong]) VALUES (N'VT4', N'Không', CAST(0.0000 AS Money), 100)
INSERT INTO [dbo].[VATTU] ([MaVatTu], [TenVatTu], [DonGia], [SoLuong]) VALUES (N'VT5', N'Căm Xe', CAST(200000.0000 AS Money), 134)
INSERT INTO [dbo].[VATTU] ([MaVatTu], [TenVatTu], [DonGia], [SoLuong]) VALUES (N'VT6', N'Kính Hậu', CAST(300000.0000 AS Money), 100)
INSERT INTO [dbo].[VATTU] ([MaVatTu], [TenVatTu], [DonGia], [SoLuong]) VALUES (N'VT7', N'Đèn Pha', CAST(200000.0000 AS Money), 100)
INSERT INTO [dbo].[HOSONHAPHANG] ([MaNH], [TenNCC], [DiaChi], [DienThoai], [NgayNhapHang], [TongCong], [Email]) VALUES (N'HSNH1', N'jhf', N'sdf', N'898', N'2015-06-22', CAST(5750000.0000 AS Money), N'asd')
INSERT INTO [dbo].[HOSONHAPHANG] ([MaNH], [TenNCC], [DiaChi], [DienThoai], [NgayNhapHang], [TongCong], [Email]) VALUES (N'HSNH2', N'aasd', N'ad', N'987', N'2015-06-22', CAST(64000000.0000 AS Money), N'asd')
INSERT INTO [dbo].[HOSONHAPHANG] ([MaNH], [TenNCC], [DiaChi], [DienThoai], [NgayNhapHang], [TongCong], [Email]) VALUES (N'HSNH3', N'sdf', N'sdf', N'123', N'2015-06-22', CAST(64000000.0000 AS Money), N'sdf')
INSERT INTO [dbo].[HOSONHAPHANG] ([MaNH], [TenNCC], [DiaChi], [DienThoai], [NgayNhapHang], [TongCong], [Email]) VALUES (N'HSNH4', N'sdf', N'sdf', N'123', N'2015-06-22', CAST(34000000.0000 AS Money), N'sdf')
INSERT INTO [dbo].[HOSOSUACHUA] ([MaHSSC], [TenChuXe], [BienSo], [MaHX], [DiaChi], [DienThoai], [NgayTiepNhan], [TongCong], [Email]) VALUES (N'HSSC1', N'nguyen hoang duong', N'60b7-23567', N'BU', N'dong nai', N'0918767685', N'2015-06-18', CAST(107500000.0000 AS Money), NULL)
INSERT INTO [dbo].[HOSOSUACHUA] ([MaHSSC], [TenChuXe], [BienSo], [MaHX], [DiaChi], [DienThoai], [NgayTiepNhan], [TongCong], [Email]) VALUES (N'HSSC2', N'hoang', N'60b8-12346', N'DU', N'dong nai', N'0974881123', N'2015-06-18', CAST(120000000.0000 AS Money), NULL)
INSERT INTO [dbo].[HOSOSUACHUA] ([MaHSSC], [TenChuXe], [BienSo], [MaHX], [DiaChi], [DienThoai], [NgayTiepNhan], [TongCong], [Email]) VALUES (N'HSSC3', N'nguyen hoang uodng', N'60b8-25346', N'HD', N'dong nai', N'0978654321', N'2015-06-18', CAST(0.0000 AS Money), N'hanhkhatxahoa@gmail.com')
INSERT INTO [dbo].[PHIEUNHAPHANG] ([MaPhieuNhap], [MaVatTu], [SoLuong], [ThanhTien], [MaNH]) VALUES (N'PNH1', N'VT1', 20, CAST(60000000.0000 AS Money), N'HSNH2')
INSERT INTO [dbo].[PHIEUNHAPHANG] ([MaPhieuNhap], [MaVatTu], [SoLuong], [ThanhTien], [MaNH]) VALUES (N'PNH2', N'VT7', 20, CAST(4000000.0000 AS Money), N'HSNH2')
INSERT INTO [dbo].[PHIEUNHAPHANG] ([MaPhieuNhap], [MaVatTu], [SoLuong], [ThanhTien], [MaNH]) VALUES (N'PNH3', N'VT1', 20, CAST(60000000.0000 AS Money), N'HSNH3')
INSERT INTO [dbo].[PHIEUNHAPHANG] ([MaPhieuNhap], [MaVatTu], [SoLuong], [ThanhTien], [MaNH]) VALUES (N'PNH4', N'VT7', 20, CAST(4000000.0000 AS Money), N'HSNH3')
INSERT INTO [dbo].[PHIEUNHAPHANG] ([MaPhieuNhap], [MaVatTu], [SoLuong], [ThanhTien], [MaNH]) VALUES (N'PNH5', N'VT1', 10, CAST(30000000.0000 AS Money), N'HSNH4')
INSERT INTO [dbo].[PHIEUNHAPHANG] ([MaPhieuNhap], [MaVatTu], [SoLuong], [ThanhTien], [MaNH]) VALUES (N'PNH6', N'VT7', 20, CAST(4000000.0000 AS Money), N'HSNH4')
INSERT INTO [dbo].[PHIEUSUACHUA] ([MaPhieuSC], [NoiDung], [MaVatTu], [SoLuong], [MaTienCong], [ThanhTien], [MaHSSC], [NgaySuaChua]) VALUES (N'PSC1', N'bx', N'VT1', 30, N'TC6', CAST(90000000.0000 AS Money), N'HSSC2', N'2015-06-23')
INSERT INTO [dbo].[PHIEUSUACHUA] ([MaPhieuSC], [NoiDung], [MaVatTu], [SoLuong], [MaTienCong], [ThanhTien], [MaHSSC], [NgaySuaChua]) VALUES (N'PSC2', N'lx', N'VT2', 15, N'TC6', CAST(30000000.0000 AS Money), N'HSSC2', N'2015-06-23')
INSERT INTO [dbo].[DANHSACHXE] ([MaXe], [MaHSSC], [TienNo]) VALUES (N'MX1', N'HSSC1', CAST(37500000.0000 AS Money))
INSERT INTO [dbo].[DANHSACHXE] ([MaXe], [MaHSSC], [TienNo]) VALUES (N'MX2', N'HSSC2', CAST(30000000.0000 AS Money))
INSERT INTO [dbo].[DANHSACHXE] ([MaXe], [MaHSSC], [TienNo]) VALUES (N'MX3', N'HSSC3', CAST(0.0000 AS Money))