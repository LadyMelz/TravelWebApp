using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TravelWebAPI.Models
{
    [Index(nameof(User.Email), IsUnique = true)]
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Phone { get; set; }
        [Required]
        public string ImgURL { get; set; }
        //public List<Itinerary>? Itineraries { get; set; }

    }
}

