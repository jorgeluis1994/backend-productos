using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_products.src.models
{
    public class Transaccion
    {
        public int Id { set; get; }
        public DateTime Fecha { set; get; }

        public string Tipo { set; get; }

        public int ProductoId { set; get; }

        public Producto Producto { set; get; }

        public int Cantidad { set; get; }

        public decimal PrecioUnitario { set; get; }

        public decimal PrecioTotal { set; get; }

        public string Detalle { set; get; }

    }
}