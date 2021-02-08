using System;
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
                    DurumId = 1,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " İlçesi Eklendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return CreatedAtAction("GetById", new { id= eklenenIlce.Id}, eklenenIlce);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " İlçesi Eklenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
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
                    DurumId = 1,
                    IslemTipId = 4,
                    Aciklama = "İlçe Silindi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok();
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 4,
                    Aciklama = "İlçe Silinemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var i = await _ilce.GetAll();
            await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "İlçeler Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
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
                    DurumId = 1,
                    IslemTipId = 7,
                    Aciklama = "İlçe Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(i);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 7,
                    Aciklama = "İlçe Listelenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Ilce entity)
        {
            if (await _ilce.GetById(entity.Id)!=null)
            {
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 5,
                    Aciklama = entity.Ad + " İlçesi Düzenlendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(_ilce.Update(entity));
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 5,
                    Aciklama = entity.Ad + " İlçesi Düzenlenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }
    }
}