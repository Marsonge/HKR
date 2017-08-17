using HKRCore.DTO.PlayerDTO;
using HKRCore.Model;
using AutoMapper;

namespace HKRCore.Mapper
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerInscription>().ReverseMap();
            CreateMap<Player, PlayerDefaultDto>().ReverseMap();
        }
    }
}
