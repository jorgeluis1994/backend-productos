using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_products.src.models;
using backend_products.src.services;
using Microsoft.AspNetCore.Mvc;

namespace backend_products.src.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionController : ControllerBase
    {

        //Inyectamos el servicio en el controlador
        private readonly ITransaccionService _transaccionService;

        public TransaccionController(ITransaccionService transaccionService)
        {
            _transaccionService = transaccionService;

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
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerTransaccionPorId(int id)
        {
            try
            {
                // Obtener la transacción por su id
                var transaccion = await _transaccionService.ObtenerTransaccionPorId(id);

                if (transaccion == null)
                {
                    return NotFound(new { Status = "Error", Message = "Transacción no encontrada", Success = false });
                }

                return Ok(new { Status = "Success", Message = "Transacción obtenida con éxito", Success = true, Data = transaccion });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Status = "Error", Message = "Ocurrió un error al obtener la transacción.", Details = ex.Message });
            }
        }


        [HttpPost("save")]
        public async Task<ActionResult> CrearProducto([FromBody] Transaccion transaccion)
        {
            try
            {
                var transaccionCreada = await _transaccionService.CrearTransaccion(transaccion);

                if (transaccionCreada == null)
                {
                    return StatusCode(500, "Error al crear trnasaccion");
                }

                return Created("/api/producto", transaccionCreada);
            }
            catch (System.Exception)
            {
                throw;
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarTransaccion(int id)
        {
            try
            {

                var result = await _transaccionService.EliminarTransaccion(id);

                if (result)
                {
                    return Ok(new { Status = "Success", Message = "Transacción eliminada con éxito", Success = true });
                }
                else
                {
                    return NotFound(new { Status = "Error", Message = "Transacción no encontrada", Success = false });
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Status = "Error", Message = "Ocurrió un error al eliminar la transacción.", Success = false });
            }
        }
        [HttpPut("{id}")]

        public async Task<ActionResult<Boolean>> ActualizarTransaccion(int id, [FromBody] Transaccion transaccion)
        {
            try
            {
                return await _transaccionService.ActualizarTransaccion(id, transaccion);
            }
            catch (System.Exception)
            {

                throw;
            }

        }


    }
}