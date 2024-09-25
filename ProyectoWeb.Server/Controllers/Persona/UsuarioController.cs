using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Shared.Entidades;

namespace ProyectoWeb.Server.Controllers.Persona
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController:ControllerBase
    {
        private readonly AppDbContext context;

        public UsuarioController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAll() { 
        
            return await context.Usuarios.ToListAsync();
        
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Usuario usuario) {

            var existeUsuario = await context.Usuarios.AnyAsync(x => x.Username == usuario.Username);

            if (existeUsuario) {

                return BadRequest("Ya existe un usuario con ese nombre");

            }

            context.Add(usuario);
            await context.SaveChangesAsync();
            return Ok(usuario.Id);

        }
    }
}
