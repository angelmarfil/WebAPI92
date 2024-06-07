using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebAPI92.Context;
using WebAPI92.Dto;

namespace WebAPI92.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;
        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<UsuarioDto>>> GetUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuario.Include(x => x.Roles).ToListAsync();

                var users = response.Select(user => new UsuarioDto
                {
                    Id = user.PkUsuario,
                    Name = user.Nombre,
                    Username = user.User,
                    FkRol = user.FkRol,
                    Role = user.Roles.Nombre
                }).ToList();

                return new Response<List<UsuarioDto>>(users);
            }

            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<CreateUsuarioDto>> CreateUsuario(CreateUsuarioDto usuario)
        {
            try
            {
                var usuarioModel = new Usuario
                {
                    Nombre = usuario.Name,
                    User = usuario.Username,
                    Password = usuario.Password,    
                    FkRol = usuario.FkRol,
                };

                var response = await _context.Usuario.AddAsync(usuarioModel);
                await _context.SaveChangesAsync();

                return new Response<CreateUsuarioDto>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> GetById(int id)
        {
            try
            {
                var res = await _context.Usuario.FindAsync(id);
                return new Response<Usuario>(res);
            }

            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<CreateUsuarioDto>> UpdateUsuario(CreateUsuarioDto usuario, int id)
        {
            try
            {
                var existeUsuario = _context.Usuario.Any(usuario => usuario.PkUsuario == id);

                if (!existeUsuario)
                {
                    return new Response<CreateUsuarioDto>("Usuario no existe"); 
                }

                var usuarioEncontrado = await _context.Usuario.FindAsync(id);

                usuarioEncontrado.Nombre = usuario.Name;
                usuarioEncontrado.User = usuario.Username;
                usuarioEncontrado.Password = usuario.Password;
                usuarioEncontrado.FkRol = usuario.FkRol;

                _context.Usuario.Update(usuarioEncontrado);
                await _context.SaveChangesAsync();
                return new Response<CreateUsuarioDto>(usuario);
            }

            catch (Exception e)
            {
                throw new Exception("Sucedio un error" +  e.Message);
            }
        }

        public async Task<Response<int>> DeleteUsuario(int id)
        {
            try
            {
                var existeUsuario = _context.Usuario.Any(usuario => usuario.PkUsuario == id);

                if (!existeUsuario)
                {
                    return new Response<int>("Usuario no existe");
                }

                var usuarioEncontrado = await _context.Usuario.FindAsync(id);

                _context.Usuario.Remove(usuarioEncontrado);
                await _context.SaveChangesAsync();
                return new Response<int>(id, "Eliminado correctamente");
            }

            catch (Exception e)
            {
                throw new Exception("Sucedio un error" + e.Message);
            }
        }
    }
}
