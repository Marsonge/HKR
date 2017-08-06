using AutoMapper;
using HKRCore.Model;
using HKRWebServices.PlayerDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HKRWebServices.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Player, PlayerInscription>().ReverseMap();
            CreateMap<Player, PlayerDefaultDto>().ReverseMap();
        }
    }
}
