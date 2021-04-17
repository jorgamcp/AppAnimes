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
        private List<HistorialViewModel> historialIQ;
        
        public HistorialModel(ILogger<IndexModel> logger, AppAnimesDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            else
            {

               
                //  historialIQ = await (
                //                    from h in _context.Historial
                //                    join t in _context.Temporadas on h.IdAnimeNavigation.IdAnime equals t.IdAnime
                //                    join a in _context.Animes on h.IdAnime equals a.IdAnime  into hat
                //                   from resultado in hat.DefaultIfEmpty()
                //                    where h.IdAnime == id 
                //                    select new HistorialViewModel()
                //                    {
                //                        id_historial = h.IdHistorial,
                //                        id_temp = h.IdTemp,
                //                        NombreAnimeTemporada = h.IdAnimeNavigation.Nombre + " " + t.NombreTemporada,
                //                        FechaInicio = h.FechaInicio,
                //                        FechaFin = h.FechaFin,
                                        
                //                    }).AsNoTracking().ToListAsync();
            
              
                historialIQ = await(
                    from h in _context.Historial
                    where h.IdAnime == id 
                    select new HistorialViewModel{
                        id_historial = h.IdHistorial,
                        id_temp = h.IdTemp,
                        NombreAnimeTemporada = h.IdAnimeNavigation.Nombre,
                        FechaInicio  = h.FechaInicio,
                        FechaFin = h.FechaFin
                    }).ToListAsync();
                



            }

 

            historialViewModel = historialIQ;
            return Page();
        }


    }
}

