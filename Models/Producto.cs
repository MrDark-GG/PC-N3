namespace PC_N3.Models
{
    public class Producto
    {
        public int Id {get;set;}
        public string NombreProducto {get; set;}
        public string Foto {get; set;}
        public string Descripcion {get; set;}
        public decimal Precio {get; set;}
        public string Celular {get; set;}
        public string LugarCompra {get; set;}
        public string NombreComprador {get; set;}

        public Categoria Categoria {get; set;}

        public int CategoriaID {get; set;}
    }
}