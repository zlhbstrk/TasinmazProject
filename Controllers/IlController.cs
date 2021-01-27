using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IlController : ControllerBase
    {
        private IRepository<Il> _il;

        public IlController(IRepository<Il> il)
        {
            _il = il;
        }

        [HttpPost]
        public Il Add([FromBody]Il entity)
        {
            return _il.Add(entity);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _il.Delete(id);
        }

        [HttpGet]
        public IList<Il> GetAll()
        {
            return _il.GetAll();
        }

        [HttpGet("{id}")]
        public Il GetById(int id)
        {
            return _il.GetById(id);
        }

        // [HttpGet("{filter}")]
        // public IList<Il> GetAllFilter(string filtre)
        // {
        //     return _il.GetAllFilter(filtre);
        // }

        [HttpPut]
        public Il Update([FromBody]Il entity)
        {
            return _il.Update(entity);
        }
    }
}