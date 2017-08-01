using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HKR.Model
{
    public class Player
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long PosX { get; set; }
        public long PosY { get; set; }
    }
}
