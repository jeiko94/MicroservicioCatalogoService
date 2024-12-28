﻿namespace Catalogo.Dominio.Models
{
    //Representa una categoria de productos
    public class Categoria
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
