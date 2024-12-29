using Catalogo.Aplicacion.Repositorios;
using Catalogo.Dominio.Models;
using Catalogo.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infraestructura.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly CatalogoDbContext _context;

        public ProductoRepositorio(CatalogoDbContext context)
        {
            _context = context;
        }

        public async Task CrearAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }
        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            //Incluir categoría
            return await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .ToListAsync();
        }
        public async Task ActualizarAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarAsync(int id)
        {
            var producto = await ObtenerPorIdAsync(id);

            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
