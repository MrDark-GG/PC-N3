using System.Collections.Generic;

namespace PC_N3.Models
{
    public class Categoria
    {
        public int Id {get;set;}
        public string NombreCategoria {get; set;}
        public ICollection<Producto> Producto{get; set;}
    }
}