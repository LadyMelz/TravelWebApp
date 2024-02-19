using AutoMapper;
using TravelWebAPI.Dto;
using TravelWebAPI.Models;

namespace TravelWebAPI.Profiles
{
    public class ItineraryCreateDtoProfile : Profile
    {
        public ItineraryCreateDtoProfile()
        {
            CreateMap<ItineraryCreateDto, Itinerary>();
        }
    }
}
