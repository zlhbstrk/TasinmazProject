using System;
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
                    DurumId = 1,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " Mahallesi Eklendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123" 
                });
                return CreatedAtAction("GetById", new { id= eklenenMahalle.Id}, eklenenMahalle);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " Mahallesi Eklenemedi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
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
                    DurumId = 1,
                    IslemTipId = 4,
                    Aciklama = "Mahalle Silindi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok();
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 4,
                    Aciklama = "Mahalle Silinemedi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var m = await _mahalle.GetAll();
            await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Mahalleler Listelendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
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
                    DurumId = 1,
                    IslemTipId = 7,
                    Aciklama = "Mahalle Listelendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(m);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 7,
                    Aciklama = "Mahalle Listelenemedi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Mahalle entity)
        {
            if (await _mahalle.GetById(entity.Id)!=null)
            {
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 5,
                    Aciklama = entity.Ad + " Mahallesi Düzenlendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(_mahalle.Update(entity));
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 5,
                    Aciklama = entity.Ad + " Mahallesi Düzenlenemedi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }
    }
}