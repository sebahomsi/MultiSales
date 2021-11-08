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
using back_end.Utilities;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BrandsController> _logger;
        private readonly IMapper _mapper;

        public BrandsController(ApplicationDbContext context, ILogger<BrandsController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BrandDTO>>> Get([FromQuery] PaginacionDTO paginacionDto)
        {
            var queryable = _context.Brands.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var brands = queryable
                .OrderBy(x => x.Name)
                .Paginar(paginacionDto)
                .ToList();

            return _mapper.Map<List<BrandDTO>>(brands);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<BrandDTO>> Get(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<BrandDTO>(brand);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BrandDTO brandDto)
        {
            var brand = _mapper.Map<Store>(brandDto);
            _context.Add(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] BrandDTO brandDto)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);

            if (brand == null) return NotFound();

            brand = _mapper.Map(brandDto, brand);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var brand = await _context.Brands.AnyAsync(x => x.Id == id);

            if (!brand) return NotFound();

            _context.Remove(new Brand() { Id = id });

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}