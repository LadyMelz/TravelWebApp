using AutoMapper;
using TravelWebAPI.Dto;
using TravelWebAPI.Models;

namespace TravelWebAPI.Profiles
{
    public class ItineraryReadDtoProfile : Profile
    {
        public ItineraryReadDtoProfile()
        {
            CreateMap<Itinerary, ItineraryReadDto>();
        }
    }
}
