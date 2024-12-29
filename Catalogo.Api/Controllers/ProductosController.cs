using Catalogo.Api.DTOs;
using Catalogo.Aplicacion.Servicios;
using Catalogo.Dominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoServicio _productoServicio;

        public ProductosController(ProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] CrearProductoDto dto)
        {
            //Validaciones...

            await _productoServicio.CrearProductoAsync(dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.CategoriaId);

            return Ok("Producto creado exitosamente.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerProducto(int id)
        {
            try
            {
                var producto = await _productoServicio.ObtenerProductoAsync(id);

                if (producto == null)
                    return NotFound("Producto no encontrado.");

                return Ok(MapearProductoDto(producto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor.");
            }

        }

        [HttpGet]
        public async Task<IActionResult> ListarProductos()
        {
            var productos = await _productoServicio.ListarProductosAsync();
            
            return Ok(productos.Select(p => MapearProductoDto(p)));
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarProducto([FromBody] ActualizarProductoDto dto)
        {
            //Validaciones...

            await _productoServicio.ActualizarProductoAsync(dto.Id, dto.Nombre, dto.Descripcion, dto.Precio, dto.Stock, dto.CategoriaId);
            return Ok("Producto actualizado exitosamente.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            await _productoServicio.EliminarProductoAsync(id);
            return Ok("Producto eliminado exitosamente.");
        }

        private ProductoDto MapearProductoDto(Producto producto)
        {
            return new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                CategoriaId = producto.CategoriaId
            };
        }
    }
}
