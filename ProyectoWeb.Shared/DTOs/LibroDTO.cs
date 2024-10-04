using ProyectoWeb.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWeb.Shared.DTOs
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public string NombreAutor { get; set; }


        public static LibroDTO CrearDTO(Libro modelo)
        {

            return new LibroDTO
            {

                Id = modelo.Id,
                Titulo = modelo.Titulo,
                AutorId = modelo.Autor.Id,
                NombreAutor = modelo.Autor.Nombre

            };


        }

    }

}

