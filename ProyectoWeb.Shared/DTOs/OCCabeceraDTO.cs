using ProyectoWeb.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWeb.Shared.DTOs
{
    public class OCCabeceraDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente{ get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Estado { get; set; }  
        public int Monto { get; set; }
        public List<OCDetalleDTO> Detalle { get; set; }

        public static OCCabeceraDTO CrearDTO(OrdenCompraCabecera modelo)
        {

            return new OCCabeceraDTO
            {

                Id = modelo.Id,
                ClienteId = modelo.ClienteId,
                NombreCliente = modelo.Cliente.Nombre,
                UsuarioId = modelo.UsuarioId,
                NombreUsuario = modelo.Usuario.Nombre,
                Fecha = modelo.Fecha,
                FechaEntrega = modelo.FechaEntrega,
                Estado = modelo.Estado,
                Monto = modelo.Monto


            };

        }

    }

  
}
