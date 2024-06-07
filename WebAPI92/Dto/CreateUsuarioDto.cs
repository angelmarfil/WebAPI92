using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI92.Dto
{
    public class CreateUsuarioDto
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? FkRol { get; set; }
    }
}
