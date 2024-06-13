using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fundaciondeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoTipoController:ControllerBase
    {
        public readonly ApplicationDbContext _dbcontext;

        public TelefonoTipoController(ApplicationDbContext _context) { 
            _dbcontext = _context;
        }
        // GET: api/<TelefonoTipoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //y control
        [HttpGet("ListaTelefonos")]
        public async Task<IActionResult>  Lista() { 
            List<TelefonoTipo> list = new List<TelefonoTipo>();
            try
            {
                list = await _dbcontext.TelefonoTipos.ToListAsync();

                return Ok(list);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("obtener/{id_telefono:int}")]
        public async Task<IActionResult> obtener(int id_telefono)
        {
            
            try
            {
                TelefonoTipo telTipo = await _dbcontext.TelefonoTipos.FindAsync(id_telefono);
                if(telTipo == null)
                {
                    return BadRequest("Telefono tipo no encontrado");
                }

                return Ok(telTipo);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] TelefonoTipo obj)
        {

            try
            {
                _dbcontext.TelefonoTipos.Add(obj);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" , Response  = obj });
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] TelefonoTipo obj)
        {
            TelefonoTipo tipo = await _dbcontext.TelefonoTipos.FindAsync(obj.Id);
            if(tipo == null)
            {
                return BadRequest("Tipo telefono no encontrado");
            }
            try
            {
                tipo.Tipo = obj.Tipo is null ? tipo.Tipo : obj.Tipo;
                _dbcontext.TelefonoTipos.Update(tipo);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = tipo });
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("eliminar/{id_telefono:int}")]
        public async Task<IActionResult> Eliminar(int id_telefono)
        {
            TelefonoTipo tipo = await _dbcontext.TelefonoTipos.FindAsync(id_telefono);
            if(tipo == null)
            {
                return BadRequest("Tipo telefono no encontrado");
            }
            try
            {
                _dbcontext.TelefonoTipos.Remove(tipo);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok, Eliminado" });
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }


        // GET api/<TelefonoTipoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TelefonoTipoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TelefonoTipoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TelefonoTipoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
