using System.ComponentModel.DataAnnotations;

namespace TravelWebAPI.Models
{
    public class Event
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Short_Description { get; set; }
        [Required]
        public string Long_Description { get; set; }
        public string Link { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        public string ImgURL { get; set; }
        public decimal Price { get; set; }

      //  public List<Event_Itinerary> Event_Itineraries { get; set; }

    }
}
