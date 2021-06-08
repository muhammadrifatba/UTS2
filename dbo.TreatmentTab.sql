CREATE TABLE [dbo].[TreatmentTab] (
    [Treatid]   INT          IDENTITY (1000, 1) NOT NULL,
    [TreatName] VARCHAR (50) NOT NULL,
    [TreatCost] INT          NOT NULL,
    [TreatDesc] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Treatid] ASC)
);

