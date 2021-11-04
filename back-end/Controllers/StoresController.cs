using AutoMapper;
using back_end.DTOs;
using back_end.Entities;
using back_end.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILogger<StoresController> _logger;
        private readonly IMapper _mapper;
        public StoresController(ApplicationDbContext context, ILogger<StoresController> logger, IMapper mapper)
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

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<StoreDTO>> Get(int id)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<StoreDTO>(store);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StoreDTO storeDto)
        {
            var store = _mapper.Map<Store>(storeDto);
            _context.Add(store);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] StoreDTO storeDto)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);

            if (store == null) return NotFound();

            store = _mapper.Map(storeDto, store);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var store = await _context.Stores.AnyAsync(x => x.Id == id);

            if (!store) return NotFound();

            _context.Remove(new Store() { Id = id });

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
