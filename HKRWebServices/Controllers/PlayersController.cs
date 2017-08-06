﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HKRCore.Model;
using AutoMapper;
using HKRWebServices.PlayerDTO.DTO;
using HKRInfrastructure.Context;

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
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _context.Players.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<Player, PlayerDefaultDto>( item );
            return new ObjectResult( dto );
        }

        // POST api/values (Create a new one)
        [HttpPost]
        public void Post([FromBody]PlayerInscription newPlayer)
        {
            var player = _mapper.Map<PlayerInscription, Player>(newPlayer);
            _context.Players.Add( player );
            _context.SaveChanges();
        }

        // PUT api/values/5 (Update)
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Player player)
        {

        }

        // TODO check if we're connected with the good user 
        // DELETE api/values/5 (Delete one)
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
