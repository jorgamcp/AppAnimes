using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppAnimes.Models;

namespace AppAnimes.Pages.Animes
{
    public class EliminarAnimeModel : PageModel
    {
        private readonly AppAnimesDBContext _context;
        [BindProperty]
        public Anime Anime { get; set; }

        // Enlace de Modelo
        [BindProperty]
        public Temporada Temporada { get; set; }
        // Enlace de Modelo
        [BindProperty]
        public Historial Historial { get; set; }

        public EliminarAnimeModel(AppAnimesDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? TemporadaId, int? AnimeId)
        {
            if (AnimeId == null)
            {
                return NotFound();
            }
            Temporada = await _context.Temporadas.FindAsync(TemporadaId);
            Anime = await _context.Animes.FindAsync(AnimeId);

            int numeroTemporadas = await _context.Temporadas.Where(a => a.AnimeId == AnimeId).CountAsync();

            int x = 0;
            ViewData["NombreAnime"] = Anime.Nombre;
            ViewData["NombreTemporada"] = Temporada.NombreTemporada;
            ViewData["NumeroTemporada"] = Temporada.NumeroTemporada;


            return Page();
        }


        

        public async Task<IActionResult> OnPostAsync(int? AnimeId) // async. Clase Task
        {
            Anime = await _context.Animes.FindAsync(AnimeId);
            if (Anime != null)
            {
                _context.Animes.Remove(Anime);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }
            return  RedirectToPage("./AnimesTemporadas");
        }

    }

}