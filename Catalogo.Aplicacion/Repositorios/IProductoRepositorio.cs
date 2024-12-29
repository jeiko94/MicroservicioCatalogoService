using Catalogo.Dominio.Models;

namespace Catalogo.Aplicacion.Repositorios
{
    public interface IProductoRepositorio
    {
        Task CrearAsync(Producto producto);
        Task<Producto> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task ActualizarAsync(Producto producto);
        Task EliminarAsync(int id);
    }
}
