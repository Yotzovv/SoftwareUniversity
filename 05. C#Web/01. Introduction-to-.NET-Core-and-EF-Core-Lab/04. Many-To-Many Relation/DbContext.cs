using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentsCourses>()
                    .HasKey(sc => new { sc.StudentId, sc.CourseId });

        modelBuilder.Entity<StudentsCourses>()
                    .HasOne<Student>(sc => sc.Student)
                    .WithMany(st => st.StudentsCourses)
                    .HasForeignKey(sc => sc.StudentId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-52OK68M\SQLEXPRESS;Database=TestDb;Integrated Security=True;");
    }
}