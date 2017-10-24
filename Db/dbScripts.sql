USE [krknTrdsDb]
GO
/****** Object:  Table [dbo].[trades]    Script Date: 15/10/2017 19:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Direction] [nvarchar](max) NULL,
	[LastTradeId] [bigint] NOT NULL,
	[Miscellaneous] [nvarchar](max) NULL,
	[Pair] [nvarchar](max) NULL,
	[Price] [decimal](30, 5) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[UnixTime] [decimal](30, 5) NOT NULL,
	[Volume] [decimal](30, 8) NOT NULL,
	[IsMaTrade] [bit] NULL,
 CONSTRAINT [PK_trades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[trades] ADD  CONSTRAINT [DF_trades_IsMaTrade]  DEFAULT ((0)) FOR [IsMaTrade]
GO
