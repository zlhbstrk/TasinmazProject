using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;
using Tasinmaz.Models;
using Tasinmaz.Helpers;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class KullaniciController : ControllerBase
    {
        private IKullaniciRepository _kullanici;
        private ILogRepository _log;

        public KullaniciController(IKullaniciRepository kullanici, ILogRepository log)
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
                    if (Helper.SifreKontrol(entity.Sifre) == entity.Sifre)
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
                            Aciklama = entity.Sifre + " Şifre Formatı Yanlıştır",
                            KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                            KullaniciAdi = Request.Headers["current-user-name"],
                            Tarih = DateTime.Now,
                            IP = Request.Headers["ip-address"]
                        });
                        return BadRequest(ModelState);
                    }
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
            catch (System.Exception ex)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 3,
                    Aciklama = "Kullanıcı Servisinde Ekleme Hatası Oluştu!" + ex.Message,
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
                var kullanici = await _kullanici.GetAll(skipDeger, takeDeger);
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
        public async Task<IActionResult> Logout()
        {
            await _log.Add(new Log()
            {
                DurumId = 1,
                IslemTipId = 2,
                Aciklama = "Sistemden Çıkış Yapıldı",
                KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                KullaniciAdi = Request.Headers["current-user-name"],
                Tarih = DateTime.Now,
                IP = Request.Headers["ip-address"]
            });
            return Ok();
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
                        KullaniciId = kullanici.Result.Id,
                        KullaniciAdi = kullanici.Result.Ad,
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
                        IslemTipId = 1,
                        Aciklama = "Sisteme Giriş Yapılamadı",
                        KullaniciId = 81,
                        KullaniciAdi = Request.Headers["current-user-email"],
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
                    IslemTipId = 1,
                    Aciklama = "Kullanıcı Servisinde Login Hatası Oluştu!",
                    KullaniciId = 81,
                    KullaniciAdi = Request.Headers["current-user-email"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return NotFound(); //Response Code-404
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PasswordChange(int id, PasswordChangeDto entity)
        {
            try
            {
                var o = await _kullanici.PasswordControl(id, entity.MevcutSifre);
                if (o)
                {
                    await _kullanici.PasswordChange(entity);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 5,
                        Aciklama = entity.Id + " Id'li Kullanıcının Şifresi Düzenlendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok("Başarılı"); //200 + data
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 5,
                        Aciklama = entity.Id + " Id'li Kullanıcının Şifresi Düzenemelendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return NoContent();
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
                return BadRequest();
            }
        }
    }
}