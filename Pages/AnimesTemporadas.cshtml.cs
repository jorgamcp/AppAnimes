using AppAnimes.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AppAnimesNuevo;

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

        // public IList<AnimesTemporadasViewModel> animesTemporadasViewModels { get; set; }
        public PaginatedList<AnimesTemporadasViewModel> animesTemporadasPaginated { get; set; }

        public AnimesTemporadasModel(ILogger<IndexModel> logger, AppAnimesDBContext context)
        {
            _logger = logger;
            _context = context;

        }


        public async Task<IActionResult> OnGetAsync(int? pageIndex)
        {
            var pageSize = 10; // Tamaño maximo  de filas que tiene la tabla.
            // si me introducen un pageindex < 1 redirigimos al index de AnimesTemporadas
            if (pageIndex <= 0)
            {
                return RedirectToPage("AnimesTemporadas");

            }

            animesTemporadasPaginated = await PaginatedList<AnimesTemporadasViewModel>.CreateAsync(
                     from a in _context.Animes
                     join t in _context.Temporadas on a equals t.Anime into atemp
                     from at in atemp.DefaultIfEmpty()
                     orderby a.Nombre
                     select new AnimesTemporadasViewModel()
                     {
                         id_anime = a.AnimeId,
                         id_temporada = at.TemporadaId,
                         NumeroTemporada = at.NumeroTemporada,
                         NombreAnimeTemporada = a.Nombre + " " + at.NombreTemporada,
                         genero = a.Genero,
                         nombreEnIngles = at.Anime.NombreIngles,
                         estado = at.Estado,
                         tipo = at.Tipo,
                         temporada_estreno = at.TemporadaEstreno

                     }, pageIndex ?? 1, pageSize);





            return Page();
        }


    }
}

