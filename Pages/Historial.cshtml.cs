using AppAnimes.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppAnimes.Pages
{
    public class HistorialModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppAnimesDBContext _context;
        public IList<HistorialViewModel> historialViewModel { get; set; }

        public HistorialModel(ILogger<IndexModel> logger, AppAnimesDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // var animesIQ
            //          = await (
            //             from a in _context.Animestests 
            //             join h in _context.Historialtests on a equals h.IdAnimeNavigation into hanimes
            //             join t in _context.Temporadastests on a equals t.IdAnimeNavigation into tanimes 
            //             from ha in hanimes.DefaultIfEmpty()
            //          select new HistorialViewModel(){
            //              id_historial = ha.IdHistorial,
            //              id_temp = ha.IdTemp,
            //              NombreAnimeTemporada = a.Nombre + " " + ha.

            //          }).ToListAsync();
            if(id == null){
                return NotFound();
            }
            var historialIQ =
                    await (
                        from h in _context.Historial
                        join a in _context.Animes on h.IdAnime equals a.IdAnime into HistorialAnimes
                        join t in _context.Temporadas on h.IdAnime equals t.IdAnime into HistorialAnimesTemp
                        from hat in HistorialAnimesTemp.DefaultIfEmpty()
                        select new HistorialViewModel()
                        {
                            id_historial = h.IdHistorial,
                            id_temp = h.IdTemp,
                            NombreAnimeTemporada = hat.IdAnimeNavigation.Nombre + " " + hat.NombreTemporada,
                            FechaInicio = h.FechaInicio,
                            FechaFin = h.FechaFin
                        }
                    ).ToListAsync();
            
            historialViewModel = historialIQ;
            return Page();
        }
    }
}
