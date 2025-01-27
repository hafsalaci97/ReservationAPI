using Microsoft.EntityFrameworkCore;
using ReservationAPI.Models; // Ensure this namespace matches the location of your Reservation model.

namespace ReservationAPI.Data
{
    public class ReservationContext : DbContext
    {
        // Constructor to pass options to the DbContext
        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {
        }

        // DbSet representing the Reservations table in the database
        public DbSet<Reservation> Reservations { get; set; }

        // Override OnModelCreating (optional, to configure table properties or relationships)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional model configuration can go here.
        }
    }
}
