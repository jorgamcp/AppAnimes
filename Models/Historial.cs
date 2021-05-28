using System;
using System.Collections.Generic;

#nullable disable

namespace AppAnimes.Models
{
    public partial class Historial
    {
        public int IdHistorial { get; set; }
        public int AnimeId { get; set; }
        public int? TemporadaId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string VistoEn { get; set; }

        public virtual Anime Anime { get; set; }
        public virtual Temporada Temporada { get; set; }
         
    }
}
