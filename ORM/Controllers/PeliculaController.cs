using Orm.Clases;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Controllers
{
    public sealed class PeliculaController : CineContexto<PeliculaController, CineContext>
    {
        public PeliculaController() { }

        public List<Pelicula> ListadoPelicula()
        {
            List<Pelicula> oPeliculas = new List<Pelicula>();
            oPeliculas = (from c in Peliculas select c).ToList();
            return oPeliculas;
        }

        public void AddPelicula(Pelicula oPelicula)
        {
            Add(oPelicula);
        }

        public void DeletePelicula(long IdPelicula)
        {
            Pelicula pelicula = (from c in Peliculas where c.Id == IdPelicula select c).First();
            Remove(pelicula);
        }

        public void UpdatePelicula(long IdPelicula, string nuevoTitulo)
        {

            // Buscar pelicula
            Pelicula pelicula = (from c in Peliculas where c.Id == IdPelicula select c).First();

            if (pelicula != null)
            {
                pelicula.Titulo = nuevoTitulo;  // Actualizar el nombre
                Update(pelicula);  // Guardar los cambios en la base de datos
            }
            else
            {
                Console.WriteLine("Película no encontrada.");
            }

        }
    }
}
