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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public CarShowroomDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(client => client.Id);
            modelBuilder.Entity<Client>().Property(client => client.Name).HasMaxLength(30);
            modelBuilder.Entity<Client>().Property(client => client.Name).IsRequired();
            modelBuilder.Entity<Client>().Property(client => client.LastName).HasMaxLength(30);
            modelBuilder.Entity<Client>().Property(client => client.LastName).IsRequired();
            modelBuilder.Entity<Client>().Property(client => client.Phone).HasMaxLength(10);
            modelBuilder.Entity<Client>().Property(client => client.Phone).IsRequired();
            modelBuilder.Entity<Client>(entity => entity.HasIndex(client => client.Phone).IsUnique());

            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Employee>().Property(e => e.Name).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.LastName).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(e => e.LastName).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Phone).HasMaxLength(10);
            modelBuilder.Entity<Employee>(entity => entity.HasIndex(e => e.Phone).IsUnique());
            modelBuilder.Entity<Employee>().Property(e => e.Phone).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Position).HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(e => e.Position).IsRequired();

            modelBuilder.Entity<Car>().HasKey(car => car.Id);
            modelBuilder.Entity<Car>().Property(car => car.Make).HasMaxLength(30);
            modelBuilder.Entity<Car>().Property(car => car.Make).IsRequired();
            modelBuilder.Entity<Car>().Property(car => car.Model).HasMaxLength(30);
            modelBuilder.Entity<Car>().Property(car => car.Model).IsRequired();
            modelBuilder.Entity<Car>().Property(car => car.Year).HasColumnType("Date");
            modelBuilder.Entity<Car>().Property(car => car.Year).IsRequired();
            modelBuilder.Entity<Car>().Property(car => car.BodyStyle).HasMaxLength(30);
            modelBuilder.Entity<Car>().Property(car => car.BodyStyle).IsRequired();
            modelBuilder.Entity<Car>().Property(car => car.Color).HasMaxLength(20);
            modelBuilder.Entity<Car>().Property(car => car.Color).IsRequired();
            modelBuilder.Entity<Car>()
                .HasOne(car => car.Client)
                .WithMany(client => client.Cars)
                .HasForeignKey(car => car.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Part>().HasKey(part => part.Id);
            modelBuilder.Entity<Part>().Property(part => part.Name).IsRequired();
            modelBuilder.Entity<Part>().HasIndex(part => part.SerialNumber).IsUnique();
            modelBuilder.Entity<Part>().Property(part => part.SerialNumber).IsRequired();

            modelBuilder.Entity<Order>().HasKey(order => order.Id);
            modelBuilder.Entity<Order>().Property(order => order.BeginningOfWork).HasColumnType("Date");
            modelBuilder.Entity<Order>().Property(order => order.BeginningOfWork).IsRequired();
            modelBuilder.Entity<Order>().Property(order => order.EndingOfWork).HasColumnType("Date");
            modelBuilder.Entity<Order>().Property(order => order.EndingOfWork).IsRequired();
            modelBuilder.Entity<Order>()
                .HasOne(order => order.Car)
                .WithOne(car => car.Order)
                .HasForeignKey<Car>(car => car.OrderId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderEmployee>()
                .HasOne(oe => oe.Order)
                .WithMany(order => order.OrderEmployees)
                .HasForeignKey(oe => oe.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderEmployee>()
                .HasOne(oe => oe.Employee)
                .WithMany(e => e.OrderEmployees)
                .HasForeignKey(oe => oe.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderEmployee>().HasKey(oe => new { oe.OrderId, oe.EmployeeId });

            modelBuilder.Entity<OrderPart>()
                .HasOne(op => op.Order)
                .WithMany(order => order.OrderParts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderPart>()
                .HasOne(op => op.Part)
                .WithMany(part => part.OrderParts)
                .HasForeignKey(op => op.PartId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderPart>().HasKey(op => new { op.OrderId, op.PartId });

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
