using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_products.src.models;

namespace backend_products.src.services
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> ObtenerProductos();

        Task<Producto> ObtenerProductoId(int id);

        Task<Producto> CrearProducto(Producto producto);

        Task<Boolean> ActualizarProducto(int id,Producto producto);

        Task<Boolean> EliminarProducto(int id);




    }
}