using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using aspnetcoreapp.Models;
using System.Text.Json;
using AppAnimes.Models;

namespace aspnetcoreapp.Pages.Animes
{
    public class TemporadasModel : PageModel
    {
        private readonly AppAnimesDBContext _context;
        private const string ANIME_TIPO_SERIE = "SERIE";
        public TemporadasModel(AppAnimesDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            var x = (from a in _context.Animes
                     join t in _context.Temporadas on a.AnimeId equals t.AnimeId into atemp
                     from at in atemp
                     where at.Tipo == ANIME_TIPO_SERIE
                     select new SelectListItem
                     {
                         Value = at.AnimeId.ToString(),
                         Text = at.Anime.Nombre
                     }).Distinct();


            // ViewData["AnimeId"] = new SelectList(_context.Animes, "AnimeId", "Nombre");
            ViewData["AnimeId"] = x;




            return Page();
        }

        public IActionResult OnGetObtenerUltimoNumeroTemporada(int? id_anime)
        {
            if (id_anime == null)
            {
                return new JsonResult("error");
            }

            /* var numeroTemporada = from animes in _context.Animes
                                   join temporadas in _context.Temporadas on animes equals temporadas.Anime into animestempo
                                   from at in animestempo.DefaultIfEmpty()
                                   select animes.Temporada.First();*/

            var numeroTemporada = (from t in _context.Temporadas
                                   where t.AnimeId == id_anime

                                   select t.NumeroTemporada);



            if (numeroTemporada == null)
            {
                return new JsonResult("Error Ani_0001");
            }


            return new JsonResult(numeroTemporada);
        }


        [BindProperty]
        public Temporada Temporada { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var x = (from a in _context.Animes
                         join t in _context.Temporadas on a.AnimeId equals t.AnimeId into atemp
                         from at in atemp
                         where at.Tipo == ANIME_TIPO_SERIE
                         select new SelectListItem
                         {
                             Value = at.AnimeId.ToString(),
                             Text = at.Anime.Nombre
                         }).Distinct();


                // ViewData["AnimeId"] = new SelectList(_context.Animes, "AnimeId", "Nombre");
                ViewData["AnimeId"] = x;

                return Page();
            }

            _context.Temporadas.Add(Temporada);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}


