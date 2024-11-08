using ITEC_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ITEC_API.Database
{
    public class ITECDbContext : DbContext
    {
        public ITECDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MainCourse> MainCourses { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorEnrollment> InstructorEnrollments { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainCourse>()
                 .HasMany(mc => mc.CourseLevels)
                 .WithOne(cl => cl.MainCourse)
                 .HasForeignKey(cl => cl.MainCourseId);


            modelBuilder.Entity<InstructorEnrollment>()
                .HasOne(ie => ie.CourseLevel)
                .WithMany(cl => cl.InstructorEnrollments)
                .HasForeignKey(ie => ie.CourseId);

            modelBuilder.Entity<InstructorEnrollment>()
                .HasOne(ie => ie.Instructor)
                .WithMany(i => i.InstructorEnrollments)
                .HasForeignKey(ie => ie.InstructorId);
        }
    }
}
