using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagerIngest.Infrastructure;
using ManagerIngest.Infrastructure.Datatable;
using ManagerIngest.Models;

namespace ManagerIngestTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
        {
            var query = from e in _context.Employees
                        select new EmployeeModel
                        {
                            EmployeeId = e.EmployeeId,
                            Name = e.Name,
                            PositionId = e.Position.PositionId,
                            ProductionUnitId = e.ProductionUnit.ProductionUnitId
                        };
            return await query.ToListAsync();
        }

        // GET: api/Employees
        [HttpGet("reporter")]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployeesReporter()
        {
            var query = from e in _context.Employees
                        where (e.Position.PositionId == Guid.Parse("350B3DC0-3DCF-45BC-A41C-943621E511EC"))
                        select new EmployeeModel
                        {
                            EmployeeId = e.EmployeeId,
                            Name = e.Name,
                            PositionId = e.Position.PositionId,
                            ProductionUnitId = e.ProductionUnit.ProductionUnitId
                        };
            return await query.ToListAsync();
        }

        // GET: api/Employees
        [HttpGet("cameraman")]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployeesCameraman()
        {
            var query = from e in _context.Employees
                        where (e.Position.PositionId == Guid.Parse("04B29736-6E76-42DE-AE4A-9967BD1A1CFB"))
                        select new EmployeeModel
                        {
                            EmployeeId = e.EmployeeId,
                            Name = e.Name,
                            PositionId = e.Position.PositionId,
                            ProductionUnitId = e.ProductionUnit.ProductionUnitId
                        };
            return await query.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployee(Guid id)
        {

            var employee = from e in _context.Employees
                           select new EmployeeModel
                           {
                               EmployeeId = e.EmployeeId,
                               Name = e.Name,
                               PositionId = e.Position.PositionId,
                               ProductionUnitId = e.ProductionUnit.ProductionUnitId
                           };
            var result = await employee.Where(e=>e.EmployeeId == id).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, EmployeeModel eple)
        {
            var employees = new Employee
            {
                EmployeeId = eple.EmployeeId,
                Name = eple.Name,
                Position = _context.Positions.Find(eple.PositionId),
                ProductionUnit = _context.ProductionUnits.Find(eple.ProductionUnitId)
            };
            if (id != employees.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployee(EmployeeModel eple)
        {
            var employees = new Employee
            {
                EmployeeId = eple.EmployeeId,
                Name = eple.Name,
                Position = _context.Positions.Find(eple.PositionId),
                ProductionUnit = _context.ProductionUnits.Find(eple.ProductionUnitId)
            };
            _context.Employees.Add(employees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employees.EmployeeId }, employees);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(Guid id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
