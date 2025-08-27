USE [FASTY_FOOD]
GO
/****** Object:  StoredProcedure [dbo].[GetRols]    Script Date: 21/2/2025 21:52:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jean Intriago
-- Create date: 19/02/2025
-- Description:	Obtener Todos Los Roles
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GetRols]
AS
BEGIN
	SELECT id, rolname, CONVERT(varchar,dateRegister), statusRol FROM Rol

END
