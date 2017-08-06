using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HKRCore.Model;
using AutoMapper;
using HKRWebServices.PlayerDTO.DTO;
using HKRInfrastructure.Context;
using HKRWebServices.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HKRWebServices.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {

        private readonly HKRContext _context;
        private readonly IMapper _mapper;

        public PlayersController( HKRContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;

            if (_context.Players.Count() == 0)
            {
                _context.Players.AddRange(
                    new Player { Username = "Truc", PosX = 1, PosY = 2 },
                    new Player { Username = "Chose", PosX = 1, PosY = 2 }
                    );
                _context.SaveChanges();
                
            }
        }

        // GET: api/values (Get all players)
        [HttpGet]
        public IEnumerable<PlayerDefaultDto> GetAll()
        {
            var list = _context.Players.ToList();
            return _mapper.Map< IEnumerable<Player>, IEnumerable<PlayerDefaultDto>>( list );
        }

        // GET api/values/5 (Get one from id)
        [HttpGet("{id}", Name = "GetCompany" )]
        public IActionResult GetCompany(long id)
        {
            var item = _context.Players.Find(id);
            if (item == null)
            {
                return NotFound(new { Id = id, error = $"There was no customer with an id of {id}" });
            }
            var dto = _mapper.Map<Player, PlayerDefaultDto>( item );
            return new ObjectResult( dto );
        }

        // POST api/values (Create a new one)
        [HttpPost]
        public IActionResult Post([FromBody]PlayerInscription newPlayer)
        {
            var player = _mapper.Map<PlayerInscription, Player>(newPlayer);
            _context.Players.Add( player );
            _context.SaveChanges();
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

            _context.Players.Update( player );
            _context.SaveChanges();

            return AcceptedAtRoute( "GetCompany", new { id = player.Id }, player );
        }

        // TODO check if we're connected with the good user 
        // DELETE api/values/5 (Delete one)
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            // Here get the actual user

            var toDelete = new Player { Id = id };
            _context.Players.Attach( toDelete );
            _context.Players.Remove( toDelete );

            return Ok();
        }

        [HttpPatch( "{id}/move" )]
        public IActionResult MovePlayer( long id, [FromBody]Coord coord )
        {
            var player = _context.Players.Find( id );
            if (player == null)
            {
                return BadRequest( $"Player with id {id} doesn't exist" );
            }
            if(!player.CanMove(coord.PosX, coord.PosY ))
            {
                return BadRequest($"Player with id {id} can't move to {coord.PosX}, {coord.PosY}");
            }


            player.move(coord.PosX, coord.PosY);
            _context.SaveChanges();

            return AcceptedAtRoute( "GetCompany", new { id = player.Id }, player );
        }
    }
}
