using System.Collections.Generic;

namespace back_end.DTOs
{
    public class PaginacionDto
    {
        public int Pagina { get; set; } = 1;

        private int _registrosPorPagina = 10;
        private const int CantidadMaximaRegistrosPorPagina = 50;

        public int RegistrosPorPagina
        {
            get => _registrosPorPagina;
            set => _registrosPorPagina = (value > CantidadMaximaRegistrosPorPagina)
                    ? CantidadMaximaRegistrosPorPagina
                    : value;
        }
    }
}
