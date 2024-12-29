using Catalogo.Aplicacion.Repositorios;
using Catalogo.Dominio.Models;

namespace Catalogo.Aplicacion.Servicios
{
    public class ProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public ProductoServicio(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }
        
        public async Task CrearProductoAsync(string nombre, string desc, decimal precio, int stock, int categoriaId)
        {
            var producto = new Producto
            {
                Nombre = nombre,
                Descripcion = desc,
                Precio = precio,
                Stock = stock,
                CategoriaId = categoriaId,
                Activo = true
            };

            await _productoRepositorio.CrearAsync(producto);
        }

        public async Task<Producto> ObtenerProductoAsync(int id)
        {
            return await _productoRepositorio.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Producto>> ListarProductosAsync()
        {
            return await _productoRepositorio.ObtenerTodosAsync();
        }

        public async Task ActualizarProductoAsync(int id, string nombre, string desc, decimal precio, int stock, int categoriaId)
        {
            var producto = await _productoRepositorio.ObtenerPorIdAsync(id);

            if(producto == null)
                throw new KeyNotFoundException("Producto no encontrado");

            producto.Nombre = nombre;
            producto.Descripcion = desc;
            producto.Precio = precio;
            producto.Stock = stock;
            producto.CategoriaId = categoriaId;
            producto.Activo = true;

            await _productoRepositorio.ActualizarAsync(producto);
        } 

        public async Task EliminarProductoAsync(int id)
        {
            await _productoRepositorio.EliminarAsync(id); 
        }
    }
}
