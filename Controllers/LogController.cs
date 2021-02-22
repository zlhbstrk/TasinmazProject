using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LogController : ControllerBase
    {
        private IRepository<Log> _log;

        public LogController(IRepository<Log> log)
        {
            _log = log;
        }

        [HttpGet]
        public async Task<IActionResult> FullGetAll()
        {
            var log = await _log.FullGetAll();
            return Ok(log);
        }

        [HttpGet]
        [Route("{skipDeger}/{takeDeger}")]
        public async Task<IActionResult> GetAll(int skipDeger, int takeDeger)
        {
            var log = await _log.GetAll(skipDeger, takeDeger, 1);
            return Ok(log);
        }

        [HttpGet]
        [Route("{filter}")]
        public async Task<IActionResult> GetAllFilter(string filter)
        {
            var log = await _log.GetAllFilter(filter);
            if (log != null)
            {
                return Ok(log);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<int> GetCount()
        {
            return await _log.GetCount();
        }
    }
}