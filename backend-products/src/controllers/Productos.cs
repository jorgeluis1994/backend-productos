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
    public class Productos : ControllerBase
    {

        //Inyectamos el servicio en el controlador
        private readonly IProductoService _productoService;

        public Productos(IProductoService productoService)
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

    }
}