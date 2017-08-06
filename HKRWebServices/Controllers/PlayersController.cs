using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HKRCore.Model;
using HKRCore.Interface;
using AutoMapper;
using HKRWebServices.PlayerDTO.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HKRWebServices.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {

        private readonly IPlayerRepository _repository;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;

            if (_repository.List().Count() == 0)
            {
                _repository.Insert(new Player { Username = "Truc", PosX = 1, PosY = 2 });
                
            }
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<PlayerDefaultDto> GetAll()
        {
            var list = _repository.List();
            return _mapper.Map< IEnumerable<Player>, IEnumerable<PlayerDefaultDto>>( list );
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
            var dto = _mapper.Map<Player, PlayerDefaultDto>( item );
            return new ObjectResult( dto );
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
