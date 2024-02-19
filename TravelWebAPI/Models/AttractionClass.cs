using System.ComponentModel.DataAnnotations;

namespace TravelWebAPI.Models
{
    public class Attraction
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Short_Description { get; set; }
        [Required]
        public string Long_Description { get; set; }
        public string Link { get; set; }
        [Required]
        public string ImgURL { get; set; }

        [Required]
        public string Location { get; set; }

      //  public List<Attraction_Itinerary> Attraction_Itineraries { get; set; }
    }
}
