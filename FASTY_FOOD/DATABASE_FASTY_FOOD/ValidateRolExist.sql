USE [FASTY_FOOD]
GO
/****** Object:  StoredProcedure [dbo].[ValidateRolExist]    Script Date: 21/2/2025 21:55:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jean Intriago
-- Create date: 19/02/2025
-- Description:	Validar si existe el rol
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[ValidateRolExist] --EXEC [ValidateRolExist] 'ADMIN'
	@rolName varchar(50)
AS
BEGIN
	SELECT COUNT(*) FROM Rol Where rolname = @rolName;
END
