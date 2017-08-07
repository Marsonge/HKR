using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HKRCore.Model;
using HKRInfrastructure.Context;
using HKRCore.Interface;
using HKRCore.DTO.PlayerDTO;
using HKRCore.DTO;
using HKRCore.Exception;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HKRWebServices.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {

        private IPlayersService _playersService;

        public PlayersController(IPlayersService playersService)
        {
            _playersService = playersService;

        }

        // GET: api/values (Get all players)
        [HttpGet]
        public IEnumerable<PlayerDefaultDto> GetAll()
        {
            var list = _playersService.GetAll();
            return list;
        }

        // GET api/values/5 (Get one from id)
        [HttpGet("{id}", Name = "GetCompany" )]
        public IActionResult GetCompany(long id)
        {
            var item = _playersService.Find(id);
            if (item == null)
            {
                return NotFound(new { Id = id, error = $"There was no customer with an id of {id}" });
            }
            return new ObjectResult( item );
        }

        // POST api/values (Create a new one)
        [HttpPost]
        public IActionResult Post([FromBody]PlayerInscription newPlayer)
        {
            var player = _playersService.Add( newPlayer );
            return CreatedAtRoute( "GetCompany", new { id = player.Id}, player );
        }

        // PUT api/values/5 (Update)
        // Shouldn't exist I suppose, it's just for the example
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Player player)
        {
            if(player==null || player.Id != id)
            {
                return BadRequest();
            }
            _playersService.Update( player );

            return AcceptedAtRoute( "GetCompany", new { id = player.Id }, player );
        }

        // TODO check if we're connected with the good user 
        // DELETE api/values/5 (Delete one)
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            // Here get the actual user

            _playersService.Delete( id );

            return Ok();
        }

        [HttpPatch( "{id}/move" )]
        public IActionResult MovePlayer( long id, [FromBody]Coord coord )
        {
            try
            {
                var player = _playersService.MovePlayer( id, coord );
                return AcceptedAtRoute( "GetCompany", new { id = player.Id }, player );
            }
            catch(DomainException e)
            {
                return BadRequest( e.Message );
            }

        }
    }
}
