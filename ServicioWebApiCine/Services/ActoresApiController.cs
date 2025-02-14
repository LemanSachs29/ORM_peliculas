using Microsoft.AspNetCore.Mvc;
using ServicioWebApiCine.Services;
using ORM.Models;
using System.Collections.Generic;

namespace ServicioWebApiCine.Services
{

    [Route("api/actores")]
    [ApiController]
    public class ActoresApiController : ControllerBase
    {
        private readonly ActorService _actorService;

        public ActoresApiController(ActorService actorService)
        {
            _actorService = actorService;
        }

        //GET api/actores
        [HttpGet]
        public ActionResult<IEnumerable<Actore>> GetActores()
        {
            return _actorService.ListarActores();
        }

        [HttpPost]
        public IActionResult AddActor([FromBody]Actore actor)
        {
            _actorService.AgregarActor(actor);
            return Ok(new { mensaje = "Actor agregado con éxito" });
        }

        //DELETE: api/actores/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteActor(long id)
        {
            _actorService.EliminarActor(id);
            return Ok(new { mensaje = "Actor eliminado con éxito" });
        }

        // PUT: api/actores/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateActor(long id, [FromBody] Actore actor)
        {
            _actorService.ActualizarActor(id, actor);
            return Ok(new { mensaje = "Actor actualizado con éxito" });
        }

        // PATCH: api/actores/{id}/nombre
        [HttpPatch("{id}/nombre")]
        public IActionResult UpdateNombreActor(long id, [FromBody] string nuevoNombre)
        {
            _actorService.ActualizarNombreActor(id, nuevoNombre);
            return Ok(new { mensaje = "Nombre del actor actualizado con éxito" });
        }
    }
}
