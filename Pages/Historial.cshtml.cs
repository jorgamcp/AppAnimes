using AppAnimes.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppAnimes.Pages
{
    public class HistorialModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger; // Para Usar Log en la consola
        private readonly AppAnimesDBContext _context; // Contexto de la BBDD Representa una conexion a SQLSERVER
        public IList<HistorialViewModel> historialViewModel { get; set; } // Vista-Modelo Patron MVVM Lista que contiene el Modelo que se mostrará al usuario juntando informacion de distintas tablas del Modelo
        private List<HistorialViewModel> historialIQ; // Query LINQ IQ -> IQueryAble https://docs.microsoft.com/es-es/dotnet/api/system.linq.iqueryable?view=net-5.0 Es una Lista

        // Dependency Injection DI Inyeccion de dependencias  . Ioc Inversion of Control
        public HistorialModel(ILogger<IndexModel> logger, AppAnimesDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            // Si el id es nulo es decir he dado clic en la pagina historial del navbar muestrame toda la tabla historial y no filtres por id anime
            if (id == null)
            {
                historialIQ = await (
                                from historial in _context.Historial
                                select new HistorialViewModel()
                                {
                                    id_historial = historial.IdHistorial,
                                    id_temp = historial.TemporadaId,
                                    NombreAnimeTemporada = historial.Anime.Nombre + " " + historial.Temporada.NombreTemporada,
                                    FechaInicio = historial.FechaInicio,
                                    FechaFin = historial.FechaFin,

                                }).AsNoTracking().OrderBy(h => h.FechaFin.HasValue).ToListAsync();
            }
            else
            {

                // He dado clic en el Boton de la tabla de 'Ver Historico', muestrame el historico solo de ese anime, paso el id con un where
                historialIQ = await (
                               from historial in _context.Historial
                               where historial.AnimeId == id
                               select new HistorialViewModel()
                               {
                                   id_historial = historial.IdHistorial,
                                   id_temp = historial.TemporadaId,
                                   NombreAnimeTemporada = historial.Anime.Nombre + " " + historial.Temporada.NombreTemporada,
                                   FechaInicio = historial.FechaInicio,
                                   FechaFin = historial.FechaFin,

                               }).AsNoTracking().ToListAsync();



            }



            historialViewModel = historialIQ;

            return Page();
        }




    }
}

