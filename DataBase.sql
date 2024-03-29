USE [eshop_Identity2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/9/2021 10:42:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 2/9/2021 10:42:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[ProductId] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[CartId] [int] NOT NULL,
	[SellerProductId] [int] NOT NULL,
 CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 2/9/2021 10:42:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[UserId] [nvarchar](450) NULL,
	[BrowserId] [uniqueidentifier] NOT NULL,
	[Finished] [bit] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2/9/2021 10:42:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[ParentCategoryId] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryImages]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[Src] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NULL,
	[ProvinceId] [int] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomePageImages]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomePageImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[Src] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
	[ImageLocation] [int] NOT NULL,
 CONSTRAINT [PK_HomePageImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[SellerProductId] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[UserId] [nvarchar](450) NULL,
	[PaymentId] [int] NOT NULL,
	[OrderState] [int] NOT NULL,
	[Addrress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Amount] [int] NOT NULL,
	[IsPayed] [bit] NOT NULL,
	[PayDate] [datetime2](7) NULL,
	[Authority] [nvarchar](max) NULL,
	[RefId] [int] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductFeatures]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductFeatures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[ProductId] [int] NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductFeatures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[ProductId] [int] NOT NULL,
	[Src] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[Brand] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [int] NOT NULL,
	[Inventory] [int] NOT NULL,
	[Displayed] [bit] NOT NULL,
	[ViewCount] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provinces]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provinces](
	[ProvinceId] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Provinces] PRIMARY KEY CLUSTERED 
(
	[ProvinceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SCategories]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[ParentCategoryId] [int] NULL,
	[SCategoryType] [int] NOT NULL,
 CONSTRAINT [PK_SCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellerProducts]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[ProductId] [int] NOT NULL,
	[SellerId] [int] NOT NULL,
	[SellerPrice] [int] NOT NULL,
	[Inventory] [int] NOT NULL,
 CONSTRAINT [PK_SellerProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sellers]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sellers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[ShopName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[UserName] [nvarchar](450) NOT NULL,
	[Addrress] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Sellers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InsertTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeleteTime] [datetime2](7) NULL,
	[Src] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sliders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[ProviderKey] ASC,
	[LoginProvider] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](450) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 2/9/2021 10:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210102073841_First2', N'3.1.0')
SET IDENTITY_INSERT [dbo].[CartItems] ON 

INSERT [dbo].[CartItems] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [Count], [Price], [CartId], [SellerProductId]) VALUES (1, CAST(N'2021-01-02T14:05:03.0292776' AS DateTime2), NULL, 0, NULL, 1, 1, 10500000, 1, 1)
INSERT [dbo].[CartItems] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [Count], [Price], [CartId], [SellerProductId]) VALUES (2, CAST(N'2021-01-06T16:23:52.2903150' AS DateTime2), NULL, 0, NULL, 2, 1, 11000000, 2, 3)
INSERT [dbo].[CartItems] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [Count], [Price], [CartId], [SellerProductId]) VALUES (3, CAST(N'2021-01-06T16:27:12.7891253' AS DateTime2), NULL, 0, NULL, 2, 1, 11000000, 3, 3)
INSERT [dbo].[CartItems] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [Count], [Price], [CartId], [SellerProductId]) VALUES (4, CAST(N'2021-01-07T13:08:04.4724455' AS DateTime2), NULL, 1, CAST(N'2021-01-07T13:08:10.8133448' AS DateTime2), 1, 1, 10500000, 4, 1)
SET IDENTITY_INSERT [dbo].[CartItems] OFF
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [UserId], [BrowserId], [Finished]) VALUES (1, CAST(N'2021-01-02T14:05:02.8530285' AS DateTime2), NULL, 0, NULL, N'700d83aa-6789-44b0-be82-4f660ec29cd3', N'15368c28-763f-43a2-a47f-3df1cee13c0e', 1)
INSERT [dbo].[Carts] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [UserId], [BrowserId], [Finished]) VALUES (2, CAST(N'2021-01-06T16:23:52.1896847' AS DateTime2), NULL, 0, NULL, N'81b82afa-0c97-474e-af8c-8ce6cb183205', N'15368c28-763f-43a2-a47f-3df1cee13c0e', 1)
INSERT [dbo].[Carts] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [UserId], [BrowserId], [Finished]) VALUES (3, CAST(N'2021-01-06T16:27:12.7098733' AS DateTime2), NULL, 0, NULL, N'a5a43138-8357-4cb3-b9e8-11d9343fda1d', N'15368c28-763f-43a2-a47f-3df1cee13c0e', 1)
INSERT [dbo].[Carts] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [UserId], [BrowserId], [Finished]) VALUES (4, CAST(N'2021-01-07T13:08:04.3670481' AS DateTime2), NULL, 0, NULL, N'700d83aa-6789-44b0-be82-4f660ec29cd3', N'15368c28-763f-43a2-a47f-3df1cee13c0e', 1)
SET IDENTITY_INSERT [dbo].[Carts] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (1, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لپ تاپ', 8)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (2, CAST(N'2020-11-17T13:57:42.6036496' AS DateTime2), NULL, 0, NULL, N'موبایل', 8)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (3, CAST(N'2020-11-18T12:26:13.7053580' AS DateTime2), NULL, 0, NULL, N'خانه و آشپزخانه', NULL)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (4, CAST(N'2020-11-18T12:26:31.3869250' AS DateTime2), NULL, 0, NULL, N'شستشو و نظافت', 3)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (5, CAST(N'2020-11-18T15:58:53.2824627' AS DateTime2), NULL, 0, NULL, N'تلویزیون ', 19)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (6, CAST(N'2020-11-21T10:15:32.5627678' AS DateTime2), NULL, 0, NULL, N'مد و پوشاک', NULL)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (7, CAST(N'2020-11-21T10:15:32.5627678' AS DateTime2), NULL, 0, NULL, N'دوربین عکاسی', 8)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (8, CAST(N'2020-11-23T13:35:43.2679901' AS DateTime2), NULL, 0, NULL, N'کالای دیجیتال', NULL)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (9, CAST(N'2020-11-23T13:35:43.2679901' AS DateTime2), NULL, 0, NULL, N'اسباب بازی، کودک و نوزاد', NULL)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (10, CAST(N'2020-11-23T13:35:43.2679901' AS DateTime2), NULL, 0, NULL, N'خودرو، ابزار و تجهیزات صنعتی', NULL)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (11, CAST(N'2020-11-23T13:35:43.2679901' AS DateTime2), NULL, 0, NULL, N'ورزش و سفر', NULL)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (12, CAST(N'2020-11-23T13:35:43.2679901' AS DateTime2), NULL, 0, NULL, N'خوردنی و آشامیدنی', NULL)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (13, CAST(N'2020-11-23T13:35:43.2679901' AS DateTime2), NULL, 0, NULL, N'زیبایی و سلامت', NULL)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (14, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لوازم جانبی گوشی', 8)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (15, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'دوربین‌های تحت شبکه', 8)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (16, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'کامپیوتر و تجهیزات جانبی', 8)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (17, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لباس مردانه', 12)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (18, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لباس زنانه', 12)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (19, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'صوتی و تصویری', 3)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (20, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'آشپزخانه', 3)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (21, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'مبلمان خانگی', 3)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (22, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'فرش ماشینی، دستبافت', 3)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (23, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لوازم جانبی خودرو و موتورسیکلت', 22)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (24, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لوازم یدکی خودرو و موتورسیکلت', 22)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (25, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لوازم مصرفی خودرو و موتورسیکلت', 22)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (26, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لوازم و یراق آلات ساختمانی', 22)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (27, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'ابزار برقی', 22)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (28, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لوازم آرایشی', 26)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (29, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لوازم بهداشتی', 26)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (30, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'لوازم شخصی برقی', 26)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (31, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'پوشاک ورزشی مردانه', 23)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (32, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 0, NULL, N'پوشاک ورزشی زنانه', 23)
INSERT [dbo].[Categories] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [ParentCategoryId]) VALUES (39, CAST(N'2020-11-14T10:27:48.2662560' AS DateTime2), NULL, 1, NULL, N'دسته بندی کالاها', 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[CategoryImages] ON 

INSERT [dbo].[CategoryImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [CategoryId]) VALUES (10, CAST(N'2020-11-18T12:31:08.3887164' AS DateTime2), NULL, 0, NULL, N'images\CategoryImages\digi.jpg', 8)
INSERT [dbo].[CategoryImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [CategoryId]) VALUES (11, CAST(N'2020-11-18T12:31:08.3887164' AS DateTime2), NULL, 0, NULL, N'images\CategoryImages\toy.jpg', 9)
INSERT [dbo].[CategoryImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [CategoryId]) VALUES (12, CAST(N'2020-11-18T12:31:08.3887164' AS DateTime2), NULL, 0, NULL, N'images\CategoryImages\car utilities.jpg', 10)
INSERT [dbo].[CategoryImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [CategoryId]) VALUES (13, CAST(N'2020-11-18T12:31:08.3887164' AS DateTime2), NULL, 0, NULL, N'images\CategoryImages\images.jpg', 11)
INSERT [dbo].[CategoryImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [CategoryId]) VALUES (14, CAST(N'2020-11-18T12:31:08.3887164' AS DateTime2), NULL, 0, NULL, N'images\CategoryImages\None.jpg', 12)
INSERT [dbo].[CategoryImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [CategoryId]) VALUES (15, CAST(N'2020-11-18T12:31:08.3887164' AS DateTime2), NULL, 0, NULL, N'images\CategoryImages\beauty.jpg', 13)
INSERT [dbo].[CategoryImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [CategoryId]) VALUES (16, CAST(N'2020-11-18T12:31:08.3887164' AS DateTime2), NULL, 0, NULL, N'images\CategoryImages\home_applience.jpg', 3)
INSERT [dbo].[CategoryImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [CategoryId]) VALUES (17, CAST(N'2020-11-18T12:31:08.3887164' AS DateTime2), NULL, 0, NULL, N'images\CategoryImages\cloths.jpg', 6)
SET IDENTITY_INSERT [dbo].[CategoryImages] OFF
SET IDENTITY_INSERT [dbo].[HomePageImages] ON 

INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (1, CAST(N'2020-11-23T10:25:53.6867557' AS DateTime2), NULL, 1, NULL, N'images\HomePages\Slider\637417239536696273a-1.jpg', NULL, 0)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (2, CAST(N'2020-11-23T10:33:13.8417349' AS DateTime2), NULL, 1, NULL, N'images\HomePages\Slider\637417243938406777a-2.jpg', NULL, 1)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (3, CAST(N'2020-11-23T10:38:43.0844383' AS DateTime2), NULL, 1, NULL, N'images\HomePages\Slider\637417247230835741a-3.jpg', NULL, 3)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (4, CAST(N'2020-11-23T10:41:42.4217263' AS DateTime2), NULL, 1, NULL, N'images\HomePages\Slider\637417249024015805a-8.jpg', NULL, 4)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (5, CAST(N'2020-11-23T10:46:27.8510215' AS DateTime2), NULL, 1, NULL, N'images\HomePages\Slider\637417251878354578a-4.jpg', NULL, 5)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (6, CAST(N'2020-11-23T10:46:39.9611170' AS DateTime2), NULL, 1, NULL, N'images\HomePages\Slider\637417251999595237a-5.jpg', NULL, 5)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (7, CAST(N'2020-11-23T10:46:51.8618211' AS DateTime2), NULL, 1, NULL, N'images\HomePages\Slider\637417252118602366a-6.jpg', NULL, 5)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (8, CAST(N'2020-11-23T10:46:59.1382006' AS DateTime2), NULL, 1, NULL, N'images\HomePages\Slider\637417252191366996a-7.jpg', NULL, 5)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (9, CAST(N'2020-11-23T11:01:50.5987799' AS DateTime2), NULL, 1, NULL, N'images\HomePages\adplacement\637417261105892228a-1.jpg', NULL, 0)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (10, CAST(N'2020-11-23T11:01:56.1978369' AS DateTime2), NULL, 1, NULL, N'images\HomePages\adplacement\637417261161962799a-2.jpg', NULL, 1)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (11, CAST(N'2020-11-23T11:02:00.8117210' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637417261208106118a-3.jpg', NULL, 3)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (12, CAST(N'2020-11-23T11:02:10.0446367' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637417261300414934a-8.jpg', NULL, 4)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (13, CAST(N'2020-11-23T11:02:15.9340881' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637417261359328641a-4.jpg', NULL, 5)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (14, CAST(N'2020-11-23T11:02:21.7376083' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637417261417361998a-5.jpg', NULL, 5)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (15, CAST(N'2020-11-23T11:02:26.5344242' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637417261465332865a-6.jpg', NULL, 5)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (16, CAST(N'2020-11-23T11:02:32.2662008' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637417261522652452a-7.jpg', NULL, 5)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (17, CAST(N'2020-11-23T11:35:38.0581212' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637417281380486190a-4.jpg', NULL, 6)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (18, CAST(N'2020-11-23T11:35:47.2735876' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637417281472723084a-5.jpg', NULL, 6)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (19, CAST(N'2020-11-23T11:36:07.6794897' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637417281676781847a-6.jpg', NULL, 6)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (20, CAST(N'2020-11-23T11:36:16.5544542' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637417281765525456a-7.jpg', NULL, 6)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (21, CAST(N'2020-12-01T12:41:09.3203252' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637424232693092848637423572171405980Promotion-Related-problems1.png', NULL, 1)
INSERT [dbo].[HomePageImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link], [ImageLocation]) VALUES (22, CAST(N'2020-12-01T12:41:25.2420519' AS DateTime2), NULL, 0, NULL, N'images\HomePages\adplacement\637424232852318121637423574194301683service providers.png', NULL, 0)
SET IDENTITY_INSERT [dbo].[HomePageImages] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [OrderId], [ProductId], [Price], [Count], [SellerProductId]) VALUES (1, CAST(N'2021-01-05T10:24:38.9837126' AS DateTime2), NULL, 0, NULL, 1, 1, 10500000, 1, 1)
INSERT [dbo].[OrderDetails] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [OrderId], [ProductId], [Price], [Count], [SellerProductId]) VALUES (2, CAST(N'2021-01-07T11:58:56.8664757' AS DateTime2), NULL, 0, NULL, 2, 2, 11000000, 1, 3)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [UserId], [PaymentId], [OrderState], [Addrress]) VALUES (1, CAST(N'2021-01-05T10:24:38.9654333' AS DateTime2), NULL, 0, NULL, N'700d83aa-6789-44b0-be82-4f660ec29cd3', 1, 0, N'')
INSERT [dbo].[Orders] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [UserId], [PaymentId], [OrderState], [Addrress]) VALUES (2, CAST(N'2021-01-07T11:58:56.8476662' AS DateTime2), NULL, 0, NULL, N'a5a43138-8357-4cb3-b9e8-11d9343fda1d', 3, 0, N'')
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Guid], [UserId], [Amount], [IsPayed], [PayDate], [Authority], [RefId]) VALUES (1, CAST(N'2021-01-05T10:23:18.6967881' AS DateTime2), NULL, 0, NULL, N'6655bf3c-8f6d-41ce-b2bf-c277c5bc1ced', N'700d83aa-6789-44b0-be82-4f660ec29cd3', 10500000, 1, CAST(N'2021-01-05T10:24:38.9654282' AS DateTime2), N'000000000000000000000000000000275050', 12345678)
INSERT [dbo].[Payments] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Guid], [UserId], [Amount], [IsPayed], [PayDate], [Authority], [RefId]) VALUES (2, CAST(N'2021-01-06T16:27:57.1842685' AS DateTime2), NULL, 0, NULL, N'6f1f0fed-0c65-4953-9ff5-6d16d478cf3c', N'a5a43138-8357-4cb3-b9e8-11d9343fda1d', 11000000, 0, NULL, NULL, 0)
INSERT [dbo].[Payments] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Guid], [UserId], [Amount], [IsPayed], [PayDate], [Authority], [RefId]) VALUES (3, CAST(N'2021-01-07T11:58:36.5790104' AS DateTime2), NULL, 0, NULL, N'1a760b6e-bddf-4ac0-94d9-1c9ea3a36536', N'a5a43138-8357-4cb3-b9e8-11d9343fda1d', 11000000, 1, CAST(N'2021-01-07T11:58:56.8476640' AS DateTime2), N'000000000000000000000000000000281019', 12345678)
INSERT [dbo].[Payments] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Guid], [UserId], [Amount], [IsPayed], [PayDate], [Authority], [RefId]) VALUES (4, CAST(N'2021-01-10T11:40:31.1147006' AS DateTime2), NULL, 0, NULL, N'3fb8e8fe-285b-4467-bc2b-a1b04a2c8e9f', N'81b82afa-0c97-474e-af8c-8ce6cb183205', 11000000, 0, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Payments] OFF
SET IDENTITY_INSERT [dbo].[ProductFeatures] ON 

INSERT [dbo].[ProductFeatures] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [DisplayName], [Value]) VALUES (5, CAST(N'2020-11-18T12:31:08.4032096' AS DateTime2), NULL, 0, NULL, 1, N'ظرفیت دیگ', N'8 کیلوگرم ')
INSERT [dbo].[ProductFeatures] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [DisplayName], [Value]) VALUES (6, CAST(N'2020-11-18T12:31:08.4035313' AS DateTime2), NULL, 0, NULL, 1, N'رتبه انرژی', N'+++A ')
INSERT [dbo].[ProductFeatures] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [DisplayName], [Value]) VALUES (7, CAST(N'2020-11-18T12:31:08.4035331' AS DateTime2), NULL, 0, NULL, 1, N'سرعت چرخش موتور', N'1400 دور در دقیقه')
INSERT [dbo].[ProductFeatures] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [DisplayName], [Value]) VALUES (8, CAST(N'2020-11-18T16:04:22.4592516' AS DateTime2), NULL, 0, NULL, 2, N'سایز صفحه', N'43 اینچ ')
INSERT [dbo].[ProductFeatures] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [DisplayName], [Value]) VALUES (9, CAST(N'2020-11-18T16:04:22.4592597' AS DateTime2), NULL, 0, NULL, 2, N'کیفیت تصویر', N'Full HD')
INSERT [dbo].[ProductFeatures] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [DisplayName], [Value]) VALUES (10, CAST(N'2021-01-06T15:53:19.5694583' AS DateTime2), NULL, 0, NULL, 3, N'حافظه داخلی', N'128 گیگابایت ')
INSERT [dbo].[ProductFeatures] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [DisplayName], [Value]) VALUES (11, CAST(N'2021-01-06T15:53:19.5694632' AS DateTime2), NULL, 0, NULL, 3, N'شبکه های ارتباطی', N'4G، 3G، 2G ')
INSERT [dbo].[ProductFeatures] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [DisplayName], [Value]) VALUES (12, CAST(N'2021-01-06T15:53:19.5694636' AS DateTime2), NULL, 0, NULL, 3, N'دوربین‌های پشت گوشی', N' 1 ماژول دوربین')
SET IDENTITY_INSERT [dbo].[ProductFeatures] OFF
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [Src]) VALUES (3, CAST(N'2020-11-18T12:31:08.3887164' AS DateTime2), NULL, 0, NULL, 1, N'images\ProductImages\637412994683851317a1dc7034cf8eee6fe7dc3742076e647d9eefcb4f_1602500358.jpg')
INSERT [dbo].[ProductImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [Src]) VALUES (4, CAST(N'2020-11-18T16:04:22.4461168' AS DateTime2), NULL, 0, NULL, 2, N'images\ProductImages\637413122327140069111446992.jpg')
INSERT [dbo].[ProductImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [Src]) VALUES (5, CAST(N'2020-11-18T16:04:22.4575646' AS DateTime2), NULL, 0, NULL, 2, N'images\ProductImages\637413122624461993111446999.jpg')
INSERT [dbo].[ProductImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [Src]) VALUES (6, CAST(N'2021-01-06T15:53:19.5541072' AS DateTime2), NULL, 0, NULL, 3, N'images\ProductImages\637455451995508101122045219.jpg')
INSERT [dbo].[ProductImages] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [Src]) VALUES (7, CAST(N'2021-01-06T15:53:19.5573946' AS DateTime2), NULL, 0, NULL, 3, N'images\ProductImages\637455451995541534122045277.jpg')
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [Brand], [Description], [Price], [Inventory], [Displayed], [ViewCount], [CategoryId]) VALUES (1, CAST(N'2020-11-18T12:31:08.3667140' AS DateTime2), NULL, 0, NULL, N'ماشین لباسشویی دوو سری کاریزما مدل DWK-8140 ظرفیت 8 کیلوگرم ', N'دوو ', N'ماشین لباسشویی 8 کیلوگرمی دوو سری کاریزما مدل DWK-8140 یکی از جدیدترین مدل های لباسشویی تولید شده توسط شرکت دوو (DAEWOO)سری کاریزما (Charisma) می باشد. این لباسشویی با عملکرد مناسب خود به محبوبیت مناسبی میان مصرف کنندگان رسیده است. لباسشویی درب از جلو (Front Loading) کاریزما با موتور بدون تسمه 1400 دور در دقیقه به مصرف کنندگان عرضه میگردد. لباسشویی های سری کاریزما با بهره مندی از صفحه نمایش جدید خود که در قسمت جلوی لباسشویی، به آسانی تنظیم و آماده شروع فرآیند شستشو می گردد. لباسشویی 8 کیلوگرمی دوو سری کاریزما مدل DWK-8140 با استفاده از طراحی بدنه جدید خود تمامی لرزش های اضافی را در خود نگه میدارد، اما مهمترین نکته در مورد طراحی این سری از لباسشویی، مصرف پایین انرژی است. رتبه مصرف انرژی این لباسشویی در پایین ترین سطح و در رده انرژی A+++ قرار گرفته است‌. دیگ زمردی (Emerald Drum) چیست ؟ می‌توان گفت که محفظه‌ی مورد استفاده در این ماشین لباسشویی سری جدید دوو با نام کاریزما (Charisma) با استفاده از قوی‌ترین کامپیوتر دنیا و استفاده از ایده‌ای ناب طراحی شده است که نه‌تنها تمام آلودگی‌ها و لکه‌ها را ازبین می‌برد بلکه باتوجه به‌ویژگی های استفاده شده در ساخت آن برای انواع لباس‌ها با هر جنسی مناسب و کاربردی است. محفظه‌ی استوانه‌ای شکل (drum) این ماشین لباسشویی کامل‌ترین و پیشرفته ترین نوع این محصول است و مهمترین ویژگی آن صرفه‌جویی در آب مصرفی است. این دِرام دارای برآمدگی های بیضی شکل (Emerald) است و به همین‌خاطر Emerald Drum نام‌ گرفته است. این برآمدگی، شستشویی همانند اثر انگشت را ایجاد نموده تا ضمن حفاظت از الیاف البسه در هنگام شستشو، کیفیت شستشوی را بالا برود. عملکرد تکنولوژی نانو سیلور (Nano Silver) در لباسشویی چگونه است؟ ماشین لباسشویی DWK-8140 دوو سری کاریزما با استفاده از این تکنولوژی، قادر به از بین بردن بیش از 650 نوع باکتری است. این تکنولوژی در ماشین لباسشویی حدود 400 میلیارد یون نقره را هنگام شست و شو آزاد نموده و به این ترتیب خاصیت استریل کنندگی آن تا 99 درصد افزایش می یابد. جالب است بدانید این خاصیت ضد باکتری تا 30 روز پس از شست و شو در لباس باقی می‌ماند. ', 8500000, 5, 0, 211, 4)
INSERT [dbo].[Products] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [Brand], [Description], [Price], [Inventory], [Displayed], [ViewCount], [CategoryId]) VALUES (2, CAST(N'2020-11-18T16:04:22.4393619' AS DateTime2), NULL, 0, NULL, N'تلویزیون ال ای دی ال جی مدل 43LJ52100 سایز 43 اینچ', N'ال جی', N'، تلویزیونی 43 اینچی محصول کمپانی ال‌جی است که با توجه به سایز آن، مناسب فضاهای کوچکتر است. کیفیت تصویر در این دستگاه، Full HD، دارای زاویه‌ی دید گسترده، مجموع قدرت خروجی بلندگوهای آن 10 وات، و دارای سیستم بلندگوی استریو می‌باشد. گیرنده‌ی دیجیتالی داخلی در این تلویزیون شما را از دستگاه جداگانه برای دریافت شبکه‌های دیجیتالی بی‌نیاز می‌کند. اگرچه، درگاه‌های ارتباطی 43LJ52100GI یک عدد پورت USB، پورت‌های HDMI و یک عدد درگاه کامپوننت را نیز شامل می‌شود. درگاه USB قابلیت استفاده از فلش و هارد اکسترنال را به طور مستقیم و وجود پورت HDMI، امکان دریافت تصاویر با کیفیت برایتان فراهم می‌کند. ضمنا این تلویزیون دارای قابلیت اتصال به دیوار است و شما می‌توانید با توجه به شرایط منزل یا محلی که تلویزیون را در آن قرار می‌دهید آن را روی میز تلویزیون قرار داده یا به دیوار نصب کنید. ', 10369000, 5, 0, 128, 19)
INSERT [dbo].[Products] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Name], [Brand], [Description], [Price], [Inventory], [Displayed], [ViewCount], [CategoryId]) VALUES (3, CAST(N'2021-01-06T15:53:19.5177911' AS DateTime2), NULL, 0, NULL, N'گوشی موبایل اپل مدل iPhone SE 2020 A2275 ظرفیت 128 گیگابایت ', N' اپل', N'شرکت اپل نسل دوم گوشی SEخود را در 15 آوریل 2020 معرفی کرد. این گوشی با بهره‌گیری از سخت‌افزار آیفون 11 و ابعاد جمع‌وجور به‌عنوان گوشی میان رده شرکت اپل روانه بازار شده است. قاب پشتی و جلویی آیفون SE از شیشه و فریم آن از آلومینیوم ساخته شده است. آیفون SE از یک صفحه‌نمایش 4.7 اینچی با فناوری Retina IPS بهره می‌برد. صفحه‌نمایش این گوشی دارای نسبت 16:9 است که رزولوشن آن برابر با 1334 در 750 پیکسل است. آیفون SE این‌بار در ظرفیت 256 گیگابایتی عرضه شده و طبق معمول خبری از امکان استفاده از کارت حافظه‌ی جانبی برای افزایش این مقدار نیست. شرکت اپل در ساخت گوشی SE 2020 از جدیدترین چیپست خود یعنی A13 Bionic با معماری 7nm+ استفاده کرده است. به لطف پردازنده‌ی جدید، آیفون SE می‌تواند به باند‌های LTE بیشتری متصل شود، همچنین از بلوتوث و Wi-Fi با نسخه‌های بالاتر با سرعت‌ بیشتر هم سود می‌برد. با این سنسور علاوه بر این‌که می‌توانید تصاویر با کیفیت‌تری ثبت کنید، می‌توانید تصاویر زنده ثبت کنید، ویدیو‌هایی با رزولوشن 4K ضبط کنید و یا از ضبط ویدیو‌هایی با سرعت 240 فریم بر ثانیه لذت ببرید. باتری آیفون SE خرید این گوشی به کسانی که هنوز از گوشی‌های کوچک استفاده می‌کنند و از نمایشگر‌های 4.7 اینچی رضایت دارند، توصیه می‌شود. ', 0, 10, 0, 60, 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Description]) VALUES (N'1', N'Admin', N'ADMIN', NULL, N'Admin')
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Description]) VALUES (N'2', N'Seller', N'SELLER', NULL, N'Seller')
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Description]) VALUES (N'3', N'Customer', N'CUSTOMER', NULL, N'Customer')
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Description]) VALUES (N'4', N'Operator', N'OPERATOR', NULL, N'Operator')
SET IDENTITY_INSERT [dbo].[SellerProducts] ON 

INSERT [dbo].[SellerProducts] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [SellerId], [SellerPrice], [Inventory]) VALUES (1, CAST(N'2021-01-02T13:16:05.9584121' AS DateTime2), NULL, 0, NULL, 1, 1, 10500000, 4)
INSERT [dbo].[SellerProducts] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [SellerId], [SellerPrice], [Inventory]) VALUES (2, CAST(N'2021-01-06T15:54:12.0579909' AS DateTime2), NULL, 0, NULL, 3, 2, 17500000, 10)
INSERT [dbo].[SellerProducts] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [SellerId], [SellerPrice], [Inventory]) VALUES (3, CAST(N'2021-01-06T16:05:41.1814507' AS DateTime2), NULL, 0, NULL, 2, 1, 11000000, 20)
INSERT [dbo].[SellerProducts] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [SellerId], [SellerPrice], [Inventory]) VALUES (4, CAST(N'2021-01-06T16:12:08.0884489' AS DateTime2), NULL, 0, NULL, 2, 3, 10800000, 3)
INSERT [dbo].[SellerProducts] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ProductId], [SellerId], [SellerPrice], [Inventory]) VALUES (5, CAST(N'2021-01-10T11:38:00.9880490' AS DateTime2), NULL, 1, NULL, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[SellerProducts] OFF
SET IDENTITY_INSERT [dbo].[Sellers] ON 

INSERT [dbo].[Sellers] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ShopName], [Phone], [Mobile], [UserName], [Addrress], [CategoryId], [IsActive], [UserId]) VALUES (1, CAST(N'2021-01-02T12:57:27.5582426' AS DateTime2), NULL, 0, NULL, N'پلاس', NULL, N'09103556594', N'Plus', NULL, 3, 1, N'81b82afa-0c97-474e-af8c-8ce6cb183205')
INSERT [dbo].[Sellers] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ShopName], [Phone], [Mobile], [UserName], [Addrress], [CategoryId], [IsActive], [UserId]) VALUES (2, CAST(N'2021-01-06T14:33:07.2083744' AS DateTime2), NULL, 0, NULL, N'نیکان', NULL, N'09137365147', N'Nikan', NULL, 8, 1, N'1c976aaa-f746-4a17-9c54-8f893e0c29c7')
INSERT [dbo].[Sellers] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [ShopName], [Phone], [Mobile], [UserName], [Addrress], [CategoryId], [IsActive], [UserId]) VALUES (3, CAST(N'2021-01-06T16:11:10.1382421' AS DateTime2), NULL, 0, NULL, N'زمرد', NULL, N'09133658741', N'Zomorrod', NULL, 3, 1, N'2cc4968c-6313-45b6-b93f-fd9adecac033')
SET IDENTITY_INSERT [dbo].[Sellers] OFF
SET IDENTITY_INSERT [dbo].[Sliders] ON 

INSERT [dbo].[Sliders] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link]) VALUES (1, CAST(N'2020-11-22T11:27:46.3259784' AS DateTime2), NULL, 1, NULL, N'images\HomePages\Slider\63741641266321792646.jpg', NULL)
INSERT [dbo].[Sliders] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link]) VALUES (2, CAST(N'2020-11-22T13:10:19.2782909' AS DateTime2), NULL, 0, NULL, N'images\HomePages\Slider\637416474192713946637316263744270286sm-1.jpg', N'https://localhost:44304/products/detail/6')
INSERT [dbo].[Sliders] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link]) VALUES (3, CAST(N'2020-11-22T13:10:34.0653861' AS DateTime2), NULL, 0, NULL, N'images\HomePages\Slider\637416474340617932637316277407677837sm-3.jpg', NULL)
INSERT [dbo].[Sliders] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link]) VALUES (4, CAST(N'2020-11-22T13:20:43.8967137' AS DateTime2), NULL, 1, NULL, N'images\HomePages\Slider\63741648043888977746.jpg', NULL)
INSERT [dbo].[Sliders] ([Id], [InsertTime], [UpdateTime], [IsDeleted], [DeleteTime], [Src], [Link]) VALUES (5, CAST(N'2020-11-22T13:27:13.7437528' AS DateTime2), NULL, 0, NULL, N'images\HomePages\Slider\637416484337386274637316291974361207sm-5.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Sliders] OFF
SET IDENTITY_INSERT [dbo].[UserClaims] ON 

INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'700d83aa-6789-44b0-be82-4f660ec29cd3', N'FullName', N'محسن رضایی')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (2, N'81b82afa-0c97-474e-af8c-8ce6cb183205', N'FullName', N'ناصر رضایی')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (3, N'a5a43138-8357-4cb3-b9e8-11d9343fda1d', N'FullName', N'جمشید مرادی')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (4, N'1c976aaa-f746-4a17-9c54-8f893e0c29c7', N'FullName', N'مصطفی محسنی')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (5, N'2cc4968c-6313-45b6-b93f-fd9adecac033', N'FullName', N'علی رضایی')
SET IDENTITY_INSERT [dbo].[UserClaims] OFF
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'700d83aa-6789-44b0-be82-4f660ec29cd3', N'1')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'1c976aaa-f746-4a17-9c54-8f893e0c29c7', N'2')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'2cc4968c-6313-45b6-b93f-fd9adecac033', N'2')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'81b82afa-0c97-474e-af8c-8ce6cb183205', N'2')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'a5a43138-8357-4cb3-b9e8-11d9343fda1d', N'3')
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive], [IsDeleted]) VALUES (N'1c976aaa-f746-4a17-9c54-8f893e0c29c7', N'Nikan', N'NIKAN', N'Nikan@msn.com', N'NIKAN@MSN.COM', 1, N'AQAAAAEAACcQAAAAEBU6ucRUUEawthsAcxbSLavM0eb3rcRVRYUCIvG8qT3xNEjjbeKoXzVSyDfk+KIbDg==', N'XLTLQPIFQXV7ZTV44LF37UFGTGFASQ4X', N'cfd7f907-04b3-435a-b421-1fd64352420d', NULL, 1, 0, NULL, 1, 0, N'مصطفی محسنی', 1, 0)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive], [IsDeleted]) VALUES (N'2cc4968c-6313-45b6-b93f-fd9adecac033', N'Zomorrod', N'ZOMORROD', N'Zomorrod@msn.com', N'ZOMORROD@MSN.COM', 1, N'AQAAAAEAACcQAAAAEG+53EpDOXA+fHmT01CTOtTgHishvcpTCjSMtXOVxzwYmf1H7XY98UHahYSTmSMtfQ==', N'VSVBHE4P4PLXNPMNBCCKDRFTKPTOSU55', N'e4aba48c-8a35-44ce-b95e-2180e06cdf7d', NULL, 1, 0, NULL, 1, 0, N'علی رضایی', 1, 0)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive], [IsDeleted]) VALUES (N'700d83aa-6789-44b0-be82-4f660ec29cd3', N'mohsen_r_2020@yahoo.com', N'MOHSEN_R_2020@YAHOO.COM', N'mohsen_r_2020@yahoo.com', N'MOHSEN_R_2020@YAHOO.COM', 1, N'AQAAAAEAACcQAAAAEHFlfL9mfyU1N6HQlAjhfDcuxg9KoeLU6cNsflvjug/uT4650XRj1LIMC5OscV+hFQ==', N'447JWIMZVJTBGX2C2QXLZIZE524XFNCC', N'42ecca87-8d7d-4e06-a4dd-a43e4f1539a9', N'09139738530', 1, 0, NULL, 1, 0, N'محسن رضایی', 1, 0)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive], [IsDeleted]) VALUES (N'81b82afa-0c97-474e-af8c-8ce6cb183205', N'Plus', N'PLUS', N'Plus@msn.com', N'PLUS@MSN.COM', 1, N'AQAAAAEAACcQAAAAEDEtbofeSLR5EIlpUrhDALimL2YhVar1ayQS0MM73W8BtODCNDgEpi2eesWyAru3Ng==', N'FZONXZ2EXUGTTXJOIYYZMS6DRA7APZHP', N'fcf3d417-6b34-44cd-98ee-35a0cfe85536', NULL, 1, 0, NULL, 1, 0, N'ناصر رضایی', 1, 0)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive], [IsDeleted]) VALUES (N'a5a43138-8357-4cb3-b9e8-11d9343fda1d', N'jamshid@gmail.com', N'JAMSHID@GMAIL.COM', N'jamshid@gmail.com', N'JAMSHID@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHFlfL9mfyU1N6HQlAjhfDcuxg9KoeLU6cNsflvjug/uT4650XRj1LIMC5OscV+hFQ==', N'Q3QZHGIO2UNUT7WR2XAMSM6ZGR3FG4V2', N'6d957151-f236-4b85-8cf1-dd14cf44539e', NULL, 1, 0, NULL, 1, 0, N'جمشید مرادی', 1, 0)
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_Carts_CartId] FOREIGN KEY([CartId])
REFERENCES [dbo].[Carts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_Carts_CartId]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_Products_ProductId]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_SellerProducts_SellerProductId] FOREIGN KEY([SellerProductId])
REFERENCES [dbo].[SellerProducts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_SellerProducts_SellerProductId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Users_UserId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories_ParentCategoryId] FOREIGN KEY([ParentCategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories_ParentCategoryId]
GO
ALTER TABLE [dbo].[CategoryImages]  WITH CHECK ADD  CONSTRAINT [FK_CategoryImages_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryImages] CHECK CONSTRAINT [FK_CategoryImages_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Provinces_ProvinceId] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Provinces] ([ProvinceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Provinces_ProvinceId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_SellerProducts_SellerProductId] FOREIGN KEY([SellerProductId])
REFERENCES [dbo].[SellerProducts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_SellerProducts_SellerProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Payments_PaymentId] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Payments_PaymentId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_UserId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Users_UserId]
GO
ALTER TABLE [dbo].[ProductFeatures]  WITH CHECK ADD  CONSTRAINT [FK_ProductFeatures_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductFeatures] CHECK CONSTRAINT [FK_ProductFeatures_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[SCategories]  WITH CHECK ADD  CONSTRAINT [FK_SCategories_SCategories_ParentCategoryId] FOREIGN KEY([ParentCategoryId])
REFERENCES [dbo].[SCategories] ([Id])
GO
ALTER TABLE [dbo].[SCategories] CHECK CONSTRAINT [FK_SCategories_SCategories_ParentCategoryId]
GO
ALTER TABLE [dbo].[SellerProducts]  WITH CHECK ADD  CONSTRAINT [FK_SellerProducts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[SellerProducts] CHECK CONSTRAINT [FK_SellerProducts_Products_ProductId]
GO
ALTER TABLE [dbo].[SellerProducts]  WITH CHECK ADD  CONSTRAINT [FK_SellerProducts_Sellers_SellerId] FOREIGN KEY([SellerId])
REFERENCES [dbo].[Sellers] ([Id])
GO
ALTER TABLE [dbo].[SellerProducts] CHECK CONSTRAINT [FK_SellerProducts_Sellers_SellerId]
GO
ALTER TABLE [dbo].[Sellers]  WITH CHECK ADD  CONSTRAINT [FK_Sellers_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sellers] CHECK CONSTRAINT [FK_Sellers_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Sellers]  WITH CHECK ADD  CONSTRAINT [FK_Sellers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Sellers] CHECK CONSTRAINT [FK_Sellers_Users_UserId]
GO
