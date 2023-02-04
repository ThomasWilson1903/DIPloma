using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Wpf_core_diploma.Database.Entity;

namespace Wpf_core_diploma.Database
{
    public partial class EfModels : DbContext
    {
        public EfModels()
        {
        }
        private static EfModels Instance;
        public static EfModels init()
        {
            if (Instance == null)
                Instance = new EfModels();
            return Instance;
        }
        public EfModels(DbContextOptions<EfModels> options)
            : base(options)
        {
        }

        public virtual DbSet<Userss> Usersses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr22-33_BirukovAA;password=ISPr22-33_BirukovAA;character set=utf8;database=ISPr22-33_BirukovAA_WpfApp_diploma2", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Userss>(entity =>
            {
                entity.HasKey(e => e.IdUserss)
                    .HasName("PRIMARY");

                entity.ToTable("Userss");

                entity.Property(e => e.IdUserss).HasColumnName("idUserss");

                entity.Property(e => e.Login).HasMaxLength(45);

                entity.Property(e => e.Mail).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
