using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_products.src.models
{
    public class Producto
    {
        public int Id { set; get; }
        public string Nombre { set; get; }

        public string Descripcion { set; get; }

        public string Categoria { set; get; }

        public string Imagen { set; get; }

        public decimal Precio { set; get; }

        public int Stock { set; get; }

    }
}