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
    public class ProgramShowsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProgramShowsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProgramShows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramShowModel>>> GetPrograms()
        {
            var result = from p in _context.ProgramShows
                         select new ProgramShowModel
                         {
                             PropgramShowId = p.PropgramShowId,
                             Name = p.Name
                         };
            return await result.ToListAsync();
        }

        #region not use
        //// GET: api/ProgramShows/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProgramShow>> GetProgramShow(Guid id)
        //{
        //    var programShow = await _context.ProgramShows.FindAsync(id);

        //    if (programShow == null)
        //    {
        //        return NotFound();
        //    }

        //    return programShow;
        //}

        //// PUT: api/ProgramShows/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProgramShow(Guid id, ProgramShow programShow)
        //{
        //    if (id != programShow.PropgramShowId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(programShow).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProgramShowExists(id))
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

        //// POST: api/ProgramShows
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ProgramShow>> PostProgramShow(ProgramShow programShow)
        //{
        //    _context.ProgramShows.Add(programShow);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProgramShow", new { id = programShow.PropgramShowId }, programShow);
        //}
        //private bool ProgramShowExists(Guid id)
        //{
        //    return _context.ProgramShows.Any(e => e.PropgramShowId == id);
        //}
        #endregion

        // DELETE: api/ProgramShows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramShow(Guid id)
        {
            var programShow = await _context.ProgramShows.FindAsync(id);
            if (programShow == null)
            {
                return NotFound();
            }

            _context.ProgramShows.Remove(programShow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
