CREATE TABLE [dbo].[tblDoffed] (
    [rollID]  INT             IDENTITY (1, 1) NOT NULL,
    [rollNo]  VARCHAR (255)   NULL,
    [LOOMSNO] VARCHAR (255)   NULL,
    [mesh]    VARCHAR (255)   NULL,
    [width]   VARCHAR (255)   NULL,
    [length]  DECIMAL (20, 2) NULL,
    [weight]  DECIMAL (20, 2) NULL,
    [denier]  VARCHAR (255)   NULL,
    [COLOR]   VARCHAR (255)   NULL,
    [doffer]  VARCHAR (255)   NULL,
    [status]  VARCHAR (255)   NULL,
    [BIONO]   VARCHAR (255)   NULL
);

