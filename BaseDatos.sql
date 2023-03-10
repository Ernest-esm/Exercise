USE [BANK_ACCOUNTS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Clientes](
	[ID_CLIENTE] [int] IDENTITY(1,1) NOT NULL,
	[ID_PERSONA] [int] NOT NULL,
	[CONTRASEÑA] [varchar](50) NOT NULL,
	[ESTADO] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID_CLIENTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cuenta](
	[ID_CUENTA] [int] IDENTITY(1,1) NOT NULL,
	[ID_CLIENTE] [int] NOT NULL,
	[NUMERO_CUENTA] [varchar](50) NOT NULL,
	[TIPO_CUENTA] [varchar](50) NOT NULL,
	[SALDO_INI] [decimal](18, 2) NOT NULL,
	[ESTADO] [int] NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[ID_CUENTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Mensajes](
	[ID_MSG] [int] IDENTITY(1,1) NOT NULL,
	[MESSAGE] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Mensajes] PRIMARY KEY CLUSTERED 
(
	[ID_MSG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Movimientos](
	[ID_MOV] [int] IDENTITY(1,1) NOT NULL,
	[ID_CLIENTE] [int] NOT NULL,
	[ID_CUENTA] [int] NOT NULL,
	[MOVIMIENTO] [decimal](18, 2) NOT NULL,
	[SALDO] [decimal](18, 2) NOT NULL,
	[FECHA] [datetime] NOT NULL,
	[ESTADO] [int] NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[ID_MOV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Persona](
	[ID_PERSONA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[GENERO] [varchar](100) NOT NULL,
	[EDAD] [varchar](10) NOT NULL,
	[IDENTIFICACION] [varchar](50) NOT NULL,
	[DIRECCION] [varchar](100) NOT NULL,
	[TELEFONO] [varchar](100) NOT NULL,
 CONSTRAINT [PK_T_Persona] PRIMARY KEY CLUSTERED 
(
	[ID_PERSONA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Clientes] ON 
GO
INSERT [Clientes] ([ID_CLIENTE], [ID_PERSONA], [CONTRASEÑA], [ESTADO]) VALUES (2, 8, N'1234', 1)
GO
INSERT [Clientes] ([ID_CLIENTE], [ID_PERSONA], [CONTRASEÑA], [ESTADO]) VALUES (3, 9, N'5678', 1)
GO
INSERT [Clientes] ([ID_CLIENTE], [ID_PERSONA], [CONTRASEÑA], [ESTADO]) VALUES (4, 10, N'1245', 1)
GO
SET IDENTITY_INSERT [Clientes] OFF
GO
SET IDENTITY_INSERT [Cuenta] ON 
GO
INSERT [Cuenta] ([ID_CUENTA], [ID_CLIENTE], [NUMERO_CUENTA], [TIPO_CUENTA], [SALDO_INI], [ESTADO]) VALUES (2, 2, N'478758', N'Ahorro', CAST(2000.00 AS Decimal(18, 2)), 1)
GO
INSERT [Cuenta] ([ID_CUENTA], [ID_CLIENTE], [NUMERO_CUENTA], [TIPO_CUENTA], [SALDO_INI], [ESTADO]) VALUES (3, 3, N'225487', N'Corriente', CAST(100.00 AS Decimal(18, 2)), 1)
GO
INSERT [Cuenta] ([ID_CUENTA], [ID_CLIENTE], [NUMERO_CUENTA], [TIPO_CUENTA], [SALDO_INI], [ESTADO]) VALUES (4, 4, N'495878', N'Ahorro', CAST(0.00 AS Decimal(18, 2)), 1)
GO
INSERT [Cuenta] ([ID_CUENTA], [ID_CLIENTE], [NUMERO_CUENTA], [TIPO_CUENTA], [SALDO_INI], [ESTADO]) VALUES (5, 3, N'496825', N'Ahorro', CAST(540.00 AS Decimal(18, 2)), 1)
GO
INSERT [Cuenta] ([ID_CUENTA], [ID_CLIENTE], [NUMERO_CUENTA], [TIPO_CUENTA], [SALDO_INI], [ESTADO]) VALUES (6, 2, N'585545', N'Corriente', CAST(1000.00 AS Decimal(18, 2)), 1)
GO
SET IDENTITY_INSERT [Cuenta] OFF
GO
SET IDENTITY_INSERT [Mensajes] ON 
GO
INSERT [Mensajes] ([ID_MSG], [MESSAGE]) VALUES (1, N'SALDO NO DISPONIBLE')
GO
SET IDENTITY_INSERT [Mensajes] OFF
GO
SET IDENTITY_INSERT [Movimientos] ON 
GO
INSERT [Movimientos] ([ID_MOV], [ID_CLIENTE], [ID_CUENTA], [MOVIMIENTO], [SALDO], [FECHA], [ESTADO]) VALUES (1, 2, 2, CAST(-575.00 AS Decimal(18, 2)), CAST(1425.00 AS Decimal(18, 2)), CAST(N'2023-02-21T12:25:38.617' AS DateTime), 1)
GO
INSERT [Movimientos] ([ID_MOV], [ID_CLIENTE], [ID_CUENTA], [MOVIMIENTO], [SALDO], [FECHA], [ESTADO]) VALUES (2, 3, 3, CAST(600.00 AS Decimal(18, 2)), CAST(700.00 AS Decimal(18, 2)), CAST(N'2023-02-21T12:30:59.207' AS DateTime), 1)
GO
INSERT [Movimientos] ([ID_MOV], [ID_CLIENTE], [ID_CUENTA], [MOVIMIENTO], [SALDO], [FECHA], [ESTADO]) VALUES (3, 4, 4, CAST(150.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(N'2023-02-21T12:31:27.053' AS DateTime), 1)
GO 
INSERT [Movimientos] ([ID_MOV], [ID_CLIENTE], [ID_CUENTA], [MOVIMIENTO], [SALDO], [FECHA], [ESTADO]) VALUES (4, 3, 5, CAST(-540.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2023-02-21T12:31:52.130' AS DateTime), 1)
GO
SET IDENTITY_INSERT [Movimientos] OFF
GO
SET IDENTITY_INSERT [Persona] ON 
GO
INSERT [Persona] ([ID_PERSONA], [NOMBRE], [GENERO], [EDAD], [IDENTIFICACION], [DIRECCION], [TELEFONO]) VALUES (8, N'Jose Lema ', N'M', N'33', N'INE', N'Otavalo sn y principal', N'098254785')
GO
INSERT [Persona] ([ID_PERSONA], [NOMBRE], [GENERO], [EDAD], [IDENTIFICACION], [DIRECCION], [TELEFONO]) VALUES (9, N'Marianela Montalvo ', N'M', N'33', N'INE', N'Amazonas y NNUU', N'097548965')
GO
INSERT [Persona] ([ID_PERSONA], [NOMBRE], [GENERO], [EDAD], [IDENTIFICACION], [DIRECCION], [TELEFONO]) VALUES (10, N'Juan Osorio ', N'M', N'33', N'INE', N'13 junio y Equinoccial', N'098874587')
GO
SET IDENTITY_INSERT [Persona] OFF
GO
ALTER TABLE [Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([ID_PERSONA])
REFERENCES [Persona] ([ID_PERSONA])
GO
ALTER TABLE [Clientes] CHECK CONSTRAINT [FK_Cliente_Persona]
GO
ALTER TABLE [Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente] FOREIGN KEY([ID_CLIENTE])
REFERENCES [Clientes] ([ID_CLIENTE])
GO
ALTER TABLE [Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente]
GO
ALTER TABLE [Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Clientes] FOREIGN KEY([ID_CLIENTE])
REFERENCES [Clientes] ([ID_CLIENTE])
GO
ALTER TABLE [Movimientos] CHECK CONSTRAINT [FK_Movimiento_Clientes]
GO
ALTER TABLE [Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Cuenta] FOREIGN KEY([ID_CUENTA])
REFERENCES [Cuenta] ([ID_CUENTA])
GO
ALTER TABLE [Movimientos] CHECK CONSTRAINT [FK_Movimiento_Cuenta]
GO
