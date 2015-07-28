Alter Table Employee
Add City nvarchar(50)
GO

SELECT * FROM Employee

sp_helptext spGetEmployee

Alter Procedure spGetEmployee
@Id int
As
Begin
	Select Id, Name, Gender, DateOfBirth, EmployeeType,
			AnnualSalary, HourlyPay, HoursWorked, City
	From Employee
	Where Id = @Id
End

sp_helptext spSaveEmployee

ALTER Procedure spSaveEmployee
@Id int,
@Name nvarchar(50),
@Gender nvarchar(50) = null, 
@DateOfBirth DateTime,
@EmployeeType int,
@AnnualSalary decimal(18,2) = 0,
@HourlyPay decimal(18,2) = 0,
@HoursWorked int = 0,
@City nvarchar(50) = null
As
Begin
	Insert Into Employee
	Values (@Id, @Name, @Gender, @DateOfBirth, @EmployeeType, 
			@AnnualSalary, @HourlyPay, @HoursWorked, @City)
End
