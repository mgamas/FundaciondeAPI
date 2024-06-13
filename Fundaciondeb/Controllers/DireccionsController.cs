using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Fundaciondeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DireccionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Direccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direccion>>> GetDireccions()
        {
            return await _context.Direccions.ToListAsync();
        }

        // GET: api/Direccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Direccion>> GetDireccion(int id)
        {
            var direccion = await _context.Direccions.FindAsync(id);

            if (direccion == null)
            {
                return NotFound();
            }

            return direccion;
        }

        // PUT: api/Direccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDireccion(int id, Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(direccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DireccionExists(id))
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

        // POST: api/Direccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Direccion>> PostDireccion(Direccion direccion)
        {
            _context.Direccions.Add(direccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDireccion", new { id = direccion.Id }, direccion);
        }

        // DELETE: api/Direccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDireccion(int id)
        {
            var direccion = await _context.Direccions.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }

            _context.Direccions.Remove(direccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DireccionExists(int id)
        {
            return _context.Direccions.Any(e => e.Id == id);
        }
    }
}
