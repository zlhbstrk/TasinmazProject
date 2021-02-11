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
        public async Task<IActionResult> Add([FromBody]Kullanici entity) //try - catch kullanmayı unutma
        {
            if (ModelState.IsValid)
            {
                var eklenenKullanici = await _kullanici.Add(entity);
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 3,
                    Aciklama = entity.Ad + " Kullanıcısı Eklendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                    //KullaniciID = token'dan çekilecek,
                    //KullaniciAdi = token'dan çekilecek,
                    //Tarih = 
                    //IP = "js ile çekilmeye çalışılacak"   
                });
                return CreatedAtAction("GetById", new { id= eklenenKullanici.Id}, eklenenKullanici); //201 + eklenenKullanici
            }
            await _log.Add(new Log(){
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
            if (await _kullanici.GetById(id)!=null)
            {
                await _kullanici.Delete(id);
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 4,
                    Aciklama = "Kullanıcı Silindi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(); //200
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 4,
                    Aciklama = "Kullanıcı Silinemedi",
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
            var k = await _kullanici.GetAll(skipDeger, takeDeger);
            await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Kullanıcılar Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return Ok(k); //Response Code-200 + (body kısmına) k ekle
        }

        [HttpGet]
        public async Task<IActionResult> FullGetAll()
        {
            var k = await _kullanici.FullGetAll();
            await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 6,
                    Aciklama = "Kullanıcılar Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
            return Ok(k); //Response Code-200 + (body kısmına) k ekle
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var k = await _kullanici.GetById(id);
            if (k != null)
            {
                await _log.Add(new Log(){
                    DurumId = 1,
                    IslemTipId = 7,
                    Aciklama = "Kullanıcı Listelendi",
                    KullaniciId = 29,
                    KullaniciAdi = "Zeliha",
                    Tarih = DateTime.Now,
                    IP = "123.123.123"
                });
                return Ok(k);
            }
            await _log.Add(new Log(){
                    DurumId = 2,
                    IslemTipId = 7,
                    Aciklama = "Kullanıcı Listelenemedi",
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
        public async Task<IActionResult> Update([FromBody]Kullanici entity)
        {
            if (await _kullanici.GetById(entity.Id)!=null)
            {
                await _log.Add(new Log(){
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
            await _log.Add(new Log(){
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
    }
}