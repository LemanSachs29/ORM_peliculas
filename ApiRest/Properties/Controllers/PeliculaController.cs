using Orm.Clases;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Necogio
{
    internal sealed class PeliculaController : CineContexto<PeliculaController, CineContext>
    {
        public PeliculaController() { }

        public List<Pelicula> ListadoPelicula()
        {
            List<Pelicula> oPeliculas= new List<Pelicula>();
            oPeliculas= (from c in Peliculas select c).ToList<Pelicula>();
            return oPeliculas;
        }

        public void AddPelicula(Pelicula oPelicula)
        {
            this.Add(oPelicula);
        }

        public void DeletePelicula(long IdPelicula)
        {
            Pelicula pelicula = (from c in Peliculas where c.Id == IdPelicula select c).First();
            this.Remove(pelicula);
        }

        public void UpdatePelicula(long IdPelicula, string nuevoTitulo)
        {
       
            // Buscar pelicula
            Pelicula pelicula = (from c in Peliculas where c.Id == IdPelicula select c).First();

            if (pelicula != null)
            {
                pelicula.Titulo = nuevoTitulo;  // Actualizar el nombre
                this.Update(pelicula) ;  // Guardar los cambios en la base de datos
            }
            else
            {
               Console.WriteLine("Película no encontrada.");
            }
            
        }
    }
}
