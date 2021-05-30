using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AppAnimes.Models;
using AppAnimes.Pages;

namespace aspnetcoreapp.Models
{
    public class AnimeTemporadasModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppAnimesDBContext _context;

        public IList<AnimesTemporadasViewModel> animesTemporadasViewModels { get; set; }


        public AnimeTemporadasModel(ILogger<IndexModel> logger, AppAnimesDBContext context)
        {
            _logger = logger;
            _context = context;

        }


        public async Task<IActionResult> OnGetAsync()
        {

            List<AnimesTemporadasViewModel> animesIQ = await
                (from animes in _context.Animes
                 join temporadas in _context.Temporadas on animes.AnimeId equals temporadas.AnimeId into atemp
                 from at in atemp.DefaultIfEmpty()
                 orderby animes.Nombre
                 select new AnimesTemporadasViewModel
                 {

                     id_anime = animes.AnimeId,
                     id_temporada = at.NumeroTemporada,
                     NombreAnimeTemporada = at.NombreTemporada,
                     NombreAnime = at.Anime.Nombre,
                     nombreTemporada = "",
                     genero = at.Anime.Genero,
                     nombreEnIngles = at.Anime.NombreIngles,
                     estado = at.Estado,
                     temporada_estreno = at.TemporadaEstreno


                 }).AsNoTracking().ToListAsync();


            animesTemporadasViewModels = animesIQ;


            return Page();
        }
    }
}
