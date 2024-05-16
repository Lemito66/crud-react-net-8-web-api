using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeersController : ControllerBase
    {
        private readonly DbcrudContext _context;

        public EmployeersController(DbcrudContext context)
        {
            _context = context;
        }

        // GET: api/Employeers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employeer>>> GetEmployeers()
        {
            return await _context.Employeers.ToListAsync();
        }

        // GET: api/Employeers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employeer>> GetEmployeer(int id)
        {
            var employeer = await _context.Employeers.FindAsync(id);

            if (employeer == null)
            {
                return NotFound();
            }

            return employeer;
        }

        // PUT: api/Employeers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeer(int id, Employeer employeer)
        {
            if (id != employeer.IdEmployeer)
            {
                return BadRequest();
            }

            _context.Entry(employeer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeerExists(id))
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

        // POST: api/Employeers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employeer>> PostEmployeer(Employeer employeer)
        {
            _context.Employeers.Add(employeer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeer", new { id = employeer.IdEmployeer }, employeer);
        }

        // DELETE: api/Employeers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeer(int id)
        {
            var employeer = await _context.Employeers.FindAsync(id);
            if (employeer == null)
            {
                return NotFound();
            }

            _context.Employeers.Remove(employeer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeerExists(int id)
        {
            return _context.Employeers.Any(e => e.IdEmployeer == id);
        }
    }
}
