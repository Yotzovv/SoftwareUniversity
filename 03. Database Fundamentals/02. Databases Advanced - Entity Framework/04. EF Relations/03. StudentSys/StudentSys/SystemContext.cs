namespace StudentSys
{
    using Migrations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SystemContext : DbContext
    {
        public SystemContext()
            : base("name=SystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SystemContext, Configuration>());
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
    }
}