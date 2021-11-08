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
    public class SaleDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SaleDetailsController> _logger;
        private readonly IMapper _mapper;

        public SaleDetailsController(ApplicationDbContext context, ILogger<SaleDetailsController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SaleDetailDTO>>> Get([FromQuery] PaginacionDTO paginacionDto)
        {
            var queryable = _context.SaleDetails.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var saleDetails = queryable
                .OrderBy(x => x.Product.Name)
                .Paginar(paginacionDto)
                .ToList();

            return _mapper.Map<List<SaleDetailDTO>>(saleDetails);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<SaleDetailDTO>> Get(int id)
        {
            var saleDetail = await _context.SaleDetails.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<SaleDetailDTO>(saleDetail);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SaleDetailDTO saleDetailDTO)
        {
            var saleDetail = _mapper.Map<SaleDetail>(saleDetailDTO);
            _context.Add(saleDetail);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] SaleDetailDTO saleDetailDTO)
        {
            var saleDetail = await _context.SaleDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (saleDetail == null) return NotFound();

            saleDetail = _mapper.Map(saleDetailDTO, saleDetail);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var saleDetail = await _context.SaleDetails.AnyAsync(x => x.Id == id);

            if (!saleDetail) return NotFound();

            _context.Remove(new SaleDetail() { Id = id });

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
