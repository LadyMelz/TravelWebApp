using AutoMapper;
using TravelWebAPI.Dto;
using TravelWebAPI.Models;

namespace TravelWebAPI.Profiles
{
    public class EventReadDtoProfile : Profile
    {
        public EventReadDtoProfile()
        {
            CreateMap<Event, EventReadDto>();
        }
    }
}
