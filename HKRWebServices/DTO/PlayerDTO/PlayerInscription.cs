using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HKRWebServices.PlayerDTO.DTO
{
    public class PlayerInscription
    {
        [Required]
        public string Name { get; set; }
        [Required, DataType( DataType.EmailAddress )]
        public string Email { get; set; }
        [Required, DataType( DataType.Password )]
        public string Password { get; set; }
        [Required, DataType( DataType.Password ), Compare( "Password" )]
        public string ConfirmPassword { get; set; }
    }
}
