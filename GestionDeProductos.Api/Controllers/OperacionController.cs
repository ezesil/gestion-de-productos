using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperacionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<OperacionController> _logger;
        private readonly IGenericService<Operacion> _service;

        public OperacionController(ILogger<OperacionController> logger, IGenericService<Operacion> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("GetOperacion")]
        public async Task<Operacion> GetOperacion(int id)
        {
            return await _service.GetOne(id);
        }

        [HttpGet]
        [Route("GetAllOperacions")]
        public async Task<IEnumerable<Operacion>> GetAllOperaciones()
        {
            return await _service.GetAll();
        }

        [HttpPost]
        [Route("CreateOperacion")]
        public async Task CreateOperacion([FromBody] Operacion Operacion)
        {
            await _service.Insert(Operacion);
        }

        [HttpPut]
        [Route("UpdateOperacion")]
        public async Task UpdateOperacion([FromBody] Operacion Operacion)
        {
            await _service.Update(Operacion);
        }

        [HttpDelete]
        [Route("DeleteOperacion")]
        public async Task DeleteOperacion(int id)
        {
            await _service.Delete(id);
        }

    }
}