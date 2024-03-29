USE [SHOPLONG5]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[address_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[address_name] [nvarchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[address_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[brand_id] [int] IDENTITY(1,1) NOT NULL,
	[brand_name] [varchar](20) NULL,
	[isActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[brand_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[cartid] [int] IDENTITY(1,1) NOT NULL,
	[common_id] [int] NOT NULL,
	[create_at] [varchar](255) NULL,
	[username] [varchar](50) NOT NULL,
	[amount] [int] NOT NULL,
 CONSTRAINT [PK__Cart__41663FC0B600D0AD] PRIMARY KEY CLUSTERED 
(
	[cartid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [varchar](50) NULL,
	[create_at] [varchar](200) NULL,
	[isActive] [bit] NULL,
	[cate_url] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[color_id] [int] IDENTITY(1,1) NOT NULL,
	[color_name] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[color_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Content_aboutus]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content_aboutus](
	[contentid] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[description] [nvarchar](max) NULL,
	[create_by] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[contentid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[discountid] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NULL,
	[discount_percent] [decimal](5, 2) NULL,
	[start_at] [varchar](50) NULL,
	[end_at] [varchar](50) NULL,
	[product_detail_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[discountid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Features]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[feature_id] [int] IDENTITY(1,1) NOT NULL,
	[url] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[feature_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupAccounts]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupAccounts](
	[group_id] [int] NOT NULL,
	[username] [varchar](50) NOT NULL,
	[createat] [varchar](255) NULL,
 CONSTRAINT [PK__GroupAcc__FA4A29F7E6D5E82C] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC,
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupFeatures]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupFeatures](
	[group_id] [int] NOT NULL,
	[feature_id] [int] NOT NULL,
	[createat] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[group_id] ASC,
	[feature_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[group_id] [int] IDENTITY(1,1) NOT NULL,
	[groupName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[group_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[image_id] [int] IDENTITY(1,1) NOT NULL,
	[product_detail_id] [int] NOT NULL,
	[color_id] [int] NOT NULL,
	[image_url] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[image_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[total_price] [decimal](10, 2) NOT NULL,
	[status_order] [varchar](50) NOT NULL,
	[order_date] [varchar](50) NOT NULL,
	[addressid] [int] NOT NULL,
 CONSTRAINT [PK__order__080E3775B9699926] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_detail]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_detail](
	[orderdetail_id] [int] IDENTITY(1,1) NOT NULL,
	[common_id] [int] NOT NULL,
	[amount] [int] NOT NULL,
	[total_unit_price] [decimal](10, 2) NULL,
	[orderid] [int] NOT NULL,
 CONSTRAINT [PK__order_de__59AE7411E1B818A2] PRIMARY KEY CLUSTERED 
(
	[orderdetail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Details]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Details](
	[product_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [varchar](255) NOT NULL,
	[price] [float] NULL,
	[stock] [int] NULL,
	[category_id] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
	[create_at] [varchar](200) NULL,
	[isActive] [bit] NULL,
	[isSale] [bit] NULL,
	[brand_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[product_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[review_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[common_id] [int] NULL,
	[rating] [int] NULL,
	[comment] [text] NULL,
	[review_date] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[review_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Size_Color_Stock]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size_Color_Stock](
	[common_id] [int] IDENTITY(1,1) NOT NULL,
	[size_id] [int] NULL,
	[color_id] [int] NULL,
	[quantity_stock] [int] NULL,
	[product_detail_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[common_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[size_id] [int] IDENTITY(1,1) NOT NULL,
	[size_name] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[size_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/13/2024 10:57:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[displayName] [nvarchar](50) NULL,
	[phone_number] [varchar](20) NULL,
	[email] [varchar](200) NULL,
	[avatar_url] [varchar](200) NULL,
	[create_at] [varchar](500) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__Users__F3DBC573C25AC361] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (1, N'longnk', N'Ha Noi')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (2, N'longnk', N'USA')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (3, N'longnk123', N'Hola')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (4, N'longnk123', N'Viet Name')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (5, N'longnk', N'Germany')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (8, N'longnk', N'England')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (9, N'longnk', N'VietNam')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (10, N'longbeo', N'England')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (11, N'longbeo', N'VietNam')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (12, N'longnk', N'London')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (13, N'longbeo', N'London')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (14, N'longbeo', N'Hanoi')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (15, N'longbeo', N'Thailand')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (16, N'longbeo', N'Lao')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (17, N'longnk', N'Thailand')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (18, N'longnk', N'Thach Thach, Ha Noi')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (19, N'longnk', N'Binh Phu')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (20, N'longnk', N'Phu Hoa')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (21, N'longnk', N'Hola')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (22, N'long', N'London')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (23, N'long', N'England')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (24, N'long', N'Thailand')
INSERT [dbo].[Address] ([address_id], [username], [address_name]) VALUES (25, N'long123', N'London')
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([brand_id], [brand_name], [isActive]) VALUES (1, N'LEVI''S', 1)
INSERT [dbo].[Brand] ([brand_id], [brand_name], [isActive]) VALUES (2, N'ADIDAS', 1)
INSERT [dbo].[Brand] ([brand_id], [brand_name], [isActive]) VALUES (3, N'NIKE', 1)
INSERT [dbo].[Brand] ([brand_id], [brand_name], [isActive]) VALUES (4, N'H&M', 1)
INSERT [dbo].[Brand] ([brand_id], [brand_name], [isActive]) VALUES (5, N'Long', 0)
INSERT [dbo].[Brand] ([brand_id], [brand_name], [isActive]) VALUES (6, N'ALOOO', 0)
INSERT [dbo].[Brand] ([brand_id], [brand_name], [isActive]) VALUES (7, N'Nguyen Khac Long Alo', 0)
INSERT [dbo].[Brand] ([brand_id], [brand_name], [isActive]) VALUES (8, N'Long', 0)
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([cartid], [common_id], [create_at], [username], [amount]) VALUES (19, 3, N'3/11/2024 12:53:11 AM', N'longbeo', 4)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([category_id], [category_name], [create_at], [isActive], [cate_url]) VALUES (1, N'Shoe', NULL, 1, N'shoe.jpg')
INSERT [dbo].[Categories] ([category_id], [category_name], [create_at], [isActive], [cate_url]) VALUES (2, N'Glasses', NULL, 1, N'glasses.jpg')
INSERT [dbo].[Categories] ([category_id], [category_name], [create_at], [isActive], [cate_url]) VALUES (3, N'Clothes', NULL, 1, N'clothes.jpg')
INSERT [dbo].[Categories] ([category_id], [category_name], [create_at], [isActive], [cate_url]) VALUES (4, N'Bag', NULL, 1, N'bag.jpg')
INSERT [dbo].[Categories] ([category_id], [category_name], [create_at], [isActive], [cate_url]) VALUES (5, N'Laptop', NULL, 0, NULL)
INSERT [dbo].[Categories] ([category_id], [category_name], [create_at], [isActive], [cate_url]) VALUES (6, N'Long', NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (1, N'Red')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (2, N'Blue')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (3, N'Pink')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (4, N'Black')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (5, N'White')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (6, N'Brown')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (7, N'Purple')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (8, N'Green')
INSERT [dbo].[Colors] ([color_id], [color_name]) VALUES (9, N'Orange')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Features] ON 

INSERT [dbo].[Features] ([feature_id], [url]) VALUES (1, N'/userprofile')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (2, N'/editprofile')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (3, N'/addnewaddress')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (4, N'/doEdit')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (5, N'/dochangepass')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (8, N'/managebrands')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (9, N'/addnewbrand')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (10, N'/editbrand')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (11, N'/updateBrand')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (12, N'/manageproduct')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (13, N'/searchbyname_admin')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (14, N'/detailproductforadmin')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (15, N'/editproductforadmin')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (16, N'/managecate')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (17, N'/addnewcate')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (18, N'/editcate')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (19, N'/updateCate')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (20, N'/manageuser')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (21, N'/changepass')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (22, N'/doshopping')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (23, N'/upload_avatar')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (24, N'/completeorder')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (25, N'/completeorderincart')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (26, N'/viewcart')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (27, N'/deletecart')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (28, N'/manageorder')
INSERT [dbo].[Features] ([feature_id], [url]) VALUES (29, N'/orderhistory')
SET IDENTITY_INSERT [dbo].[Features] OFF
GO
INSERT [dbo].[GroupAccounts] ([group_id], [username], [createat]) VALUES (1, N'long', NULL)
INSERT [dbo].[GroupAccounts] ([group_id], [username], [createat]) VALUES (1, N'long123', N'2024-03-13 16:30:42')
INSERT [dbo].[GroupAccounts] ([group_id], [username], [createat]) VALUES (1, N'longbeo', N'2024-03-07 13:30:34')
INSERT [dbo].[GroupAccounts] ([group_id], [username], [createat]) VALUES (1, N'longnk', NULL)
INSERT [dbo].[GroupAccounts] ([group_id], [username], [createat]) VALUES (1, N'longnk123', NULL)
INSERT [dbo].[GroupAccounts] ([group_id], [username], [createat]) VALUES (1, N'longnk12345', NULL)
INSERT [dbo].[GroupAccounts] ([group_id], [username], [createat]) VALUES (2, N'longnk', NULL)
GO
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 1, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 2, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 3, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 4, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 5, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 21, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 22, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 23, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 24, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 25, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 26, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 27, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (1, 29, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 8, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 9, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 10, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 11, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 12, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 13, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 14, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 15, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 16, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 17, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 18, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 19, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 20, NULL)
INSERT [dbo].[GroupFeatures] ([group_id], [feature_id], [createat]) VALUES (2, 28, NULL)
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([group_id], [groupName]) VALUES (1, N'customer')
INSERT [dbo].[Groups] ([group_id], [groupName]) VALUES (2, N'admin')
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (1, 1, 1, N'p111.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (2, 1, 1, N'p112.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (3, 1, 1, N'p113.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (4, 1, 1, N'p114.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (5, 1, 6, N'p161.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (6, 1, 6, N'p162.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (7, 1, 6, N'p163.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (8, 1, 6, N'p164.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (9, 2, 8, N'p281.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (10, 2, 8, N'p282.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (11, 2, 8, N'p283.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (12, 2, 8, N'p284.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (13, 2, 6, N'p261.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (14, 2, 6, N'p262.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (15, 2, 6, N'p263.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (16, 2, 6, N'p264.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (17, 2, 4, N'p241.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (18, 2, 4, N'p242.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (19, 2, 4, N'p243.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (20, 2, 4, N'p244.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (24, 3, 4, N'p341.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (25, 3, 4, N'p342.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (26, 3, 4, N'p343.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (27, 3, 4, N'p344.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (28, 3, 6, N'p361.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (29, 3, 6, N'p362.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (30, 3, 6, N'p363.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (31, 3, 6, N'p364.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (32, 3, 8, N'p381.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (33, 3, 8, N'p382.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (34, 3, 8, N'p383.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (35, 3, 8, N'p384.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (36, 4, 4, N'p441.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (37, 4, 4, N'p442.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (38, 4, 4, N'p443.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (39, 4, 4, N'p444.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (40, 5, 5, N'p551.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (41, 5, 5, N'p552.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (42, 5, 5, N'p553.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (43, 5, 5, N'p554.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (44, 6, 6, N'p661.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (45, 6, 6, N'p662.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (46, 6, 6, N'p663.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (47, 6, 6, N'p664.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (48, 7, 7, N'p771.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (49, 7, 7, N'p772.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (50, 7, 7, N'p773.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (51, 7, 7, N'p774.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (52, 8, 8, N'p881.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (53, 8, 8, N'p882.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (54, 8, 8, N'p883.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (55, 8, 8, N'p884.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (56, 9, 9, N'p991.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (57, 9, 9, N'p992.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (58, 9, 9, N'p993.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (59, 9, 9, N'p994.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (60, 10, 1, N'p1011.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (61, 10, 1, N'p1012.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (62, 10, 1, N'p1013.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (63, 10, 1, N'p1014.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (64, 11, 7, N'p1171.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (65, 11, 7, N'p1172.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (66, 11, 7, N'p1173.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (67, 11, 7, N'p1174.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (68, 12, 9, N'p1291.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (69, 12, 9, N'p1292.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (70, 12, 9, N'p1293.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (71, 12, 9, N'p1294.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (72, 13, 5, N'p1351.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (73, 13, 5, N'p1352.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (74, 13, 5, N'p1353.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (75, 13, 5, N'p1354.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (76, 14, 6, N'p1461.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (77, 14, 6, N'p1462.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (79, 14, 6, N'p1463.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (80, 14, 6, N'p1464.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (81, 15, 7, N'p1571.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (82, 15, 7, N'p1572.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (83, 15, 7, N'p1573.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (84, 15, 7, N'p1574.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (85, 16, 8, N'p1681.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (86, 16, 8, N'p1682.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (87, 16, 8, N'p1683.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (88, 16, 8, N'p1684.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (89, 18, 9, N'p1891.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (90, 18, 9, N'p1892.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (91, 18, 9, N'p1893.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (92, 18, 9, N'p1894.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (93, 19, 1, N'p1911.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (94, 19, 1, N'p1912.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (95, 19, 1, N'p1913.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (96, 19, 1, N'p1914.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (97, 20, 7, N'p2071.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (98, 20, 7, N'p2072.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (99, 20, 7, N'p2073.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (100, 20, 7, N'p2074.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (101, 21, 3, N'p2131.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (102, 21, 3, N'p2132.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (103, 21, 3, N'p2133.jpg')
GO
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (104, 21, 3, N'p2134.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (105, 22, 4, N'p2241.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (106, 22, 4, N'p2242.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (107, 22, 4, N'p2243.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (108, 22, 4, N'p2244.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (109, 23, 2, N'p2321.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (110, 23, 2, N'p2322.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (111, 23, 2, N'p2323.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (112, 23, 2, N'p2324.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (113, 24, 4, N'p2441.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (114, 24, 4, N'p2442.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (115, 24, 4, N'p2443.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (116, 24, 4, N'p2444.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (117, 25, 7, N'p2571.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (118, 25, 7, N'p2572.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (119, 25, 7, N'p2573.jpg')
INSERT [dbo].[Images] ([image_id], [product_detail_id], [color_id], [image_url]) VALUES (120, 25, 7, N'p2574.jpg')
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[order] ON 

INSERT [dbo].[order] ([orderid], [username], [total_price], [status_order], [order_date], [addressid]) VALUES (2, N'longnk', CAST(4810.00 AS Decimal(10, 2)), N'processing', N'3/11/2024 1:10:02 PM', 18)
INSERT [dbo].[order] ([orderid], [username], [total_price], [status_order], [order_date], [addressid]) VALUES (3, N'longnk', CAST(910.00 AS Decimal(10, 2)), N'processing', N'3/11/2024 1:14:46 PM', 18)
INSERT [dbo].[order] ([orderid], [username], [total_price], [status_order], [order_date], [addressid]) VALUES (4, N'longnk', CAST(2010.00 AS Decimal(10, 2)), N'processing', N'3/12/2024 2:29:50 PM', 1)
INSERT [dbo].[order] ([orderid], [username], [total_price], [status_order], [order_date], [addressid]) VALUES (5, N'longnk', CAST(1010.00 AS Decimal(10, 2)), N'processing', N'3/13/2024 4:34:06 PM', 1)
SET IDENTITY_INSERT [dbo].[order] OFF
GO
SET IDENTITY_INSERT [dbo].[order_detail] ON 

INSERT [dbo].[order_detail] ([orderdetail_id], [common_id], [amount], [total_unit_price], [orderid]) VALUES (4, 14, 4, NULL, 2)
INSERT [dbo].[order_detail] ([orderdetail_id], [common_id], [amount], [total_unit_price], [orderid]) VALUES (5, 46, 1, NULL, 3)
INSERT [dbo].[order_detail] ([orderdetail_id], [common_id], [amount], [total_unit_price], [orderid]) VALUES (6, 3, 1, NULL, 4)
INSERT [dbo].[order_detail] ([orderdetail_id], [common_id], [amount], [total_unit_price], [orderid]) VALUES (7, 4, 1, NULL, 4)
INSERT [dbo].[order_detail] ([orderdetail_id], [common_id], [amount], [total_unit_price], [orderid]) VALUES (8, 4, 1, NULL, 5)
SET IDENTITY_INSERT [dbo].[order_detail] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Details] ON 

INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (1, N'Air Jordan 1 Low SE', 1000, NULL, 1, N'Here''s some straightforward, good-looking AJ1s. Were you expecting anything less? Crafted from crisp leather, they feature comfortable Nike Air cushioning in the sole. An embroidered Swoosh logo puts the finishing touch on this all-time favourite.', NULL, 1, 0, 3)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (2, N'Nike Air Force 1 ''07', 900, NULL, 1, N'The radiance lives on in the Nike Air Force 1 ''07, the basketball original that puts a fresh spin on what you know best: durably stitched overlays, clean finishes and the perfect amount of flash to make you shine.', NULL, 1, 0, 3)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (3, N'Nike G.T. Cut 3 ASW EP', 1200, NULL, 1, N'How can you separate your game when it''s winning time? Start by lacing up in the G.T. Cut 3. Designed to help you create space for stepback jumpers and backdoor cuts, its sticky multi-court traction helps you stop in an instant and shift gears at will. And when you''re making all those game-changing plays, the newly added, ultra-responsive ZoomX foam helps keep you fresh for all four quarters. This design straps you into the wayback machine and teleports you to one of Nike''s golden eras of hoops, with direct inspiration derived from the famed Air Zoom Flight 5. Donned by the legends, destined to help take your game to the next level. With its extra-durable rubber outsole, this version gives you traction for outdoor courts.', NULL, 1, 0, 3)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (4, N'Air Pegasus ''89 G NRG', 1000, NULL, 1, N'We waded into the waste paper basket for this special-edition Air Pegasus ''89 G. Crinkly Swoosh logos and slick, elastic materials create a design dressed in dustbin debris. Then we added wet-rubber traction to take on the sketchiest of terrain: hop-soaked greens. But the ride? That''s pure Peg. Air Zoom is comfortable enough to walk all 18 of the rowdiest stop on the tour.', NULL, 1, 0, 3)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (5, N'GAZELLE SHOES', 1001, NULL, 1, N'No returns, no refunds
Item is confirmed after payment confirmation. No refunds, returns or exchanges will be entertained except as required by law. This product is excluded from all promotional discounts and offers. Limited to 1 Quantity per Order.', NULL, 1, 0, 2)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (6, N'GAZELLE 85 SHOES', 555, NULL, 1, N'This product is excluded from all promotional discounts and offers.', NULL, 1, 0, 2)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (7, N'SAMBA OG SHOES', 1900, NULL, 1, NULL, NULL, 1, 0, 2)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (8, N'LEVI''S® MEN''S STAG RUNNER SNEAKERS', 100, NULL, 1, N'A sneaker with the look of an old-school running shoe, these Stag Runners bring the vintage into now. The classic elements are all here—the simple rubber sole curving up around the heel, the layer foam cushioning, the familiar silhouette—but with modern crafting.', NULL, 1, 0, 1)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (9, N'LEVI''S® MEN''S LS2 SNEAKERS', 9000, NULL, 1, N'Simple, stylish and constructed with careful craftsmanship. These LS2 Sneakers are crafted with durable canvas and a lace-up design—and will be a staple in your wardrobe for seasons to come.', NULL, 1, 0, 1)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (10, N'LEVI''S® MEN''S ARCHIE SNEAKERS', 100000, NULL, 1, N'A classic, wear-with-anything sneaker. Simple and streamlined, these Archie Sneakers are inherently effortless—just like our jeans.', NULL, 1, 0, 1)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (11, N'Ballet Flats', 20, NULL, 1, NULL, NULL, 1, 0, 4)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (12, N'Textured Slingbacks', 40, NULL, 1, NULL, NULL, 1, 0, 4)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (13, N'Nike Rave Polarized', 10, NULL, 2, N'Express your style in bold color with the Nike Rave Sunglasses. Sporting highly reflective polarized lenses, these sunglasses do more than just shade.', NULL, 1, 0, 3)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (14, N'Nike City Hero S', 100, NULL, 2, N'The Nike City Hero Small Fit puts a fresh spin on vintage shades. The classic oversized style combines lightweight comfort and easy temple adjustability to provide all day comfort. Designed specifically to accommodate a smaller fit.', NULL, 1, 0, 3)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (15, N'Nike Ace Driver Polarized', 1000, NULL, 2, N'From course to club to courtyardthe Nike Ace Driver shades are modern classics ready for action. The ultralight, titanium design covers all the bases with a full coverage fit that defends against light leaks, a flat top bar that fits under your cap, and new U-shaped nose pads, which sit flush on your face and wont pull your hair if you decide to wear your shades as a headband.', NULL, 1, 0, 3)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (16, N'Nike Livefree Classic Mirrored', 10, NULL, 2, N'The Nike LiveFree Classic Sunglasses elevate your outdoor look with a classic, oversized design featuring a dose of bold color and unexpected surprise on the temples: a texturized, waffle pattern on the outside and a positive livefree mantra on the inside.', NULL, 1, 0, 3)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (18, N'Nike Variant I', 30, NULL, 2, N'Meet the Nike Variant I. Made with mismatched details and a chunky, rectangular frame, these shades perfectly combine your sporty attitude and bold, streetwear aesthetic.', NULL, 1, 0, 3)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (19, N'Nike Sportswear', 10, NULL, 3, N'Mixing midweight cotton and a roomy fit with fresh, earth-loving graphics, this Nike tee adds the perfect layer to your wear-anywhere wardrobe.', NULL, 1, 0, 3)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (20, N'CLASSIC STANDARD FIT WESTERN SHIRT', 40, NULL, 3, N'Cowboy boots and chaps not included. As a brand with deep roots in the American West, there''s nothing we love more than this rugged-yet-put-together Classic Standard Fit Western Shirt. True to the classic, this essential features a distinctive snap placket, pointed yoke and curved hem. Pair it with your favorite blue jeans for the iconic denim-on-denim look, or size up and wear like a jacket—there are no rules in the Wild West.', NULL, 1, 0, 1)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (21, N'SERENO AEROREADY 3-STRIPES TEE', 10, NULL, 3, NULL, NULL, 1, 0, 2)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (22, N'Double-breasted Trench Coat', 10, NULL, 3, NULL, NULL, 1, 0, 4)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (23, N'Knot-detail shoulder bag', 300, NULL, 4, NULL, NULL, 1, 0, 4)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (24, N'ADICOLOR BACKPACK', 100, NULL, 4, NULL, NULL, 1, 0, 2)
INSERT [dbo].[Product_Details] ([product_detail_id], [product_name], [price], [stock], [category_id], [description], [create_at], [isActive], [isSale], [brand_id]) VALUES (25, N'Nike Hoops Elite
Backpack (32L)', 10000001, NULL, 4, NULL, NULL, 1, 0, 3)
SET IDENTITY_INSERT [dbo].[Product_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Size_Color_Stock] ON 

INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (1, 4, 1, 100, 1)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (2, 5, 1, 80, 1)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (3, 6, 1, 8, 1)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (4, 4, 6, 8, 1)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (5, 5, 6, 0, 1)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (6, 7, 8, 10, 2)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (7, 7, 6, 19, 2)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (9, 2, 4, 10, 2)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (11, 4, 4, 9, 3)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (12, 4, 8, 8, 3)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (14, 5, 6, 4, 3)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (15, 6, 4, 8, 3)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (16, 4, 4, 44, 4)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (17, 5, 5, 5, 5)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (18, 6, 6, 6, 6)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (19, 7, 7, 7, 7)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (20, 2, 8, 8, 8)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (21, 3, 9, 9, 9)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (25, 4, 1, 1, 10)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (26, 7, 7, 7, 11)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (27, 3, 9, 10, 12)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (28, 1, 5, 5, 13)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (29, 2, 6, 6, 14)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (30, 3, 7, 7, 15)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (31, 4, 8, 8, 16)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (33, 5, 9, 9, 18)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (34, 8, 1, 10, 19)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (35, 9, 1, 10, 19)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (36, 8, 7, 10, 20)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (37, 9, 7, 10, 20)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (38, 10, 7, 10, 20)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (39, 11, 7, 10, 20)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (40, 11, 3, 100, 21)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (41, 10, 4, 18, 22)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (42, 8, 2, 19, 23)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (43, 9, 4, 10, 24)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (44, 10, 7, 10, 25)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (45, 5, 8, 1000, 2)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (46, 4, 4, 0, 2)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (47, 1, 4, 1, 2)
INSERT [dbo].[Size_Color_Stock] ([common_id], [size_id], [color_id], [quantity_stock], [product_detail_id]) VALUES (48, 2, 6, 1, 2)
SET IDENTITY_INSERT [dbo].[Size_Color_Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[Sizes] ON 

INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (1, N'38')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (2, N'39')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (3, N'40')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (4, N'41')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (5, N'42')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (6, N'43')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (7, N'44')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (8, N'M')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (9, N'L')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (10, N'XL')
INSERT [dbo].[Sizes] ([size_id], [size_name]) VALUES (11, N'XXL')
SET IDENTITY_INSERT [dbo].[Sizes] OFF
GO
INSERT [dbo].[Users] ([username], [password], [displayName], [phone_number], [email], [avatar_url], [create_at], [isActive]) VALUES (N'long', N'123', N'LongNguyen', N'0386045795', N'long@gmail.com', N'long_avt_03126964-e66c-4f9b-ba70-05e1ee774f83.jpg', NULL, 1)
INSERT [dbo].[Users] ([username], [password], [displayName], [phone_number], [email], [avatar_url], [create_at], [isActive]) VALUES (N'long123', N'123', N'LongNguyen', N'1234567890', N'long123@gmail.com', N'long123_png-transparent-trafalgar-d-water-law-monkey-d-luffy-donquixote-doflamingo-roronoa-zoro-one-piece-logo-luffy-logo-jolly-roger-smiley_ac254aaf-dc3d-45a1-874c-3e63b55d5d80.png', NULL, 1)
INSERT [dbo].[Users] ([username], [password], [displayName], [phone_number], [email], [avatar_url], [create_at], [isActive]) VALUES (N'longbeo', N'123', N'longbeo', N'0386045795', N'longbeo@gmail.com', N'longbeo_412035946_842204204580297_7563689038935233321_n.jpg', NULL, 1)
INSERT [dbo].[Users] ([username], [password], [displayName], [phone_number], [email], [avatar_url], [create_at], [isActive]) VALUES (N'longnk', N'123', N'Nguyen Khac Long', N'12345678910', N'longnk@gmail.com', N'longnk_MauchlyPortrait.jpg', NULL, 1)
INSERT [dbo].[Users] ([username], [password], [displayName], [phone_number], [email], [avatar_url], [create_at], [isActive]) VALUES (N'longnk123', N'123', N'LongNguyen', N'098765431', N'longnk123@gmail.com', NULL, NULL, 1)
INSERT [dbo].[Users] ([username], [password], [displayName], [phone_number], [email], [avatar_url], [create_at], [isActive]) VALUES (N'longnk12345', N'123', N'KhacLong', N'10101010101', N'longnk12345@gmail.com', NULL, NULL, 1)
GO
ALTER TABLE [dbo].[Brand] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Product_Details] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Product_Details] ADD  DEFAULT ((0)) FOR [isSale]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__isActive__6FE99F9F]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK__Address__usernam__70DDC3D8] FOREIGN KEY([username])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK__Address__usernam__70DDC3D8]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK__Cart__common_id__71D1E811] FOREIGN KEY([common_id])
REFERENCES [dbo].[Size_Color_Stock] ([common_id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK__Cart__common_id__71D1E811]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK__Cart__username__72C60C4A] FOREIGN KEY([username])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK__Cart__username__72C60C4A]
GO
ALTER TABLE [dbo].[Content_aboutus]  WITH CHECK ADD  CONSTRAINT [FK__Content_a__creat__73BA3083] FOREIGN KEY([create_by])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Content_aboutus] CHECK CONSTRAINT [FK__Content_a__creat__73BA3083]
GO
ALTER TABLE [dbo].[Discount]  WITH CHECK ADD FOREIGN KEY([product_detail_id])
REFERENCES [dbo].[Product_Details] ([product_detail_id])
GO
ALTER TABLE [dbo].[GroupAccounts]  WITH CHECK ADD  CONSTRAINT [FK__GroupAcco__group__75A278F5] FOREIGN KEY([group_id])
REFERENCES [dbo].[Groups] ([group_id])
GO
ALTER TABLE [dbo].[GroupAccounts] CHECK CONSTRAINT [FK__GroupAcco__group__75A278F5]
GO
ALTER TABLE [dbo].[GroupAccounts]  WITH CHECK ADD  CONSTRAINT [FK__GroupAcco__usern__76969D2E] FOREIGN KEY([username])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[GroupAccounts] CHECK CONSTRAINT [FK__GroupAcco__usern__76969D2E]
GO
ALTER TABLE [dbo].[GroupFeatures]  WITH CHECK ADD FOREIGN KEY([feature_id])
REFERENCES [dbo].[Features] ([feature_id])
GO
ALTER TABLE [dbo].[GroupFeatures]  WITH CHECK ADD FOREIGN KEY([group_id])
REFERENCES [dbo].[Groups] ([group_id])
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD FOREIGN KEY([color_id])
REFERENCES [dbo].[Colors] ([color_id])
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD FOREIGN KEY([product_detail_id])
REFERENCES [dbo].[Product_Details] ([product_detail_id])
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK__order__username__7B5B524B] FOREIGN KEY([username])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK__order__username__7B5B524B]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Address] FOREIGN KEY([addressid])
REFERENCES [dbo].[Address] ([address_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_Order_Address]
GO
ALTER TABLE [dbo].[order_detail]  WITH CHECK ADD  CONSTRAINT [FK__order_det__commo__7C4F7684] FOREIGN KEY([common_id])
REFERENCES [dbo].[Size_Color_Stock] ([common_id])
GO
ALTER TABLE [dbo].[order_detail] CHECK CONSTRAINT [FK__order_det__commo__7C4F7684]
GO
ALTER TABLE [dbo].[order_detail]  WITH CHECK ADD  CONSTRAINT [FK__order_det__order__7D439ABD] FOREIGN KEY([orderid])
REFERENCES [dbo].[order] ([orderid])
GO
ALTER TABLE [dbo].[order_detail] CHECK CONSTRAINT [FK__order_det__order__7D439ABD]
GO
ALTER TABLE [dbo].[Product_Details]  WITH CHECK ADD FOREIGN KEY([brand_id])
REFERENCES [dbo].[Brand] ([brand_id])
GO
ALTER TABLE [dbo].[Product_Details]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([category_id])
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD FOREIGN KEY([common_id])
REFERENCES [dbo].[Size_Color_Stock] ([common_id])
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK__Reviews__usernam__01142BA1] FOREIGN KEY([username])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK__Reviews__usernam__01142BA1]
GO
ALTER TABLE [dbo].[Size_Color_Stock]  WITH CHECK ADD FOREIGN KEY([color_id])
REFERENCES [dbo].[Colors] ([color_id])
GO
ALTER TABLE [dbo].[Size_Color_Stock]  WITH CHECK ADD FOREIGN KEY([product_detail_id])
REFERENCES [dbo].[Product_Details] ([product_detail_id])
GO
ALTER TABLE [dbo].[Size_Color_Stock]  WITH CHECK ADD FOREIGN KEY([size_id])
REFERENCES [dbo].[Sizes] ([size_id])
GO
