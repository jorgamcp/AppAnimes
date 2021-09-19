using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppAnimesNuevo.Models;

#nullable disable

namespace AppAnimes.Models
{
    public partial class Historial
    {
        public int IdHistorial { get; set; }
        public int? AnimeId { get; set; }
        public int? TemporadaId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        [Required(ErrorMessage ="La página donde se vió/esta viendo es obligatoria.")]
        public int? VistoEn { get; set; }

        public int? AnyoVisto{get;set;} // Si no se conoce la fecha en la que se vio el anime.
        public virtual Anime Anime { get; set; }
        public virtual Temporada Temporada { get; set; }
        public virtual  Paginas Pagina{get;set;}


         
    }
}
