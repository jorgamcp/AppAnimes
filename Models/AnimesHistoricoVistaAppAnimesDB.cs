using System;
using System.Collections.Generic;

#nullable disable

namespace AppAnimes.Models
{
    public partial class AnimesHistoricoVistaAppAnimesDB
    {
        public int IdHistorial { get; set; }
        public int IdTemp { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaPausa { get; set; }
    }
}
