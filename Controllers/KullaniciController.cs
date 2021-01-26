using System.Collections.Generic;
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

        public KullaniciController(IRepository<Kullanici> kullanici)
        {
            _kullanici = kullanici;
        }

        [HttpPost]
        public Kullanici Add([FromBody]Kullanici entity)
        {
            return _kullanici.Add(entity);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _kullanici.Delete(id);
        }

        [HttpGet]
        public IList<Kullanici> GetAll()
        {
            return _kullanici.GetAll();
        }

        [HttpGet("{id}")]
        public Kullanici GetById(int id)
        {
            return _kullanici.GetById(id);
        }

              [HttpGet("{filtre}")]
        public IList<Kullanici> GetByFilter(string filtre)
        {
            return _kullanici.GetByFilter(filtre);
        }

        [HttpPut]
        public Kullanici Update([FromBody]Kullanici entity)
        {
            return _kullanici.Update(entity);
        }
    }
}