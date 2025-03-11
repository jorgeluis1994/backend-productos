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
            _dbContext=dbContext;
            
        }
        public Task<bool> ActualizarTransaccion(int id, Transaccion transaccion)
        {
            throw new NotImplementedException();
        }

        public Task<Transaccion> CrearTransaccion(Transaccion transaccion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarTransaccion(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transaccion>> ObtenerTransacciones()
        {
            return await _dbContext.Transacciones.Include(t => t.Producto).ToListAsync();

        }

        public Task<Transaccion> ObtenerTransaccionPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidarStockYCrearTransaccion(Transaccion transaccion)
        {
            throw new NotImplementedException();
        }
    }
}