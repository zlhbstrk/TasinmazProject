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
        private ITasinmazRepository _tasinmaz;
        private ILogRepository _log;

        public TasinmazController(ITasinmazRepository tasinmaz, ILogRepository log)
        {
            _tasinmaz = tasinmaz;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ETasinmaz entity)
        {
            try
            {
                entity.KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]);
                if (ModelState.IsValid)
                {
                    var eklenenTasinmaz = await _tasinmaz.Add(entity);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 3,
                        Aciklama = entity.Id + " Id'li Taşınmaz Eklendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return CreatedAtAction("GetById", new { id = eklenenTasinmaz.Id }, eklenenTasinmaz);
                }
                else
                {
                    entity.KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]);
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 3,
                        Aciklama = entity.Adres + " Adresli Taşınmaz Eklenemedi",
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
                entity.KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]);
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 3,
                    Aciklama = "Taşınmaz Servisinde Ekleme Hatası Oluştu!",
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
                if (await _tasinmaz.GetById(id) != null)
                {
                    await _tasinmaz.Delete(id);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 4,
                        Aciklama = id + " Id'li Taşınmaz Silindi",
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
                        Aciklama = id + "Id'li Taşınmaz Silinemedi",
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
                    Aciklama = "Taşınmaz Servisinde Silme Hatası Oluştu!",
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
                var tasinmaz = await _tasinmaz.FullGetAll();
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Taşınmazlar Listelendi",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return Ok(tasinmaz);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "Taşınmaz Servisinde Listeleme Hatası Oluştu!",
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
                int kullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]);
                int kullaniciYetki = Convert.ToInt32(Request.Headers["current-user-type"]);
                var tasinmaz = await _tasinmaz.GetAllYetki(skipDeger, takeDeger, kullaniciId, kullaniciYetki);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Taşınmazlar Listelendi",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return Ok(tasinmaz);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "Taşınmaz Servisinde Listeleme Hatası Oluştu!",
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
                var tasinmaz = await _tasinmaz.GetById(id);
                if (tasinmaz != null)
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 7,
                        Aciklama = id + " Id'li Taşınmaz Listelendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok(tasinmaz);
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 7,
                        Aciklama = id + " Id'li Taşınmaz Listelenemedi",
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
                    Aciklama = "Taşınmaz Servisinde GetById Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{filter}")]
        public async Task<IActionResult> GetAllFilter(string filter)
        {
            try
            {
                var tasinmaz = await _tasinmaz.GetAllFilter(filter);
                if (tasinmaz != null)
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 8,
                        Aciklama = filter + " ile Taşınmaz Filtrelendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok(tasinmaz);
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 8,
                        Aciklama = filter + " ile Taşınmaz Filtrelenemedi",
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
                    IslemTipId = 8,
                    Aciklama = "Taşınmaz Servisinde Filtreleme Hatası Oluştu!",
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
                return await _tasinmaz.GetCount();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ETasinmaz entity)
        {
            try
            {
                if (await _tasinmaz.GetById(entity.Id) != null)
                {
                    entity.KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 5,
                        Aciklama = entity.Id + " Id'li Taşınmaz Düzenlendi",
                        KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                        KullaniciAdi = Request.Headers["current-user-name"],
                        Tarih = DateTime.Now,
                        IP = Request.Headers["ip-address"]
                    });
                    return Ok(_tasinmaz.Update(entity));
                }
                else
                {
                    entity.KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]);
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 5,
                        Aciklama = entity.Id + " Id'li Taşınmaz Düzenlenemedi",
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
                entity.KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]);
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 5,
                    Aciklama = "Taşınmaz Servisinde Düzenleme Hatası Oluştu!",
                    KullaniciId = Convert.ToInt32(Request.Headers["current-user-id"]),
                    KullaniciAdi = Request.Headers["current-user-name"],
                    Tarih = DateTime.Now,
                    IP = Request.Headers["ip-address"]
                });
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{filter}")]
        public async Task<int> FilterGetCount(string filter)
        {
            try
            {
                return await _tasinmaz.FilterGetCount(filter);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("{skipDeger}/{takeDeger}/{filter}")]
        public async Task<IActionResult> GetSearchAndFilter(int skipDeger, int takeDeger, string filter)
        {
            try
            {
                var tasinmaz = await _tasinmaz.GetSearchAndFilter(skipDeger, takeDeger, filter);
                if (tasinmaz != null)
                {
                    return Ok(tasinmaz);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}