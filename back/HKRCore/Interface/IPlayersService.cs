using HKRCore.DTO.PlayerDTO;
using System;
using System.Collections.Generic;
using System.Text;
using HKRCore.Model;
using HKRCore.DTO;

namespace HKRCore.Interface
{
    public interface IPlayersService
    {
        IEnumerable<PlayerDefaultDto> GetAll();
        PlayerDefaultDto Find( long id );
        PlayerDefaultDto Add( PlayerInscription newPlayer );
        void Update( Player player );
        void Delete( long id );
        PlayerDefaultDto MovePlayer( long id, Coord coord );
    }
}
