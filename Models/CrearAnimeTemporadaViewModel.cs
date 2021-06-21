using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AppAnimesNuevo.Models;

namespace AppAnimes.Models
{
    public class CrearAnimeTemporadaViewModel : PageModel
    {

        [DisplayName("Nombre Anime")]
        [EsUnicoAnime]
        public string Nombre { get; set; } // Columna Nombre TBL  Animes
        [DisplayName("Genero")]
        public string Genero { get; set; } // Columna Genero TBL  Animes
        [DisplayName("Nombre en Inglés")]
        public string NombreIngles { get; set; } // Columna Nombre Ingles TBL Animes
        [DisplayName("Número Temporada")]
        public int? NumeroTemporada { get; set; } // Numero de temporada Puede ser nulo TBL Temporadas
        [DisplayName("Nombre Temporada (si no tiene dejar en blanco)")]
        public string NombreTemporada { get; set; } // Nombre Especifico de la Temporada ej :Gou para Higurashi puede ser nulo TBL Temporadas
        [DisplayName("Estado (VISTO,VIENDOLO,DROP,PLANEADO)")]
        public string Estado { get; set; } // Columna Estado TBL Temporadas
        [DisplayName("Tipo (SERIE,OVA,ONA,PELICULA)")]
        public string Tipo { get; set; } // Columna Tipo TBL Temporadas (SERIE,PELICULA , OVA...)
        [DisplayName("Temporada Estreno (Temporada que se estreno el Anime mes año ej: Invierno 2021)")]
        public string  TemporadaEstreno { get; set; } // Temporada Estreno puede ser nulo


    }
}
