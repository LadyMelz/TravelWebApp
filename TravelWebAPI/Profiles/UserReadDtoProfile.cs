using AutoMapper;
using TravelWebAPI.Dto;
using TravelWebAPI.Models;

namespace TravelWebAPI.Profiles
{
    public class UserReadDtoProfile : Profile
    {
        public UserReadDtoProfile()
        {
            CreateMap<User, UserReadDto>();
        }
    }
}
