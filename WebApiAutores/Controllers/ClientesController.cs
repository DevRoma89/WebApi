
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public ClientesController(ApplicationDbContext context)
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

            return await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);


        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {

            context.Add(cliente);

            await context.SaveChangesAsync();

            return Ok();


        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Cliente cliente) {

            if (cliente.Id != id) {

                return BadRequest("Los IDs no coinciden");

            }

            var existe = await context.Clientes.AnyAsync(x => x.Id == id);

            if (!existe) {

                return NotFound();

            }

            context.Update(cliente);
            await context.SaveChangesAsync();
            return Ok();


        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete( int id) {

            var existe = context.Clientes.AnyAsync(x => x.Id == id); 


        

        
        }

    }
}
