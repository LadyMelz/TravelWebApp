using System.ComponentModel.DataAnnotations;

namespace TravelWebAPI.Dto
{
    public class EventReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Short_Description { get; set; }
        public string Long_Description { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string ImgURL { get; set; }
        public decimal Price { get; set; }
    }
}
