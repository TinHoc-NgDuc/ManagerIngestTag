﻿using System;
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
    public class TopicsController : ControllerBase
    {
        private readonly DataContext _context;

        public TopicsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Topics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicModel>>> GetTopics()
        {
            var result = from t in _context.Topics
                         select new TopicModel
                         {
                             CameramanName = t.CameramanName,
                             CreateName = t.CreateName,
                             IsCategory = t.IsCategory,
                             IsNew = t.IsNew,
                             IsOtherProgram = t.IsOtherProgram,
                             IsReporting = t.IsReporting,
                             Name = t.Name,
                             ProductionName = t.ProductionName,
                             ProgramName = t.ProgramName,
                             ReporterName = t.ReporterName,
                             TopicId = t.TopicId
                         };

            return await result.ToListAsync();
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(Guid id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #region not use
        //// GET: api/Topics/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Topic>> GetTopic(Guid id)
        //{
        //    var topic = await _context.Topics.FindAsync(id);

        //    if (topic == null)
        //    {
        //        return NotFound();
        //    }

        //    return topic;
        //}

        //// PUT: api/Topics/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTopic(Guid id, Topic topic)
        //{
        //    if (id != topic.TopicId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(topic).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TopicExists(id))
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

        //// POST: api/Topics
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Topic>> PostTopic(Topic topic)
        //{
        //    _context.Topics.Add(topic);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTopic", new { id = topic.TopicId }, topic);
        //}

        //private bool TopicExists(Guid id)
        //{
        //    return _context.Topics.Any(e => e.TopicId == id);
        //}
        #endregion
    }
}
