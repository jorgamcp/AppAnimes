using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppAnimes.Models;
using AppAnimesNuevo.Models;

namespace AppAnimes.Pages.Animes
{
    public class AnadirPaginaModel : PageModel
    {
        private readonly AppAnimesDBContext _context;

        // Enlace de Modelo
        [BindProperty]
        public Paginas Pagina { get; set; }

        // Enlace de Modelo
    
        public AnadirPaginaModel(AppAnimesDBContext context)
        {
            _context = context; // Dependency Injection
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Paginas pagina) // async. Clase Task
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }




            Paginas paginaNueva = Pagina; // Nueva pagina que se va a insertar en la base de datos Tiene que ser con la variable de enlace de modelo
        
 
            IQueryable<string> ConsultaPaginaNombre = from p in _context.Paginas where p.nombrePagina ==pagina.nombrePagina select p.nombrePagina;
          

            // Obtener los datos de las consultas LINQ si no existen en la base de datos se devuelve NULL
            string NombrePagina = ConsultaPaginaNombre.FirstOrDefault();



            if (NombrePagina != null)
            {
                ModelState.AddModelError("Nombre", "Error PAGINA DUPLICADA: La Pagina ya existe en la base  de datos");
            }
 

            await _context.Paginas.AddAsync(paginaNueva);  
            await _context.SaveChangesAsync(); // Guardamos los datos en SQL SERVER. EF core realizara un INSERT.




            return RedirectToPage("./Paginas"); // Redigigimos al usuario a la tabla de paginas
        }

        public bool ExistePagina(int PaginaId)
        {
            int? consultaPagina = (from paginas in _context.Paginas where paginas.paginaId == PaginaId select paginas.paginaId).FirstOrDefault();


            if (consultaPagina == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}

