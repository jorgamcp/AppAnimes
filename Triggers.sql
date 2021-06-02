exec QueryAllTablesProc;
GO

create   trigger [dbo].[auditar_cambio_viendo_visto] 
on [dbo].[Temporadas]
after UPDATE
as
begin
	DECLARE @estado_anterior varchar(100) =(select estado from deleted);
	DECLARE @estado_posterior varchar(100) = (select estado from inserted);
	DECLARE @id_anime int = (select AnimeId from deleted);
	DECLARE @id_temporada int = (select TemporadaId from deleted);
	if update(estado) 
		begin

			if @estado_anterior = 'Visto' 
				insert into historial(AnimeId,TemporadaId,FechaInicio,FechaFin,VistoEn,AnyoVisto) values(@id_anime,@id_temporada,GETDATE(),NULL,NULL,NULL);			
			else
				update historial set fechaFin = GETDATE() where FechaFin is null and AnimeId= @id_anime and TemporadaId = @id_temporada;
				PRINT Concat('AnimeId',@id_anime); 
				PRINT Concat('TemporadaId',@id_temporada); 
				PRINT Concat('ESTADO anterior',@estado_anterior);
				PRINT Concat('Estado POSTERIOR',@estado_posterior);
		end;
	end;
GO

ALTER TABLE [dbo].[temporadas] ENABLE TRIGGER [auditar_cambio_viendo_visto]
GO




create   trigger [dbo].[auditar_nuevo_registro]
on [dbo].[temporadas]
after INSERT
as
begin
	DECLARE @id_anime int = (select AnimeId from inserted);
	DECLARE @id_temporada int = (select TemporadaId from inserted);
	
	insert into historial(AnimeId,TemporadaId,FechaInicio,FechaFin,VistoEn,AnyoVisto)
	values (@id_anime,@id_temporada,GETDATE(),null,null,null);

	PRINT('Se registro una temporada nueva en temporadas insertando nuevo registro');
	end;
GO

ALTER TABLE [dbo].[temporadas] ENABLE TRIGGER [auditar_nuevo_registro]
GO