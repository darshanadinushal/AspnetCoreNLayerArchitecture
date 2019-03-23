CREATE TABLE [com].[App_T_Department]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(150) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 0, 
	[CreatedDate] DATETIME2 NOT NULL, 
    [CreatedBy] NVARCHAR(128) NOT NULL, 
    [UpdatedDate] DATETIME2 NULL, 
    [UpdatedBy] NVARCHAR(128) NULL
)
