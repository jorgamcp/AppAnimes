using System;
using System.Collections.Generic;

#nullable disable

namespace AppAnimes.Models
{
    public partial class Temporadas
    {
        public int IdAnime { get; set; }
        public int? IdTemporada { get; set; }
        public string NombreTemporada { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string TemporadaEstreno { get; set; }

        public virtual Animes IdAnimeNavigation { get; set; }
        public virtual Temporadas IdTemporadaNavigation { get; set; }
    }
}
