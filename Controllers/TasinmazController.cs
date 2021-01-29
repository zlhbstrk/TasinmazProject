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
        private IRepository<ETasinmaz> _tasinmaz;
        private IRepository<Log> _log;

        public TasinmazController(IRepository<ETasinmaz> tasinmaz, IRepository<Log> log)
        {
            _tasinmaz = tasinmaz;
            _log = log;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ETasinmaz entity)
        {
            if (ModelState.IsValid)
            {
                var eklenenTasinmaz = await _tasinmaz.Add(entity);
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 3,
                    Aciklama = entity.ID + " Taşınmazı Eklendi",   
                });
                return CreatedAtAction("GetById", new { id= eklenenTasinmaz.ID}, eklenenTasinmaz);
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 3,
                    Aciklama = entity.ID + " Taşınmazı Eklenemedi",   
                });
            return BadRequest(ModelState);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _tasinmaz.GetById(id)!=null)
            {
                await _tasinmaz.Delete(id);
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 4,
                    Aciklama = "Taşınmaz Silindi",   
                });
                return Ok();
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 4,
                    Aciklama = "Taşınmaz Silinemedi",   
                });
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var t = await _tasinmaz.GetAll();
            await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 6,
                    Aciklama = "Taşınmazlar Listelendi",   
                });
            return Ok(t);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var t = await _tasinmaz.GetById(id);
            if (t != null)
            {
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 7,
                    Aciklama = "Taşınmaz Listelendi",   
                });
                return Ok(t);
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 4,
                    Aciklama = "Taşınmaz Listelenemedi",   
                });
            return NotFound();
        }

        [HttpGet]
        [Route("{filter}")]
        public async Task<IActionResult> GetAllFilter(string filter)
        {
            var t = await _tasinmaz.GetAllFilter(filter);
            if (t != null)
            {
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 8,
                    Aciklama = "Taşınmaz Filtrelendi",   
                });
                return Ok(t);
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 8,
                    Aciklama = "Taşınmaz Filtrelenemedi",   
                });
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ETasinmaz entity)
        {
            if (await _tasinmaz.GetById(entity.ID)!=null)
            {
                await _log.Add(new Log(){
                    DurumID = 1,
                    IslemTipID = 5,
                    Aciklama = entity.ID + " Taşınmazı Düzenlendi",   
                });
                return Ok(_tasinmaz.Update(entity));
            }
            await _log.Add(new Log(){
                    DurumID = 2,
                    IslemTipID = 5,
                    Aciklama = entity.ID + " Taşınmazı Düzenlenemedi",   
                });
            return NotFound();
        }
    }    
}