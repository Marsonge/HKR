using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HKRCore.Model
{
    public class Player : EntityBase
    {
        public string Name { get; set; }
        public long PosX { get; set; }
        public long PosY { get; set; }
    }
}
