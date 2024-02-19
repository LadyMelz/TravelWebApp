using System.ComponentModel.DataAnnotations;
using TravelWebAPI.Models;

namespace TravelWebAPI.Dto
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string ImgURL { get; set; }
        //public List<Itinerary>? Itineraries { get; set; }
    }
}
