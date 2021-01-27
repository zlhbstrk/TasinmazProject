using System.Collections.Generic;
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

        public TasinmazController(IRepository<ETasinmaz> tasinmaz)
        {
            _tasinmaz = tasinmaz;
        }

        [HttpPost]
        public ETasinmaz Add([FromBody]ETasinmaz entity)
        {
            return _tasinmaz.Add(entity);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tasinmaz.Delete(id);
        }

        [HttpGet]
        public IList<ETasinmaz> GetAll()
        {
            return _tasinmaz.GetAll();
        }

        [HttpGet("{id}")]
        public ETasinmaz GetById(int id)
        {
            return _tasinmaz.GetById(id);
        }

        [HttpGet("{filter}")]
        public IList<ETasinmaz> GetAllFilter(string filter)
        {
            return _tasinmaz.GetAllFilter(filter);
        }

        [HttpPut]
        public ETasinmaz Update([FromBody]ETasinmaz entity)
        {
            return _tasinmaz.Update(entity);
        }
    }    
}