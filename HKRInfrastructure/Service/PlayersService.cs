using HKRCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using HKRCore.DTO.PlayerDTO;
using AutoMapper;
using HKRInfrastructure.Context;
using System.Linq;
using HKRCore.Model;
using HKRCore.DTO;
using HKRCore.Exception;

namespace HKRInfrastructure.Service
{
    public class PlayersService : IPlayersService
    {
        private IMapper _mapper;
        private HKRContext _context;

        public PlayersService( IMapper mapper, HKRContext context)
        {
            _mapper = mapper;
            _context = context;

            if (_context.Players.Count() == 0)
            {
                _context.Players.AddRange(
                    new Player { Username = "Truc", PosX = 1, PosY = 2 },
                    new Player { Username = "Chose", PosX = 1, PosY = 2 }
                    );
                _context.SaveChanges();

            }
        }

        public PlayerDefaultDto Add( PlayerInscription newPlayer )
        {
            var player = _mapper.Map<PlayerInscription, Player>(newPlayer);
            _context.Players.Add( player );
            _context.SaveChanges();
            var dto = _mapper.Map<Player, PlayerDefaultDto>(player);
            return dto;
        }

        public void Delete( long id )
        {
            var toDelete = new Player { Id = id };
            _context.Players.Attach( toDelete );
            _context.Players.Remove( toDelete );
            _context.SaveChanges();
        }

        public PlayerDefaultDto Find( long id )
        {
            var item = _context.Players.Find( id );
            var dto = _mapper.Map<Player, PlayerDefaultDto>( item );
            return dto;
        }

        public IEnumerable<PlayerDefaultDto> GetAll()
        {
            var list = _context.Players.ToList();
            return _mapper.Map< IEnumerable<Player>, IEnumerable<PlayerDefaultDto>>( list );
        }

        public PlayerDefaultDto MovePlayer( long id, Coord coord)
        {
            var player = _context.Players.Find( id );
            if (player == null)
            {
                throw new DomainException( $"Player with id {id} doesn't exist" );
            }
            if (!player.CanMove( coord.PosX, coord.PosY ))
            {
                throw new DomainException( $"Player with id {id} can't move to {coord.PosX}, {coord.PosY}" );
            }


            player.move( coord.PosX, coord.PosY );
            _context.SaveChanges();
            var dto = _mapper.Map<Player, PlayerDefaultDto>( player );
            return dto;
        }

        public void Update( Player player )
        {
            _context.Players.Update( player );
            _context.SaveChanges();
        }
    }
}
