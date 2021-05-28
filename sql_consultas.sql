CREATE OR ALTER PROCEDURE QueryAllTablesProc AS
    SELECT * FROM dbo.Animes ORDER BY id_anime asc;
    SELECT * FROM dbo.Temporadas ORDER BY id_anime asc;
    SELECT * FROM dbo.Historial ORDER BY id_anime asc;
GO

EXEC dbo.QueryAllTablesProc;
go