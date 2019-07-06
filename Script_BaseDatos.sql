USE [master]
GO
/****** Object:  Database [OnBreak]    Script Date: 05-07-2019 19:40:51 ******/
CREATE DATABASE [OnBreak]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnBreak', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\OnBreak.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OnBreak_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\OnBreak_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OnBreak] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnBreak].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnBreak] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnBreak] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnBreak] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnBreak] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnBreak] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnBreak] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnBreak] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnBreak] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnBreak] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnBreak] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnBreak] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnBreak] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnBreak] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnBreak] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnBreak] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OnBreak] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnBreak] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnBreak] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnBreak] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnBreak] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnBreak] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnBreak] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnBreak] SET RECOVERY FULL 
GO
ALTER DATABASE [OnBreak] SET  MULTI_USER 
GO
ALTER DATABASE [OnBreak] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnBreak] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnBreak] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnBreak] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnBreak] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OnBreak', N'ON'
GO
ALTER DATABASE [OnBreak] SET QUERY_STORE = OFF
GO
USE [OnBreak]
GO
/****** Object:  Table [dbo].[ActividadEmpresa]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActividadEmpresa](
	[IdActividadEmpresa] [int] NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
 CONSTRAINT [ActividadEmpresa_PK] PRIMARY KEY CLUSTERED 
(
	[IdActividadEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CacheContrato]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CacheContrato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaHora] [datetime] NULL,
	[NumeroContrato] [nvarchar](12) NULL,
	[Creacion] [datetime] NULL,
	[Termino] [datetime] NULL,
	[RutCliente] [nvarchar](10) NULL,
	[IdModalidad] [nvarchar](5) NULL,
	[IdTipoEvento] [int] NULL,
	[FechaHoraInicio] [datetime] NULL,
	[FechaHoraTermino] [datetime] NULL,
	[Asistentes] [int] NULL,
	[PersonalAdicional] [int] NULL,
	[Realizado] [bit] NULL,
	[ValorTotalContrato] [float] NULL,
	[Observaciones] [nvarchar](250) NULL,
	[IdTipoAmbientacion] [int] NULL,
	[MusicaAmbiental] [bit] NULL,
	[LocalOnBreak] [bit] NULL,
	[OtroLocalOnBreak] [bit] NULL,
	[ValorArriendo] [float] NULL,
	[MusicaCliente] [bit] NULL,
	[Vegetariana] [bit] NULL,
 CONSTRAINT [PK_CacheContrato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cenas]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cenas](
	[Numero] [nvarchar](12) NOT NULL,
	[IdTipoAmbientacion] [int] NOT NULL,
	[MusicaAmbiental] [bit] NOT NULL,
	[LocalOnBreak] [bit] NOT NULL,
	[OtroLocalOnBreak] [bit] NOT NULL,
	[ValorArriendo] [float] NOT NULL,
 CONSTRAINT [Key15] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[RutCliente] [nvarchar](10) NOT NULL,
	[RazonSocial] [nvarchar](50) NOT NULL,
	[NombreContacto] [nvarchar](50) NOT NULL,
	[MailContacto] [nvarchar](30) NOT NULL,
	[Direccion] [nvarchar](30) NOT NULL,
	[Telefono] [nvarchar](15) NOT NULL,
	[IdActividadEmpresa] [int] NOT NULL,
	[IdTipoEmpresa] [int] NOT NULL,
 CONSTRAINT [Cliente_PK] PRIMARY KEY CLUSTERED 
(
	[RutCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cocktail]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cocktail](
	[Numero] [nvarchar](12) NOT NULL,
	[IdTipoAmbientacion] [int] NULL,
	[Ambientacion] [bit] NOT NULL,
	[MusicaAmbiental] [bit] NOT NULL,
	[MusicaCliente] [bit] NOT NULL,
 CONSTRAINT [Key14] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoffeeBreak]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoffeeBreak](
	[Numero] [nvarchar](12) NOT NULL,
	[Vegetariana] [bit] NOT NULL,
 CONSTRAINT [Key13] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contrato]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contrato](
	[Numero] [nvarchar](12) NOT NULL,
	[Creacion] [datetime] NOT NULL,
	[Termino] [datetime] NOT NULL,
	[RutCliente] [nvarchar](10) NOT NULL,
	[IdModalidad] [nvarchar](5) NOT NULL,
	[IdTipoEvento] [int] NOT NULL,
	[FechaHoraInicio] [datetime] NOT NULL,
	[FechaHoraTermino] [datetime] NOT NULL,
	[Asistentes] [int] NOT NULL,
	[PersonalAdicional] [int] NOT NULL,
	[Realizado] [bit] NOT NULL,
	[ValorTotalContrato] [float] NOT NULL,
	[Observaciones] [nvarchar](250) NOT NULL,
 CONSTRAINT [Key1] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModalidadServicio]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModalidadServicio](
	[IdModalidad] [nvarchar](5) NOT NULL,
	[IdTipoEvento] [int] NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[ValorBase] [float] NOT NULL,
	[PersonalBase] [int] NOT NULL,
 CONSTRAINT [Key2] PRIMARY KEY CLUSTERED 
(
	[IdModalidad] ASC,
	[IdTipoEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistroContrato]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroContrato](
	[Numero] [nvarchar](12) NOT NULL,
	[Creacion] [datetime] NOT NULL,
	[Termino] [datetime] NOT NULL,
	[RutCliente] [nvarchar](10) NOT NULL,
	[IdModalidad] [nvarchar](5) NOT NULL,
	[IdTipoEvento] [int] NOT NULL,
	[FechaHoraInicio] [datetime] NOT NULL,
	[FechaHoraTermino] [datetime] NOT NULL,
	[Asistentes] [int] NOT NULL,
	[PersonalAdicional] [int] NOT NULL,
	[Realizado] [bit] NOT NULL,
	[ValorTotalContrato] [float] NOT NULL,
	[Observaciones] [nvarchar](250) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAmbientacion]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAmbientacion](
	[IdTipoAmbientacion] [int] NOT NULL,
	[Descripcion] [nvarchar](15) NOT NULL,
 CONSTRAINT [Key16] PRIMARY KEY CLUSTERED 
(
	[IdTipoAmbientacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEmpresa]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEmpresa](
	[IdTipoEmpresa] [int] NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
 CONSTRAINT [TipoEmpresa_PK] PRIMARY KEY CLUSTERED 
(
	[IdTipoEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEvento]    Script Date: 05-07-2019 19:40:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEvento](
	[IdTipoEvento] [int] NOT NULL,
	[Descripcion] [nvarchar](15) NOT NULL,
 CONSTRAINT [Key3] PRIMARY KEY CLUSTERED 
(
	[IdTipoEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05-07-2019 19:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] NOT NULL,
	[Nombre_Usuario] [nvarchar](50) NOT NULL,
	[Contrasenia] [nvarchar](256) NOT NULL,
 CONSTRAINT [Usuario_Id_Usuario_PK] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ActividadEmpresa] ([IdActividadEmpresa], [Descripcion]) VALUES (1, N'Agropecuaria')
INSERT [dbo].[ActividadEmpresa] ([IdActividadEmpresa], [Descripcion]) VALUES (2, N'Minería')
INSERT [dbo].[ActividadEmpresa] ([IdActividadEmpresa], [Descripcion]) VALUES (3, N'Manufactura')
INSERT [dbo].[ActividadEmpresa] ([IdActividadEmpresa], [Descripcion]) VALUES (4, N'Comercio')
INSERT [dbo].[ActividadEmpresa] ([IdActividadEmpresa], [Descripcion]) VALUES (5, N'Hotelería')
INSERT [dbo].[ActividadEmpresa] ([IdActividadEmpresa], [Descripcion]) VALUES (6, N'Alimentos')
INSERT [dbo].[ActividadEmpresa] ([IdActividadEmpresa], [Descripcion]) VALUES (7, N'Transporte')
INSERT [dbo].[ActividadEmpresa] ([IdActividadEmpresa], [Descripcion]) VALUES (8, N'Servicios')
SET IDENTITY_INSERT [dbo].[CacheContrato] ON 

INSERT [dbo].[CacheContrato] ([Id], [FechaHora], [NumeroContrato], [Creacion], [Termino], [RutCliente], [IdModalidad], [IdTipoEvento], [FechaHoraInicio], [FechaHoraTermino], [Asistentes], [PersonalAdicional], [Realizado], [ValorTotalContrato], [Observaciones], [IdTipoAmbientacion], [MusicaAmbiental], [LocalOnBreak], [OtroLocalOnBreak], [ValorArriendo], [MusicaCliente], [Vegetariana]) VALUES (700, CAST(N'2019-07-05T18:44:58.430' AS DateTime), NULL, CAST(N'2019-07-05T00:00:00.000' AS DateTime), NULL, N'', NULL, 20, CAST(N'1753-01-01T00:00:00.000' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), 1, 0, 0, 0, NULL, NULL, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[CacheContrato] ([Id], [FechaHora], [NumeroContrato], [Creacion], [Termino], [RutCliente], [IdModalidad], [IdTipoEvento], [FechaHoraInicio], [FechaHoraTermino], [Asistentes], [PersonalAdicional], [Realizado], [ValorTotalContrato], [Observaciones], [IdTipoAmbientacion], [MusicaAmbiental], [LocalOnBreak], [OtroLocalOnBreak], [ValorArriendo], [MusicaCliente], [Vegetariana]) VALUES (701, CAST(N'2019-07-05T18:45:32.213' AS DateTime), NULL, CAST(N'2019-07-05T00:00:00.000' AS DateTime), NULL, N'', N'CO002', 20, CAST(N'1753-01-01T00:00:00.000' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), 5, 0, 0, 359608, NULL, NULL, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[CacheContrato] ([Id], [FechaHora], [NumeroContrato], [Creacion], [Termino], [RutCliente], [IdModalidad], [IdTipoEvento], [FechaHoraInicio], [FechaHoraTermino], [Asistentes], [PersonalAdicional], [Realizado], [ValorTotalContrato], [Observaciones], [IdTipoAmbientacion], [MusicaAmbiental], [LocalOnBreak], [OtroLocalOnBreak], [ValorArriendo], [MusicaCliente], [Vegetariana]) VALUES (702, CAST(N'2019-07-05T18:45:52.740' AS DateTime), NULL, CAST(N'2019-07-05T00:00:00.000' AS DateTime), NULL, N'', N'CO002', 20, CAST(N'1753-01-01T00:00:00.000' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), 5, 0, 0, 359608, NULL, 10, 0, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[CacheContrato] OFF
INSERT [dbo].[Cliente] ([RutCliente], [RazonSocial], [NombreContacto], [MailContacto], [Direccion], [Telefono], [IdActividadEmpresa], [IdTipoEmpresa]) VALUES (N'183545450', N'BRAULIO LLEDO', N'braulio lledo', N'brauliolledo@gmail.com', N'AVENIDA PORTALES 2766', N'56972192627', 1, 20)
INSERT [dbo].[Cocktail] ([Numero], [IdTipoAmbientacion], [Ambientacion], [MusicaAmbiental], [MusicaCliente]) VALUES (N'201907050921', 20, 0, 1, 0)
INSERT [dbo].[Cocktail] ([Numero], [IdTipoAmbientacion], [Ambientacion], [MusicaAmbiental], [MusicaCliente]) VALUES (N'201907051812', 20, 0, 1, 1)
INSERT [dbo].[Contrato] ([Numero], [Creacion], [Termino], [RutCliente], [IdModalidad], [IdTipoEvento], [FechaHoraInicio], [FechaHoraTermino], [Asistentes], [PersonalAdicional], [Realizado], [ValorTotalContrato], [Observaciones]) VALUES (N'201907050921', CAST(N'2019-07-02T00:00:00.000' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), N'183545450', N'CO001', 20, CAST(N'2019-07-05T00:00:00.000' AS DateTime), CAST(N'2019-07-06T00:00:00.000' AS DateTime), 1, 0, 0, 248960, N'')
INSERT [dbo].[Contrato] ([Numero], [Creacion], [Termino], [RutCliente], [IdModalidad], [IdTipoEvento], [FechaHoraInicio], [FechaHoraTermino], [Asistentes], [PersonalAdicional], [Realizado], [ValorTotalContrato], [Observaciones]) VALUES (N'201907051812', CAST(N'2019-07-05T00:00:00.000' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), N'183545450', N'CO002', 20, CAST(N'2019-07-05T00:00:00.000' AS DateTime), CAST(N'2019-07-06T00:00:00.000' AS DateTime), 1, 4, 0, 622399, N'')
INSERT [dbo].[ModalidadServicio] ([IdModalidad], [IdTipoEvento], [Nombre], [ValorBase], [PersonalBase]) VALUES (N'CB001', 10, N'Light Break', 3, 2)
INSERT [dbo].[ModalidadServicio] ([IdModalidad], [IdTipoEvento], [Nombre], [ValorBase], [PersonalBase]) VALUES (N'CB002', 10, N'	Journal Break', 8, 6)
INSERT [dbo].[ModalidadServicio] ([IdModalidad], [IdTipoEvento], [Nombre], [ValorBase], [PersonalBase]) VALUES (N'CB003', 10, N'	Day Break', 12, 6)
INSERT [dbo].[ModalidadServicio] ([IdModalidad], [IdTipoEvento], [Nombre], [ValorBase], [PersonalBase]) VALUES (N'CE001', 30, N'	Ejecutiva', 25, 10)
INSERT [dbo].[ModalidadServicio] ([IdModalidad], [IdTipoEvento], [Nombre], [ValorBase], [PersonalBase]) VALUES (N'CE002', 30, N'Celebración', 35, 14)
INSERT [dbo].[ModalidadServicio] ([IdModalidad], [IdTipoEvento], [Nombre], [ValorBase], [PersonalBase]) VALUES (N'CO001', 20, N'	Quick Cocktail', 6, 4)
INSERT [dbo].[ModalidadServicio] ([IdModalidad], [IdTipoEvento], [Nombre], [ValorBase], [PersonalBase]) VALUES (N'CO002', 20, N'	Ambient Cocktail', 10, 5)
INSERT [dbo].[TipoAmbientacion] ([IdTipoAmbientacion], [Descripcion]) VALUES (10, N'Básica')
INSERT [dbo].[TipoAmbientacion] ([IdTipoAmbientacion], [Descripcion]) VALUES (20, N'Personalizada')
INSERT [dbo].[TipoEmpresa] ([IdTipoEmpresa], [Descripcion]) VALUES (10, N'SPA')
INSERT [dbo].[TipoEmpresa] ([IdTipoEmpresa], [Descripcion]) VALUES (20, N'EIRL')
INSERT [dbo].[TipoEmpresa] ([IdTipoEmpresa], [Descripcion]) VALUES (30, N'Limitada')
INSERT [dbo].[TipoEmpresa] ([IdTipoEmpresa], [Descripcion]) VALUES (40, N'Sociedad Anónima')
INSERT [dbo].[TipoEvento] ([IdTipoEvento], [Descripcion]) VALUES (10, N'Coffee Break')
INSERT [dbo].[TipoEvento] ([IdTipoEvento], [Descripcion]) VALUES (20, N'Cocktail')
INSERT [dbo].[TipoEvento] ([IdTipoEvento], [Descripcion]) VALUES (30, N'Cenas')
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre_Usuario], [Contrasenia]) VALUES (1, N'admin', N'd033e22ae348aeb5660fc2140aec35850c4da997')
/****** Object:  Index [IX_Cena_TipoAmbentacion_FK1]    Script Date: 05-07-2019 19:40:53 ******/
CREATE NONCLUSTERED INDEX [IX_Cena_TipoAmbentacion_FK1] ON [dbo].[Cenas]
(
	[IdTipoAmbientacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cocktail_TipoAmbentacion_FK1]    Script Date: 05-07-2019 19:40:53 ******/
CREATE NONCLUSTERED INDEX [IX_Cocktail_TipoAmbentacion_FK1] ON [dbo].[Cocktail]
(
	[IdTipoAmbientacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Contrato_Cliente_FK1]    Script Date: 05-07-2019 19:40:53 ******/
CREATE NONCLUSTERED INDEX [IX_Contrato_Cliente_FK1] ON [dbo].[Contrato]
(
	[RutCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Contrato_ModalidadEvento_FK1]    Script Date: 05-07-2019 19:40:53 ******/
CREATE NONCLUSTERED INDEX [IX_Contrato_ModalidadEvento_FK1] ON [dbo].[Contrato]
(
	[IdModalidad] ASC,
	[IdTipoEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CacheContrato]  WITH CHECK ADD  CONSTRAINT [FK_CacheContrato_ModalidadServicio] FOREIGN KEY([IdModalidad], [IdTipoEvento])
REFERENCES [dbo].[ModalidadServicio] ([IdModalidad], [IdTipoEvento])
GO
ALTER TABLE [dbo].[CacheContrato] CHECK CONSTRAINT [FK_CacheContrato_ModalidadServicio]
GO
ALTER TABLE [dbo].[CacheContrato]  WITH CHECK ADD  CONSTRAINT [FK_CacheContrato_TipoAmbientacion] FOREIGN KEY([IdTipoAmbientacion])
REFERENCES [dbo].[TipoAmbientacion] ([IdTipoAmbientacion])
GO
ALTER TABLE [dbo].[CacheContrato] CHECK CONSTRAINT [FK_CacheContrato_TipoAmbientacion]
GO
ALTER TABLE [dbo].[CacheContrato]  WITH CHECK ADD  CONSTRAINT [FK_CacheContrato_TipoEvento] FOREIGN KEY([IdTipoEvento])
REFERENCES [dbo].[TipoEvento] ([IdTipoEvento])
GO
ALTER TABLE [dbo].[CacheContrato] CHECK CONSTRAINT [FK_CacheContrato_TipoEvento]
GO
ALTER TABLE [dbo].[Cenas]  WITH CHECK ADD  CONSTRAINT [Cena_TipoAmbientacion_FK1] FOREIGN KEY([IdTipoAmbientacion])
REFERENCES [dbo].[TipoAmbientacion] ([IdTipoAmbientacion])
GO
ALTER TABLE [dbo].[Cenas] CHECK CONSTRAINT [Cena_TipoAmbientacion_FK1]
GO
ALTER TABLE [dbo].[Cenas]  WITH CHECK ADD  CONSTRAINT [Contrato_Cenas_FK1] FOREIGN KEY([Numero])
REFERENCES [dbo].[Contrato] ([Numero])
GO
ALTER TABLE [dbo].[Cenas] CHECK CONSTRAINT [Contrato_Cenas_FK1]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [Cliente_ActividadEmpresa_FK1] FOREIGN KEY([IdActividadEmpresa])
REFERENCES [dbo].[ActividadEmpresa] ([IdActividadEmpresa])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [Cliente_ActividadEmpresa_FK1]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [Cliente_TipoEmpresa_FK1] FOREIGN KEY([IdTipoEmpresa])
REFERENCES [dbo].[TipoEmpresa] ([IdTipoEmpresa])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [Cliente_TipoEmpresa_FK1]
GO
ALTER TABLE [dbo].[Cocktail]  WITH CHECK ADD  CONSTRAINT [Cocktail_TipoAmbientacion_FK1] FOREIGN KEY([IdTipoAmbientacion])
REFERENCES [dbo].[TipoAmbientacion] ([IdTipoAmbientacion])
GO
ALTER TABLE [dbo].[Cocktail] CHECK CONSTRAINT [Cocktail_TipoAmbientacion_FK1]
GO
ALTER TABLE [dbo].[Cocktail]  WITH CHECK ADD  CONSTRAINT [Contrato_Cocktail_FK1] FOREIGN KEY([Numero])
REFERENCES [dbo].[Contrato] ([Numero])
GO
ALTER TABLE [dbo].[Cocktail] CHECK CONSTRAINT [Contrato_Cocktail_FK1]
GO
ALTER TABLE [dbo].[CoffeeBreak]  WITH CHECK ADD  CONSTRAINT [Contrato_CoffeeBreak_FK1] FOREIGN KEY([Numero])
REFERENCES [dbo].[Contrato] ([Numero])
GO
ALTER TABLE [dbo].[CoffeeBreak] CHECK CONSTRAINT [Contrato_CoffeeBreak_FK1]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [Contrato_Cliente_FK1] FOREIGN KEY([RutCliente])
REFERENCES [dbo].[Cliente] ([RutCliente])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [Contrato_Cliente_FK1]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [Contrato_ModalidadEvento_FK1] FOREIGN KEY([IdModalidad], [IdTipoEvento])
REFERENCES [dbo].[ModalidadServicio] ([IdModalidad], [IdTipoEvento])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [Contrato_ModalidadEvento_FK1]
GO
ALTER TABLE [dbo].[ModalidadServicio]  WITH CHECK ADD  CONSTRAINT [ModalidadServicio_TipoEvento_FK1] FOREIGN KEY([IdTipoEvento])
REFERENCES [dbo].[TipoEvento] ([IdTipoEvento])
GO
ALTER TABLE [dbo].[ModalidadServicio] CHECK CONSTRAINT [ModalidadServicio_TipoEvento_FK1]
GO
USE [master]
GO
ALTER DATABASE [OnBreak] SET  READ_WRITE 
GO
