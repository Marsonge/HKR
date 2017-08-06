using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HKRCore.Model
{
    public class Player : EntityBase
    {
        [Required]
        public string Username { get; set; }
        [Required, DataType( DataType.EmailAddress )]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public long PosX { get; set; }
        public long PosY { get; set; }
    }
}
