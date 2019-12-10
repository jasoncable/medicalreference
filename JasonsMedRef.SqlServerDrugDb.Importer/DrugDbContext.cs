using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class DrugDbContext : DbContext
    {
        public DrugDbContext()
        {
        }

        public DrugDbContext(DbContextOptions<DrugDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationType> ApplicationType { get; set; }
        public virtual DbSet<DosageForm> DosageForm { get; set; }
        public virtual DbSet<Drug> Drug { get; set; }
        public virtual DbSet<DrugPharmaClassXref> DrugPharmaClassXref { get; set; }
        public virtual DbSet<DrugSchedule> DrugSchedule { get; set; }
        public virtual DbSet<DrugType> DrugType { get; set; }
        public virtual DbSet<Exclusivity> Exclusivity { get; set; }
        public virtual DbSet<MarketingCategory> MarketingCategory { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Patent> Patent { get; set; }
        public virtual DbSet<PharmaClass> PharmaClass { get; set; }
        public virtual DbSet<PharmaClassClass> PharmaClassClass { get; set; }
        public virtual DbSet<RouteOfAdministration> RouteOfAdministration { get; set; }
        public virtual DbSet<Strength> Strength { get; set; }
        public virtual DbSet<TherapeuticEquivalenceCode> TherapeuticEquivalenceCode { get; set; }
        public virtual DbSet<TradeName> TradeName { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=JLCDrugs;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.Property(e => e.Applicant)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicantFullName).IsUnicode(false);

                entity.Property(e => e.ApplicationNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Strength).IsUnicode(false);

                entity.HasOne(d => d.ApplicationType)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.ApplicationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_ApplicationType");

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.DrugId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Drug");

                entity.HasOne(d => d.TherapeuticEquivalenceCode)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.TherapeuticEquivalenceCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_TECode");
            });

            modelBuilder.Entity<ApplicationType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DosageForm>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameExtended)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.Property(e => e.EndMarketingDate).HasColumnType("datetime");

                entity.Property(e => e.Ingredient)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.StartMarketingDate).HasColumnType("datetime");

                entity.HasOne(d => d.DosageForm)
                    .WithMany(p => p.Drug)
                    .HasForeignKey(d => d.DosageFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drug_DosageForm");

                entity.HasOne(d => d.DrugSchedule)
                    .WithMany(p => p.Drug)
                    .HasForeignKey(d => d.DrugScheduleId)
                    .HasConstraintName("FK_Drug_DrugSchedule");

                entity.HasOne(d => d.DrugType)
                    .WithMany(p => p.Drug)
                    .HasForeignKey(d => d.DrugTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drug_DrugType");

                entity.HasOne(d => d.MarketingCategory)
                    .WithMany(p => p.Drug)
                    .HasForeignKey(d => d.MarketingCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drug_MarketingCategory");

                entity.HasOne(d => d.RouteOfAdmin)
                    .WithMany(p => p.Drug)
                    .HasForeignKey(d => d.RouteOfAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drug_RouteOfAdministration");
            });

            modelBuilder.Entity<DrugPharmaClassXref>(entity =>
            {
                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.DrugPharmaClassXref)
                    .HasForeignKey(d => d.DrugId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DrugPharmaClassXref_Drug");

                entity.HasOne(d => d.PharmaClass)
                    .WithMany(p => p.DrugPharmaClassXref)
                    .HasForeignKey(d => d.PharmaClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DrugPharmaClassXref_PharmaClass");
            });

            modelBuilder.Entity<DrugSchedule>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DrugType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameExtended)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exclusivity>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Expiration).HasColumnType("datetime");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Exclusivity)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exclusivity_Application");
            });

            modelBuilder.Entity<MarketingCategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NameExtended).IsUnicode(false);
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.EndMarketingDate).HasColumnType("datetime");

                entity.Property(e => e.LabelerName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Ndc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NdcDashed)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StartMarketingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.Package)
                    .HasForeignKey(d => d.DrugId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Package_Drug");
            });

            modelBuilder.Entity<Patent>(entity =>
            {
                entity.Property(e => e.Expiration).HasColumnType("datetime");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Patent)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patent_Application");
            });

            modelBuilder.Entity<PharmaClass>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.PharmaClassClass)
                    .WithMany(p => p.PharmaClass)
                    .HasForeignKey(d => d.PharmaClassClassId)
                    .HasConstraintName("FK_PharmaClass_PharmaClassClass");
            });

            modelBuilder.Entity<PharmaClassClass>(entity =>
            {
                entity.Property(e => e.ExtendedName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RouteOfAdministration>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameExtended)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Strength>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.Strength)
                    .HasForeignKey(d => d.DrugId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Strength_Drug");
            });

            modelBuilder.Entity<TherapeuticEquivalenceCode>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TradeName>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.TradeName)
                    .HasForeignKey(d => d.DrugId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TradeName_Drug");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
