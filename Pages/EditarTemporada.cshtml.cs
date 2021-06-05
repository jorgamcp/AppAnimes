using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetcoreapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AppAnimes.Models;

namespace aspnetcoreapp.Pages.Animes
{
    public class EditarTemporadaModel : PageModel
    {
        private readonly AppAnimesDBContext _context;
        private readonly ILogger _logger; // Log info.

        public EditarTemporadaModel(AppAnimesDBContext context, ILogger<EditarTemporadaModel> logger)
        {
            _context = context;
            _logger = logger; // Log info
        }
        [BindProperty]
        public Temporada Temporada { get; set; }
        [BindProperty]
        public Anime Anime { get; set; }
        public string frase { get; set; }

        // Campo clase pageIndex
        public int? pageIndex { get; set; }

        public async Task<IActionResult> OnGetAsync(int? TemporadaId, int AnimeId, int? pageIndex) // PageIndex es para la paginacion
        {

            if (TemporadaId == null)
            {
                return NotFound();
            }

            Temporada = await _context.Temporadas.FindAsync(TemporadaId);

            Anime = await _context.Animes.FindAsync(AnimeId);



            ViewData["NombreTemporada"] = Temporada.NombreTemporada;
            ViewData["NumeroTemporada"] = Temporada.NumeroTemporada;
            ViewData["NombreAnime"] = Anime.Nombre;

            if (Temporada == null)
            {
                return NotFound();
            }

            // Paginacion
            // Si doy al link de volver, quiero volver a la lista de animes a la pagina donde YO estaba no al principio de la lista
            if (pageIndex == null)
            {
                // pero si es nulo , pues llevame a la pagina uno que le vamos a hacer
                this.pageIndex = 1;
            }
            else
            {
                // Pero si no es nulo, quiero volver a donde estaba, no a la pagina 1 del principio
                // El campo  de clase será la variable que tenga la pagina (argumento del metodo onGet).
                this.pageIndex = pageIndex;
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? temporadaId,int? AnimeId)
        {
            Temporada TemporadaActualizar = await _context.Temporadas.FindAsync(temporadaId);
            Anime animeActualizar = await _context.Animes.FindAsync(AnimeId);
            if (TemporadaActualizar == null || animeActualizar == null)
            {
                return NotFound();
            }
            else  
            {
                if(await TryUpdateModelAsync<Anime>(animeActualizar,"anime", a => a.Nombre))
                {
                    _context.ChangeTracker.DetectChanges();
                    Console.WriteLine(_context.ChangeTracker.DebugView.LongView);
                }

                if (await TryUpdateModelAsync<Temporada>(TemporadaActualizar, "temporada", t => t.NumeroTemporada, t => t.NombreTemporada, t => t.Estado, t => t.Tipo, t => t.TemporadaEstreno))
                {
                    _context.ChangeTracker.DetectChanges();

                    Console.WriteLine(_context.ChangeTracker.DebugView.LongView);

                    // if(TemporadaActualizar.Estado.Equals("Visto")) // Viendo -> Visto
                    // {   

                    //      Historial registroHistorial = await _context.Historial.FindAsync(temporadaId);

                    // }


                }
            }
            
                
             
            await _context.SaveChangesAsync();

            return RedirectToPage("./AnimesTemporadas");


           // return Page();
        }



    }
}
