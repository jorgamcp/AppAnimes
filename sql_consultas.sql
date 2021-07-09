select * from Animes;
select * from temporadas;

 /*Obtener Cuantas temporadas tiene un anime*/

 SELECT A.Nombre,A.AnimeId, count(*) as "Nº temporadas totales" from Animes A join Temporadas T on (A.AnimeId = T.AnimeId) group by A.AnimeId,A.Nombre,T.AnimeId order by A.Nombre asc;
go


/*Consulta Historial con nombre anime + temp*/
SELECT h.id_historial, a.AnimeId,t.NumeroTemporada, Concat(a.Nombre,' ',t.NombreTemporada) as "Nombre Anime Completo", h.FechaInicio,h.FechaFin,h.VistoEn,h.AnyoVisto from Historial h join animes a on (h.animeId=a.AnimeId)
join temporadas t on (h.TemporadaId=t.TemporadaId) where a.AnimeId=45;