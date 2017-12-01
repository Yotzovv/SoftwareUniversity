﻿using LerningSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LerningSystem.Data
{
    public class LearningSystemDbContext : IdentityDbContext<User>
    {
        public LearningSystemDbContext(DbContextOptions<LearningSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudentCourse>()
                   .HasKey(st => new { st.CourseId, st.StudentId });

            builder.Entity<StudentCourse>()
                   .HasOne(sc => sc.Student)
                   .WithMany(s => s.Courses)
                   .HasForeignKey(sc => sc.StudentId);

            builder.Entity<StudentCourse>()
                   .HasOne(sc => sc.Course)
                   .WithMany(c => c.Students)
                   .HasForeignKey(c => c.CourseId);

            builder.Entity<Course>()
                   .HasOne(c => c.Trainer)
                   .WithMany(u => u.Trainings)
                   .HasForeignKey(c => c.TrainerId);

            builder.Entity<Article>()
                   .HasOne(a => a.Author)
                   .WithMany(u => u.Articles)
                   .HasForeignKey(a => a.AuthorId);
        }
    }
}
