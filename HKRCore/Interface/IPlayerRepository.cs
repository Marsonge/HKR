using HKRCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HKRCore.Interface
{
    public interface IPlayerRepository : IRepository<Player>
    {
        IEnumerable<Player> ListPlayersAtCoordinates(int x, int y);
    }
}
