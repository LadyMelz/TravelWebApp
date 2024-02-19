using AutoMapper;
using TravelWebAPI.Dto;
using TravelWebAPI.Models;

namespace TravelWebAPI.Profiles
{
    public class AttractionReadDtoProfile : Profile
    {
        public AttractionReadDtoProfile()
        {
            CreateMap<Attraction, AttractionReadDto>();
        }
    }
}
