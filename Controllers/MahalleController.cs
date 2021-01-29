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
        private IRepository<Log> _log;

        public MahalleController(IRepository<Mahalle> mahalle, IRepository<Log> log)
        {
            _mahalle = mahalle;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Mahalle entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenMahalle = await _mahalle.Add(entity);
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 3,
                    Aciklama = entity.Ad + " Mahallesi Eklendi",   
                });
                return CreatedAtAction("GetById", new { id= eklenenMahalle.ID}, eklenenMahalle);
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 3,
                    Aciklama = entity.Ad + " Mahallesi Eklenemedi",   
                });
            return BadRequest(ModelState);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _mahalle.GetById(id)!=null)
            {
                await _mahalle.Delete(id);
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 4,
                    Aciklama = "Mahalle Silindi",   
                });
                return Ok();
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 4,
                    Aciklama = "Mahalle Silinemedi",   
                });
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var m = await _mahalle.GetAll();
            await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 6,
                    Aciklama = "Mahalleler Listelendi",   
                });
            return Ok(m);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var m = await _mahalle.GetById(id);
            if (m != null)
            {
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 7,
                    Aciklama = "Mahalle Listelendi",   
                });
                return Ok(m);
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 7,
                    Aciklama = "Mahalle Listelenemedi",   
                });
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Mahalle entity)
        {
            if (await _mahalle.GetById(entity.ID)!=null)
            {
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 5,
                    Aciklama = entity.Ad + " Mahallesi Düzenlendi",   
                });
                return Ok(_mahalle.Update(entity));
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 5,
                    Aciklama = entity.Ad + " Mahallesi Düzenlenemedi",   
                });
            return NotFound();
        }
    }
}