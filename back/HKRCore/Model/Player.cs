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

        public bool CanMove( int posX, int posY )
        {
            if (posX < 0 || posY < 0) return false;
            if (Math.Abs( posX - PosX ) > 1 || Math.Abs( posY - PosY ) > 1) return false;
            return true;
        }

        public void move( int posX, int posY )
        {
            if(CanMove(posX, posY ))
            {
                PosX = posX;
                PosY = posY;
            }
        }
    }
}
