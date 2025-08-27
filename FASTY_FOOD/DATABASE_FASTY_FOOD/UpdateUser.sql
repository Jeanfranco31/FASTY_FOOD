
-- =============================================
-- Author:		Jean Intriago
-- Create date: 22-01-2025
-- Description:	Update user info
-- =============================================
CREATE OR ALTER PROCEDURE UpdateUser
	@id INT,
	@identification VARCHAR(10),
	@fullname VARCHAR(150),
	@email VARCHAR(200),
	@address VARCHAR(200),
	@username VARCHAR(20),
	@companyName VARCHAR(150),
	@rolName VARCHAR(50),
	@status BIT
AS

BEGIN TRAN
BEGIN TRY
	
	UPDATE Users 
	SET
		identification = @identification,
		full_name = @fullname,
		email = @email,
		address_direction = @address,
		username = @username,
		id_Company = (SELECT id FROM Company WHERE full_name = @companyName),
		id_Rol = (SELECT id FROM Rol WHERE rolname = @rolName),
		status_User = @status
	WHERE id = @id
	COMMIT TRAN;

	SELECT
		u.id,
		u.identification,
		u.full_name,
		u.username,
		c.fullName,
		u.status_User
	FROM Users u
	INNER JOIN Company c ON c.id = u.id_Company
	WHERE u.id = @id
END TRY
BEGIN CATCH
	ROLLBACK TRAN;
END CATCH
GO 

