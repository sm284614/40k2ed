using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Xml;
using _40k2ed.Models.EntityModels;
using _40k2ed.Models.DisplayModels;

namespace _40k2ed.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<WeaponType> WeaponType { get; set; }
        public DbSet<WeaponTable> WeaponTable { get; set; }
        public DbSet<WeaponRule> WeaponRule { get; set; }
        public DbSet<WeaponWeaponRule> WeaponWeaponRule { get; set; }
        public DbSet<Faction> Faction { get; set; }
        public DbSet<FactionCategory> FactionCategory { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var boolConverter = new ValueConverter<bool, byte>
            (
                v => (byte)(v ? 1 : 0), // Convert C# bool → SQL TINYINT
                v => v == 1 // Convert SQL TINYINT → C# bool
            );

            modelBuilder.Entity<Faction>()
                .Property(e => e.AlliesOnly)
                .HasConversion(boolConverter);
            modelBuilder.Entity<User>()
                .Property(e => e.Confirmed)
                .HasConversion(boolConverter);
            modelBuilder.Entity<WeaponTable>().HasNoKey();
            modelBuilder.Entity<WeaponWeaponRule>().HasNoKey();
            modelBuilder.Entity<WeaponWithAllRules>().HasNoKey();
        }
    }
}
