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

        private IRepository<Log> _log;

        public IlController(IRepository<Il> il, IRepository<Log> log)
        {
            _il = il;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Il entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenIl = await _il.Add(entity);
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 3,
                    Aciklama = entity.Ad + " İli Eklendi",   
                });
                return CreatedAtAction("GetById", new { id= eklenenIl.ID}, eklenenIl);
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 3,
                    Aciklama = entity.Ad + " İli Eklenemedi",   
                });
            return BadRequest(ModelState);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _il.GetById(id)!=null)
            {
                await _il.Delete(id);
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 4,
                    Aciklama = "İl Silindi",   
                });
                return Ok();
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 4,
                    Aciklama = "İl Silinemedi",   
                });
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var i = await _il.GetAll();
            await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 6,
                    Aciklama = "İller Listelendi",   
                });
            return Ok(i);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var i = await _il.GetById(id);
            if (i != null)
            {
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 7,
                    Aciklama = "İl Listelendi",   
                });
                return Ok(i);
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 7,
                    Aciklama = "İl Listelenemedi",   
                });
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Il entity)
        {
            if (await _il.GetById(entity.ID)!=null)
            {
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 5,
                    Aciklama = entity.Ad + " İli Düzenlendi",   
                });
                return Ok(_il.Update(entity));
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 5,
                    Aciklama = entity.Ad + " İli Düzenlenemedi",   
                });
            return NotFound();
        }
    }
}