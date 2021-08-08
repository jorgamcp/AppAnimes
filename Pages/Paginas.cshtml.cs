using AppAnimes.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AppAnimesNuevo;
using Microsoft.AspNetCore.Http;

namespace AppAnimes.Pages
{
    public class PaginasModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppAnimesDBContext _context;


        public PaginatedList<PaginaViewModel> PaginasAnimePaginated { get; set; }

        public PaginasModel(ILogger<IndexModel> logger, AppAnimesDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? pageIndex, string action,int? pageId)
        {

            if (action == null && pageId == null)
            {
                int pageSize = 100;
                if (pageIndex <= 0)
                {
                    return RedirectToPage("Index");
                }

                PaginasAnimePaginated = await PaginatedList<PaginaViewModel>.CreateAsync(
                    from pagina in _context.Paginas
                    select new PaginaViewModel()
                    {
                        paginaId = pagina.paginaId,
                        nombrePagina = pagina.nombrePagina,
                        esLegal = pagina.esLegal
                    }, pageIndex ?? 1, pageSize);

                return Page();
            }
            else
            {   
                string urlDestino = (from pagina in _context.Paginas where pagina.paginaId == pageId select pagina.urlPagina).First(); // Obtener URL de la pagina desde SQL SERVER
                return Redirect(urlDestino);
            }
        }


        // public RedirectResult Redireccionar(int PageId)
        // {

        //     string urlDestination = "a";

        //     urlDestination = (from paginas in _context.Paginas where paginas.paginaId == PageId select paginas.urlPagina).FirstOrDefault();




        //     return Redirect(urlDestination);
        // }

    }
}