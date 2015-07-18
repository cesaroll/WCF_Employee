Create Table Employee
(
	Id int,
	Name nvarchar(50),
	Gender nvarchar(50),
	DateOfBirth datetime
)
GO

Insert Into Employee values (1, 'Mark', 'Male', '10/10/1980')
Insert Into Employee values (1, 'Mary', 'Female', '11/10/1981')
Insert Into Employee values (1, 'John', 'Male', '8/20/1985')
GO

Create Procedure spGetEmployee
@Id int
As
Begin
	Select Id, Name, Gender, DateOfBirth
	From Employee
	Where Id = @Id
End
GO

Create Procedure spSaveEmployee
@Id int,
@Name nvarchar(50),
@Gender nvarchar(50), 
@DateOfBirth DateTime
As
Begin
	Insert Into Employee
	Values (@Id, @Name, @Gender, @DateOfBirth)
End
GO