USE [BDBimManager]
GO
/****** Object:  StoredProcedure [dbo].[spPresupuestoCategoriaActualizar]    Script Date: 5/10/2024 15:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE     PROCEDURE [dbo].[spPresupuestoCategoriaActualizar]
	@PresupuestoCategoriaID smallInt,
	@Nombre nvarchar(250), 
	@Observaciones nvarchar(MAX),
	@Porcentaje tinyint,
	@PadrePresupuestoCategoriaID smallint
AS
BEGIN
	UPDATE PresupuestoCategoria
	SET Nombre = @Nombre,
		Observaciones = @Observaciones,
		Porcentaje = @Porcentaje,
		PadrePresupuestoCategoriaID = @PadrePresupuestoCategoriaID 
	WHERE PresupuestoCategoriaID = @PresupuestoCategoriaID
END
GO
/****** Object:  StoredProcedure [dbo].[spPresupuestoCategoriaBuscarTodos]    Script Date: 5/10/2024 15:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[spPresupuestoCategoriaBuscarTodos]
AS
BEGIN
	SELECT *
	FROM PresupuestoCategoria
	ORDER BY Nombre
END
GO
/****** Object:  StoredProcedure [dbo].[spPresupuestoCategoriaInsertar]    Script Date: 5/10/2024 15:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE     PROCEDURE [dbo].[spPresupuestoCategoriaInsertar]
	@Nombre nvarchar(250), 
	@Observaciones nvarchar(MAX),
	@Porcentaje tinyint,
	@PadrePresupuestoCategoriaID smallint
AS
BEGIN
	INSERT INTO PresupuestoCategoria (Nombre, Observaciones, Porcentaje, PadrePresupuestoCategoriaID)
	VALUES (@Nombre, @Observaciones, @Porcentaje, @PadrePresupuestoCategoriaID)

	SELECT @@IDENTITY
END
GO
