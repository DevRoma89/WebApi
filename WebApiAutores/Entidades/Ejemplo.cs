using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Entidades
{
    public class Ejemplo
    {
        public int Id { get; set; }
        [Length(0,15)]
        public string Nombre { get; set; }

    }
}
