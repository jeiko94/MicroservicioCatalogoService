using Catalogo.Api.DTOs;
using Catalogo.Aplicacion.Servicios;
using Catalogo.Dominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaServicio _categoriaServicio;

        public CategoriaController(CategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCategoria([FromBody] CrearCategoriaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _categoriaServicio.CrearCategoriaAsync(dto.Nombre, dto.Descripcion);
                return Ok("Categoria creada exitosamente.");
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> ObtenerCategoria(int id)
        {
            try
            {
                var categoria = await _categoriaServicio.ObtenerCategoriaAsync(id);

                if (categoria == null)
                    return NotFound("Categoria no encontrada.");

                return Ok(MapearCategoriaDto(categoria));
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> ListarCategorias()
        {
            try
            {
                var categorias = await _categoriaServicio.ListarCategoriasAsync();
                return Ok(categorias.Select(c => MapearCategoriaDto(c)));
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCategoria([FromBody] ActualizarCategoriaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _categoriaServicio.ActualizarCategoriaAsync(dto.Id, dto.Nombre, dto.Descripcion);
                return Ok("Categoria actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            try
            {
                await _categoriaServicio.EliminarCategoriaAsync(id);
                return Ok("Categoria eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        private CategoriaDto MapearCategoriaDto(Categoria categoria)
        {
            return new CategoriaDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion
            };
        }
    }
}
