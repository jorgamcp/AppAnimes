using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAnimes.Models;

namespace AppAnimesNuevo.Models
{
    public class AnimeTemporada
    {
        public Anime anime { get; set; }
        public Temporada temporada { get; set; }
    }
}
