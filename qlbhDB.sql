USE [master]
GO
/****** Object:  Database [QLBanHangDB]    Script Date: 12/29/2023 11:02:50 AM ******/
CREATE DATABASE [QLBanHangDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLBanHangDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLBanHangDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLBanHangDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLBanHangDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLBanHangDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLBanHangDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLBanHangDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLBanHangDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLBanHangDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLBanHangDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLBanHangDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLBanHangDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLBanHangDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLBanHangDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLBanHangDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLBanHangDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLBanHangDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLBanHangDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLBanHangDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLBanHangDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLBanHangDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLBanHangDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLBanHangDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLBanHangDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLBanHangDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLBanHangDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLBanHangDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLBanHangDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLBanHangDB] SET RECOVERY FULL 
GO
ALTER DATABASE [QLBanHangDB] SET  MULTI_USER 
GO
ALTER DATABASE [QLBanHangDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLBanHangDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLBanHangDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLBanHangDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLBanHangDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLBanHangDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLBanHangDB', N'ON'
GO
ALTER DATABASE [QLBanHangDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLBanHangDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLBanHangDB]
GO
/****** Object:  Table [dbo].[ChiTietHDB]    Script Date: 12/29/2023 11:02:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDB](
	[MaHDB] [nchar](10) NOT NULL,
	[MaSP] [nchar](10) NOT NULL,
	[SLBan] [int] NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_ChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HDBan]    Script Date: 12/29/2023 11:02:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HDBan](
	[MaHDB] [nchar](10) NOT NULL,
	[MaKH] [nchar](10) NOT NULL,
	[TongTien] [money] NULL,
	[NgayBan] [date] NULL,
 CONSTRAINT [PK_HDBan] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/29/2023 11:02:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [nchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 12/29/2023 11:02:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[MaLoai] [nchar](10) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiSP] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 12/29/2023 11:02:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [nchar](10) NOT NULL,
	[TenSP] [nvarchar](200) NULL,
	[LoaiSP] [nchar](10) NULL,
	[GiaNhap] [money] NULL,
	[GiaBan] [money] NULL,
	[HSD] [datetime] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 12/29/2023 11:02:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [nchar](10) NOT NULL,
	[SoTienDaTra] [money] NULL,
	[NgayTra] [date] NULL,
 CONSTRAINT [PK_ThanhToan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB001    ', N'SP006     ', 1, 48.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB001    ', N'SP008     ', 2, 20.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB001    ', N'SP011     ', 5, 60.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB002    ', N'SP004     ', 2, 13.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB002    ', N'SP005     ', 1, 75.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB002    ', N'SP008     ', 2, 20.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB002    ', N'SP012     ', 1, 148.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB002    ', N'SP015     ', 1, 55.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB003    ', N'SP014     ', 1, 5.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB004    ', N'SP014     ', 1, 5.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB005    ', N'SP004     ', 1, 13.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB006    ', N'SP010     ', 2, 530.0000)
INSERT [dbo].[ChiTietHDB] ([MaHDB], [MaSP], [SLBan], [ThanhTien]) VALUES (N'HDB007    ', N'SP015     ', 9, 495.0000)
GO
INSERT [dbo].[HDBan] ([MaHDB], [MaKH], [TongTien], [NgayBan]) VALUES (N'HDB001    ', N'KH001     ', 128.0000, CAST(N'2023-12-25' AS Date))
INSERT [dbo].[HDBan] ([MaHDB], [MaKH], [TongTien], [NgayBan]) VALUES (N'HDB002    ', N'KH002     ', 324.0000, CAST(N'2023-12-25' AS Date))
INSERT [dbo].[HDBan] ([MaHDB], [MaKH], [TongTien], [NgayBan]) VALUES (N'HDB003    ', N'KH002     ', 5.0000, CAST(N'2023-12-25' AS Date))
INSERT [dbo].[HDBan] ([MaHDB], [MaKH], [TongTien], [NgayBan]) VALUES (N'HDB004    ', N'KH002     ', 5.0000, CAST(N'2023-12-19' AS Date))
INSERT [dbo].[HDBan] ([MaHDB], [MaKH], [TongTien], [NgayBan]) VALUES (N'HDB005    ', N'KH002     ', 13.0000, CAST(N'2023-12-24' AS Date))
INSERT [dbo].[HDBan] ([MaHDB], [MaKH], [TongTien], [NgayBan]) VALUES (N'HDB006    ', N'KH001     ', 530.0000, CAST(N'2023-12-26' AS Date))
INSERT [dbo].[HDBan] ([MaHDB], [MaKH], [TongTien], [NgayBan]) VALUES (N'HDB007    ', N'KH003     ', 495.0000, CAST(N'2023-12-29' AS Date))
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TrangThai]) VALUES (N'KH001     ', N'thọ hà', N'Đã trả nợ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TrangThai]) VALUES (N'KH002     ', N'dương hằng', N'Đã trả nợ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [TrangThai]) VALUES (N'KH003     ', N'hằng', N'Đã trả nợ')
GO
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'M001      ', N'Cà phê')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'M002      ', N'Bia lon')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'M003      ', N'ChocoPie')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'M004      ', N'Dầu ăn')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'M005      ', N'Nước mắm')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'M006      ', N'Bánh gạo')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'M007      ', N'Sữa tươi')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'M008      ', N'Mì tôm')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'M009      ', N'Bánh ngọt')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'M010      ', N'Pepsi')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP001     ', N'Hộp quà ChocoPie', N'M003      ', 0.0000, 90.0000, CAST(N'2024-02-29T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP002     ', N'Bia 333 - Thùng', N'M002      ', 0.0000, 275.0000, CAST(N'2023-12-24T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP004     ', N'Bia 333 - Lon', N'M002      ', 0.0000, 13.0000, CAST(N'2024-02-23T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP005     ', N'Hộp ChocoPie - 20 cái', N'M003      ', 0.0000, 75.0000, CAST(N'2023-12-24T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP006     ', N'Hộp ChocoPie - 12 cái', N'M003      ', 0.0000, 48.0000, CAST(N'2023-12-23T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP007     ', N'Hộp ChocoPie - 12 cái (+2)', N'M003      ', 0.0000, 48.0000, CAST(N'2023-12-23T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP008     ', N'ChocoPie - 2 cái', N'M003      ', 0.0000, 10.0000, CAST(N'2023-12-23T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP009     ', N'ChocoPie - 1 lốc 12 hộp', N'M003      ', 0.0000, 105.0000, CAST(N'2023-12-23T23:01:53.787' AS DateTime), 10)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP010     ', N'Bia Hà Nội - Thùng', N'M002      ', 0.0000, 265.0000, CAST(N'2023-12-23T23:01:53.787' AS DateTime), 7)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP011     ', N'Bia Hà Nội - Lon', N'M002      ', 0.0000, 12.0000, CAST(N'2023-12-23T23:01:53.787' AS DateTime), 10)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP012     ', N'Sữa tươi Fami - Thùng', N'M007      ', 0.0000, 148.0000, CAST(N'2023-12-24T17:22:12.643' AS DateTime), 9)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP013     ', N'Sữa tươi Fami - Lốc', N'M007      ', 0.0000, 26.0000, CAST(N'2023-12-24T17:22:12.643' AS DateTime), 10)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP014     ', N'Sữa tươi Fami - Hộp', N'M007      ', 0.0000, 5.0000, CAST(N'2023-12-24T17:22:12.643' AS DateTime), 8)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP015     ', N'Dầu ăn Simply - 1 lít', N'M004      ', 0.0000, 55.0000, CAST(N'2023-12-24T17:22:12.643' AS DateTime), 0)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [LoaiSP], [GiaNhap], [GiaBan], [HSD], [SoLuong]) VALUES (N'SP016     ', N'Sữa tươi Fami - Hộp', N'M007      ', 0.0000, 5.0000, CAST(N'2023-12-29T00:00:00.000' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[ThanhToan] ON 

INSERT [dbo].[ThanhToan] ([Id], [MaKH], [SoTienDaTra], [NgayTra]) VALUES (1, N'KH001     ', 658.0000, CAST(N'2023-12-26' AS Date))
INSERT [dbo].[ThanhToan] ([Id], [MaKH], [SoTienDaTra], [NgayTra]) VALUES (2, N'KH002     ', 200.0000, CAST(N'2023-12-26' AS Date))
INSERT [dbo].[ThanhToan] ([Id], [MaKH], [SoTienDaTra], [NgayTra]) VALUES (3, N'KH002     ', 147.0000, CAST(N'2023-12-29' AS Date))
INSERT [dbo].[ThanhToan] ([Id], [MaKH], [SoTienDaTra], [NgayTra]) VALUES (4, N'KH003     ', 200.0000, CAST(N'2023-12-29' AS Date))
INSERT [dbo].[ThanhToan] ([Id], [MaKH], [SoTienDaTra], [NgayTra]) VALUES (5, N'KH003     ', 295.0000, CAST(N'2023-12-20' AS Date))
SET IDENTITY_INSERT [dbo].[ThanhToan] OFF
GO
ALTER TABLE [dbo].[ChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDB_HDBan] FOREIGN KEY([MaHDB])
REFERENCES [dbo].[HDBan] ([MaHDB])
GO
ALTER TABLE [dbo].[ChiTietHDB] CHECK CONSTRAINT [FK_ChiTietHDB_HDBan]
GO
ALTER TABLE [dbo].[ChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDB_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietHDB] CHECK CONSTRAINT [FK_ChiTietHDB_SanPham]
GO
ALTER TABLE [dbo].[HDBan]  WITH CHECK ADD  CONSTRAINT [FK_HDBan_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HDBan] CHECK CONSTRAINT [FK_HDBan_KhachHang]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSP] FOREIGN KEY([LoaiSP])
REFERENCES [dbo].[LoaiHang] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSP]
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_ThanhToan_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[ThanhToan] CHECK CONSTRAINT [FK_ThanhToan_KhachHang]
GO
USE [master]
GO
ALTER DATABASE [QLBanHangDB] SET  READ_WRITE 
GO
