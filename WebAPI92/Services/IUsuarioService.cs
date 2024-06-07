using Domain.Entities;
using WebAPI92.Dto;

namespace WebAPI92.Services
{
    public interface IUsuarioService
    {
        public Task<Response<List<UsuarioDto>>> GetUsuarios();
        public Task<Response<Usuario>> GetById(int id);
        public Task<Response<CreateUsuarioDto>> CreateUsuario(CreateUsuarioDto usuario);

        public Task<Response<CreateUsuarioDto>> UpdateUsuario(CreateUsuarioDto usuario, int id);

        public Task<Response<int>> DeleteUsuario(int id);
    }
}
