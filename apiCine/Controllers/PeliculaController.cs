using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.Models;
 

namespace ApiCine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly CineContext _context;

        public PeliculasController(CineContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener todas las películas
        /// </summary>
        [HttpGet("listado")]
        public async Task<ActionResult<List<Pelicula>>> ListadoPeliculas()
        {
            var peliculas = await _context.Peliculas.ToListAsync();
            return Ok(peliculas);
        }

        /// <summary>
        /// Agregar una nueva película
        /// </summary>
        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarPelicula([FromBody] Pelicula oPelicula)
        {
            if (oPelicula == null)
                return BadRequest("La película no puede ser nula.");

            _context.Peliculas.Add(oPelicula);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ListadoPeliculas), new { id = oPelicula.Id }, oPelicula);
        }

        /// <summary>
        /// Eliminar una película por su ID
        /// </summary>
        [HttpDelete("borrar/{id}")]
        public async Task<IActionResult> BorrarPelicula([FromRoute] long id)
        {
            var pelicula = await _context.Peliculas.FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null)
                return NotFound("Película no encontrada.");

            _context.Peliculas.Remove(pelicula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Actualizar el título de una película
        /// </summary>
        [HttpPut("actualizar/titulo/{id}")]
        public async Task<IActionResult> ActualizarTituloPelicula([FromRoute] long id, [FromQuery] string nuevoTitulo)
        {
            var pelicula = await _context.Peliculas.FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null)
                return NotFound("Película no encontrada.");

            pelicula.Titulo = nuevoTitulo;
            await _context.SaveChangesAsync();

            return Ok(pelicula);
        }

    }
}
