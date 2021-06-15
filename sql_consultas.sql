select * from temporadas;
select * from Animes;

 /*Obtener Cuantas temporadas tiene un anime*/

 SELECT A.Nombre,A.AnimeId, count(*) as "Nº temporadas totales" from Animes A join Temporadas T on (A.AnimeId = T.AnimeId) group by A.AnimeId,A.Nombre,T.AnimeId order by A.Nombre asc;
go