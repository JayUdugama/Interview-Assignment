USE [Inventory_Management_System]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 3/8/2024 12:33:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 3/8/2024 12:33:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](20) NOT NULL,
	[PhoneNo] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLogin]    Script Date: 3/8/2024 12:33:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLogin](
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 3/8/2024 12:33:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrder](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_tblOrder] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 3/8/2024 12:33:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[ProductQty] [int] NOT NULL,
	[ProductPrice] [float] NOT NULL,
	[ProductDescription] [varchar](100) NULL,
	[ProductCategory] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 3/8/2024 12:33:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[Username] [varchar](20) NOT NULL,
	[Fullname] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[ConfirmPassword] [varchar](20) NOT NULL,
	[Phone] [varchar](20) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON 

INSERT [dbo].[tblCategory] ([CategoryId], [CategoryName]) VALUES (1, N'Laundry Soap')
INSERT [dbo].[tblCategory] ([CategoryId], [CategoryName]) VALUES (2, N'Kitchen Soap')
INSERT [dbo].[tblCategory] ([CategoryId], [CategoryName]) VALUES (3, N'Guest Soap')
INSERT [dbo].[tblCategory] ([CategoryId], [CategoryName]) VALUES (4, N'Medicated Soap')
INSERT [dbo].[tblCategory] ([CategoryId], [CategoryName]) VALUES (5, N'Beauty Soap')
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
GO
INSERT [dbo].[tblLogin] ([UserName], [Password]) VALUES (N'user', N'password')
GO
SET IDENTITY_INSERT [dbo].[tblProduct] ON 

INSERT [dbo].[tblProduct] ([ProductId], [ProductName], [ProductQty], [ProductPrice], [ProductDescription], [ProductCategory]) VALUES (1, N'Pure Clean', 10, 20, N'Mainly for white cloths', N'Laundry Soap')
INSERT [dbo].[tblProduct] ([ProductId], [ProductName], [ProductQty], [ProductPrice], [ProductDescription], [ProductCategory]) VALUES (2, N'Crystal Breez', 140, 30, N'Made using lime and turmeric', N'Kitchen Soap')
INSERT [dbo].[tblProduct] ([ProductId], [ProductName], [ProductQty], [ProductPrice], [ProductDescription], [ProductCategory]) VALUES (3, N'Morning dew', 150, 50, N'Mini soap made with rose petals', N'Guest Soap')
INSERT [dbo].[tblProduct] ([ProductId], [ProductName], [ProductQty], [ProductPrice], [ProductDescription], [ProductCategory]) VALUES (4, N'HealingSoap', 130, 60, N'Made with turmeric and cineman', N'Medicated Soap')
INSERT [dbo].[tblProduct] ([ProductId], [ProductName], [ProductQty], [ProductPrice], [ProductDescription], [ProductCategory]) VALUES (5, N'YoungShine', 140, 70, N'Made with veniwal and kokum', N'Beauty Soap')
SET IDENTITY_INSERT [dbo].[tblProduct] OFF
GO
INSERT [dbo].[tblUser] ([Username], [Fullname], [Password], [ConfirmPassword], [Phone]) VALUES (N'example_user', N'John Doe', N'password123', N'password123', N'123-456-7890')
INSERT [dbo].[tblUser] ([Username], [Fullname], [Password], [ConfirmPassword], [Phone]) VALUES (N'user', N'user', N'password', N'password', N'123-456-7890')
GO
