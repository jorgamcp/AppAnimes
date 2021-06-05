using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppAnimesNuevo
{
      /*
        PaginatedList
        Proporciona Una lista de elementos para la clase T 
    Donde T es Generico es decir puede ser tipo Anime, Temporada o Historial.
        
     */
    public class PaginatedList<T> : List<T> // T es (Generico) Generics 
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {

            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
          
           
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(
                (pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}