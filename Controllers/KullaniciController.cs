using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class KullaniciController : ControllerBase
    {
        private IRepository<Kullanici> _kullanici;

        public KullaniciController(IRepository<Kullanici> kullanici)
        {
            _kullanici = kullanici;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Kullanici entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenKullanici = await _kullanici.Add(entity);
                return CreatedAtAction("GetById", new { id= eklenenKullanici.ID}, eklenenKullanici); //201 + eklenenKullanici
            }
            return BadRequest(ModelState); //Response Code-400 + validation errors
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _kullanici.GetById(id)!=null)
            {
                await _kullanici.Delete(id);
                return Ok(); //200
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var k = await _kullanici.GetAll();
            return Ok(k); //Response Code-200 + (body kısmına) k ekle
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var k = await _kullanici.GetById(id);
            if (k != null)
            {
                return Ok(k);
            }
            return NotFound(); //Response Code-404
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Kullanici entity)
        {
            if (await _kullanici.GetById(entity.ID)!=null)
            {
                return Ok(_kullanici.Update(entity)); //200 + data
            }
            return NotFound();
        }
    }
}