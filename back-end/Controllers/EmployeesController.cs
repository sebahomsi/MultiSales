using AutoMapper;
using back_end.DTOs;
using back_end.Entities;
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
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IMapper _mapper;

        public EmployeesController(ApplicationDbContext context, ILogger<EmployeesController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> Get([FromQuery] PaginacionDto paginacionDto)
        {
            var queryable = _context.Employees.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var employees = queryable
                .OrderBy(x => x.FirstName)
                .Paginar(paginacionDto)
                .ToList();

            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<EmployeeDTO>> Get(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null) return NotFound();

            employee = _mapper.Map(employeeDTO, employee);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _context.Employees.AnyAsync(x => x.Id == id);

            if (!employee) return NotFound();

            _context.Remove(new Employee() { Id = id });

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
