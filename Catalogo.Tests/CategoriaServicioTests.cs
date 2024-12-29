using Catalogo.Aplicacion.Repositorios;
using Catalogo.Aplicacion.Servicios;
using Catalogo.Dominio.Models;
using Moq;
using Xunit;

namespace Catalogo.Tests
{
    public class CategoriaServicioTests
    {
        private readonly Mock<ICategoriaRepositorio> _mockCategoriaRepositorio;
        private readonly CategoriaServicio _categoriaServicio;

        public CategoriaServicioTests()
        {
            _mockCategoriaRepositorio = new Mock<ICategoriaRepositorio>();
            _categoriaServicio = new CategoriaServicio(_mockCategoriaRepositorio.Object);
        }

        [Fact]
        public async Task CrearCategoriaAsync_DeberiaCrearCategoria()
        {
            // Arrange
            var nombre = "Categoria Test";
            var descripcion = "Descripcion Test";

            // Act
            await _categoriaServicio.CrearCategoriaAsync(nombre, descripcion);

            // Assert
            _mockCategoriaRepositorio.Verify(r => r.CrearAsync(It.IsAny<Categoria>()), Times.Once);
        }

        [Fact]
        public async Task ObtenerCategoriaAsync_DeberiaRetornarCategoria()
        {
            // Arrange
            var categoriaId = 1;
            var categoria = new Categoria { Id = categoriaId, Nombre = "Categoria Test" };
            _mockCategoriaRepositorio.Setup(r => r.ObtenerPorIdAsync(categoriaId)).ReturnsAsync(categoria);

            // Act
            var result = await _categoriaServicio.ObtenerCategoriaAsync(categoriaId);

            // Assert
            Assert.Equal(categoria, result);
        }

        [Fact]
        public async Task ListarCategoriasAsync_DeberiaRetornarListaDeCategorias()
        {
            // Arrange
            var categorias = new List<Categoria> { new Categoria { Id = 1, Nombre = "Categoria Test" } };
            _mockCategoriaRepositorio.Setup(r => r.ObtenerTodosAsync()).ReturnsAsync(categorias);

            // Act
            var result = await _categoriaServicio.ListarCategoriasAsync();

            // Assert
            Assert.Equal(categorias, result);
        }

        [Fact]
        public async Task ActualizarCategoriaAsync_DeberiaActualizarCategoria()
        {
            // Arrange
            var categoriaId = 1;
            var categoria = new Categoria { Id = categoriaId, Nombre = "Categoria Test" };
            _mockCategoriaRepositorio.Setup(r => r.ObtenerPorIdAsync(categoriaId)).ReturnsAsync(categoria);

            // Act
            await _categoriaServicio.ActualizarCategoriaAsync(categoriaId, "Nuevo Nombre", "Nueva Descripcion");

            // Assert
            _mockCategoriaRepositorio.Verify(r => r.ActualizarAsync(It.IsAny<Categoria>()), Times.Once);
        }

        [Fact]
        public async Task EliminarCategoriaAsync_DeberiaEliminarCategoria()
        {
            // Arrange
            var categoriaId = 1;

            // Act
            await _categoriaServicio.EliminarCategoriaAsync(categoriaId);

            // Assert
            _mockCategoriaRepositorio.Verify(r => r.EliminarAsync(categoriaId), Times.Once);
        }
    }
}
