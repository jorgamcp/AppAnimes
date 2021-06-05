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
        public AnimesTemporadasViewModel animesTemporadasViewModel { get; set; }

        [BindProperty(SupportsGet = true)]//Enlace Modelo Soporta GET
        public string searchString { get; set; } // cadena busqueda
        public AnimesTemporadasModel(ILogger<IndexModel> logger, AppAnimesDBContext context)
        {
            _logger = logger;
            _context = context;

        }


        public async Task<IActionResult> OnGetAsync(int? pageIndex)
        {
            int pageSize = 6; // Tamaño maximo  de filas que tiene la tabla.
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


            // Busqueda

            if (!string.IsNullOrEmpty(searchString))
            {
                animesTemporadasPaginated = await PaginatedList<AnimesTemporadasViewModel>.CreateAsync(
                   from a in _context.Animes
                   join t in _context.Temporadas on a equals t.Anime into atemp
                   from at in atemp.DefaultIfEmpty()
                   orderby a.Nombre
                   where at.Anime.Nombre.Contains(searchString) || at.NombreTemporada.Contains(searchString) || a.NombreIngles.Contains(searchString)

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
            }


            return Page();
        }
        public IActionResult OnGetFind(int id)
        {
            var temporada = _context.Temporadas.Find(id);
            //string anime = _context.Animes.Where(a => a.AnimeId == temporada.AnimeId).Select( a => a.Nombre).FirstOrDefault();
            Anime anime = _context.Animes.Where(a => a.AnimeId == temporada.AnimeId).FirstOrDefault();
            
            temporada.Anime = anime;
            
            return new JsonResult(temporada);
        }
        public async Task<IActionResult> OnPostCambiarEstado(int id,string estado)
        {
            var temporada = _context.Temporadas.Find(id);

            temporada.Estado = estado;

            _context.Temporadas.Update(temporada);
            await _context.SaveChangesAsync();
            return RedirectToPage("./AnimesTemporadas");
        }


    }
}

