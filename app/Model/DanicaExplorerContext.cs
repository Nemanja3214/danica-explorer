using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace app.Model;

public partial class DanicaExplorerContext : DbContext
{
    public DanicaExplorerContext()
    {
    }

    public DanicaExplorerContext(DbContextOptions<DanicaExplorerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attraction> Attractions { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<TripAttraction> TripAttractions { get; set; }

    public virtual DbSet<TripService> TripServices { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=danica_explorer;Username=postgres;Password=password");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attraction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attractions_pkey");

            entity.ToTable("attractions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Location).WithMany(p => p.Attractions)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("attractions_location_id_fkey");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("locations_pkey");

            entity.ToTable("locations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reservations_pkey");

            entity.ToTable("reservations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.TripId).HasColumnName("trip_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Trip).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("reservations_trip_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("reservations_user_id_fkey");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("services_pkey");

            entity.ToTable("services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Ishotel).HasColumnName("ishotel");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Location).WithMany(p => p.Services)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("services_location_id_fkey");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("trips_pkey");

            entity.ToTable("trips");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Durationindays).HasColumnName("durationindays");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TripAttraction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("trip_attraction_pkey");

            entity.ToTable("trip_attraction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AttractionId).HasColumnName("attraction_id");
            entity.Property(e => e.TripId).HasColumnName("trip_id");

            entity.HasOne(d => d.Attraction).WithMany(p => p.TripAttractions)
                .HasForeignKey(d => d.AttractionId)
                .HasConstraintName("trip_attraction_attraction_id_fkey");

            entity.HasOne(d => d.Trip).WithMany(p => p.TripAttractions)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("trip_attraction_trip_id_fkey");
        });

        modelBuilder.Entity<TripService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("trip_service_pkey");

            entity.ToTable("trip_service");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TripId).HasColumnName("trip_id");

            entity.HasOne(d => d.Service).WithMany(p => p.TripServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("trip_service_service_id_fkey");

            entity.HasOne(d => d.Trip).WithMany(p => p.TripServices)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("trip_service_trip_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Isagent).HasColumnName("isagent");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
