using ORM.Negocio;
using ORM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicioWebApiCine.Services
{
    public class ActorService
    {
        private readonly actoresControllers _actorController;

        public ActorService(actoresControllers actorController)
        {
            _actorController = actorController;
        }

        public List<Actore> ListarActores()
        {
            return _actorController.ListadoActores();
        }

        public void AgregarActor(Actore actor)
        {
            _actorController.AddActore(actor);
        }

        public void EliminarActor(long id)
        {
            _actorController.DeletedActore(id);
        }

        public void ActualizarNombreActor(long id, string nuevoNombre)
        {
            _actorController.UpdateNombreActor(id, nuevoNombre);
        }

        public void ActualizarActor(long id, Actore actor)
        {
            _actorController.UpdateActor(id, actor);
        }
    }

        
}
