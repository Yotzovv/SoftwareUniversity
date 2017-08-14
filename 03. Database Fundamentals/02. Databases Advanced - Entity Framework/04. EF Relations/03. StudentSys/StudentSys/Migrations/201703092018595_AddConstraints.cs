namespace StudentSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraints : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Homework", "CourseId", c => c.Int(nullable: false));
            //AddColumn("dbo.Homework", "StudentId", c => c.Int(nullable: false));
            //AddColumn("dbo.Resources", "CourseId", c => c.Int(nullable: false));
            //Sql("ALTER TABLE StudentCourses ADD PRIMARY KEY (Student_Id, Course_Id)");
            //AddForeignKey("Resources", "CourseId", "Courses", "Id");
            //AddForeignKey("StudentCourses", "Course_Id", "Courses", "Id");
            //AddForeignKey("StudentCourses", "Student_Id", "Students", "Id");
            //AddForeignKey("Homework", "CourseId", "Courses", "Id");
            //AddForeignKey("Homework", "StudentId", "Students", "Id");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "CourseId");
            DropColumn("dbo.Homework", "StudentId");
            DropColumn("dbo.Homework", "CourseId");
        }
    }
}
