using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;

namespace AppAnimes.Models
{
    public class HistorialViewModel : PageModel
    {

        public int? idHistorial { get; set; }

        [DisplayName("Id Anime")]

        public int? id_anime { get; set; }

        [DisplayName("Numero de Temporada")]
        public int? NumeroTemporada { get; set; }
        public int? id_temporada { get; set; }
        [DisplayName("Nombre (Anime+Temporada)")]
        public string NombreAnimeTemporada { get; set; }
        public string NombreAnime { get; set; }
        public string nombreTemporada { get; set; }

        [DisplayName("Fecha Inicio")]
        public DateTime? fechaInicio { get; set; }

        [DisplayName("Fecha Fin")]
        public DateTime? fechaFin { get; set; }

        [DisplayName("Fecha Pausa")]
        public DateTime? fechaPausa { get; set; }

        [DisplayName("Visto En")]
        public int VistoEn { get; set; }

        [DisplayName("Año Visto")]
        public int? AnyoVisto{get;set;}

        public HistorialViewModel()
        {
            NombreAnimeTemporada = NombreAnime + " " + nombreTemporada;
        }

    }
}
