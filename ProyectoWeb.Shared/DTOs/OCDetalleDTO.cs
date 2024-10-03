using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWeb.Shared.DTOs
{
    public class OCDetalleDTO
    {
        public int Id { get; set; }
        public string NombreLibro { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
    }
}
