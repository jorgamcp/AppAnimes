using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

 
namespace AppAnimes.Models
{
    public partial class Anime 
    {
        public Anime()
        {
            Historials = new HashSet<Historial>();
            Temporadas = new HashSet<Temporada>();
     
        }

        [DisplayName("Id")] // En vez de IdAnime en la tabla del navegador se mostrara Id
        public int AnimeId { get; set; }
        [Required(ErrorMessage ="El nombre del Anime es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="El Género es Obligatorio")]
        public string Genero { get; set; }

        [DisplayName("Nombre En Inglés")]
        public string NombreIngles { get; set; }

        public virtual ICollection<Historial> Historials { get; set; } // Relacion 1 a N Animestst HistorialTest
        public virtual ICollection<Temporada> Temporadas { get; set; } // Relacion 1 a N AnimesTest  TemporadasTest
    }
}
