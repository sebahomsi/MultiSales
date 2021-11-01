using back_end.DTOs;
using System.Linq;

namespace back_end.Utilidades
{
    public static class IQueryableExtensions
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
