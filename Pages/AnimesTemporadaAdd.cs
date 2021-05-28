using AppAnimes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace AppAnimesNuevo.Pages
{
    public class AnimesTemporadaAdd : PageModel
    {
        private readonly ILogger<Anime> _logger;
        private readonly AppAnimesDBContext _context;
        public AnimesTemporadaAdd(ILogger<Anime> logger,AppAnimesDBContext context)
        {
            // DI
            _logger=logger;
            _context=context;
        }

        public  IActionResult OnGet()
        {
            return Page();
        }

        
    }
}