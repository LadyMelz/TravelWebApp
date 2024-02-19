using AutoMapper;
using TravelWebAPI.Dto;
using TravelWebAPI.Models;

namespace TravelWebAPI.Profiles
{
    public class AttractionCreateDtoProfile : Profile
    {
        public AttractionCreateDtoProfile() 
        {
            CreateMap<AttractionCreateDto, Attraction>();
        }
    }
}
