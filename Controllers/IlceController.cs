using System.Collections.Generic;
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

        public IlceController(IRepository<Ilce> ilce)
        {
            _ilce = ilce;
        }

        [HttpPost]
        public Ilce Add([FromBody]Ilce entity)
        {
            return _ilce.Add(entity);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ilce.Delete(id);
        }

        [HttpGet]
        public IList<Ilce> GetAll()
        {
            return _ilce.GetAll();
        }

        [HttpGet("{id}")]
        public Ilce GetById(int id)
        {
            return _ilce.GetById(id);
        }

        // [HttpGet("{filter}")]
        // public IList<Ilce> GetAllFilter(string filtre)
        // {
        //     return _ilce.GetAllFilter(filtre);
        // }

        [HttpPut]
        public Ilce Update([FromBody]Ilce entity)
        {
            return _ilce.Update(entity);
        }
    }
}