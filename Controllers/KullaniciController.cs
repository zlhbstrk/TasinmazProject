using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class KullaniciController : ControllerBase
    {
        private IRepository<Kullanici> _kullanici;
        private IRepository<Log> _log;

        public KullaniciController(IRepository<Kullanici> kullanici, IRepository<Log> log)
        {
            _kullanici = kullanici;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Kullanici entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenKullanici = await _kullanici.Add(entity);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " Kullanıcısı Eklendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return CreatedAtAction("GetById", new { id = eklenenKullanici.Id }, eklenenKullanici); //201 + eklenenKullanici
            }
            await _log.Add(new Log()
            {
                DurumId = 2,
                IslemTipId = 3,
                Aciklama = entity.Ad + " Kullanıcısı Eklenemedi",
                KullaniciId = 29,
                KullaniciAdi = "Zeliha",
                Tarih = DateTime.Now,
                IP = "123.123.123"
            });
            return BadRequest(ModelState); //Response Code-400 + validation errors
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _kullanici.GetById(id) != null)
            {
                await _kullanici.Delete(id);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 4,
                    Aciklama = id + " Id'li Kullanıcı Silindi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(); //200
            }
            await _log.Add(new Log()
            {
                DurumId = 2,
                IslemTipId = 4,
                Aciklama = id + " Id'li Kullanıcı Silinemedi",
                KullaniciId = 29,
                KullaniciAdi = "Zeliha",
                Tarih = DateTime.Now,
                IP = "123.123.123"
            });
            return NotFound();
        }

        [HttpGet]
        [Route("{skipDeger}/{takeDeger}")]
        public async Task<IActionResult> GetAll(int skipDeger, int takeDeger)
        {
            var kullanici = await _kullanici.GetAll(skipDeger, takeDeger, 1);
            await _log.Add(new Log()
            {
                DurumId = 1,
                IslemTipId = 6,
                Aciklama = "Kullanıcılar Listelendi",
                KullaniciId = 29,
                KullaniciAdi = "Zeliha",
                Tarih = DateTime.Now,
                IP = "123.123.123"
            });
            return Ok(kullanici);
        }

        [HttpGet]
        public async Task<IActionResult> FullGetAll()
        {
            var kullanici = await _kullanici.FullGetAll();
            await _log.Add(new Log()
            {
                DurumId = 1,
                IslemTipId = 6,
                Aciklama = "Kullanıcılar Listelendi",
                KullaniciId = 29,
                KullaniciAdi = "Zeliha",
                Tarih = DateTime.Now,
                IP = "123.123.123"
            });
            return Ok(kullanici); //Response Code-200
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var kullanici = await _kullanici.GetById(id);
            if (kullanici != null)
            {
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 7,
                    Aciklama = id + " Id'li Kullanıcı Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(kullanici);
            }
            await _log.Add(new Log()
            {
                DurumId = 2,
                IslemTipId = 7,
                Aciklama = id + " Id'li Kullanıcı Listelenemedi",
                KullaniciId = 29,
                KullaniciAdi = "Zeliha",
                Tarih = DateTime.Now,
                IP = "123.123.123"
            });
            return NotFound(); //Response Code-404
        }

        [HttpGet]
        public async Task<int> GetCount()
        {
            return await _kullanici.GetCount();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Kullanici entity)
        {
            if (await _kullanici.GetById(entity.Id) != null)
            {
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 5,
                    Aciklama = entity.Ad + " Kullanıcısı Düzenlendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(_kullanici.Update(entity)); //200 + data
            }
            await _log.Add(new Log()
            {
                DurumId = 2,
                IslemTipId = 5,
                Aciklama = entity.Ad + " Kullanıcısı Düzenemelendi",
                KullaniciId = 29,
                KullaniciAdi = "Zeliha",
                Tarih = DateTime.Now,
                IP = "123.123.123"
            });
            return NotFound();
        }

        [HttpGet]
        [Route("{email}/{sifre}")]
        public async Task<IActionResult> Login(string email, string sifre)
        {
            var kullanici = _kullanici.Login(email, sifre);
            if (kullanici != null)
            {
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 1,
                    Aciklama = "Sisteme Giriş Yapıldı",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(kullanici);
            }
            await _log.Add(new Log()
            {
                DurumId = 2,
                IslemTipId = 1,
                Aciklama = "Sisteme Giriş Yapılamadı",
                KullaniciId = 29,
                KullaniciAdi = "Zeliha",
                Tarih = DateTime.Now,
                IP = "123.123.123"
            });
            return NotFound(); //Response Code-404
        }
    }
}