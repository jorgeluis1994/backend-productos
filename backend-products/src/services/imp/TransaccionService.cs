using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_products.src.models;
using Microsoft.EntityFrameworkCore;

namespace backend_products.src.services.imp
{
    public class TransaccionService : ITransaccionService
    {
        // Inyectamos entity
        private readonly AplicationDbContext _dbContext;

        public TransaccionService(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public Task<bool> ActualizarTransaccion(int id, Transaccion transaccion)
        {
            throw new NotImplementedException();
        }

        public async Task<Transaccion> CrearTransaccion(Transaccion transaccion)
        {
            // Buscar el producto en la base de datos por su ID
            var producto = await _dbContext.Productos.FindAsync(transaccion.ProductoId);

            if (producto == null)
            {
                // Si no se encuentra el producto, lanzar una excepción con un mensaje claro
                throw new InvalidOperationException("Producto no encontrado.");
            }

            // Verificar si la transacción es una venta y si hay suficiente stock disponible
            if (transaccion.Tipo.ToLower() == "venta")
            {
                if (producto.Stock < transaccion.Cantidad)
                {
                    // Si no hay suficiente stock, lanzar una excepción
                    throw new InvalidOperationException("Stock insuficiente para completar la venta.");
                }
            }

            // Calcular el precio total de la transacción
            transaccion.PrecioTotal = transaccion.Cantidad * transaccion.PrecioUnitario;

            // Actualizar el stock del producto según el tipo de transacción
            if (transaccion.Tipo.ToLower() == "compra")
            {
                producto.Stock += transaccion.Cantidad; // Aumentar stock en caso de compra
            }
            else if (transaccion.Tipo.ToLower() == "venta")
            {
                producto.Stock -= transaccion.Cantidad; // Disminuir stock en caso de venta
            }

            // Intentar guardar los cambios en la base de datos
            try
            {
                // Agregar la nueva transacción a la base de datos
                _dbContext.Transacciones.Add(transaccion);
                await _dbContext.SaveChangesAsync(); // Guardar cambios de transacción y stock
            }
            catch (Exception ex)
            {
                // Si ocurre un error durante el guardado, lanzar una excepción con el mensaje de error
                throw new Exception("Hubo un problema al registrar la transacción. " + ex.Message);
            }

            // Retornar la transacción registrada
            return transaccion;
        }

        public async Task<bool> EliminarTransaccion(int id)
        {

            var transaccion = await _dbContext.Transacciones.FindAsync(id);


            if (transaccion == null)
            {
                return false;
            }

            // Eliminar la transacción
            _dbContext.Transacciones.Remove(transaccion);


            await _dbContext.SaveChangesAsync();

            return true;
        }


        public async Task<IEnumerable<Transaccion>> ObtenerTransacciones()
        {
            var transacciones = await (from t in _dbContext.Transacciones
                                       join p in _dbContext.Productos on t.ProductoId equals p.Id
                                       select new
                                       {
                                           t.Id,
                                           t.Fecha,
                                           t.Tipo,
                                           t.ProductoId,
                                           ProductoNombre = p.Nombre, // Puedes seleccionar otros campos del producto aquí
                                           t.Cantidad,
                                           t.PrecioUnitario,
                                           t.PrecioTotal,
                                           t.Detalle
                                       }).ToListAsync();

            // Convertir a una lista de transacciones si lo necesitas
            return transacciones.Select(t => new Transaccion
            {
                Id = t.Id,
                Fecha = t.Fecha,
                Tipo = t.Tipo,
                ProductoId = t.ProductoId,
                Cantidad = t.Cantidad,
                PrecioUnitario = t.PrecioUnitario,
                PrecioTotal = t.PrecioTotal,
                Detalle = t.Detalle
            }).ToList();
        }


        public async Task<Transaccion> ObtenerTransaccionPorId(int id)
        {

            var transaccion = await _dbContext.Transacciones.FindAsync(id);


            if (transaccion == null)
            {
                throw new KeyNotFoundException("Transacción no encontrada.");
            }

            // Retornamos la transacción encontrada
            return transaccion;
        }


        public Task<bool> ValidarStockYCrearTransaccion(Transaccion transaccion)
        {
            throw new NotImplementedException();
        }
    }
}