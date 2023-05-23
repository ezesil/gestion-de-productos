using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Business.Services;
using GestionDeProductos.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiendaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TiendaController> _logger;
        private readonly ITiendaService _service;

        public TiendaController(ILogger<TiendaController> logger, ITiendaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("GetTienda")]
        public async Task<Tienda> GetTienda(int id)
        {
            return await _service.GetOne(id);
        }

        [HttpGet]
        [Route("GetAllTiendas")]
        public async Task<IEnumerable<Tienda>> GetAllTiendas()
        {
            return await _service.GetAll();
        }

        [HttpPost]
        [Route("CreateTienda")]
        public async Task CreateTienda([FromBody] Tienda product)
        {
            await _service.Insert(product);
        }

        [HttpPut]
        [Route("UpdateTienda")]
        public async Task UpdateTienda([FromBody] Tienda product)
        {
            await _service.Update(product);
        }

        [HttpDelete]
        [Route("DeleteTienda")]
        public async Task DeleteTienda(int id)
        {
            await _service.Delete(id);
        }

    }
}