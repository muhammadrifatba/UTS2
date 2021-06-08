CREATE TABLE [dbo].[AppointmentTab] (
    [Apid]      INT          IDENTITY (500, 1) NOT NULL,
    [Patient]   VARCHAR (50) NOT NULL,
    [Treatment] VARCHAR (50) NOT NULL,
    [ApDate]    DATE         NOT NULL,
    [ApTime]    TIME (7)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Apid] ASC)
);

