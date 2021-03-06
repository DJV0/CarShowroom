// <auto-generated />
using Carshowroom.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Carshowroom.DAL.Migrations
{
    [DbContext(typeof(CarShowroomDbContext))]
    [Migration("20210929141149_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarShowroom.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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
#pragma warning restore 612, 618
        }
    }
}
