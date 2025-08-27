
-- =============================================
-- Author:		JEAN INTRIAGO
-- Create date: 20-02-2024
-- Description:	Get rol by status
-- =============================================
CREATE OR ALTER PROCEDURE GetRolsByStatus
	@statusRol BIT,
	@rolName VARCHAR(50)
AS
BEGIN
	IF @statusRol <> '' AND @rolName <> ''
	BEGIN
		SELECT 
			id,
			rolname
		FROM Rol
		WHERE statusRol = @statusRol and rolname <> 'SUPER_ADMINISTRADOR' AND rolname = @rolName
	END

	IF @statusRol <> ''
	BEGIN
		SELECT 
			id,
			rolname
		FROM Rol
		WHERE statusRol = @statusRol and rolname <> 'SUPER_ADMINISTRADOR'
	END

	IF @rolName <> ''
	BEGIN
		SELECT 
			id,
			rolname
		FROM Rol
		WHERE rolname <> 'SUPER_ADMINISTRADOR' AND rolname = @rolName
	END
END
GO

