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
    public class CrearAnimeTemporadaModel : PageModel
    {
        private readonly AppAnimesDBContext _context;

        // Enlace de Modelo
        [BindProperty]
        public Anime Anime { get; set; }

        // Enlace de Modelo
        [BindProperty]
        public Temporada Temporada { get; set; }


        public CrearAnimeTemporadaModel(AppAnimesDBContext context)
        {
            _context = context; // Dependency Injection
        }

        public IActionResult OnGet()
        {
            

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() // async. Clase Task
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Anime animeNuevo = new Anime(); // Nuevo Anime que se va a insertar en la base de datos
            Temporada temporada = new Temporada(); // Nueva Temporada que se va a insertar en la tabla temporadas.
            HashSet<Temporada> temporadas = new HashSet<Temporada>();

            animeNuevo = Anime;
            temporada.Tipo = "SERIE"; // ES SERIE
            temporada = Temporada;
            temporadas.Add(temporada);
            animeNuevo.Temporadas = temporadas;
            await _context.Animes.AddAsync(animeNuevo); // Guarda tanto Anime como Temporada

            await _context.SaveChangesAsync();

            return RedirectToPage("./AnimesTemporadas");
        }
    }
}
