using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_products.src.models;
using Microsoft.EntityFrameworkCore;

namespace backend_products.src.services.imp
{
    public class ProductoService : IProductoService
    {

        // Inyectamos entity
        private readonly AplicationDbContext _dbContext;

        public ProductoService(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<bool> ActualizarProducto(int id, Producto producto)
        {
            try
            {
                var existeProducto = await _dbContext.Productos.FindAsync(id);
                if (existeProducto == null) return false;
                existeProducto.Nombre = producto.Nombre;
                existeProducto.Precio = producto.Precio;

                await _dbContext.SaveChangesAsync();

                return true;


            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<Producto> CrearProducto(Producto producto)
        {
            try
            {
                _dbContext.Productos.Add(producto);

                await _dbContext.SaveChangesAsync();

                return producto;

            }
            catch (System.Exception ex)
            {

                throw new Exception("Error al crear  producto", ex);
            }
        }

        public async Task<bool> EliminarProducto(int id)
        {
            try
            {
                var producto = await _dbContext.Productos.FindAsync(id);
                if (producto == null) return false;
                _dbContext.Productos.Remove(producto);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception ex)
            {

                throw new Exception("Error al eliminar producto", ex);
            }
        }

        public async Task<Producto> ObtenerProductoId(int id)
        {
            
            var producto = await _dbContext.Productos.FindAsync(id);

            if (producto == null)
            {
                throw new KeyNotFoundException("Producto no encontrado.");
            }

            return producto;
        }


        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            try
            {
                return await _dbContext.Productos.ToListAsync();
            }
            catch (System.Exception ex)
            {

                throw new Exception("Error al obtener los productos", ex);
            }
        }
    }
}