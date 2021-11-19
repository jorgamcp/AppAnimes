using System;
using System.Collections.Generic;

#nullable disable

namespace AppAnimes.Models
{
    public partial class Temporada
    {
        public int TemporadaId { get; set; }
        public int? NumeroTemporada { get; set; }
        public string NombreTemporada { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string TemporadaEstreno { get; set; }
        public int AnimeId { get; set; }

        public virtual Anime Anime { get; set; }
    }
}
