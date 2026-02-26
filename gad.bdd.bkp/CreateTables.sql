use GadAntonioAnte
go

CREATE TABLE [Log].[SolicitudRespuesta](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[fechaRegistro] [datetime] NOT NULL,
	[secuencial] [bigint] NOT NULL,
	[codigoUsuario] [nvarchar](50) NOT NULL,
	[numeroDocumento] [nvarchar](20) NOT NULL,
	[proveedor] [nvarchar](500) NOT NULL,
	[metodo] [nvarchar](100) NOT NULL,
	[fechaHoraEnvio] [datetime] NOT NULL,
	[tramaEnvio] [nvarchar](max) NOT NULL,
	[fechaHoraRespuesta] [datetime] NOT NULL,
	[tramaRespuesta] [nvarchar](max) NOT NULL,
	[codigo] [nvarchar](50) NOT NULL,
	[mensaje] [nvarchar](500) NOT NULL,
	[exito] [bit] NOT NULL,
 CONSTRAINT [PK_SolicitudRespuesta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [Aplicacion].[Cantones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[provincia] [nvarchar](100) NOT NULL,
	[canton] [nvarchar](100) NOT NULL,
	[seleccionado] [bit] NOT NULL,
 CONSTRAINT [PK__Cantones__3213E83F2F1C2AB3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Aplicacion].[DeclaracionPJ]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Aplicacion].[DeclaracionPJ](
	[ruc] [varchar](20) NOT NULL,
	[aniofiscal] [int] NOT NULL,
	[TotalActivoCorriente470] [decimal](18, 2) NOT NULL,
	[TotActivoNoCorriente1077] [decimal](18, 2) NOT NULL,
	[TotalActivo1080] [decimal](18, 2) NOT NULL,
	[TotPasivosCorrientes1340] [decimal](18, 2) NOT NULL,
	[TotalPasivosLargoPlazo1590] [decimal](18, 2) NOT NULL,
	[TotalPasivosContingente] [decimal](18, 2) NOT NULL,
	[TotalPasivos1620] [decimal](18, 2) NOT NULL,
	[TotalIngresos1930] [decimal](18, 2) NOT NULL,
	[TotasCostosGastos3380] [decimal](18, 2) NOT NULL,
	[UtilidadEjercicio3420] [decimal](18, 2) NOT NULL,
	[ValorUnoPorMil] [decimal](18, 2) NOT NULL,
	[ValorPatente] [decimal](18, 2) NOT NULL,
	[FechaInser] [datetime] NOT NULL,
	[FechaUpdate] [datetime] NULL,
 CONSTRAINT [PK_DeclaracionPJ] PRIMARY KEY CLUSTERED 
(
	[ruc] ASC,
	[aniofiscal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Aplicacion].[DistribucionPago]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Aplicacion].[DistribucionPago](
	[ruc] [varchar](20) NOT NULL,
	[aniofiscal] [int] NOT NULL,
	[id] [int] NOT NULL,
	[pagoaa] [bit] NOT NULL,
	[porcentaje] [decimal](18, 2) NOT NULL,
	[valor] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_DistribucionPago] PRIMARY KEY CLUSTERED 
(
	[ruc] ASC,
	[aniofiscal] ASC,
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Aplicacion].[TarifaImpositiva]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Aplicacion].[TarifaImpositiva](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Desde] [decimal](18, 5) NOT NULL,
	[Hasta] [decimal](18, 5) NOT NULL,
	[Impuesto] [decimal](18, 5) NOT NULL,
	[Excedente] [decimal](18, 5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Aplicacion].[TasaAdministrativa]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Aplicacion].[TasaAdministrativa](
	[concepto] [varchar](25) NOT NULL,
	[valor] [decimal](18, 2) NULL,
 CONSTRAINT [PK_TasaAdministrativa] PRIMARY KEY CLUSTERED 
(
	[concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[actividades_establecimiento]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[actividades_establecimiento](
	[numero_ruc] [varchar](13) NOT NULL,
	[numero_establecimiento] [int] NOT NULL,
	[codigo_actividad] [varchar](20) NOT NULL,
	[actividad_economica] [varchar](max) NULL,
	[fecha_registro] [datetime2](7) NULL,
 CONSTRAINT [PK_actividades_establecimiento] PRIMARY KEY CLUSTERED 
(
	[numero_ruc] ASC,
	[numero_establecimiento] ASC,
	[codigo_actividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[Form101]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[Form101](
	[anioFiscal] [int] NOT NULL,
	[numeroIdentificacion] [varchar](20) NOT NULL,
	[razonSocial] [varchar](200) NULL,
	[perdidaEjercicio3430] [decimal](18, 6) NULL,
	[totActivoNoCorriente1077] [decimal](18, 6) NULL,
	[totPasivosCorrientes1340] [decimal](18, 6) NULL,
	[totalActivo1080] [decimal](18, 6) NULL,
	[totalActivoCorriente470] [decimal](18, 6) NULL,
	[totalIngresos1930] [decimal](18, 6) NULL,
	[totalPasivos1620] [decimal](18, 6) NULL,
	[totalPatrimonioNeto1780] [decimal](18, 6) NULL,
	[totasCostosGastos3380] [decimal](18, 6) NULL,
	[utilidadEjercicio3420] [decimal](18, 6) NULL,
	[totalPasivosLargoPlazo1590] [decimal](18, 6) NULL,
	[proNoctePasCtgComNeg1577] [decimal](18, 6) NULL,
	[fechaInsert] [datetime] NOT NULL,
	[fechaModificado] [datetime] NULL,
 CONSTRAINT [PK_Form101] PRIMARY KEY CLUSTERED 
(
	[anioFiscal] ASC,
	[numeroIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[Form101bkp]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[Form101bkp](
	[anioFiscal] [int] NOT NULL,
	[numeroIdentificacion] [varchar](20) NOT NULL,
	[razonSocial] [varchar](200) NULL,
	[perdidaEjercicio3430] [decimal](18, 6) NULL,
	[totActivoNoCorriente1077] [decimal](18, 6) NULL,
	[totPasivosCorrientes1340] [decimal](18, 6) NULL,
	[totalActivo1080] [decimal](18, 6) NULL,
	[totalActivoCorriente470] [decimal](18, 6) NULL,
	[totalIngresos1930] [decimal](18, 6) NULL,
	[totalPasivos1620] [decimal](18, 6) NULL,
	[totalPatrimonioNeto1780] [decimal](18, 6) NULL,
	[totasCostosGastos3380] [decimal](18, 6) NULL,
	[utilidadEjercicio3420] [decimal](18, 6) NULL,
	[totalPasivosLargoPlazo1590] [decimal](18, 6) NULL,
	[proNoctePasCtgComNeg1577] [decimal](18, 6) NULL,
	[fechaInsert] [datetime] NOT NULL,
 CONSTRAINT [PK_Form101bkp] PRIMARY KEY CLUSTERED 
(
	[anioFiscal] ASC,
	[numeroIdentificacion] ASC,
	[fechaInsert] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[Form102]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[Form102](
	[AnioFiscal] [int] NOT NULL,
	[NumeroIdentificacion] [varchar](20) NOT NULL,
	[RazonSocial] [varchar](150) NOT NULL,
	[SustitutivaOriginal] [varchar](50) NULL,
	[AvaluoArriendoInmuebles3030] [decimal](18, 6) NULL,
	[AvaArriendoOtrosAct3070] [decimal](18, 6) NULL,
	[DepreciacionAcumulada530] [decimal](18, 6) NULL,
	[EcoSoftware480] [decimal](18, 6) NULL,
	[IngresosLepOli3120] [decimal](18, 6) NULL,
	[InmueblesExceptoTerrenos420] [decimal](18, 6) NULL,
	[MaqEquInstalaciones450] [decimal](18, 6) NULL,
	[MueblesEnseres440] [decimal](18, 6) NULL,
	[PerdidaEjercicio2810] [decimal](18, 6) NULL,
	[RebajaDiscapacidad3350] [decimal](18, 6) NULL,
	[RebajaTerceraEdad3340] [decimal](18, 6) NULL,
	[SubIngRgrTyc3195] [decimal](18, 6) NULL,
	[SubIngRgrTycSrd3200] [decimal](18, 6) NULL,
	[Terrenos540] [decimal](18, 6) NULL,
	[TotActCorriente410] [decimal](18, 6) NULL,
	[TotActivoNoCorriente812] [decimal](18, 6) NULL,
	[TotPasivoCorriente1030] [decimal](18, 6) NULL,
	[TotPatrimonioNeto1330] [decimal](18, 6) NULL,
	[TotalActivo830] [decimal](18, 6) NULL,
	[TotalActivoFijo560] [decimal](18, 6) NULL,
	[TotalCostosGastos2760] [decimal](18, 6) NULL,
	[TotalIngresos1440] [decimal](18, 6) NULL,
	[TotalPasivo1310] [decimal](18, 6) NULL,
	[UtilidadNetaEjercicio2800] [decimal](18, 6) NULL,
	[VehiculosEqtEqc490] [decimal](18, 6) NULL,
	[VneGrvTce1360] [decimal](18, 6) NULL,
	[IngresosAemRie1280] [decimal](18, 6) NULL,
	[IngSyoTrabajoRde3240] [decimal](18, 6) NULL,
	[CdoCliRelExterior190] [decimal](18, 6) NULL,
	[FechaInsercion] [datetime] NOT NULL,
	[FechaActualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AnioFiscal] ASC,
	[NumeroIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[form102bkp]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[form102bkp](
	[AnioFiscal] [int] NOT NULL,
	[NumeroIdentificacion] [varchar](20) NOT NULL,
	[RazonSocial] [varchar](150) NOT NULL,
	[SustitutivaOriginal] [varchar](50) NULL,
	[AvaluoArriendoInmuebles3030] [decimal](18, 6) NULL,
	[AvaArriendoOtrosAct3070] [decimal](18, 6) NULL,
	[DepreciacionAcumulada530] [decimal](18, 6) NULL,
	[EcoSoftware480] [decimal](18, 6) NULL,
	[IngresosLepOli3120] [decimal](18, 6) NULL,
	[InmueblesExceptoTerrenos420] [decimal](18, 6) NULL,
	[MaqEquInstalaciones450] [decimal](18, 6) NULL,
	[MueblesEnseres440] [decimal](18, 6) NULL,
	[PerdidaEjercicio2810] [decimal](18, 6) NULL,
	[RebajaDiscapacidad3350] [decimal](18, 6) NULL,
	[RebajaTerceraEdad3340] [decimal](18, 6) NULL,
	[SubIngRgrTyc3195] [decimal](18, 6) NULL,
	[SubIngRgrTycSrd3200] [decimal](18, 6) NULL,
	[Terrenos540] [decimal](18, 6) NULL,
	[TotActCorriente410] [decimal](18, 6) NULL,
	[TotActivoNoCorriente812] [decimal](18, 6) NULL,
	[TotPasivoCorriente1030] [decimal](18, 6) NULL,
	[TotPatrimonioNeto1330] [decimal](18, 6) NULL,
	[TotalActivo830] [decimal](18, 6) NULL,
	[TotalActivoFijo560] [decimal](18, 6) NULL,
	[TotalCostosGastos2760] [decimal](18, 6) NULL,
	[TotalIngresos1440] [decimal](18, 6) NULL,
	[TotalPasivo1310] [decimal](18, 6) NULL,
	[UtilidadNetaEjercicio2800] [decimal](18, 6) NULL,
	[VehiculosEqtEqc490] [decimal](18, 6) NULL,
	[VneGrvTce1360] [decimal](18, 6) NULL,
	[IngresosAemRie1280] [decimal](18, 6) NULL,
	[IngSyoTrabajoRde3240] [decimal](18, 6) NULL,
	[CdoCliRelExterior190] [decimal](18, 6) NULL,
	[FechaInsercion] [datetime] NOT NULL,
 CONSTRAINT [PK_form102bkp] PRIMARY KEY CLUSTERED 
(
	[AnioFiscal] ASC,
	[NumeroIdentificacion] ASC,
	[FechaInsercion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[SepsOrganizacion]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[SepsOrganizacion](
	[calle] [varchar](200) NULL,
	[canton] [varchar](100) NULL,
	[cedulaRepresentante] [varchar](20) NULL,
	[cedulaSecretario] [varchar](20) NULL,
	[claseOrganizacion] [varchar](100) NULL,
	[codigoError] [int] NULL,
	[codigoRegistroSeps] [varchar](50) NULL,
	[correoOrganizacion] [varchar](150) NULL,
	[error] [varchar](500) NULL,
	[estadoOrganizacion] [varchar](100) NULL,
	[fechaRegistroSeps] [date] NULL,
	[grupoOrganizacion] [varchar](100) NULL,
	[interseccion] [varchar](200) NULL,
	[nombreRepresentanteLegal] [varchar](200) NULL,
	[nombreSecretario] [varchar](200) NULL,
	[numero] [varchar](50) NULL,
	[numeroResolucionSeps] [varchar](100) NULL,
	[parroquia] [varchar](100) NULL,
	[provincia] [varchar](100) NULL,
	[razonSocial] [varchar](300) NULL,
	[referencia] [varchar](200) NULL,
	[ruc] [varchar](13) NOT NULL,
	[telefono] [varchar](50) NULL,
	[tipoOrganizacion] [varchar](100) NULL,
	[fecha_grabado] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SepsOrganizacion] PRIMARY KEY CLUSTERED 
(
	[ruc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[sri_actividad_economica]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[sri_actividad_economica](
	[numeroRuc] [varchar](20) NOT NULL,
	[actividadGeneral] [varchar](500) NULL,
	[codN1Familia] [varchar](10) NULL,
	[codN2Grupo] [varchar](10) NULL,
	[codN3SubGrupo] [varchar](10) NULL,
	[codN4Clase] [varchar](10) NULL,
	[codN5SubClase] [varchar](10) NULL,
	[codN6Actividad] [varchar](10) NULL,
	[n1Familia] [varchar](300) NULL,
	[n2Grupo] [varchar](300) NULL,
	[n3SubGrupo] [varchar](300) NULL,
	[n4Clase] [varchar](300) NULL,
	[n5SubClase] [varchar](300) NULL,
	[n6Actividad] [varchar](500) NULL,
	[fecha_grabado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[numeroRuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[sri_contador]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[sri_contador](
	[numeroRuc] [varchar](20) NOT NULL,
	[cedulaContador] [varchar](20) NULL,
	[nombreContador] [varchar](300) NULL,
	[fecha_grabado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[numeroRuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[sri_contribuyente_datos]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[sri_contribuyente_datos](
	[numeroRuc] [varchar](20) NOT NULL,
	[codClaseContrib] [varchar](10) NULL,
	[codEstado] [varchar](10) NULL,
	[desClaseContrib] [varchar](100) NULL,
	[desEstado] [varchar](50) NULL,
	[direccionCorta] [varchar](500) NULL,
	[email] [varchar](200) NULL,
	[nombreComercial] [varchar](300) NULL,
	[razonSocial] [varchar](300) NULL,
	[telefonoDomicilio] [varchar](50) NULL,
	[telefonoTrabajo] [varchar](50) NULL,
	[calificacionArtesanal] [varchar](50) NULL,
	[direccionLarga] [varchar](500) NULL,
	[fax] [varchar](50) NULL,
	[fechaAltaParaEspecial] [date] NULL,
	[fechaCalificacionArtesanal] [date] NULL,
	[fechaCambioObligado] [date] NULL,
	[fechaInicioActividades] [date] NULL,
	[fechaNacimiento] [date] NULL,
	[fechaNotificacionEspeciales] [date] NULL,
	[fechaUltimaDeclaracion] [date] NULL,
	[numeroCalificacionArtesanal] [varchar](50) NULL,
	[obligadoContabilidad] [varchar](5) NULL,
	[resolucionAltaParaEspecial] [varchar](100) NULL,
	[tipoCalificacionArtesanal] [varchar](200) NULL,
	[ultimoPeriodoFiscalCumplido] [varchar](50) NULL,
	[nombreAgenteRetencion] [varchar](200) NULL,
	[estadoListaBlanca] [varchar](5) NULL,
	[marcaFantasma] [varchar](10) NULL,
	[fecha_grabado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[numeroRuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[sri_estado_tributario]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[sri_estado_tributario](
	[numeroRuc] [varchar](20) NOT NULL,
	[Estado] [nvarchar](5) NULL,
	[Descripcion] [nvarchar](200) NULL,
	[fecha_grabado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[numeroRuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[sri_estructura_organizacional]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[sri_estructura_organizacional](
	[numeroRuc] [varchar](20) NOT NULL,
	[codigoProvincia] [varchar](10) NULL,
	[codigoRegional] [varchar](10) NULL,
	[nombreProvincia] [varchar](200) NULL,
	[nombreRegional] [varchar](200) NULL,
	[fecha_grabado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[numeroRuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[sri_representante_legal]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[sri_representante_legal](
	[numeroRuc] [varchar](20) NOT NULL,
	[cargo] [varchar](200) NULL,
	[identificacion] [varchar](20) NULL,
	[nombre] [varchar](300) NULL,
	[fecha_grabado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[numeroRuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[sri_ruc_establecimientos]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[sri_ruc_establecimientos](
	[calle] [varchar](255) NULL,
	[estadoEstablecimiento] [varchar](50) NULL,
	[interseccion] [varchar](255) NULL,
	[nombreFantasiaComercial] [varchar](255) NULL,
	[numeroEstablecimiento] [varchar](50) NOT NULL,
	[numeroRuc] [varchar](20) NOT NULL,
	[tipoEstablecimiento] [varchar](50) NULL,
	[referenciaUbicacion] [varchar](500) NULL,
	[fechaInicioActividades] [datetime] NULL,
	[fechaReinicioActividades] [datetime] NULL,
	[fechaCierre] [datetime] NULL,
	[verificacionUbicacion] [varchar](5) NULL,
	[ubicacionGeografica] [varchar](50) NULL,
	[barrio] [varchar](255) NULL,
	[ciudadela] [varchar](255) NULL,
	[conjunto] [varchar](255) NULL,
	[bloque] [varchar](50) NULL,
	[nombreEdificio] [varchar](255) NULL,
	[numeroOficina] [varchar](50) NULL,
	[manzana] [varchar](50) NULL,
	[supermanzana] [varchar](50) NULL,
	[kilometro] [varchar](50) NULL,
	[carretero] [varchar](50) NULL,
	[camino] [varchar](50) NULL,
	[numeroPiso] [varchar](50) NULL,
	[resultadoVerificacion] [varchar](5) NULL,
	[direccionPresunta] [varchar](500) NULL,
	[fecha_grabado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[numeroRuc] ASC,
	[numeroEstablecimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[sri_ruc_lista_blanca]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[sri_ruc_lista_blanca](
	[numeroRuc] [varchar](20) NOT NULL,
	[marcaListaBlanca] [varchar](5) NULL,
	[fecha_grabado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[numeroRuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[sri_tipo_contribuyente]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[sri_tipo_contribuyente](
	[numeroRuc] [varchar](20) NOT NULL,
	[nivel1] [varchar](200) NULL,
	[nivel2] [varchar](200) NULL,
	[nivel3] [varchar](200) NULL,
	[nivel4] [varchar](200) NULL,
	[ultimoNivel] [varchar](200) NULL,
	[fecha_grabado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[numeroRuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Dinardap].[SriRucContribuyente]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dinardap].[SriRucContribuyente](
	[claseContribuyente] [varchar](50) NULL,
	[codigoClaseContribuyente] [varchar](10) NULL,
	[codigoEstadoContribuyente] [varchar](10) NULL,
	[estadoContribuyente] [varchar](20) NULL,
	[estadoPersona] [varchar](20) NULL,
	[estadoSociedad] [varchar](20) NULL,
	[fechaActualizacion] [datetime] NULL,
	[fechaCancelacion] [datetime] NULL,
	[fechaReinicioActividades] [datetime] NULL,
	[fechaSuspensionDefinitiva] [datetime] NULL,
	[obligado] [varchar](5) NULL,
	[personaSociedad] [varchar](10) NULL,
	[fechaInscripcionRuc] [datetime] NULL,
	[fechaConstitucion] [datetime] NULL,
	[numeroRegistroMercantil] [varchar](50) NULL,
	[fechaFusion] [datetime] NULL,
	[fechaEscision] [datetime] NULL,
	[capitalSuscrito] [varchar](50) NULL,
	[fechaNombramiento] [datetime] NULL,
	[categoriaRise] [varchar](20) NULL,
	[comercioExterior] [varchar](10) NULL,
	[numRucSociedadAdscrita] [varchar](20) NULL,
	[numRucSociedadEscisionada] [varchar](20) NULL,
	[numeroRucFusionado] [varchar](20) NULL,
	[numeroPatronal] [varchar](20) NULL,
	[numeroExpediente] [varchar](50) NULL,
	[origenSociedad] [varchar](50) NULL,
	[gerenteGeneral] [varchar](200) NULL,
	[fechaNombramientoGerente] [datetime] NULL,
	[numeroRegistroColegioGremio] [varchar](50) NULL,
	[FechaRegistro] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[ConfiguracionEmail]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[ConfiguracionEmail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[servidor] [nvarchar](100) NOT NULL,
	[puerto] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[pwd] [nvarchar](100) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_ConfiguracionEmail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Jwt]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Jwt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[securityKey] [nvarchar](max) NOT NULL,
	[jwtTime] [int] NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Seguridad_Jwt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Rsa]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Rsa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[privateKey] [nvarchar](max) NOT NULL,
	[publicKey] [nvarchar](max) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Rsa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Usuario]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Usuario](
	[user] [nvarchar](50) NOT NULL,
	[cambiaClave] [bit] NULL,
	[diasParaCambiarClave] [int] NULL,
	[email] [nvarchar](50) NULL,
	[estaBloqueado] [bit] NULL,
	[estado] [bit] NULL,
	[fecha] [datetime] NULL,
	[fechaUltimoCambioClave] [datetime] NULL,
	[nombres] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK__Usuario__7FC76D73014370D6] PRIMARY KEY CLUSTERED 
(
	[user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Seguridad].[Usuario_Sesion]    Script Date: 25/2/2026 14:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Seguridad].[Usuario_Sesion](
	[jti] [nvarchar](50) NOT NULL,
	[codigoUser] [nvarchar](50) NOT NULL,
	[fecha] [date] NOT NULL,
	[fechaHora] [datetime] NOT NULL,
	[fechaExpiracion] [datetime] NOT NULL,
	[fechaRevocatoria] [datetime] NOT NULL,
	[browser] [nvarchar](100) NOT NULL,
	[userAgent] [nvarchar](200) NOT NULL,
	[language] [nvarchar](50) NOT NULL,
	[ip] [nvarchar](20) NOT NULL,
	[operatingSystem] [nvarchar](100) NOT NULL,
	[plugins] [nvarchar](200) NOT NULL,
	[geolocation] [nvarchar](50) NOT NULL,
	[timeZone] [nvarchar](50) NOT NULL,
	[estaRevocado] [bit] NOT NULL,
	[accion] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Seguridad_Usuario_Sesion] PRIMARY KEY CLUSTERED 
(
	[jti] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Aplicacion].[Cantones] ON 

INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (1, N'Azuay', N'Camilo Ponce Enríquez', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (2, N'Azuay', N'Chordeleg', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (3, N'Azuay', N'Cuenca', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (4, N'Azuay', N'El Pan', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (5, N'Azuay', N'Girón', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (6, N'Azuay', N'Guachapala', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (7, N'Azuay', N'Gualaceo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (8, N'Azuay', N'Nabón', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (9, N'Azuay', N'Oña', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (10, N'Azuay', N'Paute', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (11, N'Azuay', N'Pucará', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (12, N'Azuay', N'San Fernando', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (13, N'Azuay', N'Santa Isabel', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (14, N'Azuay', N'Sevilla de Oro', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (15, N'Azuay', N'Sígsig', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (16, N'Bolívar', N'Caluma', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (17, N'Bolívar', N'Chillanes', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (18, N'Bolívar', N'Chimbo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (19, N'Bolívar', N'Echeandía', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (20, N'Bolívar', N'Guaranda', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (21, N'Bolívar', N'Las Naves', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (22, N'Bolívar', N'San Miguel', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (23, N'Cañar', N'Azogues', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (24, N'Cañar', N'Biblián', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (25, N'Cañar', N'Cañar', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (26, N'Cañar', N'Déleg', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (27, N'Cañar', N'El Tambo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (28, N'Cañar', N'La Troncal', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (29, N'Cañar', N'Suscal', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (30, N'Carchi', N'Tulcán', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (31, N'Carchi', N'Bolívar', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (32, N'Carchi', N'Espejo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (33, N'Carchi', N'Mira', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (34, N'Carchi', N'Montúfar', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (35, N'Carchi', N'San Pedro de Huaca', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (36, N'Chimborazo', N'Riobamba', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (37, N'Chimborazo', N'Alausí', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (38, N'Chimborazo', N'Chambo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (39, N'Chimborazo', N'Chunchi', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (40, N'Chimborazo', N'Colta', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (41, N'Chimborazo', N'Cumandá', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (42, N'Chimborazo', N'Guamote', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (43, N'Chimborazo', N'Guano', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (44, N'Chimborazo', N'Pallatanga', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (45, N'Chimborazo', N'Penipe', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (46, N'Cotopaxi', N'Latacunga', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (47, N'Cotopaxi', N'La Maná', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (48, N'Cotopaxi', N'Pangua', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (49, N'Cotopaxi', N'Pujilí', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (50, N'Cotopaxi', N'Salcedo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (51, N'Cotopaxi', N'Saquisilí', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (52, N'Cotopaxi', N'Sigchos', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (53, N'El Oro', N'Machala', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (54, N'El Oro', N'Arenillas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (55, N'El Oro', N'Atahualpa', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (56, N'El Oro', N'Balsas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (57, N'El Oro', N'Chilla', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (58, N'El Oro', N'El Guabo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (59, N'El Oro', N'Huaquillas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (60, N'El Oro', N'Marcabelí', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (61, N'El Oro', N'Pasaje', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (62, N'El Oro', N'Piñas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (63, N'El Oro', N'Portovelo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (64, N'El Oro', N'Santa Rosa', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (65, N'El Oro', N'Zaruma', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (66, N'El Oro', N'Las Lajas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (67, N'Esmeraldas', N'Esmeraldas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (68, N'Esmeraldas', N'Eloy Alfaro', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (69, N'Esmeraldas', N'Muisne', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (70, N'Esmeraldas', N'Quinindé', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (71, N'Esmeraldas', N'San Lorenzo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (72, N'Esmeraldas', N'Atacames', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (73, N'Esmeraldas', N'Río Verde', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (74, N'Esmeraldas', N'La Concordia', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (75, N'Galápagos', N'Isabela', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (76, N'Galápagos', N'San Cristóbal', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (77, N'Galápagos', N'Santa Cruz', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (78, N'Guayas', N'Guayaquil', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (79, N'Guayas', N'Alfredo Baquerizo Moreno', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (80, N'Guayas', N'Balao', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (81, N'Guayas', N'Balzar', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (82, N'Guayas', N'Colimes', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (83, N'Guayas', N'Coronel Marcelino Maridueña', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (84, N'Guayas', N'Daule', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (85, N'Guayas', N'Durán', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (86, N'Guayas', N'El Empalme', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (87, N'Guayas', N'El Triunfo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (88, N'Guayas', N'General Antonio Elizalde', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (89, N'Guayas', N'Isidro Ayora', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (90, N'Guayas', N'Lomas de Sargentillo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (91, N'Guayas', N'Milagro', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (92, N'Guayas', N'Naranjal', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (93, N'Guayas', N'Naranjito', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (94, N'Guayas', N'Nobol', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (95, N'Guayas', N'Palestina', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (96, N'Guayas', N'Pedro Carbo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (97, N'Guayas', N'Playas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (98, N'Guayas', N'Salitre', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (99, N'Guayas', N'Samborondón', 0)
GO
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (100, N'Guayas', N'San Jacinto de Yaguachi', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (101, N'Guayas', N'Santa Lucía', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (102, N'Guayas', N'Simón Bolívar', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (103, N'Guayas', N'Babahoyo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (104, N'Guayas', N'Baba', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (105, N'Guayas', N'Buena Fé', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (106, N'Guayas', N'Catarama', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (107, N'Guayas', N'Montalvo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (108, N'Guayas', N'Páez', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (109, N'Guayas', N'Puebloviejo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (110, N'Guayas', N'Quevedo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (111, N'Guayas', N'Urdaneta', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (112, N'Guayas', N'Valencia', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (113, N'Guayas', N'Ventanas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (114, N'Guayas', N'Vinces', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (115, N'Imbabura', N'Ibarra', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (116, N'Imbabura', N'Antonio Ante', 1)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (117, N'Imbabura', N'Cotacachi', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (118, N'Imbabura', N'Otavalo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (119, N'Imbabura', N'Pimampiro', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (120, N'Imbabura', N'San Miguel de Urcuquí', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (121, N'Loja', N'Loja', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (122, N'Loja', N'Calvas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (123, N'Loja', N'Catamayo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (124, N'Loja', N'Celica', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (125, N'Loja', N'Chaguarpamba', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (126, N'Loja', N'Espíndola', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (127, N'Loja', N'Gonzanamá', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (128, N'Loja', N'Macará', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (129, N'Loja', N'Paltas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (130, N'Loja', N'Pindal', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (131, N'Loja', N'Quilanga', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (132, N'Loja', N'Olmedo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (133, N'Loja', N'Saraguro', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (134, N'Loja', N'Sozoranga', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (135, N'Loja', N'Zapotillo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (136, N'Los Ríos', N'Babahoyo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (137, N'Los Ríos', N'Baba', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (138, N'Los Ríos', N'Buena Fé', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (139, N'Los Ríos', N'Montalvo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (140, N'Los Ríos', N'Mocache', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (141, N'Los Ríos', N'Palenque', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (142, N'Los Ríos', N'Puebloviejo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (143, N'Los Ríos', N'Quevedo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (144, N'Los Ríos', N'Urdaneta', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (145, N'Los Ríos', N'Valencia', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (146, N'Los Ríos', N'Ventanas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (147, N'Los Ríos', N'Vinces', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (148, N'Los Ríos', N'Catarama', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (149, N'Manabí', N'Pedernales', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (150, N'Manabí', N'Chone', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (151, N'Manabí', N'Flavio Alfaro', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (152, N'Manabí', N'El Carmen', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (153, N'Manabí', N'Jama', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (154, N'Manabí', N'San Vicente', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (155, N'Manabí', N'Sucre', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (156, N'Manabí', N'Tosagua', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (157, N'Manabí', N'Rocafuerte', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (158, N'Manabí', N'Junín', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (159, N'Manabí', N'Bolívar', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (160, N'Manabí', N'Pichincha', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (161, N'Manabí', N'Portoviejo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (162, N'Manabí', N'Jaramijó', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (163, N'Manabí', N'Manta', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (164, N'Manabí', N'Montecristi', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (165, N'Manabí', N'Santa Ana', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (166, N'Manabí', N'Jipijapa', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (167, N'Manabí', N'Veinticuatro de Mayo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (168, N'Manabí', N'Olmedo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (169, N'Manabí', N'Puerto López', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (170, N'Manabí', N'Paján', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (171, N'Morona Santiago', N'Gualaquiza', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (172, N'Morona Santiago', N'Huamboya', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (173, N'Morona Santiago', N'Limón Indanza', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (174, N'Morona Santiago', N'Logroño', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (175, N'Morona Santiago', N'Macas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (176, N'Morona Santiago', N'Pablo Sexto', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (177, N'Morona Santiago', N'Palora', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (178, N'Morona Santiago', N'Sevilla Don Bosco', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (179, N'Morona Santiago', N'Santiago de Méndez', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (180, N'Morona Santiago', N'Sucúa', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (181, N'Morona Santiago', N'Taisha', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (182, N'Morona Santiago', N'Tiwintza', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (183, N'Napo', N'Archidona', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (184, N'Napo', N'Carlos Julio Arosemena Tola', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (185, N'Napo', N'El Chaco', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (186, N'Napo', N'Quijos', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (187, N'Napo', N'Tena', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (188, N'Orellana', N'Aguarico', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (189, N'Orellana', N'Francisco de Orellana', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (190, N'Orellana', N'Joya de los Sachas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (191, N'Orellana', N'Loreto', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (192, N'Pastaza', N'Arajuno', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (193, N'Pastaza', N'Mera', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (194, N'Pastaza', N'Puyo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (195, N'Pastaza', N'Santa Clara', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (196, N'Pastaza', N'Tarqui', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (197, N'Pastaza', N'Simón Bolívar', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (198, N'Pichincha', N'Cayambe', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (199, N'Pichincha', N'Mejía', 0)
GO
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (200, N'Pichincha', N'Pedro Moncayo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (201, N'Pichincha', N'Pedro Vicente Maldonado', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (202, N'Pichincha', N'Puerto Quito', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (203, N'Pichincha', N'Quito', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (204, N'Pichincha', N'Rumiñahui', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (205, N'Pichincha', N'San Miguel de los Bancos', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (206, N'Santa Elena', N'La Libertad', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (207, N'Santa Elena', N'Salinas', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (208, N'Santa Elena', N'Santa Elena', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (209, N'Santo Domingo de los Tsáchilas', N'La Concordia', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (210, N'Santo Domingo de los Tsáchilas', N'Santo Domingo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (211, N'Sucumbíos', N'Cascales', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (212, N'Sucumbíos', N'Cuyabeno', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (213, N'Sucumbíos', N'Gonzalo Pizarro', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (214, N'Sucumbíos', N'Lago Agrio', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (215, N'Sucumbíos', N'Putumayo', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (216, N'Sucumbíos', N'Shushufindi', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (217, N'Tungurahua', N'Ambato', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (218, N'Tungurahua', N'Baños de Agua Santa', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (219, N'Tungurahua', N'Cevallos', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (220, N'Tungurahua', N'Mocha', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (221, N'Tungurahua', N'Patate', 0)
INSERT [Aplicacion].[Cantones] ([id], [provincia], [canton], [seleccionado]) VALUES (222, N'Tungurahua', N'Quero', 0)
SET IDENTITY_INSERT [Aplicacion].[Cantones] OFF
GO
SET IDENTITY_INSERT [Aplicacion].[TarifaImpositiva] ON 

INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (1, CAST(0.00000 AS Decimal(18, 5)), CAST(2000.00000 AS Decimal(18, 5)), CAST(20.00000 AS Decimal(18, 5)), CAST(0.00000 AS Decimal(18, 5)))
INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (2, CAST(2000.01000 AS Decimal(18, 5)), CAST(4000.00000 AS Decimal(18, 5)), CAST(20.00000 AS Decimal(18, 5)), CAST(0.01000 AS Decimal(18, 5)))
INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (3, CAST(4000.01000 AS Decimal(18, 5)), CAST(10000.00000 AS Decimal(18, 5)), CAST(40.00000 AS Decimal(18, 5)), CAST(0.00900 AS Decimal(18, 5)))
INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (4, CAST(10000.01000 AS Decimal(18, 5)), CAST(20000.00000 AS Decimal(18, 5)), CAST(94.00000 AS Decimal(18, 5)), CAST(0.00800 AS Decimal(18, 5)))
INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (5, CAST(20000.01000 AS Decimal(18, 5)), CAST(50000.00000 AS Decimal(18, 5)), CAST(174.00000 AS Decimal(18, 5)), CAST(0.00700 AS Decimal(18, 5)))
INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (6, CAST(50000.01000 AS Decimal(18, 5)), CAST(100000.00000 AS Decimal(18, 5)), CAST(384.00000 AS Decimal(18, 5)), CAST(0.00600 AS Decimal(18, 5)))
INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (7, CAST(100000.01000 AS Decimal(18, 5)), CAST(300000.00000 AS Decimal(18, 5)), CAST(684.00000 AS Decimal(18, 5)), CAST(0.00600 AS Decimal(18, 5)))
INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (8, CAST(300000.01000 AS Decimal(18, 5)), CAST(600000.00000 AS Decimal(18, 5)), CAST(1684.00000 AS Decimal(18, 5)), CAST(0.00500 AS Decimal(18, 5)))
INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (9, CAST(600000.01000 AS Decimal(18, 5)), CAST(900000.00000 AS Decimal(18, 5)), CAST(2884.00000 AS Decimal(18, 5)), CAST(0.00400 AS Decimal(18, 5)))
INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (10, CAST(900000.01000 AS Decimal(18, 5)), CAST(1200000.00000 AS Decimal(18, 5)), CAST(3784.00000 AS Decimal(18, 5)), CAST(0.00300 AS Decimal(18, 5)))
INSERT [Aplicacion].[TarifaImpositiva] ([Id], [Desde], [Hasta], [Impuesto], [Excedente]) VALUES (11, CAST(1200000.01000 AS Decimal(18, 5)), CAST(9999999999.00000 AS Decimal(18, 5)), CAST(4384.00000 AS Decimal(18, 5)), CAST(0.00100 AS Decimal(18, 5)))
SET IDENTITY_INSERT [Aplicacion].[TarifaImpositiva] OFF
GO
INSERT [Aplicacion].[TasaAdministrativa] ([concepto], [valor]) VALUES (N'Tasa 1.5', CAST(5.00 AS Decimal(18, 2)))
INSERT [Aplicacion].[TasaAdministrativa] ([concepto], [valor]) VALUES (N'Tasa Administrativa', CAST(10.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [Seguridad].[Jwt] ON 

INSERT [Seguridad].[Jwt] ([id], [fecha], [securityKey], [jwtTime], [estado]) VALUES (1, CAST(N'2026-12-01' AS Date), N'7CPFBTUGJJ3NRRFXYHDKRJQQJNAP3Y33VOA44Z6J7AXJRN6XR4TY3S7436HANPNIAN64EIQ7JQJWR5YSBP32I6EECWYJIIOA6PEGT5I', 3600, 1)
SET IDENTITY_INSERT [Seguridad].[Jwt] OFF
GO
SET IDENTITY_INSERT [Seguridad].[Rsa] ON 

INSERT [Seguridad].[Rsa] ([id], [fecha], [privateKey], [publicKey], [estado]) VALUES (1, CAST(N'2026-01-12' AS Date), N'MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCUmptolusvD3xNsIK8qIpeo0hgcgRrz8vG5iCgAZ0YzuQg9ZGYwqMxKHby59ZgD1hh6ynDhWsAGuPsu6guUzJqq8V1ePibcmByoxTUZX9iFjbvPwA6BIjb0E4o50GJ9X5x6N9/hkDxv4iLxWqGsArmJcBSeFdcN/9SqvD3v/zT6bc6EdBZFLfbcH3P/X6MFjRSyDoqmc6Du3AjggR5fWNMiwjOZWQV+kqFoJuBqEYYEAPThkDtJTK2Safe8GzJSbeo2LPwtdPHwOxfAhdoBpJUp0SiXsXlDpReRoce4p3cFEWa75rMWiKtKMIibTe7Gdv/LOMIcc98EUVRAsQ1aUSZAgMBAAECggEAOeuo9zMbp9QZVw6dZnsqs4hhBXZrUrpDatr3jGYUnT7GnDIa9benc9mZw0Opwvc4M7I9LQArnHber77U5nl3BSy+YfMssyn5fbUiwUZuSATwlH+xzutFjKe8TyUT3nnZNvzVYBcr6Q4GYrQnuSeUl+/O7lYJduA8nDQUh/xExzORMtxL/SDuzdo41GxvGO8ElUTQsbLxR/pV/MbubMv/HxupX9yV+NDIc0yd64fa+Hu5M6kpf+WpXJfEVIqgujt4UaNij387nZLBMM8J+uR2yzE0k8SwQnXW5u1JCE/zuzZXX9uVzb7c/30W94G8Tv8N8VYGf7L1BDmlpx92LrHcoQKBgQDEA9pjeD4a9GJQisWbl2QgFOYqbiIHa/yOPc4ORgfVujB07aNnw32IRar54GdEj8WYmSd3yOv2mNp9WE7x6JE09bCtIAzOt2xjMNk9stwK/2OsVt6qy3pCNQb9fxQj210L4xIDciUEXDJJMGvSuXqeyPilxH5/YRY9hYS2aP8cpwKBgQDCFHzeZG/eawOG1wEr8RtLR312NxmKsQE1NVkXRq1Q2QplvebjVWLZdbTWYkIkudooDBXaxPvO0DbLJ3kZVfmq5YyvUJon+NrsFL3eVqeqX4bIwE2imtdVexC3MBzEdDpJSlD8rkPDVW6CrkANsCFQcy2BmQB+nYT+U5Q1lX58vwKBgQC0PCrCTd0lYdNI5eE/6Ru62ByvpScLFgNbM39V5pTrtFE8IwqercWu2QiWzP2HsH9rimAdJ5W44OH+YYXtsABc5xE2j4LXTRePuWn37o+gWSboX9RMzd60JBgyXXhCZEGRXZDBtGJPOQtP+wMZ90zF1luz6RK7w6T0muHl7HOvfwKBgEKraQ24cNl153s9hpCCvb6Ja2bdnK+RCHovvlAJnmYEeNbkelkjrtZG4f03OcOF+JQDOsqxGlM8IWZ+Q9JZP2/edQqQZLRQf1vT8DldiTE0qYdyz/iIumoJ4X8cTvWJe7BLkDCM6IhEY7cOhsBs/bS2LC610X6tO89mBKa3mQDfAoGBAJCGhbLusnRwQfPOYvWkuNyIe32iyRRwqh8iyOG//IxlzRMcQp5XEqIPnsNFrJiweScnBhdwnIclJoUIx5j412W4Oc08jadAJRZuDGJsNMEO88qsvWbuZCn/n80Qkxwh+RQZsvlX7MD8heTb+CfmKBMEMDOUvfGPQ7Nmnq7/8Pqw', N'MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAlJqbaJbrLw98TbCCvKiKXqNIYHIEa8/LxuYgoAGdGM7kIPWRmMKjMSh28ufWYA9YYespw4VrABrj7LuoLlMyaqvFdXj4m3JgcqMU1GV/YhY27z8AOgSI29BOKOdBifV+cejff4ZA8b+Ii8VqhrAK5iXAUnhXXDf/Uqrw97/80+m3OhHQWRS323B9z/1+jBY0Usg6KpnOg7twI4IEeX1jTIsIzmVkFfpKhaCbgahGGBAD04ZA7SUytkmn3vBsyUm3qNiz8LXTx8DsXwIXaAaSVKdEol7F5Q6UXkaHHuKd3BRFmu+azFoirSjCIm03uxnb/yzjCHHPfBFFUQLENWlEmQIDAQAB', 1)
SET IDENTITY_INSERT [Seguridad].[Rsa] OFF
GO
INSERT [Seguridad].[Usuario] ([user], [cambiaClave], [diasParaCambiarClave], [email], [estaBloqueado], [estado], [fecha], [fechaUltimoCambioClave], [nombres], [password]) VALUES (N'1310079072001', 0, 180, N'jgpb_1987@hotmail.com', 0, 1, CAST(N'2026-01-12T22:05:35.463' AS DateTime), CAST(N'2026-01-12T22:05:35.463' AS DateTime), N'JPINTO SOLUCIONES INFORMATICAS', N'30454023945b219501cae0c1f13a734f19eefbe7')
GO
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'01a33bf2-1a62-40f4-aed0-2aaa887aa02e', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T08:33:17.307' AS DateTime), CAST(N'2026-01-27T09:33:17.307' AS DateTime), CAST(N'2026-01-27T08:33:17.307' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'035b391c-f052-4be1-ad23-d551dfe425fc', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T07:51:50.413' AS DateTime), CAST(N'2026-01-27T08:51:50.413' AS DateTime), CAST(N'2026-01-27T07:51:50.413' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'04aac296-abcf-41b3-9460-735de8a5affe', N'1310079072001', CAST(N'2026-02-02' AS Date), CAST(N'2026-02-02T19:19:57.183' AS DateTime), CAST(N'2026-02-02T20:19:57.183' AS DateTime), CAST(N'2026-02-02T19:19:57.183' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'0fd5c520-0623-4ac1-b470-29f9aa611419', N'1310079072001', CAST(N'2026-01-28' AS Date), CAST(N'2026-01-28T19:14:26.057' AS DateTime), CAST(N'2026-01-28T20:14:26.057' AS DateTime), CAST(N'2026-01-28T19:14:26.057' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'13d61ccd-ca46-4680-aa62-6692c2f2755f', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T12:43:45.863' AS DateTime), CAST(N'2026-01-27T13:43:45.863' AS DateTime), CAST(N'2026-01-27T12:43:45.863' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'16497615-6878-42f4-8b17-d679c7a75b2c', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T14:57:09.857' AS DateTime), CAST(N'2026-01-27T15:57:09.857' AS DateTime), CAST(N'2026-01-27T14:57:09.857' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'1b8fc2f6-5bc9-48b9-bba1-6e89771878fc', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T15:31:25.113' AS DateTime), CAST(N'2026-01-26T16:31:25.113' AS DateTime), CAST(N'2026-01-26T15:31:25.113' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'1e217629-27e0-4d8b-a85e-27cdc9c9dafc', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T12:33:39.443' AS DateTime), CAST(N'2026-01-27T13:33:39.443' AS DateTime), CAST(N'2026-01-27T12:33:39.443' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'1f908259-b8d3-4622-8175-d42e405762b8', N'1310079072001', CAST(N'2026-02-02' AS Date), CAST(N'2026-02-02T19:46:34.140' AS DateTime), CAST(N'2026-02-02T20:46:34.140' AS DateTime), CAST(N'2026-02-02T19:46:34.140' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'25264b05-aadb-4bc8-9a50-0f66fe110105', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T18:25:33.723' AS DateTime), CAST(N'2026-01-26T19:25:33.723' AS DateTime), CAST(N'2026-01-26T18:25:33.723' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'254d00e3-3967-4f42-b6c1-66da705cb90d', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T09:32:34.657' AS DateTime), CAST(N'2026-01-26T10:32:34.657' AS DateTime), CAST(N'2026-01-26T09:32:34.657' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'30149f3b-c702-4006-b914-da50ded490b0', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T07:57:19.197' AS DateTime), CAST(N'2026-01-26T08:57:19.197' AS DateTime), CAST(N'2026-01-26T07:57:19.197' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'35a8cda3-c3c9-4ffd-8157-9c252202e331', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T10:16:30.570' AS DateTime), CAST(N'2026-01-26T11:16:30.570' AS DateTime), CAST(N'2026-01-26T10:16:30.570' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'371758d7-a387-4be9-a356-1a59640c6450', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T09:33:22.547' AS DateTime), CAST(N'2026-01-26T10:33:22.547' AS DateTime), CAST(N'2026-01-26T09:33:22.547' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'38ec7594-196b-4289-ba85-528278750870', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T13:35:17.990' AS DateTime), CAST(N'2026-01-27T14:35:17.990' AS DateTime), CAST(N'2026-01-27T13:35:17.990' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'41a04db2-917e-44c6-84f6-58d497ac39df', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:43:21.587' AS DateTime), CAST(N'2026-01-26T09:43:21.587' AS DateTime), CAST(N'2026-01-26T08:43:21.587' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'4268eeeb-86b6-4795-aadd-d835e45fe6cf', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T12:39:47.743' AS DateTime), CAST(N'2026-01-27T13:39:47.743' AS DateTime), CAST(N'2026-01-27T12:39:47.743' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'46fbddbc-cc4b-4a5d-8751-acf03210e6b4', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T14:50:41.573' AS DateTime), CAST(N'2026-01-27T15:50:41.573' AS DateTime), CAST(N'2026-01-27T14:50:41.573' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'49af18d1-77d4-42ac-88cc-1cb28b7255ca', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T09:31:40.277' AS DateTime), CAST(N'2026-01-26T10:31:40.277' AS DateTime), CAST(N'2026-01-26T09:31:40.277' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'51e8091d-5157-4b23-8b8c-a790ad61a35e', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T10:08:13.633' AS DateTime), CAST(N'2026-01-26T11:08:13.633' AS DateTime), CAST(N'2026-01-26T10:08:13.633' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'52f9283f-9b5a-453e-8c89-cc9724a27372', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T09:23:26.970' AS DateTime), CAST(N'2026-01-26T10:23:26.970' AS DateTime), CAST(N'2026-01-26T09:23:26.970' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'59f5e22f-6315-43d8-a2e4-849ba3e9756c', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:11:37.457' AS DateTime), CAST(N'2026-01-26T09:11:37.457' AS DateTime), CAST(N'2026-01-26T08:11:37.457' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'5dfecacc-d54c-4f4e-8b39-4086db1b0157', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T09:23:24.833' AS DateTime), CAST(N'2026-01-26T10:23:24.833' AS DateTime), CAST(N'2026-01-26T09:23:24.833' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'5f19c234-625f-4506-b95b-40ba3e94f7f4', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T12:30:33.227' AS DateTime), CAST(N'2026-01-27T13:30:33.227' AS DateTime), CAST(N'2026-01-27T12:30:33.227' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'62203dab-9fa5-4635-8e28-fe1781240574', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T19:02:15.040' AS DateTime), CAST(N'2026-01-26T20:02:15.040' AS DateTime), CAST(N'2026-01-26T19:02:15.040' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'64b4c6ba-c09a-4d40-8435-e5ba1dcaae89', N'1310079072001', CAST(N'2026-01-24' AS Date), CAST(N'2026-01-24T12:13:22.427' AS DateTime), CAST(N'2026-01-24T13:13:22.427' AS DateTime), CAST(N'2026-01-24T12:13:22.427' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'67a4438a-0e0c-454c-b165-196694999b5a', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T10:11:44.013' AS DateTime), CAST(N'2026-01-26T11:11:44.013' AS DateTime), CAST(N'2026-01-26T10:11:44.013' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'6d8493e8-3a4e-4c54-9e8e-be56b2e5487e', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:39:24.310' AS DateTime), CAST(N'2026-01-26T09:39:24.310' AS DateTime), CAST(N'2026-01-26T08:39:24.310' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'6daaf325-c38e-4275-8ca9-b8b1b24824d4', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T10:07:19.643' AS DateTime), CAST(N'2026-01-26T11:07:19.643' AS DateTime), CAST(N'2026-01-26T10:07:19.643' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'742bf2f7-bbeb-4133-b4c2-116e74bb02d9', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:51:40.860' AS DateTime), CAST(N'2026-01-26T09:51:40.860' AS DateTime), CAST(N'2026-01-26T08:51:40.860' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'7cba6038-78b7-4f41-b140-52f32307ea20', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T15:24:06.547' AS DateTime), CAST(N'2026-01-26T16:24:06.547' AS DateTime), CAST(N'2026-01-26T15:24:06.547' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'84d72c97-dcb0-4629-9077-e62fbd7081d1', N'1310079072001', CAST(N'2026-02-10' AS Date), CAST(N'2026-02-10T15:22:42.530' AS DateTime), CAST(N'2026-02-10T16:22:42.530' AS DateTime), CAST(N'2026-02-10T15:22:42.530' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'86a1dc6c-c1a2-4ea7-9aa8-e3663cff12c0', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T14:44:15.557' AS DateTime), CAST(N'2026-01-27T15:44:15.557' AS DateTime), CAST(N'2026-01-27T14:44:15.557' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'87e1b7c0-5ae6-42b7-a74d-560ac91c024d', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T15:37:04.830' AS DateTime), CAST(N'2026-01-26T16:37:04.830' AS DateTime), CAST(N'2026-01-26T15:37:04.830' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'87e9232b-4b5c-4027-a904-da470546cce6', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T09:30:55.920' AS DateTime), CAST(N'2026-01-26T10:30:55.920' AS DateTime), CAST(N'2026-01-26T09:30:55.920' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'8f00e38a-b352-49a5-b928-7792f29ee633', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T19:23:15.277' AS DateTime), CAST(N'2026-01-26T20:23:15.277' AS DateTime), CAST(N'2026-01-26T19:23:15.277' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'91a954fa-c1f2-462f-8409-4b99363ee270', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T07:56:48.030' AS DateTime), CAST(N'2026-01-26T08:56:48.030' AS DateTime), CAST(N'2026-01-26T07:56:48.030' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'9200e316-e339-4003-a72b-21cc512df4e8', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T08:48:01.257' AS DateTime), CAST(N'2026-01-27T09:48:01.257' AS DateTime), CAST(N'2026-01-27T08:48:01.257' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'9a43c0f0-5fad-4786-8013-f4160cddaf26', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T09:23:28.207' AS DateTime), CAST(N'2026-01-26T10:23:28.207' AS DateTime), CAST(N'2026-01-26T09:23:28.207' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'9ee1e27e-0e1a-4118-950f-f8b94f9deab7', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:12:15.060' AS DateTime), CAST(N'2026-01-26T09:12:15.060' AS DateTime), CAST(N'2026-01-26T08:12:15.060' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'9f7a0fda-93bd-440d-a5b1-b95e16bbd9e7', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T08:52:18.687' AS DateTime), CAST(N'2026-01-27T09:52:18.687' AS DateTime), CAST(N'2026-01-27T08:52:18.687' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'a07e37e7-a2ba-44dc-9364-31e5a225a095', N'1310079072001', CAST(N'2026-01-24' AS Date), CAST(N'2026-01-24T12:18:46.440' AS DateTime), CAST(N'2026-01-24T13:18:46.440' AS DateTime), CAST(N'2026-01-24T12:18:46.440' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'a1929f04-3834-4ebd-b8e9-15e5be60ed91', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:02:08.770' AS DateTime), CAST(N'2026-01-26T09:02:08.770' AS DateTime), CAST(N'2026-01-26T08:02:08.770' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'a3bca082-8e25-43cd-b7e1-33d3d4d92ea6', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:41:03.653' AS DateTime), CAST(N'2026-01-26T09:41:03.653' AS DateTime), CAST(N'2026-01-26T08:41:03.653' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'a4de79d2-ac37-4541-9e7a-d506b6799fb3', N'1310079072001', CAST(N'2026-01-24' AS Date), CAST(N'2026-01-24T12:24:19.840' AS DateTime), CAST(N'2026-01-24T13:24:19.840' AS DateTime), CAST(N'2026-01-24T12:24:19.840' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'a5024b63-2ea4-4f87-bab9-b1f290a8530c', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:16:45.737' AS DateTime), CAST(N'2026-01-26T09:16:45.737' AS DateTime), CAST(N'2026-01-26T08:16:45.737' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'a7679315-438d-42be-b027-327a1a4133b1', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T08:41:15.803' AS DateTime), CAST(N'2026-01-27T09:41:15.803' AS DateTime), CAST(N'2026-01-27T08:41:15.803' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'ab79949d-dc11-4718-a581-e614bac89716', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T13:43:02.397' AS DateTime), CAST(N'2026-01-27T14:43:02.397' AS DateTime), CAST(N'2026-01-27T13:43:02.397' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'ac97c6ab-9b5e-407a-b395-2f42cb2ff32a', N'1310079072001', CAST(N'2026-01-24' AS Date), CAST(N'2026-01-24T12:15:03.520' AS DateTime), CAST(N'2026-01-24T13:15:03.520' AS DateTime), CAST(N'2026-01-24T12:15:03.520' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'ae901da1-b46a-46ac-be55-82237acadae6', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T12:30:22.127' AS DateTime), CAST(N'2026-01-27T13:30:22.127' AS DateTime), CAST(N'2026-01-27T12:30:22.127' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'afe38a1b-6b31-4eb9-83e2-4c5907964513', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:44:35.660' AS DateTime), CAST(N'2026-01-26T09:44:35.660' AS DateTime), CAST(N'2026-01-26T08:44:35.660' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'b295c091-3cb8-4dc7-90d8-625785c1a673', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T19:08:38.477' AS DateTime), CAST(N'2026-01-26T20:08:38.477' AS DateTime), CAST(N'2026-01-26T19:08:38.477' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'b3f68d23-124e-455e-b605-319cfdb6061e', N'1310079072001', CAST(N'2026-02-10' AS Date), CAST(N'2026-02-10T10:19:40.073' AS DateTime), CAST(N'2026-02-10T11:19:40.073' AS DateTime), CAST(N'2026-02-10T10:19:40.073' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'b41e4e57-616a-4e64-9e68-e34023b84849', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T15:22:50.483' AS DateTime), CAST(N'2026-01-26T16:22:50.483' AS DateTime), CAST(N'2026-01-26T15:22:50.483' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'b783b92b-6272-40e1-8c0f-cbe70e2ead9e', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T18:59:08.027' AS DateTime), CAST(N'2026-01-26T19:59:08.027' AS DateTime), CAST(N'2026-01-26T18:59:08.027' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'b8e1daeb-138d-4cdb-8337-dcedc2008663', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T19:04:03.070' AS DateTime), CAST(N'2026-01-26T20:04:03.070' AS DateTime), CAST(N'2026-01-26T19:04:03.070' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'bf4ae02f-b43f-4dc7-9525-f368e8fd5ae6', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T19:24:51.803' AS DateTime), CAST(N'2026-01-26T20:24:51.803' AS DateTime), CAST(N'2026-01-26T19:24:51.803' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'c0185810-d5c2-4252-acb7-c81cde4085c7', N'1310079072001', CAST(N'2026-01-24' AS Date), CAST(N'2026-01-24T12:15:17.070' AS DateTime), CAST(N'2026-01-24T13:15:17.070' AS DateTime), CAST(N'2026-01-24T12:15:17.070' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'c1d5cb6d-4e63-4c70-a290-ba7d030a04aa', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T09:46:13.463' AS DateTime), CAST(N'2026-01-26T10:46:13.463' AS DateTime), CAST(N'2026-01-26T09:46:13.463' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'c23254c6-fb20-4868-a2ad-dca7b02e11ce', N'1310079072001', CAST(N'2026-01-24' AS Date), CAST(N'2026-01-24T12:21:34.570' AS DateTime), CAST(N'2026-01-24T13:21:34.570' AS DateTime), CAST(N'2026-01-24T12:21:34.570' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'c669df9c-6293-4fa4-9d67-814bd944f043', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T08:39:20.037' AS DateTime), CAST(N'2026-01-27T09:39:20.037' AS DateTime), CAST(N'2026-01-27T08:39:20.037' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'c814b62e-c369-41fe-9870-01273ce5b721', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T12:38:59.897' AS DateTime), CAST(N'2026-01-27T13:38:59.897' AS DateTime), CAST(N'2026-01-27T12:38:59.897' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'ca87c856-ce4d-464e-b059-ab589101bdc4', N'1310079072001', CAST(N'2026-02-10' AS Date), CAST(N'2026-02-10T20:32:55.357' AS DateTime), CAST(N'2026-02-10T21:32:55.357' AS DateTime), CAST(N'2026-02-10T20:32:55.357' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'd274703a-eb96-47a5-bafd-73ffee1e2340', N'1310079072001', CAST(N'2026-01-24' AS Date), CAST(N'2026-01-24T12:14:47.933' AS DateTime), CAST(N'2026-01-24T13:14:47.933' AS DateTime), CAST(N'2026-01-24T12:14:47.933' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'd6d6d8cd-a3dc-4ca3-bcc7-0ba56a699e55', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:02:22.300' AS DateTime), CAST(N'2026-01-26T09:02:22.300' AS DateTime), CAST(N'2026-01-26T08:02:22.300' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'db612c5d-648e-4532-94d3-cac7f9421cfc', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T15:33:00.963' AS DateTime), CAST(N'2026-01-26T16:33:00.963' AS DateTime), CAST(N'2026-01-26T15:33:00.963' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'dbc26f08-ccd6-4067-a443-916bbcc7465d', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T08:51:13.600' AS DateTime), CAST(N'2026-01-27T09:51:13.600' AS DateTime), CAST(N'2026-01-27T08:51:13.600' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'de2ca64f-2d6b-4aa5-8922-7345a5b6c540', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T14:18:55.210' AS DateTime), CAST(N'2026-01-27T15:18:55.210' AS DateTime), CAST(N'2026-01-27T14:18:55.210' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'e265b9c8-e7a9-4454-856f-ba2a1934f2fd', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T19:03:10.037' AS DateTime), CAST(N'2026-01-26T20:03:10.037' AS DateTime), CAST(N'2026-01-26T19:03:10.037' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'e37a9199-8842-4320-9600-3ed16866e65f', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T07:57:00.330' AS DateTime), CAST(N'2026-01-26T08:57:00.330' AS DateTime), CAST(N'2026-01-26T07:57:00.330' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'f1f74f3a-a6e8-4e4f-95ea-04f048097523', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:14:23.287' AS DateTime), CAST(N'2026-01-26T09:14:23.287' AS DateTime), CAST(N'2026-01-26T08:14:23.287' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'f38ab0bb-4053-4178-8227-6683c4d9bec9', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T08:42:00.047' AS DateTime), CAST(N'2026-01-26T09:42:00.047' AS DateTime), CAST(N'2026-01-26T08:42:00.047' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'f3fab4f0-f165-4139-adbd-f289d796b35d', N'1310079072001', CAST(N'2026-01-24' AS Date), CAST(N'2026-01-24T12:17:15.787' AS DateTime), CAST(N'2026-01-24T13:17:15.787' AS DateTime), CAST(N'2026-01-24T12:17:15.787' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'f5589e7f-bace-4925-957f-1bfaffee843d', N'1310079072001', CAST(N'2026-01-28' AS Date), CAST(N'2026-01-28T18:56:50.357' AS DateTime), CAST(N'2026-01-28T19:56:50.357' AS DateTime), CAST(N'2026-01-28T18:56:50.357' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'f8bc2734-3889-4910-802d-d10da99e1ecb', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T19:05:08.327' AS DateTime), CAST(N'2026-01-26T20:05:08.327' AS DateTime), CAST(N'2026-01-26T19:05:08.327' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-ES', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'fabed994-26fd-4d99-b0f3-21ba1688f6f4', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T07:57:56.680' AS DateTime), CAST(N'2026-01-26T08:57:56.680' AS DateTime), CAST(N'2026-01-26T07:57:56.680' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'fcfa6de9-21e9-41b9-9e22-e3088f1f4c54', N'1310079072001', CAST(N'2026-01-27' AS Date), CAST(N'2026-01-27T12:47:26.193' AS DateTime), CAST(N'2026-01-27T13:47:26.190' AS DateTime), CAST(N'2026-01-27T12:47:26.193' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
INSERT [Seguridad].[Usuario_Sesion] ([jti], [codigoUser], [fecha], [fechaHora], [fechaExpiracion], [fechaRevocatoria], [browser], [userAgent], [language], [ip], [operatingSystem], [plugins], [geolocation], [timeZone], [estaRevocado], [accion]) VALUES (N'fe8899e9-84fc-4931-82e4-4c54e6c7926b', N'1310079072001', CAST(N'2026-01-26' AS Date), CAST(N'2026-01-26T09:42:35.313' AS DateTime), CAST(N'2026-01-26T10:42:35.313' AS DateTime), CAST(N'2026-01-26T09:42:35.313' AS DateTime), N'Google Chrome 144.0.0.0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/144.0.0.0 Safari/537.36', N'es-419', N'', N'Windows', N'', N'', N'America/Guayaquil', 0, N'Login')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_act_est_ruc]    Script Date: 25/2/2026 14:16:54 ******/
CREATE NONCLUSTERED INDEX [IX_act_est_ruc] ON [Dinardap].[actividades_establecimiento]
(
	[numero_ruc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Aplicacion].[DeclaracionPJ] ADD  CONSTRAINT [DF__Declaraci__Fecha__160F4887]  DEFAULT (getdate()) FOR [FechaInser]
GO
ALTER TABLE [Dinardap].[actividades_establecimiento] ADD  DEFAULT (sysdatetime()) FOR [fecha_registro]
GO
ALTER TABLE [Dinardap].[Form101] ADD  DEFAULT (getdate()) FOR [fechaInsert]
GO
ALTER TABLE [Dinardap].[Form102] ADD  DEFAULT (getdate()) FOR [FechaInsercion]
GO
ALTER TABLE [Dinardap].[SepsOrganizacion] ADD  DEFAULT (sysdatetime()) FOR [fecha_grabado]
GO
ALTER TABLE [Dinardap].[sri_actividad_economica] ADD  DEFAULT (getdate()) FOR [fecha_grabado]
GO
ALTER TABLE [Dinardap].[sri_contador] ADD  DEFAULT (getdate()) FOR [fecha_grabado]
GO
ALTER TABLE [Dinardap].[sri_contribuyente_datos] ADD  DEFAULT (getdate()) FOR [fecha_grabado]
GO
ALTER TABLE [Dinardap].[sri_estructura_organizacional] ADD  DEFAULT (getdate()) FOR [fecha_grabado]
GO
ALTER TABLE [Dinardap].[sri_representante_legal] ADD  DEFAULT (getdate()) FOR [fecha_grabado]
GO
ALTER TABLE [Dinardap].[sri_ruc_establecimientos] ADD  DEFAULT (getdate()) FOR [fecha_grabado]
GO
ALTER TABLE [Dinardap].[sri_ruc_lista_blanca] ADD  DEFAULT (getdate()) FOR [fecha_grabado]
GO
ALTER TABLE [Dinardap].[sri_tipo_contribuyente] ADD  DEFAULT (getdate()) FOR [fecha_grabado]
GO
ALTER TABLE [Dinardap].[SriRucContribuyente] ADD  DEFAULT (sysdatetime()) FOR [FechaRegistro]
GO
ALTER TABLE [Seguridad].[Usuario_Sesion] ADD  DEFAULT ('') FOR [accion]
GO
ALTER TABLE [Aplicacion].[DistribucionPago]  WITH CHECK ADD  CONSTRAINT [FK_DistribucionPago_Cantones] FOREIGN KEY([id])
REFERENCES [Aplicacion].[Cantones] ([id])
GO
ALTER TABLE [Aplicacion].[DistribucionPago] CHECK CONSTRAINT [FK_DistribucionPago_Cantones]
GO
ALTER TABLE [Aplicacion].[DistribucionPago]  WITH CHECK ADD  CONSTRAINT [FK_DistribucionPago_DeclaracionPJ] FOREIGN KEY([ruc], [aniofiscal])
REFERENCES [Aplicacion].[DeclaracionPJ] ([ruc], [aniofiscal])
GO
ALTER TABLE [Aplicacion].[DistribucionPago] CHECK CONSTRAINT [FK_DistribucionPago_DeclaracionPJ]
GO
ALTER TABLE [Seguridad].[Usuario_Sesion]  WITH CHECK ADD  CONSTRAINT [FK_Seguridad_Usuario_Sesion_Usuario] FOREIGN KEY([codigoUser])
REFERENCES [Seguridad].[Usuario] ([user])
GO
ALTER TABLE [Seguridad].[Usuario_Sesion] CHECK CONSTRAINT [FK_Seguridad_Usuario_Sesion_Usuario]
GO
USE [master]
GO
ALTER DATABASE [GadAntonioAnte] SET  READ_WRITE 
GO
