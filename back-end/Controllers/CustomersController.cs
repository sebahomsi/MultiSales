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
using back_end.Utilities;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CustomersController> _logger;
        private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext context, ILogger<CustomersController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> Get([FromQuery] PaginacionDTO paginacionDto)
        {
            var queryable = _context.Customers.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var customers = queryable
                .OrderBy(x => x.FirstName)
                .Paginar(paginacionDto)
                .ToList();

            return _mapper.Map<List<CustomerDTO>>(customers);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<CustomerDTO>> Get(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CustomerDTO customerDTO)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null) return NotFound();

            customer = _mapper.Map(customerDTO, customer);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _context.Customers.AnyAsync(x => x.Id == id);

            if (!customer) return NotFound();

            _context.Remove(new Customer() { Id = id });

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
