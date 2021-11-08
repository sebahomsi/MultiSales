using System.Linq;
using back_end.DTOs;

namespace back_end.Utilities
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable,
            PaginacionDTO paginacionDto)
        {
            return queryable
                .Skip((paginacionDto.Pagina - 1) * paginacionDto.RegistrosPorPagina)
                .Take(paginacionDto.RegistrosPorPagina);
        }
    }
}
