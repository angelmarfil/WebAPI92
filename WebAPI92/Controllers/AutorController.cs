using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI92.Services;

namespace WebAPI92.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            return Ok(await _autorService.GetAutores());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _autorService.GetByIdAutor(id));
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor(Autor autor)
        {
            return Ok(await _autorService.Crear(autor));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarAutor([FromBody]Autor autor, int id) 
        {
            return Ok(await _autorService.Editar(autor, id));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAutor( int id)
        {
            return Ok(await _autorService.Eliminar(id));
        }
    }
}
