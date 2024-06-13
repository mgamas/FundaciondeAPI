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
    public class PaisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisDto>>> GetPais()
        {
            return await _context.Pais.OrderBy(p => p.Id).Select(p => new PaisDto
            {
                Id = p.Id,
                Nombre = p.Nombre
            }).ToListAsync();
        }

        // GET: api/Pais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
            var pais = await _context.Pais.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        // PUT: api/Pais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(int id, Pais pais)
        {
            bool respuesta = false;
            if (id != pais.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = respuesta, message = "Error: El pais no coincide" });
            }

            _context.Entry(pais).State = EntityState.Modified;

            try
            {
                int changes = await _context.SaveChangesAsync();
                respuesta = changes > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = respuesta, message = "Error: El pais NO se actualizo" });
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta, message = "El pais se actualizo correctamente" });
        }

        // POST: api/Pais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            bool respuesta = false;
            _context.Pais.Add(pais);
            int changes = await _context.SaveChangesAsync();
            respuesta = changes > 0;
            if (respuesta)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta, message = "El pais se creo correctamente" });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = respuesta, message = "El no se puede eliminar" });
            }
            
        }

        // DELETE: api/Pais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(int id)
        {
            bool respuesta = false;
            var pais = await _context.Pais.FindAsync(id);
            if (pais == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = respuesta, message = "El no se puede eliminar" });
            }

            _context.Pais.Remove(pais);
            int changes = await _context.SaveChangesAsync();
            respuesta |= changes > 0;
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta, message = "El pais se elimino correctamente" });
        }

        private bool PaisExists(int id)
        {
            return _context.Pais.Any(e => e.Id == id);
        }
    }

    public class PaisDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}
