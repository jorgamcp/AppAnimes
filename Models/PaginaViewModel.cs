using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;

namespace AppAnimes.Models
{
    public class PaginaViewModel : PageModel
    {

        [DisplayName("Id Página")]        
        public int paginaId{get;set;}
        [DisplayName("Nombre de la Página")]
        public string nombrePagina{get;set;}
        [DisplayName("¿Es Legal?")]
        public bool esLegal{get;set;}
        [DisplayName("¿Es Fansub?")]
        public bool esFansub{get;set;}

        [DisplayName("Url")]
        public string urlPagina{get;set;}
        
        [DisplayName("¿Esta Disponible en España?")]
        public bool estaDisponible{get;set;}
        [DisplayName("¿Esta Activo?")]
        public bool estaActivo{get;set;}
        public PaginaViewModel()
        {
        }
    }
    
}