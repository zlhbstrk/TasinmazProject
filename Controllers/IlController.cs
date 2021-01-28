using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IlController : ControllerBase
    {
        private IRepository<Il> _il;

        public IlController(IRepository<Il> il)
        {
            _il = il;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Il entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenIl = await _il.Add(entity);
                return CreatedAtAction("GetById", new { id= eklenenIl.ID}, eklenenIl);
            }
            return BadRequest(ModelState);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _il.GetById(id)!=null)
            {
                await _il.Delete(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var i = await _il.GetAll();
            return Ok(i);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var i = await _il.GetById(id);
            if (i != null)
            {
                return Ok(i);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Il entity)
        {
            if (await _il.GetById(entity.ID)!=null)
            {
                return Ok(_il.Update(entity));
            }
            return NotFound();
        }
    }
}