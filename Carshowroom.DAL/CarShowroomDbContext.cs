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

            base.OnModelCreating(modelBuilder);
        }
    }
}
