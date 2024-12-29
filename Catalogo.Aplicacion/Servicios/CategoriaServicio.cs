using Catalogo.Aplicacion.Repositorios;
using Catalogo.Dominio.Models;

namespace Catalogo.Aplicacion.Servicios
{
    public class CategoriaServicio
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaServicio(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task CrearCategoriaAsync(string nombre, string desc)
        {
            var categoria = new Categoria
            {
                Nombre = nombre,
                Descripcion = desc
            };

            await _categoriaRepositorio.CrearAsync(categoria);
        }

        public async Task<Categoria> ObtenerCategoriaAsync(int id)
        {
            return await _categoriaRepositorio.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Categoria>> ListarCategoriasAsync()
        {
            return await _categoriaRepositorio.ObtenerTodosAsync();
        }

        public async Task ActualizarCategoriaAsync(int id, string nombre, string desc)
        {
            var categoria = await _categoriaRepositorio.ObtenerPorIdAsync(id);

            if(categoria == null)
                throw new KeyNotFoundException("Categoria no encontrada");

            categoria.Nombre = nombre;
            categoria.Descripcion = desc;

            await _categoriaRepositorio.ActualizarAsync(categoria);
        }

        public async Task EliminarCategoriaAsync(int id)
        {
            await _categoriaRepositorio.EliminarAsync(id);
        }
    }
}
