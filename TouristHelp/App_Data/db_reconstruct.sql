DROP TABLE [dbo].Tours;
DROP TABLE [dbo].ReservationFood;
DROP TABLE [dbo].TouristBooking;
DROP TABLE [dbo].ReservationHotel;
DROP TABLE [dbo].HotelBook;
DROP TABLE [dbo].ShopVoucher;
DROP TABLE [dbo].[Transaction];
DROP TABLE [dbo].Reward;
DROP TABLE [dbo].Directions;
DROP TABLE [dbo].TourGuides;
DROP TABLE [dbo].Tourists;
DROP TABLE [dbo].Users;
DROP TABLE [dbo].Cart;
DROP TABLE [dbo].Interest;
DROP TABLE [dbo].Ticket;
DROP TABLE [dbo].Attraction;

CREATE TABLE [dbo].[Attraction] (
    [attractionId]          INT             IDENTITY (1, 1) NOT NULL,
    [attractionName]        VARCHAR (MAX)   NOT NULL,
    [attractionPrice]       NVARCHAR (50)   NOT NULL,
    [dateTime]              VARCHAR (50)    NULL,
    [attractionDesc]        VARCHAR (MAX)   NOT NULL,
    [attractionLocation]    VARCHAR (50)    NOT NULL,
    [attractionLatitude]    DECIMAL (18, 8) NULL,
    [attractionLongitude]   DECIMAL (18, 8) NULL,
    [attractionInterest]    VARCHAR (50)    NOT NULL,
    [attractionType]        VARCHAR (50)    NOT NULL,
    [attractionTransaction] VARCHAR (50)    NOT NULL,
    [attractionImage]       VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Attraction] PRIMARY KEY CLUSTERED ([attractionId] ASC)
);



CREATE TABLE [dbo].[Ticket] (
    [ticketId]       INT             IDENTITY (1, 1) NOT NULL,
    [attractionName] VARCHAR (50)    NOT NULL,
    [attractionDesc] VARCHAR (MAX)   NOT NULL,
    [price]          NUMERIC (18, 2) NOT NULL,
    [dateExpire]     DATE            NOT NULL,
    [ticketCode]     VARCHAR (50)    NOT NULL,
    [paid]           VARCHAR (50)    NOT NULL,
    [user_id]        NCHAR (10)      NULL,
    [ticketImage]    NCHAR (50)      NULL,
    [cartId]         INT             NULL,
    PRIMARY KEY CLUSTERED ([ticketId] ASC)
);


CREATE TABLE [dbo].[Interest] (
    [InterestName] VARCHAR (50) NOT NULL,
    [user_id]      INT          NOT NULL
);


CREATE TABLE [dbo].[Cart] (
    [cartId]          INT             IDENTITY (1, 1) NOT NULL,
    [productName]     VARCHAR (50)    NOT NULL,
    [productPrice]    DECIMAL (18, 2) NOT NULL,
    [productQuantity] INT             NOT NULL,
    [user_id]         INT             NULL,
    [productDesc]     VARCHAR (MAX)   NULL,
    [active]          VARCHAR (50)    NULL,
    [productExpiry]   DATETIME        NULL,
    [itemType]        NVARCHAR (50)   NULL,
    PRIMARY KEY CLUSTERED ([cartId] ASC)
);






CREATE TABLE [dbo].[Tourists] (
    [tourist_id]  INT          IDENTITY (1, 1) NOT NULL,
    [nationality] VARCHAR (50) NULL,
    [user_id]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([tourist_id] ASC),
    CONSTRAINT [FK_Tourist_ToUser] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id])
);

CREATE TABLE [dbo].[TourGuides] (
    [tourguide_id]   INT           IDENTITY (1, 1) NOT NULL,
    [user_id]        INT           NOT NULL,
    [tours]          VARCHAR (255) NULL,
    [description]    VARCHAR (50)  NULL,
    [languages]      VARCHAR (50)  NULL,
    [credentials]    VARCHAR (255) NULL,
    [tourguideimage] VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([tourguide_id] ASC),
    CONSTRAINT [FK_TourGuides_ToUsers] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id])
);







CREATE TABLE [dbo].[Directions] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [attraction_id] INT NOT NULL,
    [tourist_id]    INT NOT NULL,
    CONSTRAINT [PK_Directions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Directions_ToTourists] FOREIGN KEY ([tourist_id]) REFERENCES [dbo].[Tourists] ([tourist_id]),
    CONSTRAINT [FK_Directions_ToAttractions] FOREIGN KEY ([attraction_id]) REFERENCES [dbo].[Attraction] ([attractionId])
);


CREATE TABLE [dbo].[Reward] (
    [user_id]         INT          NOT NULL,
    [loginCount]      INT          DEFAULT ((0)) NOT NULL,
    [loginStreak]     INT          DEFAULT ((0)) NOT NULL,
    [loyaltyTier]     VARCHAR (50) NOT NULL,
    [totalDiscount]   INT          NOT NULL,
    [bonusCredits]    INT          NOT NULL,
    [membershipTier]  VARCHAR (50) NOT NULL,
    [creditBalance]   INT          NOT NULL,
    [remainBonusDays] INT          NOT NULL,
    [loggedInLog]     BIT          NOT NULL,
    [loggedInDate]    DATETIME     NOT NULL,
    [newDateCheck]    BIT          NOT NULL,
    CONSTRAINT [PK_Reward] PRIMARY KEY CLUSTERED ([user_id] ASC)
);


CREATE TABLE [dbo].[Transaction] (
    [voucherGen_id]    INT          NOT NULL,
    [voucherStats]     VARCHAR (50) NOT NULL,
    [voucherExpiry]    DATETIME     NULL,
    [confirmCode]      INT          NOT NULL,
    [user_id]          INT          NOT NULL,
    [voucherDate]      DATETIME     NOT NULL,
    [voucherTotalCost] INT          NOT NULL,
    [voucherQuantity]  INT          NOT NULL,
    [voucherName]      VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([voucherGen_id] ASC)
   
);





CREATE TABLE [dbo].[ShopVoucher] (
    [voucher_id]         INT           IDENTITY (1, 1) NOT NULL,
    [voucherQty]         INT           NOT NULL,
    [voucherType]        VARCHAR (50)  NOT NULL,
    [voucherStatus]      VARCHAR (50)  NOT NULL,
    [membershipCategory] BIT           NOT NULL,
    [foodCategory]       BIT           NOT NULL,
    [nameFilter]         VARCHAR (50)  NULL,
    [voucherCost]        INT           NOT NULL,
    [shopImage]          NVARCHAR (50) NULL,
    [shopDesc]           NVARCHAR (50) NULL,
    [voucherName]        NVARCHAR (50) NOT NULL,
    [voucherPopularity] INT NULL, 
    PRIMARY KEY CLUSTERED ([voucher_id] ASC)
);



CREATE TABLE [dbo].[HotelBook] (
    [hotelId]        INT             IDENTITY (1, 1) NOT NULL,
    [hotelPrice]     DECIMAL (18, 2) NOT NULL,
    [hotelImage]     NVARCHAR (50)   NULL,
    [centralFilter]  BIT             NOT NULL,
    [northFilter]    BIT             NOT NULL,
    [southFilter]    BIT             NOT NULL,
    [westFilter]     BIT             NOT NULL,
    [eastFilter]     BIT             NOT NULL,
    [hotelName]      NVARCHAR (50)   NOT NULL,
    [minPriceFilter] INT             NULL,
    [maxPriceFilter] INT             NULL,
    PRIMARY KEY CLUSTERED ([hotelId] ASC)
);


CREATE TABLE [dbo].[ReservationHotel] (
    [hotelGen_Id]  INT             NOT NULL,
    [totalCost]    DECIMAL (18, 2) NOT NULL,
    [roomQty]      INT             NOT NULL,
    [stayDuration] DATETIME        NOT NULL,
    [user_id]      INT             NOT NULL,
    [hotelName]    NVARCHAR (50)   NOT NULL,
    [verifyHotel]  INT             NOT NULL,
    [hotelPaid]    NVARCHAR (50)   NOT NULL,
    [cartId]       INT             NOT NULL,
    [reserveDate] DATETIME NOT NULL, 
    PRIMARY KEY CLUSTERED ([hotelGen_Id] ASC)
);

CREATE TABLE [dbo].[TouristBooking] (
    [tourist_id]   INT          NOT NULL,
    [name]         VARCHAR (50) NULL,
    [id]           INT          NOT NULL,
    [tourtitle]    VARCHAR (50) NULL,
    [timing]       VARCHAR (50) NULL,
    [status]       VARCHAR (50) NULL,
    [tourguide_id] INT          NULL,
    CONSTRAINT [PK_TouristBooking] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TouristBooking_ToTourists] FOREIGN KEY ([tourist_id]) REFERENCES [dbo].[Tourists] ([tourist_id]),
    CONSTRAINT [FK_TouristBooking_ToTourGuides] FOREIGN KEY ([tourguide_id]) REFERENCES [dbo].[TourGuides] ([tourguide_id])
);




CREATE TABLE [dbo].[ReservationFood] (
    [reservationId]    INT          IDENTITY (1, 1) NOT NULL,
    [reservationName]  VARCHAR (50) NOT NULL,
    [reservationDate]  VARCHAR (50) NOT NULL,
    [reservationTime]  VARCHAR (50) NOT NULL,
    [reservationPax]   INT          NOT NULL,
    [reservationState] VARCHAR (50) NOT NULL,
    [userId]           INT          NOT NULL
);

CREATE TABLE [dbo].[Tours] (
    [Id]           INT           NOT NULL,
    [tourguide_id] INT           NOT NULL,
    [title]        VARCHAR (50)  NULL,
    [description]  VARCHAR (200) NULL,
    [details]      VARCHAR (200) NULL,
    [price]        VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tours_ToTourGuides] FOREIGN KEY ([tourguide_id]) REFERENCES [dbo].[TourGuides] ([tourguide_id])
);


CREATE TABLE [dbo].[EmailVerification]
(
    [emailVerificationCode] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [email] VARCHAR(255) NOT NULL, 
    [expire] BIT NOT NULL, 
    [timeGenerated] DATETIME NOT NULL
)


CREATE TABLE [dbo].[Users] (
    [user_id]            INT            IDENTITY (1, 1) NOT NULL,
    [password]           VARCHAR (255)  NOT NULL,
    [salt]               NVARCHAR (MAX) NULL,
    [name]               VARCHAR (255)  NOT NULL,
    [email]              VARCHAR (255)  NOT NULL,
    [firstLogin]         BIT            DEFAULT ((1)) NOT NULL,
    [failCount]          INT            DEFAULT ((0)) NOT NULL,
    [email2FAON]         BIT            DEFAULT ((0)) NOT NULL,
    [email2FACode]       NVARCHAR (50)  NULL,
    [token]              NVARCHAR (MAX) NULL,
    [expiryToken]        DATETIME       NULL,
    [secretKey]          NVARCHAR (MAX) NULL,
    [verified]           BIT            DEFAULT ((0)) NULL,
    [accountLockedUntil] DATETIME       DEFAULT (getdate()) NULL,
    [phone]              NVARCHAR (MAX) NULL,
    [phone2FAON]         BIT            DEFAULT ((0)) NOT NULL,
    [phone2FACode]       NVARCHAR (50)  NULL,
    [status2FA]          NVARCHAR (3)   DEFAULT ('OFF') NOT NULL,
    [logStatus]          NVARCHAR (MAX) NULL,
	[lastLoggedIn]       DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);




CREATE TABLE [dbo].[PasswordGen] (
    [pwId]            INT           IDENTITY (1, 1) NOT NULL,
    [email]         VARCHAR (255) NULL,
    [passwordHash]  VARCHAR (255) NULL,
    [passwordSalt]  VARCHAR (255) NULL,
    [timeGenerated] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([pwId] ASC)
);

CREATE TABLE [dbo].[SecurityLogs] (
    [logId]           INT           IDENTITY (1, 1) NOT NULL,
	[logTarget] VARCHAR(MAX) NULL,
	[logType] VARCHAR(50) NULL, 
    [logContent]      VARCHAR (MAX) NULL,
    [dateTimeCreated] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([logId] ASC)
);

CREATE TABLE [dbo].[ResetPasswordRequests] (
    [Id]                         UNIQUEIDENTIFIER NOT NULL,
    [user_id]                    INT              NOT NULL,
    [resetrequestdatetime]       DATETIME         NULL,
    [resetrequestdatetimeexpire] DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ResetPasswordRequests_ToUsers] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id])
);

