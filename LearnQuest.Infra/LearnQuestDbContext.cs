using LearnQuest.Dominio.Class.Entidades;
using LearnQuest.Dominio.Grade.Entidades;
using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Subject.Entidades;
using LearnQuest.Dominio.Teacher.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LearnQuest.Infra
{
    public class LearnQuestDbContext : DbContext
    {
        public DbSet<Parents> Parents { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Teacherss> Teachers { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Grades> Grades { get; set; }

        public LearnQuestDbContext(DbContextOptions<LearnQuestDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parents>().ToTable("Parent");
            modelBuilder.Entity<Students>().ToTable("Student");
            modelBuilder.Entity<Classe>().ToTable("Class");
            modelBuilder.Entity<Teacherss>().ToTable("Teacher");
            modelBuilder.Entity<Subjects>().ToTable("Subject");
            modelBuilder.Entity<Grades>().ToTable("Grade");

            modelBuilder.Entity<Teacherss>()
                .HasMany(t => t.Classes)
                .WithMany(c => c.Teachers)
                .UsingEntity("TeacherClasses",
                    j => j.HasOne(typeof(Classe)).WithMany().HasForeignKey("ClassId"),
                    j => j.HasOne(typeof(Teacherss)).WithMany().HasForeignKey("TeacherId"),
                    j => j.ToTable("TeacherClasses")
                );
        }
    }
}