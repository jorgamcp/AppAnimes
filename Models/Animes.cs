using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

 
namespace AppAnimes.Models
{
    public partial class Animes
    {
        public Animes()
        {
            Historial = new HashSet<Historial>();
            Temporadas = new HashSet<Temporadas>();
     
        }

        [DisplayName("Id")] // En vez de IdAnime en la tabla del navegador se mostrara Id
        public int IdAnime { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }

     

        [DisplayName("Nombre En Inglés")]
        public string NombreEnIngles { get; set; }

        public virtual ICollection<Historial> Historial { get; set; } // Relacion 1 a N Animestst HistorialTest
        public virtual ICollection<Temporadas> Temporadas { get; set; } // Relacion 1 a N AnimesTest  TemporadasTest
    }
}
