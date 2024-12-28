namespace Catalogo.Dominio.Models
{
    //Representa un producto en el catalogo de la tienda
    public class Producto
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public bool Activo { get; set; } //Indica si el producto esta activo o no
    }
}
