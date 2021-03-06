USE [master]
GO
/****** Object:  Database [QL_PHUTUNG]    Script Date: 30/5/2021 11:42:58 PM ******/
CREATE DATABASE [QL_PHUTUNG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_PHUTUNG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_PHUTUNG.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_PHUTUNG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_PHUTUNG_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_PHUTUNG] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_PHUTUNG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_PHUTUNG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QL_PHUTUNG] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QL_PHUTUNG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_PHUTUNG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_PHUTUNG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QL_PHUTUNG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_PHUTUNG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_PHUTUNG] SET  MULTI_USER 
GO
ALTER DATABASE [QL_PHUTUNG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_PHUTUNG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_PHUTUNG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_PHUTUNG] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QL_PHUTUNG]
GO
/****** Object:  StoredProcedure [dbo].[rpHD]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[rpHD] (@SDT char(10),@NGAY date)
as
begin
	select nv.TENNV,k.TENKH,hd.SDT,k.DIACHI,pt.TENPT,hd.NGAYBAN,ct.SOLUONG,ct.DONGIA ,ct.THANHTIEN from KHACHHANG as k , HOADON as hd, CTHD as ct , NHANVIEN as nv, PHUTUNGXE as pt
	where k.SDT = hd.SDT and hd.MAHD=ct.MAHD and ct.MAPT=pt.MAPT and hd.MANV = nv.MANV AND hd.SDT = @SDT and hd.NGAYBAN = @NGAY
end	
GO
/****** Object:  StoredProcedure [dbo].[rpNH]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[rpNH](@TENNCC NVARCHAR(50),@NGAY date)
as
begin
	select nv.TENNV,ncc.TENNCC,n.NGAYNHAP,pt.TENPT,ctn.SOLUONG,ctn.THANHTIEN,ncc.SDT,ncc.DIACHI 
	from NHAPHANG as n, CTNHAPHANG as ctn,NHACUNGCAP as ncc,PHUTUNGXE as pt,NHANVIEN as nv
	where n.MANH = ctn.MANH and ctn.MAPT = pt.MAPT and n.MANCC = ncc.MANCC  and n.MANV=nv.MANV AND NCC.TENNCC=@TENNCC AND N.NGAYNHAP=@NGAY
end
GO
/****** Object:  Table [dbo].[BAOHANH]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAOHANH](
	[MAHD] [int] NOT NULL,
	[MAPT] [int] NOT NULL,
	[MANV] [int] NULL,
	[SOLUONG_DOI] [int] NULL,
	[NGAYMUA] [date] NULL,
	[NGAYTRA] [date] NULL,
	[TINHTRANG] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC,
	[MAPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[MAHD] [int] NOT NULL,
	[MAPT] [int] NOT NULL,
	[SOLUONG] [int] NULL,
	[DONGIA] [float] NULL,
	[GIAMGIA] [float] NULL,
	[THANHTIEN] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC,
	[MAPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTNHAPHANG]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTNHAPHANG](
	[MANH] [int] NOT NULL,
	[MAPT] [int] NOT NULL,
	[SOLUONG] [int] NULL,
	[THANHTIEN] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MANH] ASC,
	[MAPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DANHSACHYEUTHICH]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DANHSACHYEUTHICH](
	[SDT] [char](13) NOT NULL,
	[MAPT] [int] NOT NULL,
	[NGAYLAP] [datetime] NOT NULL,
	[SOLUONG_DS] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SDT] ASC,
	[MAPT] ASC,
	[NGAYLAP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GIAMGIA]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GIAMGIA](
	[MAGIAMGIA] [char](20) NOT NULL,
	[SOTIENGIAM] [float] NULL,
	[NGAYBATDAU] [date] NULL,
	[NGAYKETTHUC] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MAGIAMGIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOADON](
	[MAHD] [int] IDENTITY(1,1) NOT NULL,
	[SDT] [char](13) NOT NULL,
	[MANV] [int] NOT NULL,
	[NGAYBAN] [datetime] NULL,
	[TONGTIEN] [float] NULL,
	[Tinhtrang] [bit] NULL,
 CONSTRAINT [PK__HOADON__603F20CED6FBE472] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[SDT] [char](13) NOT NULL,
	[TENKH] [nvarchar](50) NULL,
	[GIOITINH] [char](4) NULL,
	[EMAIL] [char](60) NULL,
	[NGAYTAO] [date] NULL,
	[DIACHI] [nvarchar](100) NULL,
	[CHUTHICH] [nvarchar](100) NULL,
 CONSTRAINT [PK_KH] PRIMARY KEY CLUSTERED 
(
	[SDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAIPHUTUNG]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIPHUTUNG](
	[MALOAI] [int] IDENTITY(1,1) NOT NULL,
	[TENPHUTUNG] [nvarchar](100) NULL,
 CONSTRAINT [PK_LX] PRIMARY KEY CLUSTERED 
(
	[MALOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MANCC] [int] IDENTITY(1,1) NOT NULL,
	[TENNCC] [nvarchar](50) NULL,
	[DIACHI] [nvarchar](50) NULL,
	[SDT] [char](13) NULL,
 CONSTRAINT [PK_NCC] PRIMARY KEY CLUSTERED 
(
	[MANCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [int] IDENTITY(1,1) NOT NULL,
	[TENNV] [nvarchar](50) NULL,
	[GIOITINH] [nvarchar](5) NULL,
	[SDT] [char](13) NULL,
	[MatKhau] [char](25) NULL,
	[DIACHI] [nvarchar](50) NULL,
	[NGAYVAOLAM] [date] NULL,
	[MAPQ] [char](10) NULL,
 CONSTRAINT [PK_NV] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHAPHANG]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAPHANG](
	[MANH] [int] IDENTITY(1,1) NOT NULL,
	[MANV] [int] NOT NULL,
	[MANCC] [int] NOT NULL,
	[NGAYNHAP] [date] NULL,
	[TONGTIEN] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MANH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MAPQ] [char](10) NOT NULL,
	[TEnPHANQUYEN] [nvarchar](20) NULL,
 CONSTRAINT [PK_AD] PRIMARY KEY CLUSTERED 
(
	[MAPQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHUTUNGXE]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHUTUNGXE](
	[MAPT] [int] IDENTITY(1,1) NOT NULL,
	[TENPT] [nvarchar](100) NULL,
	[DVT] [nvarchar](20) NULL,
	[MANCC] [int] NOT NULL,
	[MALOAI] [int] NOT NULL,
	[GIABAN] [float] NULL,
	[SOLUONG] [int] NULL,
	[MOTA] [nvarchar](1000) NULL,
	[HINH] [nvarchar](100) NULL,
	[TINHTRANG] [nvarchar](50) NULL,
 CONSTRAINT [PK_PTX] PRIMARY KEY CLUSTERED 
(
	[MAPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 1, CAST(0x0000AD3800B79AF8 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 1, CAST(0x0000AD3800B81687 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 1, CAST(0x0000AD3800F9C3CB AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 1, CAST(0x0000AD3801067FCF AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 1, CAST(0x0000AD3801467356 AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 1, CAST(0x0000AD3801470364 AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 1, CAST(0x0000AD38014F2572 AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 1, CAST(0x0000AD380150E952 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 2, CAST(0x0000AD3800CFD97E AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 2, CAST(0x0000AD3801019688 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 2, CAST(0x0000AD38010C0713 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 3, CAST(0x0000AD3800B9A82F AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 3, CAST(0x0000AD3800BE9B3A AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 5, CAST(0x0000AD3800B79E3B AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 5, CAST(0x0000AD3800B81687 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 5, CAST(0x0000AD3800CFDBC3 AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 5, CAST(0x0000AD38010B1E3B AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 6, CAST(0x0000AD38013195DB AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 10, CAST(0x0000AD380123C7FF AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 21, CAST(0x0000AD38010D9802 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 22, CAST(0x0000AD3800BE9D8A AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 23, CAST(0x0000AD3800B7A10B AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 23, CAST(0x0000AD3800B81688 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 23, CAST(0x0000AD3801281E81 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 24, CAST(0x0000AD38010DAC14 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 25, CAST(0x0000AD38012FDC84 AS DateTime), 3)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 26, CAST(0x0000AD38012ADE15 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 26, CAST(0x0000AD38013FC6B7 AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 43, CAST(0x0000AD3800F9EA8E AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 44, CAST(0x0000AD38012F6AEF AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 45, CAST(0x0000AD380144E444 AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 51, CAST(0x0000AD38010D97FF AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 52, CAST(0x0000AD38012A1985 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 53, CAST(0x0000AD38012BDF2B AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 54, CAST(0x0000AD38012D4902 AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0971343530   ', 79, CAST(0x0000AD38014764B2 AS DateTime), 5)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0975864125   ', 2, CAST(0x0000AD3801701863 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0987652364   ', 1, CAST(0x0000AD38014E1A53 AS DateTime), 1)
INSERT [dbo].[DANHSACHYEUTHICH] ([SDT], [MAPT], [NGAYLAP], [SOLUONG_DS]) VALUES (N'0987652364   ', 6, CAST(0x0000AD38014E1A58 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([MAHD], [SDT], [MANV], [NGAYBAN], [TONGTIEN], [Tinhtrang]) VALUES (30, N'0971343530   ', 3, CAST(0x0000AD38014F2575 AS DateTime), 0, 1)
SET IDENTITY_INSERT [dbo].[HOADON] OFF
INSERT [dbo].[KHACHHANG] ([SDT], [TENKH], [GIOITINH], [EMAIL], [NGAYTAO], [DIACHI], [CHUTHICH]) VALUES (N'0909137407   ', N'An Lê', N'Nam ', N'khanhnguyen@gmail.com                                       ', CAST(0x51420B00 AS Date), N'Sài Gòn', N'')
INSERT [dbo].[KHACHHANG] ([SDT], [TENKH], [GIOITINH], [EMAIL], [NGAYTAO], [DIACHI], [CHUTHICH]) VALUES (N'0971343530   ', N'Quốc An', N'Nam ', NULL, NULL, N'Long An', NULL)
INSERT [dbo].[KHACHHANG] ([SDT], [TENKH], [GIOITINH], [EMAIL], [NGAYTAO], [DIACHI], [CHUTHICH]) VALUES (N'0975864125   ', N'ANLLLE', N'Nam ', NULL, NULL, N'TPHCM', NULL)
INSERT [dbo].[KHACHHANG] ([SDT], [TENKH], [GIOITINH], [EMAIL], [NGAYTAO], [DIACHI], [CHUTHICH]) VALUES (N'0987652364   ', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LOAIPHUTUNG] ON 

INSERT [dbo].[LOAIPHUTUNG] ([MALOAI], [TENPHUTUNG]) VALUES (1, N'Đồ chơi xe máy')
INSERT [dbo].[LOAIPHUTUNG] ([MALOAI], [TENPHUTUNG]) VALUES (2, N'Phụ tùng thay thế')
INSERT [dbo].[LOAIPHUTUNG] ([MALOAI], [TENPHUTUNG]) VALUES (3, N'Vỏ xe máy (Lốp xe)')
INSERT [dbo].[LOAIPHUTUNG] ([MALOAI], [TENPHUTUNG]) VALUES (4, N'Nhớt xe máy')
INSERT [dbo].[LOAIPHUTUNG] ([MALOAI], [TENPHUTUNG]) VALUES (5, N'Phụ kiện cho Biker')
INSERT [dbo].[LOAIPHUTUNG] ([MALOAI], [TENPHUTUNG]) VALUES (6, N'Đồ kiểng theo xe')
SET IDENTITY_INSERT [dbo].[LOAIPHUTUNG] OFF
SET IDENTITY_INSERT [dbo].[NHACUNGCAP] ON 

INSERT [dbo].[NHACUNGCAP] ([MANCC], [TENNCC], [DIACHI], [SDT]) VALUES (1, N'CTY TNHH CÔNG NGHỆ PHÚC LÂN', N'Ð?NG NAI', N'02513896748  ')
INSERT [dbo].[NHACUNGCAP] ([MANCC], [TENNCC], [DIACHI], [SDT]) VALUES (2, N'CTY TNHH HOÀNG THƯƠNG', N'HÀ N?I', N'0972357769   ')
INSERT [dbo].[NHACUNGCAP] ([MANCC], [TENNCC], [DIACHI], [SDT]) VALUES (3, N'CTY CỔ PHẦN CƠ KHÍ PHỐ YÊN', N'THÁI NGUYÊN', N'0984750468   ')
INSERT [dbo].[NHACUNGCAP] ([MANCC], [TENNCC], [DIACHI], [SDT]) VALUES (4, N'CTY MOTO SIÊU VIỆT', N'HCM', N'0938079579   ')
INSERT [dbo].[NHACUNGCAP] ([MANCC], [TENNCC], [DIACHI], [SDT]) VALUES (5, N'CTY VIỆT HỒNG CHINH', N'QU?NG TR?', N'0942944357   ')
INSERT [dbo].[NHACUNGCAP] ([MANCC], [TENNCC], [DIACHI], [SDT]) VALUES (6, N'CTY ĐIỆN MÁY CHÂU Á', N'HÀ N?I', N'02436408544  ')
SET IDENTITY_INSERT [dbo].[NHACUNGCAP] OFF
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 

INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [SDT], [MatKhau], [DIACHI], [NGAYVAOLAM], [MAPQ]) VALUES (1, N'Lê Nguyễn Long Quốc An', N'Nam', N'0971343530   ', N'123                      ', N'CẦN GIUỘC', CAST(0x83320B00 AS Date), N'QL        ')
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [SDT], [MatKhau], [DIACHI], [NGAYVAOLAM], [MAPQ]) VALUES (2, N'Đinh Quốc Khánh Nguyên', N'Nam', N'0123453551   ', N'123                      ', N'TIỀN GIANG', CAST(0xC7400B00 AS Date), N'NVTN      ')
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [SDT], [MatKhau], [DIACHI], [NGAYVAOLAM], [MAPQ]) VALUES (3, N'Mai Quốc Đạt', N'Nam', N'0985642356   ', N'123                      ', N'TPHCm', CAST(0xC7400B00 AS Date), N'NVK       ')
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
INSERT [dbo].[PhanQuyen] ([MAPQ], [TEnPHANQUYEN]) VALUES (N'NVK       ', N'Nhân Viên kho')
INSERT [dbo].[PhanQuyen] ([MAPQ], [TEnPHANQUYEN]) VALUES (N'NVTN      ', N'Nhân viên thu ngân')
INSERT [dbo].[PhanQuyen] ([MAPQ], [TEnPHANQUYEN]) VALUES (N'QL        ', N'Quản lí')
SET IDENTITY_INSERT [dbo].[PHUTUNGXE] ON 

INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (1, N'Dây ga Thái', N'Sợi', 1, 1, 90000, 100, N'Dây ga Thái, dùng để thay thế dây ga zin lâu ngày bị mục nát, nứt, dơ bụi khiến tay ga nặng hơn, hoặc dây ga Thái dùng để gắn chung với cùm tăng Domino nhìn khá nổi bật. Dây ga hàng Thái Lan có thể gắn được tất cả loại xe.', N'day-ga-thai.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (2, N'Co ga Domino', N'Cái', 1, 1, 70000, 103, N'Co ga Domino hàng copy đủ màu sắc, gắn chung với cùm tăng Domino giúp màu mè, nổi bật hơn, ruột bên trong cao su bền, đẹp, thiết kế rất nét, đẹp.', N'coga-domino.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (3, N'Cùm tăng tốc Domino 2 dây ga dưới màu đen chính hãng', N'Cái', 1, 1, 1800000, 100, N'Cùm tăng tốc Domino 2 dây ga dưới màu đen chính hãng, giúp hành trình vặn ga nhanh hơn, giúp xe tăng tốc nhanh hơn như đúng tên gọi của nó. Cùm ga tăng Domino đang là sản phẩm rất được ưu chuộng bởi anh em Biker bởi tính năng cũng như thẩm mỹ của nó. Cùm ga tăng Domino 2 dây ga dưới chính hãng được sản xuất tại Italy, gắn được tất cả dòng xe.', N'cum-ga-tang-domino-2-day-ga.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (4, N'Xinhan Spirit Beast L27 chính hãng', N'Cặp', 1, 1, 400000, 100, N'Xinhan Spirit Beast L27 hàng chính hãng hoàn toàn mới, thiết kế thon dài khá ấn tượng dành cho các dòng xe. Với ánh sáng rất tốt, an toàn cho người tham gia giao thông. Thương hiệu này hiện tại khá được ưa chuộng ở Việt Nam. Xinhan Spirit Beast L27 chính hãng có thể gắn cho nhiều loại xe.', N'xinhan-spirit-beast-l27.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (5, N'Kính chắn gió Zhipat V2 cho Wave, Winner, Winner X', N'Bộ', 1, 1, 130000, 100, N'Kính chắn gió Zhipat V2 với thiết kế rộng hơn dành cho Wave A, Wave RSX, Winner, Winner X... được thiết kế tinh xảo, ôm gọn vào đầu đèn, giúp xe trông ngầu và đẹp hơn rất nhiều. Kính chắn gió có 2 màu: Trắng trong suốt hoặc đen khói trong suốt. Được là từ chất liệu nhựa kỹ thuật bền. Chính hãng ZHIPAT.', N'kinh-chan-gio-zhipat-v2.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (6, N'Đĩa KingSpeed sau cho Raider Fi, Satria', N'Cái', 1, 1, 350000, 100, N'Đĩa KingSpeed thương hiệu mới đang hot trên thị trường với thiết kế rất đẹp, độc tuy nhiên giá thành lại khá hợp lí. Đĩa KingSpeed 190mm gắn vừa như zin đĩa sau cho Raider Fi, Satria mà không cần chế cháo.', N'dia-kingspeed.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (7, N'Kính H2C tròn', N'Cái', 1, 1, 220000, 100, N'Kính H2C tròn hàng gia công làm bằng nhôm sắc nét, kiểu dáng khá độc đáo, lên xe nhìn gọn nhưng vẫn có thể quan sát rất rõ tình hình phía sau, đảm bảo an toàn. Kính H2C đã được mode chân lại, nhìn rất thẩm mỹ. Kính H2C tròn có thể gắn đước tất cả các loại xe 2 bánh.', N'kinh-h2c-tron-1482.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (8, N'Kính gù Motogadget tròn', N'Cái', 1, 1, 800000, 100, N'Kính gù Motogadget tròn mẫu mới nhất, được thiết kế tinh tế, nguyên khối sắc cạnh từng chi tiết, cùng với đó là độ bền, cứng cáp, an toàn khi xe vận hành dài lâu. Kính gù Motogadget tròn lên xe nhìn rất gọn, thích hợp cho xe đi gọn nhẹ hơn là gắn kính kiểu truyền thống.Kính gù Motogadget tròn có thể gắn tất cả các loại xe.', N'kinh-gu-motogadget-tron.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (9, N'Che két nước CNC titan cho Yamaha Exciter 155', N'Cái', 1, 1, 250000, 50, N'Che két nước CNC màu Titan mới nhất dành cho Exciter 155, với thiết kế hoàn toàn mới nhìn rất đẹp, đường nét CNC sắc nét cùng độ dày chắc chắn, tránh tình trạng bị đá hoặc các vật lạ văng vào gây hư hỏng két nước. Che két nước CNC màu titan gắn vừa khít cho Yamaha Exciter 155.', N'che-ket-nuoc-cnc-titan-cho-yamaha-exciter-155.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (10, N'Bao tay Driven SBK chính hãng', N'Cặp', 1, 1, 450000, 100, N'Bao tay Driven SBK chính hãng USA, thương hiệu cao cấp chuyên làm đồ chơi cho các dòng xe PKL, thương hiệu rất nổi tiếng từ USA. Bao tay Driven là sản phẩm mới nhất được cho ra mắt với giá cả vô cùng hợp lí. Bao tay Driven SBK là dòng đua Racing tạo cảm giác bám chặt vào tay và siêu mềm. Bao tay Driven SBK có thể gắn được tất cả loại xe từ PKL đến PKN.', N'bao-tay-driven-sbk-chinh-hang.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (11, N'Bao tay Driven Supermoto chính hãng', N'Cặp', 1, 1, 450000, 50, N'Bao tay Driven Supermoto chính hãng USA, thương hiệu cao cấp chuyên làm đồ chơi cho các dòng xe PKL, thương hiệu rất nổi tiếng từ USA. Bao tay Driven là sản phẩm mới nhất được cho ra mắt với giá cả vô cùng hợp lí. Bao tay Driven Supermoto là dòng thể thao cân đối giữa dòng đua và đi phố với cảm giác cầm nắm mềm nhưng cũng rất chắc chắn. Bao tay Driven Supermoto có thể gắn được tất cả loại xe từ PKL đến PKN.', N'bao-tay-driven-supermoto.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (12, N'Ốp mặt nạ carbon limited cho Exciter4 155', N'Cái', 1, 1, 950000, 50, N'Ốp mặt nạ carbon limited cho Exciter 155, miếng ốp được làm từ carbon nguyên khối, rất chắc chắn, ngoài việc làm xe trở nên đẹp hơn còn giúp xe của bạn trở thành bản limited như đợt đầu bán ra 100 xe ở Việt Nam. Ốp mặt nạ carbon limited cho Exciter 155 được sản xuất với nhiều con số để cho khách hàng chọn lựa.', N'op-mat-na-carbon-limited-cho-exciter-155.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (13, N'Rổ giữa cho Exciter 155', N'Cái', 1, 1, 150000, 50, N'Rổ giữa dành cho Exciter 155 mới, rất tiện dụng dùng để áo khoác, áo mưa, khẩu trang, nón...khắc phục tính trang không có chỗ để đồ trên xe số vô cùng tiện lợi. Rổ giữa dành cho Exciter 155 gôm nguyên bộ rổ, pát gắn vừa khít Exciter 155.', N'ro-giua-cho-exciter-155.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (14, N'Bợ cổ sơn carbon gắn đèn led 2 tầng Zhi.Pat cho EX135 (4 số)', N'Cái', 1, 1, 260000, 50, N'Bợ cổ sơn Carbon gắn đèn led 2 tầng Zhi.Pat cho EX135 (4 số). Gắn như zin không cần chế. Có thể kết hợp với đầu đèn led hoặc gắn thêm kính chắn gió để thay đổi diện mạo đầu đèn xe. Sản phẩm chính hãng Zhi.pat.', N'bo-co-son-carboncho-ex135.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (15, N'Kính titan kiểu dáng Suzuki', N'Cặp', 1, 1, 150000, 50, N'Kính titan kiểu dáng Suzuki, sản phẩm mới toanh trên thị trường, có thiết kế như các dòng xe Suzuki lúc trước đang rất được nhiều Biker ưa chuộng. Kính titan kiểu dáng Suzuki gồm 1 cặp đều là chân ốc răng thuận.', N'kinh-titan-kieu-dang-suzuki.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (16, N'Bình dầu inox Salaya', N'Cái', 1, 1, 400000, 50, N'Bình dầu inox Salaya, sản phẩm mới từ chất liệu inox làm cho độ bền của bình dầu tốt hơn, ngoài ra inox luôn sáng bóng bền bỉ theo thời gian không xuống màu như các loại đồ nhôm CNC. Bình dầu inox Salaya có thể gắn cho các loại xe đi thắng đĩa bình dầu rời.', N'binh-dau-inox-salaya.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (17, N'Van vòi inox Salaya', N'Cặp', 1, 1, 80000, 100, N'Van vòi inox Salaya kiểu dáng mới rất độc lạ, chất kiệu inox bền bỉ theo thời gian và không xuống màu như các loại van vòi nhôm, nhựa màu thông thường. Van vòi inox Salaya có thể gắn cho tất cả các dòng xe.', N'van-voi-inox-salaya.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (18, N'Cốt bánh trước inox Salaya cho Honda Winner, Lead', N'Bộ', 1, 1, 180000, 50, N'Cốt bánh trước inox Salaya dành cho Honda Winner, Lead sản phẩm inox thương hiệu Salaya đang rất hot trên thị trường, chất liệu inox luôn sáng theo thời gian, đặc biệt rất cứng cáp, bền bỉ. Cốt bánh trước inox Salaya vừa là món phụ tùng trang trì vừa có thể thay thế cốt zin lâu ngày hưng hỏng, cũ kỹ.', N'cot-banh-truoc-inox-salaya-cho-honda-winner.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (19, N'Gù inox Salaya 3 cạnh', N'Cặp', 1, 1, 150000, 100, N'Gù inox Salaya 3 cạnh, làm từ inox rất sáng đẹp, không bị phai màu theo thời gian như nhôm, titan. Gù inox Salaya thiết kế dài trung bình, gọn gàng vào bao tay xe. Gù inox Salaya 3 cạnh có thể gắn tất cả loại xe máy.', N'gu-inox-salaya-3-canh.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (20, N'Baga inox 10 ly màu titan cho Exciter 135', N'Cái', 1, 1, 150000, 50, N'Baga inox 10ly màu titan cho Exciter 135 (đời 2011 - 2015) được làm bằng vật liệu cao cấp, với thiết kế nhuộm màu titan khá đẹp mắt, inox 10 dày để chở hàng, chở đồ, gác chân khá chắc chắn, tiện lợi ngoài ra còn giúp bảo về cho dàn áo xe không trầy, xe rất thẩm mỹ và gọn gàng.', N'baga-inox-10-ly-mau-titan-cho-exciter-135.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (21, N'Phuộc YSS Z Sport chính hãng cho Honda Vario', N'cái', 2, 2, 2050000, 100, N'Phuộc YSS Z Sport chính hãng cho các dòng xe tay ga Vario, Click, SH mode, Lead...với thiết kế Black Series mới nhất , tính năng êm ái khi vận hành trên mọi cung đường bởi nút tăng chỉnh độ năng nhẹ ngay chân phuộc, chất lượng phuộc YSS chính hãng đã được nhiều khách hàng tin dùng. Phuộc YSS chính hãng sản xuất tại Thái Lan.', N'phuoc-yss-z-sport-chinh-hang-cho-honda-vario.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (22, N'Lọc gió lưới thép độ dành cho Honda ADV, PCX mới', N'Cái', 2, 2, 250000, 100, N'Lọc gió lưới thép độ dành riêng cho Honda ADV, PCX mới , với chất liệu bằng lưới kim loại lọc có thể vệ sinh tái sử dụng được nhiều lần (5000km mỗi lần vệ sinh), cho thời gian sử dụng bền bỉ gần như trọn đời xe. Bên cạnh đó với thiết kế plug and play, người dùng chỉ cần thay thế cho lưới lọc zin của xe mà ko cần phải chế hay thay đổi kết cấu nguyên bản của xe.', N'loc-gio-luoi-thep-do-danh-cho-honda.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (23, N'Bố thắng đĩa RCB sau cho Honda SH', N'Cặp', 2, 2, 90000, 100, N'Bố thắng đĩa RCB sau cho Honda SH, hàng nhập khẩu chính hãng RCB, chất lượng bố rất tốt so với giá bán ra, đảm bảo an toàn khi vận hành. Bố thắng đĩa RCB sau gắn vừa khít cho Honda SH 2 đĩa.', N'bo-thang-dia-rcb-sau-cho-honda-sh.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (24, N'Bộ nồi BBS cho Vario, AB', N'Bộ', 2, 2, 2200000, 100, N'ộ nồi BBS dành cho Vario, Air Blade gồm: đế bi (chén đựng bi), bi nồi 12g, nắp chụp, cao su kẹp, đế nhôm cánh quạt, bộ 3 càng sau + chuông nồi. Bộ nồi tay ga BBS gắn như zin cho xe Vario, AB zin, khắc phục tình trạng rung nồi tuyệt đối (bệnh chung của các dòng xe Honda hiện tại), làm xe chạy nhẹ nhàng đồng thời rất êm ái, không gào máy như các loại nồi độ khác. Bộ nồi xe tay ga BBS cho Vario, AirBlade được sản xuất tại Taiwan.', N'bo-noi-bbs-cho-vario-ab.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (25, N'Sên phốt RK 428 ELO 132L', N'Sợi', 2, 2, 490000, 100, N'Sên phốt RK 428 ELO - 132L, hàng chính hãng thương hiệu RK chuyên sản xuất sên cho các dòng xe PKL, xe đua...số 1 Nhật Bản. Sên phốt RK 428 ELO - 132L là loại sên 9ly có phốt cao su, dài 132 mắc, sên này được trang bị trên xe Yamaha Exciter 155 nguyên bản, sên có phốt nên vận hành rất mượt mà, êm ái. Sên phốt RK 428 ELO - 132L chính hãng được sản xuất tại Nhật, gắn được cho Exciter 155 và các dòng xe côn tay thể thao dưới 150cc.', N'sen-phot-rk-428-elo.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (26, N'Lọc gió trụ DNA họng 54 chính hãng', N'Cái', 2, 2, 850000, 100, N'Lọc gió trụ DNA họng 54 chính hãng dành riêng cho các dòng xe đã làm máy, dạng trụ cùng họng xăng lớn giúp lấy gió nhiều hơn để chuẩn với tỉ lệ xăng xuống nhiều giúp xe chạy bốc, đồng thời phát ra tiếng hú uy lực, thương hiệu DNA nổi tiếng Châu Âu nằm trong top thế giới. Với chất liệu bằng lưới lọc có thể vệ sinh tái sử dụng được trên 100 lần (5000km mỗi lần vệ sinh), cho thời gian sử dụng bền bỉ gần như trọn đời xe. Lọc gió trụ DNA họng 54 hàng chính hãng DNA sản xuất tại Hy Lạp.', N'loc-gio-tru-dna-hong-54-chinh-hang.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (27, N'Lọc gió trụ DNA họng 51 chính hãng', N'Cái', 2, 2, 750000, 50, N'Lọc gió trụ DNA họng 51 chính hãng dành riêng cho các dòng xe zin muốn đi nhẹ do lọc gió dạng trụ lấy gió nhiều hơn tạo nên hỗn hợp xăng gió lớn giúp xe chạy bốc, đồng thời phát ra tiếng hú uy lực, thương hiệu DNA nổi tiếng Châu Âu nằm trong top thế giới. Với chất liệu bằng lưới lọc có thể vệ sinh tái sử dụng được trên 100 lần (5000km mỗi lần vệ sinh), cho thời gian sử dụng bền bỉ gần như trọn đời xe. Lọc gió trụ DNA họng 51hàng chính hãng DNA sản xuất tại Hy Lạp.', N'loc-gio-tru-dna-hong.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (28, N'Sên RK vàng đen 428HSBT - 132L chính hãng', N'Sợi', 2, 2, 680000, 50, N'Sên RK vàng đen 428HSBT - 132L, hàng chính hãng thương hiệu RK chuyên sản xuất sên cho các dòng xe PKL, xe đua...số 1 Nhật Bản. Sên RK vàng đen 428HSBT - 132L là loại sên 10ly không phốt, dài 132 mắc, sên vàng có lớp mạ ngoài đen, nhìn nổi bật đồng thời cũng giúp màu sắc sên bền hơn so với loại vàng nguyên sợi. Sên RK vàng đen 428HSBT - 132L chính hãng được sản xuất tại Nhật, gắn được cho Exciter 155 và các dòng xe côn tay thể thao dưới 150cc', N'sen-rk-vang-den-428hsb.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (29, N'Dĩa Recto 46T chính hãng cho Exciter 155', N'Cái', 2, 2, 275000, 50, N'Dĩa Recto 46T hàng chính hãng dành cho Exciter 155. Sản phẩm đang được rất nhiều Biker ưa chuộng với chất lượng tuyệt vời, đồ bền cao, vận hành êm ái. Ngoài ra thiết kế cũng khá ấn tượng. Dĩa Recto 46T hàng chính hãng Thái Lan gắn vừa khít cho Exciter 155.', N'dia-recto-46t-chinh-hang-cho-exciter-155.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (30, N'Nhông Mặt Trời 15T cho Honda Winner, Sonic', N'Cái', 2, 2, 60000, 100, N'Nhông mặt trời 15T chính hãng dành cho Honda Winner, Sonic, chất lượng đã được kiểm chứng lâu năm vô cùng bền bỉ. Nhông mặt trời 15T chính hãng cho Winner được sản xuất tại Thái Lan.', N'nhong-mat-troi-15t-cho-honda-winner-sonic.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (31, N'Mâm RCB 8 cây chính hãng cho Exciter 150-155', N'Cặp', 2, 2, 2500000, 50, N'Mâm RCB 8 cây bản nhỏ cho Exciter 150-155 với bản trước 1.6 sau 1.85 lên xe cực chất, dành cho Biker thích phong cách racing, nhìn xe gọn nhưng rất chất. Gắn lên xe như zin không cần chế cháo. Mẫu mâm 8 cây rất được ưa chuộng nay đã có cho Exciter 150-155. Mâm RCB Racingboy 8 cây gắn vừa khít cho Exciter 150-155 có 3 Màu: Đen/Vàng/Trắng. Hàng chính hãng RCB được bảo hành 6 tháng.', N'mam-rcb-8-cay-chinh-hang-cho-exciter-150-155.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (32, N'Cần số 2 chiều cho Exciter 155', N'Cái', 2, 2, 100000, 50, N'Cần số 2 chiều dành cho xe Yamaha Exciter 155, mẫu mã đẹp, dễ sử dụng, đập số nhanh hơn, hạn chế tối đa việc móc số gây hư giày. Phù hợp với khách hàng là nhân viên văn phòng.', N'can-so-2-chieu-cho-exciter-155.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (33, N'Thảm cao su Honda Vision 2021', N'Cái', 2, 2, 75000, 50, N'Thảm cao su lót chân cho Honda Vision đời 2021, thiết kế kiểu Indo đẹp, cao su làm rất dày, giúp chống trày sản xe, khi dơ chỉ cần lấy xe chà là xong sạch sẽ rất tiện lợi.', N'tham-cao-su-honda-vision.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (34, N'Dĩa Recto 42T chính hãng cho Honda Sonic', N'Cái', 2, 2, 190000, 50, N'Dĩa Recto 42T hàng chính hãng dành cho Honda Sonic. Sản phẩm đang được rất nhiều Biker ưa chuộng với chất lượng tuyệt vời, đồ bền cao, vận hành êm ái. Ngoài ra thiết kế cũng khá ấn tượng. Dĩa Recto 42T hàng chính hãng Thái Lan gắn vừa khít như zin cho Sonic.', N'dia-recto-42t-chinh-hang-cho-honda-sonic.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (35, N'Phuộc Nitron chính hãng Việt Nam cho Raider, Satria', N'Cái', 2, 2, 2300000, 20, N'Phuộc Nitron chính hãng Việt Nam, thương hiệu phuộc mới tại Việt Nam đang rất được ưa chuộng trên thị trường đồ chơi xe máy với ưu điểm thiết kế đẹp mắt, tỉ mỉ từng chi tiết đồng thời độ nhún rất mượt mà, êm ái và đặc biệt giá cả vô cùng hợp lí. Phuộc Nitron chính hãng Việt Nam cho Raider, Satria được thiết kế bình dầu cùng full chức năng tăng chỉnh độ nhún, độ đàn hồi phuộc nên phù hợp cho nhiều Biker có thể đi đường xấu đẹp hay chở nặng nhẹ tuỳ ý. Phuộc Nitron chính hãng Việt Nam cho Raider, Satria cao 285mm, phuộc được bảo hành 12 tháng 1 đổi 1 chính hãng Nitron Việt Nam.', N'phuoc-nitron-chinh-hang-viet-nam-cho-raider-satria.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (36, N'Ống tiêu inox Honda Winner X', N'Cái', 2, 2, 75000, 50, N'Ống tiêu inox dành cho Honda Winner X, làm cho hơi thoát ra từ pô xe phóng xuống đường, tình trạng pô zin xe Winner X làm cho khí thải phóng thẳng vào mặt người đi sau đã xảy ra rất nhiều, khiến người đi đường rất khó chịu, sản phẩm chụp pô Winner X này làm cho trở nên văn minh, lịch sự hơn. Ống tiêu inox Winner X gắn vừa khít cho pô zin.', N'ong-tieu-inox-honda-winner-x.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (37, N'Baga tĩnh điện cho Vespa', N'Cái', 2, 2, 550000, 50, N'Baga Vepsa làm từ chất liệu inox dày và được sơn tĩnh điện rất thẩm mĩ và chắc chắn, giúp xe chở đồ nặng và gác chân thoái mái àm không sợ trày xước sàn xe. Baga tĩnh điện Vespa có thể bắt được nhiều dòng xe Vespa...', N'baga-tinh-dien-cho-vespa.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (38, N'Ốp pô inox 300i ZHIPAT cho SHVN 2020', N'Bộ', 2, 2, 680000, 50, N'Ốp pô inox 300i ZHIPAT cho SHVN 2020. Sản phẩm thay thế cho ốp zin hoặc trang trí cho xe thêm cá tính và thời trang. Ốp pô 300i ZHIPAT cho SH 2020 với chất liệu nhựa ABS kết hợp với inox chắc chắn sẽ bảo vệ phần pô gần như tuyệt đối. Ốp pô inox 300i ZHIPAT gắn được cho tất cả loại xe SHVN 2020. Sản phẩm chính hãng ZHIPAT.', N'op-po-inox-300i-zhipat-cho-shvn.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (39, N'Pô 4road 2009 hàng chuẩn full cổ pát cho SHVN 2020', N'Cái', 2, 2, 3400000, 20, N'Pô 4road 2009 hàng chuẩn 1:1 full cổ pát inox loại xịn cho SHVN 2020...âm thanh êm, chuẩn tiếng 4road, dàn ngoài như zin không cần bàn cải về vẻ đẹp. Pô 4road 2009 hàng 1:1 full bộ cổ pát inox loại xịn gắn lên SHVN 2020 mà không cần chế cháo.', N'po-4road-2009-hang-chuan-full-co-pat-cho-shvn-2020.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (40, N'Cục kêu tìm xe Honda', N'Cái', 2, 2, 175000, 100, N'Cục kêu tìm xe Honda, giúp các xe thường lên Smartkey xử dụng được chức năng tìm xe kêu tít tít khi để trong bãi xe.', N'cuc-keu-tim-xe-honda.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (41, N'Vỏ Michelin City Grip 2 120/70-12', N'Cái', 3, 3, 976000, 20, N'Vỏ Michelin City Grip 2 rất phù hợp với điều kiện ở Việt Nam bởi thiết kế nhiều rảnh gai sâu, ở phiên bản City Grip 2 này được cải tiển thêm nhiều chấm gai nhỏ, dài giúp thoáng nước cực tốt mà độ bền vẫn giữ được lâu. Vỏ Michelin City Grip 2 120/70-12 được sản xuất tại Châu Âu, với nhiều rãnh nhỏ trên bề mặt lốp sẽ đảm bảo việc di chuyển ở đường trơn, ôm cua gấp được an toàn hơn. Vỏ Michelin City Grip 2 120/70-12 dành cho các dòng xe: MSX, Scoopy, Vespa..', N'vo-michelin-city-grip-2.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (42, N'Vỏ Metzeler 90/80-14', N'Cái', 3, 3, 515000, 20, N'Metzeler 90/80-14, với thiết kế hoàn toàn mới, dòng cao cấp hơn nhiều so với các loại thông thường. METZELER là một công ty sản xuất vỏ xe của Đức với hơn 100 năm kinh nghiệm sản xuất vỏ xe máy. Metzeler 90/80-14 gắn được bánh sau cho xe AB, Click, Vision, Luvias...', N'vo-metzeler.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (43, N'Vỏ xe Aspira Urbano 120/70-17', N'Cái', 3, 3, 800000, 100, N'ỏ xe Aspira Urbano 120/70-17 gắn được cho xe số như Exciter, Winner, FZ150i...được sản xuất trên cùng dây chuyền trong cùng nhà máy sản xuất nên 2 thương hiệu lốp xe lớn của thế giới là Pirelli của Ý và Metzeller của Đức. Đồng điệu với những thương hiệu nổi tiếng, Aspira Urbano thừa hưởng mọi tinh tuý từ chất lượng và độ chính xác cao nhất của Metzeller – giới Biker trên toàn thế giới ưu ái đặt cho mệnh danh là ”Vỏ xe máy thuộc đẳng cấp High-end’’. Ưu điểm lớn nhất chính là khả năng bám đường tốt cùng khoảng cách phanh ngắn, kiểm soát lái tối ưu và rất tiết kiệm nhiên liệu, êm ái thoải mái trên đường phố, yên tâm với những cú chặt cua ở tốc độ cao.', N'vo-xe-aspira-sportivo.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (44, N'Vỏ xe Goodride H993 130/70-12', N'Cái', 3, 3, 550000, 100, N'Vỏ xe Goodride, một thương hiệu vỏ xe chất lượng đứng top 8 trên thế giới, rất mạnh về thị trường xe 4 bánh nay đã cho ra mắt sản phẩm vỏ xe 2 bánh. Lốp Goodride H993 130/70-12 dành cho xe Vespa, MSX...với thiết kế gai hình tia sét (Flash) rất thông minh, độc lạ, đậm chất thể thao, cùng hợp chất Silica giúp xe có khả năng bám đường tốt. Vỏ xe Goodride H993 130/70-12 sản xuất tại Thái Lan và được bảo hành 6 tháng.', N'vo-xe-goodride.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (45, N'Vỏ xe Camel Pilot 888 110/70-17', N'Cái', 3, 3, 600000, 20, N'Vỏ xe Camel Pilot 888 110/70-17 có gai giống Pilot Street 1 đã từng rất được ưu thích bởi anh em Biker, khi gắn lên xe nhìn trông thể thao, vỏ Camel được lợi thế gai khá đẹp và giá cũng vô cùng hợp lí. Vỏ xe Camel Pilot 888 110/70-17 gắn vừa xe Exciter135-150-155, Winner... Vỏ xe Camel Pilot 888 110/70-17 mang thương hiệu Camel Thái Lan được sản xuất tại Việt Nam.', N'vo-xe-camel-pilot.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (46, N'Vỏ xe Goodride H993 110/70-12', N'Cái', 3, 3, 430000, 20, N'Vỏ xe Goodride, một thương hiệu vỏ xe chất lượng đứng top 8 trên thế giới, rất mạnh về thị trường xe 4 bánh nay đã cho ra mắt sản phẩm vỏ xe 2 bánh. Lốp Goodride H993 110/70-12 dành cho bánh trước xe Vespa, MSX...với thiết kế gai hình tia sét (Flash) rất thông minh, độc lạ, đậm chất thể thao, cùng hợp chất Silica giúp xe có khả năng bám đường tốt. Vỏ xe Goodride H993 110/70-12 sản xuất tại Thái Lan và được bảo hành 6 tháng.', N'vo-xe-goodride-h993.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (47, N'Vỏ xe Camel 563 100/80-17', N'Cái', 3, 3, 640000, 20, N'Vỏ xe Camel 563 100/80-17 có gai Rosso Sport hình tia sét rất độc đáo, khi gắn lên xe nhìn trông thể thao, vỏ Camel được lợi thế gai khá đẹp và giá cũng vô cùng hợp lí. Vỏ xe Camel 563 100/80-17 gắn vừa xe Exciter 135, Winner,... Vỏ xe Camel 563 100/80-17 mang thương hiệu Camel Thái Lan được sản xuất tại Việt Nam.', N'vo-xe-camel-563.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (48, N'Vỏ Michelin City Grip 2 100/80-16', N'Cái', 3, 3, 1380000, 20, N'Vỏ Michelin City Grip 2 rất phù hợp với điều kiện ở Việt Nam bởi thiết kế nhiều rảnh gai sâu, ở phiên bản City Grip 2 này được cải tiển thêm nhiều chấm gai nhỏ, dài giúp thoáng nước cực tốt mà độ bền vẫn giữ được lâu. Vỏ Michelin City Grip 2 được sản xuất tại Châu Âu, với nhiều rãnh nhỏ trên bề mặt lốp sẽ đảm bảo việc di chuyển ở đường trơn, ôm cua gấp được an toàn hơn. Vỏ Michelin City Grip 2 100/80-16 dành cho bánh trước xe SH.', N'vo-michelin-city-grip-2-10080.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (49, N'Vỏ xe Camel Pilot 888 90/80-17', N'Cái', 3, 3, 460000, 20, N'Vỏ xe Camel Pilot 888 90/80-17 có gai giống Pilot Street 1 đã từng rất được ưu thích bởi anh em Biker, khi gắn lên xe nhìn trông thể thao, vỏ Camel được lợi thế gai khá đẹp và giá cũng vô cùng hợp lí. Vỏ xe Camel Pilot 888 90/80-17 gắn vừa xe Wave, Dream, Sirius, Jupiter, Sonic, Exciter135-150, Winner, Sonic, Satria... Vỏ xe Camel Pilot 888 90/80-17 mang thương hiệu Camel Thái Lan được sản xuất tại Việt Nam.', N'vo-xe-camel-pilot1.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (50, N'Vỏ xe Aspira Sportivo 70/90-14', N'Cái', 3, 3, 440000, 20, N'Vỏ xe Aspira Sportivo 70/90-14 gắn được cho xe Mio, Luvias...được sản xuất trên cùng dây chuyền trong cùng nhà máy sản xuất nên 2 thương hiệu lốp xe lớn của thế giới là Pirelli của Ý và Metzeller của Đức. Đồng điệu với những thương hiệu nổi tiếng, Aspira Sportivo thừa hưởng mọi tinh tuý từ chất lượng và độ chính xác cao nhất của Metzeller – giới Biker trên toàn thế giới ưu ái đặt cho mệnh danh là ”Vỏ xe máy thuộc đẳng cấp High-end’’. Ưu điểm lớn nhất chính là khả năng bám đường tốt cùng khoảng cách phanh ngắn, kiểm soát lái tối ưu và rất tiết kiệm nhiên liệu, êm ái thoải mái trên đường phố, yên tâm với những cú chặt cua ở tốc độ cao.', N'vo-xe-aspira-sportivo1.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (51, N'Chai dưỡng bóng dàn áo GoRacing', N'Chai', 4, 4, 175000, 100, N'hai dưỡng bóng dàn áo GoRacing (GoRacing Quick Spray Wax) là dung dịch tạo 1 lớp film mỏng, trong suốt bao phủ lên bề mặt sơn làm tăng độ sáng bóng, bảo vệ bề mặt sơn khỏi ánh nắng trực tiếp, đồng thời tạo hiệu ứng lá sen để chống bám nước, bụi bẩn. Chai xịt bóng dàn áo xe máy GoRacing là sản phẩm chính hãng của thương hiệu GoRacing đang rất được ưa chuộng tại Việt Nam. Chai dưỡng bóng dàn áo GoRacing có 3 tính năng nổi bật: SÁNG BÓNG - BẢO VỆ MÀU SƠN - CHỐNG THẤM NƯỚC BẨN.', N'chai-duong-bong-dan-ao-goracing-1459.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (52, N'Nhớt chiết lẻ Liqui Moly Scooter Race 10W40 (100ml)', N'Chai', 4, 4, 32000, 100, N'Nhớt chiết lẻ Liqui Moly Scooter Race 10W40 là sản phẩm nhớt cao cấp nhất của Liqui chuyên dụng dành cho các dòng xe tay ga hiện đại mới nhất hiện nay. Nhớt Liqui Moly Scooter Race 10W40 thích hơp với các dòng xe tay ga đời mới hiện nay tại Việt Nam như: Lead, Vision, SH, AB, NVX... Thời gian thay nhớt Liqui Moly Scooter Race 10W40 sẽ từ 2500-3000km', N'nhot-liqui-moly-scooter-race-10w40-100ml.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (53, N'Nhớt Motul Scooter LE 10W40 0.8L', N'Chai', 4, 4, 90000, 100, N'Nhớt Motul Scooter LE 10W40 0.8L nhớt chất lượng cho xe tay ga 4 thì, kiểm soát cặn piston, chống mài mòn hiệu quả giúp tăng tuổi thọ động cơ. Khả năng chống quá nhiệt hoàn hảo phù hợp với chế độ dừng chạy liên tục khi giao thông ở thành phố. Nhớt Motul Scooter LE 10W40 được sản xuất bới chính hãng Motul VN.', N'nhot-motul-scoote-le-10w40-08l.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (54, N'Nhớt Maxima Full Syn 10W40', N'Chai', 4, 4, 190000, 100, N'Nhớt Maxima Full Syn 10W40 là dòng nhớt hoàn toàn mới của Maxima, với nhiều công nghệ như chống mài mòn các chi tiết máy cực tốt, dòng nhớt cho xe có khả năng tăng tốc khá bốc tuy nhiên vẫn giữ độ êm của máy, cùng với đó là chỉ số độ nhớt cao 161. Nhớt Maxima Full Syn 10W40 phù hợp cho các dòng xe số trên thị trường, nhớt được sản xuất tại Mỹ.', N'nhot-maxima-full-syn-10w40.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (55, N'Nhớt Repsol MXR Platium 10W40 1L', N'Chai', 4, 4, 195000, 50, N'Nhớt Repsol MXR Platium 10W40 - sản phẩm dành riêng cho các dòng xe số ở thị trường Châu Á, là loại nhớt tổng hợp mạnh mẽ và vượt trội cho động cơ đạt công xuất tối đa. Với công nghệ hiện đại, sản phẩm sẽ mang lại sự bảo vệ và vận hành tối ưu, giúp kéo dài tuổi thọ động cơ. Nhớt Repsol MXR Platium 10W40 có độ nhớt với chỉ số 160, chỉ số khá cao, gần như ngang ngửa với các dòng cao cấp như Repsol Racing.', N'nhot-repsol-mxr-platium-10w40-1l.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (56, N'Nhớt Gulf Western Oil SYN-M 4T Premium Scooter 10W40 0,8L', N'Chai', 4, 4, 250000, 50, N'Nhớt Gulf Western Oil SYN-M 4T Premium Scooter là loại dầu tổng hợp được pha chế đặc biệt để đáp ứng yêu cầu của những động cơ hoạt động lâu dài, đáp ứng yêu cầu khắc khe và sự kiểm soát khí thải cũng như mức tiêu thụ dầu, đáp ứng yêu cầu bôi trơn nghiêm ngặt của các động cơ xe tay ga 4 thì hiện đại, xe có tua máy cao và hạn chế tối đa về nhiệt độ cho các dòng xe máy, chắc chắn vượt trội hơn so với các dầu xe tay ga 4T thông thường khác', N'gulf-western-oil-syn-m-4t-premium-scooter-10w40-08l.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (57, N'Nhớt Gulf Western Oil SYN-M 4T Premium 10W40 1L', N'Chai', 4, 4, 250000, 50, N'Nhớt Gulf Western Oil SYN-M 4T Premium là loại dầu tổng hợp được pha chế đặc biệt để đáp ứng yêu cầu của những động cơ hoạt động lâu dài, đáp ứng yêu cầu khắc khe và sự kiểm soát khí thải cũng như mức tiêu thụ dầu, đáp ứng yêu cầu bôi trơn nghiêm ngặt của các động cơ 4 thì hiện đại, đặc biệt là những động cơ dùng để đua, xe có tua máy cao và hạn chế tối đa về nhiệt độ cho các dòng xe máy, chắc chắn vượt trội hơn so với các dầu 4T thông thường khác.', N'nhot-gulf-western-oil-syn-m-4t-premium-10w40-1l.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (58, N'Nhớt Gulf Western Oil SYN-M 4T Ester Pao 10W40', N'Chai', 4, 4, 360000, 50, N'Nhớt Gulf Western Oil SYN-M 4T Ester Pao 10W40 là dầu tổng hợp với công nghệ cao nhất PAO và Ester, sản phẩm có màu nhớt là cam phản quang rất độc đáo. Nhớt Gulf Western Oil SYN-M 4T Ester Pao 10W40 có thể sử dụng được cho tất cả loại xe thể thao từ PKN đến PKL, được nhập khẩu chính hãng 100% từ Úc.', N'nhot-gulf-western-oil-syn-m-4t-ester-pao-10w40.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (59, N'Nước làm mát GoRacing', N'Chai', 4, 4, 135000, 50, N'Nước làm mát GoRacing với 3 tính năng vượt trội: độ sôi cao - giải nhiệt nhanh - chống đóng cặn. Thương hiệu GoRacing đã có uy tín trong các sản phẩm chăm sóc xe máy.', N'nuoc-lam-mat-goracing-1201.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (60, N'Chai xịt làm sạch dàn nhựa nhám, vỏ xe GoRacing', N'Chai', 4, 4, 90000, 50, N'Chai xịt làm sạch dàn nhựa nhám, vỏ xe GoRacing giúp duy trì, bảo dưỡng độ bóng, tẩy rửa làm sạch mốc trắng, phục hồi lại màu sắc ban đầu của các chi tiết dàn nhựa, vỏ xe một cách tuyệt vời. Xế iu của các bạn lúc nào cũng sạch bóng như zin, lại hạn chế bám bụi cực tốt.', N'chai-xit-lam-sach-dan-nhua-nham-vo-xe-goracing.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (61, N'Motul 300V Factory Line 10W40 1L', N'Chai', 4, 4, 425000, 50, N'Motul 300V Factory Line 10W40 1L nhớt chất lượng cao dành cho xe mô tô phân khối lớn như: Exciter 150, Winner 150, Ex135, MSX 125, Raider 150, Fz150i, TFX 150, kawasaki z1000, Ducati, Cbr150, Cb1100... Nhớt Motul 300V 10W40 1L tối ưu hóa công suất động cơ và bảo vệ động cơ một cách hoàn hảo', N'motul-300v-factory-line-10w40-1l.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (62, N'Chai xịt vệ sinh sên GoRacing', N'Chai', 4, 4, 85000, 50, N'hai xịt vệ sinh sên GoRacing (chain cleaner) là dung dịch tẩy rửa, làm sạch bề mặt sên, khô nhanh, giúp cho bề mặt kim loại sáng bóng. Rút ngắn thời gian vệ sinh với mọi bề mặt kim loại. Chai vệ sinh sên GoRacing còn có thể dùng để vệ sinh hệ thống thắng đĩa. Chai xịt vệ sinh sên GoRacing với những ưu điểm vượt trội như tẩy rữa sạch, bảo vệ màu sơn tốt, chống rỉ sét.', N'chai-xit-ve-sinh-sen-goracing-8572.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (63, N'Chai xịt bôi trơn sên GoRacing', N'Chai', 4, 4, 150000, 50, N'Chai xịt bôi trơn sên GoRacing (Chain Lube) là hỗn hợp dầu bôi trơn, chất hòa tan, khí hóa lỏng. Giúp tạo một lớp phủ lên bề mặt sên, giảm tiếng ồn, chống rỉ sét tận bên trong lõi sên, hạn chế bám bụi, giữ sạch sên lâu hơn.', N'chai-xit-sen-goracing-848.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (64, N'Nước làm mát Liqui Moly (loại không pha)', N'Chai', 4, 4, 170000, 50, N'Nước làm mát Liqui Moly đỏ cao cấp cho hệ thống làm mát động cơ, máy móc. Giải nhiệt động cơ, chống đông, chống ăn mòn, chống hình thành rong rêu cặn bẩn trong hệ thống. Nhiệt độ sôi trên 160°C. Nước làm mát đỏ loại này là loại nguyên chất không cần pha thêm nước. Nước làm mát hàng chính hãng Liqui Moly nhập khẩu từ Đức. Sử dụng cho tất cả các dòng xe sử dụng hệ thống làm mát bằng dung dịch.', N'nuoc-lam-mat-liqui-moly-loai-khong-pha-804.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (65, N'Nhớt Wolver Racing Synthetic 10W40 1lit', N'Chai', 4, 4, 150000, 50, N'Nhớt Wolver Racing Synthetic 10W40 là loại dầu nhớt bôi trơn tổng hợp đặc biệt dành riêng cho động cơ xe máy 4 thì được nhập khẩu chính hãng từ Đức. Wolver Racing được biết đến là dòng nhớt được ứng dụng đặc biệt cho các loại xe máy phân khối lớn, bên cạnh đó còn có thể dùng tốt cho tất cả các loại xe máy có bộ ly hợp khô và ướt (xe số và xe tay ga).', N'nhot-wolver-racing-synthetic-10w40-492.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (66, N'Phụ gia pha nhớt Liqui Moly MO S2', N'Cái', 4, 4, 65000, 100, N'Phụ gia pha nhớt động cơ MOS2 Liqui Moly Oil Additiv Là loại phụ gia đặc biệt, chứa thành phần chính là dầu MoS2 loại hoạt chất bôi trơn cực mạnh, giúp dầu nhớt tăng hiệu quả bôi trơn và nâng cao tuổi thọ của nhớt, từ đó động cơ hoạt động trơn tru và êm hơn. Sản phẩm đặc biệt thích hợp cho các dòng xe độ, nâng cấp động cơ cũng như các động cơ cũ nằm bãi lâu ngày hay cả với động cơ xe mới. Phụ gia pha nhớt Liqui Moly MO S2 nhập khẩu từ Đức, pha với nhớt với tỉ lệ 2% (20ml pha với 1 lít nhớt).', N'phu-gia-pha-nhot-liqui-moly-mo-s2.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (67, N'Phụ gia tăng tốc Liqui Moly Speed Additive', N'Chai', 4, 4, 65000, 50, N'Phụ gia tăng tốc Liqui Moly Speed Additive giúp tăng chỉ số Octan, tối ưu quy trình cháy nổ, giảm tiêu hao nhiên liệu, ngăn chặn hình thành cặn bã, nâng cao hiệu xuất động cơ. Phụ gia tăng tốc Liqui Moly Speed Additive sử dụng cho tất cả loại xe 2 thì, 4 thì, phun xăng điện tử hoặc xăng cơ...', N'phu-gia-tang-toc-liqui-moly-speed-additive.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (68, N'Dầu súc động cơ Liqui Moly Engine Flush', N'Chai', 4, 4, 65000, 50, N'Dầu súc rửa động cơ Liqui Moly Engine Flush, làm sạch động cơ bên trong xe của bạn. Tẩy rửa các chất bẩn bám lâu ngày trong động cơ mà quá trình thay dầu không thể sạch hết. Dầu súc rửa động cơ Liqui Moly Engine Flush sử dụng cho tất cả loại xe.', N'dau-suc-dong-co-liqui-moly-engine-flush.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (69, N'Nhớt hộp số Liqui Moly Racing Scooter Gear Oil', N'Chai', 4, 4, 120000, 50, N'Giúp động cơ xe có khả năng chịu áp lực cao, giảm tiếng ổn khi vận hành xe, độ nhớt ổn định, chống mài mòn bánh răng hiệu quả nhất.', N'nhot-hop-so-liqui-moly-racing-scooter-gear-oil.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (70, N'Motul Scooter Gear Plus', N'Chai', 4, 4, 45000, 100, N'Motul Scooter Gear Plus nhớt láp xe tay ga - nhớt hộp số chất lượng cao của hãng Motul. Motul Scooter Gear Plus chống mài mòn bánh răng, giảm độ ma sát tốt hơn cho xe tay ga đời mới, giúp xe chạy êm ái và mạnh mẽ, chống rỉ và chống ăn mòn tốt nhất trên động cơ xe', N'motul-scooter-gear-plus-38.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (71, N'Găng tay bảo hộ dài ngón Mechanix Mpact', N'Cặp', 5, 5, 180000, 50, N'Găng tay bảo hộ dài ngón Mechanix Mpact được làm từ chất liệu cao cấp dùng cho quân đội, sử dụng khá êm ái trong quá trình đi tour, phượt, đồng thời chống tổn thương khi va quẹt, té ngã. Găng tay dài ngón Mechanix Mpact có màu sắc : Đen, Đỏ Đen, Vàng – Đen, Camo. Size : L, XL sthích hợp cho cả nam và nữ.', N'gang-tay-bao-ho-dai-ngon-mechanix.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (72, N'Găng tay chống nắng xỏ ngón Hàn Quốc', N'Cặp', 5, 5, 50000, 100, N'Găng tay chống nắng xỏ ngón Hàn Quốc giúp bạn bớt đen da khi không muốn mặc áo khoác hầm nóng, thích hợp cho các bạn mặc đồ team giống nhau chống nắng khi di chuyển trên đường, đi leo núi, biển.... Xuất xứ: Hàn Quốc. Màu sắc: đa dạng. Chất liệu: cotton 4 chiều co giãn cực tốt thích hợp cho cả nam và nữ.', N'gang-tay-chong-nang-xo-ngon-han-quoc.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (73, N'Giáp inox bảo hộ Pro Biker (chính hãng)', N'Bộ', 5, 5, 400000, 50, N'Giáp inox bảo hộ Pro Biker chính hãng, bảo vệ toàn bộ cùi chỏ, đầu gối, ống tay, chân giúp giảm thiểu chấn thương cực tốt khi va chạm, tai nạn, món phụ kiện khá tốt nên trang bị dành cho anh em chuyên đi tour, phượt....được an toàn. Giáp bảo hộ tay chân inox Pro Biker với lớp kim loại inox bên ngoài được tác động vật lý cao hơn hẳn so với các loại nhựa. Và các lớp đệm mút lót bên trong dày & êm ái tạo cảm giác chắc chắn khi sử dụng. Giúp hấp thụ & phát tán xung động giảm chấn thương khi gặp hay có sự cố bất ngờ lúc chạy xe.', N'giap-inox-bao-ho-pro-biker-chinh-hang.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (74, N'Nón bảo hiểm Exciter', N'Cái', 5, 5, 99000, 50, N'Nón bảo hiểm được thiết kế dành riêng cho quý khách chạy Exciter - dòng xe côn tay HOT nhất trên thị trường hiện nay đảm bảo chất lượng và mẫu mã hợp thời trang', N'non-bao-hiem-exciter.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (75, N'Ốc titan lốc máy Satria', N'Bộ', 6, 6, 90000, 50, N'Ốc titan lốc máy Satria sẽ đem đến một kiệt tác nghệ thuật cho xế yêu của bạn. Liên hệ shop để mua ốc titan lốc máy Satria chất lượng tốt nhất.', N'octitanlocmaysatria2.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (76, N'Ốc titan lốc máy Wave', N'Bộ', 6, 6, 85000, 50, N'Ốc titan lốc máy Wave sẽ mang lại vẻ đẹp cuốn hút cho một dòng xe bình thường như Wave. Mua ốc titan lốc máy Wave tốt nhất tại shop với giá siêu khuyến mãi.', N'octitanlocmaywave.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (77, N'Ốc titan lốc máy Sirius', N'Bộ', 6, 6, 80000, 50, N'Mua ốc titan lốc máy Sirius chất lượng, giá tốt uy tín, bao lắp đặt tại shop. Ốc titan lốc máy Sirius giúp cho xe của bạn trở nên nổi bật và đảm bảo được khả năng làm việc tốt.', N'octitanlocmaysirius.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (78, N'Ốc titan lốc máy Winner x', N'Bộ', 6, 6, 80000, 50, N'Ốc titan lốc máy Winner x mang lại vẻ đẹp hoàn hảo cho xế yêu của bạn. Mua ốc titan lốc máy winner x chất lượng, giá rẻ, uy tín tại shop.', N'octitanlocmaywinnerx.png', N'Còn hàng')
INSERT [dbo].[PHUTUNGXE] ([MAPT], [TENPT], [DVT], [MANCC], [MALOAI], [GIABAN], [SOLUONG], [MOTA], [HINH], [TINHTRANG]) VALUES (79, N'Ốc titan lốc máy Exciter 150', N'Bộ', 6, 6, 80000, 50, N'Ốc titan lốc máy Exciter 150 là sự lựa chọn phù hợp cho xế yêu của bạn. Ốc titan lốc máy Exciter 150 chắc chắn và luôn tạo điểm nhấn đẹp mắt cho xe.', N'octitanlocmayexciter150.png', N'Còn hàng')
SET IDENTITY_INSERT [dbo].[PHUTUNGXE] OFF
ALTER TABLE [dbo].[CTHD] ADD  DEFAULT ((0)) FOR [GIAMGIA]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT (NULL) FOR [CHUTHICH]
GO
ALTER TABLE [dbo].[BAOHANH]  WITH CHECK ADD  CONSTRAINT [FK__BAOHANH__MAHD__35BCFE0A] FOREIGN KEY([MAHD])
REFERENCES [dbo].[HOADON] ([MAHD])
GO
ALTER TABLE [dbo].[BAOHANH] CHECK CONSTRAINT [FK__BAOHANH__MAHD__35BCFE0A]
GO
ALTER TABLE [dbo].[BAOHANH]  WITH CHECK ADD FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[BAOHANH]  WITH CHECK ADD FOREIGN KEY([MAPT])
REFERENCES [dbo].[PHUTUNGXE] ([MAPT])
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK__CTHD__MAHD__276EDEB3] FOREIGN KEY([MAHD])
REFERENCES [dbo].[HOADON] ([MAHD])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK__CTHD__MAHD__276EDEB3]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD FOREIGN KEY([MAPT])
REFERENCES [dbo].[PHUTUNGXE] ([MAPT])
GO
ALTER TABLE [dbo].[CTNHAPHANG]  WITH CHECK ADD FOREIGN KEY([MANH])
REFERENCES [dbo].[NHAPHANG] ([MANH])
GO
ALTER TABLE [dbo].[CTNHAPHANG]  WITH CHECK ADD FOREIGN KEY([MAPT])
REFERENCES [dbo].[PHUTUNGXE] ([MAPT])
GO
ALTER TABLE [dbo].[DANHSACHYEUTHICH]  WITH CHECK ADD FOREIGN KEY([MAPT])
REFERENCES [dbo].[PHUTUNGXE] ([MAPT])
GO
ALTER TABLE [dbo].[DANHSACHYEUTHICH]  WITH CHECK ADD FOREIGN KEY([SDT])
REFERENCES [dbo].[KHACHHANG] ([SDT])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK__HOADON__MANV__20C1E124] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK__HOADON__MANV__20C1E124]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK__HOADON__SDT__1FCDBCEB] FOREIGN KEY([SDT])
REFERENCES [dbo].[KHACHHANG] ([SDT])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK__HOADON__SDT__1FCDBCEB]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [fk_PQ_NV] FOREIGN KEY([MAPQ])
REFERENCES [dbo].[PhanQuyen] ([MAPQ])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [fk_PQ_NV]
GO
ALTER TABLE [dbo].[NHAPHANG]  WITH CHECK ADD FOREIGN KEY([MANCC])
REFERENCES [dbo].[NHACUNGCAP] ([MANCC])
GO
ALTER TABLE [dbo].[NHAPHANG]  WITH CHECK ADD FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[PHUTUNGXE]  WITH CHECK ADD  CONSTRAINT [FK_PTX_LX] FOREIGN KEY([MALOAI])
REFERENCES [dbo].[LOAIPHUTUNG] ([MALOAI])
GO
ALTER TABLE [dbo].[PHUTUNGXE] CHECK CONSTRAINT [FK_PTX_LX]
GO
ALTER TABLE [dbo].[PHUTUNGXE]  WITH CHECK ADD  CONSTRAINT [FK_PTX_NCC] FOREIGN KEY([MANCC])
REFERENCES [dbo].[NHACUNGCAP] ([MANCC])
GO
ALTER TABLE [dbo].[PHUTUNGXE] CHECK CONSTRAINT [FK_PTX_NCC]
GO
/****** Object:  Trigger [dbo].[trg_CAPNHATTONGTIENHD]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create TRIGGER [dbo].[trg_CAPNHATTONGTIENHD] ON [dbo].[CTHD] AFTER INSERT AS 
BEGIN
UPDATE HOADON
 SET TONGTIEN = l.TONGTIEN + (
		SELECT i.THANHTIEN
		FROM inserted i
		WHERE i.MAHD = l.MAHD
	)
	FROM HOADON l
	JOIN inserted ON l.MAHD = inserted.MAHD
END



GO
/****** Object:  Trigger [dbo].[TRG_SAUKHICAPNHATCT]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  TRIGGER [dbo].[TRG_SAUKHICAPNHATCT] on [dbo].[CTHD] after update AS
BEGIN
UPDATE HOADON
   SET TONGTIEN = l.TONGTIEN -  (SELECT i.THANHTIEN FROM inserted i WHERE i.MAHD = l.MAHD) +
	  (SELECT i.THANHTIEN FROM deleted i WHERE i.MAHD = l.MAHD)

	FROM HOADON l
	JOIN deleted ON l.MAHD = deleted.MAHD
end


GO
/****** Object:  Trigger [dbo].[TRG_SAUKHICAPNHATHD]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[TRG_SAUKHICAPNHATHD] on [dbo].[CTHD] after update AS
BEGIN
   UPDATE PHUTUNGXE 
   SET SOLUONG = l.SOLUONG -
	   (SELECT i.SOLUONG FROM inserted i WHERE i.MAPT = l.MAPT) +
	  (SELECT i.SOLUONG FROM deleted i WHERE i.MAPT = l.MAPT)
   FROM PHUTUNGXE l
	JOIN deleted ON l.MAPT = deleted.MAPT
end


GO
/****** Object:  Trigger [dbo].[TRG_XOAhd]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TRG_XOAhd] ON [dbo].[CTHD] FOR DELETE AS 
BEGIN
UPDATE HOADON
 SET TONGTIEN = l.TONGTIEN - (
		SELECT i.THANHTIEN
		FROM deleted i
		WHERE i.MAHD = l.MAHD
	)
	FROM HOADON l
	JOIN deleted ON l.MAHD = deleted.MAHD

END



GO
/****** Object:  Trigger [dbo].[TGR_XOANHAP]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TGR_XOANHAP] ON [dbo].[CTNHAPHANG] FOR DELETE AS 
BEGIN
	UPDATE NHAPHANG
 SET TONGTIEN = l.TONGTIEN - (
		SELECT i.THANHTIEN
		FROM deleted i
		WHERE i.MANH = l.MANH
	)
	FROM NHAPHANG l
	JOIN deleted ON l.MANH = deleted.MANH
END




GO
/****** Object:  Trigger [dbo].[TRG_CAPNHATSOLUONGPTXE]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TRG_CAPNHATSOLUONGPTXE] ON [dbo].[CTNHAPHANG] AFTER INSERT AS 
BEGIN
UPDATE PHUTUNGXE
 SET SOLUONG = l.SOLUONG + (
		SELECT i.SOLUONG
		FROM inserted i
		WHERE i.MAPT = l.MAPT
	)
	FROM PHUTUNGXE l
	JOIN inserted ON l.MAPT = inserted.MAPT
END


GO
/****** Object:  Trigger [dbo].[TRG_CAPNHATTONGTIRN]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER  [dbo].[TRG_CAPNHATTONGTIRN] 
ON [dbo].[CTNHAPHANG] 
AFTER INSERT AS 
BEGIN
UPDATE NHAPHANG
 SET TONGTIEN = l.TONGTIEN + (
		SELECT i.THANHTIEN
		FROM inserted i
		WHERE i.MANH = l.MANH
	)
	FROM NHAPHANG l
	JOIN inserted ON l.MANH = inserted.MANH
END



GO
/****** Object:  Trigger [dbo].[TRG_HUYCTNHAP]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create TRIGGER [dbo].[TRG_HUYCTNHAP] ON [dbo].[CTNHAPHANG] FOR DELETE AS 
BEGIN
	UPDATE PHUTUNGXE
 SET SOLUONG = l.SOLUONG - (
		SELECT i.SOLUONG
		FROM inserted i
		WHERE i.MAPT = l.MAPT
	)
	FROM PHUTUNGXE l
	JOIN deleted ON l.MAPT = deleted.MAPT
END



GO
/****** Object:  Trigger [dbo].[TRG_SAUKHICAPNHATNHADSP]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create TRIGGER [dbo].[TRG_SAUKHICAPNHATNHADSP] on [dbo].[CTNHAPHANG] after update AS
BEGIN
UPDATE NHAPHANG
   SET TONGTIEN = l.TONGTIEN -  (SELECT i.THANHTIEN FROM inserted i WHERE i.MANH = l.MANH) +
	  (SELECT i.THANHTIEN FROM deleted i WHERE i.MANH = l.MANH)

	FROM NHAPHANG l
	JOIN deleted ON l.MANH = deleted.MANH
end


GO
/****** Object:  Trigger [dbo].[TRG_SAUKHICAPNHATNHAP]    Script Date: 30/5/2021 11:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[TRG_SAUKHICAPNHATNHAP] on [dbo].[CTNHAPHANG] after update AS
BEGIN
   UPDATE PHUTUNGXE 
   SET SOLUONG = l.SOLUONG -
	   (SELECT i.SOLUONG FROM inserted i WHERE i.MAPT = l.MAPT) +
	  (SELECT i.SOLUONG FROM deleted i WHERE i.MAPT = l.MAPT)
   FROM PHUTUNGXE l
	JOIN deleted ON l.MAPT = deleted.MAPT
end



GO
USE [master]
GO
ALTER DATABASE [QL_PHUTUNG] SET  READ_WRITE 
GO
