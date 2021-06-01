using AppAnimes.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
 

namespace AppAnimes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppAnimesDBContext _context;



        public IndexModel(ILogger<IndexModel> logger, AppAnimesDBContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IList<Anime> Anime { get; set; }
        public IList<Temporada> Temporadas { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {


            IQueryable<Anime> animesIQ = from a in _context.Animes select a;
            IQueryable<Temporada> temporadasIQ = from t in _context.Temporadas select t;


            Anime = await animesIQ.AsNoTracking().ToListAsync();
            Temporadas = await temporadasIQ.AsNoTracking().ToListAsync();
            return Page();
        }

         public IActionResult OnGetObtenerNombresAnimes(string term)
        {
            var animesNombres = _context.Animes.Where(a => a.Nombre.StartsWith(term)).Select(a => a.Nombre).ToList();

            return new JsonResult(animesNombres);
        }

        public IActionResult OnGetObtenerTodosDatosAnime(string nombre)
        {
          //  List<Anime> datoAnime = _context.Animes.Where(a => a.Nombre.StartsWith(nombre)).Include(a => a.Temporadas).ToList();
            List<Anime> dato = _context.Animes.Where(a => a.Nombre.Contains(nombre)).Include(a => a.Temporadas).ToList();
            
            if(dato.Count == 0)
            {
                return new JsonResult("Not in database");
            }

            return new JsonResult(dato);
        }

        public IActionResult OnGetObtenerMaximoNumeroTemporada(string nombre)
        {
           // var maximoNumeroTemporada = _context.Temporadas.Where(t => t.NombreTemporada.Contains(nombre)).Max(a => a.NumeroTemporada);
            
            var maximoNumeroTemporada = _context.Temporadas
            .FromSqlRaw("SELECT MAX(NUMEROTEMPORADA) ").ToList();
            int x ;
            return new JsonResult(maximoNumeroTemporada); 
        }

    }
}
