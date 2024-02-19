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
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> Get()
        {
            var users = _userRepository.GetAll();
            var userDto = _mapper.Map<IEnumerable<UserReadDto>>(users);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var users = _userRepository.Get(id);
            if (users == null)
            {
                return NotFound(id);
            }
            return (_mapper.Map<UserReadDto>(users));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser([FromBody]   UserCreateDto userCreateDto)
        {

            //Mapping to Persist to Data
            var userModel = _mapper.Map<User>(userCreateDto);
            _userRepository.Create(userModel);
            _userRepository.SaveChanges();

            //Mapp from Prescription to its Dtod
            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById),
                new { Id = userReadDto.Id }, userReadDto);
        }

        [HttpPut("{id}", Name = "UpdateUserById")]
        public ActionResult<UserReadDto> UpdateUserById(int id, UserCreateDto userCreateDto)
        {

            var userModel = _mapper.Map<User>(userCreateDto);

            _userRepository.Update(id, userModel);
            _userRepository.SaveChanges();

           
            return Ok();
              
        }

        [HttpDelete("{id}", Name = "DeleteUserById")]

        public ActionResult<User> DeleteUserById(int id, User user)
        {
            _userRepository.Delete(id, user);
            return Ok();
        }
    }
}
