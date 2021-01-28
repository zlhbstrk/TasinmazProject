using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IlceController : ControllerBase
    {
        private IRepository<Ilce> _ilce;

        public IlceController(IRepository<Ilce> ilce)
        {
            _ilce = ilce;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Ilce entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenIlce = await _ilce.Add(entity);
                return CreatedAtAction("GetById", new { id= eklenenIlce.ID}, eklenenIlce);
            }
            return BadRequest(ModelState);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _ilce.GetById(id)!=null)
            {
                await _ilce.Delete(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var i = await _ilce.GetAll();
            return Ok(i);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var i = await _ilce.GetById(id);
            if (i != null)
            {
                return Ok(i);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Ilce entity)
        {
            if (await _ilce.GetById(entity.ID)!=null)
            {
                return Ok(_ilce.Update(entity));
            }
            return NotFound();
        }
    }
}