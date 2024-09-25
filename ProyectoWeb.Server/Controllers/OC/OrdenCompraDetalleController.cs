using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Shared.Entidades;

namespace ProyectoWeb.Server.Controllers.OC
{
    [ApiController]
    [Route("api/ordenCompraDetalle")]
    public class OrdenCompraDetalleController : ControllerBase
    {

        private readonly AppDbContext context;

        public OrdenCompraDetalleController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<OrdenCompraDetalle>>> GetAll() { 
        
            return await context.Detalles.ToListAsync();    
        
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post( OrdenCompraDetalle ordenCompraDetalle) { 
        
            var existeCabecera = await context.Cabeceras.AnyAsync(x => x.Id == ordenCompraDetalle.OrdenCompraCabeceraId);

            if (!existeCabecera) { 
            
                return NotFound($"No se encontro esta cabecera: {ordenCompraDetalle.OrdenCompraCabeceraId} ");

            }

            context.Add(ordenCompraDetalle); 
            await context.SaveChangesAsync();
            return Ok(ordenCompraDetalle.Id);


        }
    }
}
