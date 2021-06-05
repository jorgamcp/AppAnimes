using AppAnimes.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AppAnimesNuevo;

namespace AppAnimes.Pages
{
    public class HistorialModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppAnimesDBContext _context;

        // public IList<HistorialViewModel> HistorialAnimesTemporadas { get; set; }
        public PaginatedList<HistorialViewModel> HistorialAnimesTemporadasPaginated { get; set; }

        [BindProperty(SupportsGet = true)]//Enlace Modelo Soporta GET
        public string searchString { get; set; } // cadena busqueda
        public HistorialModel(ILogger<IndexModel> logger, AppAnimesDBContext context)
        {
            _logger = logger;
            _context = context;

        }


        public async Task<IActionResult> OnGetAsync(int? pageIndex,int? id)
        {

            // Paginacion
            var pageSize = 100;
            if (pageIndex <= 0)
            {
                return RedirectToPage("Historial");
            }
            ViewData["id"] = id;
          
            if(id != null) // Si hay un filtro de anime filtramos.
            {
                HistorialAnimesTemporadasPaginated = await PaginatedList<HistorialViewModel>.CreateAsync(
              from historial in _context.Historial
              where historial.AnimeId == id
              select new HistorialViewModel()
              {
                  idHistorial = historial.IdHistorial,
                  id_anime = historial.Anime.AnimeId,
                  id_temporada = historial.TemporadaId,
                  NumeroTemporada = historial.Temporada.NumeroTemporada,
                  NombreAnimeTemporada = historial.Anime.Nombre + " " + historial.Temporada.NombreTemporada,
                  fechaInicio = historial.FechaInicio,
                  fechaFin = historial.FechaFin,
                  VistoEn = historial.VistoEn
              }, pageIndex ?? 1, pageSize);

                ViewData["nombreAnimeFiltrado"] = HistorialAnimesTemporadasPaginated[0].NombreAnimeTemporada;
            }
            else
            {
                HistorialAnimesTemporadasPaginated = await PaginatedList<HistorialViewModel>.CreateAsync(
              from historial in _context.Historial
              select new HistorialViewModel()
              {
                  idHistorial = historial.IdHistorial,
                  id_anime = historial.Anime.AnimeId,
                  id_temporada = historial.TemporadaId,
                  NumeroTemporada = historial.Temporada.NumeroTemporada,
                  NombreAnimeTemporada = historial.Anime.Nombre + " " + historial.Temporada.NombreTemporada,
                  fechaInicio = historial.FechaInicio,
                  fechaFin = historial.FechaFin,
                  VistoEn = historial.VistoEn
              }, pageIndex ?? 1, pageSize);
            }


          


            // BUSQUEDA
            if (!string.IsNullOrEmpty(searchString))
            {
                HistorialAnimesTemporadasPaginated = await PaginatedList<HistorialViewModel>.CreateAsync(
                from historial in _context.Historial

                orderby historial.FechaFin
                where historial.Anime.Nombre.Contains(searchString) || historial.Temporada.NombreTemporada.Contains(searchString) || historial.Anime.NombreIngles.Contains(searchString) // Nombre del anime o el nombre de temporada.
                select new HistorialViewModel()
                {
                    idHistorial = historial.IdHistorial,
                    id_anime = historial.Anime.AnimeId,
                    id_temporada = historial.TemporadaId,
                    NumeroTemporada = historial.Temporada.NumeroTemporada,
                    NombreAnimeTemporada = historial.Anime.Nombre + " " + historial.Temporada.NombreTemporada,
                    fechaInicio = historial.FechaInicio,
                    fechaFin = historial.FechaFin,
                    VistoEn = historial.VistoEn

                }, pageIndex ?? 1, pageSize);
            }


            /*
              List<HistorialViewModel> historialIQ = await
                 (
                     from historial in _context.Historials
                     select new HistorialViewModel()
                     {
                         idHistorial = historial.IdHistorial,
                         id_anime = historial.Anime.AnimeId,
                         id_temporada = historial.TemporadaId,
                         NumeroTemporada = historial.Temporada.NumeroTemporada,
                         NombreAnimeTemporada = historial.Anime.Nombre + " " + historial.Temporada.NombreTemporada,
                         fechaInicio = historial.FechaInicio,
                         fechaFin = historial.FechaFin,
                         fechaPausa = historial.FechaPausa,
                         VistoEn = historial.VistoEn
                     }).AsNoTracking().ToListAsync();
             HistorialAnimesTemporadas = historialIQ;
             */

            // Ordenar por fecha descentente : .OrderByDescending(h => h.fechaInicio)



            return Page();
        }

    }

}


