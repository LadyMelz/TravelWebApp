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
    public class AttractionController : ControllerBase
    {
        private readonly IAttractionRepository _attractionRepository;
        private readonly IMapper _mapper;
        public AttractionController(IAttractionRepository attractionRepository, IMapper mapper)
        {
            _attractionRepository = attractionRepository;
            _mapper = mapper;
        }
        // GET: api/<AttractionController>
        [HttpGet]
        public ActionResult<IEnumerable<AttractionReadDto>> Get()
        {
            var attractions = _attractionRepository.GetAll();
            var attractionDto = _mapper.Map<IEnumerable<AttractionReadDto>>(attractions);
            if (attractions == null) { 
                return NotFound();
            }
            return Ok(attractionDto);
        }

        [HttpGet("{id}", Name = "GetAttractionById")]
        public ActionResult<AttractionReadDto> GetAttractionById(int id)
        {
            var attractions = _attractionRepository.Get(id);
            if (attractions == null)
            {
                return NotFound(id);
            }
            return (_mapper.Map<AttractionReadDto>(attractions));
        }

        [HttpPost]
        public ActionResult<AttractionReadDto> CreateAttraction(
            AttractionCreateDto attarctionCreateDto)
        {

            //Mapping to Persist to Data
            var attractionModel = _mapper.Map<Attraction>(attarctionCreateDto);

            _attractionRepository.Create(attractionModel);
            _attractionRepository.SaveChanges();

            //Mapp from Prescription to its Dtod
            var attractionReadDto = _mapper.Map<AttractionReadDto>(attractionModel);

            return CreatedAtRoute(nameof(GetAttractionById),
                new { Id = attractionReadDto.Id }, attractionReadDto);
        }

        [HttpPut("{id}", Name = "UpdateAttractionById")]
        public ActionResult<Attraction> UpdateEventById([FromRoute]int id,[FromBody] Attraction attraction)
        {
            var attractions = _attractionRepository.Get(id);
            if (attractions == null)
            {
                return NotFound(id);
            }


            _attractionRepository.Update(id, attraction);
            _attractionRepository.SaveChanges();

           
            return Ok();
        }
        [HttpDelete("{id}", Name = "DeleteAttractionById")]

        public ActionResult<Attraction> DeleteAttractionById(int id, Attraction attraction)
        {
            _attractionRepository.Delete(id, attraction);
            return Ok();
        }

    }

}

