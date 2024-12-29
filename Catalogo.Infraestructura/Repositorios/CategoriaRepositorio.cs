using Catalogo.Aplicacion.Repositorios;
using Catalogo.Dominio.Models;
using Catalogo.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infraestructura.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly CatalogoDbContext _context;

        public CategoriaRepositorio(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task CrearAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }
        public async Task<Categoria> ObtenerPorIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }
        public async Task<IEnumerable<Categoria>> ObtenerTodosAsync()
        {
            return await _context.Categorias.ToListAsync();
        }
        public async Task ActualizarAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarAsync(int id)
        {
            var categoria = await ObtenerPorIdAsync(id);

            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
