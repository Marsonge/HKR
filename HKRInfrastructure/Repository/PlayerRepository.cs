using HKRCore.Interface;
using HKRCore.Model;
using HKRInfrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HKRInfrastructure.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository( HKRContext dbContext ) : base( dbContext )
        {
        }

        public IEnumerable<Player> ListPlayersAtCoordinates( int x, int y )
        {
            return _dbContext.Set<Player>()
                   .Where( P => P.PosX==x && P.PosY==y)
                   .AsEnumerable();
        }
    }
}
