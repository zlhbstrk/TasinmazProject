using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TasinmazController : ControllerBase
    {
        private IRepository<ETasinmaz> _tasinmaz;

        public TasinmazController(IRepository<ETasinmaz> tasinmaz)
        {
            _tasinmaz = tasinmaz;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ETasinmaz entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenTasinmaz = await _tasinmaz.Add(entity);
                return CreatedAtAction("GetById", new { id= eklenenTasinmaz.ID}, eklenenTasinmaz);
            }
            return BadRequest(ModelState);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _tasinmaz.GetById(id)!=null)
            {
                await _tasinmaz.Delete(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var t = await _tasinmaz.GetAll();
            return Ok(t);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var t = await _tasinmaz.GetById(id);
            if (t != null)
            {
                return Ok(t);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{filter}")]
        public async Task<IActionResult> GetAllFilter(string filter)
        {
            var t = await _tasinmaz.GetAllFilter(filter);
            if (t != null)
            {
                return Ok(t);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ETasinmaz entity)
        {
            if (await _tasinmaz.GetById(entity.ID)!=null)
            {
                return Ok(_tasinmaz.Update(entity));
            }
            return NotFound();
        }
    }    
}