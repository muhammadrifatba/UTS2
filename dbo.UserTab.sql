CREATE TABLE [dbo].[UserTab] (
    [Ud]    INT          IDENTITY (1, 1) NOT NULL,
    [Uname] VARCHAR (50) NOT NULL,
    [Upass] VARCHAR (50) NOT NULL,
    [Uhp]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Ud] ASC)
);

