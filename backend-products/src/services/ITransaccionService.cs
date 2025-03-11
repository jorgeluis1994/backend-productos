using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_products.src.models;

namespace backend_products.src.services
{
    public interface ITransaccionService
    {
        Task<IEnumerable<Transaccion>> ObtenerTransacciones();

        Task<Transaccion> ObtenerTransaccionPorId(int id);

        Task<Transaccion> CrearTransaccion(Transaccion transaccion);

        Task<bool> ValidarStockYCrearTransaccion(Transaccion transaccion);

        Task<bool> ActualizarTransaccion(int id, Transaccion transaccion);

        Task<bool> EliminarTransaccion(int id);
    }

}