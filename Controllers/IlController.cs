using System;
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
                    DurumId = 1,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " İli Eklendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return CreatedAtAction("GetById", new { id= eklenenIl.Id}, eklenenIl);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " İli Eklenemedi",
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
            if (await _il.GetById(id)!=null)
            {
                await _il.Delete(id);
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 4,
                    Aciklama = "İl Silindi",
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
                    Aciklama = "İl Silinemedi",
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
            var i = await _il.GetAll();
            await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "İller Listelendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
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
                    DurumId = 1,
                    IslemTipId = 7,
                    Aciklama = "İl Listelendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(i);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 7,
                    Aciklama = "İl Listelenemedi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Il entity)
        {
            if (await _il.GetById(entity.Id)!=null)
            {
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 5,
                    Aciklama = entity.Ad + " İli Düzenlendi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(_il.Update(entity));
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 5,
                    Aciklama = entity.Ad + " İli Düzenlenemedi",
                    KullaniciId = 1,
                    KullaniciAdi = "zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return NotFound();
        }
    }
}