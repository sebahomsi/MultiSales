﻿namespace back_end.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;

        private int registrosPorPagina = 10;
        private readonly int cantidadMaximaRegistrosPorPagina = 50;

        public int RegistrosPorPagina
        {
            get
            {
                return registrosPorPagina;
            }
            set
            {
                registrosPorPagina = (value > cantidadMaximaRegistrosPorPagina)
                    ? cantidadMaximaRegistrosPorPagina
                    : value;
            }
        }
    }
}
