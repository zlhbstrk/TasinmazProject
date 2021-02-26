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
                if (ModelState.IsValid)
                {
                    var eklenenIl = await _il.Add(entity);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 3,
                        Aciklama = entity.Ad + " İli Eklendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return CreatedAtAction("GetById", new { id = eklenenIl.Id }, eklenenIl);
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 3,
                        Aciklama = entity.Ad + " İli Eklenemedi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 3,
                    Aciklama = "İl Servisinde Ekleme Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
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
                if (await _il.GetById(id) != null)
                {
                    await _il.Delete(id);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 4,
                        Aciklama = id + " Id'li İl Silindi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok();
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 4,
                        Aciklama = id + " Id'li İl Silinemedi",
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
                    Aciklama = "İl Servisinde Silme Hatası Oluştu!",
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
                var il = await _il.FullGetAll();
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "İller Listelendi",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return Ok(il);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "İl Servisinde Listeleme Hatası Oluştu!",
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
                var il = await _il.GetAll(skipDeger, takeDeger);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "İller Listelendi",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return Ok(il);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "İl Servisinde Listeleme Hatası Oluştu!",
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
                var il = await _il.GetById(id);
                if (il != null)
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 7,
                        Aciklama = id + " Id'li İl Listelendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok(il);
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 7,
                        Aciklama = id + " Id'li İl Listelenemedi",
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
                    IslemTipId = 7,
                    Aciklama = "İl Servisinde GetById Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
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
                if (await _il.GetById(entity.Id) != null)
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 5,
                        Aciklama = entity.Ad + " İli Düzenlendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok(_il.Update(entity));
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 5,
                        Aciklama = entity.Ad + " İli Düzenlenemedi",
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
                    Aciklama = "İl Servisinde Düzenleme Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return NotFound();
            }
        }
    }
}