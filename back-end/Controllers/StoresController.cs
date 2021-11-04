using AutoMapper;
using back_end.DTOs;
using back_end.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BrandsController> _logger;
        private readonly IMapper _mapper;
        public StoresController(ApplicationDbContext context, ILogger<BrandsController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<StoreDTO>>> Get([FromQuery] PaginacionDTO paginacionDto)
        {
            var queryable = _context.Stores.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var stores = queryable
                .OrderBy(x => x.Name)
                .Paginar(paginacionDto)
                .ToList();

            return _mapper.Map<List<StoreDTO>>(stores);
        }
    }
}
