-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		jorge
-- Create date: 01/06/2021
-- Description:	
-- =============================================
CREATE OR ALTER TRIGGER dbo.AuditarEstado_Viendo_Visto
   ON  dbo.Temporadas 
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	DECLARE @estado_anterior varchar(100) = (select estado from deleted);
	DECLARE @estado_posterior varchar(100) = (select estado from inserted);
	DECLARE @AnimeId int = (select AnimeId from inserted);
	DECLARE @TemporadaId int = (Select TemporadaId from inserted);

	if update(estado) 
		if @estado_anterior = 'Visto'
			insert into Historial(AnimeId,TemporadaId,FechaInicio,FechaFin,VistoEn,AnyoVisto) VALUES();
		else
	end;
END
GO
