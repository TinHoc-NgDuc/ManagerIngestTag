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
using Microsoft.Extensions.Configuration;

namespace ManagerIngestTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;
        public IConfiguration Configuration { get; }
        public EmployeesController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
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

        // GET: api/Employees/reporter
        [HttpGet("reporter")]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployeesReporter()
        {
            string EmployeesReporterId = Configuration.GetValue<string>("EmployeesReporterId");
            var query = from e in _context.Employees
                        where (e.Position.PositionId == Guid.Parse(EmployeesReporterId))
                        select new EmployeeModel
                        {
                            EmployeeId = e.EmployeeId,
                            Name = e.Name,
                            PositionId = e.Position.PositionId,
                            ProductionUnitId = e.ProductionUnit.ProductionUnitId
                        };
            return await query.ToListAsync();
        }

        // GET: api/Employees/InRoomIngest
        [HttpGet("InRoomIngest")]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployeesInRoomIngest()
        {
            string EmployeesInRoomIngest = Configuration.GetValue<string>("EmployeesInRoomIngest");
            var query = from e in _context.Employees
                        where (e.Position.PositionId == Guid.Parse(EmployeesInRoomIngest))
                        select new EmployeeModel
                        {
                            EmployeeId = e.EmployeeId,
                            Name = e.Name,
                            PositionId = e.Position.PositionId,
                            ProductionUnitId = e.ProductionUnit.ProductionUnitId
                        };
            return await query.ToListAsync();
        }

        // GET: api/Employees/cameraman
        [HttpGet("cameraman")]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployeesCameraman()
        {
            string EmployeesCameraman = Configuration.GetValue<string>("EmployeesCameraman");
            var query = from e in _context.Employees
                        where (e.Position.PositionId == Guid.Parse(EmployeesCameraman))
                        select new EmployeeModel
                        {
                            EmployeeId = e.EmployeeId,
                            Name = e.Name,
                            PositionId = e.Position.PositionId,
                            ProductionUnitId = e.ProductionUnit.ProductionUnitId
                        };
            return await query.ToListAsync();
        }
        //EmployeesEditor

        // GET: api/Employees/cameraman
        [HttpGet("reporterOrEditor")]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetreporterOrEditor()
        {
            string EmployeesEditor = Configuration.GetValue<string>("EmployeesEditor");
            string EmployeesReporterId = Configuration.GetValue<string>("EmployeesReporterId");
            var query = from e in _context.Employees
                        where (
                            (e.Position.PositionId == Guid.Parse(EmployeesEditor)) ||
                            (e.Position.PositionId == Guid.Parse(EmployeesReporterId))
                        )
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
            var result = await employee.Where(e => e.EmployeeId == id).FirstOrDefaultAsync();
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
