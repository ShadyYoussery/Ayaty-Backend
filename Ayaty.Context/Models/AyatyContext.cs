using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ayaty.Context.Models
{
    public partial class AyatyContext : DbContext
    {
        public AyatyContext()
        {
        }

        public AyatyContext(DbContextOptions<AyatyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<CityLanguage> CityLanguage { get; set; }
        public virtual DbSet<Clinic> Clinic { get; set; }
        public virtual DbSet<ClinicComminicationWay> ClinicComminicationWay { get; set; }
        public virtual DbSet<ClinicLanguage> ClinicLanguage { get; set; }
        public virtual DbSet<ClinicPermission> ClinicPermission { get; set; }
        public virtual DbSet<ClinicPermissionLanguage> ClinicPermissionLanguage { get; set; }
        public virtual DbSet<ClinicUser> ClinicUser { get; set; }
        public virtual DbSet<ClinicUserComminicationWay> ClinicUserComminicationWay { get; set; }
        public virtual DbSet<ClinicUserLanguage> ClinicUserLanguage { get; set; }
        public virtual DbSet<CommincationWay> CommincationWay { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryLanguage> CountryLanguage { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StateLanguage> StateLanguage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GU88C36;Initial Catalog=Ayaty;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_State");
            });

            modelBuilder.Entity<CityLanguage>(entity =>
            {
                entity.HasKey(e => new { e.CityId, e.LanguageId });

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CityLanguage)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CityLanguage_City");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CityLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CityLanguage_Language");
            });

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Logo).HasMaxLength(250);

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(9, 6)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Clinic)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clinic_City");
            });

            modelBuilder.Entity<ClinicComminicationWay>(entity =>
            {
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.ClinicComminicationWay)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicComminicationWay_Clinic");

                entity.HasOne(d => d.ClinicNavigation)
                    .WithMany(p => p.ClinicComminicationWay)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicComminicationWay_CommincationWay");
            });

            modelBuilder.Entity<ClinicLanguage>(entity =>
            {
                entity.HasKey(e => new { e.ClinicId, e.LanguageId });

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Address2).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.ClinicLanguage)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicLanguage_Clinic");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ClinicLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicLanguage_Language");
            });

            modelBuilder.Entity<ClinicPermissionLanguage>(entity =>
            {
                entity.HasKey(e => new { e.ClinicPermissionId, e.LanguageId });

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ClinicPermission)
                    .WithMany(p => p.ClinicPermissionLanguage)
                    .HasForeignKey(d => d.ClinicPermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicPermissionLanguage_ClinicPermission");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ClinicPermissionLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicPermissionLanguage_Language");
            });

            modelBuilder.Entity<ClinicUser>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ClinicId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.HashPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SaltPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.ClinicUser)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicUser_Clinic");
            });

            modelBuilder.Entity<ClinicUserComminicationWay>(entity =>
            {
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.ClinicUserComminicationWay)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicUserComminicationWay_CommincationWay");

                entity.HasOne(d => d.Clin)
                    .WithMany(p => p.ClinicUserComminicationWay)
                    .HasForeignKey(d => new { d.ClinetUserId, d.ClinicId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicUserComminicationWay_ClinicUser");
            });

            modelBuilder.Entity<ClinicUserLanguage>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ClinicUserLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicUserLanguage_Language");

                entity.HasOne(d => d.Clin)
                    .WithMany(p => p.ClinicUserLanguage)
                    .HasForeignKey(d => new { d.ClinetUserId, d.ClinicId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicUserLanguage_ClinicUser");
            });

            modelBuilder.Entity<CommincationWay>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CountryLanguage>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.LanguageId });

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryLanguage)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountryLanguage_Country");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CountryLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountryLanguage_Language");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_State_Country");
            });

            modelBuilder.Entity<StateLanguage>(entity =>
            {
                entity.HasKey(e => new { e.StateId, e.LanguageId });

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.StateLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StateLanguage_Language");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.StateLanguage)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StateLanguage_State");
            });
        }
    }
}
