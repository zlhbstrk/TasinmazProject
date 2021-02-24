using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IlceController : ControllerBase
    {
        private IRepository<Ilce> _ilce;
        private IRepository<Log> _log;

        public IlceController(IRepository<Ilce> ilce, IRepository<Log> log)
        {
            _ilce = ilce;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Ilce entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var eklenenIlce = await _ilce.Add(entity);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 3,
                        Aciklama = entity.Ad + " İlçesi Eklendi",
                        KullaniciId = 29,
                        KullaniciAdi = "Zeliha",
                        Tarih = DateTime.Now,
                        IP = "123.123.123"
                    });
                    return CreatedAtAction("GetById", new { id = eklenenIlce.Id }, eklenenIlce);
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 3,
                        Aciklama = entity.Ad + " İlçesi Eklenemedi",
                        KullaniciId = 29,
                        KullaniciAdi = "Zeliha",
                        Tarih = DateTime.Now,
                        IP = "123.123.123"
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
                    Aciklama = entity.Ad + " İlçesi Eklenemedi",
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
                if (await _ilce.GetById(id) != null)
                {
                    await _ilce.Delete(id);
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 4,
                        Aciklama = id + " Id'li İlçe Silindi",
                        KullaniciId = 29,
                        KullaniciAdi = "Zeliha",
                        Tarih = DateTime.Now,
                        IP = "123.123.123"
                    });
                    return Ok();
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 4,
                        Aciklama = id + " Id'li İlçe Silinemedi",
                        KullaniciId = 29,
                        KullaniciAdi = "Zeliha",
                        Tarih = DateTime.Now,
                        IP = "123.123.123"
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
                    Aciklama = id + " Id'li İlçe Silinemedi",
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
                var ilce = await _ilce.GetAll(skipDeger, takeDeger, 1);
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "İlçeler Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(ilce);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "İlçeler Listelenemedi",
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
                var ilce = await _ilce.FullGetAll();
                await _log.Add(new Log()
                {
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "İlçeler Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(ilce);
            }
            catch (System.Exception)
            {
                await _log.Add(new Log()
                {
                    DurumId = 2,
                    IslemTipId = 6,
                    Aciklama = "İlçeler Listelenemedi",
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
                var ilce = await _ilce.GetById(id);
                if (ilce != null)
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 7,
                        Aciklama = id + " Id'li İlçe Listelendi",
                        KullaniciId = 29,
                        KullaniciAdi = "Zeliha",
                        Tarih = DateTime.Now,
                        IP = "123.123.123"
                    });
                    return Ok(ilce);
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 7,
                        Aciklama = id + " Id'li İlçe Listelenemedi",
                        KullaniciId = 29,
                        KullaniciAdi = "Zeliha",
                        Tarih = DateTime.Now,
                        IP = "123.123.123"
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
                    Aciklama = id + " Id'li İlçe Listelenemedi",
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
                return await _ilce.GetCount();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Ilce entity)
        {
            try
            {
                if (await _ilce.GetById(entity.Id) != null)
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 1,
                        IslemTipId = 5,
                        Aciklama = entity.Ad + " İlçesi Düzenlendi",
                        KullaniciId = 29,
                        KullaniciAdi = "Zeliha",
                        Tarih = DateTime.Now,
                        IP = "123.123.123"
                    });
                    return Ok(_ilce.Update(entity));
                }
                else
                {
                    await _log.Add(new Log()
                    {
                        DurumId = 2,
                        IslemTipId = 5,
                        Aciklama = entity.Ad + " İlçesi Düzenlenemedi",
                        KullaniciId = 29,
                        KullaniciAdi = "Zeliha",
                        Tarih = DateTime.Now,
                        IP = "123.123.123"
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
                    Aciklama = entity.Ad + " İlçesi Düzenlenemedi",
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