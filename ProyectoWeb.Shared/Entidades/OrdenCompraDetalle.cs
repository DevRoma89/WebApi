using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWeb.Shared.Entidades
{
    public class OrdenCompraDetalle
    {
        public int Id { get; set; }
        public int OrdenCompraCabeceraId { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
        public int Precio { get; set; } 
        public int Cantidad { get; set; }
        public int Total { get; set; }

        
    }
}
