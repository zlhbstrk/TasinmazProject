using System;
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
        private IRepository<Log> _log;

        public TasinmazController(IRepository<ETasinmaz> tasinmaz, IRepository<Log> log)
        {
            _tasinmaz = tasinmaz;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ETasinmaz entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenTasinmaz = await _tasinmaz.Add(entity);
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 3,
                    Aciklama = entity.Id + " Taşınmazı Eklendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123" 
                });
                return CreatedAtAction("GetById", new { id= eklenenTasinmaz.Id}, eklenenTasinmaz);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 3,
                    Aciklama = entity.Id + " Taşınmazı Eklenemedi",
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
            if (await _tasinmaz.GetById(id)!=null)
            {
                await _tasinmaz.Delete(id);
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 4,
                    Aciklama = "Taşınmaz Silindi",
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
                    Aciklama = "Taşınmaz Silinemedi",
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
            var t = await _tasinmaz.GetAll();
            await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Taşınmazlar Listelendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return Ok(t);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var t = await _tasinmaz.GetById(id);
            if (t != null)
            {
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 7,
                    Aciklama = "Taşınmaz Listelendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(t);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 4,
                    Aciklama = "Taşınmaz Listelenemedi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }

        [HttpGet]
        [Route("{filter}")]
        public async Task<IActionResult> GetAllFilter(string filter)
        {
            var t = await _tasinmaz.GetAllFilter(filter);
            if (t != null)
            {
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 8,
                    Aciklama = "Taşınmaz Filtrelendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(t);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 8,
                    Aciklama = "Taşınmaz Filtrelenemedi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ETasinmaz entity)
        {
            if (await _tasinmaz.GetById(entity.Id)!=null)
            {
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 5,
                    Aciklama = entity.Id + " Taşınmazı Düzenlendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(_tasinmaz.Update(entity));
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 5,
                    Aciklama = entity.Id + " Taşınmazı Düzenlenemedi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }
    }    
}