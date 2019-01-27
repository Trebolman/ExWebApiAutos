using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infraestructure.Persistencia
{
    public partial class CarsDbContext : DbContext
    {
        public CarsDbContext()
        {
        }

        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCar> TCar { get; set; }
        public virtual DbSet<TMarca> TMarca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source = DANOSHINPC\\SQLEXPRESS; Initial Catalog = CarsDB; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<TCar>(entity =>
            {
                entity.HasKey(e => e.IdCar);

                entity.ToTable("t_car");

                entity.Property(e => e.IdCar)
                    .HasColumnName("id_car")
                    .ValueGeneratedNever();

                entity.Property(e => e.CarCol)
                    .HasColumnName("car_col")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CarIsFull)
                    .HasColumnName("car_is_full")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CarIsMec)
                    .HasColumnName("car_is_mec")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CarMarca)
                    .HasColumnName("car_marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CarNroAsien)
                    .HasColumnName("car_nro_asien")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CarNroPlaca)
                    .HasColumnName("car_nro_placa")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CarYear)
                    .HasColumnName("car_year")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MarcaId).HasColumnName("marca_id");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.TCar)
                    .HasForeignKey(d => d.MarcaId)
                    .HasConstraintName("FK_t_car_t_marca");
            });

            modelBuilder.Entity<TMarca>(entity =>
            {
                entity.HasKey(e => e.MarcaId);

                entity.ToTable("t_marca");

                entity.Property(e => e.MarcaId)
                    .HasColumnName("marca_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MarcaName)
                    .HasColumnName("marca_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
