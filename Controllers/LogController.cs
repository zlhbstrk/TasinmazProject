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
            var l = await _log.FullGetAll();
            return Ok(l);
        }

        [HttpGet]
        [Route("{skipDeger}/{takeDeger}")]
        public async Task<IActionResult> GetAll(int skipDeger, int takeDeger)
        {
            var l = await _log.GetAll(skipDeger, takeDeger);
            return Ok(l);
        }

        [HttpGet]
        [Route("{filter}")]
        public async Task<IActionResult> GetAllFilter(string filter)
        {
            var l = await _log.GetAllFilter(filter);
            if (l != null)
            {
                return Ok(l);
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