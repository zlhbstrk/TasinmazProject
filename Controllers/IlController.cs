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
        public async Task<IActionResult> Add(Il entity)
        {
            try
            {
                var eklenenIl = await _il.Add(entity);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " İli Eklendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return CreatedAtAction("GetById", new { id = eklenenIl.Id }, eklenenIl);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " İli Eklenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _il.Delete(id);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 4,
                    Aciklama = id + " Id'li İl Silindi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok();
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 4,
                    Aciklama = id + " Id'li İl Silinemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> FullGetAll()
        {
            try
            {
                var il = await _il.FullGetAll();
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "İller Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(il);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "İller Listelenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{skipDeger}/{takeDeger}")]
        public async Task<IActionResult> GetAll(int skipDeger, int takeDeger)
        {
            try
            {
                var il = await _il.GetAll(skipDeger, takeDeger, 1);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "İller Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(il);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "İller Listelenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var il = await _il.GetById(id);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 7,
                    Aciklama = id + " Id'li İl Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(il);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 7,
                    Aciklama = id + " Id'li İl Listelenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<int> GetCount()
        {
            try
            {
                return await _il.GetCount();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Il entity)
        {
            try
            {
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 5,
                    Aciklama = entity.Ad + " İli Düzenlendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(_il.Update(entity));
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 5,
                    Aciklama = entity.Ad + " İli Düzenlenemedi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return NotFound();
            }
        }
    }
}