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


            // TODO: Comprobar que el anime que se ha insertado no existe previamente en la base de datos

            IQueryable<string> ConsultaNombreAnime = from a in _context.Animes where a.Nombre == Anime.Nombre select a.Nombre;
            IQueryable<int> ConsultaAnimeIdObtenido = from a in _context.Animes where a.Nombre == Anime.Nombre select a.AnimeId;
            IQueryable<int?> ConsultaUltimonumeroTemporadaBBDD = from temporadas in _context.Temporadas where temporadas.AnimeId == ConsultaAnimeIdObtenido.FirstOrDefault() select temporadas.NumeroTemporada;
            IQueryable<string> ConsultaTipoAnime = from temporadas in _context.Temporadas where temporadas.AnimeId == ConsultaAnimeIdObtenido.FirstOrDefault() select temporadas.Tipo;

            // Obtener los datos de las consultas LINQ si no existen en la base de datos se devuelve NULL
            string NombreAnime = ConsultaNombreAnime.FirstOrDefault();
            int AnimeIdObtenido = ConsultaAnimeIdObtenido.FirstOrDefault();



            // Si la variable NombreAnime no es null, entonces  el anime  esta en la base de datos.Caso contrario no existe en la base de datos.
            if (NombreAnime != null)
            {
                ModelState.AddModelError("Nombre", "Error ANIME DUPLICADO: El anime ya existe en la base  de datos");
            }

            // Lo que ha introducido el usuario en el formulario Es Serie ? o Es Peli?
            if (Temporada.Tipo.Equals("SERIE"))
            {
                // Comprobar que el numero de temporada no esta repetido
                if (Temporada.NumeroTemporada.Equals(ConsultaUltimonumeroTemporadaBBDD))
                {
                    // El numero de temporada ya existe en la base de datos 
                    ModelState.AddModelError("NumeroTemporada", "Error Temporada ya registrada en la base de datos");
                }

            }
            else if (Temporada.Tipo.Equals("PELICULA"))
            {
                // Insertar la pelicula. Numero temporada es nulo es decir no es aplicable porque una pelicula no tiene temporadas.
                temporadaInsertar.NumeroTemporada = null;
                
            }
            else
            {
                // No es serie ni peli 
            }


            /*
            int? ultimonumeroTemporadaObtenido = UltimonumeroTemporadaBBDD.FirstOrDefault();
            string nombreAnimeObtenido = NombreAnime.FirstOrDefault();
            string tipoAnime = TipoAnime.FirstOrDefault();

            if (ultimonumeroTemporadaObtenido != null || nombreAnimeObtenido != null)
            {
                if (ultimonumeroTemporadaObtenido <= Temporada.NumeroTemporada) // Si el numero de temporada introducido es menor o igual al que esta en SQL SERVER
                {
                   ModelState.AddModelError("Nombre", "El Anime " + Anime.Nombre + " Ya Existe en la base de datos");
                   ModelState.AddModelError("NumeroTemporada", "El Anime " + Anime.Nombre + " ya tiene registrada esta temporada  en la base de datos");
                    return Page();
                }
                else if (ultimonumeroTemporadaObtenido == null)
               {
                   if (nombreAnimeObtenido.Equals(Anime.Nombre, StringComparison.InvariantCultureIgnoreCase))
                   {
                       ModelState.AddModelError("Nombre", "El Anime " + Anime.Nombre + " ya existe en la base de datos");

                       return Page();
                   }
               }

           }



            */



            await _context.Animes.AddAsync(animeNuevo); // Guarda tanto Anime como Temporada
            await _context.SaveChangesAsync(); // Guardamos los datos en SQL SERVER. EF core realizara un INSERT.




            return RedirectToPage("./AnimesTemporadas"); // Redigigimos al usuario a la tabla de animes
        }

        public bool ExisteTemporada(int animeId)
        {
            int? consultaTemporada = (from temporadas in _context.Temporadas where temporadas.AnimeId == animeId select temporadas.NumeroTemporada).FirstOrDefault();


            if (consultaTemporada == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}

