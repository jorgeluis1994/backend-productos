using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_products.src.services;
using Microsoft.AspNetCore.Mvc;

namespace backend_products.src.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Transaccion : ControllerBase
    {

        //Inyectamos el servicio en el controlador
        private readonly ITransaccionService _transaccionService;

        public Transaccion(ITransaccionService transaccionService)
        {
           _transaccionService=transaccionService;

        }
         [HttpGet]
        public async Task<ActionResult> ObtenerTransactrions()
        {
            try
            {
                var listProducts = await _transaccionService.ObtenerTransacciones();
                return Ok(listProducts);

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        
    }
}