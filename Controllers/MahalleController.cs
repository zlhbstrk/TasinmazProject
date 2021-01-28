using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MahalleController : ControllerBase
    {
        private IRepository<Mahalle> _mahalle;

        public MahalleController(IRepository<Mahalle> mahalle)
        {
            _mahalle = mahalle;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Mahalle entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenMahalle = await _mahalle.Add(entity);
                return CreatedAtAction("GetById", new { id= eklenenMahalle.ID}, eklenenMahalle);
            }
            return BadRequest(ModelState);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _mahalle.GetById(id)!=null)
            {
                await _mahalle.Delete(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var m = await _mahalle.GetAll();
            return Ok(m);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var m = await _mahalle.GetById(id);
            if (m != null)
            {
                return Ok(m);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Mahalle entity)
        {
            if (await _mahalle.GetById(entity.ID)!=null)
            {
                return Ok(_mahalle.Update(entity));
            }
            return NotFound();
        }
    }
}