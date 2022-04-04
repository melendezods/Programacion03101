using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadServicios.Entities.Entities
{
    public partial class UnedProyectosContext : DbContext
    {
        public UnedProyectosContext()
        {
        }

        public UnedProyectosContext(DbContextOptions<UnedProyectosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Crew> Crew { get; set; }
        public virtual DbSet<Crewperson> Crewperson { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Luggage> Luggage { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TypeAirplane> TypeAirplane { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAuthentication> UsersAuthentication { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=UnedProyectos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.IdAirplane).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdTypeAirplaneNavigation)
                    .WithMany(p => p.Airplane)
                    .HasForeignKey(d => d.IdTypeAirplane)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AIRPLANE");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Crew>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Crewperson>(entity =>
            {
                entity.HasKey(e => new { e.IdCrew, e.IdPerson });

                entity.Property(e => e.IdPerson).IsUnicode(false);

                entity.HasOne(d => d.IdCrewNavigation)
                    .WithMany(p => p.Crewperson)
                    .HasForeignKey(d => d.IdCrew)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREWPERSON_CREW");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Crewperson)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREWPERSON_PERSON");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.Airplane).IsUnicode(false);

                entity.Property(e => e.Direct).IsUnicode(false);

                entity.Property(e => e.Duration).IsUnicode(false);

                entity.HasOne(d => d.AirplaneNavigation)
                    .WithMany(p => p.Flight)
                    .HasForeignKey(d => d.Airplane)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLIGHT_AIRPLANE");

                entity.HasOne(d => d.IdCrewNavigation)
                    .WithMany(p => p.Flight)
                    .HasForeignKey(d => d.IdCrew)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLIGHT_CREW");

                entity.HasOne(d => d.IdDestinationCountryNavigation)
                    .WithMany(p => p.FlightIdDestinationCountryNavigation)
                    .HasForeignKey(d => d.IdDestinationCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLIGHT_COUNTRY_DESTINATION");

                entity.HasOne(d => d.IdOriginCountryNavigation)
                    .WithMany(p => p.FlightIdOriginCountryNavigation)
                    .HasForeignKey(d => d.IdOriginCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLIGHT_COUNTRY");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Gender1).IsUnicode(false);
            });

            modelBuilder.Entity<Luggage>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ShortDes).IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Identification).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.IdPerson).ValueGeneratedOnAdd();

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);

                entity.HasOne(d => d.IdGenderNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.IdGender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERSON_GENDER");

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERSON_POSITION");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Position1).IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.IdUser).IsUnicode(false);

                entity.Property(e => e.SeatNumber).IsUnicode(false);

                entity.HasOne(d => d.IdFlightNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.IdFlight)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TICKET_FLIGHT");

                entity.HasOne(d => d.IdLuggageNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.IdLuggage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TICKET_LUGGAGE");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TICKET_USERS");
            });

            modelBuilder.Entity<TypeAirplane>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ShortDes).IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);
            });

            modelBuilder.Entity<UsersAuthentication>(entity =>
            {
                entity.HasKey(e => new { e.Email, e.Code });

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.UsersAuthentication)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERS_AUTHENTICATION");
            });
            modelBuilder.Entity<UsersAuthentication>().Ignore(c => c.Id);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
