using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Shared.Entidades;

namespace ProyectoWeb.Server.Controllers.OC
{
    [ApiController]
    [Route("api/ordenCompra")]
    public class OrdenCompraController : ControllerBase
    {

        private readonly AppDbContext context;

        public OrdenCompraController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrdenCompraCabecera>>> GetAll() {

            return await context.Cabeceras.Include(x => x.Detalle).ToListAsync();

        }

        [HttpGet("/cliente/{id:int}")]
        public async Task<ActionResult<List<OrdenCompraCabecera>>> GetByCliente([FromRoute] int id) {

            var existeCliente = await context.Clientes.AnyAsync(x => x.Id == id);

            if (!existeCliente) {

                return NotFound($"El cliente con Id {id} no existe");

            }

            return await context.Cabeceras.Include(x => x.Detalle).ToListAsync();

        }

        [HttpGet("/rangoFecha")]
        public async Task<ActionResult<List<OrdenCompraCabecera>>> GetByRangoFecha([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin ) {

            if (fechaInicio > fechaFin)
            {
                return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin.");
            }
          

            return await context.Cabeceras.Where( x => x.Fecha >= fechaInicio && x.Fecha <= fechaFin ).ToListAsync();   


        }

        [HttpPost]
        public async Task<ActionResult<int>> Post( OrdenCompraCabecera ordenCompraCabecera) { 
        
            var  clienteExiste = await context.Clientes.AnyAsync(x => x.Id == ordenCompraCabecera.ClienteId);
            var  usuarioExiste = await context.Usuarios.AnyAsync(x => x.Id == ordenCompraCabecera.UsuarioId);

            if ( !( clienteExiste && usuarioExiste) ) {

                return BadRequest("El usuario o el cliente no existen");
            
            }

            context.Add(ordenCompraCabecera); 
            await context.SaveChangesAsync();
            return Ok(ordenCompraCabecera.Id);


        }

        [HttpPut("fecha/{id:int}")]
        public async Task<ActionResult> PutFechaEntrega(int id , [FromBody] DateTime actualizarFecha) {

            var actual = await context.Cabeceras.FindAsync(id);

            if ( actual == null) {
                return NotFound($"No se encontro una cabecera con el Id {id}");
            }

            actual.FechaEntrega = actualizarFecha;


            context.Update(actual);
            await context.SaveChangesAsync();
            return Ok(actual);
            
            
        }        
        [HttpPut("estado/{id:int}")]
        public async Task<ActionResult> PutEstado(int id , [FromBody] string estado) {

            var actual = await context.Cabeceras.FindAsync(id);
           

            if ( actual == null) {
                return NotFound($"No se encontro una cabecera con el Id {id}");
            }

            

            if ( estado.ToUpper() == "ENTREGADO" || estado.ToUpper() == "ANULADO") {

                actual.Estado = estado.ToUpper();
                context.Update(actual);
                await context.SaveChangesAsync();
                return Ok(actual);

            }

           
            return BadRequest("El estado tiene que ser entragado o anulado");

            
            
            
        }

      

    }
}
