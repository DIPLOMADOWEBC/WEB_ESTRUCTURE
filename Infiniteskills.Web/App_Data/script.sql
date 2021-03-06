USE [pe_infinite_last]
GO
/****** Object:  StoredProcedure [dbo].[sp_usuario_sucursal]    Script Date: 02/08/2020 11:04:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_usuario_sucursal]
@usuarioid int
as
begin
select usuario_id as usuarioid,
	   usuario as nombreusuario,
	   concat(p.nombres ,' ', p.apellidos) as nombres,
	   e.empresa_id as empresaid,
	   e.nombre as nombreempresa,
	   s.sucursal_id as sucursalid,
	   a.nombre as nombrealmacen,
	   a.almacen_id as almacenid,
	   s.nombre as nombresucursal,
	   pe.periodo_empresa_id as periodoempresaid,
	   pr.periodo as periodonombre,
	   pr.periodo_id as periodoid
			from usuario u 
			INNER JOIN personal p on p.personal_id = u.personal_id
			INNER JOIN sucursal_personal sp on sp.personal_id = p.personal_id  AND sp.estado = 'A'
			INNER JOIN sucursal s on s.sucursal_id = sp.sucursal_id
		    INNER JOIN empresa e on e.empresa_id = s.empresa_id
			INNER JOIN almacen a on a.sucursal_id = s.sucursal_id
			LEFT JOIN periodo_empresa pe on pe.sucursal_id = s.sucursal_id
			LEFT JOIN periodo pr on pr.periodo_id = pe.periodo_id
			where u.usuario_id = @usuarioid  and u.estado = 'A' order by pr.periodo_id desc
end

GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[almacen]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[almacen](
	[almacen_id] [int] IDENTITY(1,1) NOT NULL,
	[sucursal_id] [int] NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[direccion] [nvarchar](max) NULL,
	[telefono] [nvarchar](max) NULL,
	[stock_sn] [nvarchar](1) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.almacen] PRIMARY KEY CLUSTERED 
(
	[almacen_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[area]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[area](
	[area_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.area] PRIMARY KEY CLUSTERED 
(
	[area_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bien_servicio]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bien_servicio](
	[bien_servicio_id] [int] IDENTITY(1,1) NOT NULL,
	[bien_servicio] [nvarchar](max) NOT NULL,
	[linea_id] [int] NOT NULL,
	[codigo_com] [nvarchar](max) NOT NULL,
	[descripcion] [nvarchar](max) NULL,
	[categoria_id] [int] NOT NULL,
	[moneda_id] [int] NOT NULL,
	[tipo_existencia_id] [int] NOT NULL,
	[proveedor_id] [int] NULL,
	[stock_minimo] [decimal](12, 4) NOT NULL,
	[stock_maximo] [decimal](12, 4) NOT NULL,
	[existencia] [decimal](18, 2) NOT NULL,
	[modelo] [nvarchar](max) NULL,
	[marca_id] [int] NOT NULL,
	[tipo_bien_id] [int] NOT NULL,
	[almacen_id] [int] NULL,
	[unidad_medida_id] [int] NOT NULL,
	[precio_unitario] [decimal](12, 4) NOT NULL,
	[precio_venta] [decimal](12, 4) NULL,
	[observacion] [nvarchar](max) NULL,
	[procedencia] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.bien_servicio] PRIMARY KEY CLUSTERED 
(
	[bien_servicio_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[categoria]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[categoria_id] [int] IDENTITY(1,1) NOT NULL,
	[categoria] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.categoria] PRIMARY KEY CLUSTERED 
(
	[categoria_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[conductor]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conductor](
	[conductor_id] [int] IDENTITY(1,1) NOT NULL,
	[documento] [nvarchar](max) NULL,
	[nombres] [nvarchar](max) NULL,
	[num_licencia] [nvarchar](max) NULL,
	[telefono] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.conductor] PRIMARY KEY CLUSTERED 
(
	[conductor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[contacto]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contacto](
	[contacto_id] [int] IDENTITY(1,1) NOT NULL,
	[area_id] [int] NOT NULL,
	[num_ruc] [nvarchar](max) NOT NULL,
	[nombres] [nvarchar](max) NULL,
	[telefono] [nvarchar](max) NOT NULL,
	[celular] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[direccion] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.contacto] PRIMARY KEY CLUSTERED 
(
	[contacto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departamento]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departamento](
	[departamento_id] [int] IDENTITY(1,1) NOT NULL,
	[departamento] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[pais_id] [int] NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.departamento] PRIMARY KEY CLUSTERED 
(
	[departamento_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[direccion]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[direccion](
	[direccion_id] [int] IDENTITY(1,1) NOT NULL,
	[proveedor_id] [int] NOT NULL,
	[nombre_via] [nvarchar](max) NOT NULL,
	[referencia] [nvarchar](max) NOT NULL,
	[fiscal] [nvarchar](max) NULL,
	[distrito_id] [int] NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.direccion] PRIMARY KEY CLUSTERED 
(
	[direccion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[distrito]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[distrito](
	[distrito_id] [int] IDENTITY(1,1) NOT NULL,
	[distrito] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[provincia_id] [int] NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.distrito] PRIMARY KEY CLUSTERED 
(
	[distrito_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[doc_identidad]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doc_identidad](
	[doc_identidad_id] [int] IDENTITY(1,1) NOT NULL,
	[doc_identidad] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.doc_identidad] PRIMARY KEY CLUSTERED 
(
	[doc_identidad_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[empresa]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[empresa](
	[empresa_id] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [nvarchar](max) NOT NULL,
	[numero_ruc] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[direccion] [nvarchar](max) NULL,
	[telefono] [nvarchar](max) NULL,
	[email] [nvarchar](max) NOT NULL,
	[igv_sn] [nvarchar](max) NULL,
	[renta] [decimal](18, 2) NOT NULL,
	[logo] [varbinary](max) NULL,
	[ruta_xml] [nvarchar](max) NULL,
	[ruta_pdf] [nvarchar](max) NULL,
	[ruta_cdr] [nvarchar](max) NULL,
	[ruta_firma] [nvarchar](max) NULL,
	[contrasena_firma] [nvarchar](max) NULL,
	[usuario_correo] [nvarchar](max) NULL,
	[alias_correo] [nvarchar](max) NULL,
	[correo] [nvarchar](max) NULL,
	[contrasena_correo] [nvarchar](max) NULL,
	[server_smtp] [nvarchar](max) NULL,
	[puerto_smtp] [nvarchar](max) NULL,
	[seguridad_ssl] [bit] NOT NULL,
	[usuario_sunat] [nvarchar](max) NULL,
	[contrasena_sunat] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.empresa] PRIMARY KEY CLUSTERED 
(
	[empresa_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[forma_pago]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[forma_pago](
	[forma_pago_id] [int] IDENTITY(1,1) NOT NULL,
	[forma_pago] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.forma_pago] PRIMARY KEY CLUSTERED 
(
	[forma_pago_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[forma_venta]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[forma_venta](
	[FORMA_VENTA_ID] [int] IDENTITY(1,1) NOT NULL,
	[FORMA_VENTA] [nvarchar](max) NOT NULL,
	[NOMBRE] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.FORMA_VENTA] PRIMARY KEY CLUSTERED 
(
	[FORMA_VENTA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[impuesto]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[impuesto](
	[impuesto_id] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.impuesto] PRIMARY KEY CLUSTERED 
(
	[impuesto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[linea]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[linea](
	[LINEA_ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.LINEA] PRIMARY KEY CLUSTERED 
(
	[LINEA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[marca]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marca](
	[MARCA_ID] [int] IDENTITY(1,1) NOT NULL,
	[MARCA] [nvarchar](max) NOT NULL,
	[NOMBRE] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.MARCA] PRIMARY KEY CLUSTERED 
(
	[MARCA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[menu]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[menu_id] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[area] [nvarchar](50) NOT NULL,
	[url] [nvarchar](50) NULL,
	[imagen] [nvarchar](50) NOT NULL,
	[menu_padre_id] [int] NULL,
	[orden] [int] NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_dbo.menu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mes_contable]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mes_contable](
	[mes_contable_id] [int] IDENTITY(1,1) NOT NULL,
	[mes_contable] [nvarchar](max) NULL,
	[nombre] [nvarchar](max) NULL,
	[num_cierre_alm] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.mes_contable] PRIMARY KEY CLUSTERED 
(
	[mes_contable_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[moneda]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[moneda](
	[moneda_id] [int] IDENTITY(1,1) NOT NULL,
	[moneda] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[simbolo] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.moneda] PRIMARY KEY CLUSTERED 
(
	[moneda_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mov_alm_saldo]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mov_alm_saldo](
	[mov_alm_saldo_id] [int] IDENTITY(1,1) NOT NULL,
	[almacen_id] [int] NOT NULL,
	[bien_servicio_id] [int] NOT NULL,
	[periodo_empresa_id] [int] NOT NULL,
	[mes_contable_id] [int] NOT NULL,
	[cant_ant] [decimal](18, 2) NOT NULL,
	[valor_ant] [decimal](18, 2) NOT NULL,
	[valor_unit] [decimal](18, 2) NOT NULL,
	[valor_unit_ant] [decimal](18, 2) NOT NULL,
	[cant_ingr] [decimal](18, 2) NOT NULL,
	[valor_ingr] [decimal](18, 2) NOT NULL,
	[cant_salid] [decimal](18, 2) NOT NULL,
	[valor_salid] [decimal](18, 2) NOT NULL,
	[monto_sal] [decimal](18, 2) NOT NULL,
	[cant_reserv] [decimal](18, 2) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.mov_alm_saldo] PRIMARY KEY CLUSTERED 
(
	[mov_alm_saldo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[orden]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orden](
	[orden_id] [int] IDENTITY(1,1) NOT NULL,
	[orden] [nvarchar](max) NOT NULL,
	[num_doc_co] [nvarchar](max) NOT NULL,
	[operacion] [nvarchar](max) NOT NULL,
	[tipo_doc_com_id] [int] NOT NULL,
	[tipo_operacion_id] [int] NOT NULL,
	[fecha_orden] [datetime] NOT NULL,
	[forma_pago_id] [int] NULL,
	[moneda_id] [int] NULL,
	[periodo_empresa_id] [int] NOT NULL,
	[mes_contable_id] [int] NOT NULL,
	[almacen_id] [int] NOT NULL,
	[almacen_dest_id] [int] NULL,
	[vehiculo_id] [int] NULL,
	[conductor_id] [int] NULL,
	[tipo_precio_id] [int] NULL,
	[impuesto_id] [int] NULL,
	[fecha_entrega] [datetime] NULL,
	[cantidad] [decimal](12, 4) NOT NULL,
	[sub_total] [decimal](18, 2) NOT NULL,
	[descuento] [decimal](18, 2) NOT NULL,
	[impuesto] [decimal](18, 2) NOT NULL,
	[total_pedido] [decimal](18, 2) NOT NULL,
	[total_exone] [decimal](18, 2) NOT NULL,
	[total_inafec] [decimal](18, 2) NOT NULL,
	[personal_id] [int] NOT NULL,
	[proveedor_id] [int] NULL,
	[observacion] [nvarchar](max) NULL,
	[anulado] [nvarchar](1) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.orden] PRIMARY KEY CLUSTERED 
(
	[orden_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[orden_item]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orden_item](
	[orden_item_id] [int] IDENTITY(1,1) NOT NULL,
	[orden_id] [int] NOT NULL,
	[bien_servicio_id] [int] NOT NULL,
	[cantidad] [decimal](12, 4) NOT NULL,
	[peso_neto] [decimal](18, 2) NOT NULL,
	[peso_bruto] [decimal](18, 2) NOT NULL,
	[valor_unit] [decimal](18, 2) NOT NULL,
	[valor_orden] [decimal](18, 2) NOT NULL,
	[valor_promo] [decimal](18, 2) NOT NULL,
	[valor_mov] [decimal](18, 2) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.orden_item] PRIMARY KEY CLUSTERED 
(
	[orden_item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[pais]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pais](
	[pais_id] [int] IDENTITY(1,1) NOT NULL,
	[pais] [nvarchar](max) NULL,
	[nombre] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.pais] PRIMARY KEY CLUSTERED 
(
	[pais_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[param_sistema]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[param_sistema](
	[param_sistema_id] [int] IDENTITY(1,1) NOT NULL,
	[param_sistema] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](70) NULL,
	[valor_cadena] [nvarchar](max) NULL,
	[valor_numerico] [decimal](18, 2) NULL,
	[valor_fecha] [datetime] NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.param_sistema] PRIMARY KEY CLUSTERED 
(
	[param_sistema_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[periodo]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[periodo](
	[periodo_id] [int] IDENTITY(1,1) NOT NULL,
	[periodo] [int] NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.periodo] PRIMARY KEY CLUSTERED 
(
	[periodo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[periodo_corre]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[periodo_corre](
	[periodo_corre_id] [int] IDENTITY(1,1) NOT NULL,
	[tabla_id] [int] NOT NULL,
	[periodo_empresa_id] [int] NOT NULL,
	[correlativo] [int] NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.periodo_corre] PRIMARY KEY CLUSTERED 
(
	[periodo_corre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[periodo_empresa]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[periodo_empresa](
	[periodo_empresa_id] [int] IDENTITY(1,1) NOT NULL,
	[sucursal_id] [int] NOT NULL,
	[periodo_id] [int] NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.periodo_empresa] PRIMARY KEY CLUSTERED 
(
	[periodo_empresa_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[personal]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personal](
	[personal_id] [int] IDENTITY(1,1) NOT NULL,
	[num_doc] [nvarchar](max) NULL,
	[nombres] [nvarchar](max) NULL,
	[apellidos] [nvarchar](max) NULL,
	[fecha_nac] [datetime] NOT NULL,
	[telefono] [nvarchar](max) NULL,
	[celular] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.personal] PRIMARY KEY CLUSTERED 
(
	[personal_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[prov_contacto]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prov_contacto](
	[prov_contacto_id] [int] IDENTITY(1,1) NOT NULL,
	[contacto_id] [int] NOT NULL,
	[proveedor_id] [int] NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.prov_contacto] PRIMARY KEY CLUSTERED 
(
	[prov_contacto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[proveedor_id] [int] IDENTITY(1,1) NOT NULL,
	[moneda_id] [int] NULL,
	[personal_id] [int] NOT NULL,
	[razon_social] [nvarchar](max) NOT NULL,
	[tipo_proveedor_id] [int] NOT NULL,
	[nombres] [nvarchar](max) NULL,
	[doc_identidad_id] [int] NOT NULL,
	[num_doc_ident] [nvarchar](max) NULL,
	[tipo_cliente] [nvarchar](max) NULL,
	[forma_venta_id] [int] NULL,
	[tipo_precio_id] [int] NULL,
	[distrito_id] [int] NOT NULL,
	[telefono] [nvarchar](20) NULL,
	[celular] [nvarchar](20) NULL,
	[email] [nvarchar](70) NOT NULL,
	[email_dos] [nvarchar](120) NOT NULL,
	[pagina_web] [nvarchar](150) NOT NULL,
	[direccion] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.proveedor] PRIMARY KEY CLUSTERED 
(
	[proveedor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[provincia]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincia](
	[provincia_id] [int] IDENTITY(1,1) NOT NULL,
	[provincia] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[departamento_id] [int] NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.provincia] PRIMARY KEY CLUSTERED 
(
	[provincia_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rol]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[rol_id] [int] NOT NULL,
	[rol] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[origen_registro_id] [int] NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_dbo.rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rol_menu]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol_menu](
	[rol_menu_id] [int] NOT NULL,
	[rol_id] [int] NOT NULL,
	[menu_id] [int] NOT NULL,
	[estado_check] [nvarchar](1) NULL,
	[lectura] [nvarchar](1) NULL,
	[escritura] [nvarchar](1) NULL,
	[anulado] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.rol_menu] PRIMARY KEY CLUSTERED 
(
	[rol_menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rol_usuario]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol_usuario](
	[rol_usuario_id] [int] NOT NULL,
	[usuario_id] [int] NOT NULL,
	[rol_id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.rol_usuario] PRIMARY KEY CLUSTERED 
(
	[rol_usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[serie]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[serie](
	[serie_id] [int] IDENTITY(1,1) NOT NULL,
	[almacen_id] [int] NOT NULL,
	[tipo_doc_com_id] [int] NOT NULL,
	[num_serie] [nvarchar](max) NULL,
	[num_linea] [int] NOT NULL,
	[igv_sn] [nvarchar](max) NULL,
	[formato_doc] [nvarchar](max) NULL,
	[observacion] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.serie] PRIMARY KEY CLUSTERED 
(
	[serie_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sucursal]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sucursal](
	[sucursal_id] [int] IDENTITY(1,1) NOT NULL,
	[empresa_id] [int] NOT NULL,
	[distrito_id] [int] NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[direccion] [nvarchar](max) NULL,
	[telefono] [nvarchar](max) NULL,
	[capacidad] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.sucursal] PRIMARY KEY CLUSTERED 
(
	[sucursal_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sucursal_personal]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sucursal_personal](
	[sucursal_personal_id] [int] IDENTITY(1,1) NOT NULL,
	[sucursal_id] [int] NOT NULL,
	[personal_id] [int] NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.sucursal_personal] PRIMARY KEY CLUSTERED 
(
	[sucursal_personal_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tabla]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tabla](
	[tabla_id] [int] IDENTITY(1,1) NOT NULL,
	[tabla] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[formato] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.tabla] PRIMARY KEY CLUSTERED 
(
	[tabla_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tipo_bien]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_bien](
	[tipo_bien_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.tipo_bien] PRIMARY KEY CLUSTERED 
(
	[tipo_bien_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tipo_doc_com]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_doc_com](
	[tipo_doc_com_id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_doc_com] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.tipo_doc_com] PRIMARY KEY CLUSTERED 
(
	[tipo_doc_com_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tipo_existencia]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_existencia](
	[tipo_existencia_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.tipo_existencia] PRIMARY KEY CLUSTERED 
(
	[tipo_existencia_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tipo_movimiento]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_movimiento](
	[tipo_movimiento_id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_movimiento] [nvarchar](max) NULL,
	[nombre] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.tipo_movimiento] PRIMARY KEY CLUSTERED 
(
	[tipo_movimiento_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tipo_operacion]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_operacion](
	[tipo_operacion_id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_operacion] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
	[TipoMovimiento_TipoMovimientoId] [int] NULL,
 CONSTRAINT [PK_dbo.tipo_operacion] PRIMARY KEY CLUSTERED 
(
	[tipo_operacion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tipo_precio]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_precio](
	[tipo_precio_id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.tipo_precio] PRIMARY KEY CLUSTERED 
(
	[tipo_precio_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tipo_proveedor]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_proveedor](
	[tipo_proveedor_id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_proveedor] [nvarchar](max) NULL,
	[nombre] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.tipo_proveedor] PRIMARY KEY CLUSTERED 
(
	[tipo_proveedor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[unidad_medida]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[unidad_medida](
	[unidad_medida_id] [int] IDENTITY(1,1) NOT NULL,
	[unidad_medida] [nvarchar](max) NULL,
	[nombre] [nvarchar](max) NULL,
	[abreviatura] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.unidad_medida] PRIMARY KEY CLUSTERED 
(
	[unidad_medida_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[usuario]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuario](
	[usuario_id] [int] IDENTITY(1,1) NOT NULL,
	[personal_id] [int] NOT NULL,
	[usuario] [nvarchar](max) NOT NULL,
	[nombres] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[password_hash] [varbinary](max) NOT NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.usuario] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vehiculo]    Script Date: 02/08/2020 11:04:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehiculo](
	[vehiculo_id] [int] IDENTITY(1,1) NOT NULL,
	[num_placa] [nvarchar](max) NULL,
	[placa] [nvarchar](max) NULL,
	[constancia] [nvarchar](max) NULL,
	[estado] [nvarchar](1) NOT NULL,
	[usuario_creacion_id] [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[usuario_modifica_id] [int] NULL,
	[fecha_modifica] [datetime] NULL,
 CONSTRAINT [PK_dbo.vehiculo] PRIMARY KEY CLUSTERED 
(
	[vehiculo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202006221814424_AutomaticMigration', N'Infiniteskills.Infra.Data.Migrations.Configuration', 0x1F8B0800000000000400ED7DDB72DCB892E0FB46EC3F28F4B4BB71C6B27BE6C4CC74D833A196EC19C558B642B23DF35641B12099D32CB29664E9B8CFC67ED93EEC27ED2F2C00DE70495C09822599D1112D17012412406622914864FEBFFFF37FDFFEF38F5D7EF284AA3A2B8B77A76F5EBD3E3D41455A6EB3E2F1DDE9A179F89B7F38FDE77FFAAFFFE5EDFBEDEEC7C9B7BEDEDF927AB86551BF3BFDDE34FB5FCFCEEAF43BDA25F5AB5D9656655D3E34AFD27277966CCBB35F5EBFFEC7B3376FCE1006718A619D9CBCBD3D144DB643F407FE79511629DA378724BF2EB728AFBBEFB8E48E423DF994EC50BD4F52F4EEF4AA78C88AAC41F5EF599ED7AFF0CF2A79759934C9E9C9799E2518A13B943F9C9E244551364983D1FDF56B8DEE9AAA2C1EEFF6F843927FF9638F70BD8724AF51378C5FC7EAB6237AFD0B19D1D9D8B007951EEAA6DC39027CF3B7DD149D89CDBD26FA7498423C89EFF164377F9051D3897C777A5E213C5D6247BF5EE415A924CDF125AE9515AF48AB3F9D80657F1A48035310F9EF4F271787BC3954E85D810E4D95E47F3AB939DCE759FA6FE88F2FE5EFA878571CF29CC512E389CBB80FF8D34D55EE51D5FC718B1E18DCAFB6A727677CDB33B1F1D05468D78FB0F9DB5F4E4F3E612492FB1C0DC4C0CCC65D5356E85F5081AAA441DB9BA4695085D7F26A8BE8744A1808FD7D2A77F715EAFBC3F48739EAF4E43AF9F111158FCDF777A7F89FA7271FB21F68DB7FE970F85A64980171A3A63A2000477DBFEFEB06D382A6DF3773F4FAB53E2455565EE0494EF1E499275A0FEE034ABF273DB01E146672F4054B0D5FE4B06CC91EB21446D0021FB6BD8C9300E053F2943D524212406159D724698357E816E5B442FD3DDBB752EB555FB86939F44355EE6ECB9C69450B365F92EA11351887122ABD2B0F552A60F4F66C14025AD130A2E72A1EFA96CB8B881E131F31C1B68D252AEC449341DC1C76A82A2FCB14FF2D9A725CC6D8F2A7957B01FBD777F705E5E8A12C161CF005CA0F79522D87C07BCC5EF972DD5F66154A894C5C7006D63DEFA8F7BC7637F3DFEFFA1D0DDEEFFADDD0161BFCF309A16D5969B762A9D666AC3EE2A9AE256DD29AAA93766C6038AE5BB70462F93D5C42C967330781C4DAD5EDFBD4C319063115D02A258F5B4ACE2B8E44196A21B99C05AA1EF30D20A900D4E56A6A510AD40D234B27C8D023929D9364664C59795D16682B9F810C8211CF675924F95491729BFCB52CEECA344BF2F8AAEB976C5F0693F0EDD9AB9EFDD0351C33DBF5DD26DBC0C7D7F98F8D78DA2FF20CF715C24467D822CA6A977CC35DB912784B1B08EF2A8E0D2FB31A0F66BAEAD11FAE3553F4CBEB0033D41DA167EFA6AC2A547ED58EE7EFED3A72B511D09E2F4B1D6BBEB11CA3ABFA983C6645F2EFE85ED7F59F67E9BA1547837D6076465B15DCE356707BB104AA897DE186D1C146ED502E959442A00AA40B6A1194F6351855A99A02694D3D197D5D65D7818C5B0E3880B118461C2A9710062BB922DA2A7E20926D118CA058262127557045EC738597C1709EE9EA4067185AA43E7375E5CE07AD4EE385F1EA0AE119934BE553955CC575D6F0CFED417584FD0DAB5B77A87ACAB0148191846B48882AAA7920EB6207F43FBEAAC9407DD4B51DC4A82382D88FC5F08C43E5D27C83955C679B3BE8687095A6464657AAA2C058AE37C938306E5FAEB681BEE5F2A601F664E06A19B03F558434A26EB3C7C56E31E3F74B48352BD26CF27DF0AA0B1FBB2E3C9C8A4065B82B1D45D7287D58AD58590D508FD575BD77CE309ABCB83F6A947D170C291F29F7745A0ACEAA5C0A1AA0852AAE737877480F55ADD0E5FA42103FA950424FAE3171E31349C7670B14611CC366D8E1E4B71B328D636D87812DC5214D33AE4677F4802AD47268ECBE3F64751AC4D61FC70ABB6EE5C7BE956BCD5A937772797B34EFFADEB79FDDA6E973FB499B2E2FD53915DAE7F6D352FF5E0F39BEFD5EA27D52354967ED5C85E38B168ECC5AC30292A9B0612410231BC11AF20107AEE67C07A093E6CE0707C8F4A7385BF8A9E6DCF43A2BE54CEBE505B728169C357227B1B28A6F4B35F626C9EA554ABF6C294DD6181678B860C30B1946DE8985B29D44AAE1636A521B72BC370F49A7D6EF317EEA349D54674D1AB75A5E16F74CEFAC3F5B098B2394BD47216A573179DC62D2A8CC3A8A4B493B540A542F01349A985D8550DF727941D463E2238CD8B6B104D2FBDDBE42F5E4EBBB50B6C3C58EF8D19CFE2C7C54C3747491ECB1F8A03E61EB36F0536F03E7F92E4915DE615DD96694BDE306209649EAB25421A8F1C2F15251DC9CD4D78EB6D875B21144AE2B03E74D2C93E64DAAE07B19DB919976FA06373908556525E51DAD5C73D25DED409BCED15DDA86CBEFF81D225E315EC6A6B1F67B7B1D63DDA8236DD47845D3DFEF7403B2DB3FD74DFA396FD26A07EED6F77A1094A3F0E60A2481CD977AF993DF25F916DE5CC66225625C298C1D5FC57913445586E0AD8F9440887105F216C7950675907252B3444D46A98779EDB81DA1B9EEB7B4D9F2BB2D45C367AF1D1A3E3B53DFE24F531D11F88C7F24CB786931F1A4F0249017D2939F9466FB72185090EDABE3BF897B177DCD74933CBA3EB5F57DB99E95DB3290ADE81AD5F4F9086E311594B5026D05E612D54D56B8CEE837F43D4B0FB96B333C05F4E991EC1A692648AF47D657BBFD010FD0B519A559BC8954E831316A379209AA7F95D8B5C368EFC8E64707D08570C518DCA50959ABBF735EB8BBC3FD172CAE736D07FF3074E061D744757A60C568F01EFA6599AD033A4137689B6D67EEE3FD8F92EC9573777355240F289D71C26E02C5E9503B3F1BF6CFFB1A554FA1765083E4C37AD802C7C2F5307ADC87519DC5D8F2382A1E62E0C3AA2D42C36EA90ACBD796CA4F9C852228142D57EEFD047FD038F54FF0876A9B5E2403EFEFC54AEAC7F7524DAF97F7448F543FBC27A500B66219FCE09EADE0FCD87E5414E117F763B9BCF052A1FCE65EAA113E1A808C16F35D1505C00F99F680DBA09D9A6B49A98C9250049B6A9872679728EEF4A08A05C05401021500E5503C00B99207B236210B246E108A34C10AFC78E146FB84712835C77850C7A6F39B30EE80AC7C273FD49011048AC1F7F1621DBF07FD3691074014D9325DC4013FE4FA4324885A5F2823C697486809C55303ADF73BB047A4F5B6E9F2E643EED4ED6A42541FD9E7CCCB1039D25C24D7C176581FB334D49BCA23B9CC5B4F36C77DB2515FB3391C2280F8DEE021C3EF890C70A2707E2823C1585EF4C2B679E747331E16FE1770A7B326E759A519785A69CF21E12D0ED28313A36DC24BD831E607571937345D5EB4719771AE124D7D93B70AB25590AD82CCC906298A2DA591D24B5A7106495779C5345E5E620977F0AE32CBE90AFF08A5D6711C816937D7E553B6CBA21CED572178DC42507D3675BCE910A5A0FA2E24903BA8D44157558364EBFB69C4B4AD36DDE1B143C8CBEB91B65D5E668FB878FB3F0EAD6349EC400E5A6C04E5C96E19C7EACCD67B4B9D170D4171482F11DCC1E55B929755D7CBBC9DE09DA349A2F432FBA4F5AB73553C62BA9979447377D20F06CB836C9BCC3B9699FBB8C6DC5776D27DE6D9BA45D4316BB67E56FDECB8F533A35794CB8318D03F0A7E33638B1FBB4B9A331AC07A9AA28A3EA701A0D0CDE6E363AB591ABD7DFCF0F5746691B05656B2726B51E36EAD15F3C4E2AA17B3AD97D78C45F5D0553776532F8FD09EE128553F66C5F40CEE2DF2CC2565F4C73EA84EAB6C1FC54FFA02AFEF63594DCF73A0787FE3F12AE9FD8FAC6E5088DC0BBE8EEAF4E1F235E6FC9D5EF79AF4C283F691FC98B38F7126EB19D5D42DCAE737F15D27551A84BA88489CEB759641E52B88AE7D4DCCF501289BF8E4599D42A71050DB4D97BFCCB68FE37904827FA6681BC7116B3DE31CF71967D8E8601FA9BE94C49CEC32A7316E5252A9FCDC42AEE2AA8153E505C48E966C78C576C44E2E95B003AA389F678800864F32A4049C37BE443EB9F0C5B3A42C9471E28B34090BFDB0325C284C38A98A076BD389D6ED8ADAE281858A00E11A9AE716930851FF60C03BB7A17676C76A3E69010928A56B3E290409552A049DF3F91A3E4F0746255189E3584549039A6A20DEAABAAE2360952A107FB60238CF60050967B8D6B48707E38EE4FCF0A06FBABC89823B403A3F3CB03F7D3E7FE3C4EA22B66AA68A0D4D9DABD75931955CF8D5BAAB97D4EAB4545789459B2D2FAD0603A1ABA4B2B42C067C1EB54A8B555AF8DC85391F164589A1394FFA3997B6274767B752D26C798931181E9D5D49ED2C96AB5EB34AAA9729A9B47A8DB5D14872A4846D4A7E92A9B320398B26DAEE0864D370E7E62C9C2C6FEB56E9E4DBEF5DB6BB2F835C8CAD62F14589458D33BC4D681D491E427177C288687B23BA0229AD94F6B7F18ED065EBAE58A6414D63D17573C16F4DE75E1EF8A4E9F2FBC8808A7FFCE1AE71ACDDC432E8713CE7FBD92382DEA0BAFC84668D0E5997BF5587197B88E839CFC7229EA50BFC6D57D6EC56304B37F233BAD53D1B02F7823506A3C9C7FB8A16F4D556DFE44E57711CA2F5A9710B108B66BC9675DDB6FB96CBEFDAAC379BEBA66DEF09778416ED559A3D6769A63D73387A44883242ED33E12D2558F7081F5931B63F0E89C17B57FBC80D17FFEC23941EAB72F4A2C48951390AE0C004891993B39397C0E1BD995CC50DDB7A796123BABBBB8A1A3777F92334541F8536748E3BC1AC93E0255E7DE07F7659A955BD3C1D2545D9A877A7F4928A37C2D35457B9C8B75F5E32DE48813A5C65A30C2196740C9566B51BC15430ABC4396E89A3B604DDF8644610850D5829700828A80F8757EF3628FBBEDBA0906C901EAA2A31EE7E9AD0EDAB79E27A51561545F6C9056DAE9569044C65CBC1B02D42EC53DE1BD4D1EC4C13B6A4987B51BF9CFF796085D4F34AFBBD6E60C7BD8189BAA75A686DC4AA92A4126AA8C493582D844CE244A8A77862601C8DA462709A20B40428B1E4D7170C777A2480A051FF383A5915F355AE8553C60CE19F34EA9BF56B56C24FB00D98941846A0AA233F5F55559CF41AB443DEF98A89345B5E1C0FA2CCF942C94E061EA17937B482F9E6F5EB39FAA581E283C4E05E778097B803988EE49344A774716692B1BE3A6E97DAD243B3A52D9717A0374C6E6E0F2DD632AFF773CFDE57CFDECFF91EE579B62DE7EF89B2F227CCC48277A7AF70899609F002E5873CA9E6EF87C8873579C4BA4F2933E8DCD8A72D066C2D605AE3302F5446E8D01B15B954839E77E4A1FEA6AE5B4C10CFBE0E331BFD563AA2ABAC249D8CD4359DC3FA6890EECA405CC532398E8F5861D2A14D1CB0BB062242585E131131F2D1482018CFF086DA12F7757F79DEFB4BCFBBE105A428D6CDA2D455BADB613DD6D660DD7F30633DD49CE6ECD8CB78673FC7B6E1F2A2B243C4CBBB716C1AF1BA348840FB5AA38AFCEB086D6833F57B93D4F55FCA6ABB5CCFFF9AD4DFFBDE7FCB8AA4FAC3AEF775AFFA79F62A27BD5872DB5429CEDE0F673E63C4BBE1FABC9B199A2F2FE639747C5FCD70007EFACB8EF5CEE1A7945F6A77508E45646F50A0187C9523D6F109D7CCBEB857603A56D908A28E4759550F0C89ACAC3CED5E5918918F2C1EDB1F87301EF1F195C63C8467278E8FE269D12A6C8F5BD80A92692E51068961A3DCF316656D461A3F31D6B63D0E11D6E2E22BBEC6D6D1EE7B578D6E1532CE1A5D4BA7B03AC796814284AB10F67E8E010FDED041E53A1CF5B774D602EE1BFA9EA587DC43BCF52D97176E3D263EA28D6D1BD791E5264FD2F9DF47C7E9E502937A93AC49CF56E9AC91CE3DABC9B2992F91A49E503C49DEDDA12A431E77E6A4D9F2928EA2E1753BDE378C25E354F92A1D497BF0F61B72E34E85D80ADF8E0CE63E15D3BEBAF4255390BE7A7CBA9B3F7765E7B71DCFC3326662CE75DF38EE7DA31318B07301E1D6CD50837128600B642702AE74D2B6E11D08E46822804C08FDB140CC8FDBE4AF6571572E930CBD15DBB787F4E7B9C5BACCF0A9328A1C8EE633FE1E33D802C483B7EAD987766BCC8E3D2536F3C772BC307071FC30E07C6892FFD8855810733F37DB8728FD5C04F1CF31F7F321C38A598C433CDE716A5444EAAFD78DE2BCB938CFB3A48ED457B46EFA058BD421893889AABB5DB39FDF6E75C03FCA285DDDA1C7434522C8DDD58378FAADC41A6452F8AAD47787226922AE7F9CFED623D4711FA1B40EDA430418C02F5B2C934E5252854987A9C1C0D09E06680A13D773950C63F923968C93CF690B86F2ECFC459EC9C1679569C72DD3F497AA32AFC097ABBA7A92B0D3569E24F8A881F55B7B7873157863DBE505DD888B8F80E35BAF826D156CAB601305DBC823B04083CA254106560AE00E37E0E3E711D7355F5E8C71E8F8FBC531009E9D305BBD7A5751355154714CA0F36D93AA28DCDBE47A9364D6D56E7F40B5CF3B84BEE5F292AAC7C44748B16D57D7DD55921CA773584FA5B273185F22C90CA17892A8B846C5C15D4C9056CB8B0882858F78E8DB4D150D9FCA62BA3EF1E759E2519E5748779B354FA75F2BDD5DA7659FE6ABC1AB5DF28874B7F6F38C8E50CD4DB2AD649F4283C7179B24F9A883DB286518163BAD9C00A45857B6692B8C328CFD2E3DC4E40A273DBC1C507315615DC3E5A55887888F20639AC69065B8BBA91BBD1DBA36DC70F11DA5BF4F6609835B084A0D19DD42F4F2BE4EAB2C423FE79842F562C4F36CAB941BD38486A8F68012C54184A930D90C328443A4FF0C09AFA16CAAECF2925B4721B33CE5552C59653417BD994549582AFEF8E72AC33AD12D7ACCEAA67A2EF9DE7CF50D13C302824362660754745132C7E20DE5660E21A60412226CF15439E21DE56D6C7B14526542AC37BE750C1963DD5D78B5CA679FB323548079203AB6C5C79279866A205EFD5F0D6EFDDF6921EE930AFFC502F48E649DDEF9244115202CCF5422465EA1EF0118CFEEDE27F44EFEF721EC19DF92BCAC2E123C17F33B1FD3BEE8430FDCC8DE95DE022835971A4DA4ABE1FAE80CD72AC9785ED7E42112E15FC6F1362139A6A96591C7E17DB13D690532576B14D7ED0A1391DF57C00B8DE55DB6C7120E77FFEEF47F480353011D14A911686BECE401BE391545E3E7E212E5A84127E76943C9FC22A953CC79B238C45DF35FB03445151157494E9FFD57588437B2E8CD8A34DB27B90E6DA11128B1497D594A13C4862EC4924BB4470511A8BA7598D6F7D0853059A6B9797BC610939EC686DBCF01FD815C54B4A16E02519F54DB850C355D0134A9EA6179BA348FC38650FA361309D5BC7ED3918940B9C35BC2F102FF929CC4330DE96ADA40B42B5777215E5D6700F50EC81F1DF55A0CC48662FA3613C9D7620DA76313857E3BA447E25253925815A6D60804A4450AA06A07CEF1A44DD5D4442549D5543C0B4ABC49B27A83FB49AA2669237228F763B126B8E3E34A916850C60712ACECC8E6A142E5BCD8AC3F693C754B57CDC3B4FE6348411669C23E190DEFA5143A6075501A6A567D2E890823A7908AED4067928ADA69B2124A0C84A9D2513B2D61908974526A3137AA997255D5C9082482B984A58C95831A1A4A522AA7C64A54F5AD031C81E0A9088045045A6C9D10FB4845AA05E76A4114D8B949D91F6978889059A80F9E746C671810732BEBCC18616E02C1814B31B9FB089486DB6F0FF8985F751EB31A83215B4F61876CAB88D4F1FAD5AB377A5B24071A203B4B42F6B5294223B3B491B44DA79B16A1190880420C0D4F8AADD8273555EA51AA16A09E27558EA5ED29B18C4CA0C6E9B252B1C0089853B43ED3F484C42A0219D3578E37C96369A25EB12244B4431D475128C18E4C6AAAB1D9ACE5D0762261A9E620000E11C8E81AD5D4727E9F23C38E2AD5840889A91449ECC96845A641E5BCD81000D37822192AE721081AB1CE1077498E39C8EA20C155559E26682DE723050FFBD99D2B40F4231F2EC0E57916278CA4418F6595D1E8015457551F32A4AAE039A3AF15492202580114FC5B86D708554F194DF233CF4945393D562785BEF5D4C38A723A026011811E691CF50DB75CAA9597AB42F4D805668F428B0046CBD0A27A6A6CA880B69E4887EAA99888410C2D31A9520B79C85703F5435243A63DF5762C805C8678E071592956A4E554CD0E9C8289BDC7209AB240DBC474AA602A810443CB1D8FA51CD0D8C7016040566B45DB4D251560E0533B8F472966F9C2D7B3A797B9CE9E023E0B4927785662139D97803A16BA33383C8915434BAA455D9654835B8080DC9D9516A6204E9D630C0EAAF556D487E84927396692672AEC545BA8A571C58B2A0D3365431B2C8889246A989930D8C432B25D35686777A084AB2B8D6DA4A6B3AD4D06EFB88D1E89D14D398EC8A4AA5FB36748A9FA0384506F06DA743B461C13353A9F03DAA6A1E8CFF90CA4E93EF65E6ED609E1EAAE3BB98E04153DB8A888A0FA397D3FF652D5864621F7622FADD58049045A23213FC938CC675EA92644617DA5487AA28CD332275FE5DCD81041DF7822352AE7623A0E91E8F0FD0FF2A29F7A9F5A29859A362ADA1CAB47A450158ECBD1AA61D66C2966041380760DB3140AA708B4FCB520492BAE89138E852D11AC0DD12F5B3112F5C2B82D43B7DA79B2A10E16C0447AD5CE4B185C623CDC4055566ECB3EB994FE780355061F6F70F562BDE080908B7CDFA29B202B5D906B3FF51D8766424221B31085EAED9ACA16474DABCB59378DF37514A4EB6CE33C2EFADD088466200DA1BA86729D4286C0C0A143BC812D84A83DBEDCDC8FC192517AFC9DF9D86252C43ED49362B66BB81C7A92FB7CE894E6902561E99E34271E4503F0B843EABA78B82881AB6783C579A6D38A61C456C7020263EA09C5303913F188BF973A509DB1A5CFDEEACA93C74290D693B1F4C6398D568F6403951E13E8B53FB8BAF3FB108D9B04DCC1129A9B7EAC366B3CE39B0F6785ED181E7E609AAFCBC2FC0C53A8A7907EB44ABC33058751FCA32F3421967286369D2EFBA009988E4154B2335EF5C9558F8AF896741E534FCD2264E8752FB93425F6E9E5196EEA2849B5F6CA16105D8A955D0E6AEA8E6065707E06F0A252E3302212AB71ED9E27CDF61FEC69B6FF303BCD0E1D01343BA07DFC342B0EC3864EFA36A169565CBBE9B8C4B820ECF20318C5AB5811BC16ECB315D813A604F659C95015F61145A76A5D9E85C424B7E49F31523424BBE1D60FA8AB72AD18AA45F4AC10518B7CEED1CC8E953D906D1EC08342311B8150894499D7E553B6CB100DD5C951958E0E548D54B43AD6777C26A3ED0CA03E2D630854E8385134474669C1BF6C45D584B4753C268303BE00FB4183B325F8B66D00C683262104129158AE43DF6C7E802ACF45518B1A1374035D8ABABC4C0A474061DFD0F72C3DE42649C55783A8AAAFE1485302E0C8320A1E96CDD2F52D2752103CFCE908C438DAA32A43C6184C5C2DF0084F2A389DDB3988CF29E81288B9CD5A8789B7042EC5E4EE2350DA80B2C976245684E84D411D3A8A93C03E2B03910AFB887621D5BA3C0B73D080B4317EBA545367B2F431553ED3443C4AF46DD63F50AE13E5DA4CC721020D0EBE8626092856842830AE43AD849183F00CA4E5A926C566E9C338FFA826613206310361B76958B7C9D626F593A691361CF6503F76386C08D1251243594C9C95C892E0840A8CAD99A89088C58A8DFD0DC3B289ED035556C6C8A6F57C82648B1D2C4081BA81DA2CF0D83E44C46CC584844024669A52D3F32DBE9E3621A9235989A0633B9FC123B359BF5081001433100085A81434FCEBC23AD3ADDCC689B2664CE8A4424F27EF5479728353AA72D696A15AE52C3D0F0A6E8DDCD2600CD718527DF54D465CEA55A1B7D83D8872A66CC8830311E43644393381D08940B157BBFD01D58DE94E84AF06D1675FC371CB160047DEB1E161D9AC5EDF72221DC1C39F8E4004CAC103B846C56143FEA7A41BB61244355DB98B81900309D00B046F79BB2084B5CD3293FA13690C5A83695DC7A1AE4D4F1C1A4AE8EB28682BD23EC9220250A43591FB5296380B36AB8B9B4CA72B71D4933A8E4355BDC324A10ECD7A32D514B4E5E1ED2AC08549E5286517807634220396E219D1594F261634D1FF9D83DEFABF00CD29001F15DD09E8DBAC7FD7241CFD09CB331987E074F81EB769FEA027E7AC4055EF51B0274B4A2B5FDE9342F403AF7F7AC0BAE32E298AB2A145BF7EADD1455E11B2A8DF9D36D50149144B80DFA1A6075B918C39ED57D6E5807E9628926F3B5A37A4F663910106602A918001756CA1EAA019A18CD7D31290B1C808A34229F1D5D5A10455B2186197D21C1C615766C28E49F70EE1C5159B304AB21A42867E36B41D6F53A5F663910146E7B101E13038D01840746754A97DF7DDCC0E6D026008052625B3694D8034BBF2CA00950C70994CA81238A6CC00850B7320C1E14A6D26BB8B6700CF78576880C3470A9420F1C5A6251C13DAC92B389619A0D08C56101174F9C94C53DC66929227B7FD6E6A4DD34640BDF7693C6CD6A58D290E2F4B5B668032C6ED95808C451630D8F8AA2024B682011E1B23119A203E1EA649DC09E16864C12754B083A706640B818B58A302C655322D431BF7499EFDF6BB19ABEED91F844B5764B93D0C2AAE7297B006A9063594585027F31207244EA6DC02DAF80E0841E429BE33B280D87AEAAB80F52F2A0C807AB76D10A9D187DEB486ADD3B4BC72ED77436B359BD9F217E4AEA3DE56994A36DB2ABDB287A68775ADB05A2FB59228941BA08D767C09D05864DCEB89B50BD8E4C96743DBCEA204CDC9604733835034B769DAB1B102822D93DF2415FEDB54E51DD96576A09C97AA083099639E7C76DAB4272DA68E70826A2B88A7CED138C0D51B6C0EC338D8539A74765541E9AD0B0C14F04078C60FCD62D8F2C5F0889E3C079ADAEAA1A81B41B3633C5BDAC206E64C795C759F37F98438FA760313A7ABAE1E9DA6153475E653AB357460F294276C9FC9EBBA611085E64CAAA51B8C58199E21780C2650C074A825BF0713E223F9863FDB03BC2755D2B0855817E434C0106080029185CE24E1411A6C778CDD04200FB8A6665DC106209968C6640352412EB009C84F66B71DE9440E504B2F47F9CA2AD90C0EC2046B5E71D2DEF10F3625792AF80A6ACCB97AD0048076270D0868DF1EAC6293C73D98B03A27135869E1AA68150EB6A6427119EC697AD58583044C026CBFF3901692D5AD8FEC08090C65650D83ABDA8062C36803B4843DE38C0D8645CD444975D46310AB42D3A2B465EA21CD38095230536816E44A6AE4A5BAD03C686CB10660334E0513CBD52440F95A0611C855568A52D0A06C0236B350EDADCA635E1F48AECAB5340251AA0C4A579539DB040B980FAD8DDD7D4EA8999CCFD805CC09504B3D0EB9323427BDE15E332100A0F927845AFEB50422D4D0703B5711941BD035830E4684F1B769B4D5B2932DD7E0CD540347DE5F9DE8C6CEC29873CFE053CF6B466DB3E8421EFB69638FBFF0DA73BB3ED5BD6200EA33BBDB44C439B0AB72B103B36195B69D1B8C2971BBE5EA5AC154310C7CD3EBA95EC849C0552A86215DB8AC19A813868B23822E496DE0CDCF5362FA69EDE49844AA2A47F584E9985DB42AB2219B98C946C01832274F66A5681247CAFD0A4D8F5C493D0CA92E34292ACF0003A4F97946934E54353156B967A58199B2CF0A93A5767EB0863CFFE4C1D94B8169B34873CA0D4B9FE8941990E0F8A199297D7ED2F9E64848B5A394CC603D8D6D54976393151D5A5F1533C819A535D49F52FB5157761B9052039A385171B4A01B3849A07ABEB4E904A141A9120ACA33653345AA0C82D6F33E9DAC066C8D34D5D7B45EF87E9041A9A907AA9EAA10BB9E2A9B20B4E559651EE4772553EE4176B3837CCDECA0A9A748E704178AA20CD3666EE44A1286899C4C724B4CAD22699B8D15DD24FD0D09DE42D8D3A3097D2ED7184C6CEA7464E2D28309C9F885063D2DB570E6D513C4A457DA29B038CDC995034C44AC139C3AF512302D96799AB8219933353123933C78357365CECC6431FB21666C7C7A623163709C43FDC0A49087A1664C8A5C08000E71B213D3CE40873A6D6A1AFEF0A54A4EC31EE52CA643998D661EBA81D29F288C02DA2C29D2915D9527453002289DCC8D006714C7DACC1B8AD9B1CBD4218DCA98AB43982FDECDDE3065C6DC1CB68BE139875C520EC5BCA9137748C30153770843181E0D18A606CCD4311329491925F45361B3BB6B734F4C9B92689BBC900A0198145DB2040E7D45BA040671F61D88661E14E91166200C3E9C3FB449ABE3FDF3FB2718F19FDD33A1472A1A10F3FA8C48C1E581A1EB03D073A82B43D05B60AF0734AFF6214739D7E869365EA9EA60E8160330409AD725550AB60DCC843E203787BE32243783BD8D054119487B1E82D0867DD679681AC34473A3B20A140DF9692A1F95D9839F793F01C30BAB5C36B56188B9216903118BAE9BFD5B3A93F3A62AEEF05C8F2684B8B8BAE74AE67B1945F05C1BDCB580E634B068C2BA6A2743AE6E331E6544D32993A48C4BEAF424CC5B8795238A2AD55843F05140F354871F9594599B4933050D9D89CD844096C0FCE8425D72235004BB641057BD84D5819991C36ED9508CC0C86F95A11A39846FA1608D0CBAE3D35CCDA86FA1F08C9C351C78C1EB35E4213E203C62387CA088AB1440901FAF71AC52DC3F8BF9F21B2E1BB80E1EB132B49D883414DC8EC77B7C04AD1F3E14CECE3083D3463F98F1B43300065D53E12E865D9B361362A035B30952332124921A693EC4F41ACADE9EDDA5DFD12EE93EBC3DC35552B46F0E497E5D6E515EF705D7C97E9F158FF5D8B2FB7272B7C787AE77A7177F73777AF2639717F5BBD3EF4DB3FFF5ECACA6A0EB57BB2CADCABA7C685EA5E5EE2CD99667BFBC7EFD8F676FDE9CED5A186769CDCEF15B01DBA1A7A6AC924724949217585BF421ABEAE6326992FBA4C6937FB1DD49D5C00866FC140EB3DC77C904299397AD7F88DF5726FFEE7691E2212BB206D5BF67795EBFC23FABE415C1EE15046A9CCC0F787C44F7A64345ECF9176C861BDEA5499E547DC838065F122CEEA2CC0FBBA2FD969087F519A0FAABC17C2A77F715E2C114DD377B28EFEB2621F7812C14D47DB387D211FD051E459FD1990578E8D825EDCA1D47FA01A5DF931E360FF981140D703D50C67C943D60BAD3A1BDEBEAF8A0CDC28750EF614380DF9E09842712F99944E582CC1139C68A9F348AB80F4FA9C059F095BAA96ACEFB16E252A6BD46EFB684A158151FD9AB927962D99F1C38DE3DEC36D5217517010A70B40CD8D1D4E0BEA01C3D948502BFA62B75817881F203FE0A034CDB422769B54BB21C868648910BAC21E2040C6FDB17AFD2D41EE5559A4AD2D4C6BEE123568D702DE4AB050CD572484DC5E5DEE30A1B4FB11B588A0FB84238B6760B37802B9BAF6CAE62F3D0EC3D85AD3DD839148BB48F204568BBF669A423FB76CE38126ABD038F1BB8DBE4AFF8044E8EE2390FAF22059BBA2B71509BC41C3F9CD6840B37BE93F8A9D7E1262A76708A4A4EDB29538C5B7FA33449BB95B5DA01B8EBAC5EE4C4B70601339AF6250E9285CB9EC8091552B279A237466E431FBD3A14EB4E1D3EDC60B2B9997985B4BB2C76447150DB0329F3939578EAFD5D7E15517256E05B3897650DC0C134E7C42137C9635624FF8EEE0511433F6FFE42BEBBB2EDE5788058CF15ABC2115AE1D078ACF8E81B2A7016EA86BA692411778157E7513ABEAB822BAAE184B1A8DEF411E72055AA0D45B79E365C505E991F607E29B86A283160026C2510CC408C5639593674054B1FFEB5BB7B2B2E364FD0937B35C82E19107DA8CF9D4898EF0E449DD5A978B679E8BE2DA686AE426C156280C9441526D7D76402C2B3349928DA46DBE721356680155F8F61C3094B42800D35BC0A0217945741206B33FA38E25E7A8C06A48D06A36D1E9963C0E38D3628B81A56A0234E92D592D423F1D95751E082F22A0A649D80A40108A40E00A06C3401B0D9CC9C006EFD604604358CD51F6CE5C9597852F324CC872F55E02C7853DD5435E77D0B7129EBFECD99E38ED53E5913A1A1EE25DBA2173D81B4FE80B71601AF9E923DE618FA368EBB7C1A3FAF12CE16E555C2C91EE4FDFBE530124EF1A4DC42C0295BAA66BC6B20F9A8766FADDD962FB0B07CC902092F5CFAFB9D80534D3E6EEAF566D701E5551A49D248F572D1471481B02C0491A29D6AAADBF8DCC2F295F445E4F4835009E7B95203B172484A9D188C09DCC3A1A68AE7A38325A75A029D875A24771E1E4903B220DC01671F76EA1EB3CA7CE4BC48438A25D81B6B4F922F2DE972C804B7041C0F6978553FB59F890029E18AEAD6659A4487747CA9125211E8805DE28D282BA405EA616E71B123E03EFA8F08F2A98F0AE4EC27DE2677031CC5BBAC6FCBFBF3F52FC4458859FF72DC830DB1A4AED063023122EA8B5C4E577DE011FE70A50A47A2867477B8FF5236E2E5737DB8DF34ED6797EBA73A3DC8E27B3B7E765F0278019C08840CA38FA1CAD10729D8ECBB124780EF7F602155497A600B1391426790574582E9417AC3452166B46C4117ECE03E199FEF6B543D411B345BE020008B432E2D47D27F5CB57B5B9457ED1E7A5DDBE72D0DA3E20F00FD1ED8AADA46DB73B5DAFA76FC1CC2F0E076A14211FB98A58067163945E443C912168855B4ACA245F4A39053FE06F2A63002B6F1A9B000B2C89119B239B0E0D64BD895B719B0CBF0F698B73A0C4B2BE15970B2A66D3C6B0FC4B523B09567579E65C02EC3B36C4E98305CAB8168C1B7DAD671CD9510F7B2E0E2F36F0B650CE82FEBFB6986AA0A6D92DC492358E5C22A17A00B3E55EA29EF5B3E10A0ED559FA2B1F6BE8FB691AF5B9E08876C6A9AD66AC13B0C3605A708F19E2488ADFB1CA72FFD6AA837EF9F170DC14E7CC08F4B37895B6C866F495E561D38E12287947881FB8A493B51C03BE0322F80F09047A0AE98F65379553CE2E515E3999199C49CE6140C81A20A826BB17485D763889913FF0110AC4981338610B816416778D7988ACB2EAF9D7051DB941B30778279B8B788DAF981F156B464DDB1ED515E776C69C736E4E8F6D9B375202D766D7DF3D89B22A4CE73F05C807DCC0A39EA664E3E7A61359A1B85EB0A52E86ADF23B7D255B607FC11D90217F9D5A0C7B2921F91A67DC1724E307C5E78D0E08AC6B4F10BDF005387CC6BCC6B3B810C5BA7CC5D57E20A30F9A102D895386C2BC35C89018B8602B785DEA25CDA42DB6F0E50922A95A9857CF42016225D4032A1A260C1B3005605B18E704D9C33A4C11E68D966470B9DA998F803C19A6BE72B74180A5DC1D2506520CCA7B66439F708FC33455BE05A74CF16AC1A972DCAABC625BB49F4FB5F282F09153C1B2F0975DB68FB3AA4610DB0D6DB8E956319B0CB702C55DB43393551601EACAA68E774D4F878F5E9FDF9E6EA722A577DFA7CFDDBEDFB95ABEC515EB94ABE4324BA78A8DB430896CDBD21DCCEE94C717D7E7BE1CA54D09E47E1AC9CB97226037621CEA43695501B5E0BCD8739150D231888C04BFC169DE80AE95DB6BB2F457B48DD7F5C19DD16E595D1E1EBFAAB06ED42DED643F06C2FEBE1B6DABB7AD244F13E1797B8BEB609F5DA77B6EB88600FDA6E505D7E42A237D01E7FDD14C8ED550201F55B750061DDB7DF97BE32075EF7B6D09C5FF75270F8DBAEAC25466F41EE49A13348957F560B7357AE17BD0E28AFB25E92F5FD35462051AF026721E9D54D635DC1AC96C295C96663B2F1363420ABA9815A329C0EC012D7E42B0BAE2C380B0BB237E2A14C182C4C0FFED3378F7DB50FD9363878F1D9F81CD74F9EB2A43954C2B57B824B8682552ED8A2BCCA0539FE32E7DD1E2A12B316A885683001501FB9E7F3D50F1C2CB1435585A31BB095B157C686193B2C47FBB3B2330F87618C5E20FCE7415EBA0EE2AA9EAFDCCA805D945B6986D33C69B2A7C08CAB016CCFC35A20060E64DAAA383B25555CBD9093FB5C3E82938F47F4CA8F9D37E1490253B0CA0F5B9457F9215BD808C98732AC41B06CEC6970BBD959170CE7437189BEB3D3A827E255D543FF71E5705B94570E8734041A79339C5E0082B3D306144D359B6BC868A236E1BEDD79BF8698DF297EE0F91EE579B615F3D327E3674732FD840914BAFC6E89B4489C461930390BCA0FF8ABA0CBF41F1DF52251CAED92CCE941F82A2A5751A9C85FD5CD50E034561324A71984C9F8A892A48311D253A486376E8614F82B8FAF3C2EDE6706E56D05349B4B4C554BC392AA9671513EFB5AA38AFC0B442DCC69CA4909BA49EAFA2F65250E6EF8EA0EE95F93FA3B0C6DF39D16AD42C916E55528817E4E9FF77D86A040D6181D4C1BAB8CBEBDF2B4305B5A2165F4E501E07A23B3F2320376395E1E9DCF51289F291EAC273FEB00E8187A6C0772F46E280EC5D23BC67B7FE5E995A707B0CBF1741B6B27243BB7103D5959D558C7C6A11396ADFCB6F2DB2CFCD667FF0BB67BF6003D984DDD5435EB817317B6B71637799202A985F6ED678703AD0CC719C6455960FE94837AA5CCF795FF6D515EF95F36C4A32A0B9509018465637387DB290DE1A4BA6405271F978C67386B3AA45630B5F32409A6BAFDEC0AAD0DCB2441CBDBCFF6D0AE1E9FC4A4EBD9E39363CAF5CE2B437161DCB967B85E1A870EB1B88ACF557C0AE233ECA30CFFD718CECF30145E947EDE93B7C95FCBE2AE94033A57A460537725AE12EAF6904AF2097FDE54070FDF91A967A7CB0C9FDB64CADC8E9F97F0F378DFFA624C72CFC0027CAAF8BE45525CDC0A3906C4FD588AF6A9BC744B1A767B6892FFD88924883F6E7EEC9C668400BAD93E0080F6E4AB1BA00BF1728C024AB74E7E3804D0870CEF8200A887F6BBD3A1A2A9921A1510C874287407DC6F6D80D3D0B0AD75652E5A5A96D410C8841478008460F940E9E7098637CCA23B68127E075577BB662FE9B8F8FBA6A6050EE7D003FE51CAE0F6F4BB33B83BF478A8683A935ACC29DF976CEADA89DF3ABAB93B144903934DDD16F92C0F0095591D67C0AB12B82A81AA1CBF575BD485B30AA30F9A015BA88636408C87DAA1ADB8E4E43C9BF58501EEA43878AB857CE56E06EC82597E69E2875026F211A26FA25F4563AD7585B611D7F4C3E7DBEBF3CDB7F79FBE840804CC409BCABA6B38E09575E572AFCBE42E7951D0EB64054CEB1B65657BFDA5B222415377AFEC97A549E91932005CB7E1959719B0CBF0F2D50E9F576BD99DCA938D55E02C3858DD546961EB5A884B9975DF033883ACFBE5CA6372B96BF87C541C42C5CE074059F016DC4C35CFA4B6B87418EC6111E7AAF34ABC4E4D2AB79BD4AF9560503B54CE66EBAB5DF228C68BCEBA6FF690C8C4DE24DB0A48798D67774F4A7CE2930BB7B0AE01ACDD24D6423C745BE664F6429D153B701EACA46CA9249FB681B8E455996F3C980A438320B90109C4E02DE15C7C47E9EF10F56CD2B6C4E1AE0AA572C4C7BCFFE882585A653224347E76903FC52197D823E93F1E137F04E40D3FBE70E289E9540C9DB03094F85BD4E72AC31BC12D7ACCEAA692B4D192966EAAAE78D607C0CB115FA7FD05A441FF97A9BAC61A8A54BC4F2584E9F74635E883572796592A524B52E1BF98C8EF4810F05DB0A0AA06B016246106A1BCE6155A4A0F8E49F9A66E0B0348300E5E7C5946538F5C2458851436CF36ED48DA953802A48E47590A663229863247A0F43808417C680BD633BB2DCA3FF399FDBCA67E740D464D159B7273C3076576093F29B5B58C128B45E556944420C4CD97A47A440D20136171A68DF62880962B8BEB436677C0D37B0877E5A14A211777DD1054912A21FA54A3F9F60C2400671A11A6CC8946A4B66E41C1D5F32C00F62315058D6C98E230542162EB451513C2986AB1BE288B6D4608E0E4AAFE74C8732CBA92BC468E533399DAF8B7CC1B3EC481C7336C1182530C05602975D01D1754FF6C1BE888AF3C9126B50371E3A3A90125A6D3A5E36499A9B4DF54893B609215A812AB0CBB76F765F85DF71F08A5258F08AB0628AFC77677E977ACF7D299ABF749DA2AC9E84356D50D21DFFBA4466D95D313726F9B6D51F5EEF4EE0FA22D77AFA5FE677E9193818D15AE93227BC0FADC97F27754BC3BFDE5F59B5F4E4FA8FF2B71BBCC1F4E4F7EECF2A2FE353DD44DB94B8AA26CE8D0DF9D7E6F9AFDAF676735EDB17EB5CBD2AAACCB87E6555AEECEB07A788661FDEDD99B376768BB3B139B7760ADA0BCFEC71E4A5D6F39430A7366622DE2FC82FD1B9208A327985BF47032DACD01027B7B26B67E2B10F0D09020F1EE3423734B05C5BF20BCF44983B63749D3A00A4F58EBD0D6FC717A428831B9CFD1409067DA3EFA934ADB45F194545831ACFEDB2EF9F1DF9D61F5AA3B0FEBF4E43AF9F111158FCDF777A76F9C8182EA3B33218EE0449DBD85B4C593D964240C9527769C960E62D754074BE446AD5C8D9C0C8DD5C7B5644C65472ADEF7DA9172DAB5F52267AEF18C240DB18D28237EBD2AB6E8C7BBD3FF45DBFC7A72F51F9BAED99F4EC8DD4EF5EBC9EB93FFEDCE4D875DFB9C27043B0DE1CB0CC06C286B7C8C1302B321F26A10A9D13EF009018A79BDB4CAB39F459E0D6E6453041B710EDB4C926E328419459CAA1F0B31C7349D24EA78FF3C371CD8B693905839F45971A82F67AAFC40EDB812A4D2D01CB92B0BB4F5513B86862A46B059C63D1B7DD59117C7A69358917F1B1D62FB05DC80DD86260198A6DB0554C7E467466E2313DB4F565A078061B44D32F129B506988F9656628ABCF8D83C91271F1EB3C5B79EC26762C4332F7AEC5A4FC1634B5C1A32AFFD9F693A896A54270A6EF3FDE5B5EBC814478B8950C1330607F3EF5FFB1D5C3634CB864EFFF8C51DF23E79CC8A64F31774AF07FD6777D0F64724AB795DF5AF67A07F5D762CEFA37E7192C655FB5289A9D0CA57DF4F48BB4B185844FBC8485C3BCF5352DF763D25FD045CDA49E649C7A541BE7B322CDB7A468E55AAF55EBCBA79CA9230FC5AA10754A136106508780F599D5A9C879E89CEB70A92E720486EFA7DC3D7DC326E583EE61670BB9B437E64E1D834E496BF45FBA46A121A67C48757F9E62BBFBE787EBD6456DC6BCB1709CE79D7D7506C70559D1D6C4CDEB532A32659EDA3A8B7CD56567DF1AC7A8357DA6B57ED09CB7943052832F85E4A0615827D0272E2CA0ECF811DFA1C9E3E2CA1C9F369660BAEF18CACC1BA2DBBED0963CB49DBC2111CFA82EAC641ADCFD64E4D56170FC91EF3318DD2B7CAAF9F447E751913BC9C7A9559152CFC7A99B6330A2F9590B4901D4CD355769881E1F94C7FA731C66DF97D95212F4586B491603C24088D17E3253FC696334A8F2E9C4D90137AE76092063AF1931F4938375F29918D8757C7D87C9A5385FC2AC9031916C024745A06E228C19BB55B279C7DF2E8A3CB728DA738CE2CEEA627BD8674F6D613204C5AE01DAA5B8760DCC46752F8E69350512845360F3786964110D8E27D77DABEC3A5EB731B0BD3740AA1E145D91ED2C6CB6B926DFB127CE5B8A8946E48304DA760D08A51BC0F57E8D1510D81CEA97D30F90E0E9EA21DB962A6395A6BFA7C92BCB3244F6271F1DF791C1BEE370D9E935CDBC33F0C3DFCE2710750A707F60220780FFDC2CDD6019D202C8DB7D976EE4ED00FBCF5CCDC475624984867EB64BFBC7BBAD2E124D073151BD6E5F2F40538762645170D2FE809713D763E8763E745BF4B7B3EE365D403D7E3A752B9087E573CA6CF0C763B15E8A68B66164DED1CC5A29BA3560E7E0E1C2C67D8F5616543165E3337EBAC1FA1199AEDEBF81CB756B6790E6C4393FFDC248F5EAE528211CA9557D436ACD09C32F6B4F2C9CA273E7C728DEA8BCE34E7C3299265D0955774A6C5E08FAF99BE8ECD9389A88A6986AA0A1143E5AADFFD340C482F06EF925C8C316AC97FE513A1974D4D00F831A00461460E5CDC7A7F9F6118C4BC92F9D99BC5F6D38C4DEB3D8F121562BFDE2463A081E0C6C63616F5FC3D1C8A2C4617B38E842E46563C56330F64D62EE820B094CBF47722D347316F1FBB923CBFA867BC77A11385C5099672B3F5B1EA26CF4137F90DEF7677DD66E7A39DC8BBADAB76A2DDAF436B275C67610EC17956784599ECDB4DDB4369FE8A7056B42DCDD0B40F763195E2657B2C2BAFA8076CDB693ACF6CAE3EF6B64EF483E413F18CFF204378F637A0ADA3EC2E2BB29DFEDA7C920343DB49F263CE4EC675995121D8A23CCC8DD00EB7F56285AEDD744EA022D89307BAB673B897B94D23D6C749BCB51D71FBF0994EB1FD447EA6CE51E48C40536ECD45E95D3F347C9A4F274B7846607995A26DB8EBD955AB7D0E5AED45AF3A78F944703A8BB34F844AE3091EF97718E37A2FB4328907937C2407101F06F978F5E9FDF9E6EAD29D39C6963332469F317EA5E49F8592AF8972EA43C9D7E7B7177E943CB69C91926927610879658A9F8E29A8F1C2EFC671B097B85F3542A6967942AC1F9FDE5367BBFBD2E2A0BE72D98BE1327AB77FD5A0DD8487BFB8F594D7BF7DF319190E7C676C61E6E8DBBD9C0BFDD91F5DED515D6E0A34E38B25DAC37D7598B18B68F7E2FC8BE479FAD857A5C17C3CBD8F5DB95EC4FEDC1B0949094A2E63BD5DFF07BBBA97DF3F64955F28C3E46A867D4934FD7EBC1EF3A56CE1EED48BBED5F7AF6B1ED595CCA791F9577A99774DEFF27C885CBE4C742571ED75646802E73A3B3627FB04037ACA92E650ADF77D3F0F07DEB44ED2EF5B1F69AFB8BC80A3B62B171A9CBD6345F5F374519F0665E59305F94486D631C4A6FB7BE56C349100D83B7BB972ED14769DC2A67307D3EE463781605755F2A53368B7636DF89FDEECAA02E760F274E5DE8BB2AA508EF17A9AC4C8290133899D470833323579F8E4E5C1DBB57B598FC95266ED57DDE1798A267B630E21612F1BCEC033CE961B88DB6661E939EF9279427EED9EA99586800895246765B6E7C06C375DB03BCF2D758CB1E7B19B8201FA825B49DB48D001CD4761E279257B94E71990CAD92F5B39A595224927D370D80C17706A6D3F031994507B35B5BD58C9D467FA9922A106CBD52451054359C0E016318D866AA811E3A7AE6CFA1CD8F46B8BB2D77554375AAF8B28A6EDBCB6B5A5D9A01B69C8838359E7B09B9CA4AEFF5256DBB0D036DF93FA7B0F1243BCCF8AA4FA633D83BC5C1142BC373EEFFB042B3E077F39878997EF060F624E5300D7DBF1F997AF7C7354367CC220D7E553B6CB68BE64FEA7BB0DDF006E860B38BE0B6F16DF8D487BF3B800636E261FBB3B36079695C79FCBDE48FDB3FDB9864988E3C53170429DD59B7125ED69A4FDAD4B3CE543D85CBE2B57AA5625CB9AC3F4BCCF93348C8360384869596006592395FC54DC7687AACC2B2C774D1AFAD94D87963332D9E2618075D92C3C04069DB430BA22CD1843426F4C40297B7C02B20CFBDD51B5B7CBC16EE34247705AE5D8739063135CAFA7B85C4772B5AE92BF621AA94B9A9B278C59E8B04355B9A90E66A68BAEA71F717E75BBDBE6D822B43246C49BF27E372FC7DC2F6AC3BB159E8726D9FCD885B9AEA7C0F6DB8770C0D26D1897040AEC21C3DB5A28BDBCA9921A1521810E1B1071A10CC31B499E2575488041410D7318102A513450B5A977CD3ECC59EE807F94E1E0D5E8F150D1C772753D30DD7DE6AE5FF4D4521F8AA409BD20E180AEAADA7350D5867483AD3A44829978686DE46895F500BC743719C28C1A1CD7D9F1A95C2BE73C07CEA11907BF5165CF83633E7CBEBD3EDF7C7BFFE98B5FC841B1FD8CDCC2741586BED7F0833F1BAFB437645DB2800997646CAA02CF7B3245B683592E9687DED67BE5956BDCB9E66A87CF20B59F2F46D6B5F56215AEF18C4CB26E043F1B495FA3E2E09777B638F8C5A0ED1B4EB8F1313FE4FBB3FB3BBEA44292F1682ACC432559F334206D8822DB258F48B28B4EC5932ECA3ED9CA4FB41D6F97D8808F0B3D36B626FDDB32F7A5FEAACC37DE1CC035F69F2A02C6FDFEB66D353149A98CBB557252DA2CC0EB964DFA1DA5BFDB13890DE5E62885A2524D034AD3B585079B14871CE0120BC5D385377CF9C297252673837E92DD85E24CEFC5CB2AC3127C53A1C7AC6EAA2388ECE44214131E2E91359EF278496CEF3F670A283689C1869693C45824D16DFF9E3DA9F05F4C8C77240CE7CE2F441B81B1A95B007E8FDB2508339E74B8CEE6B43873ACF8F7CEFA5E1B803A4DF038C35C6DB600A98343967A05CEB6EF859E60A6BEE358CF9147788E3CAFA9BB0D91545D2F1724EF7CDA949BF34ACA5BF5BED89EE0CD03D73A670E5977287F78D57EB83EE44DB6CFB3147745965314379F8B4B94A3069D9CA70DA5CD8BA4263C210B19DC95AAEF1E43AEFFF1238FC3FF9040635187882B4996E417C417B84AF05AC872312BD26C9FE4EC78854AA0F824A74F406A92210D30C5924BB447051180E200277638C015E6D634036FCF18B2D053CB607B1EC80646DE77F9662221096D0E19A07416A2725AE7B49FE089C4250F2E40EF1128EDB277971B06B0B9248A77A621B5A102BBBAE3C728A426E32D602317CF426CF06429967BDB559E4A6CC0E802741F85DA3A0C54976BC74564306DBD48927A6E94749364F506F793544DB2031E00338B886BF2EB473FC491522C821C217305B390111DA6CD62EEC9544E9548CA9570EF34861C62D0A5B22803727C4C5CC6196552C6BEB31B6452F7751E99E4BABE5B768603C8266081FC7B8EA4C1539CCDEA94E38ACEA65039ECB7A14494D3C2EE87299DAC3E396CB0A65E23D0124DD3B8396F9F16AA6D075D39673EE8BF4521A1CFECF526EDBFFB328FED009A0FC522B20F3A27104E3B9CE91D46A019DC7E7BC027CB6A0320CD9B0DDA7AA2DDA0FFCAAFDDEB57AFDE48CBB714058C585A9EB5BB19894605A62E63683ABDBFFC45B943157902B8B921B98F34A77BA905BF2500C52F50BA00C3B45971E9E176143AB3E83502A95107F39BE4B13451D850915B4DE6EB11CB9C114B9B85A1CFD3377B3227D188C1D8670452B84635B583DEE7C8B0FF3035B935E4BEBF40F9C28ECF66557788BC8EECA6341A2D59F41A4BFFBD4BF26DF95C94608AAC4C4BDDE717A50EB7637A1E3A71D2A0C7B2C247398C1C55CCD46A715F95578BC7AF516889A454BEEB72BF7388F005F328D7C358AD34DD616A27D21437B2103D47A0AB8F2420CE468D39B3A21FD9D8397429BB2F2F9E9EDA71DAACE8C7AB4FEFA14786F3D2118D6AB4A0C69454A9855CA2D57845A9FD22D28F5A5F5E92085A646D96E3FAFCF6223E11ECE82A2C47046581B6894963A695781AE83E1DF1B9A943D16A11DA5988A7E4EAFA8BB7EA66DEB75DF817B87B44271F77D17134546470AC08253F96718E884E086E8E114B53014BB61BD5F96C2A4FBFB093B333ABDFE30624A6663BCB710FD1367DC732C95C35686777EC393A3223A8CB54D67E7DA9444647F72C694CAF105B2AB22F8A9CECB55BFAE6382EFDE8BA8CBD079AF521473DC6A0152DA924BBA92A7B4D749A79556553CF11688404F821789B4F5D7D4D6E31C78F2FFEE4350CD56665E94534DD3E62D394A9E74834F5FE07793249DDC5AC1423BE8D44636CD14F4169CC80AD571D8D73BE08D519FB8F407B5F0B121AF29AF85D585892D8DADC2AF3052F9EE2B8E1DAACF78136D8ECDA798E4D6D36BDC7706D4655566ECB2E68BE4139E72BF32A9650F402BD3C84215A29476D938D3AB180BBE61EB0E385E84B6FC53A4A225BC0927524E4666FCD3A369ADBE866300CC1690CEA6D4B08DA8BA5977E7C365D0B7281FF797524D20A1C90DF229BEE5F7C69302CF138514D186A71A15781B11723932FC97D3E50C705C92291E3E227CDC99034E00F84ED176781C2F6065009573CCFC18E226E759EA2B314864A9493ECD1F76272C48652E6DC8C16A79DA3D9A25CC9E968541BC9175FAF4B7B39E41BBC8C16508517F7AFB757828FC3C91E93795D16E6E7617D3D511C741F5FE621BE1D9C25DBB7D318F3DCAEEB312AE9982FDB8E807A96715C5A848A1C6F0417A7A4BB437AA8EA24678411346B47465022D61C2E72E1CB212F696CCF94CAFA0F4A2A1B2A402BFB1351193C518A85AEBBCA8B5099A1F31857725D94D26721C2FAC0D5DC6560FFEDE5082C303EB75F9F911C0A3E6334DA10BCFA7B36AEAEE447C094BC40059D1FA195AD87DCDB97C3D4C60DD460EA3712655D974FD92E23212E369A0914486C6C24D1185BE464C8F624DD80C4C3A06EBD8ABB71FA26928F3BF902CB37FE5CCEC44D93E6A1E1E5819690DA8AD26AF79F8FF8251B83A635B1ECDB69892B67B49DC6A507B36120344D2C73C85F8E36DC4EFA47411FDFD0F72C3DE42669D157E31672FC78C4926240D266499EFAD98826240C3DC63888A32A43CF20A60BC5933F6FB75F5E4A24977638D33B8C4033DDEC3C0F9B8D03E93E670B8D0BC52E6F98E9A7E879243A7022E3E71C81DE8972970F40DF3B6A18E510E49711D71D7509127271D808E4A8E144408BBB650C0146DB1C6DC4B1DF222986D4088ECDCA14BFE02B5560B856B2A34CF1B2F7931E376F8645D7B122B57EC3B06CE2858C95E570ADDDE767703267D0B559A80F9F6FAFCF37DFDE7FFA323908951B85B4D15B9FE8DA2C9F7ECCF4B827E8D3E9C85E3DCB3C9676F0EB59FE95F44807C3BF8C79E81C69E24567A25B88C60C8B75BCF4D69A4F259A33188D217A134A5EB012C48FD466A13BE36F68620BD777044ABBDAED0FA86E4CB6E7BE1AB7A2E3C723DEDE06246D5625EB6723DAE666E8310205608CAF5171D890FF699CE17121EF054F3E4411271D825CF7C3B7997CE6C5A950ACDE8E4CDC445AE98732B1BF3894B201B1E5174B5CA8174B26646C36AB5695930DCB2E44A2EE2E0E8DF4FE7ED2F41C0B99403E7EECE717402C2EFE7DC7422F20CE7EAE992F8C765C56F3D0CD665C1AD2F71A9C8EDEE336CD1FF4549715A8EA90B828B7E84356D5CD65D224F7498D245222ADEE50D3DFA05624E140FB95BD97A49FEFD2EF6897BC3BDDDE93C5264FD2DE9D26B444526C79A8E3515A823C1641D0D3A1D4D003706A97BA02EA407D9213C8C6BD635D87EA8EBA624327E3B5A2D4C7580475B11D4A8D3DC839D181BEE44A70AF5D3DABD9EB129982B3D795A966AF2B368D8D4BC42B8F8A2B06C7C3D5300D8966909647433F8303A12506A8E38D9C04792C82A0D743A9A187C1F54066FEBE04E4FFBED000BE3BCF4AC0BBEF10E8B22D32CB963E1D25245CFA328574E98B4D24042436940909A80475DB3019F98C3D3399EFA40E9932A89F31D99BB117EE01B7D40F570AF5C4BE52B6A384EE79374C0E5D21D81396CD98E436755BC5D0151F264EEA8C2F86BAE3A21D9B49714C012593E2580692E2586CE8A4CB092475D07D8780D3A439661A6893C5C8ABDF7E8700D3442C66C05D0601197257002F745B66434C6D2C659896DA32A578D964B4DCD0CB18D255EA642C52B2FA7D6621C6C4889E60476C05657788A964E8940FE92875C917431D725107CD5BA3107144DE24850AE076C9C7CEB0ED54DD9BB61B5BF05CB013554F5C25DDD85252D14C326DCC1F9952DAEF2081B445E63175EF0BA19174450AFCBB524B7546D3935C45A7DE6CACBB1E8EA532B9F72520A5F785167CCC3C4B02D9982957727139D6B1E8917D5F0576C95650F6B9632A5974DABFBD003BEC0B959DEDBB0A868E46677EA99BB108EAE4692835D162EBAE2D1360FB1DA4BAB6C800582DE7B402CE56B0410E5D6A9D94A9041E7158E7233BA5B4F3EF81B5D2AE10EA8A719FB12433F5895428D7109BED517BBCC0933A1B8BA07EB2A1D4A86B13EB3BA06493CFB0764D4A0C5007B3BE04782881601343A72D7C18B612AE0D48B530660B5588DBCAE49BA4C27F9BAABC239AD10ED43CA42AF0511DD7DAD47D15A15BC630279BBE36AD098DA92318C0DA0AA29D90792EC058E630F8FE8364591C5B88A630DAEA4265D83AE3D1B7189A644FDB8CC0E5716A6A071A02D7526910A42080D2C9D3215BC7C64704C07CE8AAAB87255A02E9682E15563EA1A5CAC2D7C1908B034C49E789CF00856642AA35C704C0E30E395C62E3DBF0E644800FA44A1A94195B628B2D602BE4A707B075B653A4B3617AAC2C036EC3586A81D5856B061E82B4D29C55795869D860EC27FA282C2D8B03B58221EDCF141EC3A59694E12D263052BE826613E38DCCED3E065B90B9769CF598B6FA0C1A87DD873698883B6F2F7887E6AA68B72BDE16DDEF57B09939D21065BB741FC711625765650DF929ADE32D2102C58B4CC4602FD78C5FAAA3465432CD536499AF8B0C520AE90A8D52AEA44615B81BA00873DF1719EA785960944D7CAD99041477A9318EF40EBCABF01055FD1DC198C4079256722D8DC0126F2C5A81A5BA8CE0DA42972BB4395F3079D8F46283CF98050C1BA8A5469DBB43A138775F8E60B8F4BA45BBC2420D0DE7B2373A2DCFB65F8E61986C3A7B6890CA74F7FC10B9BBA5768CE0CD512CE92BE46B578FCC66FDBC06177905B5473B7DE2F100839DFF50A7CA9A0D8CD62AC1F6F4B58ABEF128123AABF65A43EAE7392680BD011EC77F05DDED4E19BE525A69D311FB889EC84354A4C535D1B80D5F3B72E822A2ACBFC4D7CA6DB9921A71D16180223D7E3C9221AB12922A066F95BF549A06D9A961988CF74A4F8545A604CE93094C8645424D6E00909B051D005F70045320249A51CA3BB09E4606808E1FAD20108A16D1DAA0E128777975E5281330F35E7F0327BB53CF83362DDE0C9320F8F3B0CDC353C200D848067DCD20888799369F5D4195890CDA12ACB296F1FB01EBB1D46E03904312347CC0C18A9D02AE78262A30CC87B95124D6883A558A0C5236364793D00C62789C5F5C72999160BA50274F12D78FF386EB570D746C8BB7358AF97BB463B43911780F73FED3BE3AC90C306ACB8C348106AFF299A410E4C2F053313E34B1980A55C0356040E0408E6A2AA4741DD0A1409BD223100D08FE52ED2142E105E5772614734A28CE82DAD413D2195072881D8E804CC922E24D9BEC403176BBE408D224C83EBAC32C5C2B1D6F434CA5E7B470E1FA1553A10EE92F21CE7B0B0F58DF806EC011575F8A42AF1FAACD06376DB8F36F7242707560C0BAF0EB1CB2A27B36C5F59BC2F53AD2AAF291C3A1CD4A1D5A3CC86530E751DEEE49A0C3B8FBD0A400D7C0E8F441B003EDC00E533341F5D07A5719423573E8FA7B0D3A4D91C750A550C1C048F5E1843974A113A4CDD171EE616A23DAEADC908C1170F97556BE89B8E33C9198E2452531186C55E595A40DCACA212EBFCFB81B5C93BACFCB3ACA0A314475EEE266E3F2840BA619CFCD9AF098DAE11A0334061A7A7C0779550447A5C26508F608E85CD07408258B12BE105A1018B92EF82087ACF85089E27AA578841489E86FD9B879C0E06E9571F504C3DFF890A9B3F8C92F94B816C2EB27DA68F81662584390377854700C38114511BD6587C4C6248347A58C5A367560901983FD1C72780350ED1015819DFC4C2FB30D9744E2221086284F43D9DBB3F6BD5AF701FF6CCA2A7944D7E516E535FDFAF6ECF6805BEF50FBEB12D5D9E308E22D8659201A086C04DAD7B92A1ECA3EC09580515FA52F1EAE059A649B34C979D5640F78FFC0C529AAEBAC783C3DF996E407AAAADEA3ED55F1F9D0EC0F0D1E32DADDE77FB093418264E9FA7F7B26E1FCF6F39EFCAA430C01A38935C4067D2E7E3B64F976C0FB4392D7C2594E058244DFFA1784BFB76BD954C4B1F68F01D2A7B2B004D44DDF1034EC0BDAED730CACFE5CDC254FC807B7AF35FA881E93F40FFAC4648B2A3510F342F0D3FEF6324B1EAB64577730C6F6F827A6E1EDEEC73FFD7F8F87C9A54B8B0400, N'6.2.0-61023')
SET IDENTITY_INSERT [dbo].[almacen] ON 

INSERT [dbo].[almacen] ([almacen_id], [sucursal_id], [nombre], [direccion], [telefono], [stock_sn], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, 1, N'423423432432', N'AAA', N'AAAA', N'N', N'A', 1, CAST(N'2020-07-28 08:58:59.743' AS DateTime), 1, CAST(N'2020-07-28 08:58:59.743' AS DateTime))
SET IDENTITY_INSERT [dbo].[almacen] OFF
SET IDENTITY_INSERT [dbo].[bien_servicio] ON 

INSERT [dbo].[bien_servicio] ([bien_servicio_id], [bien_servicio], [linea_id], [codigo_com], [descripcion], [categoria_id], [moneda_id], [tipo_existencia_id], [proveedor_id], [stock_minimo], [stock_maximo], [existencia], [modelo], [marca_id], [tipo_bien_id], [almacen_id], [unidad_medida_id], [precio_unitario], [precio_venta], [observacion], [procedencia], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'0001', 1, N'LEN21C', N' LENTE CANON EF 50MM F/1.8 STM LUMINOSO, RETRATOS, BOKEH', 1, 1, 1, 7, CAST(5.0000 AS Decimal(12, 4)), CAST(50.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), NULL, 1, 1, NULL, 1, CAST(200.0000 AS Decimal(12, 4)), CAST(700.0000 AS Decimal(12, 4)), N'AAAAAAAAA', N'', N'A', 1, CAST(N'2020-07-26 13:45:17.903' AS DateTime), 1, CAST(N'2020-07-28 12:43:49.177' AS DateTime))
INSERT [dbo].[bien_servicio] ([bien_servicio_id], [bien_servicio], [linea_id], [codigo_com], [descripcion], [categoria_id], [moneda_id], [tipo_existencia_id], [proveedor_id], [stock_minimo], [stock_maximo], [existencia], [modelo], [marca_id], [tipo_bien_id], [almacen_id], [unidad_medida_id], [precio_unitario], [precio_venta], [observacion], [procedencia], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, N'0001', 1, N'', N'BICICLETA MONTAÑERA TODO TERRENO + REGALO ARO 26 - ALUMINIO ', 1, 1, 1, NULL, CAST(0.0000 AS Decimal(12, 4)), CAST(0.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), NULL, 1, 1, NULL, 1, CAST(0.0000 AS Decimal(12, 4)), NULL, N'AAAAAAAA', N'', N'A', 1, CAST(N'2020-07-26 13:45:40.173' AS DateTime), 1, CAST(N'2020-07-26 13:45:40.173' AS DateTime))
SET IDENTITY_INSERT [dbo].[bien_servicio] OFF
SET IDENTITY_INSERT [dbo].[categoria] ON 

INSERT [dbo].[categoria] ([categoria_id], [categoria], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'CATEGORIA', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[categoria] OFF
SET IDENTITY_INSERT [dbo].[departamento] ON 

INSERT [dbo].[departamento] ([departamento_id], [departamento], [nombre], [pais_id], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'lima', 1, N'a', 1, CAST(N'2002-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[departamento] OFF
SET IDENTITY_INSERT [dbo].[distrito] ON 

INSERT [dbo].[distrito] ([distrito_id], [distrito], [nombre], [provincia_id], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'lima', 1, N'a', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[distrito] OFF
SET IDENTITY_INSERT [dbo].[doc_identidad] ON 

INSERT [dbo].[doc_identidad] ([doc_identidad_id], [doc_identidad], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'DNI', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[doc_identidad] OFF
SET IDENTITY_INSERT [dbo].[empresa] ON 

INSERT [dbo].[empresa] ([empresa_id], [razon_social], [numero_ruc], [nombre], [direccion], [telefono], [email], [igv_sn], [renta], [logo], [ruta_xml], [ruta_pdf], [ruta_cdr], [ruta_firma], [contrasena_firma], [usuario_correo], [alias_correo], [correo], [contrasena_correo], [server_smtp], [puerto_smtp], [seguridad_ssl], [usuario_sunat], [contrasena_sunat], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'DECOR DE CHINA SAC', N'23423423423', N'DECOR DE CHINA SAC', N'AAA', N'AAAA', N'', NULL, CAST(0.00 AS Decimal(18, 2)), 0x, N'', N'', N'', N'', N'', N'', N'', N'', N'123456', N'', N'', 0, N'', N'', N'A', 1, CAST(N'2020-07-28 08:54:47.053' AS DateTime), 1, CAST(N'2020-07-28 08:54:47.053' AS DateTime))
INSERT [dbo].[empresa] ([empresa_id], [razon_social], [numero_ruc], [nombre], [direccion], [telefono], [email], [igv_sn], [renta], [logo], [ruta_xml], [ruta_pdf], [ruta_cdr], [ruta_firma], [contrasena_firma], [usuario_correo], [alias_correo], [correo], [contrasena_correo], [server_smtp], [puerto_smtp], [seguridad_ssl], [usuario_sunat], [contrasena_sunat], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, N'JEDION MELBIN PAUCAR CARDENAS', N'43243243242', N'DECOR DE CHINA SAC', N'AAA', N'4231423432', N'', NULL, CAST(0.00 AS Decimal(18, 2)), 0x, N'', N'', N'', N'', N'', N'', N'', N'', N'123456', N'', N'', 0, N'', N'', N'A', 1, CAST(N'2020-07-28 08:54:58.743' AS DateTime), 1, CAST(N'2020-07-28 08:54:58.743' AS DateTime))
SET IDENTITY_INSERT [dbo].[empresa] OFF
SET IDENTITY_INSERT [dbo].[forma_pago] ON 

INSERT [dbo].[forma_pago] ([forma_pago_id], [forma_pago], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'EFECTIVO', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[forma_pago] ([forma_pago_id], [forma_pago], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, N'02', N'TARJETA', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[forma_pago] OFF
SET IDENTITY_INSERT [dbo].[forma_venta] ON 

INSERT [dbo].[forma_venta] ([FORMA_VENTA_ID], [FORMA_VENTA], [NOMBRE], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'EFECTIVO', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[forma_venta] OFF
SET IDENTITY_INSERT [dbo].[impuesto] ON 

INSERT [dbo].[impuesto] ([impuesto_id], [NOMBRE], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'INCLUYE IGV', N'1', 1, CAST(N'2220-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[impuesto] ([impuesto_id], [NOMBRE], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, N'NO INCLUYE', N'1', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[impuesto] OFF
SET IDENTITY_INSERT [dbo].[linea] ON 

INSERT [dbo].[linea] ([LINEA_ID], [NOMBRE], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'LINEA', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[linea] OFF
SET IDENTITY_INSERT [dbo].[marca] ON 

INSERT [dbo].[marca] ([MARCA_ID], [MARCA], [NOMBRE], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'MARCA', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[marca] OFF
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (1, N'Almacen', N'', NULL, N'glyphicon glyphicon-th-list', NULL, 1, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (2, N'Bien Servicio', N'lg', N'bienservicio/bandeja', N'', 1, 1, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (3, N'Operaciones', N'', NULL, N'glyphicon glyphicon-th-list', NULL, 2, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (4, N'Ventas', N'op', N'pedido/bandeja', N'', 3, 1, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (5, N'Inventario', N'lg', N'inventario/bandeja', N'', 1, 2, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (6, N'Administracion', N'', N'', N'glyphicon glyphicon-th-list', NULL, 3, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (7, N'Maestros', N'', NULL, N'glyphicon glyphicon-th-list', NULL, 4, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (8, N'Categoria', N'mg', N'categoria/bandeja', N'', 7, 1, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (9, N'Ubigeo', N'mg', N'ubigeo/bandeja', N'', 7, 2, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (10, N'Proveedor', N'am', N'proveedor/bandeja', N'', 6, 1, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (11, N'Cliente', N'am', N'cliente/bandeja', N'', 6, 2, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (12, N'Doc. Fiscal', N'mg', N'documentocomercial/bandeja', N'', 7, 3, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (13, N'Forma Venta', N'mg', N'formaventa/bandeja', N'', 7, 4, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (14, N'Marca', N'mg', N'marca/bandeja', N'', 7, 5, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (15, N'Moneda', N'mg', N'moneda/bandeja', N'', 7, 6, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (16, N'Tipo Precio', N'mg', N'tipoprecio/bandeja', N'', 7, 7, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (17, N'Tipo Persona', N'mg', N'tipoproveedor/bandeja', N'', 7, 8, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (18, N'Unidad Medida', N'mg', N'unidadmedida/bandeja', N'', 7, 9, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (19, N'Empresa', N'am', N'empresa/bandeja', N'', 6, 3, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (20, N'Personal', N'am', N'personal/bandeja', N'', 6, 4, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (21, N'Almacen', N'am', N'almacen/bandeja', N'', 6, 6, N'A')
INSERT [dbo].[menu] ([menu_id], [nombre], [area], [url], [imagen], [menu_padre_id], [orden], [estado]) VALUES (22, N'Sucursal', N'am', N'sucursal/bandeja', N'', 6, 5, N'A')
SET IDENTITY_INSERT [dbo].[mes_contable] ON 

INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'ENERO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, N'02', N'FEBRERO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (3, N'03', N'MARZO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (4, N'04', N'ABRIL', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (5, N'05', N'MAYO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (6, N'06', N'JUNIO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (7, N'07', N'JULIO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (8, N'08', N'ENERO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (9, N'09', N'ENERO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (10, N'10', N'ENERO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (11, N'11', N'ENERO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[mes_contable] ([mes_contable_id], [mes_contable], [nombre], [num_cierre_alm], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (12, N'12', N'ENERO', N'1', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[mes_contable] OFF
SET IDENTITY_INSERT [dbo].[moneda] ON 

INSERT [dbo].[moneda] ([moneda_id], [moneda], [nombre], [simbolo], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'DOP', N'Dominican Peso', N' RD$', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[moneda] ([moneda_id], [moneda], [nombre], [simbolo], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, N'USD', N'United States Dollar', N'$', N'A', 1, CAST(N'2020-07-26 12:08:41.193' AS DateTime), 1, CAST(N'2020-07-26 12:08:41.193' AS DateTime))
INSERT [dbo].[moneda] ([moneda_id], [moneda], [nombre], [simbolo], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (3, N'EUR', N'Euro', N'€', N'A', 1, CAST(N'2020-07-26 12:09:10.137' AS DateTime), 1, CAST(N'2020-07-26 12:09:10.137' AS DateTime))
SET IDENTITY_INSERT [dbo].[moneda] OFF
SET IDENTITY_INSERT [dbo].[mov_alm_saldo] ON 

INSERT [dbo].[mov_alm_saldo] ([mov_alm_saldo_id], [almacen_id], [bien_servicio_id], [periodo_empresa_id], [mes_contable_id], [cant_ant], [valor_ant], [valor_unit], [valor_unit_ant], [cant_ingr], [valor_ingr], [cant_salid], [valor_salid], [monto_sal], [cant_reserv], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, 1, 1, 1, 7, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(68.00 AS Decimal(18, 2)), CAST(16000.00 AS Decimal(18, 2)), CAST(9.00 AS Decimal(18, 2)), CAST(4476758.00 AS Decimal(18, 2)), CAST(-13508632.00 AS Decimal(18, 2)), CAST(-8.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 09:07:47.380' AS DateTime), 1, CAST(N'2020-07-28 14:14:33.193' AS DateTime))
INSERT [dbo].[mov_alm_saldo] ([mov_alm_saldo_id], [almacen_id], [bien_servicio_id], [periodo_empresa_id], [mes_contable_id], [cant_ant], [valor_ant], [valor_unit], [valor_unit_ant], [cant_ingr], [valor_ingr], [cant_salid], [valor_salid], [monto_sal], [cant_reserv], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, 1, 2, 1, 7, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(440090.00 AS Decimal(18, 2)), CAST(-447068.00 AS Decimal(18, 2)), CAST(-2.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 09:07:47.447' AS DateTime), 1, CAST(N'2020-07-28 09:57:27.873' AS DateTime))
SET IDENTITY_INSERT [dbo].[mov_alm_saldo] OFF
SET IDENTITY_INSERT [dbo].[orden] ON 

INSERT [dbo].[orden] ([orden_id], [orden], [num_doc_co], [operacion], [tipo_doc_com_id], [tipo_operacion_id], [fecha_orden], [forma_pago_id], [moneda_id], [periodo_empresa_id], [mes_contable_id], [almacen_id], [almacen_dest_id], [vehiculo_id], [conductor_id], [tipo_precio_id], [impuesto_id], [fecha_entrega], [cantidad], [sub_total], [descuento], [impuesto], [total_pedido], [total_exone], [total_inafec], [personal_id], [proveedor_id], [observacion], [anulado], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'0001', N'', N'I', 1, 1, CAST(N'2020-07-28 00:00:00.000' AS DateTime), NULL, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, CAST(2.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'sadsadsadsa', N'A', N'A', 1, CAST(N'2020-07-28 09:07:47.463' AS DateTime), 1, CAST(N'2020-07-28 09:07:47.463' AS DateTime))
INSERT [dbo].[orden] ([orden_id], [orden], [num_doc_co], [operacion], [tipo_doc_com_id], [tipo_operacion_id], [fecha_orden], [forma_pago_id], [moneda_id], [periodo_empresa_id], [mes_contable_id], [almacen_id], [almacen_dest_id], [vehiculo_id], [conductor_id], [tipo_precio_id], [impuesto_id], [fecha_entrega], [cantidad], [sub_total], [descuento], [impuesto], [total_pedido], [total_exone], [total_inafec], [personal_id], [proveedor_id], [observacion], [anulado], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (3, N'0001', N'', N'P', 1, 1, CAST(N'2020-07-28 00:00:00.000' AS DateTime), 1, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, CAST(2.0000 AS Decimal(12, 4)), CAST(84848.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(84848.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 9, N'', N'A', N'A', 1, CAST(N'2020-07-28 09:38:08.210' AS DateTime), 1, CAST(N'2020-07-28 09:38:08.210' AS DateTime))
INSERT [dbo].[orden] ([orden_id], [orden], [num_doc_co], [operacion], [tipo_doc_com_id], [tipo_operacion_id], [fecha_orden], [forma_pago_id], [moneda_id], [periodo_empresa_id], [mes_contable_id], [almacen_id], [almacen_dest_id], [vehiculo_id], [conductor_id], [tipo_precio_id], [impuesto_id], [fecha_entrega], [cantidad], [sub_total], [descuento], [impuesto], [total_pedido], [total_exone], [total_inafec], [personal_id], [proveedor_id], [observacion], [anulado], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (4, N'0001', N'', N'P', 1, 1, CAST(N'2020-07-28 00:00:00.000' AS DateTime), 2, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, CAST(2.0000 AS Decimal(12, 4)), CAST(10016.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(10016.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 10, N'', N'A', N'A', 1, CAST(N'2020-07-28 09:56:51.367' AS DateTime), 1, CAST(N'2020-07-28 09:56:51.367' AS DateTime))
INSERT [dbo].[orden] ([orden_id], [orden], [num_doc_co], [operacion], [tipo_doc_com_id], [tipo_operacion_id], [fecha_orden], [forma_pago_id], [moneda_id], [periodo_empresa_id], [mes_contable_id], [almacen_id], [almacen_dest_id], [vehiculo_id], [conductor_id], [tipo_precio_id], [impuesto_id], [fecha_entrega], [cantidad], [sub_total], [descuento], [impuesto], [total_pedido], [total_exone], [total_inafec], [personal_id], [proveedor_id], [observacion], [anulado], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (5, N'0001', N'', N'P', 1, 1, CAST(N'2020-07-28 00:00:00.000' AS DateTime), 1, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, CAST(2.0000 AS Decimal(12, 4)), CAST(9733512.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(9733512.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 7, N'345324234234', N'A', N'A', 1, CAST(N'2020-07-28 09:57:27.887' AS DateTime), 1, CAST(N'2020-07-28 09:57:27.887' AS DateTime))
INSERT [dbo].[orden] ([orden_id], [orden], [num_doc_co], [operacion], [tipo_doc_com_id], [tipo_operacion_id], [fecha_orden], [forma_pago_id], [moneda_id], [periodo_empresa_id], [mes_contable_id], [almacen_id], [almacen_dest_id], [vehiculo_id], [conductor_id], [tipo_precio_id], [impuesto_id], [fecha_entrega], [cantidad], [sub_total], [descuento], [impuesto], [total_pedido], [total_exone], [total_inafec], [personal_id], [proveedor_id], [observacion], [anulado], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (6, N'0001', N'', N'P', 1, 1, CAST(N'2020-07-28 00:00:00.000' AS DateTime), 1, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 9, N'', N'A', N'A', 1, CAST(N'2020-07-28 09:58:56.347' AS DateTime), 1, CAST(N'2020-07-28 09:58:56.347' AS DateTime))
INSERT [dbo].[orden] ([orden_id], [orden], [num_doc_co], [operacion], [tipo_doc_com_id], [tipo_operacion_id], [fecha_orden], [forma_pago_id], [moneda_id], [periodo_empresa_id], [mes_contable_id], [almacen_id], [almacen_dest_id], [vehiculo_id], [conductor_id], [tipo_precio_id], [impuesto_id], [fecha_entrega], [cantidad], [sub_total], [descuento], [impuesto], [total_pedido], [total_exone], [total_inafec], [personal_id], [proveedor_id], [observacion], [anulado], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (7, N'0001', N'', N'I', 1, 1, CAST(N'2020-07-28 00:00:00.000' AS DateTime), NULL, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, CAST(47.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'', N'A', N'A', 1, CAST(N'2020-07-28 11:46:49.800' AS DateTime), 1, CAST(N'2020-07-28 11:46:49.800' AS DateTime))
INSERT [dbo].[orden] ([orden_id], [orden], [num_doc_co], [operacion], [tipo_doc_com_id], [tipo_operacion_id], [fecha_orden], [forma_pago_id], [moneda_id], [periodo_empresa_id], [mes_contable_id], [almacen_id], [almacen_dest_id], [vehiculo_id], [conductor_id], [tipo_precio_id], [impuesto_id], [fecha_entrega], [cantidad], [sub_total], [descuento], [impuesto], [total_pedido], [total_exone], [total_inafec], [personal_id], [proveedor_id], [observacion], [anulado], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (8, N'0001', N'', N'I', 1, 1, CAST(N'2020-07-28 00:00:00.000' AS DateTime), NULL, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, CAST(20.0000 AS Decimal(12, 4)), CAST(16000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(16000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'', N'A', N'A', 1, CAST(N'2020-07-28 12:02:42.977' AS DateTime), 1, CAST(N'2020-07-28 12:02:42.977' AS DateTime))
INSERT [dbo].[orden] ([orden_id], [orden], [num_doc_co], [operacion], [tipo_doc_com_id], [tipo_operacion_id], [fecha_orden], [forma_pago_id], [moneda_id], [periodo_empresa_id], [mes_contable_id], [almacen_id], [almacen_dest_id], [vehiculo_id], [conductor_id], [tipo_precio_id], [impuesto_id], [fecha_entrega], [cantidad], [sub_total], [descuento], [impuesto], [total_pedido], [total_exone], [total_inafec], [personal_id], [proveedor_id], [observacion], [anulado], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (9, N'0001', N'', N'P', 1, 1, CAST(N'2020-07-28 00:00:00.000' AS DateTime), 1, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, CAST(1.0000 AS Decimal(12, 4)), CAST(800.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(800.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 8, N'', N'A', N'A', 1, CAST(N'2020-07-28 12:42:41.327' AS DateTime), 1, CAST(N'2020-07-28 12:42:41.327' AS DateTime))
INSERT [dbo].[orden] ([orden_id], [orden], [num_doc_co], [operacion], [tipo_doc_com_id], [tipo_operacion_id], [fecha_orden], [forma_pago_id], [moneda_id], [periodo_empresa_id], [mes_contable_id], [almacen_id], [almacen_dest_id], [vehiculo_id], [conductor_id], [tipo_precio_id], [impuesto_id], [fecha_entrega], [cantidad], [sub_total], [descuento], [impuesto], [total_pedido], [total_exone], [total_inafec], [personal_id], [proveedor_id], [observacion], [anulado], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (10, N'0001', N'', N'P', 1, 2, CAST(N'2020-07-28 00:00:00.000' AS DateTime), 1, 1, 1, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL, CAST(5.0000 AS Decimal(12, 4)), CAST(1860.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1860.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 8, N'', N'A', N'A', 1, CAST(N'2020-07-28 14:14:33.297' AS DateTime), 1, CAST(N'2020-07-28 14:14:33.297' AS DateTime))
SET IDENTITY_INSERT [dbo].[orden] OFF
SET IDENTITY_INSERT [dbo].[orden_item] ON 

INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, 1, 1, CAST(1.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 09:07:47.463' AS DateTime), 1, CAST(N'2020-07-28 09:07:47.463' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, 1, 2, CAST(1.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 09:07:47.463' AS DateTime), 1, CAST(N'2020-07-28 09:07:47.463' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (3, 3, 1, CAST(1.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(41212.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 09:38:08.210' AS DateTime), 1, CAST(N'2020-07-28 09:38:08.210' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (4, 3, 2, CAST(1.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1212.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 09:38:08.210' AS DateTime), 1, CAST(N'2020-07-28 09:38:08.210' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (5, 4, 2, CAST(1.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(4554.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 09:56:51.367' AS DateTime), 1, CAST(N'2020-07-28 09:56:51.367' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (6, 4, 1, CAST(1.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(454.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 09:56:51.367' AS DateTime), 1, CAST(N'2020-07-28 09:56:51.367' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (7, 5, 1, CAST(1.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(4432432.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 09:57:27.887' AS DateTime), 1, CAST(N'2020-07-28 09:57:27.887' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (8, 5, 2, CAST(1.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(434324.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 09:57:27.887' AS DateTime), 1, CAST(N'2020-07-28 09:57:27.887' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (9, 7, 1, CAST(47.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 11:46:49.800' AS DateTime), 1, CAST(N'2020-07-28 11:46:49.800' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (10, 8, 1, CAST(20.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(800.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 12:02:42.977' AS DateTime), 1, CAST(N'2020-07-28 12:02:42.977' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (11, 9, 1, CAST(1.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(800.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 12:42:41.327' AS DateTime), 1, CAST(N'2020-07-28 12:42:41.327' AS DateTime))
INSERT [dbo].[orden_item] ([orden_item_id], [orden_id], [bien_servicio_id], [cantidad], [peso_neto], [peso_bruto], [valor_unit], [valor_orden], [valor_promo], [valor_mov], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (12, 10, 1, CAST(5.0000 AS Decimal(12, 4)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(372.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'A', 1, CAST(N'2020-07-28 14:14:33.297' AS DateTime), 1, CAST(N'2020-07-28 14:14:33.297' AS DateTime))
SET IDENTITY_INSERT [dbo].[orden_item] OFF
SET IDENTITY_INSERT [dbo].[pais] ON 

INSERT [dbo].[pais] ([pais_id], [pais], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'Peru', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[pais] OFF
SET IDENTITY_INSERT [dbo].[periodo] ON 

INSERT [dbo].[periodo] ([periodo_id], [periodo], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (6, 2020, N'PERU', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[periodo] OFF
SET IDENTITY_INSERT [dbo].[periodo_empresa] ON 

INSERT [dbo].[periodo_empresa] ([periodo_empresa_id], [sucursal_id], [periodo_id], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, 1, 6, N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[periodo_empresa] OFF
SET IDENTITY_INSERT [dbo].[personal] ON 

INSERT [dbo].[personal] ([personal_id], [num_doc], [nombres], [apellidos], [fecha_nac], [telefono], [celular], [email], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'00000', N'ADMIN', N'ADMIN', CAST(N'2020-02-02 00:00:00.000' AS DateTime), N'000', N'00', N'00', N'A', 1, CAST(N'2019-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[personal] ([personal_id], [num_doc], [nombres], [apellidos], [fecha_nac], [telefono], [celular], [email], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, N'20498143', N'ANTUANNE ', N'HORNA', CAST(N'2020-07-28 00:00:00.000' AS DateTime), N'4231423432', N'32432423', N'432432423', N'A', 1, CAST(N'2020-07-28 08:56:14.973' AS DateTime), 1, CAST(N'2020-07-28 08:56:14.973' AS DateTime))
SET IDENTITY_INSERT [dbo].[personal] OFF
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([proveedor_id], [moneda_id], [personal_id], [razon_social], [tipo_proveedor_id], [nombres], [doc_identidad_id], [num_doc_ident], [tipo_cliente], [forma_venta_id], [tipo_precio_id], [distrito_id], [telefono], [celular], [email], [email_dos], [pagina_web], [direccion], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (7, 1, 1, N'MARIA JOSE', 1, N'MANUELA', 1, N'4545454554', N'1', 1, 1, 1, N'1', N'1', N'1', N'1', N'1', N'A', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), 1, CAST(N'2020-07-28 08:43:40.517' AS DateTime))
INSERT [dbo].[proveedor] ([proveedor_id], [moneda_id], [personal_id], [razon_social], [tipo_proveedor_id], [nombres], [doc_identidad_id], [num_doc_ident], [tipo_cliente], [forma_venta_id], [tipo_precio_id], [distrito_id], [telefono], [celular], [email], [email_dos], [pagina_web], [direccion], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (8, 1, 1, N'DECOR DE CHINA SAC', 1, N'WWWWWW', 1, N'20498143726', N'C', 1, 1, 1, N'', N'', N'WWW', N'WWW', N'WW', N'AV URUBAMBA 513', N'A', 1, CAST(N'2020-07-28 08:42:44.170' AS DateTime), 1, CAST(N'2020-07-28 08:42:44.170' AS DateTime))
INSERT [dbo].[proveedor] ([proveedor_id], [moneda_id], [personal_id], [razon_social], [tipo_proveedor_id], [nombres], [doc_identidad_id], [num_doc_ident], [tipo_cliente], [forma_venta_id], [tipo_precio_id], [distrito_id], [telefono], [celular], [email], [email_dos], [pagina_web], [direccion], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (9, 1, 1, N'JEDION MELBIN PAUCAR CARDENAS', 1, N'WWWWWW', 1, N'3244234234', N'C', 1, 1, 1, N'', N'', N'WWW', N'', N'WWW', N'', N'A', 1, CAST(N'2020-07-28 08:43:27.480' AS DateTime), 1, CAST(N'2020-07-28 08:43:27.480' AS DateTime))
INSERT [dbo].[proveedor] ([proveedor_id], [moneda_id], [personal_id], [razon_social], [tipo_proveedor_id], [nombres], [doc_identidad_id], [num_doc_ident], [tipo_cliente], [forma_venta_id], [tipo_precio_id], [distrito_id], [telefono], [celular], [email], [email_dos], [pagina_web], [direccion], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (10, 1, 1, N'ANTUANEE', 1, N'HORNA', 1, N'15454454', N'C', 1, 1, 1, N'', N'', N'WWW', N'WWW', N'WWW', N'WWW', N'A', 1, CAST(N'2020-07-28 08:44:23.703' AS DateTime), 1, CAST(N'2020-07-28 08:44:23.703' AS DateTime))
INSERT [dbo].[proveedor] ([proveedor_id], [moneda_id], [personal_id], [razon_social], [tipo_proveedor_id], [nombres], [doc_identidad_id], [num_doc_ident], [tipo_cliente], [forma_venta_id], [tipo_precio_id], [distrito_id], [telefono], [celular], [email], [email_dos], [pagina_web], [direccion], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (11, 1, 1, N'CLIENTE', 1, N'CLIENTE', 1, N'0000000000', N'C', 1, 1, 1, N'8093342000', N'', N'', N'', N'', N'', N'A', 1, CAST(N'2020-07-28 14:19:31.173' AS DateTime), 1, CAST(N'2020-07-28 14:19:31.173' AS DateTime))
SET IDENTITY_INSERT [dbo].[proveedor] OFF
SET IDENTITY_INSERT [dbo].[provincia] ON 

INSERT [dbo].[provincia] ([provincia_id], [provincia], [nombre], [departamento_id], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'lima', 1, N'a', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[provincia] OFF
INSERT [dbo].[rol] ([rol_id], [rol], [nombre], [origen_registro_id], [estado]) VALUES (1, N'admin', N'administrrador', 0, N'1')
INSERT [dbo].[rol] ([rol_id], [rol], [nombre], [origen_registro_id], [estado]) VALUES (2, N'user', N'usuario', 0, N'1')
INSERT [dbo].[rol] ([rol_id], [rol], [nombre], [origen_registro_id], [estado]) VALUES (3, N'cajero', N'cajero', 0, N'1')
INSERT [dbo].[rol_menu] ([rol_menu_id], [rol_id], [menu_id], [estado_check], [lectura], [escritura], [anulado]) VALUES (1, 1, 1, N'A', N'1', N'1', N'A')
INSERT [dbo].[rol_usuario] ([rol_usuario_id], [usuario_id], [rol_id]) VALUES (1, 2, 1)
SET IDENTITY_INSERT [dbo].[serie] ON 

INSERT [dbo].[serie] ([serie_id], [almacen_id], [tipo_doc_com_id], [num_serie], [num_linea], [igv_sn], [formato_doc], [observacion], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, 1, 1, N'432432', 4324, N'4', N'3243', N'4342', N'A', 1, CAST(N'2020-07-28 08:59:10.047' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[serie] OFF
SET IDENTITY_INSERT [dbo].[sucursal] ON 

INSERT [dbo].[sucursal] ([sucursal_id], [empresa_id], [distrito_id], [nombre], [direccion], [telefono], [capacidad], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, 1, 1, N'DECOR DE CHINA SAC', N'434324', N'', N'42342343', N'A', 1, CAST(N'2020-07-28 08:58:48.913' AS DateTime), 1, CAST(N'2020-07-28 08:58:48.913' AS DateTime))
SET IDENTITY_INSERT [dbo].[sucursal] OFF
SET IDENTITY_INSERT [dbo].[tipo_bien] ON 

INSERT [dbo].[tipo_bien] ([tipo_bien_id], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'PRODUCTO', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tipo_bien] OFF
SET IDENTITY_INSERT [dbo].[tipo_doc_com] ON 

INSERT [dbo].[tipo_doc_com] ([tipo_doc_com_id], [tipo_doc_com], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'FACTURA', N'1', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[tipo_doc_com] ([tipo_doc_com_id], [tipo_doc_com], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (3, N'02', N'NOTA DE CREDITO', N'1', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tipo_doc_com] OFF
SET IDENTITY_INSERT [dbo].[tipo_existencia] ON 

INSERT [dbo].[tipo_existencia] ([tipo_existencia_id], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'A', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tipo_existencia] OFF
SET IDENTITY_INSERT [dbo].[tipo_movimiento] ON 

INSERT [dbo].[tipo_movimiento] ([tipo_movimiento_id], [tipo_movimiento], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'VENTA', N'1', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[tipo_movimiento] ([tipo_movimiento_id], [tipo_movimiento], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, N'02', N'INVENTARIO', N'1', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[tipo_movimiento] ([tipo_movimiento_id], [tipo_movimiento], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (3, N'03', N'COMPRA', N'1', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tipo_movimiento] OFF
SET IDENTITY_INSERT [dbo].[tipo_operacion] ON 

INSERT [dbo].[tipo_operacion] ([tipo_operacion_id], [tipo_operacion], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica], [TipoMovimiento_TipoMovimientoId]) VALUES (1, N'01', N'TRANSFERENCIA', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), 1, NULL, 2)
INSERT [dbo].[tipo_operacion] ([tipo_operacion_id], [tipo_operacion], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica], [TipoMovimiento_TipoMovimientoId]) VALUES (2, N'02', N'VENTA', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), 1, NULL, 1)
INSERT [dbo].[tipo_operacion] ([tipo_operacion_id], [tipo_operacion], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica], [TipoMovimiento_TipoMovimientoId]) VALUES (3, N'02', N'COMPRA', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), 1, NULL, 3)
SET IDENTITY_INSERT [dbo].[tipo_operacion] OFF
SET IDENTITY_INSERT [dbo].[tipo_precio] ON 

INSERT [dbo].[tipo_precio] ([tipo_precio_id], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'publicpo', N'a', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tipo_precio] OFF
SET IDENTITY_INSERT [dbo].[tipo_proveedor] ON 

INSERT [dbo].[tipo_proveedor] ([tipo_proveedor_id], [tipo_proveedor], [nombre], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'JURIDICA', N'A', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tipo_proveedor] OFF
SET IDENTITY_INSERT [dbo].[unidad_medida] ON 

INSERT [dbo].[unidad_medida] ([unidad_medida_id], [unidad_medida], [nombre], [abreviatura], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (1, N'01', N'UM', N'A', N'1', 2, CAST(N'2020-02-02 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[unidad_medida] OFF
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([usuario_id], [personal_id], [usuario], [nombres], [password], [password_hash], [estado], [usuario_creacion_id], [fecha_creacion], [usuario_modifica_id], [fecha_modifica]) VALUES (2, 1, N'admin', N'ADMIN  PAUCAR CARDENAS', N'YeffNufB/3Qew9oETR9WTA==', 0x5F59D1066AB00B4DA225E71AD9B143C3, N'A', 1, CAST(N'2020-06-22 13:17:09.943' AS DateTime), 1, CAST(N'2020-06-22 13:17:09.943' AS DateTime))
SET IDENTITY_INSERT [dbo].[usuario] OFF
ALTER TABLE [dbo].[almacen]  WITH CHECK ADD  CONSTRAINT [FK_dbo.almacen_dbo.sucursal_sucursal_id] FOREIGN KEY([sucursal_id])
REFERENCES [dbo].[sucursal] ([sucursal_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[almacen] CHECK CONSTRAINT [FK_dbo.almacen_dbo.sucursal_sucursal_id]
GO
ALTER TABLE [dbo].[bien_servicio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.bien_servicio_dbo.categoria_categoria_id] FOREIGN KEY([categoria_id])
REFERENCES [dbo].[categoria] ([categoria_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[bien_servicio] CHECK CONSTRAINT [FK_dbo.bien_servicio_dbo.categoria_categoria_id]
GO
ALTER TABLE [dbo].[bien_servicio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.bien_servicio_dbo.LINEA_linea_id] FOREIGN KEY([linea_id])
REFERENCES [dbo].[linea] ([LINEA_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[bien_servicio] CHECK CONSTRAINT [FK_dbo.bien_servicio_dbo.LINEA_linea_id]
GO
ALTER TABLE [dbo].[bien_servicio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.bien_servicio_dbo.MARCA_marca_id] FOREIGN KEY([marca_id])
REFERENCES [dbo].[marca] ([MARCA_ID])
GO
ALTER TABLE [dbo].[bien_servicio] CHECK CONSTRAINT [FK_dbo.bien_servicio_dbo.MARCA_marca_id]
GO
ALTER TABLE [dbo].[bien_servicio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.bien_servicio_dbo.moneda_moneda_id] FOREIGN KEY([moneda_id])
REFERENCES [dbo].[moneda] ([moneda_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[bien_servicio] CHECK CONSTRAINT [FK_dbo.bien_servicio_dbo.moneda_moneda_id]
GO
ALTER TABLE [dbo].[bien_servicio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.bien_servicio_dbo.proveedor_proveedor_id] FOREIGN KEY([proveedor_id])
REFERENCES [dbo].[proveedor] ([proveedor_id])
GO
ALTER TABLE [dbo].[bien_servicio] CHECK CONSTRAINT [FK_dbo.bien_servicio_dbo.proveedor_proveedor_id]
GO
ALTER TABLE [dbo].[bien_servicio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.bien_servicio_dbo.tipo_bien_tipo_bien_id] FOREIGN KEY([tipo_bien_id])
REFERENCES [dbo].[tipo_bien] ([tipo_bien_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[bien_servicio] CHECK CONSTRAINT [FK_dbo.bien_servicio_dbo.tipo_bien_tipo_bien_id]
GO
ALTER TABLE [dbo].[bien_servicio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.bien_servicio_dbo.tipo_existencia_tipo_existencia_id] FOREIGN KEY([tipo_existencia_id])
REFERENCES [dbo].[tipo_existencia] ([tipo_existencia_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[bien_servicio] CHECK CONSTRAINT [FK_dbo.bien_servicio_dbo.tipo_existencia_tipo_existencia_id]
GO
ALTER TABLE [dbo].[bien_servicio]  WITH CHECK ADD  CONSTRAINT [FK_dbo.bien_servicio_dbo.unidad_medida_unidad_medida_id] FOREIGN KEY([unidad_medida_id])
REFERENCES [dbo].[unidad_medida] ([unidad_medida_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[bien_servicio] CHECK CONSTRAINT [FK_dbo.bien_servicio_dbo.unidad_medida_unidad_medida_id]
GO
ALTER TABLE [dbo].[contacto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.contacto_dbo.area_area_id] FOREIGN KEY([area_id])
REFERENCES [dbo].[area] ([area_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[contacto] CHECK CONSTRAINT [FK_dbo.contacto_dbo.area_area_id]
GO
ALTER TABLE [dbo].[departamento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.departamento_dbo.pais_pais_id] FOREIGN KEY([pais_id])
REFERENCES [dbo].[pais] ([pais_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[departamento] CHECK CONSTRAINT [FK_dbo.departamento_dbo.pais_pais_id]
GO
ALTER TABLE [dbo].[direccion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.direccion_dbo.distrito_distrito_id] FOREIGN KEY([distrito_id])
REFERENCES [dbo].[distrito] ([distrito_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[direccion] CHECK CONSTRAINT [FK_dbo.direccion_dbo.distrito_distrito_id]
GO
ALTER TABLE [dbo].[distrito]  WITH CHECK ADD  CONSTRAINT [FK_dbo.distrito_dbo.provincia_provincia_id] FOREIGN KEY([provincia_id])
REFERENCES [dbo].[provincia] ([provincia_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[distrito] CHECK CONSTRAINT [FK_dbo.distrito_dbo.provincia_provincia_id]
GO
ALTER TABLE [dbo].[mov_alm_saldo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.mov_alm_saldo_dbo.almacen_almacen_id] FOREIGN KEY([almacen_id])
REFERENCES [dbo].[almacen] ([almacen_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[mov_alm_saldo] CHECK CONSTRAINT [FK_dbo.mov_alm_saldo_dbo.almacen_almacen_id]
GO
ALTER TABLE [dbo].[mov_alm_saldo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.mov_alm_saldo_dbo.bien_servicio_bien_servicio_id] FOREIGN KEY([bien_servicio_id])
REFERENCES [dbo].[bien_servicio] ([bien_servicio_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[mov_alm_saldo] CHECK CONSTRAINT [FK_dbo.mov_alm_saldo_dbo.bien_servicio_bien_servicio_id]
GO
ALTER TABLE [dbo].[mov_alm_saldo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.mov_alm_saldo_dbo.mes_contable_mes_contable_id] FOREIGN KEY([mes_contable_id])
REFERENCES [dbo].[mes_contable] ([mes_contable_id])
GO
ALTER TABLE [dbo].[mov_alm_saldo] CHECK CONSTRAINT [FK_dbo.mov_alm_saldo_dbo.mes_contable_mes_contable_id]
GO
ALTER TABLE [dbo].[mov_alm_saldo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.mov_alm_saldo_dbo.periodo_empresa_periodo_empresa_id] FOREIGN KEY([periodo_empresa_id])
REFERENCES [dbo].[periodo_empresa] ([periodo_empresa_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[mov_alm_saldo] CHECK CONSTRAINT [FK_dbo.mov_alm_saldo_dbo.periodo_empresa_periodo_empresa_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.almacen_almacen_id] FOREIGN KEY([almacen_id])
REFERENCES [dbo].[almacen] ([almacen_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.almacen_almacen_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.conductor_conductor_id] FOREIGN KEY([conductor_id])
REFERENCES [dbo].[conductor] ([conductor_id])
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.conductor_conductor_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.forma_pago_forma_pago_id] FOREIGN KEY([forma_pago_id])
REFERENCES [dbo].[forma_pago] ([forma_pago_id])
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.forma_pago_forma_pago_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.impuesto_impuesto_id] FOREIGN KEY([impuesto_id])
REFERENCES [dbo].[impuesto] ([impuesto_id])
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.impuesto_impuesto_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.mes_contable_mes_contable_id] FOREIGN KEY([mes_contable_id])
REFERENCES [dbo].[mes_contable] ([mes_contable_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.mes_contable_mes_contable_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.moneda_moneda_id] FOREIGN KEY([moneda_id])
REFERENCES [dbo].[moneda] ([moneda_id])
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.moneda_moneda_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.periodo_empresa_periodo_empresa_id] FOREIGN KEY([periodo_empresa_id])
REFERENCES [dbo].[periodo_empresa] ([periodo_empresa_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.periodo_empresa_periodo_empresa_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.personal_personal_id] FOREIGN KEY([personal_id])
REFERENCES [dbo].[personal] ([personal_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.personal_personal_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.proveedor_proveedor_id] FOREIGN KEY([proveedor_id])
REFERENCES [dbo].[proveedor] ([proveedor_id])
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.proveedor_proveedor_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.tipo_doc_com_tipo_doc_com_id] FOREIGN KEY([tipo_doc_com_id])
REFERENCES [dbo].[tipo_doc_com] ([tipo_doc_com_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.tipo_doc_com_tipo_doc_com_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.tipo_operacion_tipo_operacion_id] FOREIGN KEY([tipo_operacion_id])
REFERENCES [dbo].[tipo_operacion] ([tipo_operacion_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.tipo_operacion_tipo_operacion_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.tipo_precio_tipo_precio_id] FOREIGN KEY([tipo_precio_id])
REFERENCES [dbo].[tipo_precio] ([tipo_precio_id])
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.tipo_precio_tipo_precio_id]
GO
ALTER TABLE [dbo].[orden]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_dbo.vehiculo_vehiculo_id] FOREIGN KEY([vehiculo_id])
REFERENCES [dbo].[vehiculo] ([vehiculo_id])
GO
ALTER TABLE [dbo].[orden] CHECK CONSTRAINT [FK_dbo.orden_dbo.vehiculo_vehiculo_id]
GO
ALTER TABLE [dbo].[orden_item]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_item_dbo.bien_servicio_bien_servicio_id] FOREIGN KEY([bien_servicio_id])
REFERENCES [dbo].[bien_servicio] ([bien_servicio_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orden_item] CHECK CONSTRAINT [FK_dbo.orden_item_dbo.bien_servicio_bien_servicio_id]
GO
ALTER TABLE [dbo].[orden_item]  WITH CHECK ADD  CONSTRAINT [FK_dbo.orden_item_dbo.orden_orden_id] FOREIGN KEY([orden_id])
REFERENCES [dbo].[orden] ([orden_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orden_item] CHECK CONSTRAINT [FK_dbo.orden_item_dbo.orden_orden_id]
GO
ALTER TABLE [dbo].[periodo_corre]  WITH CHECK ADD  CONSTRAINT [FK_dbo.periodo_corre_dbo.periodo_empresa_periodo_empresa_id] FOREIGN KEY([periodo_empresa_id])
REFERENCES [dbo].[periodo_empresa] ([periodo_empresa_id])
GO
ALTER TABLE [dbo].[periodo_corre] CHECK CONSTRAINT [FK_dbo.periodo_corre_dbo.periodo_empresa_periodo_empresa_id]
GO
ALTER TABLE [dbo].[periodo_corre]  WITH CHECK ADD  CONSTRAINT [FK_dbo.periodo_corre_dbo.tabla_tabla_id] FOREIGN KEY([tabla_id])
REFERENCES [dbo].[tabla] ([tabla_id])
GO
ALTER TABLE [dbo].[periodo_corre] CHECK CONSTRAINT [FK_dbo.periodo_corre_dbo.tabla_tabla_id]
GO
ALTER TABLE [dbo].[prov_contacto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.prov_contacto_dbo.contacto_contacto_id] FOREIGN KEY([contacto_id])
REFERENCES [dbo].[contacto] ([contacto_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[prov_contacto] CHECK CONSTRAINT [FK_dbo.prov_contacto_dbo.contacto_contacto_id]
GO
ALTER TABLE [dbo].[prov_contacto]  WITH CHECK ADD  CONSTRAINT [FK_dbo.prov_contacto_dbo.proveedor_proveedor_id] FOREIGN KEY([proveedor_id])
REFERENCES [dbo].[proveedor] ([proveedor_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[prov_contacto] CHECK CONSTRAINT [FK_dbo.prov_contacto_dbo.proveedor_proveedor_id]
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.proveedor_dbo.distrito_distrito_id] FOREIGN KEY([distrito_id])
REFERENCES [dbo].[distrito] ([distrito_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[proveedor] CHECK CONSTRAINT [FK_dbo.proveedor_dbo.distrito_distrito_id]
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.proveedor_dbo.doc_identidad_doc_identidad_id] FOREIGN KEY([doc_identidad_id])
REFERENCES [dbo].[doc_identidad] ([doc_identidad_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[proveedor] CHECK CONSTRAINT [FK_dbo.proveedor_dbo.doc_identidad_doc_identidad_id]
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.proveedor_dbo.FORMA_VENTA_forma_venta_id] FOREIGN KEY([forma_venta_id])
REFERENCES [dbo].[forma_venta] ([FORMA_VENTA_ID])
GO
ALTER TABLE [dbo].[proveedor] CHECK CONSTRAINT [FK_dbo.proveedor_dbo.FORMA_VENTA_forma_venta_id]
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.proveedor_dbo.moneda_moneda_id] FOREIGN KEY([moneda_id])
REFERENCES [dbo].[moneda] ([moneda_id])
GO
ALTER TABLE [dbo].[proveedor] CHECK CONSTRAINT [FK_dbo.proveedor_dbo.moneda_moneda_id]
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.proveedor_dbo.personal_personal_id] FOREIGN KEY([personal_id])
REFERENCES [dbo].[personal] ([personal_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[proveedor] CHECK CONSTRAINT [FK_dbo.proveedor_dbo.personal_personal_id]
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.proveedor_dbo.tipo_precio_tipo_precio_id] FOREIGN KEY([tipo_precio_id])
REFERENCES [dbo].[tipo_precio] ([tipo_precio_id])
GO
ALTER TABLE [dbo].[proveedor] CHECK CONSTRAINT [FK_dbo.proveedor_dbo.tipo_precio_tipo_precio_id]
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.proveedor_dbo.tipo_proveedor_tipo_proveedor_id] FOREIGN KEY([tipo_proveedor_id])
REFERENCES [dbo].[tipo_proveedor] ([tipo_proveedor_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[proveedor] CHECK CONSTRAINT [FK_dbo.proveedor_dbo.tipo_proveedor_tipo_proveedor_id]
GO
ALTER TABLE [dbo].[provincia]  WITH CHECK ADD  CONSTRAINT [FK_dbo.provincia_dbo.departamento_departamento_id] FOREIGN KEY([departamento_id])
REFERENCES [dbo].[departamento] ([departamento_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[provincia] CHECK CONSTRAINT [FK_dbo.provincia_dbo.departamento_departamento_id]
GO
ALTER TABLE [dbo].[rol_menu]  WITH CHECK ADD  CONSTRAINT [FK_dbo.rol_menu_dbo.menu_menu_id] FOREIGN KEY([menu_id])
REFERENCES [dbo].[menu] ([menu_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[rol_menu] CHECK CONSTRAINT [FK_dbo.rol_menu_dbo.menu_menu_id]
GO
ALTER TABLE [dbo].[rol_menu]  WITH CHECK ADD  CONSTRAINT [FK_dbo.rol_menu_dbo.rol_rol_id] FOREIGN KEY([rol_id])
REFERENCES [dbo].[rol] ([rol_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[rol_menu] CHECK CONSTRAINT [FK_dbo.rol_menu_dbo.rol_rol_id]
GO
ALTER TABLE [dbo].[rol_usuario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.rol_usuario_dbo.rol_rol_id] FOREIGN KEY([rol_id])
REFERENCES [dbo].[rol] ([rol_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[rol_usuario] CHECK CONSTRAINT [FK_dbo.rol_usuario_dbo.rol_rol_id]
GO
ALTER TABLE [dbo].[rol_usuario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.rol_usuario_dbo.usuario_usuario_id] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([usuario_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[rol_usuario] CHECK CONSTRAINT [FK_dbo.rol_usuario_dbo.usuario_usuario_id]
GO
ALTER TABLE [dbo].[serie]  WITH CHECK ADD  CONSTRAINT [FK_dbo.serie_dbo.almacen_almacen_id] FOREIGN KEY([almacen_id])
REFERENCES [dbo].[almacen] ([almacen_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[serie] CHECK CONSTRAINT [FK_dbo.serie_dbo.almacen_almacen_id]
GO
ALTER TABLE [dbo].[sucursal]  WITH CHECK ADD  CONSTRAINT [FK_dbo.sucursal_dbo.distrito_distrito_id] FOREIGN KEY([distrito_id])
REFERENCES [dbo].[distrito] ([distrito_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sucursal] CHECK CONSTRAINT [FK_dbo.sucursal_dbo.distrito_distrito_id]
GO
ALTER TABLE [dbo].[sucursal]  WITH CHECK ADD  CONSTRAINT [FK_dbo.sucursal_dbo.empresa_empresa_id] FOREIGN KEY([empresa_id])
REFERENCES [dbo].[empresa] ([empresa_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sucursal] CHECK CONSTRAINT [FK_dbo.sucursal_dbo.empresa_empresa_id]
GO
ALTER TABLE [dbo].[sucursal_personal]  WITH CHECK ADD  CONSTRAINT [FK_dbo.sucursal_personal_dbo.personal_personal_id] FOREIGN KEY([personal_id])
REFERENCES [dbo].[personal] ([personal_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sucursal_personal] CHECK CONSTRAINT [FK_dbo.sucursal_personal_dbo.personal_personal_id]
GO
ALTER TABLE [dbo].[sucursal_personal]  WITH CHECK ADD  CONSTRAINT [FK_dbo.sucursal_personal_dbo.sucursal_sucursal_id] FOREIGN KEY([sucursal_id])
REFERENCES [dbo].[sucursal] ([sucursal_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sucursal_personal] CHECK CONSTRAINT [FK_dbo.sucursal_personal_dbo.sucursal_sucursal_id]
GO
ALTER TABLE [dbo].[tipo_operacion]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tipo_operacion_dbo.tipo_movimiento_TipoMovimiento_TipoMovimientoId] FOREIGN KEY([TipoMovimiento_TipoMovimientoId])
REFERENCES [dbo].[tipo_movimiento] ([tipo_movimiento_id])
GO
ALTER TABLE [dbo].[tipo_operacion] CHECK CONSTRAINT [FK_dbo.tipo_operacion_dbo.tipo_movimiento_TipoMovimiento_TipoMovimientoId]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.usuario_dbo.personal_personal_id] FOREIGN KEY([personal_id])
REFERENCES [dbo].[personal] ([personal_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_dbo.usuario_dbo.personal_personal_id]
GO
