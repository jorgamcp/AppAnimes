using System;
using System.ComponentModel;

namespace AppAnimes.Models
{
    public class HistorialViewModel
    {

        [DisplayName("Id Historial")]
        public int? id_historial { get; set; }
        [DisplayName("Numero Temporada")]
        public int? id_temp { get; set; }

        [DisplayName("Nombre (Anime+Temporada)")]
        public string NombreAnimeTemporada { get; set; }
        [DisplayName("Fecha Inicio")]
        public DateTime? FechaInicio { get; set; }
        [DisplayName("Fecha Fin")]
        public DateTime? FechaFin { get; set; }
    }
}