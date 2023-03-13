CREATE TABLE [dbo].[People]
(
  [Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL DEFAULT '', 
    [LastName] NVARCHAR(50) NOT NULL DEFAULT '', 
    [DateOfBirth] DATE NULL, 
    [DependentEmployeeId] INT NULL, 
    CONSTRAINT [FK_People_ToTable] FOREIGN KEY ([DependentEmployeeId]) REFERENCES [Employee]([Id])
)
