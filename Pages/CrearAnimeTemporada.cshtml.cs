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
        // Enlace de Modelo
        [BindProperty]
        public Historial Historial { get; set; }

        public CrearAnimeTemporadaModel(AppAnimesDBContext context)
        {
            _context = context; // Dependency Injection
        }

        public IActionResult OnGet()
        {


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Temporada temporada) // async. Clase Task
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Anime animeNuevo = Anime; // Nuevo Anime que se va a insertar en la base de datos
            Temporada temporadaInsertar = new Temporada { Anime = animeNuevo, NumeroTemporada = Temporada.NumeroTemporada, NombreTemporada = Temporada.NombreTemporada, Estado = Temporada.Estado, Tipo = Temporada.Tipo, TemporadaEstreno = Temporada.TemporadaEstreno }; // Nueva Temporada que se va a insertar en la tabla temporadas.
            Historial historial = Historial; // Nuevo registro que se va a insertar en Historial.
                                             // animeNuevo = Anime;
                                             // temporada.Tipo = "SERIE"; // ES SERIE
                                             // temporada = Temporada;


            animeNuevo.Temporadas.Add(temporadaInsertar);
            animeNuevo.Historials.Add(new Historial { IdHistorial = 0, AnimeId = animeNuevo.AnimeId, Temporada = temporadaInsertar, FechaInicio = DateTime.Now, FechaFin = null, VistoEn = Historial.VistoEn, AnyoVisto = null });


            await _context.Animes.AddAsync(animeNuevo); // Guarda tanto Anime como Temporada




            await _context.SaveChangesAsync();




            return RedirectToPage("./AnimesTemporadas");
        }
    }
}
