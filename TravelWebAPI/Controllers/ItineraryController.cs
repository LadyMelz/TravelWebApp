using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelWebAPI.Data;
using TravelWebAPI.Dto;
using TravelWebAPI.Models;
using TravelWebAPI.Models.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryRepository _itineraryRepository;
        private readonly IMapper _mapper;
        public ItineraryController(IItineraryRepository itineraryRepository, IMapper mapper)
        {
            _itineraryRepository = itineraryRepository;
            _mapper = mapper;
        }
        // GET: api/<ItineraryController>
        [HttpGet]
        public ActionResult<IEnumerable<ItineraryReadDto>> Get()
        {
            var itineraries = _itineraryRepository.GetAll();
            var itineraryDto = _mapper.Map<IEnumerable<ItineraryReadDto>>(itineraries);
            if (itineraries == null)
            {
                return NotFound();
            }
            return Ok(itineraryDto);
        }

        // GET api/<ItineraryController>/5
        [HttpGet("{id}", Name = "GetItineraryById")]
        public ActionResult<ItineraryReadDto> GetItineraryById(int id)
        {
            var itineraries = _itineraryRepository.Get(id);
            if (itineraries == null)
            {
                return NotFound(id);
            }
            return (_mapper.Map<ItineraryReadDto>(itineraries));
        }

        // POST api/<ItineraryController>
        [HttpPost]
        public ActionResult<ItineraryReadDto> CreateItinerary(
            ItineraryCreateDto itineraryCreateDto)
        {

            //Mapping to Persist to Data
            var itineraryModel = _mapper.Map<Itinerary>(itineraryCreateDto);

            _itineraryRepository.Create(itineraryModel);
            _itineraryRepository.SaveChanges();

            //Mapp from Prescription to its Dtod
            var itineraryReadDto = _mapper.Map<ItineraryReadDto>(itineraryModel);

            return CreatedAtRoute(nameof(GetItineraryById),
                new { Id = itineraryReadDto.Id }, itineraryReadDto);
        }
    }
}
