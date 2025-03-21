using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_products.src.models;
using backend_products.src.services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend_products.src.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {

        //Inyectamos el servicio en el controlador
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;

        }

        [HttpPost("save")]
        public async Task<ActionResult> CrearProducto([FromBody] Producto producto)
        {
            try
            {
                var productoCreado = await _productoService.CrearProducto(producto);

                if (productoCreado == null)
                {
                    return StatusCode(500, "Error al crear producto");
                }

                return Created("/api/producto", productoCreado);
            }
            catch (System.Exception)
            {
                throw;
            }


        }


        [HttpGet]
        public async Task<ActionResult> ObtenerProduts()
        {
            try
            {
                var listProducts = await _productoService.ObtenerProductos();
                return Ok(listProducts);

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerProductoPorId(int id)
        {
            try
            {
                var producto = await _productoService.ObtenerProductoId(id);
                return Ok(new { Status = "Success", Message = "Producto encontrado", Data = producto });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Status = "Error", Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = "Error", Message = "Ocurrió un error al obtener el producto.", Details = ex.Message });
            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            try
            {
                var producto = await _productoService.EliminarProducto(id);
                return Ok(new { Status = "Success", Message = "Producto eliminado con éxito", Success = true });

            }
            catch (System.Exception ex)
            {

                return StatusCode(500, "Ocurrió un error al eliminar el producto.");
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Boolean>> ActualizarProducto(int id, [FromBody] Producto producto)
        {
            try
            {
                return await _productoService.ActualizarProducto(id, producto);
            }
            catch (System.Exception)
            {

                throw;
            }

        }



    }
}