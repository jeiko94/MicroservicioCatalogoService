﻿namespace Catalogo.Api.DTOs
{
    public class CrearProductoDto
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
    }
}
