using System.ComponentModel.DataAnnotations;
using TravelWebAPI.Models;

namespace TravelWebAPI.Dto
{
    public class UserCreateDto
    {

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Phone { get; set; }
        [Required]
        public string ImgURL { get; set; }
        //public List<Itinerary>? Itineraries { get; set; }
    }
}
