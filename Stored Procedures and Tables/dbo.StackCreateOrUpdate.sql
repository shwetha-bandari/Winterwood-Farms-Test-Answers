CREATE PROC [dbo].[StackCreateOrUpdate]
	@StackId int,
	@Fruit varchar(10),
	@Variety varchar(30),
	@Quantity int,
	@UserId int
	AS
BEGIN
	IF(@StackId =0 )
		BEGIN
			INSERT INTO Stack(Fruit,Variety,Quantity,UserId)
			VALUES(@Fruit,@Variety,@Quantity,@UserId)
		END
	ELSE
		BEGIN
			UPDATE Stack
			SET
			Fruit = @Fruit,
			Variety = @Variety,
			Quantity = @Quantity,
			UserId = @UserId
			WHERE StackId =@StackId
		END
	END