CREATE TABLE [dbo].[PasTab] (
    [Patid]        INT           IDENTITY (100, 1) NOT NULL,
    [PatName]      VARCHAR (50)  NOT NULL,
    [PatHp]        VARCHAR (50)  NOT NULL,
    [PatAddress]   VARCHAR (50)  NOT NULL,
    [PatDOB]       DATE          NOT NULL,
    [PatGender]    VARCHAR (10)  NOT NULL,
    [PatAllergies] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Patid] ASC)
);

