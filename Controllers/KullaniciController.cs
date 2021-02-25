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
            try
            {
                if (ModelState.IsValid)
                {
                    var eklenenKullanici = await _kullanici.Add(entity);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 3,
                        Aciklama = entity.Ad + " Kullanıcısı Eklendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return CreatedAtAction("GetById", new { id = eklenenKullanici.Id }, eklenenKullanici); //201 + eklenenKullanici
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 3,
                        Aciklama = entity.Ad + " Kullanıcısı Eklenemedi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return BadRequest(ModelState); //Response Code-400 + validation errors
                }
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 3,
                    Aciklama = "Kullanıcı Servisinde Ekleme Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return BadRequest(ModelState); //Response Code-400 + validation errors
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _kullanici.GetById(id) != null)
                {
                    await _kullanici.Delete(id);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 4,
                        Aciklama = id + " Id'li Kullanıcı Silindi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok(); //200
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 4,
                        Aciklama = id + " Id'li Kullanıcı Silinemedi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return NotFound();
                }
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 4,
                    Aciklama = "Kullanıcı Servisinde Silme Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
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
                var kullanici = await _kullanici.GetAll(skipDeger, takeDeger, 1, 1);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Kullanıcılar Listelendi",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return Ok(kullanici);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "Kullanıcı Servisinde Listeleme Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> FullGetAll()
        {
            try
            {
                var kullanici = await _kullanici.FullGetAll();
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Kullanıcılar Listelendi",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return Ok(kullanici); //Response Code-200
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "Kullanıcı Servisinde Listeleme Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
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
                var kullanici = await _kullanici.GetById(id);
                if (kullanici != null)
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 7,
                        Aciklama = id + " Id'li Kullanıcı Listelendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok(kullanici);
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 7,
                        Aciklama = id + " Id'li Kullanıcı Listelenemedi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return NotFound(); //Response Code-404
                }
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 7,
                    Aciklama = "Kullanıcı Servisinde GetById Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return NotFound(); //Response Code-404
            }
        }

        [HttpGet]
        public async Task<int> GetCount()
        {
            try
            {
                return await _kullanici.GetCount();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Kullanici entity)
        {
            try
            {
                if (await _kullanici.GetById(entity.Id) != null)
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 5,
                        Aciklama = entity.Ad + " Kullanıcısı Düzenlendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok(_kullanici.Update(entity)); //200 + data
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 5,
                        Aciklama = entity.Ad + " Kullanıcısı Düzenemelendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return NotFound();
                }
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 5,
                    Aciklama = "Kullanıcı Servisinde Düzenleme Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{email}/{sifre}")]
        public async Task<IActionResult> Login(string email, string sifre)
        {
            try
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
                        KullaniciAdi = "xyz",
                        Tarih = DateTime.Now,
                        IP = ""
                    });
                    return Ok(kullanici);
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 1,
                        Aciklama = "Sisteme Giriş Yapılamadı",
                        KullaniciId = 29,
                        KullaniciAdi = "xyz",
                        Tarih = DateTime.Now,
                        IP = ""
                    });
                    return NotFound(); //Response Code-404
                }
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 1,
                    Aciklama = "Kullanıcı Servisinde Login Hatası Oluştu!",
                    KullaniciId = 29,
                    KullaniciAdi = "xyz",
                    Tarih = DateTime.Now,
                    IP = ""
                });
                return NotFound(); //Response Code-404
            }
        }
    }
}