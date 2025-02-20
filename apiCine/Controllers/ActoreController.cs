using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.Models; // Modelo Actore
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActoresController : ControllerBase
    {
        private readonly CineContext _context;

        public ActoresController(CineContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener todos los actores
        /// </summary>
        [HttpGet("listado")]
        public async Task<ActionResult<List<Actore>>> ListadoActores()
        {
            var actores = await _context.Actores.ToListAsync();
            return Ok(actores);
        }

        /// <summary>
        /// Agregar un nuevo actor
        /// </summary>
        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarActor([FromBody] Actore oActor)
        {
            if (oActor == null)
                return BadRequest("El actor no puede ser nulo.");

            _context.Actores.Add(oActor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ListadoActores), new { id = oActor.Id }, oActor);
        }

        /// <summary>
        /// Eliminar un actor por su ID
        /// </summary>
        [HttpDelete("borrar/{id}")]
        public async Task<IActionResult> BorrarActor([FromRoute] long id)
        {
            var actor = await _context.Actores.FirstOrDefaultAsync(a => a.Id == id);

            if (actor == null)
                return NotFound("Actor no encontrado.");

            _context.Actores.Remove(actor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Actualizar el nombre de un actor
        /// </summary>
        [HttpPut("actualizar/nombre/{id}")]
        public async Task<IActionResult> ActualizarNombreActor([FromRoute] long id, [FromQuery] string nuevoNombre)
        {
            var actor = await _context.Actores.FirstOrDefaultAsync(a => a.Id == id);

            if (actor == null)
                return NotFound("Actor no encontrado.");

            actor.Nombre = nuevoNombre;
            await _context.SaveChangesAsync();

            return Ok(actor);
        }

        /// <summary>
        /// Actualizar un actor completamente
        /// </summary>
        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> ActualizarActor([FromRoute] long id, [FromBody] Actore updatedActor)
        {
            var actorExistente = await _context.Actores.FirstOrDefaultAsync(a => a.Id == id);

            if (actorExistente == null)
                return NotFound("Actor no encontrado.");

            // Actualizar los campos
            actorExistente.Nombre = updatedActor.Nombre;
            actorExistente.Apellido = updatedActor.Apellido;
            actorExistente.FechaNacimiento = updatedActor.FechaNacimiento;
            actorExistente.Nacionalidad = updatedActor.Nacionalidad;

            await _context.SaveChangesAsync();
            return Ok(actorExistente);
        }
    }
}
