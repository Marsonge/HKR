using AutoMapper;
using HKRCore.DTO.PlayerDTO;
using HKRCore.Model;

namespace HKRInfrastructure.Mapper
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
