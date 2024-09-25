using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Shared.Entidades;

namespace ProyectoWeb.Server.Controllers.Persona
{
    [ApiController]
    [Route("api/autor")]
    public class AutorController : ControllerBase
    {
        private readonly AppDbContext context;

        public AutorController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> GetAll()
        {

            return await context.Autores.Include(x => x.Libros).ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Autor autor)
        {

            var repetido = await context.Autores.AnyAsync(x => x.Nombre == autor.Nombre);

            if (repetido)
            {

                return BadRequest("Ya existe un autor con ese nombre");

            }

            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok(autor.Id);

        }

    }
}
