namespace TravelWebAPI.Models.Data
{
    public interface IAttractionRepository
    {
        IEnumerable<Attraction> GetAll();

        Attraction Get(int id);

        void Update(int id,Attraction attractions);

        void Delete(int id, Attraction attraction);

        void Create(Attraction attraction);

        bool SaveChanges();
    }
}
