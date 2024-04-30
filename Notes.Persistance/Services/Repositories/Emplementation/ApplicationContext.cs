using Microsoft.EntityFrameworkCore;
using Notes.Domain.Models;
using Notes.Persistance.EntityConfiguration;


namespace Notes.Persistance.Services.Repositories.Emplementation
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions options )
            : base (options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
