using AutoMapper;
using TravelWebAPI.Dto;
using TravelWebAPI.Models;

namespace TravelWebAPI.Profiles
{
    public class EventCreateDtoProfile : Profile
    {
        public EventCreateDtoProfile()
        {
            CreateMap<EventCreateDto, Event>();
        }
    }
}
