USE [master]
GO
/****** Object:  Database [proyecto_SistemaFacturacion]    Script Date: 28/07/2020 22:44:19 ******/
CREATE DATABASE [proyecto_SistemaFacturacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'proyecto_SistemaFacturacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\proyecto_SistemaFacturacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'proyecto_SistemaFacturacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\proyecto_SistemaFacturacion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [proyecto_SistemaFacturacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET  ENABLE_BROKER 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET  MULTI_USER 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET QUERY_STORE = OFF
GO
USE [proyecto_SistemaFacturacion]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 28/07/2020 22:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](13) NULL,
	[Nombre] [varchar](50) NULL,
	[Telefono] [varchar](20) NULL,
	[Email] [varchar](40) NULL,
	[Categoria] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entradas]    Script Date: 28/07/2020 22:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entradas](
	[IdProducto] [int] NULL,
	[NombreProducto] [varchar](60) NULL,
	[Cantidad] [int] NULL,
	[IdProveedor] [int] NULL,
	[FechaIngreso] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturacion]    Script Date: 28/07/2020 22:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturacion](
	[Fecha] [date] NULL,
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdProducto] [int] NULL,
	[IdProveedor] [int] NULL,
	[CantidadProducto] [decimal](18, 0) NULL,
	[PrecioProducto] [decimal](10, 2) NULL,
	[Descuento] [int] NULL,
	[Itbis] [int] NULL,
	[Total] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 28/07/2020 22:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 28/07/2020 22:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](60) NULL,
	[Precio] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 28/07/2020 22:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](13) NULL,
	[Nombre] [varchar](70) NULL,
	[Telefono] [varchar](20) NULL,
	[Email] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([IdCliente], [Cedula], [Nombre], [Telefono], [Email], [Categoria]) VALUES (49, N'6465456', N'JUSTIN', N'546545', N'JUSTIN@MAIL', N'PREMIUM')
GO
INSERT [dbo].[Cliente] ([IdCliente], [Cedula], [Nombre], [Telefono], [Email], [Categoria]) VALUES (50, N'54545', N'ALBERTO', N'54654', N'ALBERT@MAIL', N'PREMIUM')
GO
INSERT [dbo].[Cliente] ([IdCliente], [Cedula], [Nombre], [Telefono], [Email], [Categoria]) VALUES (51, N'89741', N'MELITO', N'45411', N'MELITO@MAIL', N'REGULAR')
GO
INSERT [dbo].[Cliente] ([IdCliente], [Cedula], [Nombre], [Telefono], [Email], [Categoria]) VALUES (52, N'455445', N'DONALD ', N'4884984', N'TRUMP@MAIL', N'PREMIUM')
GO
INSERT [dbo].[Cliente] ([IdCliente], [Cedula], [Nombre], [Telefono], [Email], [Categoria]) VALUES (53, N'5456454', N'KEVIN VALDEZ', N'8095954122', N'@PIRUETAKEVIN', N'REGULAR')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[Entradas] ([IdProducto], [NombreProducto], [Cantidad], [IdProveedor], [FechaIngreso]) VALUES (38, N'FANTA SODA', 3, 11, CAST(N'2020-07-28' AS Date))
GO
INSERT [dbo].[Entradas] ([IdProducto], [NombreProducto], [Cantidad], [IdProveedor], [FechaIngreso]) VALUES (40, N'LECHE RICA', 2, 10, CAST(N'2020-07-28' AS Date))
GO
INSERT [dbo].[Entradas] ([IdProducto], [NombreProducto], [Cantidad], [IdProveedor], [FechaIngreso]) VALUES (39, N'HELADO', 2, 9, CAST(N'2020-07-28' AS Date))
GO
INSERT [dbo].[Entradas] ([IdProducto], [NombreProducto], [Cantidad], [IdProveedor], [FechaIngreso]) VALUES (42, N'PALETA', 7, 8, CAST(N'2020-07-28' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Facturacion] ON 
GO
INSERT [dbo].[Facturacion] ([Fecha], [IdFactura], [IdCliente], [IdProducto], [IdProveedor], [CantidadProducto], [PrecioProducto], [Descuento], [Itbis], [Total]) VALUES (CAST(N'2020-07-28' AS Date), 15, 53, 38, 11, CAST(1 AS Decimal(18, 0)), CAST(20.00 AS Decimal(10, 2)), 0, 18, CAST(23.60 AS Decimal(10, 2)))
GO
INSERT [dbo].[Facturacion] ([Fecha], [IdFactura], [IdCliente], [IdProducto], [IdProveedor], [CantidadProducto], [PrecioProducto], [Descuento], [Itbis], [Total]) VALUES (CAST(N'2020-07-28' AS Date), 16, 51, 40, 10, CAST(1 AS Decimal(18, 0)), CAST(30.00 AS Decimal(10, 2)), 0, 18, CAST(35.40 AS Decimal(10, 2)))
GO
INSERT [dbo].[Facturacion] ([Fecha], [IdFactura], [IdCliente], [IdProducto], [IdProveedor], [CantidadProducto], [PrecioProducto], [Descuento], [Itbis], [Total]) VALUES (CAST(N'2020-07-28' AS Date), 17, 50, 40, 10, CAST(1 AS Decimal(18, 0)), CAST(30.00 AS Decimal(10, 2)), 5, 18, CAST(33.63 AS Decimal(10, 2)))
GO
INSERT [dbo].[Facturacion] ([Fecha], [IdFactura], [IdCliente], [IdProducto], [IdProveedor], [CantidadProducto], [PrecioProducto], [Descuento], [Itbis], [Total]) VALUES (CAST(N'2020-07-28' AS Date), 18, 52, 42, 8, CAST(3 AS Decimal(18, 0)), CAST(15.00 AS Decimal(10, 2)), 5, 18, CAST(50.45 AS Decimal(10, 2)))
GO
INSERT [dbo].[Facturacion] ([Fecha], [IdFactura], [IdCliente], [IdProducto], [IdProveedor], [CantidadProducto], [PrecioProducto], [Descuento], [Itbis], [Total]) VALUES (CAST(N'2020-07-28' AS Date), 19, 49, 42, 8, CAST(1 AS Decimal(18, 0)), CAST(15.00 AS Decimal(10, 2)), 5, 18, CAST(16.82 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[Facturacion] OFF
GO
INSERT [dbo].[Inventario] ([IdProducto], [Cantidad]) VALUES (38, 2)
GO
INSERT [dbo].[Inventario] ([IdProducto], [Cantidad]) VALUES (39, 2)
GO
INSERT [dbo].[Inventario] ([IdProducto], [Cantidad]) VALUES (42, 3)
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 
GO
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Precio]) VALUES (38, N'FANTA SODA', CAST(20 AS Decimal(18, 0)))
GO
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Precio]) VALUES (39, N'HELADO', CAST(34 AS Decimal(18, 0)))
GO
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Precio]) VALUES (40, N'LECHE RICA', CAST(30 AS Decimal(18, 0)))
GO
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Precio]) VALUES (42, N'PALETA', CAST(15 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedor] ON 
GO
INSERT [dbo].[Proveedor] ([IdProveedor], [Cedula], [Nombre], [Telefono], [Email]) VALUES (1, N'54542', N'CORRIPIO', N'545458', N'CORRIPIO@EMAIL')
GO
INSERT [dbo].[Proveedor] ([IdProveedor], [Cedula], [Nombre], [Telefono], [Email]) VALUES (8, N'44545', N'PALMARITO', N'5454545', N'54545@MAIL')
GO
INSERT [dbo].[Proveedor] ([IdProveedor], [Cedula], [Nombre], [Telefono], [Email]) VALUES (9, N'64544', N'BALTAZAR', N'1122334', N'@BALTERRMAIL')
GO
INSERT [dbo].[Proveedor] ([IdProveedor], [Cedula], [Nombre], [Telefono], [Email]) VALUES (10, N'65154', N'FULANO', N'56544', N'@FULANITO')
GO
INSERT [dbo].[Proveedor] ([IdProveedor], [Cedula], [Nombre], [Telefono], [Email]) VALUES (11, N'651545', N'RAFA', N'5465654', N'@RAFAMAIL')
GO
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Cliente__B4ADFE38F91AADE4]    Script Date: 28/07/2020 22:44:20 ******/
ALTER TABLE [dbo].[Cliente] ADD UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Producto__75E3EFCF9EFBFAC9]    Script Date: 28/07/2020 22:44:20 ******/
ALTER TABLE [dbo].[Producto] ADD UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Proveedo__4EC50480F36587FC]    Script Date: 28/07/2020 22:44:20 ******/
ALTER TABLE [dbo].[Proveedor] ADD UNIQUE NONCLUSTERED 
(
	[Telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Proveedo__75E3EFCFC647A3D7]    Script Date: 28/07/2020 22:44:20 ******/
ALTER TABLE [dbo].[Proveedor] ADD UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Proveedo__A9D1053440B2E4A2]    Script Date: 28/07/2020 22:44:20 ******/
ALTER TABLE [dbo].[Proveedor] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Proveedo__B4ADFE384487BC84]    Script Date: 28/07/2020 22:44:20 ******/
ALTER TABLE [dbo].[Proveedor] ADD UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Entradas]  WITH CHECK ADD  CONSTRAINT [FK_IdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Entradas] CHECK CONSTRAINT [FK_IdProducto]
GO
ALTER TABLE [dbo].[Entradas]  WITH CHECK ADD  CONSTRAINT [FK_IdProveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Entradas] CHECK CONSTRAINT [FK_IdProveedor]
GO
ALTER TABLE [dbo].[Facturacion]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Facturacion]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Facturacion]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD CHECK  (([Categoria]='PREMIUM' OR [Categoria]='REGULAR'))
GO
/****** Object:  Trigger [dbo].[trig_InsertEntradas]    Script Date: 28/07/2020 22:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


	   create trigger [dbo].[trig_InsertEntradas] on [dbo].[Entradas]   -- ANALIZAR SI NECESITARAS EL TRIGGER
	   after insert
	   as
	   begin

	    declare @IdProducto int;
		declare @CantidadProducto int;

	   set @IdProducto = (Select Idproducto from inserted);
	   set @CantidadProducto = (Select Cantidad from inserted);

		insert into Inventario values (@IdProducto, @CantidadProducto);



	   end
GO
ALTER TABLE [dbo].[Entradas] ENABLE TRIGGER [trig_InsertEntradas]
GO
/****** Object:  Trigger [dbo].[trig_UpdateEntradas]    Script Date: 28/07/2020 22:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trig_UpdateEntradas] on [dbo].[Entradas]
  after update
  as
  begin
       
	   if(UPDATE (Cantidad))
	   begin

	   declare @nuevaCantidad int;
	   declare @Id int;

	   set @nuevaCantidad = (select Cantidad from inserted);
	   set @Id = (select IdProducto from inserted );

	   update Inventario set Cantidad = @nuevaCantidad where IdProducto = @Id;

	   end 

       end 
GO
ALTER TABLE [dbo].[Entradas] ENABLE TRIGGER [trig_UpdateEntradas]
GO
/****** Object:  Trigger [dbo].[trig_UpdateProducto]    Script Date: 28/07/2020 22:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger	[dbo].[trig_UpdateProducto]	 on [dbo].[Producto] --- trigger en caso de una actualizacion en la tabla producto.
after update	
as 
begin

   IF (UPDATE (Nombre) )  --- en caso de que haya actualizado el nombre
      begin

	  	   declare @numeroLineasTablas int;

	         declare @nuevoNombreProducto varchar(60);
			 declare @viejoNombreProducto varchar(60);  

			 set @nuevoNombreProducto = (select  Nombre from inserted);   -- tomar nuevo nombre del producto insertado
             set @viejoNombreProducto = (select  Nombre from deleted);      -- tomar viejo nombre del producto eliminado luego de ser actualizado 
			 
       set @numeroLineasTablas = (select count(*) from dbo.Entradas);

		IF ( @numeroLineasTablas > 0 )
	     begin
                update Entradas set NombreProducto = @nuevoNombreProducto where NombreProducto = @viejoNombreProducto;   -- actualizar tabla ENTRADAS
	   end

         end  -- finalizar IF de actualizacion del campo NOMBRE de la tabla PRODUCTO  
		 
   end --- finalizar trigger en caso de UPDATE en la tabla PRODUCTO

GO
ALTER TABLE [dbo].[Producto] ENABLE TRIGGER [trig_UpdateProducto]
GO
USE [master]
GO
ALTER DATABASE [proyecto_SistemaFacturacion] SET  READ_WRITE 
GO
