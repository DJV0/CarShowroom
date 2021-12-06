using CarShowroom.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Carshowroom.DAL
{
    public class CarShowroomDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public CarShowroomDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasKey(client => client.Id);
            modelBuilder.Entity<Client>().Property(client => client.Name).HasMaxLength(30);
            modelBuilder.Entity<Client>().Property(client => client.Name).IsRequired();
            modelBuilder.Entity<Client>().Property(client => client.LastName).HasMaxLength(30);
            modelBuilder.Entity<Client>().Property(client => client.LastName).IsRequired();
            modelBuilder.Entity<Client>().Property(client => client.Gender).IsRequired();
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
            modelBuilder.Entity<Car>().Property(car => car.Mileage).IsRequired();
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
                .WithMany(car => car.Orders)
                .HasForeignKey(order => order.CarId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Statistics>().HasKey(s => s.Name);
            modelBuilder.Entity<Statistics>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<Statistics>().Property(s => s.Value).IsRequired();

            modelBuilder.Entity<OrderEmployee>()
                .HasOne(oe => oe.Order)
                .WithMany(order => order.OrderEmployees)
                .HasForeignKey(oe => oe.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderEmployee>()
                .HasOne(oe => oe.Employee)
                .WithMany(e => e.OrderEmployees)
                .HasForeignKey(oe => oe.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderEmployee>().HasKey(oe => new { oe.OrderId, oe.EmployeeId });

            modelBuilder.Entity<OrderPart>()
                .HasOne(op => op.Order)
                .WithMany(order => order.OrderParts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderPart>()
                .HasOne(op => op.Part)
                .WithMany(part => part.OrderParts)
                .HasForeignKey(op => op.PartId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderPart>().HasKey(op => new { op.OrderId, op.PartId });

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Олег", LastName = "Терентьев", Gender=Gender.Male, Phone = "0981234141" },
                new Client { Id = 2, Name = "Роман", LastName = "Симоненко", Gender = Gender.Male, Phone = "0961234567" },
                new Client { Id = 3, Name = "Петр", LastName = "Климов", Gender = Gender.Male, Phone = "0671234567" },
                new Client { Id = 4, Name = "Анна", LastName = "Полунина", Gender = Gender.Female, Phone = "0638765432" },
                new Client { Id = 5, Name = "Виктория", LastName = "Грин", Gender = Gender.Female, Phone = "0979876543" }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Андрей", LastName = "Смит", Phone = "0987654343", Position = "слесарь" },
                new Employee { Id = 2, Name = "Борис", LastName = "Звонкий", Phone = "0678954433", Position = "электрик" },
                new Employee { Id = 3, Name = "Иван", LastName = "Иванов", Phone = "0989994421", Position = "шиномонтажник" }
                );
            modelBuilder.Entity<Part>().HasData(
                new Part { Id = 1, Name = "Воздушный фильтр", SerialNumber = "WA09752" },
                new Part { Id = 2, Name = "Тормозной диск", SerialNumber = "DF6143S" },
                new Part { Id = 3, Name = "Радиатор охлаждения двигателя", SerialNumber = "NRF058413" },
                new Part { Id = 4, Name = "Катушка зажигания", SerialNumber = "Facet09.6375" }
                );
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Make = "bmw", Model = "320", Year = new DateTime(2001, 01, 01), BodyStyle = "седан", 
                    Color = "синий", Mileage = 150000, ClientId = 1 },
                new Car { Id = 2, Make = "nissan", Model = "almera", Year = new DateTime(2001, 01, 01), BodyStyle = "седан",
                    Color = "синий", Mileage = 200000, ClientId = 3 },
                new Car { Id = 3, Make = "toyota", Model = "land cruiser 200", Year = new DateTime(2012, 01, 01), 
                    BodyStyle = "кросовер", Color = "черный металлик", Mileage = 25000, },
                new Car { Id = 4, Make = "kia", Model = "ceed 16v", Year = new DateTime(2010, 01, 01), 
                    BodyStyle = "универсал", Color = "серый металлик", Mileage = 80000, ClientId = 5 }
                );
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, BeginningOfWork = new DateTime(2021, 08, 29), EndingOfWork = new DateTime(2021, 09, 10), CarId = 2 },
                new Order { Id = 2, BeginningOfWork = new DateTime(2021, 09, 30), EndingOfWork = new DateTime(2021, 10, 05), CarId = 4 }
                );
            modelBuilder.Entity<OrderEmployee>().HasData(
                new OrderEmployee { OrderId = 1, EmployeeId = 1 },
                new OrderEmployee { OrderId = 1, EmployeeId = 2 },
                new OrderEmployee { OrderId = 2, EmployeeId = 1 },
                new OrderEmployee { OrderId = 2, EmployeeId = 2 },
                new OrderEmployee { OrderId = 2, EmployeeId = 3 }
                );
            modelBuilder.Entity<OrderPart>().HasData(
                new OrderPart { OrderId = 1, PartId = 1 },
                new OrderPart { OrderId = 1, PartId = 3 },
                new OrderPart { OrderId = 2, PartId = 2 }
                );

        }
    }
}
