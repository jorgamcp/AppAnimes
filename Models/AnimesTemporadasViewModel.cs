using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AppAnimes.Models
{

    /*
        Clase AnimesTemporadasViewModel

        Esta clase representa los nombres de los animes con los nombres de las Temporadas
        La aplicacion hace un join entre las dos tablas y muestra el nombre del anime y la temporada junta.

    */
    public class AnimesTemporadasViewModel
    {
        [DisplayName("Id Anime")]
        public int? id_anime { get; set; }

        [DisplayName("Numero de Temporada")]
        public int? id_temporada { get; set; }
        [DisplayName("Nombre (Anime+Temporada)")]
        public string NombreAnimeTemporada { get; set; }
        [DisplayName("Género")]
        public string genero { get; set; }
        [DisplayName("Nombre En Inglés")]
        public string nombreEnIngles { get; set; }
        [DisplayName("Estado")]
        public string estado { get; set; }
        [DisplayName("Tipo")]
        public string tipo { get; set; }
        [DisplayName("Temporada Estreno")]
        public string temporada_estreno { get; set; }
        public AnimesTemporadasViewModel()
        {

        }

         
    }
}