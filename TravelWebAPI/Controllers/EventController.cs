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
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        // GET: api/<TravelController>
        [HttpGet]
        public ActionResult<IEnumerable<EventReadDto>> Get()
        {
            var events = _eventRepository.GetAll();
            var eventDto = _mapper.Map<IEnumerable<EventReadDto>>(events);
            if (events == null)
            {
                return NotFound();
            }
            return Ok(eventDto);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public ActionResult<EventReadDto> GetEventById(int id)
        {
            var events = _eventRepository.Get(id);
            if (events == null)
            {
                return NotFound(id);
            }
            return (_mapper.Map<EventReadDto>(events));
        }

        [HttpPost]
        public ActionResult<EventReadDto> CreateEvent(
            EventCreateDto eventCreateDto)
        {

            //Mapping to Persist to Data
            var eventModel = _mapper.Map<Event>(eventCreateDto);

            _eventRepository.Create(eventModel);
            _eventRepository.SaveChanges();

            //Mapp from Prescription to its Dtod
            var eventReadDto = _mapper.Map<EventReadDto>(eventModel);

            return CreatedAtRoute(nameof(GetEventById),
                new { Id = eventReadDto.Id }, eventReadDto);
        }

        [HttpPut("{id}", Name = "UpdateEventById")]
        public ActionResult<EventReadDto> UpdateEventById(int id, EventCreateDto eventCreateDto){

            var eventModel = _mapper.Map<Event>(eventCreateDto);

            _eventRepository.Update(id, eventModel);
            _eventRepository.SaveChanges();

            
            return Ok();
        }

        [HttpDelete("{id}", Name = "DeleteEventById")]

        public ActionResult<Event> DeleteAttractionById(int id,Event events)
        {
            _eventRepository.Delete(id, events);
            return Ok();
        }

    }
}
