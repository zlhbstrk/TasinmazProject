using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MahalleController : ControllerBase
    {
        private IRepository<Mahalle> _mahalle;

        public MahalleController(IRepository<Mahalle> mahalle)
        {
            _mahalle = mahalle;
        }

        [HttpPost]
        public Mahalle Add([FromBody]Mahalle entity)
        {
            return _mahalle.Add(entity);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mahalle.Delete(id);
        }

        [HttpGet]
        public IList<Mahalle> GetAll()
        {
            return _mahalle.GetAll();
        }

        [HttpGet("{id}")]
        public Mahalle GetById(int id)
        {
            return _mahalle.GetById(id);
        }

        // [HttpGet("{filter}")]
        // public IList<Mahalle> GetAllFilter(string filtre)
        // {
        //     return _mahalle.GetAllFilter(filtre);
        // }

        [HttpPut]
        public Mahalle Update([FromBody]Mahalle entity)
        {
            return _mahalle.Update(entity);
        }
    }
}