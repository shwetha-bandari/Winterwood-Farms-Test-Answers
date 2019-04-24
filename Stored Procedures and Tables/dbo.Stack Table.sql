CREATE TABLE [dbo].[Stack] (
	 [StackId] int IDENTITY(1,1) PRIMARY KEY,
    [Fruit]    VARCHAR (10) NULL,
    [Variety]  VARCHAR (30) NULL,
    [Quantity] INT          NULL,
   
   UserId int Foreign key REFERENCES [dbo].[User] ([UserId])
 
   )