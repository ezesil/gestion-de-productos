using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Business.Services;
using GestionDeProductos.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<DepositoController> _logger;
        private readonly IDepositoService _service;

        public DepositoController(ILogger<DepositoController> logger, IDepositoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("GetDeposito")]
        public async Task<Deposito> GetDeposito(int id)
        {
            return await _service.GetOne(id);
        }

        [HttpGet]
        [Route("GetAllDepositos")]
        public async Task<IEnumerable<Deposito>> GetAllDepositos()
        {
            return await _service.GetAll();
        }

        [HttpPost]
        [Route("CreateDeposito")]
        public async Task CreateDeposito([FromBody] Deposito product)
        {
            await _service.Insert(product);
        }

        [HttpPut]
        [Route("UpdateDeposito")]
        public async Task UpdateDeposito([FromBody] Deposito product)
        {
            await _service.Update(product);
        }

        [HttpDelete]
        [Route("DeleteDeposito")]
        public async Task DeleteDeposito(int id)
        {
            await _service.Delete(id);
        }

        [HttpPost]
        [Route("GetAllProductoDeposito")]
        public async Task<IEnumerable<ProductoDeposito>> GetAllProductoDeposito(int id)
        {
            return await _service.GetAllDepositoProduct(id);
        }


        [HttpPost]
        [Route("GetProductoDeposito")]
        public async Task<ProductoDeposito> GetProductoDeposito(int idDeposito, int idProducto)
        {
            return await _service.GetDepositoProduct(idDeposito, idProducto);
        }

        [HttpPost]
        [Route("AgregarProducto")]
        public async Task AgregarProducto([FromBody] ProductoDeposito product)
        {
            _service.AgregarProducto(product);
        }

        [HttpPost]
        [Route("TransferirProductoADeposito")]
        public async Task TransferirProductoADeposito([FromBody] ProductoDeposito product, int idDeposito, int cantidad)
        {
            _service.TransferProductoADeposito(product, idDeposito, cantidad);
        }

        [HttpPost]
        [Route("TransferirProductoATienda")]
        public async Task TransferirProductoATienda([FromBody] ProductoDeposito product, int idTienda, int cantidad)
        {
            _service.TransferProductoATienda(product, idTienda, cantidad);
        }



    }
}