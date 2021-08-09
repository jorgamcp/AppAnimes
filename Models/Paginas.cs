
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppAnimes.Models;

namespace AppAnimesNuevo.Models
{
    public partial class Paginas
    {
        public Paginas(){
            Historials = new HashSet<Historial>();
        }

        public int paginaId{get;set;}

        [Required(ErrorMessage="El nombre de la pagina es obligatorio")]
        public string nombrePagina{get;set;}
      
        public bool esLegal{get;set;}

        public bool esFansub{get;set;}
        public bool estaDisponible{get;set;}
        public string urlPagina{get;set;}

        // Relacion 1 a N entre Paginas e Historial 
        public  virtual ICollection<Historial> Historials {get;set;}

    }
}