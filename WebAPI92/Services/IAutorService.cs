using Domain.Entities;
using WebAPI92.Dto;

namespace WebAPI92.Services
{
    public interface IAutorService
    {
        public Task<Response<IEnumerable<Autor>>> GetAutores();
        public Task<Response<IEnumerable<Autor>>> GetByIdAutor(int id);
        public Task<Response<IEnumerable<Autor>>> Crear(Autor i);
        public Task<Response<IEnumerable<Autor>>> Editar(Autor i, int id);
        public Task<Response<IEnumerable<Autor>>> Eliminar(int id);
    }
}
