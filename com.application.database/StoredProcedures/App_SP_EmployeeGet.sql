
-- =============================================
-- Author:		Darshana
-- Create date: 2019-03-24
-- Description:	Get employee details
-- =============================================
CREATE PROCEDURE [com].[App_SP_EmployeeGet] 

AS
BEGIN
	
	DECLARE @TempTable TABLE 
	(
		[EmployeeId] INT,
		[FirstName] NVARCHAR(256),
		[LastName] NVARCHAR(256),
		[Address] NVARCHAR(512),
        [Email] NVARCHAR(256),
        [MobileNo] NVARCHAR(12),
		[IsActive] bit,
		[DepartmentId] INT,
		[DepartmentName] NVARCHAR(256)
	)

	INSERT INTO @TempTable
	SELECT 
	EMP.[Id] as 'EmployeeId',
	EMP.[FirstName] as 'FirstName',
	EMP.[LastName] as 'LastName',
	EMP.[Address] as 'Address',
	EMP.[Email] as 'Email',
	EMP.[MobileNo] as 'MobileNo',
	EMP.[IsActive] as 'IsActive',
	DEP.[id] as 'DepartmentId',
	DEP.[Name] as 'DepartmentName'
	FROM  [com].App_T_Employee EMP left join  [com].App_T_Department DEP on emp.App_T_DepartmentId=dep.Id
	WHERE [EMP].IsActive=1


	SELECT 
	[EmployeeId] ,
	[FirstName] ,
	[LastName] ,
	[Address],
	[Email],
	[MobileNo],
	[IsActive],
	[DepartmentId],
	[DepartmentName]
	FROM @TempTable

END

