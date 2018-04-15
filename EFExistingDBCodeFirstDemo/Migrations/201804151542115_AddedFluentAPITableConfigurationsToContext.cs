namespace EFExistingDBCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFluentAPITableConfigurationsToContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagCourses", newName: "CourseTags");
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Courses", name: "Author_Id", newName: "AuthorId");
            RenameColumn(table: "dbo.CourseTags", name: "Course_Id", newName: "CourseId");
            RenameColumn(table: "dbo.CourseTags", name: "Tag_Id", newName: "TagId");
            RenameIndex(table: "dbo.CourseTags", name: "IX_Course_Id", newName: "IX_CourseId");
            RenameIndex(table: "dbo.CourseTags", name: "IX_Tag_Id", newName: "IX_TagId");
            AlterColumn("dbo.Courses", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Courses", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "AuthorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", new[] { "AuthorId" });
            AlterColumn("dbo.Courses", "AuthorId", c => c.Int());
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Title", c => c.String());
            RenameIndex(table: "dbo.CourseTags", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.CourseTags", name: "IX_CourseId", newName: "IX_Course_Id");
            RenameColumn(table: "dbo.CourseTags", name: "TagId", newName: "Tag_Id");
            RenameColumn(table: "dbo.CourseTags", name: "CourseId", newName: "Course_Id");
            RenameColumn(table: "dbo.Courses", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.Courses", "Author_Id");
            RenameTable(name: "dbo.CourseTags", newName: "TagCourses");
        }
    }
}
