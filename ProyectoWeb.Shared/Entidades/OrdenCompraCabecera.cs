using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWeb.Shared.Entidades
{
    public class OrdenCompraCabecera
    {

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int UsuarioId { get; set; }  
        public Usuario Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Estado { get; set; } = "PENDIENTE";
        public int Monto { get; set; }
        public List<OrdenCompraDetalle> Detalle { get; set; }

        // id, id_cliente, id_vendedor, fecha(sysdate), fecha_entrega,  estado(PENDIENTE), monto
    }
}
