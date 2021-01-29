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
        private IRepository<Log> _log;

        public IlceController(IRepository<Ilce> ilce, IRepository<Log> log)
        {
            _ilce = ilce;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Ilce entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenIlce = await _ilce.Add(entity);
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 3,
                    Aciklama = entity.Ad + " İlçesi Eklendi",   
                });
                return CreatedAtAction("GetById", new { id= eklenenIlce.ID}, eklenenIlce);
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 3,
                    Aciklama = entity.Ad + " İlçesi Eklenemedi",   
                });
            return BadRequest(ModelState);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _ilce.GetById(id)!=null)
            {
                await _ilce.Delete(id);
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 4,
                    Aciklama = "İlçe Silindi",   
                });
                return Ok();
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 4,
                    Aciklama = "İlçe Silinemedi",   
                });
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var i = await _ilce.GetAll();
            await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 6,
                    Aciklama = "İlçeler Listelendi",   
                });
            return Ok(i);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var i = await _ilce.GetById(id);
            if (i != null)
            {
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 7,
                    Aciklama = "İlçe Listelendi",   
                });
                return Ok(i);
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 7,
                    Aciklama = "İlçe Listelenemedi",   
                });
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Ilce entity)
        {
            if (await _ilce.GetById(entity.ID)!=null)
            {
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 5,
                    Aciklama = entity.Ad + " İlçesi Düzenlendi",   
                });
                return Ok(_ilce.Update(entity));
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 5,
                    Aciklama = entity.Ad + " İlçesi Düzenlenemedi",   
                });
            return NotFound();
        }
    }
}