CREATE TABLE [com].[App_T_Employee]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[App_T_DepartmentId] INT NOT NULL,
	[FirstName] NVARCHAR(256) NOT NULL, 
    [LastName] NVARCHAR(256) NULL,
	[Address] NVARCHAR(256) NULL,
	[Email] NVARCHAR(256) NOT NULL,
	[MobileNo] NVARCHAR(10) NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT 0, 
	[CreatedDate] DATETIME2 NOT NULL, 
    [CreatedBy] NVARCHAR(128) NOT NULL, 
    [UpdatedDate] DATETIME2 NULL, 
    [UpdatedBy] NVARCHAR(128) NULL,
	CONSTRAINT FK_DepartmentEmployeeId FOREIGN KEY (App_T_DepartmentId)	REFERENCES  [com].App_T_Department(Id),
)
