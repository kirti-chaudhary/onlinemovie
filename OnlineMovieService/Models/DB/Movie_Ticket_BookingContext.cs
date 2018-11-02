using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineMovieService.Models.DB
{
    public partial class Movie_Ticket_BookingContext : DbContext
    {
        public Movie_Ticket_BookingContext()
        {
        }

        public Movie_Ticket_BookingContext(DbContextOptions<Movie_Ticket_BookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookedseat> Bookedseat { get; set; }
        public virtual DbSet<Bookingdetails> Bookingdetails { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Multiplex> Multiplex { get; set; }
        public virtual DbSet<MultiplexHall> MultiplexHall { get; set; }
        public virtual DbSet<Shows> Shows { get; set; }

        // Unable to generate entity type for table 'dbo.prod'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=Movie_Ticket_Booking;trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookedseat>(entity =>
            {
                entity.HasKey(e => e.Ticketno);

                entity.ToTable("bookedseat");

                entity.Property(e => e.Ticketno).HasColumnName("ticketno");

                entity.Property(e => e.Bookingid).HasColumnName("bookingid");

                entity.Property(e => e.Seatno)
                    .IsRequired()
                    .HasColumnName("seatno")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Bookedseat)
                    .HasForeignKey(d => d.Bookingid)
                    .HasConstraintName("FK_bookedseat_Bookingdetails");
            });

            modelBuilder.Entity<Bookingdetails>(entity =>
            {
                entity.HasKey(e => e.Bookingid);

                entity.Property(e => e.Bookingid).HasColumnName("bookingid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Paymentdate)
                    .HasColumnName("paymentdate")
                    .HasColumnType("date");

                entity.Property(e => e.Paymentmethod)
                    .HasColumnName("paymentmethod")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Paymenttime).HasColumnName("paymenttime");

                entity.Property(e => e.Showid).HasColumnName("showid");

                entity.Property(e => e.Totalprice).HasColumnName("totalprice");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookingdetails)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookingdetails_Customer");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phoneno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MovieDuration)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MovieImage).IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Multiplex>(entity =>
            {
                entity.Property(e => e.MultiplexCity)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MultiplexEmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MultiplexName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MultiplexPhoneno)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MultiplexHall>(entity =>
            {
                entity.HasKey(e => e.HallId);

                entity.Property(e => e.HallName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shows>(entity =>
            {
                entity.HasKey(e => e.ShowId);

                entity.Property(e => e.ShowId).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ShowDate).HasColumnType("date");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shows_movie");

                entity.HasOne(d => d.Multiplex)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.MultiplexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shows_Multiplex");
            });
        }
    }
}
