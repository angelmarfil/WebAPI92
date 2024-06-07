using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAPI92.Context;
using WebAPI92.Dto;

namespace WebAPI92.Services
{
    public class AutorService : IAutorService
    {
        private readonly ApplicationDbContext _context;

        public AutorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<IEnumerable<Autor>>> GetAutores()
        {
            try
            {
                var response = await _context.Database.GetDbConnection().QueryAsync<Autor>("SpGetAutores", new {}, commandType:CommandType.StoredProcedure);
                return new Response<IEnumerable<Autor>>(response);  
            }

            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<IEnumerable<Autor>>> GetByIdAutor(int id)
        {
            try
            {
                var response = await _context.Database.GetDbConnection().QueryAsync<Autor>("SpGetById", new { id }, commandType: CommandType.StoredProcedure);
                return new Response<IEnumerable<Autor>>(response);
            }

            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<IEnumerable<Autor>>> Crear(Autor i)
        {
            try
            {
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure);
                return new Response<IEnumerable<Autor>>(result);
            }

            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<IEnumerable<Autor>>> Editar(Autor i, int id)
        {
            try
            {
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spEditarAutor", new {id, i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure);
                return new Response<IEnumerable<Autor>>(result);
            }
             
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<IEnumerable<Autor>>> Eliminar(int id)
        {
            try
            {
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spEliminarAutor", new { id }, commandType: CommandType.StoredProcedure);
                return new Response<IEnumerable<Autor>>(result);
            }

            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

    }
}
