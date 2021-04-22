using System;
using System.Collections.Generic;

#nullable disable

namespace AppAnimes.Models
{
    public partial class Historial
    {
        public int IdHistorial { get; set; }
        public int IdAnime { get; set; }
        public int IdTemp { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaPausa { get; set; }
        public string VistoEn { get; set; }

        public virtual Animes IdAnimeNavigation { get; set; }
        public virtual Temporadas IdTemporadaNavigation { get; set; }
         
    }
}
