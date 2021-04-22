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

    /*
        Clase que actua como "Controlador" de Razor Pages 
        Se hace la conexion a SQLServer usando la inyeccion de dependencias (DI) en el constructor
        
        El metodo OnGetAsync devuleve la lista de los Animes junto con el nombre de las temporadas 
        Como consultamos una bbdd en este caso SQL Server, el metodo es asincronico y debe tener aysnc/await 

        Consultamos con Language Integrated Query (LINQ) a dbcontext de la aplicacion 
        y generamos un nuevo objeto que será lo que verá el usuario en la vista Razor Pages 
        llamado AnimesTemporadasViewModel que contiene datos tanto de la tabla Animestest como de la tabla TemporadasTest en una unica View o Vista.
    
    */
    public class AnimesTemporadasModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppAnimesDBContext _context;

        public IList<AnimesTemporadasViewModel> animesTemporadasViewModels { get; set; }


        public AnimesTemporadasModel(ILogger<IndexModel> logger, AppAnimesDBContext context)
        {
            _logger = logger;
            _context = context;

        }


        public async Task<IActionResult> OnGetAsync()
        {
            
            
            var animesIQ
                     = await (from a in _context.Animes
                              join t in _context.Temporadas  on a equals t.IdAnimeNavigation into atemp
                              from at in atemp.DefaultIfEmpty()  
                              orderby a.Nombre
                              select new AnimesTemporadasViewModel()
                              {
                                  id_anime = a.IdAnime,
                                  id_temporada = at.IdTemporada,
                                  NombreAnimeTemporada = a.Nombre + " " + at.NombreTemporada,
                                  genero = a.Genero,
                                  nombreEnIngles = at.IdAnimeNavigation.NombreEnIngles,
                                  estado = at.Estado,
                                  tipo = at.Tipo,
                                  temporada_estreno = at.TemporadaEstreno

                              }).ToListAsync();

            // _logger.LogInformation(animesIQ.ToList().ToString());
            animesTemporadasViewModels = animesIQ;



  



            return Page();
        }


    }
}

