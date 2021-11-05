using AutoMapper;
using back_end.DTOs;
using back_end.Entities;
using back_end.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;

        public ProductsController(ApplicationDbContext context, ILogger<ProductsController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery] PaginacionDTO paginacionDto)
        {
            var queryable = _context.Products.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var products = queryable
                .OrderBy(x => x.Name)
                .Paginar(paginacionDto)
                .ToList();

            return _mapper.Map<List<ProductDTO>>(products);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductDTO>(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _context.Add(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null) return NotFound();

            product = _mapper.Map(productDTO, product);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _context.Products.AnyAsync(x => x.Id == id);

            if (!product) return NotFound();

            _context.Remove(new Product() { Id = id });

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
