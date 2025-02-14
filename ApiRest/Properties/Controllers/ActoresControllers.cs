using Orm.Clases;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Negocio
{
    public sealed class actoresControllers : CineContexto<Actore, CineContext>
    {

        public actoresControllers() { }


        public List<Actore> ListadoActores()
        {
            List<Actore> oActores = new List<Actore>();
            oActores = (from c in Actores select c).ToList<Actore>();
            return oActores;
        }



        public void AddActore(Actore oActor)
        {
            this.Add(oActor);

        }


        public void DeletedActore(long IdActor)
        {

            Actore actor = new Actore();
            actor = (from c in Actores where c.Id == IdActor select c).First();
            this.Remove(actor);

        }

       public void UpdateNombreActor(long IdActor, string nuevoNombre)
        {
            // Buscar el actor por su Id
            Actore actor = (from c in Actores where c.Id == IdActor select c).First();
    
            if (actor != null)  
            {
                actor.Nombre = nuevoNombre;  // Actualizar el nombre
                this.Update(actor);  // Guardar los cambios en la base de datos
            }
            else
            {
            Console.WriteLine("Actor no encontrado.");
            }
        }

        public void UpdateActor(long IdActor, Actore updatedActor)
        {
            // Buscar el actor existente por su Id
            Actore actorExistente = (from c in Actores where c.Id == IdActor select c).First();

            if (actorExistente != null)  // Si se encuentra el actor
            {
                // Actualizar todos los campos
                actorExistente.Nombre= updatedActor.Nombre;
                actorExistente.Apellido= updatedActor.Apellido;
                actorExistente.FechaNacimiento = updatedActor.FechaNacimiento;
                actorExistente.Nacionalidad= updatedActor.Nacionalidad;

                // Guardar los cambios en la base de datos
                this.Update(actorExistente);
            }
            else
            {
                Console.WriteLine("Actor no encontrado.");
            }
        }



    }
}
