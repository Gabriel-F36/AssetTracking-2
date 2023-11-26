CREATE TABLE [dbo].[Phones] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [applianceName]    NVARCHAR (MAX) NOT NULL,
    [brand]            NVARCHAR (MAX) NOT NULL,
    [modelName]        NVARCHAR (MAX) NOT NULL,
    [purchaseDate]     NVARCHAR (MAX) NOT NULL,
    [screenSizeInches] INT            NOT NULL,
    [price]            INT            NOT NULL,
    CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED ([id] ASC)
);

