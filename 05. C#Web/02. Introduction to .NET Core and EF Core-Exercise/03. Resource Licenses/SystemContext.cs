using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class SystemContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<StudentCourse> StudentsCourses { get; set; }
    public DbSet<License> Licenses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<StudentCourse>()
               .HasKey(sc => new { sc.Student_Id, sc.Course_Id });

        builder.Entity<Student>()
               .HasMany(s => s.Courses)
               .WithOne(c => c.Student)
               .HasForeignKey(c => c.Student_Id);

        builder.Entity<Student>()
               .HasMany(s => s.Homeworks)
               .WithOne(h => h.Student)
               .HasForeignKey(h => h.StudentId);

        builder.Entity<Course>()
               .HasMany(c => c.Participants)
               .WithOne(s => s.Course)
               .HasForeignKey(s => s.Course_Id);

        builder.Entity<Course>()
               .HasMany(c => c.Resources)
               .WithOne(r => r.Course)
               .HasForeignKey(r => r.CourseId);

        builder.Entity<Course>()
               .HasMany(c => c.Homework)
               .WithOne(h => h.Course)
               .HasForeignKey(h => h.CourseId);

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Server=DESKTOP-52OK68M\SQLEXPRESS;Database=TestDb;Integrated Security=True;");
        base.OnConfiguring(builder);
    }
}
