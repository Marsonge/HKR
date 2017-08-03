using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HKRCore.Model;
using HKRCore.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HKRWebServices.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {

        private readonly IPlayerRepository _repository;

        public PlayersController(IPlayerRepository repository)
        {
            _repository = repository;

            if (_repository.List().Count() == 0)
            {
                _repository.Insert(new Player { Name = "Truc", PosX = 1, PosY = 2 });
                
            }
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Player> GetAll()
        {
            return _repository.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
