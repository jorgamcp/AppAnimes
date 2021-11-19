using System;
using System.Collections.Generic;

#nullable disable

namespace AppAnimes.Models 
{
    public partial class Anime
    {
        public Anime()
        {
            Historials = new HashSet<Historial>();
            Temporadas = new HashSet<Temporada>();
        }

        public int AnimeId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string NombreIngles { get; set; }

        public virtual ICollection<Historial> Historials { get; set; }
        public virtual ICollection<Temporada> Temporadas { get; set; }
    }
}
