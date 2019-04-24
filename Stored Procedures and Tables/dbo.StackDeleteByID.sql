CREATE PROC [dbo].[StackDeleteByID]
	@StackId int
	AS
	BEGIN
	DELETE FROM Stack
	WHERE StackId=@StackId
	END