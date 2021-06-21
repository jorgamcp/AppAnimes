using System.ComponentModel.DataAnnotations;
using AppAnimes.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppAnimesNuevo.Models
{
    public class EsUnicoAnimeAttribute : ValidationAttribute
    {
        private readonly string nombreAnime;
        private readonly AppAnimesDBContext _context;

        public EsUnicoAnimeAttribute()
        {

        }

        public string GetErrorMessage() => "El Anime ya esta en la base de datos";
        protected override ValidationResult IsValid(object value,
         ValidationContext validationContext)
        {
            var anime = (Anime)validationContext.ObjectInstance;

            var consulta = from animes in _context.Animes where animes.Nombre == anime.Nombre select animes.Nombre;

            if (consulta != null)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}