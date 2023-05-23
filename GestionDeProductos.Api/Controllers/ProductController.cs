using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Business.Services;
using GestionDeProductos.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ProductController> _logger;
        private readonly IGenericService<Producto> _service;

        public ProductController(ILogger<ProductController> logger, IGenericService<Producto> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<Producto> GetProduct(int id)
        {
            return await _service.GetOne(id);
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IEnumerable<Producto>> GetAllProducts()
        {
            return await _service.GetAll();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task CreateProduct([FromBody] Producto product)
        {
            await _service.Insert(product);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task UpdateProduct([FromBody] Producto product)
        {
            await _service.Update(product);
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task DeleteProduct(int id)
        {
            await _service.Delete(id);
        }

    }
}