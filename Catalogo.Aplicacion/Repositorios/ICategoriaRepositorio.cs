using Catalogo.Dominio.Models;

namespace Catalogo.Aplicacion.Repositorios
{
    public interface ICategoriaRepositorio
    {
        Task CrearAsync(Categoria categoria);
        Task<Categoria> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Categoria>> ObtenerTodosAsync();
        Task ActualizarAsync(Categoria categoria);
        Task EliminarAsync(int id);
    }
}
