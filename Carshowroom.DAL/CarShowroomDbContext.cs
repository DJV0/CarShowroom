using CarShowroom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshowroom.DAL
{
    public class CarShowroomDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public CarShowroomDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity => entity.HasIndex(client => client.Phone).IsUnique());

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Oleh", LastName = "Terentiev", Phone = "0981234141" },
                new Client { Id = 2, Name = "Roman", LastName = "Simonenko", Phone = "0961234567" },
                new Client { Id = 3, Name = "Petr", LastName = "Klimov", Phone = "0671234567" },
                new Client { Id = 4, Name = "Sergei", LastName = "Polunin", Phone = "0638765432" },
                new Client { Id = 5, Name = "Stas", LastName = "Green", Phone = "0979876543" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
