﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Shared.Entidades;

namespace ProyectoWeb.Server.Controllers.Articulos
{
    [ApiController]
    [Route("api/libro")]
    public class LibroController : ControllerBase
    {
        private readonly AppDbContext context;

        public LibroController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Libro>>> GetAll()
        {

            return await context.Libros.ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Libro libro) {

            var autorExiste = await context.Autores.AnyAsync( x => x.Id == libro.AutorId);

            if (!autorExiste) {

                return NotFound("No se encontro el autor");

            }

            context.Add(libro);
            await context.SaveChangesAsync();   
            return Ok(libro.Id);

        }

    }
}

