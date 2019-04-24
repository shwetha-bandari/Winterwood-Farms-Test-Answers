CREATE PROC [dbo].[StackViewByID]
	@StackId int
	AS
	BEGIN
	SELECT * FROM Stack
	WHERE StackId=@StackId
	END