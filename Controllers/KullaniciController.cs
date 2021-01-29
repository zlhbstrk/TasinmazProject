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
                    DurumID = 1,
                    IslemTipID = 3,
                    Aciklama = entity.Ad + " Kullanıcısı Eklendi",
                    //KullaniciID = token'dan çekilecek,
                    //KullaniciAdi = token'dan çekilecek,
                    //Tarih = 
                    //IP = "js ile çekilmeye çalışılacak"   
                });
                return CreatedAtAction("GetById", new { id= eklenenKullanici.ID}, eklenenKullanici); //201 + eklenenKullanici
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 3,
                    Aciklama = entity.Ad + " Kullanıcısı Eklenemedi",
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
                    DurumID = 1,
                    IslemTipID = 4,
                    Aciklama = "Kullanıcı Silindi", 
                });
                return Ok(); //200
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 4,
                    Aciklama = "Kullanıcı Silinemedi", 
                });
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var k = await _kullanici.GetAll();
            await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 6,
                    Aciklama = "Kullanıcılar Listelendi", 
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
                    DurumID = 1,
                    IslemTipID = 7,
                    Aciklama = "Kullanıcı Listelendi", 
                });
                return Ok(k);
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 7,
                    Aciklama = "Kullanıcı Listelenemedi", 
                });
            return NotFound(); //Response Code-404
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Kullanici entity)
        {
            if (await _kullanici.GetById(entity.ID)!=null)
            {
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 5,
                    Aciklama = entity.Ad + " Kullanıcısı Düzenlendi", 
                });
                return Ok(_kullanici.Update(entity)); //200 + data
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 5,
                    Aciklama = entity.Ad + " Kullanıcısı Düzenemelendi", 
                });
            return NotFound();
        }
    }
}