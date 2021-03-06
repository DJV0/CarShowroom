// <auto-generated />
using System;
using Carshowroom.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Carshowroom.DAL.Migrations
{
    [DbContext(typeof(CarShowroomDbContext))]
    [Migration("20211012181937_UpdateDeleteBehavior")]
    partial class UpdateDeleteBehavior
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarShowroom.Models.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BodyStyle")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("Year")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BodyStyle = "седан",
                            ClientId = 1,
                            Color = "синий",
                            Make = "bmw",
                            Model = "320",
                            Year = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BodyStyle = "седан",
                            ClientId = 3,
                            Color = "синий",
                            Make = "nissan",
                            Model = "almera",
                            Year = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            BodyStyle = "кросовер",
                            Color = "черный металлик",
                            Make = "toyota",
                            Model = "land cruiser 200",
                            Year = new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            BodyStyle = "универсал",
                            ClientId = 5,
                            Color = "серый металлик",
                            Make = "kia",
                            Model = "ceed 16v",
                            Year = new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastName = "Terentiev",
                            Name = "Oleh",
                            Phone = "0981234141"
                        },
                        new
                        {
                            Id = 2,
                            LastName = "Simonenko",
                            Name = "Roman",
                            Phone = "0961234567"
                        },
                        new
                        {
                            Id = 3,
                            LastName = "Klimov",
                            Name = "Petr",
                            Phone = "0671234567"
                        },
                        new
                        {
                            Id = 4,
                            LastName = "Polunin",
                            Name = "Sergei",
                            Phone = "0638765432"
                        },
                        new
                        {
                            Id = 5,
                            LastName = "Green",
                            Name = "Stas",
                            Phone = "0979876543"
                        });
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastName = "Смит",
                            Name = "Андрей",
                            Phone = "0987654343",
                            Position = "слесарь"
                        },
                        new
                        {
                            Id = 2,
                            LastName = "Звонкий",
                            Name = "Борис",
                            Phone = "0678954433",
                            Position = "электрик"
                        },
                        new
                        {
                            Id = 3,
                            LastName = "Иванов",
                            Name = "Иван",
                            Phone = "0989994421",
                            Position = "шиномонтажник"
                        });
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginningOfWork")
                        .HasColumnType("Date");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndingOfWork")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique()
                        .HasFilter("[CarId] IS NOT NULL");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BeginningOfWork = new DateTime(2021, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 2,
                            EndingOfWork = new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BeginningOfWork = new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 4,
                            EndingOfWork = new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.OrderEmployee", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("OrderEmployee");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            EmployeeId = 1
                        },
                        new
                        {
                            OrderId = 1,
                            EmployeeId = 2
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 2
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 3
                        });
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.OrderPart", b =>
                {
                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "PartId");

                    b.HasIndex("PartId");

                    b.ToTable("OrderPart");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            PartId = 1
                        },
                        new
                        {
                            OrderId = 1,
                            PartId = 3
                        },
                        new
                        {
                            OrderId = 2,
                            PartId = 2
                        });
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.ToTable("Parts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Воздушный фильтр",
                            SerialNumber = "WA09752"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Тормозной диск",
                            SerialNumber = "DF6143S"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Радиатор охлаждения двигателя",
                            SerialNumber = "NRF058413"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Катушка зажигания",
                            SerialNumber = "Facet09.6375"
                        });
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Car", b =>
                {
                    b.HasOne("CarShowroom.Models.Entities.Client", "Client")
                        .WithMany("Cars")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Order", b =>
                {
                    b.HasOne("CarShowroom.Models.Entities.Car", "Car")
                        .WithOne("Order")
                        .HasForeignKey("CarShowroom.Models.Entities.Order", "CarId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.OrderEmployee", b =>
                {
                    b.HasOne("CarShowroom.Models.Entities.Employee", "Employee")
                        .WithMany("OrderEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarShowroom.Models.Entities.Order", "Order")
                        .WithMany("OrderEmployees")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.OrderPart", b =>
                {
                    b.HasOne("CarShowroom.Models.Entities.Order", "Order")
                        .WithMany("OrderParts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarShowroom.Models.Entities.Part", "Part")
                        .WithMany("OrderParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Car", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Client", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Employee", b =>
                {
                    b.Navigation("OrderEmployees");
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Order", b =>
                {
                    b.Navigation("OrderEmployees");

                    b.Navigation("OrderParts");
                });

            modelBuilder.Entity("CarShowroom.Models.Entities.Part", b =>
                {
                    b.Navigation("OrderParts");
                });
#pragma warning restore 612, 618
        }
    }
}
