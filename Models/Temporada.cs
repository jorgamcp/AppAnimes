using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public int? NumeroTemporada { get; set; }
        public string NombreTemporada { get; set; }

        [Required(ErrorMessage = "El Estado del Anime es obligatorio")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El tipo (SERIE,ONA,OVA,Pelicula) Es Obligatorio")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "La Temporada de Estreno Es Obligatoria.")]
        public string TemporadaEstreno { get; set; }

        [DisplayName("Nombre del Anime al que pertenece la temporada:")]
        public int? AnimeId { get; set; }

        public virtual Anime Anime { get; set; }
        public virtual ICollection<Historial> Historials { get; set; }
    }
}
