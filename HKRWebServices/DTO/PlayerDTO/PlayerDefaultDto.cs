using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HKRWebServices.PlayerDTO.DTO
{
    public class PlayerDefaultDto
    {
        public Int64 Id { get; set; }
        public string Username { get; set; }
        public long PosX { get; set; }
        public long PosY { get; set; }
    }
}
