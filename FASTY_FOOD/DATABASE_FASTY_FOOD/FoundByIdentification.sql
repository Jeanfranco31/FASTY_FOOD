
-- =============================================
-- Author:		Jean Intriago
-- Create date: 22-01-2025
-- Description:	Found Company by personal id
-- =============================================
CREATE OR ALTER PROCEDURE FoundByIdentification
	@identification VARCHAR(10)
AS
BEGIN
	SELECT
		u.id,
		u.identification,
		u.full_name,
		u.username,
		c.fullName,
		u.status_User
	FROM Users u
	INNER JOIN Company c ON c.id = u.id_Company
	WHERE u.identification = @identification
END
GO

