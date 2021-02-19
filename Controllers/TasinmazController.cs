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
                    Aciklama = entity.Id + " Id'li Taşınmaz Eklendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123" 
                });
                return CreatedAtAction("GetById", new { id= eklenenTasinmaz.Id}, eklenenTasinmaz);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 3,
                    Aciklama = entity.Id + " Id'li Taşınmaz Eklenemedi",
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
            if (await _tasinmaz.GetById(id)!=null)
            {
                await _tasinmaz.Delete(id);
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 4,
                    Aciklama = id + " Id'li Taşınmaz Silindi",
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
                    Aciklama = id + "Id'li Taşınmaz Silinemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> FullGetAll()
        {
            var t = await _tasinmaz.FullGetAll();
            await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Taşınmazlar Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return Ok(t);
        }

        [HttpGet]
        [Route("{skipDeger}/{takeDeger}")]
        public async Task<IActionResult> GetAll(int skipDeger, int takeDeger)
        {
            var t = await _tasinmaz.GetAll(skipDeger, takeDeger, 29);
            await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Taşınmazlar Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
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
                    Aciklama = id + " Id'li Taşınmaz Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(t);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 7,
                    Aciklama = id + " Id'li Taşınmaz Listelenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
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
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(t);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 8,
                    Aciklama = "Taşınmaz Filtrelenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }

        [HttpGet]
        public async Task<int> GetCount()
        {
            return await _tasinmaz.GetCount();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ETasinmaz entity)
        {
            if (await _tasinmaz.GetById(entity.Id)!=null)
            {
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 5,
                    Aciklama = entity.Id + " Id'li Taşınmaz Düzenlendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(_tasinmaz.Update(entity));
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 5,
                    Aciklama = entity.Id + " Id'li Taşınmaz Düzenlenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }
    }    
}