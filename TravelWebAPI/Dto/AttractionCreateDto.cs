using System.ComponentModel.DataAnnotations;
using TravelWebAPI.Models;

namespace TravelWebAPI.Dto
{
    public class AttractionCreateDto
    {
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
       
    }
}
