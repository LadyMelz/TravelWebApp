using System.ComponentModel.DataAnnotations;
using TravelWebAPI.Models;

namespace TravelWebAPI.Dto
{
    public class ItineraryCreateDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string img { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Transportation { get; set; }
        public string Location { get; set; }
        [Required]
        public int UserId { get; set; }
        //public User User { get; set; }
        //public List<Attraction>Attractions { get; set; }
        //public List<Event> Events { get; set; }
    }
}
