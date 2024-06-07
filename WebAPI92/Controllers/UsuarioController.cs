using Microsoft.AspNetCore.Mvc;
using WebAPI92.Dto;
using WebAPI92.Services;

namespace WebAPI92.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuarioService.GetUsuarios();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _usuarioService.GetById(id);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioDto request)
        {
            var response = await _usuarioService.CreateUsuario(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreateUsuarioDto request, int id)
        {
            var response = await _usuarioService.UpdateUsuario(request, id);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _usuarioService.DeleteUsuario(id);
            return Ok(response);
        }
    }
}
