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
        private IMahalleRepositoryy _mahalle;
        private ILogRepository _log;

        public MahalleController(IMahalleRepositoryy mahalle, ILogRepository log)
        {
            _mahalle = mahalle;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Mahalle entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var eklenenMahalle = await _mahalle.Add(entity);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 3,
                        Aciklama = entity.Ad + " Mahallesi Eklendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return CreatedAtAction("GetById", new { id = eklenenMahalle.Id }, eklenenMahalle);
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 3,
                        Aciklama = entity.Ad + " Mahallesi Eklenemedi",
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
                    Aciklama = "Mahalle Servisinde Ekleme Hatası Oluştu!",
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
                if (await _mahalle.GetById(id) != null)
                {
                    await _mahalle.Delete(id);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 4,
                        Aciklama = id + " Id'li Mahalle Silindi",
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
                        Aciklama = id + " Id'li Mahalle Silinemedi",
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
                    Aciklama = "Mahalle Servisinde Silme Hatası Oluştu!",
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
                var mahalle = await _mahalle.FullGetAll();
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Mahalleler Listelendi",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return Ok(mahalle);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "Mahalle Servisinde Listeleme Hatası Oluştu!",
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
                var mahalle = await _mahalle.GetAll(skipDeger, takeDeger);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Mahalleler Listelendi",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return Ok(mahalle);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "Mahalle Servisinde Listeleme Hatası Oluştu!",
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
                var mahalle = await _mahalle.GetById(id);
                if (mahalle != null)
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 7,
                        Aciklama = id + " Id'li Mahalle Listelendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok(mahalle);
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 7,
                        Aciklama = id + " Id'li Mahalle Listelenemedi",
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
                    Aciklama = "Mahalle Servisinde GetById Hatası Oluştu!",
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
                return await _mahalle.GetCount();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Mahalle entity)
        {
            try
            {
                if (await _mahalle.GetById(entity.Id) != null)
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 5,
                        Aciklama = entity.Ad + " Mahallesi Düzenlendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok(_mahalle.Update(entity));
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 5,
                        Aciklama = entity.Ad + " Mahallesi Düzenlenemedi",
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
                    Aciklama = "Mahalle Servisinde Düzenleme Hatası Oluştu!",
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