
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Shared.DTOs;
using ProyectoWeb.Shared.Entidades;
using Mapster;

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
        public async Task<ActionResult<List<AutorDTO>>> GetAll()
        {

            var autores =  await context.Autores.Include(x => x.Libros).ToListAsync();

            return autores.Adapt<List<AutorDTO>>();  
            
            

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> GetById(int id) {

            var autor = await context.Autores.FindAsync(id);

            if ( autor == null ) { 
                return NotFound("No se encontro un Autor con ese Id");
            }

            return autor;

        } 
 
        [HttpPost]
        public async Task<ActionResult<int>> Post(AutorDTO autorDTO)
{

            var repetido = await context.Autores.AnyAsync(x => x.Nombre == autorDTO.Nombre);

            if (repetido)
            {

                return BadRequest("Ya existe un autor con ese nombre");

            }

            Autor autor = autorDTO.Adapt<Autor>();   

            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok(autor.Id);

        }



    }
}
