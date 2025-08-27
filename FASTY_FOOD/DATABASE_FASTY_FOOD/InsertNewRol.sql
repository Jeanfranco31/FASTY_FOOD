USE [FASTY_FOOD]
GO
/****** Object:  StoredProcedure [dbo].[InsertNewRol]    Script Date: 21/2/2025 21:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jean Intriago
-- Create date: 19/02/2025
-- Description:	Insertar Rol
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[InsertNewRol]
	@rolName VARCHAR(50),
	@dateRegister DATETIME,
	@statusRol BIT
AS

BEGIN TRAN
BEGIN TRY
	INSERT INTO Rol(rolname,dateRegister,statusRol) VALUES (@rolName, @dateRegister, @statusRol);
	COMMIT TRAN;

	SELECT id, rolname, CONVERT(VARCHAR,dateRegister), statusRol FROM Rol where id = SCOPE_IDENTITY();

END TRY
BEGIN CATCH
	ROLLBACK TRAN;
END CATCH
