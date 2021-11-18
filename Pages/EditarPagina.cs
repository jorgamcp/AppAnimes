using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetcoreapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AppAnimes.Models;
using AppAnimesNuevo.Models;

namespace aspnetcoreapp.Pages.Animes
{
    public class EditarPaginaModel : PageModel
    {
        private readonly AppAnimesDBContext _context;
        private readonly ILogger _logger;

        public EditarPaginaModel(AppAnimesDBContext context,ILogger<EditarPaginaModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty(SupportsGet =true)]
        public Paginas pagina{get;set;}

        public async Task<IActionResult> OnGetAsync(int? paginaId){
            if(paginaId == null)
            {
                return NotFound();
            }

            pagina = await _context.Paginas.FindAsync(paginaId);

            

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? paginaId){
         
            Paginas paginactualizar = await _context.Paginas.FindAsync(paginaId);

            if(paginactualizar == null)
            {
                return NotFound();
            }   
            else
            {
                if(await TryUpdateModelAsync<Paginas>(paginactualizar,"pagina",
                    p => p.nombrePagina,
                    p => p.esLegal,
                    p => p.esFansub,
                    p => p.urlPagina,
                    p => p.estaDisponible,
                    p => p.estaActivo
                ))
                {
                    _context.ChangeTracker.DetectChanges();

                    Console.WriteLine(_context.ChangeTracker.DebugView.LongView);
                }
            }
         
            await _context.SaveChangesAsync();

          

           return RedirectToPage("./Paginas");
        }
    }
}