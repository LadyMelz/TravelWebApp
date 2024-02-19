using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TravelWebAPI.Models;

namespace TravelWebAPI.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {

        }

        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        //public DbSet<Attraction_Itinerary> Attraction_Itineraries { get; set; }
        //public DbSet<Event_Itinerary> Event_Itineraries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Attraction_Itinerary>()
            //    .HasKey(ai => new
            //    {
            //        ai.AttractionId,
            //        ai.ItineraryId
            //    });

            //modelBuilder.Entity<Attraction>()
            //    .HasOne(a => a.Attraction)
            //    .WithMany(ai => ai.Itineraries)
            //    .HasForeignKey(ai => ai.AttractionId);

            //modelBuilder.Entity<Attraction_Itinerary>()
            //    .HasOne(a => a.Itinerary)
            //    .WithMany(ai => ai.Attraction_Itineraries)
            //    .HasForeignKey(ai => ai.ItineraryId);

            //modelBuilder.Entity<Event_Itinerary>()
            //    .HasKey(ei => new
            //    {
            //        ei.EventId,
            //        ei.ItineraryId
            //    });

            //modelBuilder.Entity<Event_Itinerary>()
            //    .HasOne(a => a.Event)
            //    .WithMany(ai => ai.Event_Itineraries)
            //    .HasForeignKey(ai => ai.EventId);

            //modelBuilder.Entity<Event_Itinerary>()
            //    .HasOne(a => a.Itinerary)
            //    .WithMany(ai => ai.Event_Itineraries)
            //    .HasForeignKey(ai => ai.ItineraryId);
        }
    }
}
