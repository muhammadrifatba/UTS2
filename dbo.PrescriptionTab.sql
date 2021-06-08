CREATE TABLE [dbo].[PrescriptionTab] (
    [PrescId]   INT           IDENTITY (2000, 1) NOT NULL,
    [PrescName] VARCHAR (50)  NOT NULL,
    [TreatName] VARCHAR (50)  NOT NULL,
    [TreatCost] VARCHAR (50)  NOT NULL,
    [Medicines] VARCHAR (100) NOT NULL,
    [MedQty]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([PrescId] ASC)
);

