using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Shared.Entidades;

namespace ProyectoWeb.Server.Controllers.Persona
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {

        private readonly AppDbContext context;

        public ClienteController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAll() {

            return await context.Clientes.ToListAsync();

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {

            var existe = await context.Clientes.FindAsync(id);

            if (existe == null) {

                return NotFound("No se encontro un cliente con ese ID");

            }

            return Ok(existe);

        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Cliente cliente) {

            var existeCedula = await context.Clientes.AnyAsync(x => x.Cedula == cliente.Cedula);

            if (existeCedula) {

                return BadRequest("Ya existe un cliente con esa Cedula");

            }

            context.Add(cliente);
            await context.SaveChangesAsync();
            return Ok(cliente.Id);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {

            var cliente = await context.Clientes.FindAsync(id);

            if (cliente == null) {

                return NotFound("No se encontro un cliente con ese id");

            }

            var tieneOC = await context.Cabeceras.AnyAsync(x => x.ClienteId == id );

            if ( tieneOC == true) {

                return BadRequest("No se puede eliminar este cliente porque tiene una o mas OC asociadas");

            }

            context.Remove(cliente);
            await context.SaveChangesAsync();   
            return Ok(cliente);

        }

    }
}
