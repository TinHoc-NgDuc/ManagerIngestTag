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
using ManagerIngestTag.Models;

namespace ManagerIngestTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngestTagsController : ControllerBase
    {
        private readonly DataContext _context;

        public IngestTagsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/IngestTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngestTagReturnModel>>> GetIngestTags()
        {
            var result = from i in _context.IngestTags
                         select new IngestTagReturnModel
                         {
                             IngestTagId = i.IngestTagId,
                             IngestCode = i.IngestCode,
                             Name = i.Name,
                             Note = i.Note,
                             CategoryId = i.category.CategoryId,
                             CategoryName = i.category.Name,
                             Status = i.Status,
                             cardholderId = i.cardholderId,
                             CardholderName = i.Employee.Name,
                             EmployeeId = i.Employee.EmployeeId

                         };
            return await result.ToListAsync();
        }

        [HttpPost("getfilter")]
        public async Task<ActionResult<IEnumerable<IngestTagReturnModel>>> GetFilter(Filter filter)
        {
            if (filter == null)
            {
                var result = from i in _context.IngestTags
                             select new IngestTagReturnModel
                             {
                                 IngestTagId = i.IngestTagId,
                                 IngestCode = i.IngestCode,
                                 Name = i.Name,
                                 Note = i.Note,
                                 CategoryId = i.category.CategoryId,
                                 CategoryName = i.category.Name,
                                 Status = i.Status,
                                 cardholderId = i.cardholderId,
                                 CardholderName = i.Employee.Name,
                                 EmployeeId = i.Employee.EmployeeId

                             };
                result = result.Take(filter.PageSize).Skip(filter.PageSize * (filter.NumberPage - 1));
                return await result.ToListAsync();
            }
            else
            {
                var result = from i in _context.IngestTags
                             where (i.Name.Contains(filter.Query) || i.IngestCode.Contains(filter.Query) || i.Employee.Name.Contains(filter.Query))
                             select new IngestTagReturnModel
                             {
                                 IngestTagId = i.IngestTagId,
                                 IngestCode = i.IngestCode,
                                 Name = i.Name,
                                 Note = i.Note,
                                 CategoryId = i.category.CategoryId,
                                 CategoryName = i.category.Name,
                                 Status = i.Status,
                                 cardholderId = i.cardholderId,
                                 CardholderName = i.Employee.Name,
                                 EmployeeId = i.Employee.EmployeeId
                             };
                result = result.Take(filter.PageSize).Skip(filter.PageSize * (filter.NumberPage - 1));
                return await result.ToListAsync();
            }
        }
        [HttpPost("getNumberPage")]
        public async Task<ActionResult<int>> GetNumberPage(Filter filter)
        {
            var query = from i in _context.IngestTags
                        select i;
            var list = await query.ToListAsync();
            int resutl = list.Count() / filter.PageSize;
            if (resutl <= 0)
            {
                resutl = 1;
            }
            return resutl;
        }
        [HttpGet("getSumRecord")]
        public async Task<ActionResult<int>> GetSumRecord()
        {
            var query = from i in _context.IngestTags
                        select i;
            var list = await query.ToListAsync();
            return list.Count();
        }
        // GET: api/IngestTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngestTagReturnModel>> GetIngestTag(Guid id)
        {
            var ingestTag = await _context.IngestTags.FindAsync(id);


            var result = from i in _context.IngestTags
                         where (i.IngestTagId == id)
                         select new IngestTagReturnModel
                         {
                             IngestTagId = i.IngestTagId,
                             IngestCode = i.IngestCode,
                             Name = i.Name,
                             Note = i.Note,
                             CategoryId = i.category.CategoryId,
                             CategoryName = i.category.Name,
                             Status = i.Status,
                             cardholderId = i.cardholderId,
                             CardholderName = i.Employee.Name,
                             EmployeeId = i.Employee.EmployeeId

                         };

            if (ingestTag == null)
            {
                return NotFound();
            }

            return await result.FirstOrDefaultAsync();
        }

        // PUT: api/IngestTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngestTag(Guid id, IngestTagModel ingestTag)
        {
            if (id != ingestTag.IngestTagId)
            {
                return BadRequest();
            }
            var itemDelte = _context.IngestTags.Find(ingestTag.IngestTagId);
            _context.Remove(itemDelte);
            var ingest = new IngestTag()
            {
                IngestTagId = ingestTag.IngestTagId,
                Name = ingestTag.Name,
                Note = ingestTag.Note,
                Status = ingestTag.Status,
                //category = _context.Categories.Find(ingestTag.PositionId),
                IngestCode = ingestTag.IngestCode,
                cardholderId = ingestTag.cardholderId,
                Employee = _context.Employees.Find(ingestTag.EmployeeId)
            };
            _context.Add(ingest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngestTagExists(id))
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

        //POST: api/IngestTags
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngestTagModel>> PostIngestTag(IngestTagModel ingestTagModel)
        {
            var query = (from i in _context.IngestTags
                         orderby i.IngestCode descending
                         select i
                          ).Take(1).ToList();
            int count;
            string ingestCode = "MT";
            if (query.Count == 0)
            {
                ingestCode = "MT00000";
            }
            else
            {
                var idCode = query[0].IngestCode;
                count = int.Parse(idCode.Substring(2, idCode.Length - 2));
                count++;
                int index = count / 10;
                for (var i = index; i < 5; i++)
                {
                    ingestCode += "0";
                }
                ingestCode += count.ToString();
            }
            ingestTagModel.IngestTagId = Guid.NewGuid();
            var ingestTag = new IngestTag()
            {
                IngestTagId = ingestTagModel.IngestTagId,
                Name = ingestTagModel.Name,
                Note = ingestTagModel.Note,
                Status = ingestTagModel.Status,
                category = _context.Categories.Find(ingestTagModel.CategoryId),
                IngestCode = ingestCode,
                cardholderId = ingestTagModel.cardholderId,
                Employee = _context.Employees.Find(ingestTagModel.EmployeeId)
            };
            _context.IngestTags.Add(ingestTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngestTag", new { id = ingestTag.IngestTagId }, ingestTag);
        }

        // DELETE: api/IngestTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngestTag(Guid id)
        {
            var ingestTag = await _context.IngestTags.FindAsync(id);
            if (ingestTag == null)
            {
                return NotFound();
            }

            _context.IngestTags.Remove(ingestTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngestTagExists(Guid id)
        {
            return _context.IngestTags.Any(e => e.IngestTagId == id);
        }
    }
}
