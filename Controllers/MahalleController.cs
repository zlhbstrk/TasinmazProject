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
        public async Task<IActionResult> Add(Mahalle entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenMahalle = await _mahalle.Add(entity);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " Mahallesi Eklendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return CreatedAtAction("GetById", new { id = eklenenMahalle.Id }, eklenenMahalle);
            }
            await _log.Add(new Log()
            {
                DurumId = 2,
                IslemTipId = 3,
                Aciklama = entity.Ad + " Mahallesi Eklenemedi",
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
            if (await _mahalle.GetById(id) != null)
            {
                await _mahalle.Delete(id);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 4,
                    Aciklama = id + " Id'li Mahalle Silindi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok();
            }
            await _log.Add(new Log()
            {
                DurumId = 2,
                IslemTipId = 4,
                Aciklama = id + " Id'li Mahalle Silinemedi",
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
            var mahalle = await _mahalle.FullGetAll();
            await _log.Add(new Log()
            {
                DurumId = 1,
                IslemTipId = 6,
                Aciklama = "Mahalleler Listelendi",
                KullaniciId = 29,
                KullaniciAdi = "Zeliha",
                Tarih = DateTime.Now,
                IP = "123.123.123"
            });
            return Ok(mahalle);
        }

        [HttpGet]
        [Route("{skipDeger}/{takeDeger}")]
        public async Task<IActionResult> GetAll(int skipDeger, int takeDeger)
        {
            var mahalle = await _mahalle.GetAll(skipDeger, takeDeger, 1);
            await _log.Add(new Log()
            {
                DurumId = 1,
                IslemTipId = 6,
                Aciklama = "Mahalleler Listelendi",
                KullaniciId = 29,
                KullaniciAdi = "Zeliha",
                Tarih = DateTime.Now,
                IP = "123.123.123"
            });
            return Ok(mahalle);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mahalle = await _mahalle.GetById(id);
            if (mahalle != null)
            {
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 7,
                    Aciklama = id + " Id'li Mahalle Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(mahalle);
            }
            await _log.Add(new Log()
            {
                DurumId = 2,
                IslemTipId = 7,
                Aciklama = id + " Id'li Mahalle Listelenemedi",
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
            return await _mahalle.GetCount();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Mahalle entity)
        {
            if (await _mahalle.GetById(entity.Id) != null)
            {
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 5,
                    Aciklama = entity.Ad + " Mahallesi Düzenlendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(_mahalle.Update(entity));
            }
            await _log.Add(new Log()
            {
                DurumId = 2,
                IslemTipId = 5,
                Aciklama = entity.Ad + " Mahallesi Düzenlenemedi",
                KullaniciId = 29,
                KullaniciAdi = "Zeliha",
                Tarih = DateTime.Now,
                IP = "123.123.123"
            });
            return NotFound();
        }
    }
}