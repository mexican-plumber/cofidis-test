CREATE PROCEDURE [dbo].[GetCreditLimit]
	@income numeric(18,2) = 0
AS
    SELECT
	CASE
        WHEN @income <= 1000 THEN 1000.00
        WHEN @income > 1000 AND @income <= 2000 THEN 2000.00
        WHEN @income > 2000 THEN 5000.00
    END;
