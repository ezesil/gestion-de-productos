using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestionDeProductos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sw = new Stopwatch();
            sw.Start();
            var logs = await _logService.GetAll();
            sw.Stop();
            return Ok(new BaseResponse()
            {
                Data = logs,
                ResponseTime = sw.ElapsedMilliseconds.ToString()            
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var sw = new Stopwatch();
            sw.Start();
            var log = await _logService.GetOne(id);
            if (log == null)
            {
                return NotFound();
            }
            sw.Stop();
            return Ok(new BaseResponse()
            {
                Data = log,
                ResponseTime = sw.ElapsedMilliseconds.ToString()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Log log)
        {
            var sw = new Stopwatch();
            sw.Start();
            await _logService.Insert(log);
            sw.Stop();
            return Ok(new BaseResponse()
            {
                ResponseTime = sw.ElapsedMilliseconds.ToString(),
                Status = 200
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Log log)
        {
            var sw = new Stopwatch();
            sw.Start();
            if (id != log.IdLog)
            {
                return BadRequest();
            }

            await _logService.Update(log);
            sw.Stop();
            return Ok(new BaseResponse()
            {
                ResponseTime = sw.ElapsedMilliseconds.ToString()
            });
        }
    }
}
