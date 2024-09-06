﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Libro>>> GetAll() { 
        
            return await context.Libros.Include(x => x.Autor).ToListAsync();    
        
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id) {

            return await context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);

        }

        [HttpPost]
        public async Task<ActionResult> Post (Libro libro) {

            var ExisteAutor = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);

            if (!ExisteAutor) {

                return BadRequest($"No existe el autor de Id: {libro.AutorId}");

            }

            context.Add(libro) ;

            await context.SaveChangesAsync();
            return Ok();
        
        }
    }
}
