using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace AppAnimes.Models
{
    public partial class Temporada
    {
        public Temporada()
        {
            Historials = new HashSet<Historial>();
        }
        public int TemporadaId { get; set; }
        public int? NumeroTemporada{get;set;}
        public string NombreTemporada { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string TemporadaEstreno { get; set; }

        [DisplayName("Nombre del Anime al que pertenece la temporada:")]
        public int? AnimeId { get; set; }

        public virtual Anime Anime { get; set; }
        public virtual ICollection<Historial> Historials { get; set; }
    }
}
