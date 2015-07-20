/****** Script for SelectTopNRows command from SSMS  ******/
Truncate Table Employee
GO

SELECT TOP 1000 *
  FROM [WCF].[dbo].[Employee]
  GO

Alter Procedure spGetEmployee
@Id int
As
Begin
	Select Id, Name, Gender, DateOfBirth, EmployeeType,
			AnnualSalary, HourlyPay, HoursWorked
	From Employee
	Where Id = @Id
End
GO

Alter Procedure spSaveEmployee
@Id int,
@Name nvarchar(50),
@Gender nvarchar(50), 
@DateOfBirth DateTime,
@EmployeeType int,
@AnnualSalary decimal(18,2) = 0,
@HourlyPay decimal(18,2) = 0,
@HoursWorked int = 0
As
Begin
	Insert Into Employee
	Values (@Id, @Name, @Gender, @DateOfBirth, @EmployeeType, 
			@AnnualSalary, @HourlyPay, @HoursWorked)
End
GO


Insert Into Employee values (1, 'Mark', 'Male', '10/10/1980')
Insert Into Employee values (1, 'Mary', 'Female', '11/10/1981')
Insert Into Employee values (1, 'John', 'Male', '8/20/1985')