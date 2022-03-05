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
    public class ProductionUnitsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductionUnitsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProductionUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionUnitModel>>> GetProductionUnits()
        {

            var resutl = from pu in _context.ProductionUnits
                         select new ProductionUnitModel()
                         {
                             Name = pu.Name,
                             ProductionUnitId = pu.ProductionUnitId
                         };
            return await resutl.ToListAsync(); 
        }

        #region Not use
        //// GET: api/ProductionUnits/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductionUnit>> GetProductionUnit(Guid id)
        //{
        //    var productionUnit = await _context.ProductionUnits.FindAsync(id);

        //    if (productionUnit == null)
        //    {
        //        return NotFound();
        //    }

        //    return productionUnit;
        //}

        //// PUT: api/ProductionUnits/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProductionUnit(Guid id, ProductionUnit productionUnit)
        //{
        //    if (id != productionUnit.ProductionUnitId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(productionUnit).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductionUnitExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/ProductionUnits
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ProductionUnit>> PostProductionUnit(ProductionUnit productionUnit)
        //{
        //    _context.ProductionUnits.Add(productionUnit);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProductionUnit", new { id = productionUnit.ProductionUnitId }, productionUnit);
        //}
        //private bool ProductionUnitExists(Guid id)
        //{
        //    return _context.ProductionUnits.Any(e => e.ProductionUnitId == id);
        //}
        #endregion
        // DELETE: api/ProductionUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionUnit(Guid id)
        {
            var productionUnit = await _context.ProductionUnits.FindAsync(id);
            if (productionUnit == null)
            {
                return NotFound();
            }

            _context.ProductionUnits.Remove(productionUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
