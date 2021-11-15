using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppAnimes.Models
{
    public class Peliculas
    {
        public int PeliculaId { get; set; }

        [Required(ErrorMessage ="El nombre de la pelicula es necesario")]
        public string nombrePelicula { get; set; }
        public string estudio { get; set; }
        public virtual Anime Anime { get; set; }
        public virtual ICollection<Historial> Historials { get; set; }
        
        public Peliculas()
        {
            Historials = new HashSet<Historial>();
        }


    }
}