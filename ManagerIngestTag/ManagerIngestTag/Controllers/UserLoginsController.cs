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
    public class UserLoginsController : ControllerBase
    {
        private readonly DataContext _context;

        public UserLoginsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLoginModel>>> GetUserLogins()
        {
            var list = await _context.UserLogins.ToListAsync();
            var query = from us in _context.UserLogins
                        select new UserLoginModel
                        {
                            UserName = us.UserName,
                            Password = us.Password,
                            UserLoginId = us.UserLoginId,
                            RoleId = us.Role.RoleId
                        };
            return await query.ToListAsync();
        }

        // GET: api/UserLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLogin>> GetUserLogin(Guid id)
        {
            var userLogin = await _context.UserLogins.FindAsync(id);

            if (userLogin == null)
            {
                return NotFound();
            }

            return userLogin;
        }

        // PUT: api/UserLogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLogin(Guid id, UserLogin userLogin)
        {
            if (id != userLogin.UserLoginId)
            {
                return BadRequest();
            }

            _context.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(id))
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

        // POST: api/UserLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserLogin>> PostUserLogin(UserLoginModel userLogin)
        {
            var role = _context.Roles.Find(userLogin.RoleId);
            var user = new UserLogin();
            user.UserLoginId = Guid.NewGuid();
            user.Password = userLogin.Password;
            user.UserName = userLogin.UserName;
            user.Role = role;
            _context.UserLogins.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLogin", new { id = userLogin.UserLoginId }, userLogin);
        }

        // DELETE: api/UserLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLogin(Guid id)
        {
            var userLogin = await _context.UserLogins.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            _context.UserLogins.Remove(userLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserLoginExists(Guid id)
        {
            return _context.UserLogins.Any(e => e.UserLoginId == id);
        }
    }
}
