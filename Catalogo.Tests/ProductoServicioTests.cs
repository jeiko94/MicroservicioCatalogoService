using Catalogo.Aplicacion.Repositorios;
using Catalogo.Aplicacion.Servicios;
using Catalogo.Dominio.Models;
using Moq;
using Xunit;

namespace Catalogo.Tests
{
    public class ProductoServicioTests
    {
        private readonly Mock<IProductoRepositorio> _mockProductoRepositorio;
        private readonly ProductoServicio _productoServicio;

        public ProductoServicioTests()
        {
            _mockProductoRepositorio = new Mock<IProductoRepositorio>();
            _productoServicio = new ProductoServicio(_mockProductoRepositorio.Object);
        }

        [Fact]
        public async Task CrearProductoAsync_DeberiaCrearProducto()
        {
            // Arrange
            var nombre = "Producto Test";
            var descripcion = "Descripcion Test";
            var precio = 100m;
            var stock = 10;
            var categoriaId = 1;

            // Act
            await _productoServicio.CrearProductoAsync(nombre, descripcion, precio, stock, categoriaId);

            // Assert
            _mockProductoRepositorio.Verify(r => r.CrearAsync(It.IsAny<Producto>()), Times.Once);
        }

        [Fact]
        public async Task ObtenerProductoAsync_DeberiaRetornarProducto()
        {
            // Arrange
            var productoId = 1;
            var producto = new Producto { Id = productoId, Nombre = "Producto Test" };
            _mockProductoRepositorio.Setup(r => r.ObtenerPorIdAsync(productoId)).ReturnsAsync(producto);

            // Act
            var result = await _productoServicio.ObtenerProductoAsync(productoId);

            // Assert
            Assert.Equal(producto, result);
        }

        [Fact]
        public async Task ListarProductosAsync_DeberiaRetornarListaDeProductos()
        {
            // Arrange
            var productos = new List<Producto> { new Producto { Id = 1, Nombre = "Producto Test" } };
            _mockProductoRepositorio.Setup(r => r.ObtenerTodosAsync()).ReturnsAsync(productos);

            // Act
            var result = await _productoServicio.ListarProductosAsync();

            // Assert
            Assert.Equal(productos, result);
        }

        [Fact]
        public async Task ActualizarProductoAsync_DeberiaActualizarProducto()
        {
            // Arrange
            var productoId = 1;
            var producto = new Producto { Id = productoId, Nombre = "Producto Test" };
            _mockProductoRepositorio.Setup(r => r.ObtenerPorIdAsync(productoId)).ReturnsAsync(producto);

            // Act
            await _productoServicio.ActualizarProductoAsync(productoId, "Nuevo Nombre", "Nueva Descripcion", 200m, 20, 2);

            // Assert
            _mockProductoRepositorio.Verify(r => r.ActualizarAsync(It.IsAny<Producto>()), Times.Once);
        }

        [Fact]
        public async Task EliminarProductoAsync_DeberiaEliminarProducto()
        {
            // Arrange
            var productoId = 1;

            // Act
            await _productoServicio.EliminarProductoAsync(productoId);

            // Assert
            _mockProductoRepositorio.Verify(r => r.EliminarAsync(productoId), Times.Once);
        }
    }
}
