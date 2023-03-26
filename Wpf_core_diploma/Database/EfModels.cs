using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DIPloma.DataBase.Entity;

namespace DIPloma.DataBase
{
    public partial class EfModels : DbContext
    {
        private static EfModels _instanse;

        public static EfModels init()
        {
            if (_instanse == null)
            {
                _instanse = new EfModels();
            }
            return _instanse;
        }
        public EfModels()
        {
        }

        public EfModels(DbContextOptions<EfModels> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<DayWeek> DayWeeks { get; set; } = null!;
        public virtual DbSet<EducationalClass> EducationalClasses { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Journal> Journals { get; set; } = null!;
        public virtual DbSet<ListItem> ListItems { get; set; } = null!;
        public virtual DbSet<Patronu> Patronus { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<SectionSchedule> SectionSchedules { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentInfoParent> StudentInfoParents { get; set; } = null!;
        public virtual DbSet<Subiectum> Subiecta { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=twilson.ru;port=3306;database=ISPr22-33_BirukovAA_WpfApp_diploma2;user id=Diplom2;password=QvjG{td4lrrb;character set=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.41-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("attendance");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.SectionSchedules, "fk_attendance_sectionSchedules_idx");

                entity.HasIndex(e => e.Students, "fk_attendance_students_idx");

                entity.Property(e => e.PresenceMark).HasColumnType("tinyint(4)");

                entity.Property(e => e.SectionSchedules)
                    .HasColumnType("int(11)")
                    .HasColumnName("sectionSchedules");

                entity.Property(e => e.Students)
                    .HasColumnType("int(11)")
                    .HasColumnName("students");

                entity.HasOne(d => d.SectionSchedulesNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SectionSchedules)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_attendance_sectionSchedules");

                entity.HasOne(d => d.StudentsNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Students)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_attendance_students");
            });

            modelBuilder.Entity<DayWeek>(entity =>
            {
                entity.HasKey(e => e.IdDayWeek)
                    .HasName("PRIMARY");

                entity.ToTable("DayWeek");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IdDayWeek)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDayWeek");

                entity.Property(e => e.NameDayWeek).HasMaxLength(45);
            });

            modelBuilder.Entity<EducationalClass>(entity =>
            {
                entity.HasKey(e => e.Idgroup)
                    .HasName("PRIMARY");

                entity.ToTable("educationalClass");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Idgroup)
                    .HasColumnType("int(11)")
                    .HasColumnName("idgroup");

                entity.Property(e => e.ClassNumber)
                    .HasMaxLength(45)
                    .HasColumnName("classNumber");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Idgender)
                    .HasName("PRIMARY");

                entity.ToTable("gender");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Idgender)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idgender");

                entity.Property(e => e.Names).HasMaxLength(45);
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.HasKey(e => e.Idjournal)
                    .HasName("PRIMARY");

                entity.ToTable("journal");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ListItems, "fk_jornal_listItems_idx");

                entity.HasIndex(e => e.Students, "fk_jornal_student_idx");

                entity.Property(e => e.Idjournal)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idjournal");

                entity.Property(e => e.Aestimatio)
                    .HasColumnType("int(11)")
                    .HasColumnName("aestimatio");

                entity.Property(e => e.Comment).HasMaxLength(100);

                entity.Property(e => e.ListItems)
                    .HasColumnType("int(11)")
                    .HasColumnName("listItems");

                entity.Property(e => e.Students)
                    .HasColumnType("int(11)")
                    .HasColumnName("students");

                entity.HasOne(d => d.ListItemsNavigation)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.ListItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jornal_listItems");

                entity.HasOne(d => d.StudentsNavigation)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.Students)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jornal_student");
            });

            modelBuilder.Entity<ListItem>(entity =>
            {
                entity.HasKey(e => e.Idschedule)
                    .HasName("PRIMARY");

                entity.ToTable("listItems");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Subiectum, "fk_listItems_Objects_idx");

                entity.HasIndex(e => e.Teachers, "fk_listItems_Teacher_idx");

                entity.HasIndex(e => e.Users, "fk_listItems_Users_idx");

                entity.Property(e => e.Idschedule)
                    .HasColumnType("int(11)")
                    .HasColumnName("idschedule");

                entity.Property(e => e.Subiectum)
                    .HasColumnType("int(11)")
                    .HasColumnName("subiectum");

                entity.Property(e => e.Teachers).HasColumnType("int(11)");

                entity.Property(e => e.Users).HasColumnType("int(11)");

                entity.HasOne(d => d.SubiectumNavigation)
                    .WithMany(p => p.ListItems)
                    .HasForeignKey(d => d.Subiectum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_listItems_subiectum");

                entity.HasOne(d => d.TeachersNavigation)
                    .WithMany(p => p.ListItems)
                    .HasForeignKey(d => d.Teachers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_listItems_Teacher");

                entity.HasOne(d => d.UsersNavigation)
                    .WithMany(p => p.ListItems)
                    .HasForeignKey(d => d.Users)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_listItems_Users");
            });

            modelBuilder.Entity<Patronu>(entity =>
            {
                entity.HasKey(e => e.IdinfoParents)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Gender, "fk_infoParents_gender_idx");

                entity.Property(e => e.IdinfoParents)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idinfoParents");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasColumnName("gender");

                entity.Property(e => e.Login).HasMaxLength(45);

                entity.Property(e => e.MiddleNames).HasMaxLength(45);

                entity.Property(e => e.Names).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.SurNames).HasMaxLength(45);

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Patronus)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_infoParents_gender");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PRIMARY");

                entity.ToTable("Role");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IdRole)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRole");

                entity.Property(e => e.Names).HasMaxLength(45);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.Idsections)
                    .HasName("PRIMARY");

                entity.ToTable("sections");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Teachers, "fk_sections_techer_idx");

                entity.Property(e => e.Idsections)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idsections");

                entity.Property(e => e.NameSection).HasMaxLength(45);

                entity.Property(e => e.Teachers)
                    .HasColumnType("int(11)")
                    .HasColumnName("teachers");

                entity.HasOne(d => d.TeachersNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.Teachers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sections_techer");
            });

            modelBuilder.Entity<SectionSchedule>(entity =>
            {
                entity.HasKey(e => e.IdsectionSchedules)
                    .HasName("PRIMARY");

                entity.ToTable("sectionSchedules");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.IdDayWeek, "fk_sectionSchedules_DayWeek1_idx");

                entity.HasIndex(e => e.Sections, "fk_sectionSchedules_sections_idx");

                entity.Property(e => e.IdsectionSchedules)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idsectionSchedules");

                entity.Property(e => e.IdDayWeek)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDayWeek");

                entity.Property(e => e.Sections)
                    .HasColumnType("int(11)")
                    .HasColumnName("sections");

                entity.Property(e => e.TimeSpending).HasColumnType("time");

                entity.HasOne(d => d.IdDayWeekNavigation)
                    .WithMany(p => p.SectionSchedules)
                    .HasForeignKey(d => d.IdDayWeek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sectionSchedules_DayWeek1");

                entity.HasOne(d => d.SectionsNavigation)
                    .WithMany(p => p.SectionSchedules)
                    .HasForeignKey(d => d.Sections)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sectionSchedules_sections");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Idstudents)
                    .HasName("PRIMARY");

                entity.ToTable("students");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Group, "fk_students_group_idx");

                entity.Property(e => e.Idstudents)
                    .HasColumnType("int(11)")
                    .HasColumnName("idstudents");

                entity.Property(e => e.Group)
                    .HasColumnType("int(11)")
                    .HasColumnName("group");

                entity.Property(e => e.Login).HasMaxLength(45);

                entity.Property(e => e.MiddleNameStudent).HasMaxLength(45);

                entity.Property(e => e.NameStudent).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.SurnameStudent).HasMaxLength(45);

                entity.HasOne(d => d.GroupNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Group)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_students_group");
            });

            modelBuilder.Entity<StudentInfoParent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Student_infoParents");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.StudentParentsParents, "fk_Student_infoParents_Parents_idx");

                entity.HasIndex(e => e.StudentParentsStudent, "fk_Student_infoParents_Student_idx");

                entity.Property(e => e.StudentParentsParents)
                    .HasColumnType("int(11)")
                    .HasColumnName("StudentParents_Parents");

                entity.Property(e => e.StudentParentsStudent)
                    .HasColumnType("int(11)")
                    .HasColumnName("StudentParents_Student");

                entity.HasOne(d => d.StudentParentsParentsNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.StudentParentsParents)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Student_infoParents_Parents");

                entity.HasOne(d => d.StudentParentsStudentNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.StudentParentsStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Student_infoParents_Student");
            });

            modelBuilder.Entity<Subiectum>(entity =>
            {
                entity.HasKey(e => e.Idobjects)
                    .HasName("PRIMARY");

                entity.ToTable("subiectum");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Idobjects)
                    .HasColumnType("int(11)")
                    .HasColumnName("idobjects");

                entity.Property(e => e.NameSubiectum).HasMaxLength(45);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.IdTeachers)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IdTeachers)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idTeachers");

                entity.Property(e => e.DateBirth).HasColumnName("dateBirth");

                entity.Property(e => e.MiddleNameTeacher).HasMaxLength(45);

                entity.Property(e => e.NameTeacher).HasMaxLength(45);

                entity.Property(e => e.OfficeNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("officeNumber");

                entity.Property(e => e.SurnameTeacher).HasMaxLength(45);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUserss)
                    .HasName("PRIMARY");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Role, "fk_Users_Role_idx");

                entity.Property(e => e.IdUserss)
                    .HasColumnType("int(11)")
                    .HasColumnName("idUserss");

                entity.Property(e => e.DobleNameUser).HasMaxLength(45);

                entity.Property(e => e.Login).HasMaxLength(45);

                entity.Property(e => e.Mail).HasMaxLength(45);

                entity.Property(e => e.NameUser).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.Role).HasColumnType("int(11)");

                entity.Property(e => e.SurNameUser).HasMaxLength(45);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
